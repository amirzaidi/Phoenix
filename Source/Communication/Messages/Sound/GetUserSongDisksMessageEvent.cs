using System;
using System.Collections.Generic;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Items;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Sound
{
	internal sealed class GetUserSongDisksMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			List<Class39> list = new List<Class39>();
			foreach (Class39 current in class16_0.GetHabbo().method_23().list_0)
			{
				if (current != null && !(current.method_1().string_1 != "song_disk") && !class16_0.GetHabbo().method_23().list_1.Contains(current.uint_0))
				{
					list.Add(current);
				}
			}
			ServerMessage gClass = new ServerMessage(333u);
			gClass.AppendInt32(list.Count);
			foreach (Class39 current2 in list)
			{
				int int_ = 0;
				if (current2.string_0.Length > 0)
				{
					int_ = int.Parse(current2.string_0);
				}
				Soundtrack @class = Phoenix.GetGame().GetItemManager().method_4(int_);
				if (@class == null)
				{
					return;
				}
				gClass.AppendUInt(current2.uint_0);
				gClass.AppendInt32(@class.int_0);
			}
			class16_0.method_14(gClass);
		}
	}
}
