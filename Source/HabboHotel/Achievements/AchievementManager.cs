using System;
using System.Collections.Generic;
using System.Data;
using Phoenix.Core;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Users.Badges;
using Phoenix.Storage;
namespace Phoenix.HabboHotel.Achievements
{
	internal sealed class AchievementManager
	{
		public static Dictionary<uint, Achievement> dictionary_0;
		public static Dictionary<string, uint> dictionary_1;
		public AchievementManager()
		{
			AchievementManager.dictionary_0 = new Dictionary<uint, Achievement>();
			AchievementManager.dictionary_1 = new Dictionary<string, uint>();
		}
		public static void smethod_0(DatabaseClient class6_0)
		{
            Logging.Write("Loading Achievements..");
			AchievementManager.dictionary_0.Clear();
			DataTable dataTable = class6_0.ReadDataTable("SELECT * FROM achievements");
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					AchievementManager.dictionary_0.Add((uint)dataRow["id"], new Achievement((uint)dataRow["id"], (string)dataRow["type"], (int)dataRow["levels"], (string)dataRow["badge"], (int)dataRow["pixels_base"], (double)dataRow["pixels_multiplier"], Phoenix.smethod_3(dataRow["dynamic_badgelevel"].ToString()), (int)dataRow["score_base"]));
				}
				AchievementManager.dictionary_1.Clear();
				dataTable = class6_0.ReadDataTable("SELECT * FROM badges");
				if (dataTable != null)
				{
					foreach (DataRow dataRow in dataTable.Rows)
					{
						AchievementManager.dictionary_1.Add((string)dataRow["badge"], (uint)dataRow["id"]);
					}
					Logging.WriteLine("completed!");
				}
			}
		}
		public uint method_0(string string_0)
		{
			if (AchievementManager.dictionary_1.ContainsKey(string_0))
			{
				return AchievementManager.dictionary_1[string_0];
			}
			else
			{
                return 0;
			}
		}
		public bool method_1(GameClient class16_0, uint uint_0, int int_0)
		{
			return class16_0.GetHabbo().dictionary_0.ContainsKey(uint_0) && class16_0.GetHabbo().dictionary_0[uint_0] >= int_0;
		}
		public static ServerMessage smethod_1(GameClient class16_0)
		{
			int num = AchievementManager.dictionary_0.Count;
			foreach (KeyValuePair<uint, Achievement> current in AchievementManager.dictionary_0)
			{
				if (current.Value.Type == "hidden")
				{
					num--;
				}
			}
			ServerMessage gClass = new ServerMessage(436u);
			gClass.AppendInt32(num);
			foreach (KeyValuePair<uint, Achievement> current in AchievementManager.dictionary_0)
			{
				if (!(current.Value.Type == "hidden"))
				{
					int num2 = 0;
					int num3 = 1;
					if (class16_0.GetHabbo().dictionary_0.ContainsKey(current.Value.Id))
					{
						num2 = class16_0.GetHabbo().dictionary_0[current.Value.Id];
					}
					if (current.Value.Levels > 1 && num2 > 0)
					{
						num3 = num2 + 1;
					}
					if (num3 > current.Value.Levels)
					{
						num3 = current.Value.Levels;
					}
					gClass.AppendUInt(current.Value.Id);
					gClass.AppendInt32(num3);
					gClass.AppendStringWithBreak(AchievementManager.smethod_3(current.Value.BadgeCode, num3, current.Value.DynamicBadgeLevel));
					gClass.AppendInt32(1);
					gClass.AppendInt32(0);
					gClass.AppendInt32(0);
					gClass.AppendInt32(0);
					gClass.AppendBoolean(num2 == current.Value.Levels);
					gClass.AppendStringWithBreak(current.Value.Type);
					gClass.AppendInt32(current.Value.Levels);
				}
			}
			return gClass;
		}
		public void method_2(GameClient class16_0, uint uint_0)
		{
			if (!AchievementManager.dictionary_0.ContainsKey(uint_0))
			{
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine("AchievementID: " + uint_0 + " does not exist in your database!");
				Console.ForegroundColor = ConsoleColor.White;
			}
			else
			{
				Achievement @class = AchievementManager.dictionary_0[uint_0];
				if (@class != null)
				{
					if (class16_0.GetHabbo().dictionary_0.ContainsKey(uint_0))
					{
						this.method_3(class16_0, uint_0, class16_0.GetHabbo().dictionary_0[uint_0 + 1u]);
					}
					else
					{
						this.method_3(class16_0, uint_0, 1);
					}
				}
			}
		}
		public void method_3(GameClient class16_0, uint uint_0, int int_0)
		{
			if (!AchievementManager.dictionary_0.ContainsKey(uint_0))
			{
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine("AchievementID: " + uint_0 + " does not exist in our database!");
				Console.ForegroundColor = ConsoleColor.White;
			}
			else
			{
				Achievement @class = AchievementManager.dictionary_0[uint_0];
				if (@class != null && !this.method_1(class16_0, @class.Id, int_0) && int_0 >= 1 && int_0 <= @class.Levels)
				{
					int num = AchievementManager.smethod_2(@class.Dynamic_badgelevel, @class.PixelMultiplier, int_0);
					int num2 = AchievementManager.smethod_2(@class.ScoreBase, @class.PixelMultiplier, int_0);
					using (TimedLock.Lock(class16_0.GetHabbo().method_22().List_0))
					{
						List<string> list = new List<string>();
						foreach (UserBadge current in class16_0.GetHabbo().method_22().List_0)
						{
							if (current.Code.StartsWith(@class.BadgeCode))
							{
								list.Add(current.Code);
							}
						}
						foreach (string current2 in list)
						{
							class16_0.GetHabbo().method_22().method_6(current2);
						}
					}
					class16_0.GetHabbo().method_22().method_2(class16_0, AchievementManager.smethod_3(@class.BadgeCode, int_0, @class.DynamicBadgeLevel), true);
					if (class16_0.GetHabbo().dictionary_0.ContainsKey(@class.Id))
					{
						class16_0.GetHabbo().dictionary_0[@class.Id] = int_0;
						using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
						{
							class2.ExecuteQuery(string.Concat(new object[]
							{
								"UPDATE user_achievements SET achievement_level = '",
								int_0,
								"' WHERE user_id = '",
								class16_0.GetHabbo().Id,
								"' AND achievement_id = '",
								@class.Id,
								"' LIMIT 1; UPDATE user_stats SET AchievementScore = AchievementScore + ",
								num2,
								" WHERE id = '",
								class16_0.GetHabbo().Id,
								"' LIMIT 1; "
							}));
							goto IL_346;
						}
					}
					class16_0.GetHabbo().dictionary_0.Add(@class.Id, int_0);
					using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
					{
						class2.ExecuteQuery(string.Concat(new object[]
						{
							"INSERT INTO user_achievements (user_id,achievement_id,achievement_level) VALUES ('",
							class16_0.GetHabbo().Id,
							"','",
							@class.Id,
							"','",
							int_0,
							"'); UPDATE user_stats SET AchievementScore = AchievementScore + ",
							num2,
							" WHERE id = '",
							class16_0.GetHabbo().Id,
							"' LIMIT 1; "
						}));
					}
					IL_346:
					ServerMessage gClass = new ServerMessage(437u);
					gClass.AppendUInt(@class.Id);
					gClass.AppendInt32(int_0);
					gClass.AppendInt32(1337);
					gClass.AppendStringWithBreak(AchievementManager.smethod_3(@class.BadgeCode, int_0, @class.DynamicBadgeLevel));
					gClass.AppendInt32(num2);
					gClass.AppendInt32(num);
					gClass.AppendInt32(0);
					gClass.AppendInt32(0);
					gClass.AppendInt32(0);
					if (int_0 > 1)
					{
						gClass.AppendStringWithBreak(AchievementManager.smethod_3(@class.BadgeCode, int_0 - 1, @class.DynamicBadgeLevel));
					}
					else
					{
						gClass.AppendStringWithBreak("");
					}
					gClass.AppendStringWithBreak(@class.Type);
					class16_0.method_14(gClass);
					class16_0.GetHabbo().int_13 += num2;
					class16_0.GetHabbo().ActivityPoints += num;
					class16_0.GetHabbo().method_16(num);
				}
			}
		}
		public static int smethod_2(int int_0, double double_0, int int_1)
		{
			return (int)((double)int_0 * ((double)int_1 * double_0));
		}
		public static string smethod_3(string string_0, int int_0, bool bool_0)
		{
			if (!bool_0)
			{
				return string_0;
			}
			else
			{
				return string_0 + int_0;
			}
		}
	}
}
