using System;
using System.Data;
using System.Text.RegularExpressions;
using Phoenix.Core;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Advertisements;
using Phoenix.HabboHotel.Items;
using Phoenix.Storage;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Messages
{
	internal sealed class GameClientMessageHandler
	{
		private delegate void Delegate();
		private const int HIGHEST_MESSAGE_ID = 4004;
		private GameClient Session;
		private ClientMessage Request;
		private ServerMessage Response;
		private GameClientMessageHandler.Delegate[] RequestHandlers;
		public GameClientMessageHandler(GameClient Session)
		{
			this.Session = Session;
            this.RequestHandlers = new GameClientMessageHandler.Delegate[HIGHEST_MESSAGE_ID];
			this.Response = new ServerMessage(0);
		}
		public ServerMessage GetResponse()
		{
			return this.Response;
		}
		public void Destroy()
		{
			this.Session = null;
			this.RequestHandlers = null;
			this.Request = null;
			this.Response = null;
		}
		public void HandleRequest(ClientMessage Request)
		{
			uint arg_06_0 = Request.Id;
            if (Request.Id > HIGHEST_MESSAGE_ID)
			{
				Logging.WriteLine("Warning - out of protocol request: " + Request.Header);
			}
			else
			{
				if (this.RequestHandlers[(int)((UIntPtr)Request.Id)] != null && Request != null)
				{
					this.Request = Request;
					this.RequestHandlers[(int)((UIntPtr)Request.Id)]();
					this.Request = null;
				}
			}
		}
		public void method_3()
		{
			if (this.Response != null && this.Response.Id > 0u && this.Session.GetConnection() != null)
			{
				this.Session.GetConnection().SendMessage(this.Response);
			}
		}
		public void method_4()
		{
			RoomAdvertisement @class = Phoenix.GetGame().GetAdvertisementManager().method_1();
			this.Response.Init(258);
			if (@class == null)
			{
				this.Response.AppendStringWithBreak("");
				this.Response.AppendStringWithBreak("");
			}
			else
			{
				this.Response.AppendStringWithBreak(@class.string_0);
				this.Response.AppendStringWithBreak(@class.string_1);
				@class.method_0();
			}
			this.method_3();
		}
		public void method_5(uint uint_0, string string_0)
		{
			this.method_7();
			if (Phoenix.GetGame().GetRoomManager().method_12(uint_0) != null)
			{
				if (this.Session.GetHabbo().Boolean_0)
				{
					Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(this.Session.GetHabbo().CurrentRoomId);
					if (@class != null)
					{
						@class.method_47(this.Session, false, false);
					}
				}
				Room class2 = Phoenix.GetGame().GetRoomManager().method_15(uint_0);
				if (class2 != null)
				{
					this.Session.GetHabbo().uint_2 = uint_0;
					if (class2.method_68(this.Session.GetHabbo().Id))
					{
						if (!class2.method_71(this.Session.GetHabbo().Id))
						{
							ServerMessage gClass = new ServerMessage(224u);
							gClass.AppendInt32(4);
							this.Session.method_14(gClass);
							ServerMessage gClass2 = new ServerMessage(18u);
							this.Session.method_14(gClass2);
							return;
						}
						class2.method_69(this.Session.GetHabbo().Id);
					}
					if (class2.UsersNow >= class2.UsersMax && !Phoenix.GetGame().GetRoleManager().method_1(this.Session.GetHabbo().uint_1, "acc_enter_fullrooms") && !this.Session.GetHabbo().bool_14)
					{
						ServerMessage gClass = new ServerMessage(224u);
						gClass.AppendInt32(1);
						this.Session.method_14(gClass);
						ServerMessage gClass2 = new ServerMessage(18u);
						this.Session.method_14(gClass2);
					}
					else
					{
						if (class2.Type == "public")
						{
							if (class2.State > 0 && !this.Session.GetHabbo().HasFuse("acc_restrictedrooms"))
							{
								this.Session.SendNotif("This public room is accessible to Phoenix staff only.");
								ServerMessage gClass2 = new ServerMessage(18u);
								this.Session.method_14(gClass2);
								return;
							}
							ServerMessage gClass3 = new ServerMessage(166u);
							gClass3.AppendStringWithBreak("/client/public/" + class2.ModelName + "/0");
							this.Session.method_14(gClass3);
						}
						else
						{
							if (class2.Type == "private")
							{
								ServerMessage Logging = new ServerMessage(19u);
								this.Session.method_14(Logging);
								if (this.Session.GetHabbo().bool_7)
								{
									UserItemData class3 = class2.method_28(this.Session.GetHabbo().uint_5);
									if (class3 == null)
									{
										this.Session.GetHabbo().bool_7 = false;
										this.Session.GetHabbo().uint_5 = 0u;
										ServerMessage gClass5 = new ServerMessage(131u);
										this.Session.method_14(gClass5);
										return;
									}
								}
								if (!this.Session.GetHabbo().HasFuse("acc_enter_anyroom") && !class2.method_27(this.Session, true) && !this.Session.GetHabbo().bool_7)
								{
									if (class2.State == 1)
									{
										if (class2.Int32_0 == 0)
										{
											ServerMessage gClass5 = new ServerMessage(131u);
											this.Session.method_14(gClass5);
											return;
										}
										ServerMessage gClass6 = new ServerMessage(91u);
										gClass6.AppendStringWithBreak("");
										this.Session.method_14(gClass6);
										this.Session.GetHabbo().bool_6 = true;
										ServerMessage gClass7 = new ServerMessage(91u);
										gClass7.AppendStringWithBreak(this.Session.GetHabbo().Username);
										class2.method_61(gClass7);
										return;
									}
									else
									{
										if (class2.State == 2 && string_0.ToLower() != class2.Password.ToLower())
										{
											ServerMessage gClass8 = new ServerMessage(33u);
											gClass8.AppendInt32(-100002);
											this.Session.method_14(gClass8);
											ServerMessage gClass2 = new ServerMessage(18u);
											this.Session.method_14(gClass2);
											return;
										}
									}
								}
								ServerMessage gClass3 = new ServerMessage(166u);
								gClass3.AppendStringWithBreak("/client/private/" + class2.Id + "/id");
								this.Session.method_14(gClass3);
							}
						}
						this.Session.GetHabbo().bool_5 = true;
						this.method_6();
					}
				}
			}
		}
		public void method_6()
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(this.Session.GetHabbo().uint_2);
			if (@class != null && this.Session.GetHabbo().bool_5)
			{
				ServerMessage gClass = new ServerMessage(69u);
				gClass.AppendStringWithBreak(@class.ModelName);
				gClass.AppendUInt(@class.Id);
				this.Session.method_14(gClass);
				if (this.Session.GetHabbo().bool_8)
				{
					ServerMessage gClass2 = new ServerMessage(254u);
					this.Session.method_14(gClass2);
				}
				if (@class.Type == "private")
				{
					if (@class.Wallpaper != "0.0")
					{
						ServerMessage gClass3 = new ServerMessage(46u);
						gClass3.AppendStringWithBreak("wallpaper");
						gClass3.AppendStringWithBreak(@class.Wallpaper);
						this.Session.method_14(gClass3);
					}
					if (@class.Floor != "0.0")
					{
						ServerMessage Logging = new ServerMessage(46u);
						Logging.AppendStringWithBreak("floor");
						Logging.AppendStringWithBreak(@class.Floor);
						this.Session.method_14(Logging);
					}
					ServerMessage gClass5 = new ServerMessage(46u);
					gClass5.AppendStringWithBreak("landscape");
					gClass5.AppendStringWithBreak(@class.Landscape);
					this.Session.method_14(gClass5);
					if (@class.method_27(this.Session, true))
					{
						ServerMessage gClass6 = new ServerMessage(42u);
						this.Session.method_14(gClass6);
						ServerMessage gClass7 = new ServerMessage(47u);
						this.Session.method_14(gClass7);
					}
					else
					{
						if (@class.method_26(this.Session))
						{
							ServerMessage gClass6 = new ServerMessage(42u);
							this.Session.method_14(gClass6);
						}
					}
					ServerMessage gClass8 = new ServerMessage(345u);
					if (this.Session.GetHabbo().list_4.Contains(@class.Id) || @class.method_27(this.Session, true))
					{
						gClass8.AppendInt32(@class.Score);
					}
					else
					{
						gClass8.AppendInt32(-1);
					}
					this.Session.method_14(gClass8);
					if (@class.Boolean_0)
					{
						this.Session.method_14(@class.Event.Serialize(this.Session));
					}
					else
					{
						ServerMessage gClass9 = new ServerMessage(370u);
						gClass9.AppendStringWithBreak("-1");
						this.Session.method_14(gClass9);
					}
				}
				this.method_4();
			}
		}
		public void method_7()
		{
			this.Session.GetHabbo().uint_2 = 0u;
			this.Session.GetHabbo().bool_5 = false;
			this.Session.GetHabbo().bool_6 = false;
		}
		public bool method_8(string string_0)
		{
			if (!Regex.IsMatch(string_0, "^[-a-zA-Z0-9._:,]+$"))
			{
				return false;
			}
			else
			{
				DataRow dataRow = null;
				using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
				{
					dataRow = @class.ReadDataRow("SELECT * FROM users WHERE username = '" + string_0 + "'");
				}
				return (dataRow == null);
			}
		}
	}
}
