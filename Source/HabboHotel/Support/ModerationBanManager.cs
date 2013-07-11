using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Phoenix.Core;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Util;
using Phoenix.Storage;
namespace Phoenix.HabboHotel.Support
{
	internal sealed class ModerationBanManager
	{
		public List<ModerationBan> list_0;
		public ModerationBanManager()
		{
			this.list_0 = new List<ModerationBan>();
		}
		public void method_0(DatabaseClient class6_0)
		{
            Logging.Write("Loading bans..");
			this.list_0.Clear();
			DataTable dataTable = class6_0.ReadDataTable("SELECT bantype,value,reason,expire FROM bans WHERE expire > '" + Phoenix.GetUnixTimestamp() + "'");
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					ModerationBanType Type = ModerationBanType.IP;
					if ((string)dataRow["bantype"] == "user")
					{
						Type = ModerationBanType.USERNAME;
					}
					this.list_0.Add(new ModerationBan(Type, (string)dataRow["value"], (string)dataRow["reason"], (double)dataRow["expire"]));
				}
				Logging.WriteLine("completed!");
			}
		}
		public void method_1(GameClient class16_0)
		{
			foreach (ModerationBan current in this.list_0)
			{
				if (!current.Expired)
				{
					if (current.Type == ModerationBanType.IP && class16_0.GetConnection().Ip == current.Variable)
					{
						throw new ModerationBanException(current.ReasonMessage);
					}
					if (class16_0.GetHabbo() != null && (current.Type == ModerationBanType.USERNAME && class16_0.GetHabbo().Username.ToLower() == current.Variable.ToLower()))
					{
						throw new ModerationBanException(current.ReasonMessage);
					}
				}
			}
		}
		public void method_2(GameClient class16_0, string string_0, double double_0, string string_1, bool bool_0)
		{
			if (!class16_0.GetHabbo().bool_0)
			{
				ModerationBanType enum4_ = ModerationBanType.USERNAME;
				string text = class16_0.GetHabbo().Username;
				string object_ = "user";
				double num = Phoenix.GetUnixTimestamp() + double_0;
				if (bool_0)
				{
					enum4_ = ModerationBanType.IP;
					if (!Config.bool_20)
					{
						text = class16_0.GetConnection().Ip;
					}
					else
					{
						using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
						{
							text = @class.ReadString("SELECT ip_last FROM users WHERE id = " + class16_0.GetHabbo().Id + " LIMIT 1;");
						}
					}
					object_ = "ip";
				}
				this.list_0.Add(new ModerationBan(enum4_, text, string_1, num));
				using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
				{
					@class.AddParamWithValue("rawvar", object_);
					@class.AddParamWithValue("var", text);
					@class.AddParamWithValue("reason", string_1);
					@class.AddParamWithValue("mod", string_0);
					@class.ExecuteQuery(string.Concat(new object[]
					{
						"INSERT INTO bans (bantype,value,reason,expire,added_by,added_date,appeal_state) VALUES (@rawvar,@var,@reason,'",
						num,
						"',@mod,'",
						DateTime.Now.ToLongDateString(),
						"', '1')"
					}));
				}
				if (bool_0)
				{
					DataTable dataTable = null;
					using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
					{
						@class.AddParamWithValue("var", text);
						dataTable = @class.ReadDataTable("SELECT id FROM users WHERE ip_last = @var");
					}
					if (dataTable == null)
					{
						goto IL_268;
					}
					IEnumerator enumerator = dataTable.Rows.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							DataRow dataRow = (DataRow)enumerator.Current;
							using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
							{
								@class.ExecuteQuery("UPDATE user_info SET bans = bans + 1 WHERE user_id = '" + (uint)dataRow["id"] + "' LIMIT 1");
							}
						}
						goto IL_268;
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
				using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
				{
					@class.ExecuteQuery("UPDATE user_info SET bans = bans + 1 WHERE user_id = '" + class16_0.GetHabbo().Id + "' LIMIT 1");
				}
				IL_268:
				class16_0.method_7("You have been banned: " + string_1);
				class16_0.method_12();
			}
		}
	}
}
