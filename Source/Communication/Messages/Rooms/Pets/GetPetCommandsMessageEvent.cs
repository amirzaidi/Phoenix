using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Pets
{
	internal sealed class GetPetCommandsMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			uint num = class18_0.PopWiredUInt();
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			Class33 class2 = @class.method_48(num);
			if (class2 != null && class2.class15_0 != null)
			{
				ServerMessage gClass = new ServerMessage(605u);
				gClass.AppendUInt(num);
				int i = class2.class15_0.Level;
				gClass.AppendInt32(18);
				gClass.AppendInt32(0);
				gClass.AppendInt32(1);
				gClass.AppendInt32(2);
				gClass.AppendInt32(3);
				gClass.AppendInt32(4);
				gClass.AppendInt32(17);
				gClass.AppendInt32(5);
				gClass.AppendInt32(6);
				gClass.AppendInt32(7);
				gClass.AppendInt32(8);
				gClass.AppendInt32(9);
				gClass.AppendInt32(10);
				gClass.AppendInt32(11);
				gClass.AppendInt32(12);
				gClass.AppendInt32(13);
				gClass.AppendInt32(14);
				gClass.AppendInt32(15);
				gClass.AppendInt32(16);
				int num2 = 0;
				while (i > num2)
				{
					num2++;
					gClass.AppendInt32(num2);
				}
				gClass.AppendInt32(0);
				gClass.AppendInt32(1);
				gClass.AppendInt32(2);
				class16_0.method_14(gClass);
			}
		}
	}
}
