using System;
using System.Data;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Items;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Marketplace
{
	internal sealed class BuyOfferMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			uint num = class18_0.PopWiredUInt();
			DataRow dataRow = null;
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				dataRow = @class.ReadDataRow("SELECT state, timestamp, total_price, extra_data, item_id, furni_id FROM catalog_marketplace_offers WHERE offer_id = '" + num + "' LIMIT 1");
			}
			if (dataRow == null || (string)dataRow["state"] != "1" || (double)dataRow["timestamp"] <= Phoenix.GetGame().GetCatalog().method_22().method_3())
			{
				class16_0.SendNotif(PhoenixEnvironment.GetExternalText("marketplace_error_expired"));
			}
			else
			{
				FurnitureData class2 = Phoenix.GetGame().GetItemManager().method_2((uint)dataRow["item_id"]);
				if (class2 != null)
				{
					if ((int)dataRow["total_price"] >= 1)
					{
						if (class16_0.GetHabbo().Credits < (int)dataRow["total_price"])
						{
							class16_0.SendNotif(PhoenixEnvironment.GetExternalText("marketplace_error_credits"));
							return;
						}
						class16_0.GetHabbo().Credits -= (int)dataRow["total_price"];
						class16_0.GetHabbo().method_13(true);
					}
					Phoenix.GetGame().GetCatalog().method_9(class16_0, class2, 1, (string)dataRow["extra_data"], false, (uint)dataRow["furni_id"]);
					using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
					{
						@class.ExecuteQuery("UPDATE catalog_marketplace_offers SET state = '2' WHERE offer_id = '" + num + "' LIMIT 1");
						int num2 = 0;
						try
						{
							num2 = @class.ReadInt32("SELECT id FROM catalog_marketplace_data WHERE daysago = 0 AND sprite = " + class2.int_0 + " LIMIT 1;");
						}
						catch
						{
						}
						if (num2 > 0)
						{
							@class.ExecuteQuery(string.Concat(new object[]
							{
								"UPDATE catalog_marketplace_data SET sold = sold + 1, avgprice = (avgprice + ",
								(int)dataRow["total_price"],
								") WHERE id = ",
								num2,
								" LIMIT 1;"
							}));
						}
						else
						{
							@class.ExecuteQuery(string.Concat(new object[]
							{
								"INSERT INTO catalog_marketplace_data (sprite, sold, avgprice, daysago) VALUES ('",
								class2.int_0,
								"', 1, ",
								(int)dataRow["total_price"],
								", 0)"
							}));
						}
						if (Phoenix.GetGame().GetCatalog().method_22().dictionary_0.ContainsKey(class2.int_0) && Phoenix.GetGame().GetCatalog().method_22().dictionary_1.ContainsKey(class2.int_0))
						{
							int num3 = Phoenix.GetGame().GetCatalog().method_22().dictionary_1[class2.int_0];
							int num4 = Phoenix.GetGame().GetCatalog().method_22().dictionary_0[class2.int_0];
							num4 += (int)dataRow["total_price"];
							Phoenix.GetGame().GetCatalog().method_22().dictionary_0.Remove(class2.int_0);
							Phoenix.GetGame().GetCatalog().method_22().dictionary_0.Add(class2.int_0, num4);
							Phoenix.GetGame().GetCatalog().method_22().dictionary_1.Remove(class2.int_0);
							Phoenix.GetGame().GetCatalog().method_22().dictionary_1.Add(class2.int_0, num3 + 1);
						}
						else
						{
							if (!Phoenix.GetGame().GetCatalog().method_22().dictionary_0.ContainsKey(class2.int_0))
							{
								Phoenix.GetGame().GetCatalog().method_22().dictionary_0.Add(class2.int_0, (int)dataRow["total_price"]);
							}
							if (!Phoenix.GetGame().GetCatalog().method_22().dictionary_1.ContainsKey(class2.int_0))
							{
								Phoenix.GetGame().GetCatalog().method_22().dictionary_1.Add(class2.int_0, 1);
							}
						}
					}
					ServerMessage gClass = new ServerMessage(67u);
					gClass.AppendUInt(class2.UInt32_0);
					gClass.AppendStringWithBreak(class2.string_1);
					gClass.AppendInt32((int)dataRow["total_price"]);
					gClass.AppendInt32(0);
					gClass.AppendInt32(0);
					gClass.AppendInt32(1);
					gClass.AppendStringWithBreak(class2.char_0.ToString());
					gClass.AppendInt32(class2.int_0);
					gClass.AppendStringWithBreak("");
					gClass.AppendInt32(1);
					gClass.AppendInt32(-1);
					gClass.AppendStringWithBreak("");
					class16_0.method_14(gClass);
					class16_0.method_14(Phoenix.GetGame().GetCatalog().method_22().method_5(-1, -1, "", 1));
				}
			}
		}
	}
}
