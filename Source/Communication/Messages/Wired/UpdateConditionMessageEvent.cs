using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Items;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Wired
{
	internal sealed class UpdateConditionMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			try
			{
				Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
				uint uint_ = class18_0.PopWiredUInt();
				UserItemData class2 = @class.method_28(uint_);
				string text = class2.GetBaseItem().InteractionType.ToLower();
				if (text != null && (text == "wf_cnd_trggrer_on_frn" || text == "wf_cnd_furnis_hv_avtrs" || text == "wf_cnd_has_furni_on"))
				{
					class18_0.PopWiredBoolean();
					class18_0.PopFixedString();
					class2.string_2 = class18_0.ToString().Substring(class18_0.Length - (class18_0.RemainingLength - 2));
					class2.string_2 = class2.string_2.Substring(0, class2.string_2.Length - 1);
					class18_0.ResetPointer();
					class2 = @class.method_28(class18_0.PopWiredUInt());
					class18_0.PopWiredBoolean();
					class18_0.PopFixedString();
					int num = class18_0.PopWiredInt32();
					class2.string_3 = "";
					for (int i = 0; i < num; i++)
					{
						class2.string_3 = class2.string_3 + "," + Convert.ToString(class18_0.PopWiredUInt());
					}
					if (class2.string_3.Length > 0)
					{
						class2.string_3 = class2.string_3.Substring(1);
					}
				}
			}
			catch
			{
			}
		}
	}
}
