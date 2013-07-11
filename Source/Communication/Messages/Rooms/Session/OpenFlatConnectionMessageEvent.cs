using System;
using Phoenix.Core;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Rooms.Session
{
	internal sealed class OpenFlatConnectionMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			uint num = class18_0.PopWiredUInt();
			string string_ = class18_0.PopFixedString();
			class18_0.PopWiredInt32();
			if (Phoenix.GetConfig().data["emu.messages.roommgr"] == "1")
			{
				Logging.WriteLine("[RoomMgr] Requesting Private Room [ID: " + num + "]");
			}
			class16_0.method_1().method_5(num, string_);
		}
	}
}
