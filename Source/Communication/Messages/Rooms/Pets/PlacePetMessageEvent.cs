using System;
using System.Collections.Generic;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Pets;
using Phoenix.Util;
using Phoenix.Messages;
using Phoenix.HabboHotel.RoomBots;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Pets
{
	internal sealed class PlacePetMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && (@class.AllowPet || @class.method_27(class16_0, true)))
			{
				uint uint_ = class18_0.PopWiredUInt();
				Pet class2 = class16_0.GetHabbo().method_23().method_4(uint_);
				if (class2 != null && !class2.PlacedInRoom)
				{
					int num = class18_0.PopWiredInt32();
					int num2 = class18_0.PopWiredInt32();
					if (@class.method_30(num, num2, 0.0, true, false))
					{
						if (@class.Int32_2 >= Config.int_2)
						{
							class16_0.SendNotif(PhoenixEnvironment.GetExternalText("error_maxpets") + Config.int_2);
						}
						else
						{
							class2.PlacedInRoom = true;
							class2.RoomId = @class.Id;
							List<Class36> list = new List<Class36>();
							List<Class35> list2 = new List<Class35>();
							@class.method_4(new Class34(class2.PetId, class2.RoomId, Enum2.const_0, "freeroam", class2.Name, "", class2.Look, num, num2, 0, 0, 0, 0, 0, 0, ref list, ref list2, 0), class2);
							if (@class.method_27(class16_0, true))
							{
								class16_0.GetHabbo().method_23().method_6(class2.PetId, @class.Id);
							}
						}
					}
				}
			}
		}
	}
}
