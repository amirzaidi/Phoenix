using System;
using System.Collections.Generic;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Catalogs;
namespace Phoenix.Communication.Messages.Recycler
{
	internal sealed class GetRecyclerPrizesMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			ServerMessage gClass = new ServerMessage(506u);
			gClass.AppendInt32(5);
			for (uint num = 5u; num >= 1u; num -= 1u)
			{
				gClass.AppendUInt(num);
				if (num <= 1u)
				{
					gClass.AppendInt32(0);
				}
				else
				{
					if (num == 2u)
					{
						gClass.AppendInt32(4);
					}
					else
					{
						if (num == 3u)
						{
							gClass.AppendInt32(40);
						}
						else
						{
							if (num == 4u)
							{
								gClass.AppendInt32(200);
							}
							else
							{
								if (num >= 5u)
								{
									gClass.AppendInt32(2000);
								}
							}
						}
					}
				}
				List<Class47> list = Phoenix.GetGame().GetCatalog().method_16(num);
				gClass.AppendInt32(list.Count);
				foreach (Class47 current in list)
				{
					gClass.AppendStringWithBreak(current.method_0().char_0.ToString().ToLower());
					gClass.AppendUInt(current.uint_1);
				}
			}
			class16_0.method_14(gClass);
		}
	}
}
