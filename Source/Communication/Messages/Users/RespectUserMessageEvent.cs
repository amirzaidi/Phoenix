using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Users
{
	internal sealed class RespectUserMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && class16_0.GetHabbo().int_21 > 0)
			{
				Class33 class2 = @class.method_53(class18_0.PopWiredUInt());
				if (class2 != null && class2.method_16().GetHabbo().Id != class16_0.GetHabbo().Id && !class2.Boolean_4)
				{
					class16_0.GetHabbo().int_21--;
					class16_0.GetHabbo().RespectGiven++;
					class2.method_16().GetHabbo().Respect++;
					using (DatabaseClient class3 = Phoenix.GetDatabase().GetClient())
					{
						class3.ExecuteQuery("UPDATE user_stats SET Respect = respect + 1 WHERE id = '" + class2.method_16().GetHabbo().Id + "' LIMIT 1");
						class3.ExecuteQuery("UPDATE user_stats SET RespectGiven = RespectGiven + 1 WHERE id = '" + class16_0.GetHabbo().Id + "' LIMIT 1");
						class3.ExecuteQuery("UPDATE user_stats SET dailyrespectpoints = dailyrespectpoints - 1 WHERE id = '" + class16_0.GetHabbo().Id + "' LIMIT 1");
					}
					ServerMessage gClass = new ServerMessage(440u);
					gClass.AppendUInt(class2.method_16().GetHabbo().Id);
					gClass.AppendInt32(class2.method_16().GetHabbo().Respect);
					@class.SendMessage(gClass, null);
					if (class16_0.GetHabbo().RespectGiven == 100)
					{
						Phoenix.GetGame().GetAchievementManager().method_3(class16_0, 8u, 1);
					}
					int int_ = class2.method_16().GetHabbo().Respect;
					if (int_ <= 166)
					{
						if (int_ <= 6)
						{
							if (int_ != 1)
							{
								if (int_ == 6)
								{
									Phoenix.GetGame().GetAchievementManager().method_3(class2.method_16(), 14u, 2);
								}
							}
							else
							{
								Phoenix.GetGame().GetAchievementManager().method_3(class2.method_16(), 14u, 1);
							}
						}
						else
						{
							if (int_ != 16)
							{
								if (int_ != 66)
								{
									if (int_ == 166)
									{
										Phoenix.GetGame().GetAchievementManager().method_3(class2.method_16(), 14u, 5);
									}
								}
								else
								{
									Phoenix.GetGame().GetAchievementManager().method_3(class2.method_16(), 14u, 4);
								}
							}
							else
							{
								Phoenix.GetGame().GetAchievementManager().method_3(class2.method_16(), 14u, 3);
							}
						}
					}
					else
					{
						if (int_ <= 566)
						{
							if (int_ != 366)
							{
								if (int_ == 566)
								{
									Phoenix.GetGame().GetAchievementManager().method_3(class2.method_16(), 14u, 7);
								}
							}
							else
							{
								Phoenix.GetGame().GetAchievementManager().method_3(class2.method_16(), 14u, 6);
							}
						}
						else
						{
							if (int_ != 766)
							{
								if (int_ != 966)
								{
									if (int_ == 1116)
									{
										Phoenix.GetGame().GetAchievementManager().method_3(class2.method_16(), 14u, 10);
									}
								}
								else
								{
									Phoenix.GetGame().GetAchievementManager().method_3(class2.method_16(), 14u, 9);
								}
							}
							else
							{
								Phoenix.GetGame().GetAchievementManager().method_3(class2.method_16(), 14u, 8);
							}
						}
					}
					if (class16_0.GetHabbo().CurrentQuestId == 5u)
					{
						Phoenix.GetGame().GetQuestManager().method_1(5u, class16_0);
					}
				}
			}
		}
	}
}
