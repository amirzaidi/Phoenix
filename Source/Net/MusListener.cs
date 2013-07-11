using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using Phoenix.Core;
namespace Phoenix.Net
{
	internal sealed class MusListener
	{
		public Socket Master;
		public string string_0;
		public int MUSPort;
		public HashSet<string> hashSet_0;
		public MusListener(string string_1, int Port, string[] string_2, int int_2)
		{
			this.string_0 = "localhost";
			this.MUSPort = Port;
			this.hashSet_0 = new HashSet<string>();
			this.hashSet_0.Add(Phoenix.string_5);
			for (int i = 0; i < string_2.Length; i++)
			{
				string item = string_2[i];
				this.hashSet_0.Add(item);
			}
			try
			{
				this.Master = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				this.Master.Bind(new IPEndPoint(IPAddress.Parse(Phoenix.GetConfig().data["mus.tcp.bindip"]), this.MUSPort));
				this.Master.Listen(int_2);
				this.Master.BeginAccept(new AsyncCallback(this.method_0), this.Master);
				Logging.WriteLine("Listening for MUS on port: " + this.MUSPort);
			}
			catch (Exception ex)
			{
				throw new Exception("Could not set up MUS socket:\n" + ex.ToString());
			}
		}
		public void method_0(IAsyncResult iasyncResult_0)
		{
			try
			{
				Socket socket = ((Socket)iasyncResult_0.AsyncState).EndAccept(iasyncResult_0);
				string item = socket.RemoteEndPoint.ToString().Split(new char[]
				{
					':'
				})[0];
				if (this.hashSet_0.Contains(item))
				{
					new MUSSocketConnection(socket);
				}
				else
				{
					socket.Close();
				}
			}
			catch (Exception)
			{
			}
			this.Master.BeginAccept(new AsyncCallback(this.method_0), this.Master);
		}
	}
}
