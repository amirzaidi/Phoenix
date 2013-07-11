using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Phoenix.HabboHotel.Misc;
using Phoenix.HabboHotel.Users.UserDataManagement;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Util;
using Phoenix.Messages;
using Phoenix.HabboHotel.Users.Messenger;
using Phoenix.Storage;
namespace Phoenix.HabboHotel.Users.Messenger
{
	internal sealed class Class105
	{
		private uint uint_0;
		private Hashtable hashtable_0;
		private Hashtable hashtable_1;
		internal bool bool_0;
		public Class105(uint uint_1)
		{
			this.hashtable_0 = new Hashtable();
			this.hashtable_1 = new Hashtable();
			this.uint_0 = uint_1;
		}
		internal void method_0(UserDataFactory class12_0)
		{
			this.hashtable_0 = new Hashtable();
			DataTable dataTable_ = class12_0.DataTable_8;
			if (dataTable_ != null)
			{
				foreach (DataRow dataRow in dataTable_.Rows)
				{
					this.hashtable_0.Add((uint)dataRow["id"], new Class104((uint)dataRow["id"], dataRow["username"] as string, dataRow["look"] as string, dataRow["motto"] as string, dataRow["last_online"] as string));
				}
				try
				{
					if (this.method_25().GetHabbo().HasFuse("receive_sa"))
					{
						this.hashtable_0.Add(0, new Class104(0u, "Staff Chat", this.method_25().GetHabbo().string_5, "Staff Chat Room", "0"));
					}
				}
				catch
				{
				}
			}
		}
		internal void method_1(UserDataFactory class12_0)
		{
			this.hashtable_1 = new Hashtable();
			DataTable dataTable_ = class12_0.DataTable_9;
			if (dataTable_ != null)
			{
				foreach (DataRow dataRow in dataTable_.Rows)
				{
					this.hashtable_1.Add((uint)dataRow["from_id"], new FriendRequest((uint)dataRow["id"], this.uint_0, (uint)dataRow["from_id"], dataRow["username"] as string));
				}
			}
		}
		internal void method_2()
		{
			this.hashtable_0.Clear();
		}
		public void method_3()
		{
			this.hashtable_1.Clear();
		}
		internal FriendRequest method_4(uint uint_1)
		{
			return this.hashtable_1[uint_1] as FriendRequest;
		}
		internal void method_5(bool bool_1)
		{
			Hashtable hashtable = this.hashtable_0.Clone() as Hashtable;
			foreach (Class104 @class in hashtable.Values)
			{
				try
				{
					GameClient class2 = Phoenix.GetGame().GetClientManager().method_2(@class.UInt32_0);
					if (class2 != null && class2.GetHabbo() != null && class2.GetHabbo().method_21() != null)
					{
						class2.GetHabbo().method_21().method_6(this.uint_0);
						if (bool_1)
						{
							class2.GetHabbo().method_21().method_7();
						}
					}
				}
				catch
				{
				}
			}
			hashtable.Clear();
			hashtable = null;
		}
		internal bool method_6(uint uint_1)
		{
			Hashtable hashtable = this.hashtable_0.Clone() as Hashtable;
			bool result;
			foreach (Class104 @class in hashtable.Values)
			{
				if (@class.UInt32_0 == uint_1)
				{
					@class.bool_0 = true;
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}
		internal void method_7()
		{
			this.method_25().method_14(this.method_22());
		}
		internal bool method_8(uint uint_1, uint uint_2)
		{
			bool result;
			if (uint_1 == uint_2)
			{
				result = true;
			}
			else
			{
				using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
				{
					if (@class.ReadDataRow(string.Concat(new object[]
					{
						"SELECT id FROM messenger_requests WHERE to_id = '",
						uint_1,
						"' AND from_id = '",
						uint_2,
						"' LIMIT 1"
					})) != null)
					{
						result = true;
						return result;
					}
					if (@class.ReadDataRow(string.Concat(new object[]
					{
						"SELECT id FROM messenger_requests WHERE to_id = '",
						uint_2,
						"' AND from_id = '",
						uint_1,
						"' LIMIT 1"
					})) != null)
					{
						result = true;
						return result;
					}
				}
				result = false;
			}
			return result;
		}
		internal bool method_9(uint uint_1, uint uint_2)
		{
			bool result;
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				if (@class.ReadDataRow(string.Concat(new object[]
				{
					"SELECT user_one_id FROM messenger_friendships WHERE user_one_id = '",
					uint_1,
					"' AND user_two_id = '",
					uint_2,
					"' LIMIT 1"
				})) != null)
				{
					result = true;
					return result;
				}
				if (@class.ReadDataRow(string.Concat(new object[]
				{
					"SELECT user_one_id FROM messenger_friendships WHERE user_one_id = '",
					uint_2,
					"' AND user_two_id = '",
					uint_1,
					"' LIMIT 1"
				})) != null)
				{
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}
		internal void method_10()
		{
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				@class.ExecuteQuery("DELETE FROM messenger_requests WHERE to_id = '" + this.uint_0 + "'");
			}
			this.method_3();
		}
		internal void method_11(uint uint_1)
		{
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				@class.AddParamWithValue("userid", this.uint_0);
				@class.AddParamWithValue("fromid", uint_1);
				@class.ExecuteQuery("DELETE FROM messenger_requests WHERE to_id = @userid AND from_id = @fromid LIMIT 1");
			}
			if (this.method_4(uint_1) != null)
			{
				this.hashtable_1.Remove(uint_1);
			}
		}
		internal void method_12(uint uint_1)
		{
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				@class.AddParamWithValue("toid", uint_1);
				@class.AddParamWithValue("userid", this.uint_0);
				@class.ExecuteQuery("INSERT INTO messenger_friendships (user_one_id,user_two_id) VALUES (@userid,@toid)");
				@class.ExecuteQuery("INSERT INTO messenger_friendships (user_one_id,user_two_id) VALUES (@toid,@userid)");
			}
			this.method_14(uint_1);
			GameClient class2 = Phoenix.GetGame().GetClientManager().method_2(uint_1);
			if (class2 != null && class2.GetHabbo().method_21() != null)
			{
				class2.GetHabbo().method_21().method_14(this.uint_0);
			}
		}
		internal void method_13(uint uint_1)
		{
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				@class.AddParamWithValue("toid", uint_1);
				@class.AddParamWithValue("userid", this.uint_0);
				@class.ExecuteQuery("DELETE FROM messenger_friendships WHERE user_one_id = @toid AND user_two_id = @userid LIMIT 1");
				@class.ExecuteQuery("DELETE FROM messenger_friendships WHERE user_one_id = @userid AND user_two_id = @toid LIMIT 1");
			}
			this.method_15(uint_1);
			GameClient class2 = Phoenix.GetGame().GetClientManager().method_2(uint_1);
			if (class2 != null && class2.GetHabbo().method_21() != null)
			{
				class2.GetHabbo().method_21().method_15(this.uint_0);
			}
		}
		internal void method_14(uint uint_1)
		{
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				DataRow dataRow = @class.ReadDataRow("SELECT username,motto,look,last_online FROM users WHERE id = '" + uint_1 + "' LIMIT 1");
				Class104 class2 = new Class104(uint_1, dataRow["username"] as string, dataRow["look"] as string, dataRow["motto"] as string, dataRow["last_online"] as string);
				class2.bool_0 = true;
				if (!this.hashtable_0.Contains(class2.UInt32_0))
				{
					this.hashtable_0.Add(class2.UInt32_0, class2);
				}
				this.method_7();
			}
		}
		internal void method_15(uint uint_1)
		{
			this.hashtable_0.Remove(uint_1);
			ServerMessage gClass = new ServerMessage(13u);
			gClass.AppendInt32(0);
			gClass.AppendInt32(1);
			gClass.AppendInt32(-1);
			gClass.AppendUInt(uint_1);
			this.method_25().method_14(gClass);
		}
		internal void method_16(string string_0)
		{
			DataRow dataRow = null;
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				@class.AddParamWithValue("query", string_0.ToLower());
				dataRow = @class.ReadDataRow("SELECT id,block_newfriends FROM users WHERE username = @query LIMIT 1");
			}
			if (dataRow != null)
			{
				if (Phoenix.smethod_3(dataRow["block_newfriends"].ToString()) && !this.method_25().GetHabbo().HasFuse("ignore_friendsettings"))
				{
					ServerMessage gClass = new ServerMessage(260u);
					gClass.AppendInt32(39);
					gClass.AppendInt32(3);
					this.method_25().method_14(gClass);
				}
				else
				{
					uint num = (uint)dataRow["id"];
					if (!this.method_8(this.uint_0, num))
					{
						using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
						{
							@class.AddParamWithValue("toid", num);
							@class.AddParamWithValue("userid", this.uint_0);
							@class.ExecuteQuery("INSERT INTO messenger_requests (to_id,from_id) VALUES (@toid,@userid)");
						}
						GameClient class2 = Phoenix.GetGame().GetClientManager().method_2(num);
						if (class2 != null && class2.GetHabbo() != null)
						{
							uint num2 = 0u;
							using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
							{
								@class.AddParamWithValue("toid", num);
								@class.AddParamWithValue("userid", this.uint_0);
								num2 = @class.ReadUInt32("SELECT id FROM messenger_requests WHERE to_id = @toid AND from_id = @userid ORDER BY id DESC LIMIT 1");
							}
							FriendRequest class3 = new FriendRequest(num2, num, this.uint_0, Phoenix.GetGame().GetClientManager().GetNameById(this.uint_0));
							class2.GetHabbo().method_21().method_17(num2, num, this.uint_0);
							ServerMessage gclass5_ = new ServerMessage(132u);
							class3.method_0(gclass5_);
							class2.method_14(gclass5_);
						}
					}
				}
			}
		}
		internal void method_17(uint uint_1, uint uint_2, uint uint_3)
		{
			if (!this.hashtable_1.ContainsKey(uint_3))
			{
				this.hashtable_1.Add(uint_3, new FriendRequest(uint_1, uint_2, uint_3, Phoenix.GetGame().GetClientManager().GetNameById(uint_3)));
			}
		}
		internal void method_18(uint uint_1, string string_0)
		{
			if (!this.method_9(uint_1, this.uint_0))
			{
				this.method_20(6, uint_1);
			}
			else
			{
				GameClient @class = Phoenix.GetGame().GetClientManager().method_2(uint_1);
				if (@class == null || @class.GetHabbo().method_21() == null)
				{
					this.method_20(5, uint_1);
				}
				else
				{
					if (this.method_25().GetHabbo().bool_3)
					{
						this.method_20(4, uint_1);
					}
					else
					{
						if (@class.GetHabbo().bool_3)
						{
							this.method_20(3, uint_1);
						}
						if (this.method_25().GetHabbo().method_4() > 0)
						{
							TimeSpan timeSpan = DateTime.Now - this.method_25().GetHabbo().dateTime_0;
							if (timeSpan.Seconds > 4)
							{
								this.method_25().GetHabbo().int_23 = 0;
							}
							if (timeSpan.Seconds < 4 && this.method_25().GetHabbo().int_23 > 5)
							{
								this.method_20(4, uint_1);
								return;
							}
							this.method_25().GetHabbo().dateTime_0 = DateTime.Now;
							this.method_25().GetHabbo().int_23++;
						}
						string_0 = ChatCommandHandler.smethod_4(string_0);
						if (Config.Boolean_4 && !this.method_25().GetHabbo().bool_0)
						{
							using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
							{
								class2.AddParamWithValue("message", "<PM to " + @class.GetHabbo().Username + ">: " + string_0);
								class2.ExecuteQuery(string.Concat(new object[]
								{
									"INSERT INTO chatlogs (user_id,room_id,hour,minute,timestamp,message,user_name,full_date) VALUES ('",
									this.method_25().GetHabbo().Id,
									"','0','",
									DateTime.Now.Hour,
									"','",
									DateTime.Now.Minute,
									"',UNIX_TIMESTAMP(),@message,'",
									this.method_25().GetHabbo().Username,
									"','",
									DateTime.Now.ToLongDateString(),
									"')"
								}));
							}
						}
						@class.GetHabbo().method_21().method_19(string_0, this.uint_0);
					}
				}
			}
		}
		internal void method_19(string string_0, uint uint_1)
		{
			ServerMessage gClass = new ServerMessage(134u);
			gClass.AppendUInt(uint_1);
			gClass.AppendString(string_0);
			this.method_25().method_14(gClass);
		}
		internal void method_20(int int_0, uint uint_1)
		{
			ServerMessage gClass = new ServerMessage(261u);
			gClass.AppendInt32(int_0);
			gClass.AppendUInt(uint_1);
			this.method_25().method_14(gClass);
		}
		internal ServerMessage method_21()
		{
			ServerMessage gClass = new ServerMessage(12u);
			gClass.AppendInt32(6000);
			gClass.AppendInt32(200);
			gClass.AppendInt32(6000);
			gClass.AppendInt32(900);
			gClass.AppendBoolean(false);
			gClass.AppendInt32(this.hashtable_0.Count);
			Hashtable hashtable = this.hashtable_0.Clone() as Hashtable;
			foreach (Class104 @class in hashtable.Values)
			{
				@class.method_0(gClass, false);
			}
			return gClass;
		}
		internal ServerMessage method_22()
		{
			List<Class104> list = new List<Class104>();
			int num = 0;
			Hashtable hashtable = this.hashtable_0.Clone() as Hashtable;
			foreach (Class104 @class in hashtable.Values)
			{
				if (@class.bool_0)
				{
					num++;
					list.Add(@class);
					@class.bool_0 = false;
				}
			}
			hashtable.Clear();
			ServerMessage gClass = new ServerMessage(13u);
			gClass.AppendInt32(0);
			gClass.AppendInt32(num);
			gClass.AppendInt32(0);
			foreach (Class104 @class in list)
			{
				@class.method_0(gClass, false);
				gClass.AppendBoolean(false);
			}
			return gClass;
		}
		internal ServerMessage method_23()
		{
			ServerMessage gClass = new ServerMessage(314u);
			gClass.AppendInt32(this.hashtable_1.Count);
			gClass.AppendInt32(this.hashtable_1.Count);
			Hashtable hashtable = this.hashtable_1.Clone() as Hashtable;
			foreach (FriendRequest @class in hashtable.Values)
			{
				@class.method_0(gClass);
			}
			return gClass;
		}
		internal ServerMessage method_24(string string_0)
		{
			DataTable dataTable = null;
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				@class.AddParamWithValue("query", string_0 + "%");
				dataTable = @class.ReadDataTable("SELECT id FROM users WHERE username LIKE @query LIMIT 50");
			}
			List<DataRow> list = new List<DataRow>();
			List<DataRow> list2 = new List<DataRow>();
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					if (this.method_9(this.uint_0, (uint)dataRow["id"]))
					{
						list.Add(dataRow);
					}
					else
					{
						list2.Add(dataRow);
					}
				}
			}
			ServerMessage gClass = new ServerMessage(435u);
			gClass.AppendInt32(list.Count);
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				foreach (DataRow dataRow in list)
				{
					uint num = (uint)dataRow["id"];
					DataRow dataRow2 = @class.ReadDataRow("SELECT username,motto,look,last_online FROM users WHERE id = '" + num + "' LIMIT 1");
					new Class104(num, dataRow2["username"] as string, dataRow2["look"] as string, dataRow2["motto"] as string, dataRow2["last_online"] as string).method_0(gClass, true);
				}
				gClass.AppendInt32(list2.Count);
				foreach (DataRow dataRow in list2)
				{
					uint num = (uint)dataRow["id"];
					DataRow dataRow2 = @class.ReadDataRow("SELECT username,motto,look,last_online FROM users WHERE id = '" + num + "' LIMIT 1");
					new Class104(num, dataRow2["username"] as string, dataRow2["look"] as string, dataRow2["motto"] as string, dataRow2["last_online"] as string).method_0(gClass, true);
				}
			}
			return gClass;
		}
		private GameClient method_25()
		{
			return Phoenix.GetGame().GetClientManager().method_2(this.uint_0);
		}
		internal Hashtable method_26()
		{
			return this.hashtable_0.Clone() as Hashtable;
		}
	}
}
