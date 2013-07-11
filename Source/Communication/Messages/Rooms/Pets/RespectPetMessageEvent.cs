using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Rooms.Pets
{
	internal sealed class RespectPetMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && !@class.Boolean_3)
			{
				uint uint_ = class18_0.PopWiredUInt();
				Class33 class2 = @class.method_48(uint_);
				if (class2 != null && class2.class15_0 != null && class16_0.GetHabbo().int_22 > 0)
				{
					class2.class15_0.OnRespect();
					class16_0.GetHabbo().int_22--;
					using (DatabaseClient class3 = Phoenix.GetDatabase().GetClient())
					{
						class3.AddParamWithValue("userid", class16_0.GetHabbo().Id);
						class3.ExecuteQuery("UPDATE user_stats SET dailypetrespectpoints = dailypetrespectpoints - 1 WHERE id = @userid LIMIT 1");
					}
				}
			}
		}
	}
}
