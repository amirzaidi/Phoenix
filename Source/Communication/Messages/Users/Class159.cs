using System;
using System.Data;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Users
{
	internal sealed class Class159 : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			DataTable dataTable_ = class16_0.GetHabbo().dataTable_0;
			if (dataTable_ != null)
			{
				ServerMessage gClass = new ServerMessage(915u);
				gClass.AppendInt32(dataTable_.Rows.Count);
				foreach (DataRow dataRow in dataTable_.Rows)
				{
					GroupsManager @class = Groups.smethod_2((int)dataRow["groupid"]);
					gClass.AppendInt32(@class.int_0);
					gClass.AppendStringWithBreak(@class.string_0);
					gClass.AppendStringWithBreak(@class.string_2);
					if (class16_0.GetHabbo().int_0 == @class.int_0)
					{
						gClass.AppendBoolean(true);
					}
					else
					{
						gClass.AppendBoolean(false);
					}
				}
				class16_0.method_14(gClass);
			}
		}
	}
}
