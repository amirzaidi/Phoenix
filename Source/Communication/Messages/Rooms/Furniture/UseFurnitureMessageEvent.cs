using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Items;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Furniture
{
	internal sealed class UseFurnitureMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			try
			{
				Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
				if (@class != null)
				{
					UserItemData class2 = @class.method_28(class18_0.PopWiredUInt());
					if (class2 != null)
					{
						bool bool_ = false;
						if (@class.method_26(class16_0))
						{
							bool_ = true;
						}
						class2.Class69_0.OnTrigger(class16_0, class2, class18_0.PopWiredInt32(), bool_);
						if (class16_0.GetHabbo().CurrentQuestId == 12u)
						{
							Phoenix.GetGame().GetQuestManager().method_1(12u, class16_0);
						}
						else
						{
							if (class16_0.GetHabbo().CurrentQuestId == 18u && class2.GetBaseItem().string_1 == "bw_lgchair")
							{
								Phoenix.GetGame().GetQuestManager().method_1(18u, class16_0);
							}
							else
							{
								if (class16_0.GetHabbo().CurrentQuestId == 20u && class2.GetBaseItem().string_1.Contains("bw_sboard"))
								{
									Phoenix.GetGame().GetQuestManager().method_1(20u, class16_0);
								}
								else
								{
									if (class16_0.GetHabbo().CurrentQuestId == 21u && class2.GetBaseItem().string_1.Contains("bw_van"))
									{
										Phoenix.GetGame().GetQuestManager().method_1(21u, class16_0);
									}
									else
									{
										if (class16_0.GetHabbo().CurrentQuestId == 22u && class2.GetBaseItem().string_1.Contains("party_floor"))
										{
											Phoenix.GetGame().GetQuestManager().method_1(22u, class16_0);
										}
										else
										{
											if (class16_0.GetHabbo().CurrentQuestId == 23u && class2.GetBaseItem().string_1.Contains("party_ball"))
											{
												Phoenix.GetGame().GetQuestManager().method_1(23u, class16_0);
											}
											else
											{
												if (class16_0.GetHabbo().CurrentQuestId == 24u && class2.GetBaseItem().string_1.Contains("jukebox"))
												{
													Phoenix.GetGame().GetQuestManager().method_1(24u, class16_0);
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
			catch
			{
			}
		}
	}
}
