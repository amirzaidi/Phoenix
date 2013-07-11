using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Navigator
{
	internal sealed class DeleteFavouriteRoomMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			uint num = class18_0.PopWiredUInt();
			class16_0.GetHabbo().list_1.Remove(num);
			ServerMessage gClass = new ServerMessage(459u);
			gClass.AppendUInt(num);
			gClass.AppendBoolean(false);
			class16_0.method_14(gClass);
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				@class.ExecuteQuery(string.Concat(new object[]
				{
					"DELETE FROM user_favorites WHERE user_id = '",
					class16_0.GetHabbo().Id,
					"' AND room_id = '",
					num,
					"' LIMIT 1"
				}));
			}
		}
	}
}
