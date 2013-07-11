using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Items;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Marketplace
{
	internal sealed class MakeOfferMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0.GetHabbo().method_23() != null)
			{
				if (class16_0.GetHabbo().Boolean_0)
				{
					Room class14_ = class16_0.GetHabbo().Class14_0;
					Class33 @class = class14_.method_53(class16_0.GetHabbo().Id);
					if (@class.Boolean_3)
					{
						return;
					}
				}
				int int_ = class18_0.PopWiredInt32();
				class18_0.PopWiredInt32();
				uint uint_ = class18_0.PopWiredUInt();
				Class39 class2 = class16_0.GetHabbo().method_23().method_10(uint_);
				if (class2 != null && class2.method_1().bool_4)
				{
					Phoenix.GetGame().GetCatalog().method_22().method_1(class16_0, class2.uint_0, int_);
				}
			}
		}
	}
}
