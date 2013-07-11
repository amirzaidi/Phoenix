using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Phoenix.HabboHotel.Users.UserDataManagement;
using Phoenix.HabboHotel.Users.Subscriptions;
using Phoenix.HabboHotel.Users.Inventory;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Util;
using Phoenix.Messages;
using Phoenix.HabboHotel.Users.Messenger;
using Phoenix.HabboHotel.Users.Badges;
using Phoenix.Storage;
namespace Phoenix.HabboHotel.Users
{
	internal sealed class Habbo
	{
		public uint Id;
		public string Username;
		public string RealName;
		public bool bool_0;
		public bool bool_1;
		public bool bool_2;
		public string string_2;
		public string string_3;
		public uint uint_1;
		public string string_4;
		public string string_5;
		public string string_6;
		public int int_0;
		public DataTable dataTable_0;
		public List<int> list_0;
		public int int_1;
		public int Credits;
		public int ActivityPoints;
		public double LastActivityPointsUpdate;
		public bool bool_3;
		public int int_4;
		internal bool bool_4 = false;
		public uint uint_2;
		public bool bool_5;
		public bool bool_6;
		public uint CurrentRoomId;
		public uint uint_4;
		public bool bool_7;
		public uint uint_5;
		public List<uint> list_1;
		public List<uint> list_2;
		public List<string> list_3;
		public Dictionary<uint, int> dictionary_0;
		public List<uint> list_4;
		private SubscriptionManager class53_0;
		private Class105 class105_0;
		private UserBadges class56_0;
		private UserInventory class38_0;
		private AvatarEffectsInventoryComponent class50_0;
		private GameClient class16_0;
		public List<uint> CompletedQuests;
		public uint CurrentQuestId;
		public int CurrentQuestProgress;
		public int int_6;
		public int int_7;
		public int int_8;
		public int int_9;
		public uint uint_7;
		public int int_10;
		public bool bool_8;
		public bool bool_9;
		public bool bool_10;
		public bool bool_11;
		public bool bool_12;
		public bool bool_13;
		public bool bool_14;
		public int int_11;
		public int VipPoints;
		public int int_13;
		public int RoomVisits;
		public int int_15;
		public int int_16;
		public int Respect;
		public int RespectGiven;
		public int GiftsGiven;
		public int GiftsReceived;
		public int int_21;
		public int int_22;
		private UserDataFactory class12_0;
		internal List<RoomData> list_6;
		public int int_23;
		public DateTime dateTime_0;
		public bool bool_15;
		public int int_24;
		private bool bool_16 = false;
		public bool Boolean_0
		{
			get
			{
				return this.CurrentRoomId >= 1u;
			}
		}
		public Room Class14_0
		{
			get
			{
				if (this.CurrentRoomId <= 0u)
				{
					return null;
				}
				else
				{
					return Phoenix.GetGame().GetRoomManager().GetRoom(this.CurrentRoomId);
				}
			}
		}
		internal UserDataFactory Class12_0
		{
			get
			{
				return this.class12_0;
			}
		}
		internal string String_0
		{
			get
			{
				this.bool_16 = true;
				int num = (int)Phoenix.GetUnixTimestamp() - this.int_16;
				string text = string.Concat(new object[]
				{
					"UPDATE users SET last_online = UNIX_TIMESTAMP(), online = '0', activity_points_lastupdate = '",
					this.LastActivityPointsUpdate,
					"' WHERE id = '",
					this.Id,
					"' LIMIT 1; "
				});
				object obj = text;
				return string.Concat(new object[]
				{
					obj,
					"UPDATE user_stats SET RoomVisits = '",
					this.RoomVisits,
					"', OnlineTime = OnlineTime + ",
					num,
					", Respect = '",
					this.Respect,
					"', RespectGiven = '",
					this.RespectGiven,
					"', GiftsGiven = '",
					this.GiftsGiven,
					"', GiftsReceived = '",
					this.GiftsReceived,
					"' WHERE id = '",
					this.Id,
					"' LIMIT 1; "
				});
			}
		}
		public Habbo(uint UserId, string string_7, string string_8, string string_9, uint uint_9, string string_10, string string_11, string string_12, int int_25, int int_26, double double_1, bool bool_17, uint uint_10, int int_27, bool bool_18, bool bool_19, bool bool_20, bool bool_21, int int_28, int int_29, bool bool_22, string string_13, GameClient class16_1, UserDataFactory class12_1)
		{
			if (class16_1 != null)
			{
				Phoenix.GetGame().GetClientManager().method_0(UserId, string_7, class16_1);
			}
			this.Id = UserId;
			this.Username = string_7;
			this.RealName = string_8;
			this.bool_0 = Config.bool_15;
			this.bool_1 = true;
			this.string_2 = string_9;
			this.uint_1 = uint_9;
			this.string_4 = string_10;
			this.string_5 = Phoenix.smethod_7(string_11.ToLower());
			this.string_6 = string_12.ToLower();
			this.Credits = int_25;
			this.VipPoints = int_29;
			this.ActivityPoints = int_26;
			this.LastActivityPointsUpdate = double_1;
			this.bool_2 = bool_22;
			this.bool_3 = bool_17;
			this.uint_2 = 0u;
			this.bool_5 = false;
			this.bool_6 = false;
			this.CurrentRoomId = 0u;
			this.uint_4 = uint_10;
			this.list_1 = new List<uint>();
			this.list_2 = new List<uint>();
			this.list_3 = new List<string>();
			this.dictionary_0 = new Dictionary<uint, int>();
			this.list_4 = new List<uint>();
			this.int_10 = int_27;
			this.bool_10 = false;
			this.bool_11 = bool_18;
			this.bool_12 = bool_19;
			this.bool_13 = bool_20;
			this.bool_14 = bool_21;
			this.int_11 = int_28;
			this.int_1 = 0;
			this.int_24 = 1;
			this.string_3 = string_13;
			this.bool_7 = false;
			this.uint_5 = 0u;
			this.class16_0 = class16_1;
			this.class12_0 = class12_1;
			this.list_6 = new List<RoomData>();
			this.list_0 = new List<int>();
			DataRow dataRow = null;
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				@class.AddParamWithValue("user_id", UserId);
				dataRow = @class.ReadDataRow("SELECT * FROM user_stats WHERE id = @user_id LIMIT 1");
				if (dataRow == null)
				{
					@class.ExecuteQuery("INSERT INTO user_stats (id) VALUES ('" + UserId + "')");
					dataRow = @class.ReadDataRow("SELECT * FROM user_stats WHERE id = @user_id LIMIT 1");
				}
				this.dataTable_0 = @class.ReadDataTable("SELECT * FROM group_memberships WHERE userid = @user_id");
				IEnumerator enumerator;
				if (this.dataTable_0 != null)
				{
					enumerator = this.dataTable_0.Rows.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							DataRow dataRow2 = (DataRow)enumerator.Current;
							GroupsManager class2 = Groups.smethod_2((int)dataRow2["groupid"]);
							if (class2 == null)
							{
								DataTable dataTable = @class.ReadDataTable("SELECT * FROM groups WHERE id = " + (int)dataRow2["groupid"] + " LIMIT 1;");
								IEnumerator enumerator2 = dataTable.Rows.GetEnumerator();
								try
								{
									while (enumerator2.MoveNext())
									{
										DataRow dataRow3 = (DataRow)enumerator2.Current;
										if (!Groups.GroupsManager.ContainsKey((int)dataRow3["id"]))
										{
											Groups.GroupsManager.Add((int)dataRow3["id"], new GroupsManager((int)dataRow3["id"], dataRow3, @class));
										}
									}
									continue;
								}
								finally
								{
									IDisposable disposable = enumerator2 as IDisposable;
									if (disposable != null)
									{
										disposable.Dispose();
									}
								}
							}
							if (!class2.list_0.Contains((int)UserId))
							{
								class2.method_0((int)UserId);
							}
						}
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
					int num = (int)dataRow["groupid"];
					GroupsManager class3 = Groups.smethod_2(num);
					if (class3 != null)
					{
						this.int_0 = num;
					}
					else
					{
						this.int_0 = 0;
					}
				}
				else
				{
					this.int_0 = 0;
				}
				DataTable dataTable2 = @class.ReadDataTable("SELECT groupid FROM group_requests WHERE userid = '" + UserId + "';");
				enumerator = dataTable2.Rows.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						DataRow dataRow2 = (DataRow)enumerator.Current;
						this.list_0.Add((int)dataRow2["groupid"]);
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
			this.RoomVisits = (int)dataRow["RoomVisits"];
			this.int_16 = (int)Phoenix.GetUnixTimestamp();
			this.int_15 = (int)dataRow["OnlineTime"];
			this.Respect = (int)dataRow["Respect"];
			this.RespectGiven = (int)dataRow["RespectGiven"];
			this.GiftsGiven = (int)dataRow["GiftsGiven"];
			this.GiftsReceived = (int)dataRow["GiftsReceived"];
			this.int_21 = (int)dataRow["DailyRespectPoints"];
			this.int_22 = (int)dataRow["DailyPetRespectPoints"];
			this.int_13 = (int)dataRow["AchievementScore"];
			this.CompletedQuests = new List<uint>();
			this.uint_7 = 0u;
			this.CurrentQuestId = (uint)dataRow["quest_id"];
			this.CurrentQuestProgress = (int)dataRow["quest_progress"];
			this.int_6 = (int)dataRow["lev_builder"];
			this.int_8 = (int)dataRow["lev_identity"];
			this.int_7 = (int)dataRow["lev_social"];
			this.int_9 = (int)dataRow["lev_explore"];
			if (class16_1 != null)
			{
				this.class53_0 = new SubscriptionManager(UserId, class12_1);
				this.class56_0 = new UserBadges(UserId, class12_1);
				this.class38_0 = new UserInventory(UserId, class16_1, class12_1);
				this.class50_0 = new AvatarEffectsInventoryComponent(UserId, class16_1, class12_1);
				this.bool_8 = false;
				this.bool_9 = false;
				foreach (DataRow dataRow3 in class12_1.DataTable_10.Rows)
				{
					this.list_6.Add(Phoenix.GetGame().GetRoomManager().method_17((uint)dataRow3["id"], dataRow3));
				}
			}
		}
		public void method_0(DatabaseClient class6_0)
		{
			this.dataTable_0 = class6_0.ReadDataTable("SELECT * FROM group_memberships WHERE userid = " + this.Id);
			if (this.dataTable_0 != null)
			{
				foreach (DataRow dataRow in this.dataTable_0.Rows)
				{
					GroupsManager @class = Groups.smethod_2((int)dataRow["groupid"]);
					if (@class == null)
					{
						DataTable dataTable = class6_0.ReadDataTable("SELECT * FROM groups WHERE id = " + (int)dataRow["groupid"] + " LIMIT 1;");
						IEnumerator enumerator2 = dataTable.Rows.GetEnumerator();
						try
						{
							while (enumerator2.MoveNext())
							{
								DataRow dataRow2 = (DataRow)enumerator2.Current;
								if (!Groups.GroupsManager.ContainsKey((int)dataRow2["id"]))
								{
									Groups.GroupsManager.Add((int)dataRow2["id"], new GroupsManager((int)dataRow2["id"], dataRow2, class6_0));
								}
							}
							continue;
						}
						finally
						{
							IDisposable disposable = enumerator2 as IDisposable;
							if (disposable != null)
							{
								disposable.Dispose();
							}
						}
					}
					if (!@class.list_0.Contains((int)this.Id))
					{
						@class.method_0((int)this.Id);
					}
				}
				int num = class6_0.ReadInt32("SELECT groupid FROM user_stats WHERE id = " + this.Id + " LIMIT 1");
				GroupsManager class2 = Groups.smethod_2(num);
				if (class2 != null)
				{
					this.int_0 = num;
				}
				else
				{
					this.int_0 = 0;
				}
			}
			else
			{
				this.int_0 = 0;
			}
		}
		internal void method_1(DatabaseClient class6_0)
		{
			this.list_6.Clear();
			class6_0.AddParamWithValue("name", this.Username);
			DataTable dataTable = class6_0.ReadDataTable("SELECT * FROM rooms WHERE owner = @name ORDER BY id ASC");
			foreach (DataRow dataRow in dataTable.Rows)
			{
				this.list_6.Add(Phoenix.GetGame().GetRoomManager().method_17((uint)dataRow["id"], dataRow));
			}
		}
		public void method_2(UserDataFactory class12_1)
		{
			this.method_8(class12_1);
			this.method_5(class12_1);
			this.method_6(class12_1);
			this.method_7(class12_1);
			this.method_25();
		}
		public bool HasFuse(string string_7)
		{
			if (Phoenix.GetGame().GetRoleManager().method_3(this.Id))
			{
				return Phoenix.GetGame().GetRoleManager().method_4(this.Id, string_7);
			}
			else
			{
				return Phoenix.GetGame().GetRoleManager().method_1(this.uint_1, string_7);
			}
		}
		public int method_4()
		{
			if (this.bool_0)
			{
				return 0;
			}
			else
			{
				return Phoenix.GetGame().GetRoleManager().method_2(this.uint_1);
			}
		}
		public void method_5(UserDataFactory class12_1)
		{
			this.list_1.Clear();
			DataTable dataTable_ = class12_1.DataTable_1;
			foreach (DataRow dataRow in dataTable_.Rows)
			{
				this.list_1.Add((uint)dataRow["room_id"]);
			}
		}
		public void method_6(UserDataFactory class12_1)
		{
			DataTable dataTable_ = class12_1.DataTable_2;
			foreach (DataRow dataRow in dataTable_.Rows)
			{
				this.list_2.Add((uint)dataRow["ignore_id"]);
			}
		}
		public void method_7(UserDataFactory class12_1)
		{
			this.list_3.Clear();
			DataTable dataTable_ = class12_1.DataTable_3;
			foreach (DataRow dataRow in dataTable_.Rows)
			{
				this.list_3.Add((string)dataRow["tag"]);
			}
			if (this.list_3.Count >= 5 && this.method_19() != null)
			{
				Phoenix.GetGame().GetAchievementManager().method_3(this.method_19(), 7u, 1);
			}
		}
		public void method_8(UserDataFactory class12_1)
		{
			DataTable dataTable = class12_1.DataTable_0;
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					this.dictionary_0.Add((uint)dataRow["achievement_id"], (int)dataRow["achievement_level"]);
				}
			}
		}
		public void method_9()
		{
			if (!this.bool_9)
			{
				this.bool_9 = true;
				Phoenix.GetGame().GetClientManager().method_1(this.Id, this.Username);
				if (!this.bool_16)
				{
					this.bool_16 = true;
					using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
					{
						@class.ExecuteQuery(string.Concat(new object[]
						{
							"UPDATE users SET last_online = UNIX_TIMESTAMP(), users.online = '0', activity_points = '",
							this.ActivityPoints,
							"', activity_points_lastupdate = '",
							this.LastActivityPointsUpdate,
							"', credits = '",
							this.Credits,
							"' WHERE id = '",
							this.Id,
							"' LIMIT 1;"
						}));
						int num = (int)Phoenix.GetUnixTimestamp() - this.int_16;
						@class.ExecuteQuery(string.Concat(new object[]
						{
							"UPDATE user_stats SET RoomVisits = '",
							this.RoomVisits,
							"', OnlineTime = OnlineTime + ",
							num,
							", Respect = '",
							this.Respect,
							"', RespectGiven = '",
							this.RespectGiven,
							"', GiftsGiven = '",
							this.GiftsGiven,
							"', GiftsReceived = '",
							this.GiftsReceived,
							"' WHERE id = '",
							this.Id,
							"' LIMIT 1; "
						}));
					}
				}
				if (this.Boolean_0 && this.Class14_0 != null)
				{
					this.Class14_0.method_47(this.class16_0, false, false);
				}
				if (this.class105_0 != null)
				{
					this.class105_0.bool_0 = true;
					this.class105_0.method_5(true);
					this.class105_0 = null;
				}
				if (this.class53_0 != null)
				{
					this.class53_0.method_0();
					this.class53_0 = null;
				}
				this.class38_0.method_18();
			}
		}
		internal void method_10(uint RoomId)
		{
			if (Config.Boolean_6)
			{
				using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
				{
					@class.ExecuteQuery(string.Concat(new object[]
					{
						"INSERT INTO user_roomvisits (user_id,room_id,entry_timestamp,exit_timestamp,hour,minute) VALUES ('",
						this.Id,
						"','",
						RoomId,
						"',UNIX_TIMESTAMP(),'0','",
						DateTime.Now.Hour,
						"','",
						DateTime.Now.Minute,
						"')"
					}));
				}
			}
			this.CurrentRoomId = RoomId;
			if (this.Class14_0.Owner != this.Username && this.CurrentQuestId == 15u)
			{
				Phoenix.GetGame().GetQuestManager().method_1(15u, this.method_19());
			}
			this.class105_0.method_5(false);
		}
		public void method_11()
		{
			try
			{
				if (Config.Boolean_6)
				{
					using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
					{
						@class.ExecuteQuery(string.Concat(new object[]
						{
							"UPDATE user_roomvisits SET exit_timestamp = UNIX_TIMESTAMP() WHERE room_id = '",
							this.CurrentRoomId,
							"' AND user_id = '",
							this.Id,
							"' ORDER BY entry_timestamp DESC LIMIT 1"
						}));
					}
				}
			}
			catch
			{
			}
			this.CurrentRoomId = 0u;
			if (this.class105_0 != null)
			{
				this.class105_0.method_5(false);
			}
		}
		public void method_12()
		{
			if (this.method_21() == null)
			{
				this.class105_0 = new Class105(this.Id);
				this.class105_0.method_0(this.class12_0);
				this.class105_0.method_1(this.class12_0);
				GameClient @class = this.method_19();
				if (@class != null)
				{
					@class.method_14(this.class105_0.method_21());
					@class.method_14(this.class105_0.method_23());
					this.class105_0.method_5(true);
				}
			}
		}
		public void method_13(bool bool_17)
		{
			ServerMessage gClass = new ServerMessage(6u);
			gClass.AppendStringWithBreak(this.Credits + ".0");
			this.class16_0.method_14(gClass);
			if (bool_17)
			{
				using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
				{
					@class.ExecuteQuery(string.Concat(new object[]
					{
						"UPDATE users SET credits = '",
						this.Credits,
						"' WHERE id = '",
						this.Id,
						"' LIMIT 1;"
					}));
				}
			}
		}
		public void method_14(bool bool_17, bool bool_18)
		{
			if (bool_17)
			{
				using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
				{
					this.VipPoints = @class.ReadInt32("SELECT vip_points FROM users WHERE id = '" + this.Id + "' LIMIT 1;");
				}
			}
			if (bool_18)
			{
				using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
				{
					@class.ExecuteQuery(string.Concat(new object[]
					{
						"UPDATE users SET vip_points = '",
						this.VipPoints,
						"' WHERE id = '",
						this.Id,
						"' LIMIT 1;"
					}));
				}
			}
			this.method_16(0);
		}
		public void method_15(bool bool_17)
		{
			this.method_16(0);
			if (bool_17)
			{
				using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
				{
					@class.ExecuteQuery(string.Concat(new object[]
					{
						"UPDATE users SET activity_points = '",
						this.ActivityPoints,
						"' WHERE id = '",
						this.Id,
						"' LIMIT 1;"
					}));
				}
			}
		}
		public void method_16(int int_25)
		{
			ServerMessage gClass = new ServerMessage(438u);
			gClass.AppendInt32(this.ActivityPoints);
			gClass.AppendInt32(int_25);
			gClass.AppendInt32(0);
			ServerMessage gClass2 = new ServerMessage(438u);
			gClass2.AppendInt32(this.VipPoints);
			gClass2.AppendInt32(0);
			gClass2.AppendInt32(1);
			ServerMessage gClass3 = new ServerMessage(438u);
			gClass3.AppendInt32(this.VipPoints);
			gClass3.AppendInt32(0);
			gClass3.AppendInt32(2);
			ServerMessage gClass4 = new ServerMessage(438u);
			gClass4.AppendInt32(this.VipPoints);
			gClass4.AppendInt32(0);
			gClass4.AppendInt32(3);
			ServerMessage gClass5 = new ServerMessage(438u);
			gClass5.AppendInt32(this.VipPoints);
			gClass5.AppendInt32(0);
			gClass5.AppendInt32(4);
			this.class16_0.method_14(gClass);
			this.class16_0.method_14(gClass2);
			this.class16_0.method_14(gClass3);
			this.class16_0.method_14(gClass4);
			this.class16_0.method_14(gClass5);
		}
		public void method_17()
		{
			if (!this.bool_3)
			{
				this.method_19().SendNotif("You have been muted by a moderator.");
				this.bool_3 = true;
			}
		}
		public void method_18()
		{
			if (this.bool_3)
			{
				this.bool_3 = false;
			}
		}
		private GameClient method_19()
		{
			return Phoenix.GetGame().GetClientManager().method_2(this.Id);
		}
		public SubscriptionManager method_20()
		{
			return this.class53_0;
		}
		public Class105 method_21()
		{
			return this.class105_0;
		}
		public UserBadges method_22()
		{
			return this.class56_0;
		}
		public UserInventory method_23()
		{
			return this.class38_0;
		}
		public AvatarEffectsInventoryComponent method_24()
		{
			return this.class50_0;
		}
		public void method_25()
		{
			this.CompletedQuests.Clear();
			DataTable dataTable = null;
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				dataTable = @class.ReadDataTable("SELECT quest_id FROM user_quests WHERE user_id = '" + this.Id + "'");
			}
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					this.CompletedQuests.Add((uint)dataRow["quest_Id"]);
				}
			}
		}
		public void method_26(bool bool_17, GameClient class16_1)
		{
			ServerMessage gClass = new ServerMessage(266u);
			gClass.AppendInt32(-1);
			gClass.AppendStringWithBreak(class16_1.GetHabbo().string_5);
			gClass.AppendStringWithBreak(class16_1.GetHabbo().string_6.ToLower());
			gClass.AppendStringWithBreak(class16_1.GetHabbo().string_4);
			gClass.AppendInt32(class16_1.GetHabbo().int_13);
			gClass.AppendStringWithBreak("");
			class16_1.method_14(gClass);
			if (class16_1.GetHabbo().Boolean_0)
			{
				Room class14_ = class16_1.GetHabbo().Class14_0;
				if (class14_ != null)
				{
					Class33 @class = class14_.method_53(class16_1.GetHabbo().Id);
					if (@class != null)
					{
						if (bool_17)
						{
							DataRow dataRow = null;
							using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
							{
								class2.AddParamWithValue("userid", class16_1.GetHabbo().Id);
								dataRow = class2.ReadDataRow("SELECT * FROM users WHERE id = @userid LIMIT 1");
							}
							class16_1.GetHabbo().string_4 = Phoenix.smethod_7((string)dataRow["motto"]);
							class16_1.GetHabbo().string_5 = Phoenix.smethod_7((string)dataRow["look"]);
						}
						ServerMessage gClass2 = new ServerMessage(266u);
						gClass2.AppendInt32(@class.int_0);
						gClass2.AppendStringWithBreak(class16_1.GetHabbo().string_5);
						gClass2.AppendStringWithBreak(class16_1.GetHabbo().string_6.ToLower());
						gClass2.AppendStringWithBreak(class16_1.GetHabbo().string_4);
						gClass2.AppendInt32(class16_1.GetHabbo().int_13);
						gClass2.AppendStringWithBreak("");
						class14_.SendMessage(gClass2, null);
					}
				}
			}
		}
		public void method_27()
		{
			DataRow dataRow;
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				dataRow = @class.ReadDataRow("SELECT vip FROM users WHERE id = '" + this.Id + "' LIMIT 1;");
			}
			this.bool_14 = Phoenix.smethod_3(dataRow["vip"].ToString());
			ServerMessage gClass = new ServerMessage(2u);
			if (this.bool_14 || Config.Boolean_3)
			{
				gClass.AppendInt32(2);
			}
			else
			{
				if (this.method_20().method_2("habbo_club"))
				{
					gClass.AppendInt32(1);
				}
				else
				{
					gClass.AppendInt32(0);
				}
			}
			if (this.HasFuse("acc_anyroomowner"))
			{
				gClass.AppendInt32(7);
			}
			else
			{
				if (this.HasFuse("acc_anyroomrights"))
				{
					gClass.AppendInt32(5);
				}
				else
				{
					if (this.HasFuse("acc_supporttool"))
					{
						gClass.AppendInt32(4);
					}
					else
					{
						if (this.bool_14 || Config.Boolean_3 || this.method_20().method_2("habbo_club"))
						{
							gClass.AppendInt32(2);
						}
						else
						{
							gClass.AppendInt32(0);
						}
					}
				}
			}
			this.method_19().method_14(gClass);
		}
		public void method_28(string string_7)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(this.CurrentRoomId);
			if (@class != null)
			{
				Class33 class2 = @class.method_53(this.Id);
				ServerMessage gClass = new ServerMessage(25u);
				gClass.AppendInt32(class2.int_0);
				gClass.AppendStringWithBreak(string_7);
				gClass.AppendBoolean(false);
				this.method_19().method_14(gClass);
			}
		}
	}
}
