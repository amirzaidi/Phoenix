using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Messenger
{
	internal sealed class FindNewFriendsMessageEvent : Interface
	{
		[CompilerGenerated]
		private static Func<Room, int> func_0;
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Dictionary<Room, int> dictionary = Phoenix.GetGame().GetRoomManager().method_21();
			Room @class = null;
			IEnumerable<Room> arg_35_0 = dictionary.Keys;
			if (FindNewFriendsMessageEvent.func_0 == null)
			{
				FindNewFriendsMessageEvent.func_0 = new Func<Room, int>(FindNewFriendsMessageEvent.smethod_0);
			}
			IOrderedEnumerable<Room> orderedEnumerable = arg_35_0.OrderByDescending(FindNewFriendsMessageEvent.func_0);
			int num = 0;
			foreach (Room current in orderedEnumerable)
			{
				num++;
				string a = Phoenix.smethod_5(1, 5).ToString();
				if (a == "2")
				{
					goto IL_83;
				}
				if (num == orderedEnumerable.Count<Room>())
				{
					goto IL_83;
				}
				bool arg_A2_0 = true;
				IL_A2:
				if (arg_A2_0)
				{
					continue;
				}
				@class = current;
				break;
				IL_83:
				arg_A2_0 = (class16_0.GetHabbo().Class14_0 == null || class16_0.GetHabbo().Class14_0 == current);
				goto IL_A2;
			}
			if (@class == null)
			{
				ServerMessage gClass = new ServerMessage(831u);
				gClass.AppendBoolean(false);
				class16_0.method_14(gClass);
			}
			else
			{
				ServerMessage gClass2 = new ServerMessage(286u);
				gClass2.AppendBoolean(@class.Boolean_3);
				gClass2.AppendUInt(@class.Id);
				class16_0.method_14(gClass2);
				ServerMessage gClass3 = new ServerMessage(831u);
				gClass3.AppendBoolean(true);
				class16_0.method_14(gClass3);
			}
		}
		[CompilerGenerated]
		private static int smethod_0(Room class14_0)
		{
			return class14_0.Int32_0;
		}
	}
}
