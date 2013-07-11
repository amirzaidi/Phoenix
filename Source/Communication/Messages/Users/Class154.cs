using System;
using System.Data;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Users
{
	internal sealed class Class154 : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			int num = class18_0.PopWiredInt32();
			if (num > 0 && (class16_0 != null && class16_0.GetHabbo() != null))
			{
				class16_0.GetHabbo().int_0 = num;
				using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
				{
					@class.ExecuteQuery(string.Concat(new object[]
					{
						"UPDATE user_stats SET groupid = ",
						num,
						" WHERE id = ",
						class16_0.GetHabbo().Id,
						" LIMIT 1;"
					}));
				}
				DataTable dataTable_ = class16_0.GetHabbo().dataTable_0;
				if (dataTable_ != null)
				{
					ServerMessage gClass = new ServerMessage(915u);
					gClass.AppendInt32(dataTable_.Rows.Count);
					foreach (DataRow dataRow in dataTable_.Rows)
					{
						GroupsManager class2 = Groups.smethod_2((int)dataRow["groupid"]);
						gClass.AppendInt32(class2.int_0);
						gClass.AppendStringWithBreak(class2.string_0);
						gClass.AppendStringWithBreak(class2.string_2);
						if (class16_0.GetHabbo().int_0 == class2.int_0)
						{
							gClass.AppendBoolean(true);
						}
						else
						{
							gClass.AppendBoolean(false);
						}
					}
					class16_0.method_14(gClass);
					if (class16_0.GetHabbo().Boolean_0)
					{
						Room class14_ = class16_0.GetHabbo().Class14_0;
						Class33 class3 = class14_.method_53(class16_0.GetHabbo().Id);
						ServerMessage gClass2 = new ServerMessage(28u);
						gClass2.AppendInt32(1);
						class3.method_14(gClass2);
						class14_.SendMessage(gClass2, null);
						GroupsManager class4 = Groups.smethod_2(class16_0.GetHabbo().int_0);
						if (!class14_.list_17.Contains(class4))
						{
							class14_.list_17.Add(class4);
							ServerMessage gClass3 = new ServerMessage(309u);
							gClass3.AppendInt32(class14_.list_17.Count);
							foreach (GroupsManager class2 in class14_.list_17)
							{
								gClass3.AppendInt32(class2.int_0);
								gClass3.AppendStringWithBreak(class2.string_2);
							}
							class14_.SendMessage(gClass3, null);
						}
						else
						{
							foreach (GroupsManager current in class14_.list_17)
							{
								if (current == class4 && current.string_2 != class4.string_2)
								{
									ServerMessage gClass3 = new ServerMessage(309u);
									gClass3.AppendInt32(class14_.list_17.Count);
									foreach (GroupsManager class2 in class14_.list_17)
									{
										gClass3.AppendInt32(class2.int_0);
										gClass3.AppendStringWithBreak(class2.string_2);
									}
									class14_.SendMessage(gClass3, null);
								}
							}
						}
					}
				}
			}
		}
	}
}
