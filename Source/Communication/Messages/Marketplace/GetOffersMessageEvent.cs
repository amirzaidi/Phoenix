using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Marketplace
{
	internal sealed class GetOffersMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			int int_ = class18_0.PopWiredInt32();
			int int_2 = class18_0.PopWiredInt32();
			string string_ = class18_0.PopFixedString();
			int int_3 = class18_0.PopWiredInt32();
			class16_0.method_14(Phoenix.GetGame().GetCatalog().method_22().method_5(int_, int_2, string_, int_3));
		}
	}
}
