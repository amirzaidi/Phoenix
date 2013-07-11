using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Catalogs;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Catalog
{
	internal sealed class GetIsOfferGiftableEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			uint uint_ = class18_0.PopWiredUInt();
			Class49 @class = Phoenix.GetGame().GetCatalog().method_2(uint_);
			if (@class != null)
			{
				ServerMessage gClass = new ServerMessage(622u);
				gClass.AppendUInt(@class.uint_0);
				gClass.AppendBoolean(@class.method_0().bool_6);
				class16_0.method_14(gClass);
			}
		}
	}
}
