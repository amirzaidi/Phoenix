using System;
using System.Collections.Generic;
using System.Data;
using Phoenix.Core;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Quests;
using Phoenix.Messages;
using Phoenix.Storage;
namespace Phoenix.HabboHotel.Quests
{
	internal sealed class QuestManager
	{
		public List<Quest> Quests;
		public QuestManager()
		{
			this.Quests = new List<Quest>();
		}
		public void method_0()
		{
            Logging.Write("Loading Quests..");
			this.Quests.Clear();
			DataTable dataTable = null;
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				dataTable = @class.ReadDataTable("SELECT id,type,action,needofcount,level_num,pixel_reward FROM quests WHERE enabled = '1' ORDER by level_num");
			}
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					Quest class2 = new Quest((uint)dataRow["id"], (string)dataRow["type"], (string)dataRow["action"], (int)dataRow["needofcount"], (int)dataRow["level_num"], (int)dataRow["pixel_reward"]);
					if (class2 != null)
					{
						this.Quests.Add(class2);
					}
				}
				Logging.WriteLine("completed!");
			}
		}
		public void method_1(uint uint_0, GameClient class16_0)
		{
			class16_0.GetHabbo().CurrentQuestProgress++;
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				@class.ExecuteQuery("UPDATE user_stats SET quest_progress = quest_progress + 1 WHERE id = '" + class16_0.GetHabbo().Id + "' LIMIT 1");
			}
			Phoenix.GetGame().GetQuestManager().method_7(uint_0, class16_0);
		}
		public int GetHighestLevelForType(string string_0)
		{
			int num = 0;
			foreach (Quest current in this.Quests)
			{
				if (current.Type == string_0)
				{
					num++;
				}
			}
			return num;
		}
		public uint method_3(int int_0, string string_0)
		{
			uint result;
			foreach (Quest current in this.Quests)
			{
				if (current.Type == string_0 && current.Level == int_0 + 1)
				{
					result = current.QuestId();
					return result;
				}
			}
			result = 0u;
			return result;
		}
		public void method_4(GameClient class16_0)
		{
			Quest @class = this.method_6(class16_0.GetHabbo().uint_7);
			string text = @class.Type.ToLower();
			int int_ = 0;
			string text2 = text;
			if (text2 != null)
			{
				if (!(text2 == "social"))
				{
					if (!(text2 == "room_builder"))
					{
						if (!(text2 == "identity"))
						{
							if (text2 == "explore")
							{
								int_ = class16_0.GetHabbo().int_9;
							}
						}
						else
						{
							int_ = class16_0.GetHabbo().int_8;
						}
					}
					else
					{
						int_ = class16_0.GetHabbo().int_6;
					}
				}
				else
				{
					int_ = class16_0.GetHabbo().int_7;
				}
			}
			if (this.method_3(int_, text) != 0u)
			{
				this.method_7(this.method_3(int_, text), class16_0);
			}
		}
		public ServerMessage method_5(GameClient class16_0)
		{
			ServerMessage gClass = new ServerMessage(800u);
			gClass.AppendInt32(4);
			this.method_9(class16_0, gClass);
			gClass.AppendInt32(1);
			return gClass;
		}
		public Quest method_6(uint uint_0)
		{
			Quest result;
			foreach (Quest current in this.Quests)
			{
				if (current.QuestId() == uint_0)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}
		public void method_7(uint uint_0, GameClient class16_0)
		{
			if (class16_0 != null)
			{
				if (class16_0.GetHabbo().CurrentQuestId != uint_0)
				{
					class16_0.GetHabbo().CurrentQuestId = uint_0;
					class16_0.GetHabbo().CurrentQuestProgress = 0;
					using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
					{
						@class.AddParamWithValue("uid", class16_0.GetHabbo().Id);
						@class.AddParamWithValue("qid", uint_0);
						@class.ExecuteQuery("UPDATE user_stats SET quest_id = @qid, quest_progress = '0' WHERE id = @uid LIMIT 1");
					}
				}
				if (uint_0 == 0u)
				{
					class16_0.method_14(this.method_5(class16_0));
					ServerMessage gclass5_ = new ServerMessage(803u);
					class16_0.method_14(gclass5_);
				}
				else
				{
					Quest class2 = this.method_6(uint_0);
					if (class2.NeedForLevel <= class16_0.GetHabbo().CurrentQuestProgress)
					{
						this.method_8(uint_0, class16_0);
					}
					else
					{
						ServerMessage gclass5_ = new ServerMessage(802u);
						class2.Serialize(gclass5_, class16_0, true);
						class16_0.method_14(gclass5_);
					}
				}
			}
		}
		public void method_8(uint uint_0, GameClient class16_0)
		{
			class16_0.GetHabbo().CurrentQuestId = 0u;
			class16_0.GetHabbo().uint_7 = uint_0;
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				@class.AddParamWithValue("userid", class16_0.GetHabbo().Id);
				@class.AddParamWithValue("questid", uint_0);
				@class.ExecuteQuery(string.Concat(new string[]
				{
					"UPDATE user_stats SET quest_id = '0',quest_progress = '0', lev_",
					this.method_6(uint_0).Type.Replace("room_", ""),
					" = lev_",
					this.method_6(uint_0).Type.Replace("room_", ""),
					" + 1 WHERE id = @userid LIMIT 1"
				}));
				@class.ExecuteQuery("INSERT INTO user_quests (user_id,quest_id) VALUES (@userid,@questid)");
			}
			string text = this.method_6(uint_0).Type.ToLower();
			if (text != null)
			{
				if (!(text == "identity"))
				{
					if (!(text == "room_builder"))
					{
						if (!(text == "social"))
						{
							if (text == "explore")
							{
								class16_0.GetHabbo().int_9++;
							}
						}
						else
						{
							class16_0.GetHabbo().int_7++;
						}
					}
					else
					{
						class16_0.GetHabbo().int_6++;
					}
				}
				else
				{
					class16_0.GetHabbo().int_8++;
				}
			}
			class16_0.GetHabbo().method_25();
			ServerMessage gClass = new ServerMessage(801u);
			Quest class2 = this.method_6(uint_0);
			class2.Serialize(gClass, class16_0, true);
			this.method_9(class16_0, gClass);
			gClass.AppendInt32(1);
			class16_0.method_14(gClass);
			class16_0.GetHabbo().ActivityPoints += class2.PixelReward;
			class16_0.GetHabbo().method_15(true);
			class16_0.GetHabbo().CurrentQuestProgress = 0;
		}
		public void method_9(GameClient class16_0, ServerMessage gclass5_0)
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			foreach (Quest current in this.Quests)
			{
				if (current.QuestId() == class16_0.GetHabbo().CurrentQuestId)
				{
					current.Serialize(gclass5_0, class16_0, false);
					string text = current.Type.ToLower();
					if (text != null)
					{
						if (!(text == "social"))
						{
							if (!(text == "room_builder"))
							{
								if (!(text == "identity"))
								{
									if (text == "explore")
									{
										flag4 = true;
									}
								}
								else
								{
									flag3 = true;
								}
							}
							else
							{
								flag2 = true;
							}
						}
						else
						{
							flag = true;
						}
					}
				}
				if (current.Type.ToLower() == "room_builder" && num2 < class16_0.GetHabbo().int_6)
				{
					num2 = current.Level;
				}
				if (current.Type.ToLower() == "social" && num < class16_0.GetHabbo().int_7)
				{
					num = current.Level;
				}
				if (current.Type.ToLower() == "identity" && num3 < class16_0.GetHabbo().int_8)
				{
					num3 = current.Level;
				}
				if (current.Type.ToLower() == "explore" && num4 < class16_0.GetHabbo().int_9)
				{
					num4 = current.Level;
				}
				if (current.Type.ToLower() == "room_builder" && !flag2 && current.Level == this.GetHighestLevelForType("room_builder") && class16_0.GetHabbo().int_6 == this.GetHighestLevelForType("room_builder"))
				{
					current.Serialize(gclass5_0, class16_0, false);
					flag2 = true;
				}
				if (current.Type.ToLower() == "social" && !flag && current.Level == this.GetHighestLevelForType("social") && class16_0.GetHabbo().int_7 == this.GetHighestLevelForType("room_social"))
				{
					current.Serialize(gclass5_0, class16_0, false);
					flag = true;
				}
				if (current.Type.ToLower() == "identity" && !flag3 && current.Level == this.GetHighestLevelForType("identity") && class16_0.GetHabbo().int_8 == this.GetHighestLevelForType("identity"))
				{
					current.Serialize(gclass5_0, class16_0, false);
					flag3 = true;
				}
				if (current.Type.ToLower() == "explore" && !flag4 && current.Level == this.GetHighestLevelForType("explore") && class16_0.GetHabbo().int_9 == this.GetHighestLevelForType("explore"))
				{
					current.Serialize(gclass5_0, class16_0, false);
					flag4 = true;
				}
				if (current.Type.ToLower() == "room_builder" && !flag2 && current.Level == class16_0.GetHabbo().int_6 + 1)
				{
					current.Serialize(gclass5_0, class16_0, false);
					flag2 = true;
				}
				if (current.Type.ToLower() == "social" && !flag && current.Level == class16_0.GetHabbo().int_7 + 1)
				{
					current.Serialize(gclass5_0, class16_0, false);
					flag = true;
				}
				if (current.Type.ToLower() == "identity" && !flag3 && current.Level == class16_0.GetHabbo().int_8 + 1)
				{
					current.Serialize(gclass5_0, class16_0, false);
					flag3 = true;
				}
				if (current.Type.ToLower() == "explore" && !flag4 && current.Level == class16_0.GetHabbo().int_9 + 1)
				{
					current.Serialize(gclass5_0, class16_0, false);
					flag4 = true;
				}
			}
			if (!flag2 || !flag || !flag3 || !flag4)
			{
				foreach (Quest current in this.Quests)
				{
					if (current.Type.ToLower() == "room_builder" && !flag2 && current.Level == num2)
					{
						current.Serialize(gclass5_0, class16_0, false);
						flag2 = true;
					}
					if (current.Type.ToLower() == "social" && !flag && current.Level == num)
					{
						current.Serialize(gclass5_0, class16_0, false);
						flag = true;
					}
					if (current.Type.ToLower() == "identity" && !flag3 && current.Level == num3)
					{
						current.Serialize(gclass5_0, class16_0, false);
						flag3 = true;
					}
					if (current.Type.ToLower() == "explore" && !flag4 && current.Level == num4)
					{
						current.Serialize(gclass5_0, class16_0, false);
						flag4 = true;
					}
				}
			}
		}
	}
}
