using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Items;
namespace Phoenix.HabboHotel.Items.Interactors
{
	internal sealed class Class81 : Class69
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
				ServerMessage gClass = new ServerMessage(651u);
				gClass.AppendInt32(0);
				gClass.AppendInt32(0);
				gClass.AppendInt32(0);
				gClass.AppendInt32(class63_0.GetBaseItem().int_0);
				gClass.AppendUInt(class63_0.uint_0);
				gClass.AppendStringWithBreak(class63_0.string_2);
				gClass.AppendStringWithBreak("HHSAHH");
				class16_0.method_14(gClass);
			}
		}
	}
}
