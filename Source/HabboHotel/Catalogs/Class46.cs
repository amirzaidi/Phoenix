using System;
using System.Data;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.Storage;
namespace Phoenix.Catalogs
{
	internal sealed class Class46
	{
		public bool method_0(string string_0)
		{
			bool result;
			using (DatabaseClient adapter = Phoenix.GetDatabase().GetClient())
			{
				adapter.AddParamWithValue("code", string_0);
				if (adapter.ReadDataRow("SELECT null FROM vouchers WHERE code = @code LIMIT 1") != null)
				{
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}
		public void method_1(string string_0)
		{
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				@class.AddParamWithValue("code", string_0);
				@class.ExecuteQuery("DELETE FROM vouchers WHERE code = @code LIMIT 1");
			}
		}
		public void method_2(GameClient class16_0, string string_0)
		{
			if (!this.method_0(string_0))
			{
				ServerMessage gClass = new ServerMessage(213u);
				gClass.AppendRawInt32(0);
				class16_0.method_14(gClass);
			}
			else
			{
				DataRow dataRow = null;
				using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
				{
					@class.AddParamWithValue("code", string_0);
					dataRow = @class.ReadDataRow("SELECT * FROM vouchers WHERE code = @code LIMIT 1");
				}
				int num = (int)dataRow["credits"];
				int num2 = (int)dataRow["pixels"];
				int num3 = (int)dataRow["vip_points"];
				this.method_1(string_0);
				if (num > 0)
				{
					class16_0.GetHabbo().Credits += num;
					class16_0.GetHabbo().method_13(true);
				}
				if (num2 > 0)
				{
					class16_0.GetHabbo().ActivityPoints += num2;
					class16_0.GetHabbo().method_15(true);
				}
				if (num3 > 0)
				{
					class16_0.GetHabbo().VipPoints += num3;
					class16_0.GetHabbo().method_14(false, true);
				}
				class16_0.method_14(new ServerMessage(212u));
			}
		}
	}
}
