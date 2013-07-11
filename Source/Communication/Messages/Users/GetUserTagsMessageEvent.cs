using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Users
{
	internal sealed class GetUserTagsMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null)
			{
				Class33 class2 = @class.method_53(class18_0.PopWiredUInt());
				if (class2 != null && !class2.Boolean_4)
				{
					ServerMessage gClass = new ServerMessage(350u);
					gClass.AppendUInt(class2.method_16().GetHabbo().Id);
					gClass.AppendInt32(class2.method_16().GetHabbo().list_3.Count);
					using (TimedLock.Lock(class2.method_16().GetHabbo().list_3))
					{
						foreach (string current in class2.method_16().GetHabbo().list_3)
						{
							gClass.AppendStringWithBreak(current);
						}
					}
					class16_0.method_14(gClass);
				}
			}
		}
	}
}
