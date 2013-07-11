using System;
using System.Threading;
using Phoenix.Core;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Util;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.HabboHotel.Misc
{
	internal sealed class PixelManager
	{
		public bool KeepAlive;
		private Thread WorkerThread;
		public PixelManager()
		{
			this.KeepAlive = true;
			this.WorkerThread = new Thread(new ThreadStart(this.method_1));
			this.WorkerThread.Name = "Pixel Manager";
			this.WorkerThread.Priority = ThreadPriority.Lowest;
		}
		public void method_0()
		{
			Logging.Write("Starting Reward Timer..");
			this.WorkerThread.Start();
			Logging.WriteLine("completed!");
		}
		private void method_1()
		{
			try
			{
				while (this.KeepAlive)
				{
					if (Phoenix.GetGame() != null && Phoenix.GetGame().GetClientManager() != null)
					{
						Phoenix.GetGame().GetClientManager().method_29();
					}
					Thread.Sleep(15000);
				}
			}
			catch (ThreadAbortException)
			{
			}
		}
		public bool method_2(GameClient class16_0)
		{
			double num = (Phoenix.GetUnixTimestamp() - class16_0.GetHabbo().LastActivityPointsUpdate) / 60.0;
			return num >= (double)Config.Int32_0;
		}
		public void method_3(GameClient class16_0)
		{
			try
			{
				if (class16_0.GetHabbo().Boolean_0)
				{
					Class33 @class = class16_0.GetHabbo().Class14_0.method_53(class16_0.GetHabbo().Id);
					if (@class.int_1 <= Config.int_14)
					{
						double double_ = Phoenix.GetUnixTimestamp();
						class16_0.GetHabbo().LastActivityPointsUpdate = double_;
						if (Config.Int32_3 > 0 && (class16_0.GetHabbo().ActivityPoints < Config.int_3 || Config.int_3 == 0))
						{
							class16_0.GetHabbo().ActivityPoints += Config.Int32_3;
							class16_0.GetHabbo().method_16(Config.Int32_3);
						}
						if (Config.Int32_1 > 0 && (class16_0.GetHabbo().Credits < Config.int_5 || Config.int_5 == 0))
						{
							class16_0.GetHabbo().Credits += Config.Int32_1;
							if (class16_0.GetHabbo().bool_14)
							{
								class16_0.GetHabbo().Credits += Config.Int32_1;
							}
							class16_0.GetHabbo().method_13(true);
						}
						if (Config.Int32_2 > 0 && (class16_0.GetHabbo().VipPoints < Config.int_4 || Config.int_4 == 0))
						{
							class16_0.GetHabbo().VipPoints += Config.Int32_2;
							class16_0.GetHabbo().method_14(false, true);
						}
					}
				}
			}
			catch
			{
			}
		}
	}
}
