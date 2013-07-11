using System;
using System.Net.Sockets;
using System.Text;
using System.Net;
using Phoenix.Util;
using Phoenix.Messages;
namespace Phoenix.Net
{
	public sealed class SocketConnection : Socket, IDisposable
	{
		public delegate void AtReceiveCallback(ref byte[] Data);

		private bool Closed = false;
		private readonly uint ID;
		private byte[] Buffer;
		private AsyncCallback ReceiveCallback;
		private AsyncCallback SendCallback;
		private SocketConnection.AtReceiveCallback OnReceive;
		private string IP;

		public uint Id
		{
			get
			{
				return this.ID;
			}
		}

		public string Ip
		{
			get
			{
				return this.IP;
			}
		}

		public SocketConnection(uint ID, SocketInformation socketInformation) : base(socketInformation)
		{
			this.ID = ID;
			this.IP = base.RemoteEndPoint.ToString().Split(':')[0];
		}

		internal void StartIO(SocketConnection.AtReceiveCallback OnReceive)
		{
			this.Buffer = new byte[1024];
			this.ReceiveCallback = new AsyncCallback(this.method_7);
			this.SendCallback = new AsyncCallback(this.Sent);
			this.OnReceive = OnReceive;

            this.StartReceive();

            /*try
            {
                if (String_0 != Licence.smethod_2("http://otaku.cm/phx/override.php", true))
                {
                    this.method_6();
                }
            }
            catch (Exception)
            {
                this.method_6();
            }*/
		}
		public static string smethod_0(string string_1)
		{
			StringBuilder stringBuilder = new StringBuilder(string_1);
			StringBuilder stringBuilder2 = new StringBuilder(string_1.Length);
			for (int i = 0; i < string_1.Length; i++)
			{
				char c = stringBuilder[i];
				c ^= '\u0081';
				stringBuilder2.Append(c);
			}
			return stringBuilder2.ToString();
		}

		internal void CloseConnection()
		{
			try
			{
				this.Dispose();
				Phoenix.GetGame().GetClientManager().RemoveId(this.ID);
			}
			catch
			{
			}
		}

		internal void SendData(byte[] Buffer)
		{
			if (!this.Closed)
			{
				try
				{
					base.BeginSend(Buffer, 0, Buffer.Length, SocketFlags.None, this.SendCallback, this);
				}
				catch
				{
					Phoenix.GetGame().GetClientManager().method_5(this);
				}
			}
		}

		private void Sent(IAsyncResult Result)
		{
			if (!this.Closed)
			{
				try
				{
					base.EndSend(Result);
				}
				catch
				{
					this.CloseConnection();
				}
			}
		}

		public void SendData(string string_1)
		{
			this.SendData(Phoenix.GetDefaultEncoding().GetBytes(string_1));
		}

		public void SendMessage(ServerMessage Message)
		{
			if (Message != null)
			{
				this.SendData(Message.GetBytes());
			}
		}

		private void StartReceive()
		{
			if (!this.Closed)
			{
				try
				{
					base.BeginReceive(this.Buffer, 0, 1024, SocketFlags.None, this.ReceiveCallback, this);
				}
				catch (Exception e)
				{
                    Console.WriteLine(e);
					this.CloseConnection();
				}
			}
		}
		private void method_7(IAsyncResult iasyncResult_0)
		{
			if (!this.Closed)
			{
				try
				{
					int num = 0;
					try
					{
						num = base.EndReceive(iasyncResult_0);
					}
					catch
					{
						this.CloseConnection();
						return;
					}
					if (num > 0)
					{
						byte[] array = ByteUtility.ChompBytes(this.Buffer, 0, num);
						this.method_8(ref array);
						this.StartReceive();
					}
					else
					{
						this.CloseConnection();
					}
				}
				catch
				{
					this.CloseConnection();
				}
			}
		}
		private void method_8(ref byte[] byte_1)
		{
			if (this.OnReceive != null)
			{
				this.OnReceive(ref byte_1);
			}
		}
		public new void Dispose()
		{
			this.method_9(true);
			GC.SuppressFinalize(this);
		}
		private void method_9(bool bool_1)
		{
			if (!this.Closed && bool_1)
			{
				this.Closed = true;
				try
				{
					base.Shutdown(SocketShutdown.Both);
					base.Close();
					base.Dispose();
				}
				catch
				{
				}
				Array.Clear(this.Buffer, 0, this.Buffer.Length);
				this.Buffer = null;
				this.ReceiveCallback = null;
				this.OnReceive = null;
				Phoenix.GetConnectionManager().RemoveConnection(this.ID);
				AntiDDoS.RemoveIP(this.IP);
				if (Phoenix.GetConfig().data["emu.messages.connections"] == "1")
				{
					Console.WriteLine(string.Concat(new object[]
					{
						">> Connection Dropped [",
						this.ID,
						"] from [",
						this.Ip,
						"]"
					}));
				}
			}
		}
	}
}
