using System;
using System.Net.Sockets;
using Phoenix.Core;
using Phoenix.Util;
namespace Phoenix.Net
{
	internal sealed class AntiDDoS
	{
		private static string[] Connections;
		private static string LastConnection;

		internal static void Load(int MaxCache)
		{
			AntiDDoS.Connections = new string[MaxCache];
		}

		internal static bool Check(Socket Connection)
		{
			string IP = Connection.RemoteEndPoint.ToString().Split(new char[]
			{
				':'
			})[0];
			if (IP == AntiDDoS.LastConnection)
			{
				return false;
			}
			else
			{
				if (AntiDDoS.CheckConnections(IP) > 10 && IP != "127.0.0.1" && !Config.AntiDDoSOff)
				{
					Console.ForegroundColor = ConsoleColor.Blue;
					Console.WriteLine(IP + " was banned by Anti-DDoS system.");
					Console.ForegroundColor = ConsoleColor.White;
                    Logging.LogDDoS(IP + " - " + DateTime.Now.ToString());
					AntiDDoS.LastConnection = IP;
					return false;
				}
				else
				{
					int EmptySpot = AntiDDoS.GetEmptySpot();

					if (EmptySpot < 0)
					{
						return false;
					}
					else
					{
						AntiDDoS.Connections[EmptySpot] = IP;
						return true;
					}
				}
			}
		}
		private static int CheckConnections(string IP)
		{
			int num = 0;
			for (int i = 0; i < AntiDDoS.Connections.Length; i++)
			{
				if (AntiDDoS.Connections[i] == IP)
				{
					num++;
				}
			}
			return num;
		}
		internal static void RemoveIP(string IP)
		{
			for (int i = 0; i < AntiDDoS.Connections.Length; i++)
			{
				if (AntiDDoS.Connections[i] == IP)
				{
					AntiDDoS.Connections[i] = null;
					return;
				}
			}
		}
		private static int GetEmptySpot()
		{
			for (int i = 0; i < AntiDDoS.Connections.Length; i++)
			{
				if (AntiDDoS.Connections[i] == null)
				{
					return i;
				}
			}

			return -1;
		}
	}
}
