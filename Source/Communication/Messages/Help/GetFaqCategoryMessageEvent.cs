using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Support;
namespace Phoenix.Communication.Messages.Help
{
	internal sealed class GetFaqCategoryMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			uint uint_ = class18_0.PopWiredUInt();
			Class131 @class = Phoenix.GetGame().GetHelpTool().method_1(uint_);
			if (@class != null)
			{
				class16_0.method_14(Phoenix.GetGame().GetHelpTool().method_11(@class));
			}
		}
	}
}
