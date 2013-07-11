using System;
using System.Collections.Generic;
using System.Data;
using Phoenix.HabboHotel.Users.UserDataManagement;
using Phoenix.Storage;
namespace Phoenix.HabboHotel.Users.Subscriptions
{
	internal class SubscriptionManager
	{
		private uint uint_0;
		private Dictionary<string, Subscription> dictionary_0;
		public List<string> List_0
		{
			get
			{
				List<string> list = new List<string>();
				using (TimedLock.Lock(this.dictionary_0.Values))
				{
					foreach (Subscription current in this.dictionary_0.Values)
					{
						list.Add(current.String_0);
					}
				}
				return list;
			}
		}
		public SubscriptionManager(uint uint_1, UserDataFactory class12_0)
		{
			this.uint_0 = uint_1;
			this.dictionary_0 = new Dictionary<string, Subscription>();
			DataTable dataTable_ = class12_0.DataTable_4;
			if (dataTable_ != null)
			{
				foreach (DataRow dataRow in dataTable_.Rows)
				{
					this.dictionary_0.Add((string)dataRow["subscription_id"], new Subscription((string)dataRow["subscription_id"], (int)dataRow["timestamp_activated"], (int)dataRow["timestamp_expire"]));
				}
			}
		}
		public void method_0()
		{
			this.dictionary_0.Clear();
		}
		public Subscription method_1(string string_0)
		{
			if (this.dictionary_0.ContainsKey(string_0))
			{
				return dictionary_0[string_0];
			}
			else
			{
				return null;
			}
		}
		public bool method_2(string string_0)
		{
			if (!this.dictionary_0.ContainsKey(string_0))
			{
				return false;
			}
			else
			{
				Subscription @class = this.dictionary_0[string_0];
				return @class.method_0();
			}
		}
		public void method_3(string string_0, int int_0)
		{
			string_0 = string_0.ToLower();
			if (this.dictionary_0.ContainsKey(string_0))
			{
				Subscription @class = this.dictionary_0[string_0];
				@class.method_1(int_0);
				if (@class.Int32_0 <= 0 || @class.Int32_0 >= 2147483647)
				{
					return;
				}
				using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
				{
					class2.AddParamWithValue("subcrbr", string_0);
					class2.ExecuteQuery(string.Concat(new object[]
					{
						"UPDATE user_subscriptions SET timestamp_expire = '",
						@class.Int32_0,
						"' WHERE user_id = '",
						this.uint_0,
						"' AND subscription_id = @subcrbr LIMIT 1"
					}));
					return;
				}
			}
			if (!this.dictionary_0.ContainsKey("habbo_vip"))
			{
				int num = (int)Phoenix.GetUnixTimestamp();
				int num2 = (int)Phoenix.GetUnixTimestamp() + int_0;
				Subscription class3 = new Subscription(string_0, num, num2);
				using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
				{
					class2.AddParamWithValue("subcrbr", string_0);
					class2.ExecuteQuery(string.Concat(new object[]
					{
						"INSERT INTO user_subscriptions (user_id,subscription_id,timestamp_activated,timestamp_expire) VALUES ('",
						this.uint_0,
						"',@subcrbr,'",
						num,
						"','",
						num2,
						"')"
					}));
				}
				this.dictionary_0.Add(class3.String_0.ToLower(), class3);
			}
		}
	}
}
