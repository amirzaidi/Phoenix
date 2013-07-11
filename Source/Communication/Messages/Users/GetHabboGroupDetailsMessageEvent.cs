using System;
using System.Data;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Users
{
	internal sealed class GetHabboGroupDetailsMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			int num = class18_0.PopWiredInt32();
			if (num > 0 && (class16_0 != null && class16_0.GetHabbo() != null))
			{
				GroupsManager @class = Groups.smethod_2(num);
				if (@class != null)
				{
					ServerMessage gClass = new ServerMessage(311u);
					gClass.AppendInt32(@class.int_0);
					gClass.AppendStringWithBreak(@class.string_0);
					gClass.AppendStringWithBreak(@class.string_1);
					gClass.AppendStringWithBreak(@class.string_2);
					if (@class.uint_0 > 0u)
					{
						gClass.AppendUInt(@class.uint_0);
						if (Phoenix.GetGame().GetRoomManager().GetRoom(@class.uint_0) != null)
						{
							gClass.AppendStringWithBreak(Phoenix.GetGame().GetRoomManager().GetRoom(@class.uint_0).Name);
							goto IL_15A;
						}
						using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
						{
							try
							{
								DataRow dataRow_ = class2.ReadDataRow("SELECT * FROM rooms WHERE id = " + @class.uint_0 + " LIMIT 1;");
								string string_ = Phoenix.GetGame().GetRoomManager().method_17(@class.uint_0, dataRow_).Name;
								gClass.AppendStringWithBreak(string_);
							}
							catch
							{
								gClass.AppendInt32(-1);
								gClass.AppendStringWithBreak("");
							}
							goto IL_15A;
						}
					}
					gClass.AppendInt32(-1);
					gClass.AppendStringWithBreak("");
					IL_15A:
					bool flag = false;
					foreach (DataRow dataRow in class16_0.GetHabbo().dataTable_0.Rows)
					{
						if ((int)dataRow["groupid"] == @class.int_0)
						{
							flag = true;
						}
					}
					if (class16_0.GetHabbo().list_0.Contains(@class.int_0))
					{
						gClass.AppendInt32(2);
					}
					else
					{
						if (flag)
						{
							gClass.AppendInt32(1);
						}
						else
						{
							if (@class.string_3 == "closed")
							{
								gClass.AppendInt32(1);
							}
							else
							{
								if (@class.list_0.Contains((int)class16_0.GetHabbo().Id))
								{
									gClass.AppendInt32(1);
								}
								else
								{
									gClass.AppendInt32(0);
								}
							}
						}
					}
					gClass.AppendInt32(@class.list_0.Count);
					if (class16_0.GetHabbo().int_0 == @class.int_0)
					{
						gClass.AppendBoolean(true);
					}
					else
					{
						gClass.AppendBoolean(false);
					}
					class16_0.method_14(gClass);
				}
			}
		}
	}
}
