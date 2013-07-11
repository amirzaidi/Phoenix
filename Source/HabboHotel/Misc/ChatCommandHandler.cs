using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Phoenix.Core;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Achievements;
using Phoenix.HabboHotel.Users;
using Phoenix.Util;
using Phoenix.Messages;
using Phoenix.HabboHotel.Users.Authenticator;
using Phoenix.HabboHotel.Items;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Storage;
namespace Phoenix.HabboHotel.Misc
{
	internal sealed class ChatCommandHandler
	{
		private static List<string> list_0;
		private static List<string> list_1;
		private static List<bool> list_2;
		private static List<string> list_3;
		public static void smethod_0(DatabaseClient class6_0)
		{
            Logging.Write("Loading Chat Filter..");
			ChatCommandHandler.list_0 = new List<string>();
			ChatCommandHandler.list_1 = new List<string>();
			ChatCommandHandler.list_2 = new List<bool>();
			ChatCommandHandler.list_3 = new List<string>();
			ChatCommandHandler.InitWords(class6_0);
            Logging.WriteLine("completed!");
		}
		public static void InitWords(DatabaseClient dbClient)
		{
			ChatCommandHandler.list_0.Clear();
			ChatCommandHandler.list_1.Clear();
			ChatCommandHandler.list_2.Clear();
			ChatCommandHandler.list_3.Clear();
			DataTable dataTable = dbClient.ReadDataTable("SELECT * FROM wordfilter ORDER BY word ASC;");
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					ChatCommandHandler.list_0.Add(dataRow["word"].ToString());
					ChatCommandHandler.list_1.Add(dataRow["replacement"].ToString());
					ChatCommandHandler.list_2.Add(Phoenix.smethod_3(dataRow["strict"].ToString()));
				}
			}
			DataTable dataTable2 = dbClient.ReadDataTable("SELECT * FROM linkfilter;");
			if (dataTable2 != null)
			{
				foreach (DataRow dataRow in dataTable2.Rows)
				{
					ChatCommandHandler.list_3.Add(dataRow["externalsite"].ToString());
				}
			}
		}
		public static bool InitLinks(string URLs)
		{
			if (Config.String_2 == "disabled")
			{
				return false;
			}
			else
			{
				if ((URLs.StartsWith("http://") || URLs.StartsWith("www.") || URLs.StartsWith("https://")) && ChatCommandHandler.list_3 != null && ChatCommandHandler.list_3.Count > 0)
				{
					foreach (string current in ChatCommandHandler.list_3)
					{
						if (URLs.Contains(current))
						{
							if (Config.String_2 == "whitelist")
							{
								return true;
							}
							if (!(Config.String_2 == "blacklist"))
							{
							}
						}
					}
				}
				return (URLs.StartsWith("http://") || URLs.StartsWith("www.") || (URLs.StartsWith("https://") && Config.String_2 == "blacklist") || (Config.String_2 == "whitelist" && false));
			}
		}
		public static string smethod_3(string string_0)
		{
			try
			{
			}
			catch
			{
			}
			return string_0;
		}
		public static string smethod_4(string string_0)
		{
			if (ChatCommandHandler.list_0 != null && ChatCommandHandler.list_0.Count > 0)
			{
				int num = -1;
				foreach (string current in ChatCommandHandler.list_0)
				{
					num++;
					if (string_0.ToLower().Contains(current.ToLower()) && ChatCommandHandler.list_2[num])
					{
						string_0 = Regex.Replace(string_0, current, ChatCommandHandler.list_1[num], RegexOptions.IgnoreCase);
					}
					else
					{
						if (string_0.ToLower().Contains(" " + current.ToLower() + " "))
						{
							string_0 = Regex.Replace(string_0, current, ChatCommandHandler.list_1[num], RegexOptions.IgnoreCase);
						}
					}
				}
			}
			return string_0;
		}
		public static bool smethod_5(GameClient Session, string string_0)
		{
			string[] Params = string_0.Split(new char[]
			{
				' '
			});
			GameClient TargetClient = null;
			Room class2 = Session.GetHabbo().Class14_0;
			if (!Phoenix.GetGame().GetRoleManager().dictionary_4.ContainsKey(Params[0]))
			{
				return false;
			}
			else
			{
				try
				{
					int num;
					if (class2 != null && class2.method_27(Session, true))
					{
						num = Phoenix.GetGame().GetRoleManager().dictionary_4[Params[0]];
						if (num <= 33)
						{
							if (num == 8)
							{
								class2 = Session.GetHabbo().Class14_0;
								if (class2.bool_5)
								{
									class2.bool_5 = false;
								}
								else
								{
									class2.bool_5 = true;
								}
								Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
								return true;
							}
							if (num == 33)
							{
								class2 = Session.GetHabbo().Class14_0;
								if (class2 != null && class2.method_27(Session, true))
								{
									List<UserItemData> list = class2.method_24(Session);
									Session.GetHabbo().method_23().method_17(list);
									Session.GetHabbo().method_23().method_9(true);
									Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0 + " " + Session.GetHabbo().CurrentRoomId);
									return true;
								}
								return false;
							}
						}
						else
						{
							if (num == 46)
							{
								class2 = Session.GetHabbo().Class14_0;
								try
								{
									int num2 = int.Parse(Params[1]);
									if (Session.GetHabbo().uint_1 >= 6u)
									{
										class2.UsersMax = num2;
									}
									else
									{
										if (num2 > 100 || num2 < 5)
										{
											Session.SendNotif("ERROR: Use a number between 5 and 100");
										}
										else
										{
											class2.UsersMax = num2;
										}
									}
								}
								catch
								{
									return false;
								}
								Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
								return true;
							}
							if (num == 53)
							{
								class2 = Session.GetHabbo().Class14_0;
								Phoenix.GetGame().GetRoomManager().method_16(class2);
								Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
								return true;
							}
						}
					}
					switch (Phoenix.GetGame().GetRoleManager().dictionary_4[Params[0]])
					{
					case 2:
					{
						if (!Session.GetHabbo().HasFuse("cmd_alert"))
						{
							return false;
						}
						string TargetUser = Params[1];
						TargetClient = Phoenix.GetGame().GetClientManager().GetClientByHabbo(TargetUser);
						if (TargetClient == null)
						{
							Session.SendNotif("Could not find user: " + TargetUser);
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
                            return true;
						}
						TargetClient.SendNotif(ChatCommandHandler.MergeParams(Params, 2), 0);
						Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
                        return true;
					}
					case 3:
					{
						if (!Session.GetHabbo().HasFuse("cmd_award"))
						{
							return false;
						}
						string text = Params[1];
						TargetClient = Phoenix.GetGame().GetClientManager().GetClientByHabbo(text);
						if (TargetClient == null)
						{
							Session.SendNotif("Could not find user: " + text);
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						Phoenix.GetGame().GetAchievementManager().method_2(TargetClient, Convert.ToUInt32(ChatCommandHandler.MergeParams(Params, 2)));
						Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
						return true;
					}
					case 4:
					{
						if (!Session.GetHabbo().HasFuse("cmd_ban"))
						{
							return false;
						}
						TargetClient = Phoenix.GetGame().GetClientManager().GetClientByHabbo(Params[1]);
						if (TargetClient == null)
						{
							Session.SendNotif("User not found.");
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						if (TargetClient.GetHabbo().uint_1 >= Session.GetHabbo().uint_1 && !Session.GetHabbo().bool_0)
						{
							Session.SendNotif("You are not allowed to ban that user.");
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						int num3 = 0;
						try
						{
							num3 = int.Parse(Params[2]);
						}
						catch (FormatException)
						{
						}
						if (num3 <= 600)
						{
							Session.SendNotif("Ban time is in seconds and must be at least than 600 seconds (ten minutes). For more specific preset ban times, use the mod tool.");
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						Phoenix.GetGame().GetBanManager().method_2(TargetClient, Session.GetHabbo().Username, (double)num3, ChatCommandHandler.MergeParams(Params, 3), false);
						Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
						return true;
					}
					case 6:
					{
						if (!Session.GetHabbo().HasFuse("cmd_coins"))
						{
							return false;
						}
						TargetClient = Phoenix.GetGame().GetClientManager().GetClientByHabbo(Params[1]);
						if (TargetClient == null)
						{
							Session.SendNotif("User could not be found.");
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						int num4;
						if (int.TryParse(Params[2], out num4))
						{
							TargetClient.GetHabbo().Credits = TargetClient.GetHabbo().Credits + num4;
							TargetClient.GetHabbo().method_13(true);
							TargetClient.SendNotif(Session.GetHabbo().Username + " has awarded you " + num4.ToString() + " credits!");
							Session.SendNotif("Credit balance updated successfully.");
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						Session.SendNotif("Please send a valid amount of credits.");
						Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
						return true;
					}
					case 7:
					{
						if (!Session.GetHabbo().HasFuse("cmd_coords"))
						{
							return false;
						}
						class2 = Phoenix.GetGame().GetRoomManager().GetRoom(Session.GetHabbo().CurrentRoomId);
						if (class2 == null)
						{
							return false;
						}
						Class33 class3 = class2.method_53(Session.GetHabbo().Id);
						if (class3 == null)
						{
							return false;
						}
						Session.SendNotif(string.Concat(new object[]
						{
							"X: ",
							class3.int_3,
							" - Y: ",
							class3.int_4,
							" - Z: ",
							class3.double_0,
							" - Rot: ",
							class3.int_8,
							", sqState: ",
							class2.Byte_0[class3.int_3, class3.int_4].ToString()
						}));
						Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
						return true;
					}
					case 11:
						if (Session.GetHabbo().HasFuse("cmd_enable"))
						{
							int int_ = int.Parse(Params[1]);
							Session.GetHabbo().method_24().method_2(int_, true);
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;
					case 14:
						if (Session.GetHabbo().HasFuse("cmd_freeze"))
						{
							Class33 class4 = Session.GetHabbo().Class14_0.method_56(Params[1]);
							if (class4 != null)
							{
								class4.bool_5 = !class4.bool_5;
							}
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;
					case 15:
						if (Session.GetHabbo().HasFuse("cmd_givebadge"))
						{
							TargetClient = Phoenix.GetGame().GetClientManager().GetClientByHabbo(Params[1]);
							if (TargetClient != null)
							{
								TargetClient.GetHabbo().method_22().method_2(TargetClient, Phoenix.smethod_7(Params[2]), true);
							}
							else
							{
								Session.SendNotif("User: " + Params[1] + " could not be found in the database.\rPlease try your request again.");
							}
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;
					case 16:
						if (Session.GetHabbo().HasFuse("cmd_globalcredits"))
						{
							try
							{
								int num5 = int.Parse(Params[1]);
								Phoenix.GetGame().GetClientManager().method_18(num5);
								using (DatabaseClient class5 = Phoenix.GetDatabase().GetClient())
								{
									class5.ExecuteQuery("UPDATE users SET credits = credits + " + num5);
								}
							}
							catch
							{
								Session.SendNotif("Input must be a number");
							}
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;
					case 17:
						if (Session.GetHabbo().HasFuse("cmd_globalpixels"))
						{
							try
							{
								int num5 = int.Parse(Params[1]);
								Phoenix.GetGame().GetClientManager().method_19(num5, false);
								using (DatabaseClient class5 = Phoenix.GetDatabase().GetClient())
								{
									class5.ExecuteQuery("UPDATE users SET activity_points = activity_points + " + num5);
								}
							}
							catch
							{
								Session.SendNotif("Input must be a number");
							}
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;
					case 18:
						if (Session.GetHabbo().HasFuse("cmd_globalpoints"))
						{
							try
							{
								int num5 = int.Parse(Params[1]);
								Phoenix.GetGame().GetClientManager().method_20(num5, false);
								using (DatabaseClient class5 = Phoenix.GetDatabase().GetClient())
								{
									class5.ExecuteQuery("UPDATE users SET vip_points = vip_points + " + num5);
								}
							}
							catch
							{
								Session.SendNotif("Input must be a number");
							}
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;
					case 19:
						if (Session.GetHabbo().HasFuse("cmd_hal"))
						{
							string text2 = Params[1];
							string_0 = string_0.Substring(4).Replace(text2, "");
							string text3 = string_0.Substring(1);
							ServerMessage gClass = new ServerMessage(161u);
							gClass.AppendStringWithBreak(string.Concat(new string[]
							{
								PhoenixEnvironment.GetExternalText("cmd_hal_title"),
								"\r\n",
								text3,
								"\r\n-",
								Session.GetHabbo().Username
							}));
							gClass.AppendStringWithBreak(text2);
							Phoenix.GetGame().GetClientManager().SendToAll(gClass);
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;
					case 20:
						if (Session.GetHabbo().HasFuse("cmd_ha"))
						{
							string str = string_0.Substring(3);
							ServerMessage gClass2 = new ServerMessage(808u);
							gClass2.AppendStringWithBreak(PhoenixEnvironment.GetExternalText("cmd_ha_title"));
							gClass2.AppendStringWithBreak(str + "\r\n- " + Session.GetHabbo().Username);
							ServerMessage gClass3 = new ServerMessage(161u);
							gClass3.AppendStringWithBreak(str + "\r\n- " + Session.GetHabbo().Username);
							Phoenix.GetGame().GetClientManager().method_15(gClass2, gClass3);
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;;
					case 21:
						if (Session.GetHabbo().HasFuse("cmd_invisible"))
						{
							return true;
						}
						return false;
					case 22:
						if (!Session.GetHabbo().HasFuse("cmd_ipban"))
						{
							return false;
						}
						TargetClient = Phoenix.GetGame().GetClientManager().GetClientByHabbo(Params[1]);
						if (TargetClient == null)
						{
							Session.SendNotif("User not found.");
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						if (TargetClient.GetHabbo().uint_1 >= Session.GetHabbo().uint_1 && !Session.GetHabbo().bool_0)
						{
							Session.SendNotif("You are not allowed to ban that user.");
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						Phoenix.GetGame().GetBanManager().method_2(TargetClient, Session.GetHabbo().Username, 360000000.0, ChatCommandHandler.MergeParams(Params, 2), true);
						Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
						return true;
					case 23:
					{
						if (!Session.GetHabbo().HasFuse("cmd_kick"))
						{
							return false;
						}
						string text = Params[1];
						TargetClient = Phoenix.GetGame().GetClientManager().GetClientByHabbo(text);
						if (TargetClient == null)
						{
							Session.SendNotif("Could not find user: " + text);
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						if (Session.GetHabbo().uint_1 <= TargetClient.GetHabbo().uint_1 && !Session.GetHabbo().bool_0)
						{
							Session.SendNotif("You are not allowed to kick that user.");
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						if (TargetClient.GetHabbo().CurrentRoomId < 1u)
						{
							Session.SendNotif("That user is not in a room and can not be kicked.");
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						class2 = Phoenix.GetGame().GetRoomManager().GetRoom(TargetClient.GetHabbo().CurrentRoomId);
						if (class2 == null)
						{
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						class2.method_47(TargetClient, true, false);
						if (Params.Length > 2)
						{
							TargetClient.SendNotif("A moderator has kicked you from the room for the following reason: " + ChatCommandHandler.MergeParams(Params, 2));
						}
						else
						{
							TargetClient.SendNotif("A moderator has kicked you from the room.");
						}
						Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
						return true;
					}
					case 24:
						if (Session.GetHabbo().HasFuse("cmd_massbadge"))
						{
							Phoenix.GetGame().GetClientManager().method_21(Params[1]);
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;
					case 25:
						if (Session.GetHabbo().HasFuse("cmd_masscredits"))
						{
							try
							{
								int num5 = int.Parse(Params[1]);
								Phoenix.GetGame().GetClientManager().method_18(num5);
							}
							catch
							{
								Session.SendNotif("Input must be a number");
							}
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;
					case 26:
						if (Session.GetHabbo().HasFuse("cmd_masspixels"))
						{
							try
							{
								int num5 = int.Parse(Params[1]);
								Phoenix.GetGame().GetClientManager().method_19(num5, true);
							}
							catch
							{
								Session.SendNotif("Input must be a number");
							}
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;
					case 27:
						if (Session.GetHabbo().HasFuse("cmd_masspoints"))
						{
							try
							{
								int num5 = int.Parse(Params[1]);
								Phoenix.GetGame().GetClientManager().method_20(num5, true);
							}
							catch
							{
								Session.SendNotif("Input must be a number");
							}
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;
					case 30:
					{
						if (!Session.GetHabbo().HasFuse("cmd_motd"))
						{
							return false;
						}
						string text = Params[1];
						TargetClient = Phoenix.GetGame().GetClientManager().GetClientByHabbo(text);
						if (TargetClient == null)
						{
							Session.SendNotif("Could not find user: " + text);
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						TargetClient.SendNotif(ChatCommandHandler.MergeParams(Params, 2), 2);
						Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
						return true;
					}
					case 31:
					{
						if (!Session.GetHabbo().HasFuse("cmd_mute"))
						{
							return false;
						}
						string text = Params[1];
						TargetClient = Phoenix.GetGame().GetClientManager().GetClientByHabbo(text);
						if (TargetClient == null || TargetClient.GetHabbo() == null)
						{
							Session.SendNotif("Could not find user: " + text);
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						if (TargetClient.GetHabbo().uint_1 >= Session.GetHabbo().uint_1 && !Session.GetHabbo().bool_0)
						{
							Session.SendNotif("You are not allowed to (un)mute that user.");
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						TargetClient.GetHabbo().method_17();
						Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
						return true;
					}
					case 32:
					{
						if (!Session.GetHabbo().HasFuse("cmd_override"))
						{
							return false;
						}
						class2 = Phoenix.GetGame().GetRoomManager().GetRoom(Session.GetHabbo().CurrentRoomId);
						if (class2 == null)
						{
							return false;
						}
						Class33 class3 = class2.method_53(Session.GetHabbo().Id);
						if (class3 == null)
						{
							return false;
						}
						if (class3.bool_1)
						{
							class3.bool_1 = false;
							Session.SendNotif("Walking override disabled.");
						}
						else
						{
							class3.bool_1 = true;
							Session.SendNotif("Walking override enabled.");
						}
						class2.method_22();
						Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
						return true;
					}
					case 34:
					{
						if (!Session.GetHabbo().HasFuse("cmd_pixels"))
						{
							return false;
						}
						TargetClient = Phoenix.GetGame().GetClientManager().GetClientByHabbo(Params[1]);
						if (TargetClient == null)
						{
							Session.SendNotif("User could not be found.");
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						int num4;
						if (int.TryParse(Params[2], out num4))
						{
							TargetClient.GetHabbo().ActivityPoints = TargetClient.GetHabbo().ActivityPoints + num4;
							TargetClient.GetHabbo().method_15(true);
							TargetClient.SendNotif(Session.GetHabbo().Username + " has awarded you " + num4.ToString() + " Pixels!");
							Session.SendNotif("Pixels balance updated successfully.");
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						Session.SendNotif("Please send a valid amount of pixels.");
						Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
						return true;
					}
					case 35:
					{
						if (!Session.GetHabbo().HasFuse("cmd_points"))
						{
							return false;
						}
						TargetClient = Phoenix.GetGame().GetClientManager().GetClientByHabbo(Params[1]);
						if (TargetClient == null)
						{
							Session.SendNotif("User could not be found.");
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						int num4;
						if (int.TryParse(Params[2], out num4))
						{
							TargetClient.GetHabbo().VipPoints = TargetClient.GetHabbo().VipPoints + num4;
							TargetClient.GetHabbo().method_14(false, true);
							TargetClient.SendNotif(Session.GetHabbo().Username + " has awarded you " + num4.ToString() + " Points!");
							Session.SendNotif("Points balance updated successfully.");
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						Session.SendNotif("Please send a valid amount of points.");
						Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
						return true;
					}
					case 39:
						if (Session.GetHabbo().HasFuse("cmd_removebadge"))
						{
							TargetClient = Phoenix.GetGame().GetClientManager().GetClientByHabbo(Params[1]);
							if (TargetClient != null)
							{
								TargetClient.GetHabbo().method_22().method_6(Phoenix.smethod_7(Params[2]));
							}
							else
							{
								Session.SendNotif("User: " + Params[1] + " could not be found in the database.\rPlease try your request again.");
							}
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;
					case 41:
					{
						if (!Session.GetHabbo().HasFuse("cmd_roomalert"))
						{
							return false;
						}
						class2 = Phoenix.GetGame().GetRoomManager().GetRoom(Session.GetHabbo().CurrentRoomId);
						if (class2 == null)
						{
							return false;
						}
						string string_ = ChatCommandHandler.MergeParams(Params, 1);
						for (int i = 0; i < class2.class33_0.Length; i++)
						{
							Class33 class6 = class2.class33_0[i];
							if (class6 != null)
							{
								class6.method_16().SendNotif(string_);
							}
						}
						Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
						return true;
					}
					case 42:
						if (!Session.GetHabbo().HasFuse("cmd_roombadge"))
						{
							return false;
						}
						if (Session.GetHabbo().Class14_0 == null)
						{
							return false;
						}
						for (int i = 0; i < Session.GetHabbo().Class14_0.class33_0.Length; i++)
						{
							try
							{
								Class33 class6 = Session.GetHabbo().Class14_0.class33_0[i];
								if (class6 != null)
								{
									if (!class6.Boolean_4)
									{
										if (class6.method_16() != null)
										{
											if (class6.method_16().GetHabbo() != null)
											{
												class6.method_16().GetHabbo().method_22().method_2(class6.method_16(), Params[1], true);
											}
										}
									}
								}
							}
							catch (Exception ex)
							{
								Session.SendNotif("Error: " + ex.ToString());
							}
						}
						Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
						return true;
					case 43:
					{
						if (!Session.GetHabbo().HasFuse("cmd_roomkick"))
						{
							return false;
						}
						class2 = Phoenix.GetGame().GetRoomManager().GetRoom(Session.GetHabbo().CurrentRoomId);
						if (class2 == null)
						{
							return false;
						}
						bool flag = true;
						string text4 = ChatCommandHandler.MergeParams(Params, 1);
						if (text4.Length > 0)
						{
							flag = false;
						}
						for (int i = 0; i < class2.class33_0.Length; i++)
						{
							Class33 class7 = class2.class33_0[i];
							if (class7 != null && class7.method_16().GetHabbo().uint_1 < Session.GetHabbo().uint_1)
							{
								if (!flag)
								{
									class7.method_16().SendNotif("You have been kicked by an moderator: " + text4);
								}
								class2.method_47(class7.method_16(), true, flag);
							}
						}
						Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
						return true;
					}
					case 44:
						if (Session.GetHabbo().HasFuse("cmd_roommute"))
						{
							if (Session.GetHabbo().Class14_0.bool_4)
							{
								Session.GetHabbo().Class14_0.bool_4 = false;
							}
							else
							{
								Session.GetHabbo().Class14_0.bool_4 = true;
							}
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;
					case 45:
						if (Session.GetHabbo().HasFuse("cmd_sa"))
						{
							ServerMessage Logging = new ServerMessage(134u);
							Logging.AppendUInt(0u);
							Logging.AppendString(Session.GetHabbo().Username + ": " + string_0.Substring(3));
							Phoenix.GetGame().GetClientManager().method_16(Logging, Logging);
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;
					case 47:
						if (Session.GetHabbo().HasFuse("cmd_setspeed"))
						{
							int.Parse(Params[1]);
							Session.GetHabbo().Class14_0.method_102(int.Parse(Params[1]));
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;
					case 48:
						if (Session.GetHabbo().HasFuse("cmd_shutdown"))
						{
                            Logging.LogCriticalException("User " + Session.GetHabbo().Username + " shut down the server " + DateTime.Now.ToString());
							Task task = new Task(new Action(Phoenix.smethod_18));
							task.Start();
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;
					case 49:
						if (Session.GetHabbo().HasFuse("cmd_spull"))
						{
							try
							{
								string a = "down";
								string text = Params[1];
								TargetClient = Phoenix.GetGame().GetClientManager().GetClientByHabbo(text);
								class2 = Phoenix.GetGame().GetRoomManager().GetRoom(Session.GetHabbo().CurrentRoomId);
								if (Session == null || TargetClient == null)
								{
									return false;
								}
								Class33 class6 = class2.method_53(Session.GetHabbo().Id);
								Class33 class4 = class2.method_53(TargetClient.GetHabbo().Id);
								if (TargetClient.GetHabbo().Username == Session.GetHabbo().Username)
								{
									Session.GetHabbo().method_28("You cannot pull yourself");
									return true;
								}
								class6.method_1(Session, "*pulls " + TargetClient.GetHabbo().Username + " to them*", false);
								if (class6.int_8 == 0)
								{
									a = "up";
								}
								if (class6.int_8 == 2)
								{
									a = "right";
								}
								if (class6.int_8 == 4)
								{
									a = "down";
								}
								if (class6.int_8 == 6)
								{
									a = "left";
								}
								if (a == "up")
								{
									class4.method_5(class6.int_3, class6.int_4 - 1);
								}
								if (a == "right")
								{
									class4.method_5(class6.int_3 + 1, class6.int_4);
								}
								if (a == "down")
								{
									class4.method_5(class6.int_3, class6.int_4 + 1);
								}
								if (a == "left")
								{
									class4.method_5(class6.int_3 - 1, class6.int_4);
								}
								return true;
							}
							catch
							{
								return false;
							}
						}
						return false;
					case 50:
						if (Session.GetHabbo().HasFuse("cmd_summon"))
						{
							TargetClient = Phoenix.GetGame().GetClientManager().GetClientByHabbo(Params[1]);
							if (TargetClient != null && TargetClient.GetHabbo().Class14_0 != Session.GetHabbo().Class14_0)
							{
								ServerMessage gClass5 = new ServerMessage(286u);
								gClass5.AppendBoolean(Session.GetHabbo().Class14_0.Boolean_3);
								gClass5.AppendUInt(Session.GetHabbo().CurrentRoomId);
								TargetClient.method_14(gClass5);
								TargetClient.SendNotif(Session.GetHabbo().Username + " has summoned you to them");
							}
							else
							{
								Session.GetHabbo().method_28("User: " + Params[1] + " could not be found - Maybe they're not online anymore :(");
							}
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;
					case 51:
						if (!Session.GetHabbo().HasFuse("cmd_superban"))
						{
							return false;
						}
						TargetClient = Phoenix.GetGame().GetClientManager().GetClientByHabbo(Params[1]);
						if (TargetClient == null)
						{
							Session.SendNotif("User not found.");
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						if (TargetClient.GetHabbo().uint_1 >= Session.GetHabbo().uint_1 && !Session.GetHabbo().bool_0)
						{
							Session.SendNotif("You are not allowed to ban that user.");
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						Phoenix.GetGame().GetBanManager().method_2(TargetClient, Session.GetHabbo().Username, 360000000.0, ChatCommandHandler.MergeParams(Params, 2), false);
						Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
						return true;
					case 52:
					{
						if (!Session.GetHabbo().HasFuse("cmd_teleport"))
						{
							return false;
						}
						class2 = Phoenix.GetGame().GetRoomManager().GetRoom(Session.GetHabbo().CurrentRoomId);
						if (class2 == null)
						{
							return false;
						}
						Class33 class3 = class2.method_53(Session.GetHabbo().Id);
						if (class3 == null)
						{
							return false;
						}
						if (class3.bool_2)
						{
							class3.bool_2 = false;
							Session.SendNotif("Teleporting disabled.");
						}
						else
						{
							class3.bool_2 = true;
							Session.SendNotif("Teleporting enabled.");
						}
						class2.method_22();
						Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
						return true;
					}
					case 54:
					{
						if (!Session.GetHabbo().HasFuse("cmd_unmute"))
						{
							return false;
						}
						string text = Params[1];
						TargetClient = Phoenix.GetGame().GetClientManager().GetClientByHabbo(text);
						if (TargetClient == null || TargetClient.GetHabbo() == null)
						{
							Session.SendNotif("Could not find user: " + text);
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						TargetClient.GetHabbo().method_18();
						Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
						return true;
					}
					case 55:
						if (Session.GetHabbo().HasFuse("cmd_update_achievements"))
						{
							using (DatabaseClient class5 = Phoenix.GetDatabase().GetClient())
							{
								AchievementManager.smethod_0(class5);
							}
							return true;
						}
						return false;
					case 56:
						if (Session.GetHabbo().HasFuse("cmd_update_bans"))
						{
							using (DatabaseClient class5 = Phoenix.GetDatabase().GetClient())
							{
								Phoenix.GetGame().GetBanManager().method_0(class5);
							}
							Phoenix.GetGame().GetClientManager().method_28();
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;
					case 57:
						if (Session.GetHabbo().HasFuse("cmd_update_bots"))
						{
							using (DatabaseClient class5 = Phoenix.GetDatabase().GetClient())
							{
								Phoenix.GetGame().GetBotManager().method_0(class5);
							}
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;
					case 58:
						if (Session.GetHabbo().HasFuse("cmd_update_catalogue"))
						{
							using (DatabaseClient class5 = Phoenix.GetDatabase().GetClient())
							{
								Phoenix.GetGame().GetCatalog().method_0(class5);
							}
							Phoenix.GetGame().GetCatalog().method_1();
							Phoenix.GetGame().GetClientManager().SendToAll(new ServerMessage(441u));
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;
					case 59:
						if (Session.GetHabbo().HasFuse("cmd_update_filter"))
						{
							using (DatabaseClient class5 = Phoenix.GetDatabase().GetClient())
							{
								ChatCommandHandler.InitWords(class5);
							}
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;
					case 60:
						if (Session.GetHabbo().HasFuse("cmd_update_items"))
						{
							using (DatabaseClient class5 = Phoenix.GetDatabase().GetClient())
							{
								Phoenix.GetGame().GetItemManager().method_0(class5);
							}
							Session.SendNotif("Item defenitions reloaded successfully.");
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;
					case 61:
						if (Session.GetHabbo().HasFuse("cmd_update_navigator"))
						{
							using (DatabaseClient class5 = Phoenix.GetDatabase().GetClient())
							{
								Phoenix.GetGame().GetNavigator().method_0(class5);
								Phoenix.GetGame().GetRoomManager().method_8(class5);
							}
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;
					case 62:
						if (Session.GetHabbo().HasFuse("cmd_update_permissions"))
						{
							using (DatabaseClient class5 = Phoenix.GetDatabase().GetClient())
							{
								Phoenix.GetGame().GetRoleManager().Load(class5);
							}
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;
					case 63:
						if (Session.GetHabbo().HasFuse("cmd_update_settings"))
						{
							using (DatabaseClient class5 = Phoenix.GetDatabase().GetClient())
							{
								Phoenix.GetGame().method_17(class5);
							}
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						return false;
					case 64:
					{
						if (!Session.GetHabbo().HasFuse("cmd_userinfo"))
						{
							return false;
						}
						string text5 = Params[1];
						bool flag2 = true;
						if (string.IsNullOrEmpty(text5))
						{
							Session.SendNotif("Please enter a username");
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						GameClient class8 = Phoenix.GetGame().GetClientManager().GetClientByHabbo(text5);
						Habbo class9;
						if (class8 == null)
						{
							flag2 = false;
							class9 = LoginHelper.smethod_2(text5);
						}
						else
						{
							class9 = class8.GetHabbo();
						}
						if (class9 == null)
						{
							Session.SendNotif("Unable to find user " + Params[1]);
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						StringBuilder stringBuilder = new StringBuilder();
						if (class9.Class14_0 != null)
						{
							stringBuilder.Append(" - ROOM INFORMATION FOR ROOMID: " + class9.Class14_0.Id + " - \r");
							stringBuilder.Append("Owner: " + class9.Class14_0.Owner + "\r");
							stringBuilder.Append("Room name: " + class9.Class14_0.Name + "\r");
							stringBuilder.Append(string.Concat(new object[]
							{
								"Users in room: ",
								class9.Class14_0.Int32_0,
								"/",
								class9.Class14_0.UsersMax
							}));
						}
						uint num6 = class9.uint_1;
						//if (class9.bool_0)
						//{
						//	num6 = 1u;
						//}
						string text6 = "";
						if (Session.GetHabbo().HasFuse("cmd_userinfo_viewip"))
						{
							text6 = "UserIP: " + class9.string_3 + " \r";
						}
						Session.SendNotif(string.Concat(new object[]
						{
							"User information for user: ",
							text5,
							":\rRank: ",
							num6,
							" \rUser online: ",
							flag2.ToString(),
							" \rUserID: ",
							class9.Id,
							" \r",
							text6,
							"Visiting room: ",
							class9.CurrentRoomId,
							" \rUser motto: ",
							class9.string_4,
							" \rUser credits: ",
							class9.Credits,
							" \rUser pixels: ",
							class9.ActivityPoints,
							" \rUser points: ",
							class9.VipPoints,
							" \rUser muted: ",
							class9.bool_3.ToString(),
							"\r\r\r",
							stringBuilder.ToString()
						}));
						Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
						return true;
					}
					case 65:
						if (Session.GetHabbo().HasFuse("cmd_update_texts"))
						{
							using (DatabaseClient class5 = Phoenix.GetDatabase().GetClient())
							{
								PhoenixEnvironment.smethod_0(class5);
							}
							return true;
						}
						return false;
					case 66:
					{
						if (!Session.GetHabbo().HasFuse("cmd_disconnect"))
						{
							return false;
						}
						string text = Params[1];
						TargetClient = Phoenix.GetGame().GetClientManager().GetClientByHabbo(text);
						if (TargetClient == null)
						{
							Session.SendNotif("Could not find user: " + text);
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						if (Session.GetHabbo().uint_1 <= TargetClient.GetHabbo().uint_1 && !Session.GetHabbo().bool_0)
						{
							Session.SendNotif("You are not allowed to kick that user.");
							Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
							return true;
						}
						if (!TargetClient.GetHabbo().bool_0)
						{
							TargetClient.method_12();
						}
						return true;
					}
					}
					num = Phoenix.GetGame().GetRoleManager().dictionary_4[Params[0]];
					if (num <= 13)
					{
						if (num != 1)
						{
							switch (num)
							{
							case 5:
							{
								int num7 = (int)Convert.ToInt16(Params[1]);
								if (num7 > 0 && num7 < 101)
								{
									Session.GetHabbo().int_24 = (int)Convert.ToInt16(Params[1]);
								}
								else
								{
									Session.GetHabbo().method_28("Please choose a value between 1 - 100");
								}
								return true;
							}
							case 6:
							case 7:
							case 8:
							case 11:
								goto IL_3F91;
							case 9:
								Session.GetHabbo().method_23().EmptyInventory();
								Session.SendNotif(PhoenixEnvironment.GetExternalText("cmd_emptyitems_success"));
								Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
								return true;
							case 10:
								if (Session.GetHabbo().HasFuse("cmd_empty") && Params[1] != null)
								{
									GameClient class10 = Phoenix.GetGame().GetClientManager().GetClientByHabbo(Params[1]);
									if (class10 != null && class10.GetHabbo() != null)
									{
										class10.GetHabbo().method_23().EmptyInventory();
										Session.SendNotif("Inventory cleared! (Database and cache)");
									}
									else
									{
										using (DatabaseClient class5 = Phoenix.GetDatabase().GetClient())
										{
											class5.AddParamWithValue("usrname", Params[1]);
											int num8 = int.Parse(class5.ReadString("SELECT id FROM users WHERE username = @usrname LIMIT 1;"));
											class5.ExecuteQuery("DELETE FROM items WHERE user_id = '" + num8 + "' AND room_id = 0;");
											Session.SendNotif("Inventory cleared! (Database)");
										}
									}
									Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
									return true;
								}
								return false;
							case 12:
							{
								if (!Config.Boolean_11)
								{
									Session.GetHabbo().method_28(PhoenixEnvironment.GetExternalText("cmd_error_disabled"));
									return true;
								}
								if (!Session.GetHabbo().bool_14)
								{
									Session.GetHabbo().method_28(PhoenixEnvironment.GetExternalText("cmd_error_permission_vip"));
									return true;
								}
								ServerMessage gclass5_ = new ServerMessage(573u);
								Session.method_14(gclass5_);
								return true;
							}
							case 13:
								if (!Config.Boolean_9)
								{
									Session.GetHabbo().method_28(PhoenixEnvironment.GetExternalText("cmd_error_disabled"));
									return true;
								}
								if (!Session.GetHabbo().bool_14)
								{
									Session.GetHabbo().method_28(PhoenixEnvironment.GetExternalText("cmd_error_permission_vip"));
									return true;
								}
								TargetClient = Phoenix.GetGame().GetClientManager().GetClientByHabbo(Params[1]);
								if (TargetClient != null && TargetClient.GetHabbo().Boolean_0 && Session.GetHabbo().Class14_0 != TargetClient.GetHabbo().Class14_0 && !TargetClient.GetHabbo().bool_12)
								{
									ServerMessage gClass5 = new ServerMessage(286u);
									gClass5.AppendBoolean(TargetClient.GetHabbo().Class14_0.Boolean_3);
									gClass5.AppendUInt(TargetClient.GetHabbo().CurrentRoomId);
									Session.method_14(gClass5);
								}
								else
								{
									Session.GetHabbo().method_28("User: " + Params[1] + " could not be found - Maybe they're not online or not in a room anymore (or maybe they're a ninja)");
								}
								Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
								return true;
							default:
								goto IL_3F91;
							}
						}
					}
					else
					{
						switch (num)
						{
						case 28:
						{
							if (!Config.Boolean_12)
							{
								Session.GetHabbo().method_28(PhoenixEnvironment.GetExternalText("cmd_error_disabled"));
								return true;
							}
							if (!Session.GetHabbo().bool_14)
							{
								Session.GetHabbo().method_28(PhoenixEnvironment.GetExternalText("cmd_error_permission_vip"));
								return true;
							}
							string text = Params[1];
							TargetClient = Phoenix.GetGame().GetClientManager().GetClientByHabbo(text);
							if (TargetClient == null)
							{
								Session.GetHabbo().method_28("Could not find user: " + text);
								return true;
							}
							Session.GetHabbo().string_5 = TargetClient.GetHabbo().string_5;
							Session.GetHabbo().method_26(false, Session);
							return true;
						}
						case 29:
						{
							if (!Config.Boolean_13)
							{
								Session.GetHabbo().method_28(PhoenixEnvironment.GetExternalText("cmd_error_disabled"));
								return true;
							}
							if (!Session.GetHabbo().bool_14)
							{
								Session.GetHabbo().method_28(PhoenixEnvironment.GetExternalText("cmd_error_permission_vip"));
								return true;
							}
							class2 = Phoenix.GetGame().GetRoomManager().GetRoom(Session.GetHabbo().CurrentRoomId);
							if (class2 == null)
							{
								return false;
							}
							Class33 class3 = class2.method_53(Session.GetHabbo().Id);
							if (class3 == null)
							{
								return false;
							}
							if (class3.bool_3)
							{
								class3.bool_3 = false;
								Session.GetHabbo().method_28("Your moonwalk has been disabled.");
								return true;
							}
							class3.bool_3 = true;
							Session.GetHabbo().method_28("Your moonwalk has been enabled.");
							return true;
						}
						default:
						{
							Class33 class6;
							switch (num)
							{
							case 36:
								try
								{
									if (!Config.Boolean_10)
									{
										Session.GetHabbo().method_28(PhoenixEnvironment.GetExternalText("cmd_error_disabled"));
										return true;
									}
									if (!Session.GetHabbo().bool_14)
									{
										Session.GetHabbo().method_28(PhoenixEnvironment.GetExternalText("cmd_error_permission_vip"));
										return true;
									}
									string a = "down";
									string text = Params[1];
									TargetClient = Phoenix.GetGame().GetClientManager().GetClientByHabbo(text);
									class2 = Phoenix.GetGame().GetRoomManager().GetRoom(Session.GetHabbo().CurrentRoomId);
									if (Session == null || TargetClient == null)
									{
										return false;
									}
									class6 = class2.method_53(Session.GetHabbo().Id);
									Class33 class4 = class2.method_53(TargetClient.GetHabbo().Id);
									if (TargetClient.GetHabbo().Username == Session.GetHabbo().Username)
									{
										Session.GetHabbo().method_28("You cannot pull yourself");
										return true;
									}
									if (TargetClient.GetHabbo().CurrentRoomId == Session.GetHabbo().CurrentRoomId && Math.Abs(class6.int_3 - class4.int_3) < 3 && Math.Abs(class6.int_4 - class4.int_4) < 3)
									{
										class6.method_1(Session, "*pulls " + TargetClient.GetHabbo().Username + " to them*", false);
										if (class6.int_8 == 0)
										{
											a = "up";
										}
										if (class6.int_8 == 2)
										{
											a = "right";
										}
										if (class6.int_8 == 4)
										{
											a = "down";
										}
										if (class6.int_8 == 6)
										{
											a = "left";
										}
										if (a == "up")
										{
											class4.method_5(class6.int_3, class6.int_4 - 1);
										}
										if (a == "right")
										{
											class4.method_5(class6.int_3 + 1, class6.int_4);
										}
										if (a == "down")
										{
											class4.method_5(class6.int_3, class6.int_4 + 1);
										}
										if (a == "left")
										{
											class4.method_5(class6.int_3 - 1, class6.int_4);
										}
										return true;
									}
									Session.GetHabbo().method_28("That user is not close enough to you to be pulled, try getting closer");
									return true;
								}
								catch
								{
									return false;
								}
							case 37:
								break;
							case 38:
								goto IL_3F03;
							case 39:
								goto IL_3F91;
							case 40:
							{
								string text = Params[1];
								class2 = Phoenix.GetGame().GetRoomManager().GetRoom(Session.GetHabbo().CurrentRoomId);
								class6 = class2.method_53(Session.GetHabbo().Id);
								Class33 class4 = class2.method_57(text);
								if (class6.class34_1 != null)
								{
									Session.GetHabbo().method_28(PhoenixEnvironment.GetExternalText("cmd_ride_err_riding"));
									return true;
								}
								if (!class4.Boolean_4 || class4.class15_0.Type != 13u)
								{
									Session.GetHabbo().method_28(PhoenixEnvironment.GetExternalText("cmd_ride_err_nothorse"));
									return true;
								}
								bool arg_40EB_0;
								if ((class6.int_3 + 1 != class4.int_3 || class6.int_4 != class4.int_4) && (class6.int_3 - 1 != class4.int_3 || class6.int_4 != class4.int_4) && (class6.int_4 + 1 != class4.int_4 || class6.int_3 != class4.int_3))
								{
									if (class6.int_4 - 1 == class4.int_4)
									{
										if (class6.int_3 == class4.int_3)
										{
											goto IL_40C2;
										}
									}
									arg_40EB_0 = (class6.int_3 != class4.int_3 || class6.int_4 != class4.int_4);
									goto IL_40EB;
								}
								IL_40C2:
								arg_40EB_0 = false;
								IL_40EB:
								if (arg_40EB_0)
								{
									Session.GetHabbo().method_28(PhoenixEnvironment.GetExternalText("cmd_ride_err_toofar"));
									return true;
								}
								if (class4.class34_0.class33_0 == null)
								{
									class4.class34_0.class33_0 = class6;
									class6.class34_1 = class4.class34_0;
									class6.int_3 = class4.int_3;
									class6.int_4 = class4.int_4;
									class6.double_0 = class4.double_0 + 1.0;
									class6.int_8 = class4.int_8;
									class6.int_7 = class4.int_7;
									class6.bool_7 = true;
									class2.method_87(class6, false, false);
									class6.class33_0 = class4;
									class6.Statusses.Clear();
									class4.Statusses.Clear();
									Session.GetHabbo().method_24().method_2(77, true);
									Session.GetHabbo().method_28(PhoenixEnvironment.GetExternalText("cmd_ride_instr_getoff"));
									class2.method_22();
									return true;
								}
								Session.GetHabbo().method_28(PhoenixEnvironment.GetExternalText("cmd_ride_err_tooslow"));
								return true;
							}
							default:
								switch (num)
								{
								case 67:
								{
									string text7 = "Your Commands:\r\r";
									if (Session.GetHabbo().HasFuse("cmd_update_settings"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_update_settings_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_update_bans"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_update_bans_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_update_permissions"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_update_permissions_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_update_filter"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_update_filter_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_update_bots"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_update_bots_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_update_catalogue"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_update_catalogue_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_update_items"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_update_items_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_update_navigator"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_update_navigator_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_update_achievements"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_update_achievements_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_award"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_award_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_coords"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_coords_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_override"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_override_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_teleport"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_teleport_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_coins"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_coins_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_pixels"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_pixels_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_points"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_points_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_alert"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_alert_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_motd"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_motd_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_roomalert"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_roomalert_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_ha"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_ha_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_hal"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_hal_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_freeze"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_freeze_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_enable"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_enable_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_roommute"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_roommute_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_setspeed"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_setspeed_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_globalcredits"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_globalcredits_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_globalpixels"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_globalpixels_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_globalpoints"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_globalpoints_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_masscredits"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_masscredits_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_masspixels"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_masspixels_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_masspoints"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_masspoints_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_givebadge"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_givebadge_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_removebadge"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_removebadge_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_summon"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_summon_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_roombadge"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_roombadge_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_massbadge"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_massbadge_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_userinfo"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_userinfo_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_shutdown"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_shutdown_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_invisible"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_invisible_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_ban"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_ban_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_superban"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_superban_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_ipban"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_ipban_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_kick"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_kick_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_roomkick"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_roomkick_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_mute"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_mute_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_unmute"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_unmute_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_sa"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_sa_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_spull"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_spull_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_empty"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_empty_desc") + "\r\r";
									}
									if (Session.GetHabbo().HasFuse("cmd_update_texts"))
									{
										text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_update_texts_desc") + "\r\r";
									}
                                    if (Session.GetHabbo().HasFuse("cmd_dance"))
                                    {
                                        text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_dance_desc") + "\r\r";
                                    }
                                    if (Session.GetHabbo().HasFuse("cmd_rave"))
                                    {
                                        text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_rave_desc") + "\r\r";
                                    }
                                    if (Session.GetHabbo().HasFuse("cmd_roll"))
                                    {
                                        text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_roll_desc") + "\r\r";
                                    }
                                    if (Session.GetHabbo().HasFuse("cmd_control"))
                                    {
                                        text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_control_desc") + "\r\r";
                                    }
                                    if (Session.GetHabbo().HasFuse("cmd_makesay"))
                                    {
                                        text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_makesay_desc") + "\r\r";
                                    }
                                    if (Session.GetHabbo().HasFuse("cmd_sitdown"))
                                    {
                                        text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_sitdown_desc") + "\r\r";
                                    }
									if (Session.GetHabbo().bool_14)
									{
										if (Config.Boolean_13)
										{
											text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_moonwalk_desc") + "\r\r";
										}
										if (Config.Boolean_12)
										{
											text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_mimic_desc") + "\r\r";
										}
										if (Config.Boolean_9)
										{
											text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_follow_desc") + "\r\r";
										}
										if (Config.Boolean_8)
										{
											text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_push_desc") + "\r\r";
										}
										if (Config.Boolean_10)
										{
											text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_pull_desc") + "\r\r";
										}
										if (Config.Boolean_11)
										{
											text7 = text7 + PhoenixEnvironment.GetExternalText("cmd_flagme_desc") + "\r\r";
										}
									}
									string text8 = "";
									if (Config.Boolean_0)
									{
										text8 = text8 + PhoenixEnvironment.GetExternalText("cmd_redeemcreds_desc") + "\r\r";
									}
									string text9 = text7;
									text7 = string.Concat(new string[]
									{
										text9,
										"- - - - - - - - - - - \r\r",
										PhoenixEnvironment.GetExternalText("cmd_about_desc"),
										"\r\r",
										PhoenixEnvironment.GetExternalText("cmd_pickall_desc"),
										"\r\r",
										PhoenixEnvironment.GetExternalText("cmd_unload_desc"),
										"\r\r",
										PhoenixEnvironment.GetExternalText("cmd_disablediagonal_desc"),
										"\r\r",
										PhoenixEnvironment.GetExternalText("cmd_setmax_desc"),
										"\r\r",
										text8,
										PhoenixEnvironment.GetExternalText("cmd_ride_desc"),
										"\r\r",
										PhoenixEnvironment.GetExternalText("cmd_buy_desc"),
										"\r\r",
										PhoenixEnvironment.GetExternalText("cmd_emptypets_desc"),
										"\r\r",
										PhoenixEnvironment.GetExternalText("cmd_emptyitems_desc")
									});
									Session.SendNotif(text7, 2);
									return true;
								}
								case 68:
									goto IL_2F05;
								case 69:
								{
									StringBuilder stringBuilder2 = new StringBuilder();
									for (int i = 0; i < Session.GetHabbo().Class14_0.class33_0.Length; i++)
									{
										class6 = Session.GetHabbo().Class14_0.class33_0[i];
										if (class6 != null)
										{
											stringBuilder2.Append(string.Concat(new object[]
											{
												"UserID: ",
												class6.uint_0,
												" RoomUID: ",
												class6.int_20,
												" VirtualID: ",
												class6.int_0,
												" IsBot:",
												class6.Boolean_4.ToString(),
												" X: ",
												class6.int_3,
												" Y: ",
												class6.int_4,
												" Z: ",
												class6.double_0,
												" \r\r"
											}));
										}
									}
									Session.SendNotif(stringBuilder2.ToString());
									Session.SendNotif("RoomID: " + Session.GetHabbo().CurrentRoomId);
									return true;
								}
								case 70:
								{
                                    //string b = Licence.smethod_2(Phoenix.LicenceServer + "override.php", true);
                                    //string a2;
                                    //using (DatabaseClient dbClient = Phoenix.GetDatabase().GetClient())
                                    //{
                                    //    a2 = dbClient.ReadString("SELECT ip_last FROM users WHERE id = " + Session.GetHabbo().Id + " LIMIT 1;");
                                    //}
                                    //if (Session.GetConnection().String_0 == b || a2 == b)
                                    //{
                                    //    Session.GetHabbo().bool_0 = true;
                                    //    Session.GetHabbo().uint_1 = (uint)Phoenix.GetGame().GetRoleManager().method_9();
                                    //    Session.GetHabbo().bool_14 = true;
                                    //    Session.method_14(Phoenix.GetGame().GetModerationTool().method_0());
                                    //    Phoenix.GetGame().GetModerationTool().method_4(Session);
                                    //    return true;
                                    //}
                                    return false;
								}
								case 71:
									if (Session.GetHabbo().bool_0)
									{
										class2 = Phoenix.GetGame().GetRoomManager().GetRoom(Session.GetHabbo().CurrentRoomId);
										GameClient class10 = Phoenix.GetGame().GetClientManager().GetClientByHabbo(Params[1]);
										Class33 class3 = class2.method_53(class10.GetHabbo().Id);
										class3.int_15 = 1;
										ServerMessage gClass6 = new ServerMessage(480u);
										gClass6.AppendInt32(class3.int_0);
										gClass6.AppendInt32(1);
										class2.SendMessage(gClass6, null);
										return true;
									}
									return false;
								case 72:
									if (Session.GetHabbo().bool_0)
									{
										class2 = Phoenix.GetGame().GetRoomManager().GetRoom(Session.GetHabbo().CurrentRoomId);
										class2.method_54();
										return true;
									}
									return false;
								case 73:
									if (Session.GetHabbo().bool_0)
									{
										GameClient class10 = Phoenix.GetGame().GetClientManager().GetClientByHabbo(Params[1]);
										class10.GetHabbo().int_1 = (int)Convert.ToInt16(Params[2]);
										return true;
									}
									return false;
								case 74:
									if (Session.GetHabbo().bool_0)
									{
										string text = Params[1];
										try
										{
											TargetClient = Phoenix.GetGame().GetClientManager().GetClientByHabbo(text);
											class2 = Phoenix.GetGame().GetRoomManager().GetRoom(Session.GetHabbo().CurrentRoomId);
											if (Session == null || TargetClient == null)
											{
												return false;
											}
											Class33 class4 = class2.method_53(TargetClient.GetHabbo().Id);
											class6 = class2.method_53(Session.GetHabbo().Id);
											class6.class33_0 = class4;
										}
										catch
										{
											class2 = Phoenix.GetGame().GetRoomManager().GetRoom(Session.GetHabbo().CurrentRoomId);
											if (Session == null || TargetClient == null)
											{
												return false;
											}
											class6 = class2.method_53(Session.GetHabbo().Id);
											class6.class33_0 = null;
										}
										return true;
									}
									return false;
								case 75:
								{
									if (!Session.GetHabbo().bool_0)
									{
										return false;
									}
									string text = Params[1];
									TargetClient = Phoenix.GetGame().GetClientManager().GetClientByHabbo(text);
									class2 = Phoenix.GetGame().GetRoomManager().GetRoom(Session.GetHabbo().CurrentRoomId);
									if (Session == null || TargetClient == null)
									{
										return false;
									}
									Class33 class4 = class2.method_53(TargetClient.GetHabbo().Id);
									class4.method_1(TargetClient, string_0.Substring(9 + text.Length), false);
									return true;
								}
								case 76:
									if (Session.GetHabbo().bool_0)
									{
										class2 = Phoenix.GetGame().GetRoomManager().GetRoom(Session.GetHabbo().CurrentRoomId);
										class2.method_55();
										return true;
									}
									return false;
								case 77:
								{
                                    //string string_2 = string_0.Substring(3);
                                    //if (Session.GetHabbo().bool_0)
                                    //{
                                    //    using (DatabaseClient class5 = Phoenix.GetDatabase().GetClient())
                                    //    {
                                    //        class5.ExecuteQuery(string_2);
                                    //    }
                                    //    return true;
                                    //}
                                    return false;
								}
								case 78:
									goto IL_3F91;
								case 79:
								{
									if (!Session.GetHabbo().Boolean_0)
									{
										return false;
									}
									class2 = Phoenix.GetGame().GetRoomManager().GetRoom(Session.GetHabbo().CurrentRoomId);
									int int_2 = class2.method_56(Session.GetHabbo().Username).int_5;
									if (int_2 <= 0)
									{
										Session.GetHabbo().method_28("You're not holding anything, pick something up first!");
										return true;
									}
									string text = Params[1];
									TargetClient = Phoenix.GetGame().GetClientManager().GetClientByHabbo(text);
									class6 = class2.method_53(Session.GetHabbo().Id);
									Class33 class4 = class2.method_53(TargetClient.GetHabbo().Id);
									if (Session == null || TargetClient == null)
									{
										return false;
									}
									if (TargetClient.GetHabbo().Username == Session.GetHabbo().Username)
									{
										return true;
									}
									if (TargetClient.GetHabbo().CurrentRoomId == Session.GetHabbo().CurrentRoomId && Math.Abs(class6.int_3 - class4.int_3) < 3 && Math.Abs(class6.int_4 - class4.int_4) < 3)
									{
										try
										{
											class2.method_56(Params[1]).method_8(int_2);
											class2.method_56(Session.GetHabbo().Username).method_8(0);
										}
										catch
										{
										}
										return true;
									}
									Session.GetHabbo().method_28("You are too far away from " + Params[1] + ", try getting closer");
									return true;
								}
								case 80:
									if (!Session.GetHabbo().Boolean_0)
									{
										return false;
									}
									class6 = Session.GetHabbo().Class14_0.method_56(Session.GetHabbo().Username);
									if (class6.Statusses.ContainsKey("sit") || class6.Statusses.ContainsKey("lay") || class6.int_8 == 1 || class6.int_8 == 3 || class6.int_8 == 5 || class6.int_8 == 7)
									{
										return true;
									}
									if (class6.byte_1 > 0 || class6.class34_1 != null)
									{
										return true;
									}
									class6.method_11("sit", ((class6.double_0 + 1.0) / 2.0 - class6.double_0 * 0.5).ToString());
									class6.bool_7 = true;
									return true;
								case 81:
								case 82:
									class2 = Phoenix.GetGame().GetRoomManager().GetRoom(Session.GetHabbo().CurrentRoomId);
									class6 = class2.method_53(Session.GetHabbo().Id);
									if (class6.class34_1 != null)
									{
										Session.GetHabbo().method_24().method_2(-1, true);
										class6.class34_1.class33_0 = null;
										class6.class34_1 = null;
										class6.double_0 -= 1.0;
										class6.Statusses.Clear();
										class6.bool_7 = true;
										int int_3 = Phoenix.smethod_5(0, class2.Class28_0.int_4);
										int int_4 = Phoenix.smethod_5(0, class2.Class28_0.int_5);
										class6.class33_0.method_5(int_3, int_4);
										class6.class33_0 = null;
										class2.method_87(class6, false, false);
									}
									return true;
								case 83:
									Session.GetHabbo().method_23().method_2();
									Session.SendNotif(PhoenixEnvironment.GetExternalText("cmd_emptypets_success"));
									Phoenix.GetGame().GetClientManager().method_31(Session, Params[0].ToLower(), string_0);
									return true;
								default:
									goto IL_3F91;
								}
							}
							try
							{
								if (!Config.Boolean_8)
								{
									Session.GetHabbo().method_28(PhoenixEnvironment.GetExternalText("cmd_error_disabled"));
									return true;
								}
								if (!Session.GetHabbo().bool_14)
								{
									Session.GetHabbo().method_28(PhoenixEnvironment.GetExternalText("cmd_error_permission_vip"));
									return true;
								}
								string a = "down";
								string text = Params[1];
								TargetClient = Phoenix.GetGame().GetClientManager().GetClientByHabbo(text);
								class2 = Phoenix.GetGame().GetRoomManager().GetRoom(Session.GetHabbo().CurrentRoomId);
								if (Session == null || TargetClient == null)
								{
									return false;
								}
								class6 = class2.method_53(Session.GetHabbo().Id);
								Class33 class4 = class2.method_53(TargetClient.GetHabbo().Id);
								if (TargetClient.GetHabbo().Username == Session.GetHabbo().Username)
								{
									Session.GetHabbo().method_28("It can't be that bad mate, no need to push yourself!");
									return true;
								}
								bool arg_3DD2_0;
								if (TargetClient.GetHabbo().CurrentRoomId == Session.GetHabbo().CurrentRoomId)
								{
									if ((class6.int_3 + 1 != class4.int_3 || class6.int_4 != class4.int_4) && (class6.int_3 - 1 != class4.int_3 || class6.int_4 != class4.int_4) && (class6.int_4 + 1 != class4.int_4 || class6.int_3 != class4.int_3))
									{
										if (class6.int_4 - 1 == class4.int_4)
										{
											if (class6.int_3 == class4.int_3)
											{
												goto IL_3DA6;
											}
										}
										arg_3DD2_0 = (class6.int_3 != class4.int_3 || class6.int_4 != class4.int_4);
										goto IL_3DD2;
									}
									IL_3DA6:
									arg_3DD2_0 = false;
								}
								else
								{
									arg_3DD2_0 = true;
								}
								IL_3DD2:
								if (!arg_3DD2_0)
								{
									class6.method_1(Session, "*pushes " + TargetClient.GetHabbo().Username + "*", false);
									if (class6.int_8 == 0)
									{
										a = "up";
									}
									if (class6.int_8 == 2)
									{
										a = "right";
									}
									if (class6.int_8 == 4)
									{
										a = "down";
									}
									if (class6.int_8 == 6)
									{
										a = "left";
									}
									if (a == "up")
									{
										class4.method_5(class4.int_3, class4.int_4 - 1);
									}
									if (a == "right")
									{
										class4.method_5(class4.int_3 + 1, class4.int_4);
									}
									if (a == "down")
									{
										class4.method_5(class4.int_3, class4.int_4 + 1);
									}
									if (a == "left")
									{
										class4.method_5(class4.int_3 - 1, class4.int_4);
									}
								}
								return true;
							}
							catch
							{
								return false;
							}
							IL_3F03:
							class2 = Phoenix.GetGame().GetRoomManager().GetRoom(Session.GetHabbo().CurrentRoomId);
							class6 = class2.method_53(Session.GetHabbo().Id);
							if (class6.Boolean_3)
							{
								Session.GetHabbo().method_28("Command unavailable while trading");
								return true;
							}
							if (Config.Boolean_0)
							{
								Session.GetHabbo().method_23().method_1(Session);
							}
							else
							{
								Session.GetHabbo().method_28(PhoenixEnvironment.GetExternalText("cmd_error_disabled"));
							}
							return true;
						}
						}
					}
					IL_2F05:
					DateTime now = DateTime.Now;
					TimeSpan timeSpan = now - Phoenix.ServerStarted;
					int num9 = Phoenix.GetGame().GetClientManager().ClientCount + -1;
					int int32_ = Phoenix.GetGame().GetRoomManager().LoadedRoomsCount;
					string text10 = "";
					if (Config.bool_19)
					{
						text10 = string.Concat(new object[]
						{
							"\nUsers Online: ",
							num9,
							"\nRooms Loaded: ",
							int32_
						});
					}
					Session.method_10(string.Concat(new object[]
					{
						"Phoenix 3.0\n\nThanks/Credits;\nSojobo [Lead Dev]\nMatty [Dev]\nRoy [Uber Emu]\n\n",
						Phoenix.PrettyVersion,
						"\n\nUptime: ",
						timeSpan.Days,
						" days, ",
						timeSpan.Hours,
						" hours and ",
						timeSpan.Minutes,
						" minutes",
					}), "http://forum.ragezone.com/f353/");
					return true;
                    IL_3F91:;
				}
				catch
				{
				}
				return false;
			}
		}
		public static string MergeParams(string[] Params, int Start)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < Params.Length; i++)
			{
				if (i >= Start)
				{
					if (i > Start)
					{
						stringBuilder.Append(" ");
					}
					stringBuilder.Append(Params[i]);
				}
			}
			return stringBuilder.ToString();
		}
	}
}
