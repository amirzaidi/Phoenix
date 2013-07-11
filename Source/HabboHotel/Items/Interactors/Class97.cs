using System;
using System.Collections.Generic;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Items;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.HabboHotel.Items.Interactors
{
	internal sealed class Class97 : Class69
	{
		public override void OnPlace(GameClient class16_0, UserItemData class63_0)
		{
		}
		public override void OnRemove(GameClient class16_0, UserItemData class63_0)
		{
		}
		public override void OnTrigger(GameClient class16_0, UserItemData class63_0, int int_0, bool bool_0)
		{
			if (class63_0.GetBaseItem().list_0.Count > 1)
			{
				Dictionary<int, Coordinates> dictionary = class63_0.method_8().method_94(class63_0.GetBaseItem().int_2, class63_0.GetBaseItem().int_1, class63_0.Int32_0, class63_0.Int32_1, class63_0.int_3);
				class63_0.method_8().method_22();
				class63_0.method_8().method_87(class63_0.method_8().method_43(class63_0.Int32_0, class63_0.Int32_1), true, true);
				foreach (Coordinates current in dictionary.Values)
				{
					class63_0.method_8().method_87(class63_0.method_8().method_43(current.X, current.Y), true, true);
				}
			}
			if (class16_0 != null)
			{
				Class33 class33_ = class16_0.GetHabbo().Class14_0.method_53(class16_0.GetHabbo().Id);
				class63_0.method_8().method_10(class33_, class63_0);
			}
		}
	}
}
