using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Pathfinding;
using Phoenix.HabboHotel.Items;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.HabboHotel.Items.Interactors
{
	internal sealed class Class95 : Class69
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
					@class.bool_1 = false;
					@class.bool_0 = true;
				}
				class63_0.uint_3 = 0u;
			}
			if (class63_0.uint_4 != 0u)
			{
				Class33 @class = class63_0.method_8().method_53(class63_0.uint_4);
				if (@class != null)
				{
					@class.method_3(true);
					@class.bool_1 = false;
					@class.bool_0 = true;
				}
				class63_0.uint_4 = 0u;
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
					@class.method_6();
				}
				class63_0.uint_3 = 0u;
			}
			if (class63_0.uint_4 != 0u)
			{
				Class33 @class = class63_0.method_8().method_53(class63_0.uint_4);
				if (@class != null)
				{
					@class.method_6();
				}
				class63_0.uint_4 = 0u;
			}
		}
		public override void OnTrigger(GameClient class16_0, UserItemData class63_0, int int_0, bool bool_0)
		{
			Class33 @class = class63_0.method_8().method_53(class16_0.GetHabbo().Id);
			if (@class != null && @class.class34_1 == null)
			{
				if (ThreeDCoord.smethod_0(@class.GStruct1_0, class63_0.GStruct1_0) || ThreeDCoord.smethod_0(@class.GStruct1_0, class63_0.GStruct1_1))
				{
					if (class63_0.uint_3 == 0u)
					{
						@class.int_19 = -1;
						class63_0.uint_3 = @class.method_16().GetHabbo().Id;
						@class.class63_0 = class63_0;
					}
				}
				else
				{
					if (@class.bool_0)
					{
						try
						{
							@class.method_4(class63_0.GStruct1_1);
						}
						catch
						{
						}
					}
				}
			}
		}
	}
}
