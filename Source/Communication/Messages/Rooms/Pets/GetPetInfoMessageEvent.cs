using System;
using System.Data;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Rooms.Pets
{
	internal sealed class GetPetInfoMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			uint num = class18_0.PopWiredUInt();
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && !@class.Boolean_3)
			{
				Class33 class2 = @class.method_48(num);
				if (class2 == null || class2.class15_0 == null)
				{
					DataRow dataRow = null;
					using (DatabaseClient class3 = Phoenix.GetDatabase().GetClient())
					{
						class3.AddParamWithValue("petid", num);
						dataRow = class3.ReadDataRow("SELECT id, user_id, room_id, name, type, race, color, expirience, energy, nutrition, respect, createstamp, x, y, z FROM user_pets WHERE id = @petid LIMIT 1");
					}
					if (dataRow != null)
					{
						class16_0.method_14(Phoenix.GetGame().GetCatalog().method_12(dataRow).SerializeInfo());
					}
				}
				else
				{
					class16_0.method_14(class2.class15_0.SerializeInfo());
				}
			}
		}
	}
}
