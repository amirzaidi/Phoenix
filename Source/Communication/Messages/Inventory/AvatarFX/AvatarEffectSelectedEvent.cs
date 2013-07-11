using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Inventory.AvatarFX
{
	internal sealed class AvatarEffectSelectedEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			class16_0.GetHabbo().method_24().method_2(class18_0.PopWiredInt32(), false);
		}
	}
}
