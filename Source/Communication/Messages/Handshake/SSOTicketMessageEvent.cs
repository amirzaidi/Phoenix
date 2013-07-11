using System;
using Phoenix.Core;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Handshake
{
	internal sealed class SSOTicketMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0.GetHabbo() == null)
			{
				class16_0.method_6(class18_0.PopFixedString());
				if (class16_0.GetHabbo() != null && class16_0.GetHabbo().list_2 != null && class16_0.GetHabbo().list_2.Count > 0)
				{
					using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
					{
						try
						{
							ServerMessage gClass = new ServerMessage(420u);
							gClass.AppendInt32(class16_0.GetHabbo().list_2.Count);
							foreach (uint current in class16_0.GetHabbo().list_2)
							{
								string string_ = @class.ReadString("SELECT username FROM users WHERE id = " + current + " LIMIT 1;");
								gClass.AppendStringWithBreak(string_);
							}
							class16_0.method_14(gClass);
						}
						catch
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Logging.WriteLine("Login error: User is ignoring a user that no longer exists");
							Console.ForegroundColor = ConsoleColor.Gray;
						}

					}
				}
			}
		}
	}
}
