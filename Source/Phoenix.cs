using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Phoenix.Core;
using Phoenix.HabboHotel;
using Phoenix.Net;
using Phoenix.Storage;
using Phoenix.Util;
using Phoenix.Communication;
using Phoenix.Messages;
namespace Phoenix
{
    internal sealed class Phoenix
    {
        public const int build = 14986;
        //public const string LicenseServer = "localhost";
        private static PacketManager Packets;
        private static ConfigurationData Configuration;
        private static DatabaseManager DatabaseManager;
        private static SocketsManager ConnectionManager;
        private static MusListener MusListener;
        public static Game Game;
        internal static DateTime ServerStarted;
        //public string string_2 = Phoenix.smethod_1(14986.ToString());
        //public string string_3 = LicenceServer + "licence" + Convert.ToChar(46).ToString() + "php" + Convert.ToChar(63).ToString();
        //public static string string_4 = LicenceServer + "override" + Convert.ToChar(46).ToString() + "php";
        //public static bool bool_0 = false;
        public static int int_1 = 0;
        //public static int int_2 = 0;
        public static string string_5 = null;
        //public static string LicenseName;
        //public static string LicensePass;
        private static bool ShutdownStarted = false;
        //internal static string LicenceServer;   //Licence server (config.conf)

        public static string PrettyVersion
        {
            get
            {
                return "Phoenix v3.11.0 (Build " + build + ")";
            }
        }

        public static string MD5Upper(string string_8)
        {
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] array = Encoding.UTF8.GetBytes(string_8);
            array = mD5CryptoServiceProvider.ComputeHash(array);
            StringBuilder stringBuilder = new StringBuilder();
            byte[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                byte b = array2[i];
                stringBuilder.Append(b.ToString("x2").ToLower());
            }
            return stringBuilder.ToString().ToUpper();
        }

        public static string SHA1(string string_8)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(string_8);
            byte[] array = new SHA1Managed().ComputeHash(bytes);
            string text = string.Empty;
            byte[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                byte b = array2[i];
                text += b.ToString("X2");
            }
            return text;
        }
        public void Initialize()
        {
            //if (!Licence.CheckHostsFile(true))
            //{

            Phoenix.ServerStarted = DateTime.Now;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("        ______  _                       _          _______             ");
            Console.WriteLine("       (_____ \\| |                     (_)        (_______)            ");
            Console.WriteLine("        _____) ) | _   ___   ____ ____  _ _   _    _____   ____  _   _ ");
            Console.WriteLine("       |  ____/| || \\ / _ \\ / _  )  _ \\| ( \\ / )  |  ___) |    \\| | | |");
            Console.WriteLine("       | |     | | | | |_| ( (/ /| | | | |) X (   | |_____| | | | |_| |");
            Console.WriteLine("       |_|     |_| |_|\\___/ \\____)_| |_|_(_/ \\_)  |_______)_|_|_|\\____|");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                       " + PrettyVersion);
            Console.WriteLine();
            Console.WriteLine("          Dedicated and VPS Hosting available at Otaku-Hosting.com");
            Console.WriteLine("    VPS Hosting from just £4.99 for the first month with coupon OTAKU50!");
            Console.WriteLine();
            Console.ResetColor();

            try
            {
                Phoenix.Configuration = new ConfigurationData("config.conf");
                DateTime now = DateTime.Now;
                /*LicenceServer = GetConfig().data["LicenceServer.URL"];  //LicenceServer URL
                string_6 = GetConfig().data["Otaku-Studios.username"];
                string_7 = GetConfig().data["Otaku-Studios.password"];
                string_7 = new Random().Next(Int32.MaxValue).ToString();
                int num = string_6.Length * string_7.Length;

                if (string_6 == "" || string_7 == "" || Class13.Boolean_7)
                {
                    //Console.WriteLine();
                    //Console.ForegroundColor = ConsoleColor.Red;
                    //Phoenix.Destroy("Invalid Licence details found #0001", false);
                }
                else
                {
                    Class13.String_6 = Phoenix.string_6;
                    Class13.String_3 = Phoenix.string_7;
                    string text = new Random().Next(Int32.MaxValue).ToString();
                    text = Licence.smethod_1(text, this.string_3);

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    string str = new Random().Next(Int32.MaxValue).ToString();//text.Substring(32, 32);
                    str = Phoenix.smethod_0(str + Phoenix.string_6);
                    str = Phoenix.smethod_0(str + "4g");
                    str = Phoenix.smethod_1(str + Phoenix.string_7);
                    string b = Phoenix.smethod_0(num.ToString());*/

                DatabaseServer DBServer = new DatabaseServer(Phoenix.GetConfig().data["db.hostname"], uint.Parse(Phoenix.GetConfig().data["db.port"]), Phoenix.GetConfig().data["db.username"], Phoenix.GetConfig().data["db.password"]);
                //text = "r4r43mfgp3kkkr3mgprekw[gktp6ijhy[h]5h76ju6j7uj7";//text.Substring(64, 96);
                Database DB = new Database(Phoenix.GetConfig().data["db.name"], uint.Parse(Phoenix.GetConfig().data["db.pool.minsize"]), uint.Parse(Phoenix.GetConfig().data["db.pool.maxsize"]));
                Phoenix.DatabaseManager = new DatabaseManager(DBServer, DB);

                try
                {
                    using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
                    {
                        @class.ExecuteQuery("UPDATE users SET online = '0'");
                        @class.ExecuteQuery("UPDATE rooms SET users_now = '0'");
                    }
                    Phoenix.ConnectionManager.DisconnectAll();
                    Phoenix.Game.ContinueLoading();
                }
                catch
                {
                }

                //Class13.String_1 = text;
                Phoenix.Game = new Game(int.Parse(Phoenix.GetConfig().data["game.tcp.conlimit"]));
                //string text2 = Class13.String_5 + Phoenix.MD5((Class13.String_6.Length * 14986).ToString());
                //text2 += Phoenix.MD5((Class13.String_3.Length % 14986).ToString());

                Phoenix.Packets = new PacketManager();
                Phoenix.Packets.Handshake();
                Phoenix.Packets.Messenger();
                Phoenix.Packets.Navigator();
                Phoenix.Packets.RoomsAction();
                Phoenix.Packets.RoomsAvatar();
                Phoenix.Packets.RoomsChat();
                Phoenix.Packets.RoomsEngine();
                Phoenix.Packets.RoomsFurniture();
                Phoenix.Packets.RoomsPets();
                Phoenix.Packets.RoomsSession();
                Phoenix.Packets.RoomsSettings();
                Phoenix.Packets.Catalog();
                Phoenix.Packets.Marketplace();
                Phoenix.Packets.Recycler();
                Phoenix.Packets.Quest();
                Phoenix.Packets.InventoryAchievements();
                Phoenix.Packets.InventoryAvatarFX();
                Phoenix.Packets.InventoryBadges();
                Phoenix.Packets.InventoryFurni();
                Phoenix.Packets.InventoryPurse();
                Phoenix.Packets.InventoryTrading();
                Phoenix.Packets.Avatar();
                Phoenix.Packets.Users();
                Phoenix.Packets.Register();
                Phoenix.Packets.Help();
                Phoenix.Packets.Sound();
                Phoenix.Packets.Wired();
                //}

                Config.GamePort = int.Parse(Phoenix.GetConfig().data["game.tcp.port"]);
                Config.MusPort = int.Parse(Phoenix.GetConfig().data["mus.tcp.port"]);

                Phoenix.MusListener = new MusListener(Phoenix.GetConfig().data["mus.tcp.bindip"],
                    Config.MusPort, Phoenix.GetConfig().data["mus.tcp.allowedaddr"].Split(new char[] { ';' }), 20);
                Phoenix.ConnectionManager = new SocketsManager(/*Config.string_33,*/ Config.GamePort, int.Parse(Phoenix.GetConfig().data["game.tcp.conlimit"]));
                Phoenix.ConnectionManager.GetListener().Start();
                TimeSpan timeSpan = DateTime.Now - now;
                Logging.WriteLine(string.Concat(new object[]
					{
						"Server -> READY! (",
						timeSpan.Seconds,
						" s, ",
						timeSpan.Milliseconds,
						" ms)"
					}));
                Console.Beep();
            }
            /*catch (KeyNotFoundException)
            {
                Logging.WriteLine("Failed to boot, key not found.");
                Logging.WriteLine("Press any key to shut down ...");
                Console.ReadKey(true);
                Phoenix.smethod_16();
            }
            catch (InvalidOperationException ex)
            {
                Logging.WriteLine("Failed to initialize PhoenixEmulator: " + ex.Message);
                Logging.WriteLine("Press any key to shut down ...");
                Console.ReadKey(true);
                Phoenix.smethod_16();
            }*/
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            //}
        }
        public static int smethod_2(string string_8)
        {
            return Convert.ToInt32(string_8);
        }
        public static bool smethod_3(string string_8)
        {
            return string_8 == "1";
        }
        public static string smethod_4(bool bool_2)
        {
            if (bool_2)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        public static int smethod_5(int int_3, int int_4)
        {
            RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] array = new byte[4];
            rNGCryptoServiceProvider.GetBytes(array);
            int seed = BitConverter.ToInt32(array, 0);
            return new Random(seed).Next(int_3, int_4 + 1);
        }
        public static double GetUnixTimestamp()
        {
            return (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
        }
        public static string smethod_7(string string_8)
        {
            return smethod_8(string_8, false, false);
        }
        public static string smethod_8(string Input, bool bool_2, bool bool_3)
        {
            Input = Input.Replace(Convert.ToChar(1), ' ');
            Input = Input.Replace(Convert.ToChar(2), ' ');
            Input = Input.Replace(Convert.ToChar(9), ' ');
            if (!bool_2)
            {
                Input = Input.Replace(Convert.ToChar(13), ' ');
            }
            if (bool_3)
            {
                Input = Input.Replace('\'', ' ');
            }
            return Input;
        }
        public static bool smethod_9(string string_8)
        {
            if (string.IsNullOrEmpty(string_8))
            {
                return false;
            }
            else
            {
                for (int i = 0; i < string_8.Length; i++)
                {
                    if (!char.IsLetter(string_8[i]) && !char.IsNumber(string_8[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public static PacketManager GetPackets()
        {
            return Phoenix.Packets;
        }
        public static ConfigurationData GetConfig()
        {
            return Configuration;
        }
        public static DatabaseManager GetDatabase()
        {
            return DatabaseManager;
        }
        public static Encoding GetDefaultEncoding()
        {
            return Encoding.Default;
        }
        public static SocketsManager GetConnectionManager()
        {
            return Phoenix.ConnectionManager;
        }
        internal static Game GetGame()
        {
            return Game;
        }
        public static void DestroyEnvironment()
        {
            try
            {
                Logging.WriteLine("Destroying PhoenixEmu environment...");
                if (Phoenix.GetGame() != null)
                {
                    Phoenix.GetGame().ContinueLoading();
                    Phoenix.Game = null;
                }
                if (Phoenix.GetConnectionManager() != null)
                {
                    Logging.WriteLine("Destroying connection manager.");
                    Phoenix.GetConnectionManager().GetListener().CloseAndFree();
                    Phoenix.GetConnectionManager().Close();
                    Phoenix.ConnectionManager = null;
                }
                if (Phoenix.GetDatabase() != null)
                {
                    try
                    {
                        Logging.WriteLine("Destroying database manager.");
                        MySqlConnection.ClearAllPools();
                        Phoenix.DatabaseManager = null;
                    }
                    catch
                    {
                    }
                }

                Logging.WriteLine("Uninitialized successfully. Closing.");
            }
            catch
            {
            }
        }
        internal static void HotelAlert(string MSG)
        {
            try
            {
                ServerMessage gClass = new ServerMessage(139u);
                gClass.AppendStringWithBreak(MSG);
                Phoenix.GetGame().GetClientManager().SendToAll(gClass);
            }
            catch
            {
            }
        }
        internal static void smethod_18()
        {
            Phoenix.Destroy("", true);
        }
        internal static void Destroy(string LogLine, bool ExitWhenDone)
        {
            //Config.bool_16 = true;

            try
            {
                Phoenix.GetPackets().Clear();
            }
            catch
            {
            }

            if (LogLine != "")
            {
                if (Phoenix.ShutdownStarted)
                {
                    return;
                }

                Console.WriteLine(LogLine);
                Logging.StartLog();
                Phoenix.HotelAlert("ATTENTION:\r\nThe server is shutting down. All furniture placed in rooms/traded/bought after this message is on your own responsibillity.");
                Phoenix.ShutdownStarted = true;
                Console.WriteLine("Server shutting down...");
                try
                {
                    Phoenix.Game.GetRoomManager().EmptyAllRooms();
                }
                catch
                {
                }
                try
                {
                    Phoenix.GetConnectionManager().GetListener().Close();
                    Phoenix.GetGame().GetClientManager().CloseAll();
                }
                catch
                {

                }
                try
                {
                    Console.WriteLine("Destroying database manager.");
                    MySqlConnection.ClearAllPools();
                    Phoenix.DatabaseManager = null;
                }
                catch
                {
                }

                Console.WriteLine("System disposed, goodbye!");
            }
            else
            {
                Logging.StartLog();
                Phoenix.ShutdownStarted = true;
                try
                {
                    Phoenix.Game.GetRoomManager().EmptyAllRooms();
                }
                catch
                {
                }

                try
                {
                    Phoenix.GetConnectionManager().GetListener().Close();
                    Phoenix.GetGame().GetClientManager().CloseAll();
                }
                catch
                {
                }

                Phoenix.ConnectionManager.DisconnectAll();
                Phoenix.Game.ContinueLoading();
                Console.WriteLine(LogLine);
            }

            //if (ExitWhenDone)
            //{
                Environment.Exit(0);
            //}
        }
        public static bool smethod_20(int int_3, int int_4)
        {
            return int_3 % int_4 == 0;
        }
        public static DateTime smethod_21(double double_0)
        {
            DateTime result = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return result.AddSeconds(double_0).ToLocalTime();
        }
    }
}
