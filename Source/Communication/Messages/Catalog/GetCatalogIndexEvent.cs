using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Catalog
{
	internal sealed class GetCatalogIndexEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			class16_0.method_14(Phoenix.GetGame().GetCatalog().method_18(class16_0.GetHabbo().uint_1));
		}
	}
}
