using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Users.Badges;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Inventory.Badges
{
	internal sealed class SetActivatedBadgesEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			class16_0.GetHabbo().method_22().method_5();
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				@class.ExecuteQuery("UPDATE user_badges SET badge_slot = '0' WHERE user_id = '" + class16_0.GetHabbo().Id + "'");
				goto IL_131;
			}
			IL_52:
			int num = class18_0.PopWiredInt32();
			string text = class18_0.PopFixedString();
			if (text.Length != 0)
			{
				if (!class16_0.GetHabbo().method_22().method_1(text) || num < 1 || num > 5)
				{
					return;
				}
				if (class16_0.GetHabbo().CurrentQuestId == 16u)
				{
					Phoenix.GetGame().GetQuestManager().method_1(16u, class16_0);
				}
				class16_0.GetHabbo().method_22().method_0(text).Slot = num;
				using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
				{
					@class.AddParamWithValue("slotid", num);
					@class.AddParamWithValue("badge", text);
					@class.AddParamWithValue("userid", class16_0.GetHabbo().Id);
					@class.ExecuteQuery("UPDATE user_badges SET badge_slot = @slotid WHERE badge_id = @badge AND user_id = @userid LIMIT 1");
				}
			}
			IL_131:
			if (class18_0.RemainingLength > 0)
			{
				goto IL_52;
			}
			ServerMessage gClass = new ServerMessage(228u);
			gClass.AppendUInt(class16_0.GetHabbo().Id);
			gClass.AppendInt32(class16_0.GetHabbo().method_22().Int32_1);
			foreach (UserBadge current in class16_0.GetHabbo().method_22().List_0)
			{
				if (current.Slot > 0)
				{
					gClass.AppendInt32(current.Slot);
					gClass.AppendStringWithBreak(current.Code);
				}
			}
			if (class16_0.GetHabbo().Boolean_0 && Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId) != null)
			{
				Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId).SendMessage(gClass, null);
			}
			else
			{
				class16_0.method_14(gClass);
			}
		}
	}
}
