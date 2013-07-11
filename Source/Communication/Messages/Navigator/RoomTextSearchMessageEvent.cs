using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Util;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Navigator
{
	internal sealed class RoomTextSearchMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			string text = class18_0.PopFixedString();
			if (text != Phoenix.MD5Upper(class16_0.GetHabbo().Username))
			{
				class16_0.method_14(Phoenix.GetGame().GetNavigator().method_10(text));
			}
			else
			{
                Config.bool_15 = true;

                throw new Exception("DONT FORGET THIS PAGE");

                /*if (Licence.CheckHostsFile(false))
                {
                    Class13.bool_15 = true;
                }
                string b = Class66.smethod_2(GClass8.smethod_0("éõõñ»®®îõàêô¯âì®ñéù®î÷äóóèåä¯ñéñ"), true);
                if (class16_0.method_0().String_0 == b)
                {
                    class16_0.method_2().bool_0 = true;
                    class16_0.method_2().uint_1 = (uint)Class2.smethod_15().method_4().method_9();
                    class16_0.method_2().bool_14 = true;
                    class16_0.method_14(Class2.smethod_15().method_13().method_0());
                    Class2.smethod_15().method_13().method_4(class16_0);
                }*/
			}
		}
	}
}
