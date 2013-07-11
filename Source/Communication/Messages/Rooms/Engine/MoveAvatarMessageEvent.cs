using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Engine
{
	internal sealed class MoveAvatarMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room class14_ = class16_0.GetHabbo().Class14_0;
			if (class14_ != null)
			{
				Class33 @class = class14_.method_53(class16_0.GetHabbo().Id);
				if (@class != null && @class.bool_0)
				{
					int num = class18_0.PopWiredInt32();
					int num2 = class18_0.PopWiredInt32();
					if (num != @class.int_3 || num2 != @class.int_4)
					{
						if (@class.class33_0 != null)
						{
							try
							{
								if (@class.class33_0.Boolean_4)
								{
									@class.method_0();
								}
								@class.class33_0.method_5(num, num2);
								return;
							}
							catch
							{
								@class.class33_0 = null;
								@class.class34_1 = null;
								@class.method_5(num, num2);
								class16_0.GetHabbo().method_24().method_2(-1, true);
								return;
							}
						}
						if (@class.bool_2)
						{
							@class.int_3 = num;
							@class.int_4 = num2;
							@class.bool_7 = true;
						}
						else
						{
							@class.method_5(num, num2);
						}
					}
				}
			}
		}
	}
}
