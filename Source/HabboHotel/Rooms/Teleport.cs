using System;
using Phoenix.Messages;
using Phoenix.HabboHotel.Users;
namespace Phoenix.HabboHotel.Rooms
{
	internal sealed class Teleport
	{
		private uint uint_0;
		private uint uint_1;
		private GameClientMessageHandler class17_0;
		private Habbo class11_0;
		public Teleport(GameClientMessageHandler pHandler, Habbo pUserRefference, uint RoomId, uint TeleId)
		{
			this.class17_0 = pHandler;
			this.class11_0 = pUserRefference;
			this.uint_0 = RoomId;
			this.uint_1 = TeleId;
		}
		public void method_0()
		{
			if (this.class17_0 != null && this.class11_0 != null)
			{
				this.class11_0.bool_7 = true;
				this.class11_0.uint_5 = this.uint_1;
				this.class17_0.method_5(this.uint_0, "");
			}
		}
	}
}
