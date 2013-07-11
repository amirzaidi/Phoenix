using System;
using System.Collections.Generic;
using System.Data;
using Phoenix.Core;
using Phoenix.Storage;
namespace Phoenix.HabboHotel.RoomBots
{
	internal sealed class BotManager
	{
		private List<Class34> list_0;
		public BotManager()
		{
			this.list_0 = new List<Class34>();
		}
		public void method_0(DatabaseClient class6_0)
		{
            Logging.Write("Loading Bot data..");
			this.list_0 = new List<Class34>();
			DataTable dataTable = class6_0.ReadDataTable("SELECT * FROM bots;");
			DataTable dataTable2 = class6_0.ReadDataTable("SELECT id, bot_id, keywords, response_text, mode, serve_id FROM bots_responses;");
			DataTable dataTable3 = class6_0.ReadDataTable("SELECT text, shout, bot_id FROM bots_speech;");
			List<Class35> list = new List<Class35>();
			List<Class36> list2 = new List<Class36>();
			foreach (DataRow dataRow in dataTable2.Rows)
			{
				list.Add(new Class35((uint)dataRow["id"], (uint)dataRow["bot_id"], (string)dataRow["keywords"], (string)dataRow["response_text"], dataRow["mode"].ToString(), (int)dataRow["serve_id"]));
			}
			foreach (DataRow dataRow in dataTable3.Rows)
			{
				list2.Add(new Class36((string)dataRow["text"], Phoenix.smethod_3(dataRow["shout"].ToString()), (uint)dataRow["bot_id"]));
			}
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					string text = (string)dataRow["ai_type"];
					string text2 = text;
					if (text2 == null)
					{
						goto IL_201;
					}
					Enum2 enum2_;
					if (!(text2 == "generic"))
					{
						if (!(text2 == "guide"))
						{
							if (!(text2 == "pet"))
							{
								goto IL_201;
							}
							enum2_ = Enum2.const_0;
						}
						else
						{
							enum2_ = Enum2.const_1;
						}
					}
					else
					{
						enum2_ = Enum2.const_2;
					}
					IL_204:
					this.list_0.Add(new Class34((uint)dataRow["id"], (uint)dataRow["room_id"], enum2_, (string)dataRow["walk_mode"], (string)dataRow["name"], (string)dataRow["motto"], (string)dataRow["look"], (int)dataRow["x"], (int)dataRow["y"], (int)dataRow["z"], (int)dataRow["rotation"], (int)dataRow["min_x"], (int)dataRow["min_y"], (int)dataRow["max_x"], (int)dataRow["max_y"], ref list2, ref list, (int)dataRow["effect"]));
					continue;
					IL_201:
					enum2_ = Enum2.const_2;
					goto IL_204;
				}
				Logging.WriteLine("completed!");
			}
		}
		public bool method_1(uint uint_0)
		{
			return this.method_2(uint_0).Count >= 1;
		}
		public List<Class34> method_2(uint uint_0)
		{
			List<Class34> list = new List<Class34>();
			using (TimedLock.Lock(this.list_0))
			{
				foreach (Class34 current in this.list_0)
				{
					if (current.uint_1 == uint_0)
					{
						list.Add(current);
					}
				}
			}
			return list;
		}
		public Class34 method_3(uint uint_0)
		{
			Class34 result;
			using (TimedLock.Lock(this.list_0))
			{
				foreach (Class34 current in this.list_0)
				{
					if (current.uint_0 == uint_0)
					{
						result = current;
						return result;
					}
				}
			}
			return null;
		}
	}
}
