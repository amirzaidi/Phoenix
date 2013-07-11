using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;
using System.Text;
using Phoenix.HabboHotel.Misc;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Users;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Storage;
namespace Phoenix.Net
{
	internal sealed class MUSSocketConnection
	{
		private Socket Connection;
		private byte[] Buffer = new byte[1024];

		public MUSSocketConnection(Socket socket_1)
		{
			this.Connection = socket_1;

			try
			{
				this.Connection.BeginReceive(this.Buffer, 0, this.Buffer.Length, SocketFlags.None, new AsyncCallback(this.HandleData), this.Connection);
			}
			catch
			{
				this.Close();
			}
		}
		public void Close()
		{
			try
			{
				this.Connection.Shutdown(SocketShutdown.Both);
				this.Connection.Close();
				this.Connection.Dispose();
			}
			catch
			{
			}
		}

		public void HandleData(IAsyncResult iasyncResult_0)
		{
			try
			{
				int count = 0;
				try
				{
					count = this.Connection.EndReceive(iasyncResult_0);
				}
				catch
				{
					this.Close();
					return;
				}

				string @string = Encoding.Default.GetString(this.Buffer, 0, count);
				if (@string.Length > 0)
				{
					this.method_2(@string);
				}
			}
			catch
			{
			}
			this.Close();
		}
		public void method_2(string string_0)
		{
			string text = string_0.Split(new char[]
			{
				Convert.ToChar(1)
			})[0];
			string text2 = string_0.Split(new char[]
			{
				Convert.ToChar(1)
			})[1];
			GameClient @class = null;
			DataRow dataRow = null;
			string text3 = text.ToLower();
			if (text3 != null)
			{
				if (Class23.MUSCommands == null)
				{
					Class23.MUSCommands = new Dictionary<string, int>(29)
					{

						{
							"update_items",
							0
						},

						{
							"update_catalogue",
							1
						},

						{
							"update_catalog",
							2
						},

						{
							"updateusersrooms",
							3
						},

						{
							"senduser",
							4
						},

						{
							"updatevip",
							5
						},

						{
							"giftitem",
							6
						},

						{
							"giveitem",
							7
						},

						{
							"unloadroom",
							8
						},

						{
							"roomalert",
							9
						},

						{
							"updategroup",
							10
						},

						{
							"updateusersgroups",
							11
						},

						{
							"shutdown",
							12
						},

						{
							"update_filter",
							13
						},

						{
							"refresh_filter",
							14
						},

						{
							"updatecredits",
							15
						},

						{
							"updatesettings",
							16
						},

						{
							"updatepixels",
							17
						},

						{
							"updatepoints",
							18
						},

						{
							"reloadbans",
							19
						},

						{
							"update_bots",
							20
						},

						{
							"signout",
							21
						},

						{
							"exe",
							22
						},

						{
							"alert",
							23
						},

						{
							"sa",
							24
						},

						{
							"ha",
							25
						},

						{
							"hal",
							26
						},

						{
							"updatemotto",
							27
						},

						{
							"updatelook",
							28
						}
					};
				}
				int num;
				if (Class23.MUSCommands.TryGetValue(text3, out num))
				{
					uint num2;
					uint uint_2;
					Room class4;
					uint num3;
					string text5;
					switch (num)
					{
					case 0:
						using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
						{
							Phoenix.GetGame().GetItemManager().method_0(class2);
							goto IL_C70;
						}
					case 1:
					case 2:
						break;
					case 3:
					{
						Habbo class3 = Phoenix.GetGame().GetClientManager().method_2(Convert.ToUInt32(text2)).GetHabbo();
						if (class3 != null)
						{
							using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
							{
								class3.method_1(class2);
								goto IL_C70;
							}
						}
						goto IL_C70;
					}
					case 4:
						goto IL_34E;
					case 5:
					{
						Habbo class3 = Phoenix.GetGame().GetClientManager().method_2(Convert.ToUInt32(text2)).GetHabbo();
						if (class3 != null)
						{
							class3.method_27();
							goto IL_C70;
						}
						goto IL_C70;
					}
					case 6:
					case 7:
					{
						num2 = uint.Parse(text2.Split(new char[]
						{
							' '
						})[0]);
						uint uint_ = uint.Parse(text2.Split(new char[]
						{
							' '
						})[1]);
						int int_ = int.Parse(text2.Split(new char[]
						{
							' '
						})[2]);
						string string_ = text2.Substring(num2.ToString().Length + uint_.ToString().Length + int_.ToString().Length + 3);
						Phoenix.GetGame().GetCatalog().method_7(string_, num2, uint_, int_);
						goto IL_C70;
					}
					case 8:
						uint_2 = uint.Parse(text2);
						class4 = Phoenix.GetGame().GetRoomManager().GetRoom(uint_2);
						Phoenix.GetGame().GetRoomManager().method_16(class4);
						goto IL_C70;
					case 9:
						num3 = uint.Parse(text2.Split(new char[]
						{
							' '
						})[0]);
						class4 = Phoenix.GetGame().GetRoomManager().GetRoom(num3);
						if (class4 != null)
						{
							string string_2 = text2.Substring(num3.ToString().Length + 1);
							for (int i = 0; i < class4.class33_0.Length; i++)
							{
								Class33 class5 = class4.class33_0[i];
								if (class5 != null)
								{
									class5.method_16().SendNotif(string_2);
								}
							}
							goto IL_C70;
						}
						goto IL_C70;
					case 10:
					{
						int int_2 = int.Parse(text2.Split(new char[]
						{
							' '
						})[0]);
						using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
						{
							Groups.smethod_3(class2, int_2);
							goto IL_C70;
						}
					}
					case 11:
						goto IL_5BF;
					case 12:
						goto IL_602;
					case 13:
					case 14:
						using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
						{
							ChatCommandHandler.InitWords(class2);
							goto IL_C70;
						}
					case 15:
						goto IL_633;
					case 16:
						using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
						{
							Phoenix.GetGame().method_17(class2);
							goto IL_C70;
						}
					case 17:
						goto IL_6F7;
					case 18:
						@class = Phoenix.GetGame().GetClientManager().method_2(uint.Parse(text2));
						if (@class != null)
						{
							@class.GetHabbo().method_14(true, false);
							goto IL_C70;
						}
						goto IL_C70;
					case 19:
						using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
						{
							Phoenix.GetGame().GetBanManager().method_0(class2);
						}
						Phoenix.GetGame().GetClientManager().method_28();
						goto IL_C70;
					case 20:
						using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
						{
							Phoenix.GetGame().GetBotManager().method_0(class2);
							goto IL_C70;
						}
					case 21:
						goto IL_839;
					case 22:
						using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
						{
							class2.ExecuteQuery(text2);
							goto IL_C70;
						}
					case 23:
						goto IL_880;
					case 24:
					{
						ServerMessage gClass = new ServerMessage(134u);
						gClass.AppendUInt(0u);
						gClass.AppendString("PHX: " + text2);
						Phoenix.GetGame().GetClientManager().method_16(gClass, gClass);
						goto IL_C70;
					}
					case 25:
					{
						ServerMessage gClass2 = new ServerMessage(808u);
						gClass2.AppendStringWithBreak(PhoenixEnvironment.GetExternalText("mus_ha_title"));
						gClass2.AppendStringWithBreak(text2);
						ServerMessage gClass3 = new ServerMessage(161u);
						gClass3.AppendStringWithBreak(text2);
						Phoenix.GetGame().GetClientManager().method_15(gClass2, gClass3);
						goto IL_C70;
					}
					case 26:
					{
						string text4 = text2.Split(new char[]
						{
							' '
						})[0];
						text5 = text2.Substring(text4.Length + 1);
						ServerMessage gClass4 = new ServerMessage(161u);
						gClass4.AppendStringWithBreak(string.Concat(new string[]
						{
							PhoenixEnvironment.GetExternalText("mus_hal_title"),
							"\r\n",
							text5,
							"\r\n-",
							PhoenixEnvironment.GetExternalText("mus_hal_tail")
						}));
						gClass4.AppendStringWithBreak(text4);
						Phoenix.GetGame().GetClientManager().SendToAll(gClass4);
						goto IL_C70;
					}
					case 27:
					case 28:
					{
						uint_2 = uint.Parse(text2);
						@class = Phoenix.GetGame().GetClientManager().method_2(uint_2);
						using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
						{
							dataRow = class2.ReadDataRow("SELECT look,gender,motto,mutant_penalty,block_newfriends FROM users WHERE id = '" + @class.GetHabbo().Id + "' LIMIT 1");
						}
						@class.GetHabbo().string_5 = (string)dataRow["look"];
						@class.GetHabbo().string_6 = dataRow["gender"].ToString().ToLower();
						@class.GetHabbo().string_4 = Phoenix.smethod_7((string)dataRow["motto"]);
						@class.GetHabbo().bool_11 = Phoenix.smethod_3(dataRow["block_newfriends"].ToString());
						ServerMessage gClass5 = new ServerMessage(266u);
						gClass5.AppendInt32(-1);
						gClass5.AppendStringWithBreak(@class.GetHabbo().string_5);
						gClass5.AppendStringWithBreak(@class.GetHabbo().string_6.ToLower());
						gClass5.AppendStringWithBreak(@class.GetHabbo().string_4);
						@class.method_14(gClass5);
						if (@class.GetHabbo().Boolean_0)
						{
							class4 = Phoenix.GetGame().GetRoomManager().GetRoom(@class.GetHabbo().CurrentRoomId);
							Class33 class6 = class4.method_53(@class.GetHabbo().Id);
							ServerMessage gClass6 = new ServerMessage(266u);
							gClass6.AppendInt32(class6.int_0);
							gClass6.AppendStringWithBreak(@class.GetHabbo().string_5);
							gClass6.AppendStringWithBreak(@class.GetHabbo().string_6.ToLower());
							gClass6.AppendStringWithBreak(@class.GetHabbo().string_4);
							gClass6.AppendInt32(@class.GetHabbo().int_13);
							gClass6.AppendStringWithBreak("");
							class4.SendMessage(gClass6, null);
						}
						text3 = text.ToLower();
						if (text3 == null)
						{
							goto IL_C70;
						}
						if (text3 == "updatemotto")
						{
							Phoenix.GetGame().GetAchievementManager().method_3(@class, 5u, 1);
							goto IL_C70;
						}
						if (text3 == "updatelook")
						{
							Phoenix.GetGame().GetAchievementManager().method_3(@class, 1u, 1);
							goto IL_C70;
						}
						goto IL_C70;
					}
					default:
						goto IL_C70;
					}
					using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
					{
						Phoenix.GetGame().GetCatalog().method_0(class2);
					}
					Phoenix.GetGame().GetCatalog().method_1();
					Phoenix.GetGame().GetClientManager().SendToAll(new ServerMessage(441u));
					goto IL_C70;
					IL_34E:
					num2 = uint.Parse(text2.Split(new char[]
					{
						' '
					})[0]);
					num3 = uint.Parse(text2.Split(new char[]
					{
						' '
					})[1]);
					GameClient class7 = Phoenix.GetGame().GetClientManager().method_2(num2);
					class4 = Phoenix.GetGame().GetRoomManager().GetRoom(num3);
					if (class7 != null)
					{
						ServerMessage gClass7 = new ServerMessage(286u);
						gClass7.AppendBoolean(class4.Boolean_3);
						gClass7.AppendUInt(num3);
						class7.method_14(gClass7);
						goto IL_C70;
					}
					goto IL_C70;
					IL_5BF:
					uint_2 = uint.Parse(text2);
					using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
					{
						Phoenix.GetGame().GetClientManager().method_2(uint_2).GetHabbo().method_0(class2);
						goto IL_C70;
					}
					IL_602:
					Phoenix.smethod_18();
					goto IL_C70;
					IL_633:
					@class = Phoenix.GetGame().GetClientManager().method_2(uint.Parse(text2));
					if (@class != null)
					{
						int int_3 = 0;
						using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
						{
							int_3 = (int)class2.ReadDataRow("SELECT credits FROM users WHERE id = '" + @class.GetHabbo().Id + "' LIMIT 1")[0];
						}
						@class.GetHabbo().Credits = int_3;
						@class.GetHabbo().method_13(false);
						goto IL_C70;
					}
					goto IL_C70;
					IL_6F7:
					@class = Phoenix.GetGame().GetClientManager().method_2(uint.Parse(text2));
					if (@class != null)
					{
						int int_4 = 0;
						using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
						{
							int_4 = (int)class2.ReadDataRow("SELECT activity_points FROM users WHERE id = '" + @class.GetHabbo().Id + "' LIMIT 1")[0];
						}
						@class.GetHabbo().ActivityPoints = int_4;
						@class.GetHabbo().method_15(false);
						goto IL_C70;
					}
					goto IL_C70;
					IL_839:
					Phoenix.GetGame().GetClientManager().method_2(uint.Parse(text2)).method_12();
					goto IL_C70;
					IL_880:
					string text6 = text2.Split(new char[]
					{
						' '
					})[0];
					text5 = text2.Substring(text6.Length + 1);
					ServerMessage gClass8 = new ServerMessage(808u);
					gClass8.AppendStringWithBreak(PhoenixEnvironment.GetExternalText("mus_alert_title"));
					gClass8.AppendStringWithBreak(text5);
					Phoenix.GetGame().GetClientManager().method_2(uint.Parse(text6)).method_14(gClass8);
				}
			}
			IL_C70:
			ServerMessage gClass9 = new ServerMessage(1u);
			gClass9.AppendString("Hello Housekeeping, Love from Phoenix Emu");
			this.Connection.Send(gClass9.GetBytes());
		}
	}
}
