using System;
using Phoenix.HabboHotel.Misc;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Avatar
{
	internal sealed class SaveWardrobeOutfitMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			uint num = class18_0.PopWiredUInt();
			string text = class18_0.PopFixedString();
			string text2 = class18_0.PopFixedString();
			//if (AntiMutant.smethod_0(text, text2))
			{
				using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
				{
					@class.AddParamWithValue("userid", class16_0.GetHabbo().Id);
					@class.AddParamWithValue("slotid", num);
					@class.AddParamWithValue("look", text);
					@class.AddParamWithValue("gender", text2.ToUpper());
					if (@class.ReadDataRow("SELECT null FROM user_wardrobe WHERE user_id = @userid AND slot_id = @slotid LIMIT 1") != null)
					{
						@class.ExecuteQuery("UPDATE user_wardrobe SET look = @look, gender = @gender WHERE user_id = @userid AND slot_id = @slotid LIMIT 1;");
					}
					else
					{
						@class.ExecuteQuery("INSERT INTO user_wardrobe (user_id,slot_id,look,gender) VALUES (@userid,@slotid,@look,@gender)");
					}
				}
			}
		}
	}
}
