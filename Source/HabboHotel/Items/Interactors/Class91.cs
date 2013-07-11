using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Items;
namespace Phoenix.HabboHotel.Items.Interactors
{
	internal sealed class Class91 : Class69
	{
		public override void OnPlace(GameClient class16_0, UserItemData class63_0)
		{
			class63_0.string_0 = "-1";
		}
		public override void OnRemove(GameClient class16_0, UserItemData class63_0)
		{
			class63_0.string_0 = "-1";
		}
		public override void OnTrigger(GameClient class16_0, UserItemData class63_0, int int_0, bool bool_0)
		{
			if (bool_0 && class63_0.string_0 != "0")
			{
				class63_0.string_0 = "0";
				class63_0.method_5(false, true);
				class63_0.method_3(10);
			}
		}
	}
}
