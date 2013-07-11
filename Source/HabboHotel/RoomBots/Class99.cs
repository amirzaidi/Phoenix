using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Rooms;
using Phoenix.HabboHotel.RoomBots;
namespace Phoenix.HabboHotel.RoomBots
{
	internal abstract class Class99
	{
		public int int_0;
		private int int_1;
		private uint uint_0;
		public Class99()
		{
		}
		public void method_0(int int_2, int int_3, uint uint_1)
		{
			this.int_0 = int_2;
			this.int_1 = int_3;
			this.uint_0 = uint_1;
		}
		public Room method_1()
		{
			return Phoenix.GetGame().GetRoomManager().GetRoom(this.uint_0);
		}
		public Class33 method_2()
		{
			return this.method_1().method_52(this.int_1);
		}
		public Class34 method_3()
		{
			Class33 @class = this.method_2();
			Class34 result;
			if (@class == null)
			{
				result = null;
			}
			else
			{
				result = this.method_2().class34_0;
			}
			return result;
		}
		public abstract void OnSelfEnterRoom();
		public abstract void OnSelfLeaveRoom(bool Kicked);
		public abstract void OnUserEnterRoom(Class33 User);
		public abstract void OnUserLeaveRoom(GameClient Client);
		public abstract void OnUserSay(Class33 User, string Message);
		public abstract void OnUserShout(Class33 User, string Message);
		public abstract void OnTimerTick();
	}
}
