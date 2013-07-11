using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Catalog
{
	internal sealed class PurchaseFromCatalogEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			int int_ = class18_0.PopWiredInt32();
			uint uint_ = class18_0.PopWiredUInt();
			string string_ = class18_0.PopFixedString();
			if (class16_0.GetHabbo().int_24 > 1)
			{
				int num = 0;
				while (num < class16_0.GetHabbo().int_24 && Phoenix.GetGame().GetCatalog().method_6(class16_0, int_, uint_, string_, false, "", "", num == 0))
				{
					num++;
				}
				class16_0.GetHabbo().int_24 = 1;
			}
			else
			{
				Phoenix.GetGame().GetCatalog().method_6(class16_0, int_, uint_, string_, false, "", "", true);
			}
		}
	}
}
