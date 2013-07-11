using System;
using System.Net.Sockets;
using Phoenix.Core;
namespace Phoenix.Net
{
	internal sealed class SocketsManager
	{
		private SocketConnection[] Connections;
		private SocketListener Listener;

		public int ConnectionCount
		{
			get
			{
				int num = 0;
				for (int i = 0; i < this.Connections.Length; i++)
				{
					if (this.Connections[i] != null)
					{
						num++;
					}
				}

				return num;
			}
		}

		public SocketsManager(/*string string_0, */int Port, int MaxConnections)
		{
			this.Connections = new SocketConnection[MaxConnections];
			this.Listener = new SocketListener(/*string_0, */Port, this);
		}

		public void Close()
		{
			for (int i = 0; i < this.Connections.Length; i++)
			{
				if (this.Connections[i] != null)
				{
					this.Connections[i].Dispose();
				}
			}

			this.Connections = null;
			this.Listener = null;
		}

		public bool IsConnected(uint Id)
		{
			return this.Connections[(int)((UIntPtr)Id)] != null;
		}

		public SocketConnection GetConnection(uint Id)
		{
			return this.Connections[(int)((UIntPtr)Id)];
		}

		public SocketListener GetListener()
		{
			return this.Listener;
		}
		internal int GetNullIndex()
		{
			return Array.IndexOf<SocketConnection>(this.Connections, null);
		}
		internal void NewConnection(SocketInformation socketInformation, int Id)
		{
			SocketConnection Connection = new SocketConnection(Convert.ToUInt32(Id), socketInformation);
			this.Connections[Id] = Connection;
			Phoenix.GetGame().GetClientManager().LoadGame((uint)Id, ref Connection);
			if (Phoenix.GetConfig().data["emu.messages.connections"] == "1")
			{
				Logging.WriteLine(string.Concat(new object[]
				{
					">> Connection [",
					Id,
					"] from [",
					Connection.Ip,
					"]"
				}));
			}
		}

		internal void RemoveConnection(uint Id)
		{
			this.Connections[(int)((UIntPtr)Id)] = null;
		}

		internal void DisconnectAll()
		{
			this.Listener.ShutdownAndDispose();
			for (int i = 0; i < this.Connections.Length; i++)
			{
				if (this.Connections[i] != null)
				{
					this.Connections[i].Dispose();
				}
			}
		}
	}
}
