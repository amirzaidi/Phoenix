using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using Phoenix.Core;
namespace Phoenix.Net
{
	internal sealed class SocketListener
	{
        //private const int IDK = 1;
		private Socket Master;
		private bool Running;
		private AsyncCallback OnAccept;
		private int CurrentProcessId;
		private SocketsManager Manager;
		/*public bool Boolean_0
		{
			get
			{
				return this.Boolean_0;
			}

		}*/

		public SocketListener(/*string string_0, */int Port, SocketsManager LocalManager)
		{
            this.CurrentProcessId = Process.GetCurrentProcess().Id;
			this.Master = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			IPEndPoint localEP = new IPEndPoint(IPAddress.Parse(Phoenix.GetConfig().data["game.tcp.bindip"]), Port);
			this.Master.Bind(localEP);
			this.Master.Listen(1000);
			this.OnAccept = new AsyncCallback(this.Accept);
			this.Manager = LocalManager;
			AntiDDoS.Load(20000);
			Logging.WriteLine("Listening for connections on port: " + Port);
		}

		public void Start()
		{
			if (!this.Running)
			{
				this.Running = true;
				this.Master.BeginAccept(this.OnAccept, this.Master);
			}
		}
		public void Close()
		{
			if (this.Running)
			{
				this.Running = false;
				try
				{
					this.Master.Close();
				}
				catch
				{
				}
				Console.WriteLine("Listener -> Stopped!");
			}
		}
		public void CloseAndFree()
		{
			this.Close();
			this.Master = null;
			this.Manager = null;
		}
		private void StartAccept()
		{
			try
			{
				this.Master.BeginAccept(this.OnAccept, this.Master);
			}
			catch
			{
			}
		}
		private void Accept(IAsyncResult Result)
		{
			if (this.Running)
			{
				try
				{
					int FreeId = this.Manager.GetNullIndex();
					if (FreeId > -1)
					{
						Socket socket = ((Socket)Result.AsyncState).EndAccept(Result);
						if (AntiDDoS.Check(socket))
						{
                            this.Manager.NewConnection(socket.DuplicateAndClose(this.CurrentProcessId), FreeId);
						}
						else
						{
							try
							{
								socket.Dispose();
								socket.Close();
							}
							catch
							{
							}
						}
					}
				}
				catch (Exception ex)
				{
                    Logging.LogException("[TCPListener.OnRequest]: Could not handle new connection request: " + ex.ToString());
				}
				finally
				{
					this.StartAccept();
				}
			}
		}
		internal void ShutdownAndDispose()
		{
			this.Running = false;
			try
			{
				this.Master.Shutdown(SocketShutdown.Both);
				this.Master.Close();
				this.Master.Dispose();
			}
			catch
			{
			}
		}
	}
}
