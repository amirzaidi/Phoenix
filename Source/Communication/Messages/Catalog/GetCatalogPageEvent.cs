using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Catalogs;
namespace Phoenix.Communication.Messages.Catalog
{
	internal sealed class GetCatalogPageEvent : Interface
	{
		public void imethod_0(GameClient Session, ClientMessage class18_0)
		{
			Class48 @class = Phoenix.GetGame().GetCatalog().method_5(class18_0.PopWiredInt32());
			if (@class != null && @class.bool_1 && @class.bool_0 && @class.uint_0 <= Session.GetHabbo().uint_1)
			{
				if (@class.bool_2 && !Session.GetHabbo().method_20().method_2("habbo_club"))
				{
					Session.SendNotif("This page is for Phoenix Club members only!");
				}
				else
				{
					Session.method_14(@class.GClass5_0);
					if (@class.string_1 == "recycler")
					{
						ServerMessage gClass = new ServerMessage(507u);
						gClass.AppendBoolean(true);
						gClass.AppendBoolean(false);
						Session.method_14(gClass);
					}
					else
					{
						if (@class.string_1 == "club_buy")
						{
							ServerMessage gClass2 = new ServerMessage(625u);
							if (Session.GetHabbo().bool_14)
							{
								gClass2.AppendInt32(2);
								gClass2.AppendInt32(4535);
								gClass2.AppendStringWithBreak("HABBO_CLUB_VIP_1_MONTH");
								gClass2.AppendInt32(25);
								gClass2.AppendInt32(0);
								gClass2.AppendInt32(1);
								gClass2.AppendInt32(1);
								gClass2.AppendInt32(101);
								gClass2.AppendInt32(DateTime.Today.AddDays(30.0).Year);
								gClass2.AppendInt32(DateTime.Today.AddDays(30.0).Month);
								gClass2.AppendInt32(DateTime.Today.AddDays(30.0).Day);
								gClass2.AppendInt32(4536);
								gClass2.AppendStringWithBreak("HABBO_CLUB_VIP_3_MONTHS");
								gClass2.AppendInt32(60);
								gClass2.AppendInt32(0);
								gClass2.AppendInt32(1);
								gClass2.AppendInt32(3);
								gClass2.AppendInt32(163);
								gClass2.AppendInt32(DateTime.Today.AddDays(90.0).Year);
								gClass2.AppendInt32(DateTime.Today.AddDays(90.0).Month);
								gClass2.AppendInt32(DateTime.Today.AddDays(90.0).Day);
							}
							else
							{
								gClass2.AppendInt32(4);
								gClass2.AppendInt32(4533);
								gClass2.AppendStringWithBreak("HABBO_CLUB_BASIC_1_MONTH");
								gClass2.AppendInt32(15);
								gClass2.AppendInt32(0);
								gClass2.AppendInt32(0);
								gClass2.AppendInt32(1);
								gClass2.AppendInt32(31);
								gClass2.AppendInt32(DateTime.Today.AddDays(30.0).Year);
								gClass2.AppendInt32(DateTime.Today.AddDays(30.0).Month);
								gClass2.AppendInt32(DateTime.Today.AddDays(30.0).Day);
								gClass2.AppendInt32(4534);
								gClass2.AppendStringWithBreak("HABBO_CLUB_BASIC_3_MONTHS");
								gClass2.AppendInt32(45);
								gClass2.AppendInt32(0);
								gClass2.AppendInt32(0);
								gClass2.AppendInt32(3);
								gClass2.AppendInt32(93);
								gClass2.AppendInt32(DateTime.Today.AddDays(90.0).Year);
								gClass2.AppendInt32(DateTime.Today.AddDays(90.0).Month);
								gClass2.AppendInt32(DateTime.Today.AddDays(90.0).Day);
								gClass2.AppendInt32(4535);
								gClass2.AppendStringWithBreak("HABBO_CLUB_VIP_1_MONTH");
								gClass2.AppendInt32(25);
								gClass2.AppendInt32(0);
								gClass2.AppendInt32(1);
								gClass2.AppendInt32(1);
								gClass2.AppendInt32(101);
								gClass2.AppendInt32(DateTime.Today.AddDays(30.0).Year);
								gClass2.AppendInt32(DateTime.Today.AddDays(30.0).Month);
								gClass2.AppendInt32(DateTime.Today.AddDays(30.0).Day);
								gClass2.AppendInt32(4536);
								gClass2.AppendStringWithBreak("HABBO_CLUB_VIP_3_MONTHS");
								gClass2.AppendInt32(60);
								gClass2.AppendInt32(0);
								gClass2.AppendInt32(1);
								gClass2.AppendInt32(3);
								gClass2.AppendInt32(163);
								gClass2.AppendInt32(DateTime.Today.AddDays(90.0).Year);
								gClass2.AppendInt32(DateTime.Today.AddDays(90.0).Month);
								gClass2.AppendInt32(DateTime.Today.AddDays(90.0).Day);
							}
							Session.method_14(gClass2);
						}
					}
				}
			}
		}
	}
}
