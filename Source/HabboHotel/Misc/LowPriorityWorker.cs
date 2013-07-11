using System;
using System.Diagnostics;
using System.Threading;
using Phoenix.Core;
using Phoenix.Storage;
namespace Phoenix.HabboHotel.Misc
{
	public sealed class LowPriorityWorker
	{
		public static void smethod_0()
		{
			while (true)
			{
				try
				{
					DateTime now = DateTime.Now;
					TimeSpan timeSpan = now - Phoenix.ServerStarted;
					new PerformanceCounter("Processor", "% Processor Time", "_Total");
					int Status = 1;
					int UsersOnline = Phoenix.GetGame().GetClientManager().ClientCount + -1;
					int RoomsLoaded = Phoenix.GetGame().GetRoomManager().LoadedRoomsCount;
					bool flag = true;
					try
					{
						if (int.Parse(Phoenix.GetConfig().data["debug"]) == 1)
						{
							flag = false;
						}
					}
					catch
					{
					}
					if (flag)
					{
						using (DatabaseClient adapter = Phoenix.GetDatabase().GetClient())
						{
							adapter.ExecuteQuery(string.Concat(new object[]
							{
								"UPDATE server_status SET stamp = UNIX_TIMESTAMP(), status = '", Status, "', users_online = '",	UsersOnline, "', rooms_loaded = '",	RoomsLoaded, "', server_ver = '", Phoenix.PrettyVersion,	"' LIMIT 1" 	}));
							uint num3 = (uint)adapter.ReadInt32("SELECT users FROM system_stats ORDER BY ID DESC LIMIT 1");
							if ((long)UsersOnline > (long)((ulong)num3))
							{
								adapter.ExecuteQuery(string.Concat(new object[]
								{
									"UPDATE system_stats SET users = '",
									UsersOnline,
									"', rooms = '",
									RoomsLoaded,
									"' ORDER BY ID DESC LIMIT 1"
								}));
							}
						}
					}
					Phoenix.GetGame().GetClientManager().method_23();
					Console.Title = string.Concat(new object[]
					{
						"Phoenix 3.0 | Online Users: ",
						UsersOnline,
						" | Rooms Loaded: ",
						RoomsLoaded,
						" | Uptime: ",
						timeSpan.Days,
						" days, ",
						timeSpan.Hours,
						" hours and ",
						timeSpan.Minutes,
						" minutes"
					});
				}
				catch (Exception ex)
				{
                    Logging.LogThreadException(ex.ToString(), "Server status update task");
				}
				Thread.Sleep(5000);
			}
		}
	}
}
