using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Items;
namespace Phoenix.HabboHotel.Items.Interactors
{
	internal sealed class Class72 : Class69
	{
		public override void OnPlace(GameClient class16_0, UserItemData class63_0)
		{
		}
		public override void OnRemove(GameClient class16_0, UserItemData class63_0)
		{
		}
		public override void OnTrigger(GameClient class16_0, UserItemData class63_0, int int_0, bool bool_0)
		{
			if (bool_0 && class16_0 != null)
			{
				class63_0.method_10();
				ServerMessage gClass = new ServerMessage(652u);
				gClass.AppendInt32(0);
				gClass.AppendInt32(5);
				if (class63_0.string_2.Length > 0)
				{
					gClass.AppendString(class63_0.string_2);
				}
				else
				{
					gClass.AppendInt32(0);
				}
				gClass.AppendInt32(class63_0.GetBaseItem().int_0);
				gClass.AppendUInt(class63_0.uint_0);
				gClass.AppendStringWithBreak("");
				gClass.AppendStringWithBreak("HH");
				class16_0.method_14(gClass);
			}
		}
	}
}
