using System;
using System.Data;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Avatar
{
    internal sealed class GetWardrobeMessageEvent : Interface
    {
        public void imethod_0(GameClient class16_0, ClientMessage class18_0)
        {
            ServerMessage gClass = new ServerMessage(267u);
            gClass.AppendBoolean(class16_0.GetHabbo().method_20().method_2("habbo_club"));
            if (class16_0.GetHabbo().method_20().method_2("habbo_club"))
            {
                using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
                {
                    @class.AddParamWithValue("userid", class16_0.GetHabbo().Id);
                    DataTable dataTable = @class.ReadDataTable("SELECT slot_id, look, gender FROM user_wardrobe WHERE user_id = @userid;");
                    if (dataTable == null)
                    {
                        gClass.AppendInt32(0);
                    }
                    else
                    {
                        gClass.AppendInt32(dataTable.Rows.Count);
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            gClass.AppendUInt((uint)dataRow["slot_id"]);
                            gClass.AppendStringWithBreak((string)dataRow["look"]);
                            gClass.AppendStringWithBreak((string)dataRow["gender"]);
                        }
                    }
                }
                class16_0.method_14(gClass);
            }
            else
            {
                using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
                {
                    @class.AddParamWithValue("userid", class16_0.GetHabbo().Id);
                    DataTable dataTable = @class.ReadDataTable("SELECT slot_id, look, gender FROM user_wardrobe WHERE user_id = @userid;");
                    if (dataTable == null)
                    {
                        gClass.AppendInt32(0);
                    }
                    else
                    {
                        gClass.AppendInt32(dataTable.Rows.Count);
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            gClass.AppendUInt((uint)dataRow["slot_id"]);
                            gClass.AppendStringWithBreak((string)dataRow["look"]);
                            gClass.AppendStringWithBreak((string)dataRow["gender"]);
                        }
                    }
                }
                class16_0.method_14(gClass);
            }
        }
    }
}