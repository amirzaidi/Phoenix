using System;
using System.Collections.Generic;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Pathfinding;
using Phoenix.Messages;
using Phoenix.HabboHotel.Items;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.HabboHotel.Items.Interactors
{
	internal sealed class Class71 : Class69
	{
		public override void OnPlace(GameClient class16_0, UserItemData class63_0)
		{
		}
		public override void OnRemove(GameClient class16_0, UserItemData class63_0)
		{
		}
		public override void OnTrigger(GameClient class16_0, UserItemData class63_0, int int_0, bool bool_0)
		{
			Room @class = class63_0.method_8();
			Class33 class2 = @class.method_53(class16_0.GetHabbo().Id);
			if (class2 != null && @class != null)
			{
				ThreeDCoord gstruct1_ = new ThreeDCoord(class63_0.Int32_0 + 1, class63_0.Int32_1);
				ThreeDCoord gstruct1_2 = new ThreeDCoord(class63_0.Int32_0 - 1, class63_0.Int32_1);
				ThreeDCoord gstruct1_3 = new ThreeDCoord(class63_0.Int32_0, class63_0.Int32_1 + 1);
				ThreeDCoord gstruct1_4 = new ThreeDCoord(class63_0.Int32_0, class63_0.Int32_1 - 1);
				if (ThreeDCoord.smethod_1(class2.GStruct1_0, gstruct1_) && ThreeDCoord.smethod_1(class2.GStruct1_0, gstruct1_2) && ThreeDCoord.smethod_1(class2.GStruct1_0, gstruct1_3) && ThreeDCoord.smethod_1(class2.GStruct1_0, gstruct1_4))
				{
					if (class2.bool_0)
					{
						class2.method_4(class63_0.GStruct1_0);
					}
				}
				else
				{
					int num = class63_0.Int32_0;
					int num2 = class63_0.Int32_1;
					if (ThreeDCoord.smethod_0(class2.GStruct1_0, gstruct1_))
					{
						num = class63_0.Int32_0 - 1;
						num2 = class63_0.Int32_1;
					}
					else
					{
						if (ThreeDCoord.smethod_0(class2.GStruct1_0, gstruct1_2))
						{
							num = class63_0.Int32_0 + 1;
							num2 = class63_0.Int32_1;
						}
						else
						{
							if (ThreeDCoord.smethod_0(class2.GStruct1_0, gstruct1_3))
							{
								num = class63_0.Int32_0;
								num2 = class63_0.Int32_1 - 1;
							}
							else
							{
								if (ThreeDCoord.smethod_0(class2.GStruct1_0, gstruct1_4))
								{
									num = class63_0.Int32_0;
									num2 = class63_0.Int32_1 + 1;
								}
							}
						}
					}
					if (@class.method_37(num, num2, true, true, true, true, false))
					{
						List<UserItemData> list_ = new List<UserItemData>();
						list_ = @class.method_93(num, num2);
						double double_ = @class.method_84(num, num2, list_);
						ServerMessage gClass = new ServerMessage(230u);
						gClass.AppendInt32(class63_0.Int32_0);
						gClass.AppendInt32(class63_0.Int32_1);
						gClass.AppendInt32(num);
						gClass.AppendInt32(num2);
						gClass.AppendInt32(1);
						gClass.AppendUInt(class63_0.uint_0);
						gClass.AppendByte(2);
						gClass.AppendStringWithBreak(double_.ToString());
						gClass.AppendString("M");
						@class.SendMessage(gClass, null);
						@class.method_81(class63_0, num, num2, double_);
					}
				}
			}
		}
	}
}
