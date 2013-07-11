using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Items;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Wired
{
	internal sealed class UpdateTriggerMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			UserItemData class2 = @class.method_28(class18_0.PopWiredUInt());
			if (@class != null && class2 != null)
			{
				string text = class2.GetBaseItem().InteractionType.ToLower();
				if (text != null)
				{
					if (!(text == "wf_trg_onsay"))
					{
						if (!(text == "wf_trg_enterroom"))
						{
							if (!(text == "wf_trg_timer"))
							{
								if (!(text == "wf_trg_attime"))
								{
									if (text == "wf_trg_atscore")
									{
										class18_0.PopWiredBoolean();
										string text2 = class18_0.ToString().Substring(class18_0.Length - (class18_0.RemainingLength - 2));
										string[] array = text2.Split(new char[]
										{
											'@'
										});
										class2.string_3 = array[0];
										class2.string_2 = Convert.ToString(class18_0.PopWiredInt32());
									}
								}
								else
								{
									class18_0.PopWiredBoolean();
									string text2 = class18_0.ToString().Substring(class18_0.Length - (class18_0.RemainingLength - 2));
									string[] array = text2.Split(new char[]
									{
										'@'
									});
									class2.string_3 = array[0];
									class2.string_2 = Convert.ToString(Convert.ToString((double)class18_0.PopWiredInt32() * 0.5));
								}
							}
							else
							{
								class18_0.PopWiredBoolean();
								string text2 = class18_0.ToString().Substring(class18_0.Length - (class18_0.RemainingLength - 2));
								string[] array = text2.Split(new char[]
								{
									'@'
								});
								class2.string_3 = array[0];
								class2.string_2 = Convert.ToString(Convert.ToString((double)class18_0.PopWiredInt32() * 0.5));
							}
						}
						else
						{
							class18_0.PopWiredBoolean();
							string text3 = class18_0.PopFixedString();
							class2.string_2 = text3;
						}
					}
					else
					{
						class18_0.PopWiredBoolean();
						bool value = class18_0.PopWiredBoolean();
						string text3 = class18_0.PopFixedString();
						text3 = Phoenix.smethod_8(text3, false, true);
						if (text3.Length > 100)
						{
							text3 = text3.Substring(0, 100);
						}
						class2.string_2 = text3;
						class2.string_3 = Convert.ToString(value);
					}
				}
				class2.method_5(true, false);
			}
		}
	}
}
