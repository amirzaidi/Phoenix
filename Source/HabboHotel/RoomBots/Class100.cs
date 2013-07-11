using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.HabboHotel.RoomBots
{
	internal sealed class Class100 : Class99
	{
		private int int_2;
		private int int_3;
		public Class100(int int_4)
		{
			this.int_2 = new Random((int_4 ^ 2) + DateTime.Now.Millisecond).Next(10, 250);
			this.int_3 = new Random((int_4 ^ 2) + DateTime.Now.Millisecond).Next(10, 30);
		}
		public override void OnSelfEnterRoom()
		{
		}
		public override void OnSelfLeaveRoom(bool bool_0)
		{
		}
		public override void OnUserEnterRoom(Class33 class33_0)
		{
		}
		public override void OnUserLeaveRoom(GameClient class16_0)
		{
		}
		public override void OnUserSay(Class33 class33_0, string string_0)
		{
		}
		public override void OnUserShout(Class33 class33_0, string string_0)
		{
		}
		public override void OnTimerTick()
		{
			if (this.int_2 <= 0)
			{
				if (base.method_3().list_0.Count > 0)
				{
					Class36 @class = base.method_3().method_3();
					base.method_2().method_1(null, @class.string_0, @class.bool_0);
				}
				this.int_2 = Phoenix.smethod_5(10, 300);
			}
			else
			{
				this.int_2--;
			}
			if (this.int_3 <= 0)
			{
				string text = base.method_3().string_0.ToLower();
				if (text != null && !(text == "stand"))
				{
					if (!(text == "freeroam"))
					{
						if (text == "specified_range")
						{
							int int_ = Phoenix.smethod_5(base.method_3().int_4, base.method_3().int_5);
							int int_2 = Phoenix.smethod_5(base.method_3().int_6, base.method_3().int_7);
							base.method_2().method_5(int_, int_2);
						}
					}
					else
					{
						int int_ = Phoenix.smethod_5(0, base.method_1().Class28_0.int_4);
						int int_2 = Phoenix.smethod_5(0, base.method_1().Class28_0.int_5);
						base.method_2().method_5(int_, int_2);
					}
				}
				this.int_3 = Phoenix.smethod_5(1, 30);
			}
			else
			{
				this.int_3--;
			}
		}
	}
}
