using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Items;
namespace Phoenix.HabboHotel.Items.Interactors
{
	internal sealed class Class73 : Class69
	{
		public override void OnPlace(GameClient Session, UserItemData Item)
		{
		}
		public override void OnRemove(GameClient Session, UserItemData Item)
		{
		}
		public override void OnTrigger(GameClient Session, UserItemData Item, int Request, bool UserHasRights)
		{
			if (UserHasRights && Session != null)
			{
				Item.method_9();
				ServerMessage gClass = new ServerMessage(651u);
				gClass.AppendInt32(0);
				gClass.AppendInt32(5);
				if (Item.string_5.Length > 0)
				{
					gClass.AppendString(Item.string_5);
				}
				else
				{
					gClass.AppendInt32(0);
				}
				gClass.AppendInt32(Item.GetBaseItem().int_0);
				gClass.AppendUInt(Item.uint_0);
				gClass.AppendStringWithBreak("");
				gClass.AppendString("K");
				if (Item.string_3.Length > 0)
				{
					gClass.AppendString(Item.string_3);
				}
				else
				{
					gClass.AppendString("HHH");
				}
				gClass.AppendString("IK");
				if (Item.string_6.Length > 0)
				{
					gClass.AppendInt32(Convert.ToInt32(Item.string_6));
				}
				else
				{
					gClass.AppendInt32(0);
				}
				gClass.AppendStringWithBreak("H");
				Session.method_14(gClass);
			}
		}
	}
}
