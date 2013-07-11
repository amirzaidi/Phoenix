using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Navigator
{
	internal sealed class GetPublicSpaceCastLibsMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			uint num = class18_0.PopWiredUInt();
			class18_0.PopFixedString();
			class18_0.PopWiredInt32();
            RoomData @class = Phoenix.GetGame().GetRoomManager().method_12(num);
			if (@class != null)
			{
				if (@class.Type == "private")
				{
					ServerMessage gClass = new ServerMessage(286u);
					gClass.AppendBoolean(@class.IsPublicRoom);
					gClass.AppendUInt(num);
					class16_0.method_14(gClass);
				}
				else
				{
					ServerMessage gClass2 = new ServerMessage(453u);
					gClass2.AppendUInt(@class.Id);
					gClass2.AppendStringWithBreak(@class.CCTs);
					gClass2.AppendUInt(@class.Id);
					class16_0.method_14(gClass2);
				}
			}
		}
	}
}
