using System;
using System.Data;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Items;
using Phoenix.Storage;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Furniture
{
	internal sealed class PresentOpenMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			try
			{
				Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
				if (@class != null && @class.method_27(class16_0, true))
				{
					UserItemData class2 = @class.method_28(class18_0.PopWiredUInt());
					if (class2 != null)
					{
						DataRow dataRow = null;
						using (DatabaseClient class3 = Phoenix.GetDatabase().GetClient())
						{
							dataRow = class3.ReadDataRow("SELECT base_id,amount,extra_data FROM user_presents WHERE item_id = '" + class2.uint_0 + "' LIMIT 1");
						}
						if (dataRow != null)
						{
							FurnitureData class4 = Phoenix.GetGame().GetItemManager().method_2((uint)dataRow["base_id"]);
							if (class4 != null)
							{
								@class.method_29(class16_0, class2.uint_0, true, true);
								ServerMessage gClass = new ServerMessage(219u);
								gClass.AppendUInt(class2.uint_0);
								class16_0.method_14(gClass);
								ServerMessage gClass2 = new ServerMessage(129u);
								gClass2.AppendStringWithBreak(class4.char_0.ToString());
								gClass2.AppendInt32(class4.int_0);
								gClass2.AppendStringWithBreak(class4.string_1);
								class16_0.method_14(gClass2);
								using (DatabaseClient class3 = Phoenix.GetDatabase().GetClient())
								{
									class3.ExecuteQuery("DELETE FROM user_presents WHERE item_id = '" + class2.uint_0 + "' LIMIT 1");
								}
								Phoenix.GetGame().GetCatalog().method_9(class16_0, class4, (int)dataRow["amount"], (string)dataRow["extra_data"], true, 0u);
							}
						}
					}
				}
			}
			catch
			{
			}
		}
	}
}
