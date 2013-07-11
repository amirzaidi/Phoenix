using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Sound
{
	internal sealed class SetSoundSettingsEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			int num = class18_0.PopWiredInt32();
			if (num < 0)
			{
				num = 0;
			}
			else
			{
				if (num > 100)
				{
					num = 100;
				}
			}
			class16_0.GetHabbo().int_11 = num;
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				@class.AddParamWithValue("user_id", class16_0.GetHabbo().Id);
				@class.AddParamWithValue("volume", num);
				@class.ExecuteQuery("UPDATE users SET volume = @volume WHERE id = @user_id LIMIT 1;");
			}
		}
	}
}
