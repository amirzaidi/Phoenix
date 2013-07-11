using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Items;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.HabboHotel.Items.Interactors
{
	internal sealed class Class93 : Class69
	{
		public override void OnPlace(GameClient class16_0, UserItemData class63_0)
		{
		}
		public override void OnRemove(GameClient class16_0, UserItemData class63_0)
		{
		}
		public override void OnTrigger(GameClient class16_0, UserItemData class63_0, int int_0, bool bool_0)
		{
			Class33 @class = null;
			if (class16_0 != null)
			{
				@class = class63_0.method_8().method_53(class16_0.GetHabbo().Id);
				if (@class == null)
				{
					return;
				}
			}
			if (class16_0 == null || class63_0.method_8().method_99(class63_0.Int32_0, class63_0.Int32_1, @class.int_3, @class.int_4))
			{
				if (class63_0.string_0 != "-1")
				{
					if (int_0 == -1)
					{
						class63_0.string_0 = "0";
						class63_0.method_4();
					}
					else
					{
						class63_0.uint_3 = @class.uint_0;
						class63_0.string_0 = "-1";
						class63_0.method_5(false, true);
						class63_0.method_3(4);
					}
				}
			}
			else
			{
				if (class16_0 != null && @class != null && @class.bool_0)
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
