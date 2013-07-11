using System;
using System.Data;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Users
{
	internal sealed class Class153 : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			int num = class18_0.PopWiredInt32();
			if (num > 0 && (class16_0 != null && class16_0.GetHabbo() != null))
			{
				class16_0.GetHabbo().int_0 = 0;
				if (class16_0.GetHabbo().Boolean_0)
				{
					Room class14_ = class16_0.GetHabbo().Class14_0;
					Class33 @class = class14_.method_53(class16_0.GetHabbo().Id);
					ServerMessage gClass = new ServerMessage(28u);
					gClass.AppendInt32(1);
					@class.method_14(gClass);
					class14_.SendMessage(gClass, null);
				}
				using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
				{
					class2.ExecuteQuery("UPDATE user_stats SET groupid = 0 WHERE id = " + class16_0.GetHabbo().Id + " LIMIT 1;");
				}
				DataTable dataTable_ = class16_0.GetHabbo().dataTable_0;
				if (dataTable_ != null)
				{
					ServerMessage gClass2 = new ServerMessage(915u);
					gClass2.AppendInt32(dataTable_.Rows.Count);
					foreach (DataRow dataRow in dataTable_.Rows)
					{
						GroupsManager class3 = Groups.smethod_2((int)dataRow["groupid"]);
						gClass2.AppendInt32(class3.int_0);
						gClass2.AppendStringWithBreak(class3.string_0);
						gClass2.AppendStringWithBreak(class3.string_2);
						if (class16_0.GetHabbo().int_0 == class3.int_0)
						{
							gClass2.AppendBoolean(true);
						}
						else
						{
							gClass2.AppendBoolean(false);
						}
					}
					class16_0.method_14(gClass2);
				}
			}
		}
	}
}
