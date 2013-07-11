using System;
using System.Collections.Generic;
using System.Data;
using Phoenix.Core;
using Phoenix.Messages;
using Phoenix.Storage;
namespace Phoenix.HabboHotel.Support
{
	internal sealed class HelpTool
	{
		public Dictionary<uint, Class131> dictionary_0;
		public Dictionary<uint, Class130> dictionary_1;
		public List<Class130> list_0;
		public List<Class130> list_1;
		public HelpTool()
		{
			this.dictionary_0 = new Dictionary<uint, Class131>();
			this.dictionary_1 = new Dictionary<uint, Class130>();
			this.list_0 = new List<Class130>();
			this.list_1 = new List<Class130>();
		}
		public void method_0(DatabaseClient class6_0)
		{
			Logging.Write("Loading Help Categories..");
			this.dictionary_0.Clear();
			DataTable dataTable = class6_0.ReadDataTable("SELECT id, caption FROM help_subjects");
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					this.dictionary_0.Add((uint)dataRow["id"], new Class131((uint)dataRow["id"], (string)dataRow["caption"]));
				}
				Logging.WriteLine("completed!");
			}
		}
		public Class131 method_1(uint uint_0)
		{
			Class131 result;
			if (this.dictionary_0.ContainsKey(uint_0))
			{
				result = this.dictionary_0[uint_0];
			}
			else
			{
				result = null;
			}
			return result;
		}
		public void method_2()
		{
			this.dictionary_0.Clear();
		}
		public void method_3(DatabaseClient class6_0)
		{
			Logging.Write("Loading Help Topics..");
			this.dictionary_1.Clear();
			DataTable dataTable = class6_0.ReadDataTable("SELECT id, title, body, subject, known_issue FROM help_topics");
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					Class130 @class = new Class130((uint)dataRow["id"], (string)dataRow["title"], (string)dataRow["body"], (uint)dataRow["subject"]);
					this.dictionary_1.Add((uint)dataRow["id"], @class);
					int num = int.Parse(dataRow["known_issue"].ToString());
					if (num == 1)
					{
						this.list_1.Add(@class);
					}
					else
					{
						if (num == 2)
						{
							this.list_0.Add(@class);
						}
					}
				}
				Logging.WriteLine("completed!");
			}
		}
		public Class130 method_4(uint uint_0)
		{
			Class130 result;
			if (this.dictionary_1.ContainsKey(uint_0))
			{
				result = this.dictionary_1[uint_0];
			}
			else
			{
				result = null;
			}
			return result;
		}
		public void method_5()
		{
			this.dictionary_1.Clear();
			this.list_0.Clear();
			this.list_1.Clear();
		}
		public int method_6(uint uint_0)
		{
			int num = 0;
			using (TimedLock.Lock(this.dictionary_1))
			{
				foreach (Class130 current in this.dictionary_1.Values)
				{
					if (current.uint_1 == uint_0)
					{
						num++;
					}
				}
			}
			return num;
		}
		public ServerMessage method_7()
		{
			ServerMessage gClass = new ServerMessage(518u);
			gClass.AppendInt32(this.list_0.Count);
			using (TimedLock.Lock(this.list_0))
			{
				foreach (Class130 current in this.list_0)
				{
					gClass.AppendUInt(current.UInt32_0);
					gClass.AppendStringWithBreak(current.string_0);
				}
			}
			gClass.AppendInt32(this.list_1.Count);
			using (TimedLock.Lock(this.list_1))
			{
				foreach (Class130 current in this.list_1)
				{
					gClass.AppendUInt(current.UInt32_0);
					gClass.AppendStringWithBreak(current.string_0);
				}
			}
			return gClass;
		}
		public ServerMessage method_8()
		{
			ServerMessage gClass = new ServerMessage(519u);
			gClass.AppendInt32(this.dictionary_0.Count);
			using (TimedLock.Lock(this.dictionary_0))
			{
				foreach (Class131 current in this.dictionary_0.Values)
				{
					gClass.AppendUInt(current.UInt32_0);
					gClass.AppendStringWithBreak(current.string_0);
					gClass.AppendInt32(this.method_6(current.UInt32_0));
				}
			}
			return gClass;
		}
		public ServerMessage method_9(Class130 class130_0)
		{
			ServerMessage gClass = new ServerMessage(520u);
			gClass.AppendUInt(class130_0.UInt32_0);
			gClass.AppendStringWithBreak(class130_0.string_1);
			return gClass;
		}
		public ServerMessage method_10(string string_0)
		{
			DataTable dataTable = null;
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				@class.AddParamWithValue("query", string_0);
				dataTable = @class.ReadDataTable("SELECT id,title FROM help_topics WHERE title LIKE @query OR body LIKE @query LIMIT 25");
			}
			ServerMessage gClass = new ServerMessage(521u);
			ServerMessage result;
			if (dataTable == null)
			{
				gClass.AppendBoolean(false);
				result = gClass;
			}
			else
			{
				gClass.AppendInt32(dataTable.Rows.Count);
				foreach (DataRow dataRow in dataTable.Rows)
				{
					gClass.AppendUInt((uint)dataRow["id"]);
					gClass.AppendStringWithBreak((string)dataRow["title"]);
				}
				result = gClass;
			}
			return result;
		}
		public ServerMessage method_11(Class131 class131_0)
		{
			ServerMessage gClass = new ServerMessage(522u);
			gClass.AppendUInt(class131_0.UInt32_0);
			gClass.AppendStringWithBreak("");
			gClass.AppendInt32(this.method_6(class131_0.UInt32_0));
			using (TimedLock.Lock(this.dictionary_1))
			{
				foreach (Class130 current in this.dictionary_1.Values)
				{
					if (current.uint_1 == class131_0.UInt32_0)
					{
						gClass.AppendUInt(current.UInt32_0);
						gClass.AppendStringWithBreak(current.string_0);
					}
				}
			}
			return gClass;
		}
	}
}
