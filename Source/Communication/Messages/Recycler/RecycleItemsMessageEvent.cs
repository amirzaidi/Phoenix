using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Items;
using Phoenix.Messages;
using Phoenix.HabboHotel.Catalogs;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Recycler
{
	internal sealed class RecycleItemsMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0.GetHabbo().Boolean_0)
			{
				int num = class18_0.PopWiredInt32();
				if (num == 5)
				{
					for (int i = 0; i < num; i++)
					{
						Class39 @class = class16_0.GetHabbo().method_23().method_10(class18_0.PopWiredUInt());
						if (@class == null || !@class.method_1().bool_3)
						{
							return;
						}
						class16_0.GetHabbo().method_23().method_12(@class.uint_0, 0u, false);
					}
					uint num2 = Phoenix.GetGame().GetCatalog().method_14();
					Class47 class2 = Phoenix.GetGame().GetCatalog().method_15();
					using (DatabaseClient class3 = Phoenix.GetDatabase().GetClient())
					{
						class3.ExecuteQuery(string.Concat(new object[]
						{
							"INSERT INTO items (id,user_id,base_item,extra_data,wall_pos) VALUES ('",
							num2,
							"','",
							class16_0.GetHabbo().Id,
							"','1478','",
							DateTime.Now.ToLongDateString(),
							"', '')"
						}));
						class3.ExecuteQuery(string.Concat(new object[]
						{
							"INSERT INTO user_presents (item_id,base_id,amount,extra_data) VALUES ('",
							num2,
							"','",
							class2.uint_2,
							"','1','')"
						}));
					}
					class16_0.GetHabbo().method_23().method_9(true);
					ServerMessage gClass = new ServerMessage(508u);
					gClass.AppendBoolean(true);
					gClass.AppendUInt(num2);
					class16_0.method_14(gClass);
				}
			}
		}
	}
}
