using System;
using System.Collections.Generic;
using System.Text;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Messages;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Navigator
{
	internal sealed class UpdateRoomThumbnailMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && @class.method_27(class16_0, true))
			{
				class18_0.PopWiredInt32();
				Dictionary<int, int> dictionary = new Dictionary<int, int>();
				int num = class18_0.PopWiredInt32();
				int num2 = class18_0.PopWiredInt32();
				int num3 = class18_0.PopWiredInt32();
				for (int i = 0; i < num3; i++)
				{
					int num4 = class18_0.PopWiredInt32();
					int num5 = class18_0.PopWiredInt32();
					if (num4 < 0 || num4 > 10 || (num5 < 1 || num5 > 27) || dictionary.ContainsKey(num4))
					{
						return;
					}
					dictionary.Add(num4, num5);
				}
				if (num >= 1 && num <= 24 && (num2 >= 0 && num2 <= 11))
				{
					StringBuilder stringBuilder = new StringBuilder();
					int num6 = 0;
					foreach (KeyValuePair<int, int> current in dictionary)
					{
						if (num6 > 0)
						{
							stringBuilder.Append("|");
						}
						stringBuilder.Append(current.Key + "," + current.Value);
						num6++;
					}
					using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
					{
						class2.ExecuteQuery(string.Concat(new object[]
						{
							"UPDATE rooms SET icon_bg = '",
							num,
							"', icon_fg = '",
							num2,
							"', icon_items = '",
							stringBuilder.ToString(),
							"' WHERE id = '",
							@class.Id,
							"' LIMIT 1"
						}));
					}
					@class.myIcon = new RoomIcon(num, num2, dictionary);
					ServerMessage gClass = new ServerMessage(457u);
					gClass.AppendUInt(@class.Id);
					gClass.AppendBoolean(true);
					class16_0.method_14(gClass);
					ServerMessage gClass2 = new ServerMessage(456u);
					gClass2.AppendUInt(@class.Id);
					class16_0.method_14(gClass2);
					RoomData class27_ = @class.Class27_0;
					ServerMessage gClass3 = new ServerMessage(454u);
					gClass3.AppendBoolean(false);
					class27_.method_3(gClass3, false, false);
					class16_0.method_14(gClass3);
				}
			}
		}
	}
}
