using System;
using System.Data;
using System.Text.RegularExpressions;
using Phoenix.Core;
using Phoenix.HabboHotel.Misc;
using Phoenix.HabboHotel.Users.UserDataManagement;
using Phoenix.HabboHotel.Support;
using Phoenix.Messages;
using Phoenix.Util;
using Phoenix.HabboHotel.Users;
using Phoenix.Net;
using Phoenix.HabboHotel.Users.Authenticator;
using Phoenix.Storage;
namespace Phoenix.HabboHotel.GameClients
{
	internal sealed class GameClient
	{
		private uint uint_0;
		private SocketConnection gclass1_0;
		private GameClientMessageHandler class17_0;
		private Habbo Habbo;
		public bool bool_0;
		internal bool bool_1 = false;
		private bool bool_2 = false;
		public uint UInt32_0
		{
			get
			{
				return this.uint_0;
			}
		}
		public bool Boolean_0
		{
			get
			{
				return this.Habbo != null;
			}
		}
		public GameClient(uint uint_1, ref SocketConnection gclass1_1)
		{
			this.uint_0 = uint_1;
			this.gclass1_0 = gclass1_1;
		}
		public SocketConnection GetConnection()
		{
			return this.gclass1_0;
		}
		public GameClientMessageHandler method_1()
		{
			return this.class17_0;
		}
		public Habbo GetHabbo()
		{
			return this.Habbo;
		}
		public void method_3()
		{
			if (this.gclass1_0 != null)
			{
				this.bool_0 = true;
				SocketConnection.AtReceiveCallback gdelegate0_ = new SocketConnection.AtReceiveCallback(this.method_13);
				this.gclass1_0.StartIO(gdelegate0_);
			}
		}
		internal void method_4()
		{
			this.class17_0 = new GameClientMessageHandler(this);
		}
		internal ServerMessage method_5()
		{
			return Phoenix.GetGame().GetNavigator().method_12(this, -3);
		}
		internal void method_6(string string_0)
		{
			try
			{
				UserDataFactory @class = new UserDataFactory(string_0, this.GetConnection().Ip, true);
				if (this.GetConnection().Ip == "127.0.0.1" && !@class.Boolean_0)
				{
					@class = new UserDataFactory(string_0, "::1", true);
				}
				if (!@class.Boolean_0)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					string str = "";
					if (Config.Boolean_2)
					{
						str = PhoenixEnvironment.GetExternalText("emu_sso_wrong_secure") + "(" + this.GetConnection().Ip + ")";
					}
					ServerMessage gClass = new ServerMessage(161u);
					gClass.AppendStringWithBreak(PhoenixEnvironment.GetExternalText("emu_sso_wrong") + str);
					this.GetConnection().SendMessage(gClass);
					Console.ForegroundColor = ConsoleColor.Gray;
					this.method_12();
					return;
				}
				Habbo class2 = LoginHelper.smethod_0(string_0, this, @class, @class);
				Phoenix.GetGame().GetClientManager().method_25(class2.Id);
				this.Habbo = class2;
				this.Habbo.method_2(@class);
				string a;
				using (DatabaseClient class3 = Phoenix.GetDatabase().GetClient())
				{
					a = class3.ReadString("SELECT ip_last FROM users WHERE id = " + this.GetHabbo().Id + " LIMIT 1;");
				}
				this.Habbo.bool_0 = (this.GetConnection().Ip == Phoenix.string_5 || a == Phoenix.string_5);
				if (this.Habbo.bool_0)
				{
					this.Habbo.uint_1 = (uint)Phoenix.GetGame().GetRoleManager().method_9();
					this.Habbo.bool_14 = true;
				}
			}
			catch (Exception ex)
			{
				this.SendNotif("Login error: " + ex.Message);
				//Logging.LogException(ex.ToString());
				this.method_12();
				return;
			}
			try
			{
				Phoenix.GetGame().GetBanManager().method_1(this);
			}
			catch (ModerationBanException gException)
			{
				this.method_7(gException.Message);
				this.method_12();
				return;
			}
			ServerMessage gClass2 = new ServerMessage(2u);
			if (this.GetHabbo().bool_14 || Config.Boolean_3)
			{
				gClass2.AppendInt32(2);
			}
			else
			{
				if (this.GetHabbo().method_20().method_2("habbo_club"))
				{
					gClass2.AppendInt32(1);
				}
				else
				{
					gClass2.AppendInt32(0);
				}
			}
			if (this.GetHabbo().HasFuse("acc_anyroomowner"))
			{
				gClass2.AppendInt32(7);
			}
			else
			{
				if (this.GetHabbo().HasFuse("acc_anyroomrights"))
				{
					gClass2.AppendInt32(5);
				}
				else
				{
					if (this.GetHabbo().HasFuse("acc_supporttool"))
					{
						gClass2.AppendInt32(4);
					}
					else
					{
						if (this.GetHabbo().bool_14 || Config.Boolean_3 || this.GetHabbo().method_20().method_2("habbo_club"))
						{
							gClass2.AppendInt32(2);
						}
						else
						{
							gClass2.AppendInt32(0);
						}
					}
				}
			}
			this.method_14(gClass2);

            this.method_14(this.GetHabbo().method_24().method_6());

			ServerMessage gClass3 = new ServerMessage(290u);
			gClass3.AppendBoolean(true);
			gClass3.AppendBoolean(false);
			this.method_14(gClass3);

			ServerMessage gclass5_ = new ServerMessage(3u);
			this.method_14(gclass5_);

            if (this.GetHabbo().HasFuse("acc_supporttool"))
            {
                // Permissions bugfix by [Shorty]

                //this.GetHabbo().bool_0 = true;
                //this.GetHabbo().bool_14 = true;
                //this.method_2().uint_1 = (uint)Phoenix.GetGame().method_4().method_9();

                this.method_14(Phoenix.GetGame().GetModerationTool().method_0());
                Phoenix.GetGame().GetModerationTool().method_4(this);
            }
			

			ServerMessage Logging = new ServerMessage(517u);
			Logging.AppendBoolean(true);
			this.method_14(Logging);
			if (Phoenix.GetGame().GetPixelManager().method_2(this))
			{
				Phoenix.GetGame().GetPixelManager().method_3(this);
			}
			ServerMessage gClass5 = new ServerMessage(455u);
			gClass5.AppendUInt(this.GetHabbo().uint_4);
			this.method_14(gClass5);
			ServerMessage gClass6 = new ServerMessage(458u);
			gClass6.AppendInt32(30);
			gClass6.AppendInt32(this.GetHabbo().list_1.Count);
			foreach (uint current in this.GetHabbo().list_1)
			{
				gClass6.AppendUInt(current);
			}
			this.method_14(gClass6);
			if (this.GetHabbo().int_15 > 8294400)
			{
				Phoenix.GetGame().GetAchievementManager().method_3(this, 16u, 10);
			}
			else
			{
				if (this.GetHabbo().int_15 > 4147200)
				{
					Phoenix.GetGame().GetAchievementManager().method_3(this, 16u, 9);
				}
				else
				{
					if (this.GetHabbo().int_15 > 2073600)
					{
						Phoenix.GetGame().GetAchievementManager().method_3(this, 16u, 8);
					}
					else
					{
						if (this.GetHabbo().int_15 > 1036800)
						{
							Phoenix.GetGame().GetAchievementManager().method_3(this, 16u, 7);
						}
						else
						{
							if (this.GetHabbo().int_15 > 518400)
							{
								Phoenix.GetGame().GetAchievementManager().method_3(this, 16u, 6);
							}
							else
							{
								if (this.GetHabbo().int_15 > 172800)
								{
									Phoenix.GetGame().GetAchievementManager().method_3(this, 16u, 5);
								}
								else
								{
									if (this.GetHabbo().int_15 > 57600)
									{
										Phoenix.GetGame().GetAchievementManager().method_3(this, 16u, 4);
									}
									else
									{
										if (this.GetHabbo().int_15 > 28800)
										{
											Phoenix.GetGame().GetAchievementManager().method_3(this, 16u, 3);
										}
										else
										{
											if (this.GetHabbo().int_15 > 10800)
											{
												Phoenix.GetGame().GetAchievementManager().method_3(this, 16u, 2);
											}
											else
											{
												if (this.GetHabbo().int_15 > 3600)
												{
													Phoenix.GetGame().GetAchievementManager().method_3(this, 16u, 1);
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			if (Config.String_4 != "")
			{
				this.SendNotif(Config.String_4, 2);
			}
			for (uint num = (uint)Phoenix.GetGame().GetRoleManager().method_9(); num > 1u; num -= 1u)
			{
				if (Phoenix.GetGame().GetRoleManager().method_8(num).Length > 0)
				{
					if (!this.GetHabbo().method_22().method_1(Phoenix.GetGame().GetRoleManager().method_8(num)) && this.GetHabbo().uint_1 == num)
					{
						this.GetHabbo().method_22().method_2(this, Phoenix.GetGame().GetRoleManager().method_8(num), true);
					}
					else
					{
						if (this.GetHabbo().method_22().method_1(Phoenix.GetGame().GetRoleManager().method_8(num)) && this.GetHabbo().uint_1 < num)
						{
							this.GetHabbo().method_22().method_6(Phoenix.GetGame().GetRoleManager().method_8(num));
						}
					}
				}
			}
			if (this.GetHabbo().method_20().method_2("habbo_club") && !this.GetHabbo().method_22().method_1("HC1"))
			{
				this.GetHabbo().method_22().method_2(this, "HC1", true);
			}
			else
			{
				if (!this.GetHabbo().method_20().method_2("habbo_club") && this.GetHabbo().method_22().method_1("HC1"))
				{
					this.GetHabbo().method_22().method_6("HC1");
				}
			}
			if (this.GetHabbo().bool_14 && !this.GetHabbo().method_22().method_1("VIP"))
			{
				this.GetHabbo().method_22().method_2(this, "VIP", true);
			}
			else
			{
				if (!this.GetHabbo().bool_14 && this.GetHabbo().method_22().method_1("VIP"))
				{
					this.GetHabbo().method_22().method_6("VIP");
				}
			}
			if (this.GetHabbo().CurrentQuestId > 0u)
			{
				Phoenix.GetGame().GetQuestManager().method_7(this.GetHabbo().CurrentQuestId, this);
			}
			if (!Regex.IsMatch(this.GetHabbo().Username, "^[-a-zA-Z0-9._:,]+$"))
			{
				ServerMessage gclass5_2 = new ServerMessage(573u);
				this.method_14(gclass5_2);
			}
			this.GetHabbo().string_4 = Phoenix.smethod_7(this.GetHabbo().string_4);
			DataTable dataTable = null;
			using (DatabaseClient class3 = Phoenix.GetDatabase().GetClient())
			{
				dataTable = class3.ReadDataTable("SELECT achievement,achlevel FROM achievements_owed WHERE user = '" + this.GetHabbo().Id + "'");
			}
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					Phoenix.GetGame().GetAchievementManager().method_3(this, (uint)dataRow["achievement"], (int)dataRow["achlevel"]);
					using (DatabaseClient class3 = Phoenix.GetDatabase().GetClient())
					{
						class3.ExecuteQuery(string.Concat(new object[]
						{
							"DELETE FROM achievements_owed WHERE achievement = '",
							(uint)dataRow["achievement"],
							"' AND user = '",
							this.GetHabbo().Id,
							"' LIMIT 1"
						}));
					}
				}
			}
		}
		public void method_7(string string_0)
		{
			ServerMessage gClass = new ServerMessage(35u);
			gClass.AppendStringWithBreak("A moderator has kicked you from the hotel:", 13);
			gClass.AppendStringWithBreak(string_0);
			this.method_14(gClass);
		}
		public void SendNotif(string Message)
		{
			this.SendNotif(Message, 0);
		}
		public void SendNotif(string string_0, int int_0)
		{
			ServerMessage nMessage = new ServerMessage();
			switch (int_0)
			{
			case 0:
				nMessage.Init(161u);
				break;
			case 1:
				nMessage.Init(139u);
				break;
			case 2:
				nMessage.Init(810u);
				nMessage.AppendUInt(1u);
				break;
			default:
				nMessage.Init(161u);
				break;
			}
			nMessage.AppendStringWithBreak(string_0);
			this.GetConnection().SendMessage(nMessage);
		}
		public void method_10(string string_0, string string_1)
		{
			ServerMessage gClass = new ServerMessage(161u);
			gClass.AppendStringWithBreak(string_0);
			gClass.AppendStringWithBreak(string_1);
			this.GetConnection().SendMessage(gClass);
		}
		public void method_11()
		{
			if (this.gclass1_0 != null)
			{
				this.gclass1_0.Dispose();
				this.gclass1_0 = null;
			}
			if (this.GetHabbo() != null)
			{
				this.Habbo.method_9();
				this.Habbo = null;
			}
			if (this.method_1() != null)
			{
				this.class17_0.Destroy();
				this.class17_0 = null;
			}
		}
		public void method_12()
		{
			if (!this.bool_2)
			{
				Phoenix.GetGame().GetClientManager().RemoveId(this.uint_0);
				this.bool_2 = true;
			}
		}
		public void method_13(ref byte[] byte_0)
		{
			if (byte_0[0] == 64)
			{
				int i = 0;
				while (i < byte_0.Length)
				{
					try
					{
						int num = Base64Encoding.DecodeInt32(new byte[]
						{
							byte_0[i++],
							byte_0[i++],
							byte_0[i++]
						});
						uint uint_ = Base64Encoding.DecodeUInt32(new byte[]
						{
							byte_0[i++],
							byte_0[i++]
						});
						byte[] array = new byte[num - 2];
						for (int j = 0; j < array.Length; j++)
						{
							array[j] = byte_0[i++];
						}
						if (this.class17_0 == null)
						{
							this.method_4();
						}
						ClientMessage @class = new ClientMessage(uint_, array);
						if (@class != null)
						{
							try
							{
								if (int.Parse(Phoenix.GetConfig().data["debug"]) == 1)
								{
									Logging.WriteLine(string.Concat(new object[]
									{
										"[",
										this.UInt32_0,
										"] --> [",
										@class.Id,
										"] ",
										@class.Header,
										@class.GetBody()
									}));
								}
							}
							catch
							{
							}
							Interface @interface;
							if (Phoenix.GetPackets().Handle(@class.Id, out @interface))
							{
								@interface.imethod_0(this, @class);
							}
						}
					}
					catch (Exception ex)
					{
                        Logging.LogException("Error: " + ex.ToString());
						this.method_12();
					}
				}
			}
			else
			{
				if (true)//Class13.Boolean_7)
				{
                    this.gclass1_0.SendData(CrossdomainPolicy.GetXmlPolicy());
					this.gclass1_0.Dispose();
				}
			}
		}
		public void method_14(ServerMessage gclass5_0)
		{
			if (gclass5_0 != null && this.GetConnection() != null)
			{
				this.GetConnection().SendMessage(gclass5_0);
			}
		}
	}
}
