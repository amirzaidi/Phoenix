using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Help
{
	internal sealed class SearchFaqsMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			string text = Phoenix.smethod_7(class18_0.PopFixedString());
			if (text.Length >= 1)
			{
				class16_0.method_14(Phoenix.GetGame().GetHelpTool().method_10(text));
			}
		}
	}
}
