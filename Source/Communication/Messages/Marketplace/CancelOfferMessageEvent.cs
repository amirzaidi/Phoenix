using System;
using System.Data;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Items;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Marketplace
{
	internal sealed class CancelOfferMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0 != null)
			{
				uint num = class18_0.PopWiredUInt();
				DataRow dataRow = null;
				using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
				{
					dataRow = @class.ReadDataRow("SELECT furni_id, item_id, user_id, extra_data, offer_id, state, timestamp FROM catalog_marketplace_offers WHERE offer_id = '" + num + "' LIMIT 1");
				}
				if (dataRow != null)
				{
					int num2 = (int)Math.Floor(((double)dataRow["timestamp"] + 172800.0 - Phoenix.GetUnixTimestamp()) / 60.0);
					int num3 = int.Parse(dataRow["state"].ToString());
					if (num2 <= 0)
					{
						num3 = 3;
					}
					if ((uint)dataRow["user_id"] == class16_0.GetHabbo().Id && num3 != 2)
					{
						FurnitureData class2 = Phoenix.GetGame().GetItemManager().method_2((uint)dataRow["item_id"]);
						if (class2 != null)
						{
							Phoenix.GetGame().GetCatalog().method_9(class16_0, class2, 1, (string)dataRow["extra_data"], false, (uint)dataRow["furni_id"]);
							using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
							{
								@class.ExecuteQuery("DELETE FROM catalog_marketplace_offers WHERE offer_id = '" + num + "' LIMIT 1");
							}
							ServerMessage gClass = new ServerMessage(614u);
							gClass.AppendUInt((uint)dataRow["offer_id"]);
							gClass.AppendBoolean(true);
							class16_0.method_14(gClass);
						}
					}
				}
			}
		}
	}
}
