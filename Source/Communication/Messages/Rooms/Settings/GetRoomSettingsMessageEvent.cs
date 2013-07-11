using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Settings
{
	internal sealed class GetRoomSettingsMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && @class.method_27(class16_0, true))
			{
				ServerMessage gClass = new ServerMessage(465u);
				gClass.AppendUInt(@class.Id);
				gClass.AppendStringWithBreak(@class.Name);
				gClass.AppendStringWithBreak(@class.Description);
				gClass.AppendInt32(@class.State);
				gClass.AppendInt32(@class.Category);
				gClass.AppendInt32(@class.UsersMax);
				gClass.AppendInt32(100);
				gClass.AppendInt32(@class.Tags.Count);
				foreach (string current in @class.Tags)
				{
					gClass.AppendStringWithBreak(current);
				}
				gClass.AppendInt32(@class.list_1.Count);
				foreach (uint current2 in @class.list_1)
				{
					gClass.AppendUInt(current2);
					gClass.AppendStringWithBreak(Phoenix.GetGame().GetClientManager().GetNameById(current2));
				}
				gClass.AppendInt32(@class.list_1.Count);
				gClass.AppendBoolean(@class.AllowPet);
				gClass.AppendBoolean(@class.AllowPetsEating);
				gClass.AppendBoolean(@class.AllowWalkthrough);
				gClass.AppendBoolean(@class.Hidewall);
				gClass.AppendInt32(@class.Wallthick);
				gClass.AppendInt32(@class.Floorthick);
				class16_0.method_14(gClass);
			}
		}
	}
}
