using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Items;
namespace Phoenix.HabboHotel.Items.Interactors
{
	internal sealed class Class74 : Class69
	{
		public override void OnPlace(GameClient class16_0, UserItemData class63_0)
		{
		}
		public override void OnRemove(GameClient class16_0, UserItemData class63_0)
		{
		}
		public override void OnTrigger(GameClient class16_0, UserItemData class63_0, int int_0, bool bool_0)
		{
			if (bool_0)
			{
				class63_0.method_9();
				ServerMessage gClass = new ServerMessage(651u);
				gClass.AppendInt32(0);
				gClass.AppendInt32(5);
				if (class63_0.string_5.Length > 0)
				{
					gClass.AppendString(class63_0.string_5);
				}
				else
				{
					gClass.AppendInt32(0);
				}
				gClass.AppendInt32(class63_0.GetBaseItem().int_0);
				gClass.AppendUInt(class63_0.uint_0);
				gClass.AppendStringWithBreak("");
				gClass.AppendString("J");
				if (class63_0.string_2.Length > 0)
				{
					gClass.AppendInt32(Convert.ToInt32(class63_0.string_2));
				}
				else
				{
					gClass.AppendInt32(0);
				}
				if (class63_0.string_3.Length > 0)
				{
					gClass.AppendInt32(Convert.ToInt32(class63_0.string_3));
				}
				else
				{
					gClass.AppendInt32(0);
				}
				gClass.AppendString("HPA");
				if (class63_0.string_6.Length > 0)
				{
					gClass.AppendInt32(Convert.ToInt32(class63_0.string_6));
				}
				else
				{
					gClass.AppendInt32(0);
				}
				gClass.AppendStringWithBreak("H");
				class16_0.method_14(gClass);
			}
		}
	}
}
