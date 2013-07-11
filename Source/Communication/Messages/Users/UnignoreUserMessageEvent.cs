using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Users
{
	internal sealed class UnignoreUserMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room class14_ = class16_0.GetHabbo().Class14_0;
			if (class14_ != null)
			{
				class18_0.PopWiredUInt();
				string string_ = class18_0.PopFixedString();
				Class33 @class = class14_.method_56(string_);
				if (@class != null)
				{
					uint uint_ = @class.method_16().GetHabbo().Id;
					if (class16_0.GetHabbo().list_2.Contains(uint_))
					{
						class16_0.GetHabbo().list_2.Remove(uint_);
						using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
						{
							class2.ExecuteQuery(string.Concat(new object[]
							{
								"DELETE FROM user_ignores WHERE user_id = ",
								class16_0.GetHabbo().Id,
								" AND ignore_id = ",
								uint_,
								" LIMIT 1;"
							}));
						}
						ServerMessage gClass = new ServerMessage(419u);
						gClass.AppendInt32(3);
						class16_0.method_14(gClass);
					}
				}
			}
		}
	}
}
