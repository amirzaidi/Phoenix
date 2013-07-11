using System;
using System.Collections.Generic;
using System.Data;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Marketplace
{
	internal sealed class GetMarketplaceItemStatsEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			int int_ = class18_0.PopWiredInt32();
			int num = class18_0.PopWiredInt32();
			ServerMessage gClass = new ServerMessage(617u);
			gClass.AppendInt32(1);
			gClass.AppendInt32(Phoenix.GetGame().GetCatalog().method_22().method_7(num));
			Dictionary<int, DataRow> dictionary = new Dictionary<int, DataRow>();
			DataTable dataTable = null;
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				dataTable = @class.ReadDataTable("SELECT * FROM catalog_marketplace_data WHERE daysago > -30 AND sprite = " + num + " LIMIT 30;");
			}
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					dictionary.Add(Convert.ToInt32(dataRow["daysago"]), dataRow);
				}
			}
			gClass.AppendInt32(30);
			gClass.AppendInt32(29);
			for (int i = -29; i < 0; i++)
			{
				gClass.AppendInt32(i);
				if (dictionary.ContainsKey(i + 1))
				{
					gClass.AppendInt32(Convert.ToInt32(dictionary[i + 1]["avgprice"]) / Convert.ToInt32(dictionary[i + 1]["sold"]));
					gClass.AppendInt32(Convert.ToInt32(dictionary[i + 1]["sold"]));
				}
				else
				{
					gClass.AppendInt32(0);
					gClass.AppendInt32(0);
				}
			}
			gClass.AppendInt32(int_);
			gClass.AppendInt32(num);
			class16_0.method_14(gClass);
		}
	}
}
