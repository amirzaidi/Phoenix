using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Pathfinding;
using Phoenix.HabboHotel.Items;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.HabboHotel.Items.Interactors
{
	internal sealed class Class90 : Class69
	{
		public override void OnPlace(GameClient class16_0, UserItemData class63_0)
		{
			class63_0.string_0 = "0";
			if (class63_0.uint_3 != 0u)
			{
				Class33 @class = class63_0.method_8().method_53(class63_0.uint_3);
				if (@class != null)
				{
					@class.method_3(true);
					@class.method_6();
				}
				class63_0.uint_3 = 0u;
			}
		}
		public override void OnRemove(GameClient class16_0, UserItemData class63_0)
		{
			class63_0.string_0 = "0";
			if (class63_0.uint_3 != 0u)
			{
				Class33 @class = class63_0.method_8().method_53(class63_0.uint_3);
				if (@class != null)
				{
					@class.method_3(true);
					@class.method_6();
				}
				class63_0.uint_3 = 0u;
			}
		}
		public override void OnTrigger(GameClient class16_0, UserItemData class63_0, int int_0, bool bool_0)
		{
			Class33 @class = class63_0.method_8().method_53(class16_0.GetHabbo().Id);
			if (@class != null && (class63_0.GStruct1_2.x < class63_0.method_8().Class28_0.int_4 && class63_0.GStruct1_2.y < class63_0.method_8().Class28_0.int_5))
			{
				if (ThreeDCoord.smethod_1(@class.GStruct1_0, class63_0.GStruct1_1) && @class.bool_0)
				{
					@class.method_4(class63_0.GStruct1_1);
				}
				else
				{
					if (class63_0.method_8().method_30(class63_0.GStruct1_2.x, class63_0.GStruct1_2.y, class63_0.Double_0, true, false) && class63_0.uint_3 == 0u)
					{
						class63_0.uint_3 = @class.uint_0;
						@class.bool_0 = false;
						if (@class.bool_6 && (@class.int_10 != class63_0.GStruct1_1.x || @class.int_11 != class63_0.GStruct1_1.y))
						{
							@class.method_3(true);
						}
						@class.bool_1 = true;
						@class.method_4(class63_0.GStruct1_0);
						class63_0.method_3(3);
					}
				}
			}
		}
	}
}
