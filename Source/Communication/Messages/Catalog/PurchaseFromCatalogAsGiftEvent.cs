using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Catalog
{
	internal sealed class PurchaseFromCatalogAsGiftEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			int int_ = class18_0.PopWiredInt32();
			uint uint_ = class18_0.PopWiredUInt();
			string string_ = class18_0.PopFixedString();
			string string_2 = Phoenix.smethod_7(class18_0.PopFixedString());
			string string_3 = Phoenix.smethod_7(class18_0.PopFixedString());
			Phoenix.GetGame().GetCatalog().method_6(class16_0, int_, uint_, string_, true, string_2, string_3, true);
		}
	}
}
