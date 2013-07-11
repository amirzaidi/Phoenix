using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Items;
namespace Phoenix.Communication.Messages.Sound
{
	internal sealed class GetSongInfoMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			int num = class18_0.PopWiredInt32();
			ServerMessage gClass = new ServerMessage(300u);
			gClass.AppendInt32(num);
			if (num > 0)
			{
				for (int i = 0; i < num; i++)
				{
					int num2 = class18_0.PopWiredInt32();
					if (num2 > 0)
					{
						Soundtrack @class = Phoenix.GetGame().GetItemManager().method_4(num2);
						gClass.AppendInt32(@class.int_0);
						gClass.AppendStringWithBreak(@class.string_0);
						gClass.AppendStringWithBreak(@class.string_2);
						gClass.AppendInt32(@class.int_1);
						gClass.AppendStringWithBreak(@class.string_1);
					}
				}
			}
			class16_0.method_14(gClass);
		}
	}
}
