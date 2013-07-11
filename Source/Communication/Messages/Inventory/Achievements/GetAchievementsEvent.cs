using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Achievements;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Inventory.Achievements
{
	internal sealed class GetAchievementsEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			class16_0.method_14(AchievementManager.smethod_1(class16_0));
		}
	}
}
