using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Messages;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Navigator
{
	internal sealed class AddFavouriteRoomMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			uint num = class18_0.PopWiredUInt();
            RoomData @class = Phoenix.GetGame().GetRoomManager().method_12(num);
			if (@class == null || class16_0.GetHabbo().list_1.Count >= 30 || class16_0.GetHabbo().list_1.Contains(num) || @class.Type == "public")
			{
				ServerMessage gClass = new ServerMessage(33u);
				gClass.AppendInt32(-9001);
				class16_0.method_14(gClass);
			}
			else
			{
				ServerMessage gClass2 = new ServerMessage(459u);
				gClass2.AppendUInt(num);
				gClass2.AppendBoolean(true);
				class16_0.method_14(gClass2);
				class16_0.GetHabbo().list_1.Add(num);
				using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
				{
					class2.ExecuteQuery(string.Concat(new object[]
					{
						"INSERT INTO user_favorites (user_id,room_id) VALUES ('",
						class16_0.GetHabbo().Id,
						"','",
						num,
						"')"
					}));
				}
			}
		}
	}
}
