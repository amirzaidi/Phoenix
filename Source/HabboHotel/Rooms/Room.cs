using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Phoenix.Core;
using Phoenix.HabboHotel.Misc;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Rooms;
using Phoenix.HabboHotel.Items;
using Phoenix.HabboHotel.Pets;
using Phoenix.HabboHotel.Pathfinding;
using Phoenix.Util;
using Phoenix.Messages;
using Phoenix.HabboHotel.RoomBots;
using Phoenix.HabboHotel.Navigators;
using Phoenix.Storage;
namespace Phoenix.HabboHotel.Rooms
{
	internal sealed class Room
	{
		public delegate void Delegate2(int Team);
		private uint uint_0;
		public uint Achievement;
		public string Name;
		public string Description;
		public string Type;
		public string Owner;
		public string Password;
		public int Category;
		public int State;
		public int UsersNow;
		public int UsersMax;
		public string ModelName;
		public string CCTs;
		public int Score;
		public List<string> Tags;
		public bool AllowPet;
		public bool AllowPetsEating;
		public bool AllowWalkthrough;
		public bool Hidewall;
		public int Wallthick;
		public int Floorthick;
		internal bool bool_4;
		internal bool bool_5;
		private Timer timer_0;
		private bool bool_6;
		private bool bool_7;
		internal Class33[] class33_0;
		public int int_7 = 0;
		private int int_8;
		public RoomIcon class29_0;
		public List<uint> list_1;
		internal bool bool_8;
		private Dictionary<uint, double> dictionary_0;
		public RoomEvent Event;
		public string Wallpaper;
		public string Floor;
		public string Landscape;
		private Hashtable hashtable_0;
		private Hashtable hashtable_1;
		private Hashtable hashtable_2;
		private Hashtable hashtable_3;
		private Hashtable hashtable_4;
		public MoodlightData class67_0;
		public List<Trade> list_2;
		public bool bool_9;
		public List<UserItemData> list_3;
		public List<uint> list_4;
		public List<UserItemData> list_5;
		public List<UserItemData> list_6;
		public List<UserItemData> list_7;
		public List<UserItemData> list_8;
		public List<UserItemData> list_9;
		public List<UserItemData> list_10;
		public List<UserItemData> list_11;
		public List<UserItemData> list_12;
		public List<UserItemData> list_13;
		public int int_9;
		public int int_10;
		public int int_11;
		public int int_12;
		public int int_13;
		private bool bool_10;
		public List<UserItemData> list_14;
		public List<UserItemData> list_15;
		public List<UserItemData> list_16;
		public List<GroupsManager> list_17;
		public double[,] double_0;
		private byte[,] byte_0;
		public ThreeDCoord[,] gstruct1_0;
		private byte[,] byte_1;
		private byte[,] byte_2;
		private double[,] double_1;
		private double[,] double_2;
		private RoomModel class28_0;
		private bool bool_11;
		private int int_14;
		private int int_15;
		private RoomData class27_0;
		private int int_16;
		private bool bool_12;
		public bool Boolean_0
		{
			get
			{
				return this.Event != null;
			}
		}
		public RoomIcon myIcon
		{
			get
			{
				return this.class29_0;
			}
			set
			{
				this.class29_0 = value;
			}
		}
		internal bool Boolean_1
		{
			get
			{
				return this.bool_11;
			}
			set
			{
				this.bool_11 = value;
			}
		}
		public int Int32_0
		{
			get
			{
				int num = 0;
				int result;
				if (this.class33_0 == null)
				{
					result = 0;
				}
				else
				{
					for (int i = 0; i < this.class33_0.Length; i++)
					{
						if (this.class33_0[i] != null && !this.class33_0[i].Boolean_4 && !this.class33_0[i].Boolean_0)
						{
							num++;
						}
					}
					result = num;
				}
				return result;
			}
		}
		public int Int32_1
		{
			get
			{
				return this.Tags.Count;
			}
		}
		public RoomModel Class28_0
		{
			get
			{
				return this.class28_0;
			}
		}
		public uint Id
		{
			get
			{
				return this.uint_0;
			}
		}
		public Hashtable Hashtable_0
		{
			get
			{
				Hashtable result;
				if (this.hashtable_0 != null)
				{
					result = (this.hashtable_0.Clone() as Hashtable);
				}
				else
				{
					result = null;
				}
				return result;
			}
		}
		public Hashtable Hashtable_1
		{
			get
			{
				return this.hashtable_4.Clone() as Hashtable;
			}
		}
		public bool Boolean_2
		{
			get
			{
				if (this.Boolean_3)
				{
					return false;
				}
				else
				{
					NavigatorFlatcats @class = Phoenix.GetGame().GetNavigator().method_2(this.Category);
					return (@class != null && @class.CanTrade);
				}
			}
		}
		public bool Boolean_3
		{
			get
			{
				return this.Type == "public";
			}
		}
		public int Int32_2
		{
			get
			{
				int num = 0;
				for (int i = 0; i < this.class33_0.Length; i++)
				{
					Class33 @class = this.class33_0[i];
					if (@class != null && @class.Boolean_0)
					{
						num++;
					}
				}
				return num;
			}
		}
		internal RoomData Class27_0
		{
			get
			{
				this.class27_0.Fill(this);
				return this.class27_0;
			}
		}
		public byte[,] Byte_0
		{
			get
			{
				return this.byte_0;
			}
		}
		internal bool Boolean_4
		{
			get
			{
				return this.method_2().Count > 0;
			}
		}
		public Room(uint uint_2, string string_10, string string_11, string string_12, string string_13, int int_17, int int_18, int int_19, string string_14, string string_15, int int_20, List<string> list_18, bool bool_13, bool bool_14, bool bool_15, bool bool_16, RoomIcon class29_1, string string_16, string string_17, string string_18, string string_19, RoomData class27_1, bool bool_17, int int_21, int int_22, uint uint_3)
		{
			//if (!(Class13.String_0 == ""))
			//{
				this.bool_12 = false;
				this.uint_0 = uint_2;
				this.Name = string_10;
				this.Description = string_11;
				this.Owner = string_13;
				this.Category = int_17;
				this.Type = string_12;
				this.State = int_18;
				this.UsersNow = 0;
				this.UsersMax = int_19;
				this.ModelName = string_14;
				this.CCTs = string_15;
				this.Score = int_20;
				this.Tags = list_18;
				this.AllowPet = bool_13;
				this.AllowPetsEating = bool_14;
				this.AllowWalkthrough = bool_15;
				this.Hidewall = bool_16;
				this.Wallthick = int_21;
				this.Floorthick = int_22;
				this.int_7 = 0;
				this.class33_0 = new Class33[500];
				this.class29_0 = class29_1;
				this.Password = string_16;
				this.dictionary_0 = new Dictionary<uint, double>();
				this.Event = null;
				this.Wallpaper = string_17;
				this.Floor = string_18;
				this.Landscape = string_19;
				this.hashtable_4 = new Hashtable();
				this.hashtable_0 = new Hashtable();
				this.list_2 = new List<Trade>();
				this.class28_0 = Phoenix.GetGame().GetRoomManager().GetModel(this.ModelName, this.uint_0);
				this.bool_6 = false;
				this.bool_7 = false;
				this.bool_5 = true;
				this.class27_0 = class27_1;
				this.bool_8 = bool_17;
				this.list_17 = new List<GroupsManager>();
				this.list_4 = new List<uint>();
				this.list_5 = new List<UserItemData>();
				this.list_9 = new List<UserItemData>();
				this.list_7 = new List<UserItemData>();
				this.list_6 = new List<UserItemData>();
				this.list_8 = new List<UserItemData>();
				this.list_10 = new List<UserItemData>();
				this.list_11 = new List<UserItemData>();
				this.list_12 = new List<UserItemData>();
				this.list_13 = new List<UserItemData>();
				this.int_10 = 0;
				this.int_11 = 0;
				this.int_9 = 0;
				this.int_12 = 0;
				this.int_13 = 0;
				this.list_3 = new List<UserItemData>();
				this.list_14 = new List<UserItemData>();
				this.list_15 = new List<UserItemData>();
				this.list_16 = new List<UserItemData>();
				this.byte_0 = new byte[this.Class28_0.int_4, this.Class28_0.int_5];
				this.double_1 = new double[this.Class28_0.int_4, this.Class28_0.int_5];
				this.double_2 = new double[this.Class28_0.int_4, this.Class28_0.int_5];
				this.timer_0 = new Timer(new TimerCallback(this.method_32), null, 480, 480);
				this.int_8 = 0;
				this.bool_4 = false;
				this.bool_9 = true;
				this.bool_11 = false;
				this.int_16 = 0;
				this.int_15 = 4;
				this.Achievement = uint_3;
				this.bool_10 = false;
				this.hashtable_1 = new Hashtable();
				this.hashtable_2 = new Hashtable();
				this.hashtable_3 = new Hashtable();
				this.method_23();
				this.method_25();
				this.method_22();
			//}
		}
		public void method_0()
		{
			List<Class34> list = Phoenix.GetGame().GetBotManager().method_2(this.Id);
			foreach (Class34 current in list)
			{
				this.method_3(current);
			}
		}
		public void method_1()
		{
			new List<Pet>();
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				@class.AddParamWithValue("roomid", this.Id);
				DataTable dataTable = @class.ReadDataTable("SELECT id, user_id, room_id, name, type, race, color, expirience, energy, nutrition, respect, createstamp, x, y, z FROM user_pets WHERE room_id = @roomid;");
				if (dataTable != null)
				{
					foreach (DataRow dataRow_ in dataTable.Rows)
					{
						Pet class2 = Phoenix.GetGame().GetCatalog().method_12(dataRow_);
						List<Class36> list = new List<Class36>();
						List<Class35> list2 = new List<Class35>();
						this.method_4(new Class34(class2.PetId, this.Id, Enum2.const_0, "freeroam", class2.Name, "", class2.Look, class2.X, class2.Y, (int)class2.Z, 0, 0, 0, 0, 0, ref list, ref list2, 0), class2);
					}
				}
			}
		}
		internal List<Pet> method_2()
		{
			List<Pet> list = new List<Pet>();
			for (int i = 0; i < this.class33_0.Length; i++)
			{
				if (this.class33_0[i] != null && this.class33_0[i].Boolean_0)
				{
					list.Add(this.class33_0[i].class15_0);
				}
			}
			return list;
		}
		public Class33 method_3(Class34 class34_0)
		{
			return this.method_4(class34_0, null);
		}
		public Class33 method_4(Class34 class34_0, Pet class15_0)
		{
			int num = this.method_5();
			Class33 @class = new Class33(Convert.ToUInt32(num + 100000), this.Id, this.int_7++, true);
			@class.int_20 = num;
			this.class33_0[num] = @class;
			if (class34_0.int_1 > 0 && class34_0.int_2 > 0 && class34_0.int_1 < this.Class28_0.int_4 && class34_0.int_2 < this.Class28_0.int_5)
			{
				@class.method_7(class34_0.int_1, class34_0.int_2, class34_0.double_0);
				@class.method_9(class34_0.int_3);
			}
			else
			{
				class34_0.int_1 = this.Class28_0.int_0;
				class34_0.int_2 = this.Class28_0.int_1;
				@class.method_7(this.Class28_0.int_0, this.Class28_0.int_1, this.Class28_0.double_0);
				@class.method_9(this.Class28_0.int_2);
			}
			@class.class34_0 = class34_0;
			@class.class99_0 = class34_0.method_4(@class.int_0);
			if (@class.Boolean_0)
			{
				@class.class99_0.method_0((int)class34_0.uint_0, @class.int_0, this.Id);
				@class.class15_0 = class15_0;
				@class.class15_0.VirtualId = @class.int_0;
			}
			else
			{
				@class.class99_0.method_0(-1, @class.int_0, this.Id);
			}
			this.method_87(@class, true, true);
			@class.bool_7 = true;
			ServerMessage gClass = new ServerMessage(28u);
			gClass.AppendInt32(1);
			@class.method_14(gClass);
			this.SendMessage(gClass, null);
			@class.class99_0.OnSelfEnterRoom();
			return @class;
		}
		private int method_5()
		{
			return Array.IndexOf<Class33>(this.class33_0, null);
		}
		public void method_6(int int_17, bool bool_13)
		{
			Class33 @class = this.method_52(int_17);
			if (@class != null && @class.Boolean_4)
			{
				@class.class99_0.OnSelfLeaveRoom(bool_13);
				ServerMessage gClass = new ServerMessage(29u);
				gClass.AppendRawInt32(@class.int_0);
				this.SendMessage(gClass, null);
				uint num = @class.uint_0;
				for (int i = 0; i < this.class33_0.Length; i++)
				{
					Class33 class2 = this.class33_0[i];
					if (class2 != null && class2.uint_0 == num)
					{
						this.class33_0[i] = null;
					}
				}
			}
		}
		public void method_7(Class33 class33_1, string string_10, bool bool_13)
		{
			for (int i = 0; i < this.class33_0.Length; i++)
			{
				Class33 @class = this.class33_0[i];
				if (@class != null && @class.Boolean_4)
				{
					if (bool_13)
					{
						@class.class99_0.OnUserShout(class33_1, string_10);
					}
					else
					{
						@class.class99_0.OnUserSay(class33_1, string_10);
					}
				}
			}
		}
		public void method_8(Class33 class33_1)
		{
			try
			{
				foreach (UserItemData current in this.list_14)
				{
					if (current.GetBaseItem().InteractionType.ToLower() == "wf_trg_enterroom")
					{
						this.method_21(class33_1, current, "");
					}
				}
			}
			catch
			{
			}
		}
		public bool method_9(Class33 class33_1, string string_10)
		{
			bool result = false;
			try
			{
				foreach (UserItemData current in this.list_14)
				{
					if (current.GetBaseItem().InteractionType.ToLower() == "wf_trg_onsay" && this.method_21(class33_1, current, string_10.ToLower()))
					{
						result = true;
					}
				}
			}
			catch
			{
			}
			return result;
		}
		public void method_10(Class33 class33_1, UserItemData class63_0)
		{
			try
			{
				foreach (UserItemData current in this.list_14)
				{
					if (current.GetBaseItem().InteractionType.ToLower() == "wf_trg_furnistate")
					{
						this.method_21(class33_1, current, Convert.ToString(class63_0.uint_0));
					}
				}
			}
			catch
			{
			}
		}
		public void method_11(Class33 class33_1, UserItemData class63_0)
		{
			try
			{
				foreach (UserItemData current in this.list_14)
				{
					if (current.GetBaseItem().InteractionType.ToLower() == "wf_trg_onfurni")
					{
						this.method_21(class33_1, current, Convert.ToString(class63_0.uint_0));
					}
				}
			}
			catch
			{
			}
		}
		public void method_12(Class33 class33_1, UserItemData class63_0)
		{
			try
			{
				foreach (UserItemData current in this.list_14)
				{
					if (current.GetBaseItem().InteractionType.ToLower() == "wf_trg_offfurni")
					{
						this.method_21(class33_1, current, Convert.ToString(class63_0.uint_0));
					}
				}
			}
			catch
			{
			}
		}
		public void method_13()
		{
			try
			{
				foreach (UserItemData current in this.list_14)
				{
					if (current.GetBaseItem().InteractionType.ToLower() == "wf_trg_gameend")
					{
						this.method_21(null, current, "GameEnded");
					}
				}
			}
			catch
			{
			}
		}
		public void method_14(Class33 class33_1)
		{
			try
			{
				foreach (UserItemData current in this.list_14)
				{
					if (current.GetBaseItem().InteractionType.ToLower() == "wf_trg_gamestart")
					{
						this.method_21(class33_1, current, "GameBegun");
					}
				}
			}
			catch
			{
			}
		}
		public void method_15(UserItemData class63_0)
		{
			this.method_21(null, class63_0, "Timer");
		}
		public void method_16(double double_3)
		{
			try
			{
				foreach (UserItemData current in this.list_14)
				{
					if (current.GetBaseItem().InteractionType.ToLower() == "wf_trg_attime" && current.string_2.Length > 0 && Convert.ToDouble(current.string_2) == double_3)
					{
						this.method_21(null, current, "AtTime");
					}
				}
			}
			catch
			{
			}
		}
		public void method_17(int int_17)
		{
			try
			{
				foreach (UserItemData current in this.list_14)
				{
					if (current.GetBaseItem().InteractionType.ToLower() == "wf_trg_atscore" && current.string_2 != "" && Convert.ToDouble(current.string_2) == (double)int_17)
					{
						this.method_21(null, current, "TheScore");
					}
				}
			}
			catch
			{
			}
		}
		public bool method_18(Class33 class33_1, string string_10, string string_11)
		{
			string_11 = this.method_20(class33_1, string_11);
			bool result;
			if (string_10 != null)
			{
				if (Class23.dictionary_4 == null)
				{
					Class23.dictionary_4 = new Dictionary<string, int>(39)
					{

						{
							"roomuserseq",
							0
						},

						{
							"roomuserslt",
							1
						},

						{
							"roomusersmt",
							2
						},

						{
							"roomusersmte",
							3
						},

						{
							"roomuserslte",
							4
						},

						{
							"userhasachievement",
							5
						},

						{
							"userhasntachievement",
							6
						},

						{
							"userhasbadge",
							7
						},

						{
							"userhasntbadge",
							8
						},

						{
							"userhasvip",
							9
						},

						{
							"userhasntvip",
							10
						},

						{
							"userhaseffect",
							11
						},

						{
							"userhasnteffect",
							12
						},

						{
							"userrankeq",
							13
						},

						{
							"userrankmt",
							14
						},

						{
							"userrankmte",
							15
						},

						{
							"userranklt",
							16
						},

						{
							"userranklte",
							17
						},

						{
							"usercreditseq",
							18
						},

						{
							"usercreditsmt",
							19
						},

						{
							"usercreditsmte",
							20
						},

						{
							"usercreditslt",
							21
						},

						{
							"usercreditslte",
							22
						},

						{
							"userpixelseq",
							23
						},

						{
							"userpixelsmt",
							24
						},

						{
							"userpixelsmte",
							25
						},

						{
							"userpixelslt",
							26
						},

						{
							"userpixelslte",
							27
						},

						{
							"userpointseq",
							28
						},

						{
							"userpointsmt",
							29
						},

						{
							"userpointsmte",
							30
						},

						{
							"userpointslt",
							31
						},

						{
							"userpointslte",
							32
						},

						{
							"usergroupeq",
							33
						},

						{
							"userisingroup",
							34
						},

						{
							"wearing",
							35
						},

						{
							"notwearing",
							36
						},

						{
							"carrying",
							37
						},

						{
							"notcarrying",
							38
						}
					};
				}
				int num;
				if (Class23.dictionary_4.TryGetValue(string_10, out num))
				{
					switch (num)
					{
					case 0:
						if (this.Int32_0 == Convert.ToInt32(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 1:
						if (this.Int32_0 < Convert.ToInt32(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 2:
						if (this.Int32_0 > Convert.ToInt32(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 3:
						if (this.Int32_0 >= Convert.ToInt32(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 4:
						if (this.Int32_0 <= Convert.ToInt32(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 5:
						result = Phoenix.GetGame().GetAchievementManager().method_1(class33_1.method_16(), (uint)Convert.ToUInt16(string_11), 1);
						return result;
					case 6:
						if (!Phoenix.GetGame().GetAchievementManager().method_1(class33_1.method_16(), (uint)Convert.ToUInt16(string_11), 1))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 7:
						result = class33_1.method_16().GetHabbo().method_22().method_1(string_11);
						return result;
					case 8:
						if (!class33_1.method_16().GetHabbo().method_22().method_1(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 9:
						result = class33_1.method_16().GetHabbo().bool_14;
						return result;
					case 10:
						if (!class33_1.method_16().GetHabbo().bool_14)
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 11:
						if (class33_1.method_16().GetHabbo().method_24().int_0 == Convert.ToInt32(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 12:
						if (class33_1.method_16().GetHabbo().method_24().int_0 != Convert.ToInt32(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 13:
						if ((ulong)class33_1.method_16().GetHabbo().uint_1 == (ulong)((long)Convert.ToInt32(string_11)))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 14:
						if ((ulong)class33_1.method_16().GetHabbo().uint_1 > (ulong)((long)Convert.ToInt32(string_11)))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 15:
						if ((ulong)class33_1.method_16().GetHabbo().uint_1 >= (ulong)((long)Convert.ToInt32(string_11)))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 16:
						if ((ulong)class33_1.method_16().GetHabbo().uint_1 < (ulong)((long)Convert.ToInt32(string_11)))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 17:
						if ((ulong)class33_1.method_16().GetHabbo().uint_1 <= (ulong)((long)Convert.ToInt32(string_11)))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 18:
						if (class33_1.method_16().GetHabbo().Credits == Convert.ToInt32(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 19:
						if (class33_1.method_16().GetHabbo().Credits > Convert.ToInt32(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 20:
						if (class33_1.method_16().GetHabbo().Credits >= Convert.ToInt32(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 21:
						if (class33_1.method_16().GetHabbo().Credits < Convert.ToInt32(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 22:
						if (class33_1.method_16().GetHabbo().Credits <= Convert.ToInt32(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 23:
						if (class33_1.method_16().GetHabbo().ActivityPoints == Convert.ToInt32(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 24:
						if (class33_1.method_16().GetHabbo().ActivityPoints > Convert.ToInt32(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 25:
						if (class33_1.method_16().GetHabbo().ActivityPoints >= Convert.ToInt32(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 26:
						if (class33_1.method_16().GetHabbo().ActivityPoints < Convert.ToInt32(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 27:
						if (class33_1.method_16().GetHabbo().ActivityPoints <= Convert.ToInt32(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 28:
						if (class33_1.method_16().GetHabbo().VipPoints == Convert.ToInt32(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 29:
						if (class33_1.method_16().GetHabbo().VipPoints > Convert.ToInt32(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 30:
						if (class33_1.method_16().GetHabbo().VipPoints >= Convert.ToInt32(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 31:
						if (class33_1.method_16().GetHabbo().VipPoints < Convert.ToInt32(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 32:
						if (class33_1.method_16().GetHabbo().VipPoints <= Convert.ToInt32(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 33:
						if (class33_1.method_16().GetHabbo().int_0 == Convert.ToInt32(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 34:
					{
						IEnumerator enumerator = class33_1.method_16().GetHabbo().dataTable_0.Rows.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								DataRow dataRow = (DataRow)enumerator.Current;
								if ((int)dataRow["groupid"] == Convert.ToInt32(string_11))
								{
									result = true;
									return result;
								}
							}
							goto IL_89E;
						}
						finally
						{
							IDisposable disposable = enumerator as IDisposable;
							if (disposable != null)
							{
								disposable.Dispose();
							}
						}
					}
					case 35:
						break;
					case 36:
						if (!class33_1.method_16().GetHabbo().string_5.Contains(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 37:
						if (this.method_53(class33_1.method_16().GetHabbo().Id).int_5 == (int)Convert.ToInt16(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					case 38:
						if (this.method_53(class33_1.method_16().GetHabbo().Id).int_5 != (int)Convert.ToInt16(string_11))
						{
							result = true;
							return result;
						}
						goto IL_89E;
					default:
						goto IL_89E;
					}
					if (class33_1.method_16().GetHabbo().string_5.Contains(string_11))
					{
						result = true;
						return result;
					}
				}
			}
			IL_89E:
			result = false;
			return result;
		}
		public void method_19(Class33 class33_1, string string_10, string string_11)
		{
			string_11 = this.method_20(class33_1, string_11);
			if (string_10 != null)
			{
				if (Class23.dictionary_5 == null)
				{
					Class23.dictionary_5 = new Dictionary<string, int>(13)
					{

						{
							"sql",
							0
						},

						{
							"badge",
							1
						},

						{
							"effect",
							2
						},

						{
							"award",
							3
						},

						{
							"dance",
							4
						},

						{
							"send",
							5
						},

						{
							"credits",
							6
						},

						{
							"pixels",
							7
						},

						{
							"points",
							8
						},

						{
							"rank",
							9
						},

						{
							"respect",
							10
						},

						{
							"handitem",
							11
						},

						{
							"alert",
							12
						}
					};
				}
				int num;
				if (Class23.dictionary_5.TryGetValue(string_10, out num))
				{
					switch (num)
					{
					case 0:
						using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
						{
							@class.ExecuteQuery(string_11);
							return;
						}
					case 1:
						break;
					case 2:
						if (class33_1.method_16() != null)
						{
							class33_1.method_16().GetHabbo().method_24().method_0(Convert.ToInt32(string_11), 3600);
							class33_1.method_16().GetHabbo().method_24().method_3(Convert.ToInt32(string_11));
							return;
						}
						return;
					case 3:
						if (class33_1.method_16() != null)
						{
							Phoenix.GetGame().GetAchievementManager().method_2(class33_1.method_16(), Convert.ToUInt32(string_11));
							return;
						}
						return;
					case 4:
						if (class33_1.method_16() != null)
						{
							Class33 class2 = this.method_53(class33_1.method_16().GetHabbo().Id);
							class2.int_15 = Convert.ToInt32(string_11);
							ServerMessage gClass = new ServerMessage(480u);
							gClass.AppendInt32(class2.int_0);
							gClass.AppendInt32(Convert.ToInt32(string_11));
							this.SendMessage(gClass, null);
							return;
						}
						return;
					case 5:
					{
						if (class33_1.method_16() == null)
						{
							return;
						}
						uint num2 = Convert.ToUInt32(string_11);
						Room class3;
						if (Phoenix.GetGame().GetRoomManager().method_13(num2) || Phoenix.GetGame().GetRoomManager().method_14(num2))
						{
							class3 = Phoenix.GetGame().GetRoomManager().GetRoom(num2);
						}
						else
						{
							class3 = Phoenix.GetGame().GetRoomManager().method_15(num2);
						}
						if (class33_1 == null)
						{
							return;
						}
						if (class3 == null)
						{
							this.method_47(class33_1.method_16(), true, false);
							return;
						}
						ServerMessage gClass2 = new ServerMessage(286u);
						gClass2.AppendBoolean(class3.Boolean_3);
						gClass2.AppendUInt(Convert.ToUInt32(string_11));
						class33_1.method_16().method_14(gClass2);
						return;
					}
					case 6:
						if (class33_1.method_16() != null)
						{
							class33_1.method_16().GetHabbo().Credits = class33_1.method_16().GetHabbo().Credits + Convert.ToInt32(string_11);
							class33_1.method_16().GetHabbo().method_13(true);
							return;
						}
						return;
					case 7:
						if (class33_1.method_16() != null)
						{
							class33_1.method_16().GetHabbo().ActivityPoints = class33_1.method_16().GetHabbo().ActivityPoints + Convert.ToInt32(string_11);
							class33_1.method_16().GetHabbo().method_15(true);
							return;
						}
						return;
					case 8:
						if (class33_1.method_16() != null)
						{
							class33_1.method_16().GetHabbo().VipPoints = class33_1.method_16().GetHabbo().VipPoints + Convert.ToInt32(string_11);
							class33_1.method_16().GetHabbo().method_14(false, true);
							return;
						}
						return;
					case 9:
						if (class33_1.method_16() != null && (int)Convert.ToUInt16(string_11) < Phoenix.GetGame().GetRoleManager().method_9())
						{
							using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
							{
								@class.ExecuteQuery(string.Concat(new object[]
								{
									"UPDATE users SET rank = '",
									Convert.ToUInt16(string_11),
									"' WHERE id = ",
									class33_1.method_16().GetHabbo().Id,
									" LIMIT 1;"
								}));
							}
							class33_1.method_16().method_12();
							return;
						}
						return;
					case 10:
					{
						if (class33_1.method_16() == null)
						{
							return;
						}
						class33_1.method_16().GetHabbo().Respect++;
						using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
						{
							@class.ExecuteQuery("UPDATE user_stats SET Respect = respect + 1 WHERE id = '" + class33_1.method_16().GetHabbo().Id + "' LIMIT 1");
						}
						ServerMessage gClass3 = new ServerMessage(440u);
						gClass3.AppendUInt(class33_1.method_16().GetHabbo().Id);
						gClass3.AppendInt32(class33_1.method_16().GetHabbo().Respect);
						this.SendMessage(gClass3, null);
						int int_ = class33_1.method_16().GetHabbo().Respect;
						if (int_ <= 166)
						{
							if (int_ <= 6)
							{
								if (int_ == 1)
								{
									Phoenix.GetGame().GetAchievementManager().method_3(class33_1.method_16(), 14u, 1);
									return;
								}
								if (int_ != 6)
								{
									return;
								}
								Phoenix.GetGame().GetAchievementManager().method_3(class33_1.method_16(), 14u, 2);
								return;
							}
							else
							{
								if (int_ == 16)
								{
									Phoenix.GetGame().GetAchievementManager().method_3(class33_1.method_16(), 14u, 3);
									return;
								}
								if (int_ == 66)
								{
									Phoenix.GetGame().GetAchievementManager().method_3(class33_1.method_16(), 14u, 4);
									return;
								}
								if (int_ != 166)
								{
									return;
								}
								Phoenix.GetGame().GetAchievementManager().method_3(class33_1.method_16(), 14u, 5);
								return;
							}
						}
						else
						{
							if (int_ <= 566)
							{
								if (int_ == 366)
								{
									Phoenix.GetGame().GetAchievementManager().method_3(class33_1.method_16(), 14u, 6);
									return;
								}
								if (int_ != 566)
								{
									return;
								}
								Phoenix.GetGame().GetAchievementManager().method_3(class33_1.method_16(), 14u, 7);
								return;
							}
							else
							{
								if (int_ == 766)
								{
									Phoenix.GetGame().GetAchievementManager().method_3(class33_1.method_16(), 14u, 8);
									return;
								}
								if (int_ == 966)
								{
									Phoenix.GetGame().GetAchievementManager().method_3(class33_1.method_16(), 14u, 9);
									return;
								}
								if (int_ != 1116)
								{
									return;
								}
								Phoenix.GetGame().GetAchievementManager().method_3(class33_1.method_16(), 14u, 10);
								return;
							}
						}
					}
					case 11:
						if (class33_1.method_16() != null)
						{
							this.method_53(class33_1.method_16().GetHabbo().Id).method_8((int)Convert.ToInt16(string_11));
							return;
						}
						return;
					case 12:
						if (class33_1.method_16() != null)
						{
							class33_1.method_16().SendNotif(string_11);
							return;
						}
						return;
					default:
						return;
					}
					if (class33_1.method_16() != null)
					{
						class33_1.method_16().GetHabbo().method_22().method_2(class33_1.method_16(), Phoenix.smethod_7(string_11), true);
						class33_1.method_16().method_14(class33_1.method_16().GetHabbo().method_22().method_7());
					}
				}
			}
		}
		public string method_20(Class33 class33_1, string string_10)
		{
			if (class33_1 != null)
			{
				if (string_10.ToUpper().Contains("#USERNAME#"))
				{
					string_10 = Regex.Replace(string_10, "#USERNAME#", class33_1.method_16().GetHabbo().Username, RegexOptions.IgnoreCase);
				}
				if (string_10.ToUpper().Contains("#USERID#"))
				{
					string_10 = Regex.Replace(string_10, "#USERID#", class33_1.method_16().GetHabbo().Id.ToString(), RegexOptions.IgnoreCase);
				}
				if (string_10.ToUpper().Contains("#USERRANK#"))
				{
					string_10 = Regex.Replace(string_10, "#USERRANK#", class33_1.method_16().GetHabbo().uint_1.ToString(), RegexOptions.IgnoreCase);
				}
			}
			if (string_10.ToUpper().Contains("#ROOMNAME#"))
			{
				string_10 = Regex.Replace(string_10, "#ROOMNAME#", this.Name, RegexOptions.IgnoreCase);
			}
			if (string_10.ToUpper().Contains("#ROOMID#"))
			{
				string_10 = Regex.Replace(string_10, "#ROOMID#", this.uint_0.ToString(), RegexOptions.IgnoreCase);
			}
			int num = Phoenix.GetGame().GetClientManager().ClientCount + -1;
			int int32_ = Phoenix.GetGame().GetRoomManager().LoadedRoomsCount;
			if (string_10.ToUpper().Contains("#ONLINECOUNT#"))
			{
				string_10 = Regex.Replace(string_10, "#ONLINECOUNT#", num.ToString(), RegexOptions.IgnoreCase);
			}
			if (string_10.ToUpper().Contains("#ROOMSLOADED#"))
			{
				string_10 = Regex.Replace(string_10, "#ROOMSLOADED#", int32_.ToString(), RegexOptions.IgnoreCase);
			}
			return string_10;
		}
		public bool method_21(Class33 class33_1, UserItemData class63_0, string string_10)
		{
			bool result;
			try
			{
				if (this.bool_6 || this.bool_7)
				{
					result = false;
				}
				else
				{
					bool flag = false;
					int num = 0;
					int num2 = 0;
					bool flag2 = false;
					string text = class63_0.GetBaseItem().InteractionType.ToLower();
					switch (text)
					{
					case "wf_trg_onsay":
						if (string_10.Contains(class63_0.string_2.ToLower()))
						{
							flag = true;
						}
						break;
					case "wf_trg_enterroom":
						if (class63_0.string_2 == "" || class63_0.string_2 == class33_1.method_16().GetHabbo().Username)
						{
							flag = true;
						}
						break;
					case "wf_trg_furnistate":
						if (class63_0.string_3.Length > 0)
						{
							string[] collection = class63_0.string_3.Split(new char[]
							{
								','
							});
							List<string> list = new List<string>(collection);
							foreach (string current in list)
							{
								if (current == string_10)
								{
									flag = true;
								}
							}
						}
						break;
					case "wf_trg_onfurni":
						if (class63_0.string_3.Length > 0)
						{
							string[] collection = class63_0.string_3.Split(new char[]
							{
								','
							});
							List<string> list = new List<string>(collection);
							List<string> list2 = list;
							foreach (string current in list)
							{
								if (!(current != string_10))
								{
									UserItemData @class = this.method_28(Convert.ToUInt32(string_10));
									if (@class != null)
									{
										flag = true;
									}
									else
									{
										list2.Remove(current);
									}
								}
							}
							class63_0.string_3 = string.Join(",", list2.ToArray());
						}
						break;
					case "wf_trg_offfurni":
						if (class63_0.string_3.Length > 0)
						{
							string[] collection = class63_0.string_3.Split(new char[]
							{
								','
							});
							List<string> list = new List<string>(collection);
							List<string> list2 = list;
							foreach (string current in list)
							{
								if (!(current != string_10))
								{
									UserItemData @class = this.method_28(Convert.ToUInt32(string_10));
									if (@class != null)
									{
										flag = true;
									}
									else
									{
										list2.Remove(current);
									}
								}
							}
							class63_0.string_3 = string.Join(",", list2.ToArray());
						}
						break;
					case "wf_trg_gameend":
						if (string_10 == "GameEnded")
						{
							flag = true;
						}
						break;
					case "wf_trg_gamestart":
						if (string_10 == "GameBegun")
						{
							flag = true;
						}
						break;
					case "wf_trg_timer":
						if (string_10 == "Timer")
						{
							flag = true;
						}
						break;
					case "wf_trg_attime":
						if (string_10 == "AtTime")
						{
							flag = true;
						}
						break;
					case "wf_trg_atscore":
						if (string_10 == "TheScore")
						{
							flag = true;
						}
						break;
					}
					try
					{
						List<UserItemData> list3 = this.method_93(class63_0.Int32_0, class63_0.Int32_1);
						if (list3 == null)
						{
							result = false;
							return result;
						}
						foreach (UserItemData current2 in list3)
						{
							text = current2.GetBaseItem().InteractionType.ToLower();
							if (text != null)
							{
								int num4;
								if (!(text == "wf_cnd_phx"))
								{
									if (!(text == "wf_cnd_trggrer_on_frn"))
									{
										string[] collection;
										List<string> list;
										List<UserItemData> list4;
										if (!(text == "wf_cnd_furnis_hv_avtrs"))
										{
											if (!(text == "wf_cnd_has_furni_on"))
											{
												continue;
											}
											num4 = num2;
											num++;
											current2.string_0 = "1";
											current2.method_5(false, true);
											current2.method_3(1);
											current2.method_10();
											if (current2.string_3.Length <= 0)
											{
												continue;
											}
											collection = current2.string_3.Split(new char[]
											{
												','
											});
											list = new List<string>(collection);
											list4 = new List<UserItemData>();
											foreach (string current3 in list)
											{
												list4.Add(this.method_28(Convert.ToUInt32(current3)));
											}
											using (List<UserItemData>.Enumerator enumerator3 = list4.GetEnumerator())
											{
												while (enumerator3.MoveNext())
												{
													UserItemData current4 = enumerator3.Current;
													if (current4 != null)
													{
														Dictionary<int, Coordinates> dictionary = current4.Dictionary_0;
														if (dictionary == null)
														{
															dictionary = new Dictionary<int, Coordinates>();
														}
														List<UserItemData> list5 = new List<UserItemData>(this.method_45(current4.Int32_0, current4.Int32_1));
														if (list5.Count > 1 && num4 + 1 != num2)
														{
															num2++;
															break;
														}
														foreach (Coordinates current5 in dictionary.Values)
														{
															list5 = new List<UserItemData>(this.method_45(current5.X, current5.Y));
															if (list5.Count > 1 && num4 + 1 != num2)
															{
																num2++;
																break;
															}
														}
													}
												}
												continue;
											}
										}
										num++;
										current2.string_0 = "1";
										current2.method_5(false, true);
										current2.method_3(1);
										current2.method_10();
										if (current2.string_3.Length <= 0)
										{
											continue;
										}
										collection = current2.string_3.Split(new char[]
										{
											','
										});
										list = new List<string>(collection);
										list4 = new List<UserItemData>();
										foreach (string current3 in list)
										{
											list4.Add(this.method_28(Convert.ToUInt32(current3)));
										}
										bool flag3 = true;
										foreach (UserItemData current4 in list4)
										{
											if (current4 != null)
											{
												bool flag4 = false;
												Dictionary<int, Coordinates> dictionary = current4.Dictionary_0;
												if (dictionary == null)
												{
													dictionary = new Dictionary<int, Coordinates>();
												}
												if (this.method_96(current4.Int32_0, current4.Int32_1))
												{
													flag4 = true;
												}
												foreach (Coordinates current5 in dictionary.Values)
												{
													if (this.method_96(current5.X, current5.Y))
													{
														flag4 = true;
														break;
													}
												}
												if (!flag4)
												{
													flag3 = false;
												}
											}
										}
										if (flag3)
										{
											num2++;
											continue;
										}
										continue;
									}
									else
									{
										num4 = num2;
										num++;
										current2.string_0 = "1";
										current2.method_5(false, true);
										current2.method_3(1);
										current2.method_10();
										if (current2.string_3.Length <= 0)
										{
											continue;
										}
										string[] collection = current2.string_3.Split(new char[]
										{
											','
										});
										List<string> list = new List<string>(collection);
										List<UserItemData> list4 = new List<UserItemData>();
										foreach (string current3 in list)
										{
											list4.Add(this.method_28(Convert.ToUInt32(current3)));
										}
										if (class33_1 == null)
										{
											continue;
										}
										using (List<UserItemData>.Enumerator enumerator3 = list4.GetEnumerator())
										{
											while (enumerator3.MoveNext())
											{
												UserItemData current4 = enumerator3.Current;
												if (current4 != null)
												{
													Dictionary<int, Coordinates> dictionary = current4.Dictionary_0;
													if (dictionary == null)
													{
														dictionary = new Dictionary<int, Coordinates>();
													}
													if (class33_1.int_3 == current4.Int32_0 && class33_1.int_4 == current4.Int32_1 && num4 + 1 != num2)
													{
														num2++;
														break;
													}
													foreach (Coordinates current5 in dictionary.Values)
													{
														if (class33_1.int_3 == current5.X && class33_1.int_4 == current5.Y && num4 + 1 != num2)
														{
															num2++;
															break;
														}
													}
												}
											}
											continue;
										}
									}
								}
								num4 = num2;
								num++;
								current2.string_0 = "1";
								current2.method_5(false, true);
								current2.method_3(1);
								if (current2.string_2.Length > 0)
								{
									string string_11 = current2.string_2.Split(new char[]
									{
										':'
									})[0].ToLower();
									string string_12 = current2.string_2.Split(new char[]
									{
										':'
									})[1];
									if (class33_1 != null)
									{
										if (!class33_1.Boolean_4 && this.method_18(class33_1, string_11, string_12))
										{
											num2++;
										}
									}
									else
									{
										Class33[] array = this.class33_0;
										for (int i = 0; i < array.Length; i++)
										{
											Class33 class2 = array[i];
											if (class2 != null && !class2.Boolean_4 && this.method_18(class2, string_11, string_12) && num4 + 1 != num2)
											{
												num2++;
												break;
											}
										}
									}
								}
							}
						}
						if (num != num2)
						{
							result = false;
							return result;
						}
					}
					catch
					{
					}
					if (flag && num == num2)
					{
						class63_0.string_0 = "1";
						class63_0.method_5(false, true);
						class63_0.method_3(1);
						List<UserItemData> list6 = this.method_93(class63_0.Int32_0, class63_0.Int32_1);
						if (list6 == null)
						{
							result = false;
							return result;
						}
						bool flag5 = false;
						foreach (UserItemData current2 in list6)
						{
							if (current2.GetBaseItem().InteractionType.ToLower() == "wf_xtra_random")
							{
								flag5 = true;
								break;
							}
						}
						if (flag5)
						{
							List<UserItemData> list7 = new List<UserItemData>();
							Random random = new Random();
							while (list6.Count != 0)
							{
								int index = random.Next(0, list6.Count);
								list7.Add(list6[index]);
								list6.RemoveAt(index);
							}
							list6 = list7;
						}
						foreach (UserItemData current2 in list6)
						{
							if (flag5 && flag2)
							{
								break;
							}
							text = current2.GetBaseItem().InteractionType.ToLower();
							switch (text)
							{
							case "wf_act_give_phx":
								current2.string_0 = "1";
								current2.method_5(false, true);
								current2.method_3(1);
								if (current2.string_2.Length > 0)
								{
									string string_11 = current2.string_2.Split(new char[]
									{
										':'
									})[0].ToLower();
									string string_12 = current2.string_2.Split(new char[]
									{
										':'
									})[1];
									if (class33_1 != null)
									{
										if (!class33_1.Boolean_4)
										{
											this.method_19(class33_1, string_11, string_12);
										}
									}
									else
									{
										Class33[] array = this.class33_0;
										for (int i = 0; i < array.Length; i++)
										{
											Class33 class2 = array[i];
											if (class2 != null && !class2.Boolean_4)
											{
												this.method_19(class2, string_11, string_12);
											}
										}
									}
									flag2 = true;
								}
								break;
							case "wf_act_saymsg":
								current2.string_0 = "1";
								current2.method_5(false, true);
								current2.method_3(1);
								if (current2.string_2.Length > 0)
								{
									string text2 = current2.string_2;
									text2 = ChatCommandHandler.smethod_4(text2);
									if (text2.Length > 100)
									{
										text2 = text2.Substring(0, 100);
									}
									if (class33_1 != null)
									{
										if (!class33_1.Boolean_4)
										{
											class33_1.method_16().GetHabbo().method_28(text2);
										}
									}
									else
									{
										Class33[] array = this.class33_0;
										for (int i = 0; i < array.Length; i++)
										{
											Class33 class2 = array[i];
											if (class2 != null && !class2.Boolean_4)
											{
												class2.method_16().GetHabbo().method_28(text2);
											}
										}
									}
									flag2 = true;
								}
								break;
							case "wf_act_moveuser":
								current2.string_0 = "1";
								current2.method_5(false, true);
								current2.method_3(1);
								current2.method_10();
								if (current2.string_3.Length > 0)
								{
									string[] collection = current2.string_3.Split(new char[]
									{
										','
									});
									List<string> list = new List<string>(collection);
									Random random2 = new Random();
									int num5 = random2.Next(0, list.Count - 1);
									UserItemData class3 = this.method_28(Convert.ToUInt32(list[num5]));
									if (class3 != null)
									{
										if (class33_1 != null)
										{
											this.byte_0[class33_1.int_3, class33_1.int_4] = 1;
											this.byte_0[class33_1.int_12, class33_1.int_13] = 1;
											this.byte_0[class3.Int32_0, class3.Int32_1] = 1;
											class33_1.bool_6 = false;
											class33_1.int_12 = class3.Int32_0;
											class33_1.int_13 = class3.Int32_1;
											class33_1.double_1 = class3.Double_0;
											class33_1.method_7(class3.Int32_0, class3.Int32_1, class3.Double_0);
											class33_1.bool_7 = true;
											if (!current2.dictionary_1.ContainsKey(class33_1))
											{
												current2.dictionary_1.Add(class33_1, 10);
											}
											if (class33_1.class34_1 != null)
											{
												class33_1.class34_1.class33_0 = null;
												class33_1.class33_0 = null;
												class33_1.class34_1 = null;
											}
											this.method_87(class33_1, true, false);
										}
										else
										{
											Class33[] array = this.class33_0;
											for (int i = 0; i < array.Length; i++)
											{
												Class33 class2 = array[i];
												if (class2 != null)
												{
													this.byte_0[class2.int_3, class2.int_4] = 1;
													this.byte_0[class3.Int32_0, class3.Int32_1] = 1;
													class2.method_7(class3.Int32_0, class3.Int32_1, class3.Double_0);
													class2.bool_7 = true;
													if (!current2.dictionary_1.ContainsKey(class2))
													{
														current2.dictionary_1.Add(class2, 10);
													}
												}
											}
										}
										flag2 = true;
									}
								}
								break;
							case "wf_act_togglefurni":
								current2.string_0 = "1";
								current2.method_5(false, true);
								current2.method_3(1);
								if (current2.string_3.Length > 0)
								{
									string[] collection = current2.string_3.Split(new char[]
									{
										','
									});
									IEnumerable<string> enumerable = new List<string>(collection);
									List<string> list2 = enumerable.ToList<string>();
									foreach (string current in enumerable)
									{
										UserItemData class3 = this.method_28(Convert.ToUInt32(current));
										if (class3 != null)
										{
											class3.Class69_0.OnTrigger(null, class3, 0, true);
										}
										else
										{
											list2.Remove(current);
										}
									}
									flag2 = true;
								}
								break;
							case "wf_act_givepoints":
								current2.string_0 = "1";
								current2.method_5(false, true);
								current2.method_3(1);
								if (class33_1 != null && current2.string_2.Length > 0)
								{
									this.method_88(class33_1.int_14 + 2, Convert.ToInt32(current2.string_2), current2);
									flag2 = true;
								}
								break;
							case "wf_act_moverotate":
								current2.string_0 = "1";
								current2.method_5(false, true);
								current2.method_3(1);
								current2.method_9();
								if (current2.string_4.Length > 0)
								{
									string[] collection = current2.string_4.Split(new char[]
									{
										','
									});
									IEnumerable<string> enumerable2 = new List<string>(collection);
									foreach (string current in enumerable2)
									{
										UserItemData class3 = this.method_28(Convert.ToUInt32(current));
										if (class3 != null)
										{
											if (current2.string_2 != "0" && current2.string_2 != "")
											{
												ThreeDCoord gstruct1_ = class3.GStruct1_1;
												int num5 = 0;
												int num6 = 0;
												int num7 = 0;
												if (current2.string_2 == "1")
												{
													Random random3 = new Random();
													num5 = random3.Next(1, 5);
												}
												else
												{
													if (current2.string_2 == "2")
													{
														Random random3 = new Random();
														num6 = random3.Next(1, 3);
													}
													else
													{
														if (current2.string_2 == "3")
														{
															Random random3 = new Random();
															num7 = random3.Next(1, 3);
														}
													}
												}
												if (current2.string_2 == "4" || num5 == 1 || num7 == 1)
												{
													gstruct1_ = class3.method_1(4);
												}
												else
												{
													if (current2.string_2 == "5" || num5 == 2 || num6 == 1)
													{
														gstruct1_ = class3.method_1(6);
													}
													else
													{
														if (current2.string_2 == "6" || num5 == 3 || num7 == 2)
														{
															gstruct1_ = class3.method_1(0);
														}
														else
														{
															if (current2.string_2 == "7" || num5 == 4 || num6 == 2)
															{
																gstruct1_ = class3.method_1(2);
															}
														}
													}
												}
												if (this.method_37(gstruct1_.x, gstruct1_.y, true, true, false, true, false) && class3.GetBaseItem().InteractionType != "wf_trg_timer")
												{
													this.method_41(class3, gstruct1_, current2.uint_0, class3.Double_0);
												}
											}
											if (current2.string_3.Length > 0 && current2.string_3 != "0" && current2.string_3 != "")
											{
												int num5 = 0;
												if (current2.string_3 == "1")
												{
													num5 = class3.int_3 + 2;
													if (num5 > 6)
													{
														num5 = 0;
													}
												}
												else
												{
													if (current2.string_3 == "2")
													{
														num5 = class3.int_3 - 2;
														if (num5 < 0)
														{
															num5 = 6;
														}
													}
													else
													{
														if (current2.string_3 == "3")
														{
															Random random3 = new Random();
															num5 = random3.Next(1, 5);
															if (num5 == 1)
															{
																num5 = 0;
															}
															else
															{
																if (num5 == 2)
																{
																	num5 = 2;
																}
																else
																{
																	if (num5 == 3)
																	{
																		num5 = 4;
																	}
																	else
																	{
																		if (num5 == 4)
																		{
																			num5 = 6;
																		}
																	}
																}
															}
														}
													}
												}
												if (current2.method_8().method_79(null, class3, class3.Int32_0, class3.Int32_1, num5, false, true, false))
												{
													flag2 = true;
												}
											}
										}
									}
									flag2 = true;
								}
								break;
							case "wf_act_matchfurni":
								current2.string_0 = "1";
								current2.method_5(false, true);
								current2.method_3(1);
								current2.method_9();
								if (current2.string_4.Length > 0 && current2.string_2.Length > 0)
								{
									string[] collection = current2.string_4.Split(new char[]
									{
										','
									});
									IEnumerable<string> enumerable = new List<string>(collection);
									string[] collection2 = current2.string_2.Split(new char[]
									{
										';'
									});
									List<string> list8 = new List<string>(collection2);
									int num8 = 0;
									foreach (string current in enumerable)
									{
										UserItemData class3 = this.method_28(Convert.ToUInt32(current));
										if (class3 != null && !(class3.GetBaseItem().InteractionType.ToLower() == "dice"))
										{
											string[] collection3 = list8[num8].Split(new char[]
											{
												','
											});
											List<string> list9 = new List<string>(collection3);
											bool flag6 = false;
											bool flag7 = false;
											if (current2.string_3 != "" && class3 != null)
											{
												int int_ = class3.Int32_0;
												int int_2 = class3.Int32_1;
												if (current2.string_3.StartsWith("I"))
												{
													class3.string_0 = list9[4];
													flag7 = true;
												}
												if (current2.string_3.Substring(1, 1) == "I")
												{
													class3.int_3 = Convert.ToInt32(list9[3]);
													flag6 = true;
												}
												if (current2.string_3.EndsWith("I"))
												{
													int_ = Convert.ToInt32(list9[0]);
													int_2 = Convert.ToInt32(list9[1]);
													flag6 = true;
												}
												if (flag6)
												{
													this.method_40(class3, int_, int_2, current2.uint_0, class3.Double_0);
												}
												if (flag7)
												{
													class3.method_5(false, true);
												}
												this.method_22();
											}
											num8++;
										}
									}
								}
								flag2 = true;
								break;
							}
						}
					}
					result = flag2;
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}
		internal void method_22()
		{
			this.gstruct1_0 = new ThreeDCoord[this.Class28_0.int_4, this.Class28_0.int_5];
			this.double_0 = new double[this.Class28_0.int_4, this.Class28_0.int_5];
			this.byte_2 = new byte[this.Class28_0.int_4, this.Class28_0.int_5];
			this.byte_1 = new byte[this.Class28_0.int_4, this.Class28_0.int_5];
			this.byte_0 = new byte[this.Class28_0.int_4, this.Class28_0.int_5];
			this.double_1 = new double[this.Class28_0.int_4, this.Class28_0.int_5];
			this.double_2 = new double[this.Class28_0.int_4, this.Class28_0.int_5];
			for (int i = 0; i < this.Class28_0.int_5; i++)
			{
				for (int j = 0; j < this.Class28_0.int_4; j++)
				{
					this.double_0[j, i] = 0.0;
					this.byte_0[j, i] = 0;
					this.byte_2[j, i] = 0;
					this.byte_1[j, i] = 0;
					this.gstruct1_0[j, i] = new ThreeDCoord(j, i);
					if (j == this.Class28_0.int_0 && i == this.Class28_0.int_1)
					{
						this.byte_0[j, i] = 3;
					}
					else
					{
                        if (this.Class28_0.squareState[j, i] == SquareState.OPEN)
						{
							this.byte_0[j, i] = 1;
						}
						else
						{
                            if (this.Class28_0.squareState[j, i] == SquareState.SEAT)
							{
								this.byte_0[j, i] = 3;
							}
						}
					}
				}
			}
			foreach (UserItemData @class in this.Hashtable_0.Values)
			{
				try
				{
					if (@class.GetBaseItem().char_0 == 's')
					{
						if (@class.Int32_0 >= this.Class28_0.int_4 || @class.Int32_1 >= this.Class28_0.int_5 || @class.Int32_1 < 0 || @class.Int32_0 < 0)
						{
							this.method_29(null, @class.uint_0, true, false);
							GameClient class2 = Phoenix.GetGame().GetClientManager().GetClientByHabbo(this.Owner);
							if (class2 != null)
							{
								class2.GetHabbo().method_23().method_11(@class.uint_0, @class.uint_2, @class.string_0, true);
							}
						}
						else
						{
							if (@class.Double_1 > this.double_1[@class.Int32_0, @class.Int32_1])
							{
								this.double_1[@class.Int32_0, @class.Int32_1] = @class.Double_1;
							}
							if (@class.GetBaseItem().bool_2)
							{
								this.double_2[@class.Int32_0, @class.Int32_1] = @class.Double_1;
							}
							if (@class.GetBaseItem().Height > 0.0 || @class.GetBaseItem().byte_1 != 0 || @class.GetBaseItem().byte_0 != 0 || @class.GetBaseItem().bool_2 || !(@class.GetBaseItem().InteractionType.ToLower() != "bed"))
							{
								if (this.double_0[@class.Int32_0, @class.Int32_1] <= @class.Double_0)
								{
									this.double_0[@class.Int32_0, @class.Int32_1] = @class.Double_0;
									if (@class.GetBaseItem().byte_1 > 0)
									{
										this.byte_2[@class.Int32_0, @class.Int32_1] = @class.GetBaseItem().byte_1;
									}
									else
									{
										if (this.byte_1[@class.Int32_0, @class.Int32_1] != 0)
										{
											this.byte_2[@class.Int32_0, @class.Int32_1] = 0;
										}
									}
									if (@class.GetBaseItem().byte_0 > 0)
									{
										this.byte_1[@class.Int32_0, @class.Int32_1] = @class.GetBaseItem().byte_0;
									}
									else
									{
										if (this.byte_1[@class.Int32_0, @class.Int32_1] != 0)
										{
											this.byte_1[@class.Int32_0, @class.Int32_1] = 0;
										}
									}
									if (@class.GetBaseItem().bool_1)
									{
										if (this.byte_0[@class.Int32_0, @class.Int32_1] != 3)
										{
											this.byte_0[@class.Int32_0, @class.Int32_1] = 1;
										}
									}
									else
									{
										if (@class.Double_0 <= this.Class28_0.double_1[@class.Int32_0, @class.Int32_1] + 0.1 && @class.GetBaseItem().InteractionType.ToLower() == "gate" && @class.string_0 == "1")
										{
											if (this.byte_0[@class.Int32_0, @class.Int32_1] != 3)
											{
												this.byte_0[@class.Int32_0, @class.Int32_1] = 1;
											}
										}
										else
										{
											if (@class.GetBaseItem().bool_2 || @class.GetBaseItem().InteractionType.ToLower() == "bed")
											{
												this.byte_0[@class.Int32_0, @class.Int32_1] = 3;
											}
											else
											{
												if (this.byte_0[@class.Int32_0, @class.Int32_1] != 3)
												{
													this.byte_0[@class.Int32_0, @class.Int32_1] = 0;
												}
											}
										}
									}
								}
								if (@class.GetBaseItem().bool_2 || @class.GetBaseItem().InteractionType.ToLower() == "bed")
								{
									this.byte_0[@class.Int32_0, @class.Int32_1] = 3;
								}
								Dictionary<int, Coordinates> dictionary = @class.Dictionary_0;
								if (dictionary == null)
								{
									dictionary = new Dictionary<int, Coordinates>();
								}
								foreach (Coordinates current in dictionary.Values)
								{
									if (@class.Double_1 > this.double_1[current.X, current.Y])
									{
										this.double_1[current.X, current.Y] = @class.Double_1;
									}
									if (@class.GetBaseItem().bool_2)
									{
										this.double_2[current.X, current.Y] = @class.Double_1;
									}
									if (this.double_0[current.X, current.Y] <= @class.Double_0)
									{
										this.double_0[current.X, current.Y] = @class.Double_0;
										if (@class.GetBaseItem().byte_1 > 0)
										{
											this.byte_2[current.X, current.Y] = @class.GetBaseItem().byte_1;
										}
										else
										{
											if (this.byte_1[current.X, current.Y] != 0)
											{
												this.byte_2[current.X, current.Y] = 0;
											}
										}
										if (@class.GetBaseItem().byte_0 > 0)
										{
											this.byte_1[current.X, current.Y] = @class.GetBaseItem().byte_0;
										}
										else
										{
											if (this.byte_1[current.X, current.Y] != 0)
											{
												this.byte_1[current.X, current.Y] = 0;
											}
											else
											{
												if (@class.GetBaseItem().bool_1)
												{
													if (this.byte_0[current.X, current.Y] != 3)
													{
														this.byte_0[current.X, current.Y] = 1;
													}
												}
												else
												{
													if (@class.Double_0 <= this.Class28_0.double_1[@class.Int32_0, @class.Int32_1] + 0.1 && @class.GetBaseItem().InteractionType.ToLower() == "gate" && @class.string_0 == "1")
													{
														if (this.byte_0[current.X, current.Y] != 3)
														{
															this.byte_0[current.X, current.Y] = 1;
														}
													}
													else
													{
														if (@class.GetBaseItem().bool_2 || @class.GetBaseItem().InteractionType.ToLower() == "bed")
														{
															this.byte_0[current.X, current.Y] = 3;
														}
														else
														{
															if (this.byte_0[current.X, current.Y] != 3)
															{
																this.byte_0[current.X, current.Y] = 0;
															}
														}
													}
												}
											}
										}
									}
									if (@class.GetBaseItem().bool_2 || @class.GetBaseItem().InteractionType.ToLower() == "bed")
									{
										this.byte_0[current.X, current.Y] = 3;
									}
									if (@class.GetBaseItem().InteractionType.ToLower() == "bed")
									{
										this.byte_0[current.X, current.Y] = 3;
										if (@class.int_3 == 0 || @class.int_3 == 4)
										{
											this.gstruct1_0[current.X, current.Y].y = @class.Int32_1;
										}
										if (@class.int_3 == 2 || @class.int_3 == 6)
										{
											this.gstruct1_0[current.X, current.Y].x = @class.Int32_0;
										}
									}
								}
							}
						}
					}
				}
				catch
				{
					this.method_29(null, @class.uint_0, true, false);
					GameClient class2 = Phoenix.GetGame().GetClientManager().GetClientByHabbo(this.Owner);
					if (class2 != null)
					{
						class2.GetHabbo().method_23().method_11(@class.uint_0, @class.uint_2, @class.string_0, true);
					}
				}
			}
			if (!this.AllowWalkthrough)
			{
				for (int k = 0; k < this.class33_0.Length; k++)
				{
					Class33 class3 = this.class33_0[k];
					if (class3 != null)
					{
						this.byte_0[class3.int_3, class3.int_4] = 0;
					}
				}
			}
			this.byte_0[this.Class28_0.int_0, this.Class28_0.int_1] = 3;
		}
		public void method_23()
		{
			this.list_1 = new List<uint>();
			DataTable dataTable = null;
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				dataTable = @class.ReadDataTable("SELECT room_rights.user_id FROM room_rights WHERE room_id = '" + this.uint_0 + "'");
			}
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					this.list_1.Add((uint)dataRow["user_id"]);
				}
			}
		}
		internal List<UserItemData> method_24(GameClient class16_0)
		{
			List<UserItemData> list = new List<UserItemData>();
			foreach (UserItemData @class in this.Hashtable_0.Values)
			{
				@class.Class69_0.OnRemove(class16_0, @class);
				ServerMessage gClass = new ServerMessage(94u);
				gClass.AppendRawUInt(@class.uint_0);
				gClass.AppendStringWithBreak("");
				gClass.AppendBoolean(false);
				this.SendMessage(gClass, null);
				list.Add(@class);
			}
			foreach (UserItemData @class in this.Hashtable_1.Values)
			{
				@class.Class69_0.OnRemove(class16_0, @class);
				ServerMessage gClass = new ServerMessage(84u);
				gClass.AppendRawUInt(@class.uint_0);
				gClass.AppendStringWithBreak("");
				gClass.AppendBoolean(false);
				this.SendMessage(gClass, null);
				list.Add(@class);
			}
			this.hashtable_4.Clear();
			this.hashtable_0.Clear();
			this.hashtable_1.Clear();
			this.hashtable_2.Clear();
			this.hashtable_3.Clear();
			using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
			{
				class2.ExecuteQuery(string.Concat(new object[]
				{
					"UPDATE items SET room_id = 0, user_id = '",
					class16_0.GetHabbo().Id,
					"' WHERE room_id = '",
					this.Id,
					"'"
				}));
			}
			this.method_22();
			this.method_83();
			return list;
		}
		public void method_25()
		{
			this.hashtable_0.Clear();
			this.hashtable_4.Clear();
			DataTable dataTable;
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				dataTable = @class.ReadDataTable("SELECT id, base_item, extra_data, x, y, z, rot, wall_pos FROM items WHERE room_id = '" + this.uint_0 + "' ORDER BY room_id DESC");
			}
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					UserItemData class2 = new UserItemData((uint)dataRow["id"], this.Id, (uint)dataRow["base_item"], (string)dataRow["extra_data"], (int)dataRow["x"], (int)dataRow["y"], (double)dataRow["z"], (int)dataRow["rot"], (string)dataRow["wall_pos"], this);
					if (class2.Boolean_0)
					{
						this.bool_11 = true;
					}
					if (class2.GetBaseItem().InteractionType.ToLower().Contains("wf_") || class2.GetBaseItem().InteractionType.ToLower().Contains("fbgate"))
					{
						DataRow dataRow2;
						using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
						{
							dataRow2 = @class.ReadDataRow("SELECT extra1,extra2,extra3,extra4,extra5 FROM wired_items WHERE item_id = '" + class2.uint_0 + "'");
						}
						if (dataRow2 != null)
						{
							class2.string_2 = (string)dataRow2["extra1"];
							class2.string_3 = (string)dataRow2["extra2"];
							class2.string_4 = (string)dataRow2["extra3"];
							class2.string_5 = (string)dataRow2["extra4"];
							class2.string_6 = (string)dataRow2["extra5"];
						}
					}
					string text = class2.GetBaseItem().InteractionType.ToLower();
					switch (text)
					{
					case "dice":
						if (class2.string_0 == "-1")
						{
							class2.string_0 = "0";
						}
						break;
					case "fbgate":
						if (class2.string_0 != "" && class2.string_0.Contains(','))
						{
							class2.string_2 = class2.string_0.Split(new char[]
							{
								','
							})[0];
							class2.string_3 = class2.string_0.Split(new char[]
							{
								','
							})[1];
						}
						break;
					case "dimmer":
						if (this.class67_0 == null)
						{
							this.class67_0 = new MoodlightData(class2.uint_0);
						}
						break;
					case "bb_patch":
						this.list_5.Add(class2);
						if (class2.string_0 == "5")
						{
							this.list_6.Add(class2);
						}
						else
						{
							if (class2.string_0 == "8")
							{
								this.list_7.Add(class2);
							}
							else
							{
								if (class2.string_0 == "11")
								{
									this.list_9.Add(class2);
								}
								else
								{
									if (class2.string_0 == "14")
									{
										this.list_8.Add(class2);
									}
								}
							}
						}
						break;
					case "blue_score":
						this.list_12.Add(class2);
						break;
					case "green_score":
						this.list_13.Add(class2);
						break;
					case "red_score":
						this.list_10.Add(class2);
						break;
					case "yellow_score":
						this.list_11.Add(class2);
						break;
					case "stickiepole":
						this.list_3.Add(class2);
						break;
					case "wf_trg_onsay":
					case "wf_trg_enterroom":
					case "wf_trg_furnistate":
					case "wf_trg_onfurni":
					case "wf_trg_offfurni":
					case "wf_trg_gameend":
					case "wf_trg_gamestart":
					case "wf_trg_attime":
					case "wf_trg_atscore":
						if (!this.list_14.Contains(class2))
						{
							this.list_14.Add(class2);
						}
						break;
					case "wf_trg_timer":
						if (class2.string_2.Length <= 0)
						{
							class2.string_2 = "10";
						}
						if (!this.list_14.Contains(class2))
						{
							this.list_14.Add(class2);
						}
						class2.bool_0 = true;
						class2.method_3(1);
						break;
					case "wf_act_saymsg":
					case "wf_act_moveuser":
					case "wf_act_togglefurni":
					case "wf_act_givepoints":
					case "wf_act_moverotate":
					case "wf_act_matchfurni":
					case "wf_act_give_phx":
						if (!this.list_15.Contains(class2))
						{
							this.list_15.Add(class2);
						}
						break;
					case "wf_cnd_trggrer_on_frn":
					case "wf_cnd_furnis_hv_avtrs":
					case "wf_cnd_has_furni_on":
					case "wf_cnd_phx":
						if (!this.list_16.Contains(class2))
						{
							this.list_16.Add(class2);
						}
						break;
					}
					if (this.hashtable_0.Contains(class2.uint_0))
					{
						this.hashtable_0.Remove(class2.uint_0);
					}
					if (this.hashtable_4.Contains(class2.uint_0))
					{
						this.hashtable_4.Remove(class2.uint_0);
					}
					if (class2.Boolean_2)
					{
						this.hashtable_0.Add(class2.uint_0, class2);
					}
					else
					{
						this.hashtable_4.Add(class2.uint_0, class2);
					}
				}
			}
		}
		public bool method_26(GameClient class16_0)
		{
			return this.method_27(class16_0, false);
		}
		public bool method_27(GameClient class16_0, bool bool_13)
		{
			bool result;
			try
			{
				if (class16_0.GetHabbo().Username.ToLower() == this.Owner.ToLower())
				{
					result = true;
					return result;
				}
				if (class16_0.GetHabbo().HasFuse("acc_anyroomowner") && bool_13)
				{
					result = true;
					return result;
				}
				if (!bool_13)
				{
					if (class16_0.GetHabbo().HasFuse("acc_anyroomrights"))
					{
						result = true;
						return result;
					}
					if (this.list_1.Contains(class16_0.GetHabbo().Id))
					{
						result = true;
						return result;
					}
					if (this.bool_8)
					{
						result = true;
						return result;
					}
				}
			}
			catch
			{
			}
			result = false;
			return result;
		}
		public UserItemData method_28(uint uint_2)
		{
			UserItemData result;
			if ((this.hashtable_0 != null && this.hashtable_0.ContainsKey(uint_2)) || (this.hashtable_4 != null && this.hashtable_4.ContainsKey(uint_2)))
			{
				UserItemData @class = this.hashtable_0[uint_2] as UserItemData;
				if (@class != null)
				{
					result = @class;
				}
				else
				{
					result = (this.hashtable_4[uint_2] as UserItemData);
				}
			}
			else
			{
				result = null;
			}
			return result;
		}
		public void method_29(GameClient class16_0, uint uint_2, bool bool_13, bool bool_14)
		{
			UserItemData @class = this.method_28(uint_2);
			if (@class != null)
			{
				Dictionary<int, Coordinates> dictionary = this.method_94(@class.GetBaseItem().int_2, @class.GetBaseItem().int_1, @class.Int32_0, @class.Int32_1, @class.int_3);
				@class.Class69_0.OnRemove(class16_0, @class);
				if (@class.Boolean_1)
				{
					ServerMessage gClass = new ServerMessage(84u);
					gClass.AppendRawUInt(@class.uint_0);
					gClass.AppendStringWithBreak("");
					gClass.AppendBoolean(false);
					this.SendMessage(gClass, null);
				}
				else
				{
					if (@class.Boolean_2)
					{
						ServerMessage gClass = new ServerMessage(94u);
						gClass.AppendRawUInt(@class.uint_0);
						gClass.AppendStringWithBreak("");
						gClass.AppendBoolean(false);
						this.SendMessage(gClass, null);
						string text = @class.GetBaseItem().InteractionType.ToLower();
						switch (text)
						{
						case "bb_patch":
							this.list_5.Remove(@class);
							if (@class.string_0 == "5")
							{
								this.list_6.Remove(@class);
							}
							else
							{
								if (@class.string_0 == "8")
								{
									this.list_7.Remove(@class);
								}
								else
								{
									if (@class.string_0 == "11")
									{
										this.list_9.Remove(@class);
									}
									else
									{
										if (@class.string_0 == "14")
										{
											this.list_8.Remove(@class);
										}
									}
								}
							}
							break;
						case "blue_score":
							this.list_12.Remove(@class);
							break;
						case "green_score":
							this.list_13.Remove(@class);
							break;
						case "red_score":
							this.list_10.Remove(@class);
							break;
						case "yellow_score":
							this.list_11.Remove(@class);
							break;
						case "stickiepole":
							this.list_3.Remove(@class);
							break;
						case "wf_trg_onsay":
						case "wf_trg_enterroom":
						case "wf_trg_furnistate":
						case "wf_trg_onfurni":
						case "wf_trg_offfurni":
						case "wf_trg_gameend":
						case "wf_trg_gamestart":
						case "wf_trg_attime":
						case "wf_trg_atscore":
							this.list_14.Remove(@class);
							break;
						case "wf_trg_timer":
							@class.bool_0 = false;
							this.list_14.Remove(@class);
							break;
						case "wf_act_saymsg":
						case "wf_act_moveuser":
						case "wf_act_togglefurni":
						case "wf_act_givepoints":
						case "wf_act_moverotate":
						case "wf_act_matchfurni":
						case "wf_act_give_phx":
							this.list_15.Remove(@class);
							break;
						case "wf_cnd_trggrer_on_frn":
						case "wf_cnd_furnis_hv_avtrs":
						case "wf_cnd_has_furni_on":
						case "wf_cnd_phx":
							this.list_16.Remove(@class);
							break;
						}
					}
				}
				if (@class.Boolean_1)
				{
					this.hashtable_4.Remove(@class.uint_0);
				}
				else
				{
					this.hashtable_0.Remove(@class.uint_0);
				}
				if (this.hashtable_3.Contains(@class.uint_0))
				{
					this.hashtable_3.Remove(@class.uint_0);
				}
				if (this.hashtable_2.Contains(@class.uint_0))
				{
					this.hashtable_2.Remove(@class.uint_0);
				}
				if (!this.hashtable_1.Contains(@class.uint_0))
				{
					this.hashtable_1.Add(@class.uint_0, @class);
				}
				if (bool_13)
				{
					using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
					{
						class2.ExecuteQuery("DELETE FROM items WHERE id = '" + uint_2 + "' LIMIT 1");
					}
				}
				if (bool_14)
				{
					this.method_22();
				}
				this.method_87(this.method_43(@class.Int32_0, @class.Int32_1), true, true);
				foreach (Coordinates current in dictionary.Values)
				{
					this.method_87(this.method_43(current.X, current.Y), true, true);
				}
			}
		}
		public bool method_30(int int_17, int int_18, double double_3, bool bool_13, bool bool_14)
		{
			return this.AllowWalkthrough || bool_14 || this.method_43(int_17, int_18) == null;
		}
		private void method_31(string string_10)
		{
			for (int i = 0; i < this.class33_0.Length; i++)
			{
				Class33 @class = this.class33_0[i];
				if (@class != null && !@class.Boolean_4)
				{
					@class.method_16().SendNotif(string_10);
				}
			}
		}
		private void method_32(object object_0)
		{
			this.method_33();
		}
		private void method_33()
		{
			int num = 0;
			if (!this.bool_6 && !this.bool_7)
			{
				try
				{
					this.int_14++;
					if (this.bool_10 && this.int_14 >= 30)
					{
						using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
						{
							@class.ExecuteQuery(string.Concat(new object[]
							{
								"UPDATE rooms SET users_now = '",
								this.Int32_0,
								"' WHERE id = '",
								this.uint_0,
								"' LIMIT 1"
							}));
						}
						this.int_14 = 0;
					}
					this.method_35();
					int num2 = 0;
					try
					{
						if (this.hashtable_0 != null)
						{
							foreach (UserItemData class2 in this.Hashtable_0.Values)
							{
								if (class2.bool_1)
								{
									class2.method_2();
								}
							}
						}
					}
					catch (Exception ex)
					{
                        Logging.LogThreadException(ex.ToString(), "Room [ID: " + this.Id + "] cycle task -- Process Floor Items");
						this.method_34();
					}
					try
					{
						if (this.hashtable_4 != null)
						{
							foreach (UserItemData class2 in this.Hashtable_1.Values)
							{
								if (class2.bool_1)
								{
									class2.method_2();
								}
							}
						}
					}
					catch (Exception ex)
					{
                        Logging.LogThreadException(ex.ToString(), "Room [ID: " + this.Id + "] cycle task -- Process Wall Items");
						this.method_34();
					}
					List<uint> list = new List<uint>();
					int num3 = 0;
					if (this.class33_0 != null)
					{
						try
						{
							for (int i = 0; i < this.class33_0.Length; i++)
							{
								Class33 class3 = this.class33_0[i];
								if (class3 != null)
								{
									num = 1;
									if (!class3.Boolean_4 && class3.method_16() != null)
									{
										num3++;
										if (class3.method_16().GetHabbo() != null && class3.method_16().GetHabbo().int_4 > 0)
										{
											class3.method_16().GetHabbo().int_4--;
											if (class3.method_16().GetHabbo().int_4 == 0)
											{
												class3.method_16().GetHabbo().bool_3 = false;
											}
										}
									}
									class3.int_1++;
									num = 2;
									if (!class3.bool_8 && class3.int_1 >= Config.int_14)
									{
										class3.bool_8 = true;
										ServerMessage gClass = new ServerMessage(486u);
										gClass.AppendInt32(class3.int_0);
										gClass.AppendBoolean(true);
										this.SendMessage(gClass, null);
									}
									num = 3;
									if (class3.method_16() == null && !class3.Boolean_4)
									{
										this.class33_0[i] = null;
										if (!class3.bool_1)
										{
											this.byte_0[class3.int_3, class3.int_4] = class3.byte_0;
										}
										ServerMessage gClass2 = new ServerMessage(29u);
										gClass2.AppendRawInt32(class3.int_0);
										this.SendMessage(gClass2, null);
										this.method_50();
									}
									num = 4;
									if (class3.Boolean_2 && !list.Contains(class3.uint_0))
									{
										list.Add(class3.uint_0);
									}
									num = 5;
									if (class3.int_5 > 0)
									{
										class3.int_6--;
										if (class3.int_6 <= 0)
										{
											class3.method_8(0);
										}
									}
									num = 6;
									if (class3.bool_4 && class3.class34_1 == null)
									{
										num = 7;
										if (class3.Boolean_4 && class3.class34_0.class33_0 != null && this.method_30(class3.int_12, class3.int_13, 0.0, true, true))
										{
											num = 8;
											this.method_85(class3);
											class3.int_3 = class3.int_12;
											class3.int_4 = class3.int_13;
											class3.double_0 = class3.double_1;
											class3.class34_0.class33_0.int_3 = class3.int_12;
											class3.class34_0.class33_0.int_4 = class3.int_13;
											class3.class34_0.class33_0.double_0 = class3.double_1 + 1.0;
											class3.class34_0.class33_0.bool_4 = false;
											class3.class34_0.class33_0.method_12("mv");
											if (class3.int_3 == this.Class28_0.int_0 && class3.int_4 == this.Class28_0.int_1 && !list.Contains(class3.class34_0.class33_0.uint_0))
											{
												list.Add(class3.class34_0.class33_0.uint_0);
											}
											this.method_87(class3, true, true);
										}
										else
										{
											if (this.method_30(class3.int_12, class3.int_13, 0.0, true, class3.bool_1))
											{
												num = 8;
												this.method_85(class3);
												class3.int_3 = class3.int_12;
												class3.int_4 = class3.int_13;
												class3.double_0 = class3.double_1;
												if (class3.int_3 == this.Class28_0.int_0 && class3.int_4 == this.Class28_0.int_1 && !list.Contains(class3.uint_0) && !class3.Boolean_4)
												{
													list.Add(class3.uint_0);
												}
												this.method_87(class3, true, true);
											}
										}
										class3.bool_4 = false;
									}
									num = 9;
									if (class3.bool_6 && !class3.bool_5 && class3.class34_1 == null)
									{
										num = 10;
										SquarePoint @struct = DreamPathfinder.GetNextStep(class3.int_3, class3.int_4, class3.int_10, class3.int_11, this.byte_0, this.double_1, this.class28_0.double_1, this.double_2, this.class28_0.int_4, this.class28_0.int_5, class3.bool_1, this.bool_5);
										num = 11;
										if (@struct.X != class3.int_3 || @struct.Y != class3.int_4)
										{
											num = 12;
											int int32_ = @struct.X;
											int int32_2 = @struct.Y;
											class3.method_12("mv");
											double num4 = this.method_84(int32_, int32_2, this.method_93(int32_, int32_2));
											class3.Statusses.Remove("lay");
											class3.Statusses.Remove("sit");
											class3.method_11("mv", string.Concat(new object[]
											{
												int32_,
												",",
												int32_2,
												",",
												num4.ToString().Replace(',', '.')
											}));
											num = 13;
											if (class3.Boolean_4 && class3.class34_0.class33_0 != null)
											{
												class3.class34_0.class33_0.method_11("mv", string.Concat(new object[]
												{
													int32_,
													",",
													int32_2,
													",",
													(num4 + 1.0).ToString().Replace(',', '.')
												}));
											}
											int num5;
											if (class3.bool_3)
											{
												num5 = Class107.smethod_1(class3.int_3, class3.int_4, int32_, int32_2);
											}
											else
											{
												num5 = Class107.smethod_0(class3.int_3, class3.int_4, int32_, int32_2);
											}
											class3.int_8 = num5;
											class3.int_7 = num5;
											class3.bool_4 = true;
											class3.int_12 = int32_;
											class3.int_13 = int32_2;
											class3.double_1 = num4;
											num = 14;
											if (class3.Boolean_4 && class3.class34_0.class33_0 != null)
											{
												class3.class34_0.class33_0.int_8 = num5;
												class3.class34_0.class33_0.int_7 = num5;
												class3.class34_0.class33_0.bool_4 = true;
												class3.class34_0.class33_0.int_12 = int32_;
												class3.class34_0.class33_0.int_13 = int32_2;
												class3.class34_0.class33_0.double_1 = num4 + 1.0;
											}
											try
											{
												num = 15;
												if (!class3.Boolean_4)
												{
													if (class3.method_16().GetHabbo().string_6.ToLower() == "m" && this.byte_1[int32_, int32_2] > 0 && class3.byte_1 != this.byte_1[int32_, int32_2])
													{
														class3.method_16().GetHabbo().method_24().method_2((int)this.byte_1[int32_, int32_2], true);
														class3.byte_1 = this.byte_1[int32_, int32_2];
													}
													else
													{
														if (class3.method_16().GetHabbo().string_6.ToLower() == "f" && this.byte_2[int32_, int32_2] > 0 && class3.byte_1 != this.byte_2[int32_, int32_2])
														{
															class3.method_16().GetHabbo().method_24().method_2((int)this.byte_2[int32_, int32_2], true);
															class3.byte_1 = this.byte_2[int32_, int32_2];
														}
													}
												}
												else
												{
													if (!class3.Boolean_0)
													{
														if (this.byte_1[int32_, int32_2] > 0)
														{
															class3.class34_0.int_0 = (int)this.byte_1[int32_, int32_2];
															class3.byte_1 = this.byte_1[int32_, int32_2];
														}
														ServerMessage gClass3 = new ServerMessage(485u);
														gClass3.AppendInt32(class3.int_0);
														gClass3.AppendInt32(class3.class34_0.int_0);
														this.SendMessage(gClass3, null);
													}
												}
												goto IL_CE1;
											}
											catch
											{
												goto IL_CE1;
											}
											IL_B8B:
											this.method_87(class3, false, true);
											class3.bool_7 = true;
											if (class3.Boolean_4 && class3.class34_0.class33_0 != null)
											{
												this.method_87(class3.class34_0.class33_0, true, true);
												class3.class34_0.class33_0.bool_7 = true;
												goto IL_BE0;
											}
											goto IL_BE0;
											IL_CE1:
											num = 16;
											this.byte_0[class3.int_3, class3.int_4] = class3.byte_0;
											class3.byte_0 = this.byte_0[class3.int_12, class3.int_13];
											if (this.AllowWalkthrough)
											{
												goto IL_B8B;
											}
											this.byte_0[int32_, int32_2] = 0;
											goto IL_B8B;
										}
										num = 12;
										class3.bool_6 = false;
										class3.method_12("mv");
										class3.bool_10 = false;
										if (class3.Boolean_4 && class3.class34_0.class33_0 != null)
										{
											class3.class34_0.class33_0.method_12("mv");
											class3.class34_0.class33_0.bool_6 = false;
											class3.class34_0.class33_0.bool_10 = false;
											class3.class34_0.class33_0.bool_7 = true;
										}
										IL_BE0:
										class3.bool_7 = true;
									}
									else
									{
										num = 17;
										if (class3.Statusses.ContainsKey("mv") && class3.class34_1 == null)
										{
											num = 18;
											class3.method_12("mv");
											class3.bool_7 = true;
											if (class3.Boolean_4 && class3.class34_0.class33_0 != null)
											{
												class3.class34_0.class33_0.method_12("mv");
												class3.class34_0.class33_0.bool_7 = true;
											}
										}
									}
									if (class3.Boolean_4 || class3.Boolean_0)
									{
										try
										{
											class3.class99_0.OnTimerTick();
											goto IL_C9F;
										}
										catch
										{
											goto IL_C9F;
										}
									}
									goto IL_C9B;
									IL_C9F:
									if (class3.int_9 > 0)
									{
										if (class3.int_9 == 1)
										{
											this.method_87(class3, true, true);
										}
										class3.int_9--;
										goto IL_CD6;
									}
									goto IL_CD6;
									IL_C9B:
									num2++;
									goto IL_C9F;
								}
								IL_CD6:;
							}
						}
						catch (Exception ex)
						{
                            Logging.LogThreadException(ex.ToString(), string.Concat(new object[]
							{
								"Room [ID: ",
								this.Id,
								"] [Part: ",
								num,
								" cycle task -- Process Users Updates"
							}));
							this.method_34();
						}
					}
					try
					{
						foreach (uint current in list)
						{
							this.method_47(Phoenix.GetGame().GetClientManager().method_2(current), true, false);
						}
					}
					catch (Exception ex)
					{
                        Logging.LogThreadException(ex.ToString(), "Room [ID: " + this.Id + "] cycle task -- Remove Users");
						this.method_34();
					}
					if (num2 >= 1)
					{
						this.int_8 = 0;
					}
					else
					{
						this.int_8++;
					}
					if (!this.bool_6 && !this.bool_7)
					{
						try
						{
							if (this.int_8 >= 60)
							{
								Phoenix.GetGame().GetRoomManager().method_16(this);
								return;
							}
							ServerMessage Logging = this.method_67(false);
							if (Logging != null)
							{
								this.SendMessage(Logging, null);
							}
						}
						catch (Exception ex)
						{
                            Logging.LogThreadException(ex.ToString(), "Room [ID: " + this.Id + "] cycle task -- Cycle End");
							this.method_34();
						}
					}
					this.class27_0.UsersNow = num3;
				}
				catch (Exception ex)
				{
                    Logging.LogThreadException(ex.ToString(), "Room [ID: " + this.Id + "] cycle task");
				}
			}
		}
		private void method_34()
		{
			if (!this.bool_7 && Config.bool_18)
			{
				this.bool_7 = true;
				try
				{
					this.method_31(PhoenixEnvironment.GetExternalText("error_roomunload"));
				}
				catch
				{
				}
				Phoenix.GetGame().GetRoomManager().method_16(this);
			}
		}
		private void method_35()
		{
			if (this.bool_11)
			{
				if (this.int_16 >= this.int_15 || this.int_15 == 0)
				{
					Hashtable hashtable = this.hashtable_0.Clone() as Hashtable;
					List<uint> list = new List<uint>();
					List<uint> list2 = new List<uint>();
					foreach (UserItemData @class in hashtable.Values)
					{
						if (@class.Boolean_0)
						{
							ThreeDCoord gStruct1_ = @class.GStruct1_1;
							if (gStruct1_.x >= this.Class28_0.int_4 || gStruct1_.y >= this.Class28_0.int_5 || gStruct1_.x < 0 || gStruct1_.y < 0)
							{
								return;
							}
							List<UserItemData> list3 = this.method_45(@class.Int32_0, @class.Int32_1);
							Class33 class2 = this.method_43(@class.Int32_0, @class.Int32_1);
							if (list3.Count > 0 || class2 != null)
							{
								List<UserItemData> list4 = this.method_45(gStruct1_.x, gStruct1_.y);
								double num = this.Class28_0.double_1[gStruct1_.x, gStruct1_.y];
								int num2 = 0;
								int num3 = 0;
								bool flag = false;
								foreach (UserItemData current in list4)
								{
									if (current.Double_1 > num)
									{
										num = current.Double_1;
									}
									if (!current.Boolean_0)
									{
										num2++;
									}
									else
									{
										num3++;
									}
									if (!flag && current.GetBaseItem().InteractionType.ToLower() == "wf_trg_timer")
									{
										flag = true;
									}
								}
								bool flag2 = num2 > 0;
								if (this.method_43(gStruct1_.x, gStruct1_.y) != null)
								{
									flag2 = true;
								}
								bool flag3 = num3 > 0;
								foreach (UserItemData current in list3)
								{
									bool flag4 = current.GetBaseItem().InteractionType.ToLower() == "wf_trg_timer";
									if (!current.Boolean_0 && !list.Contains(current.uint_0) && this.method_36(gStruct1_.x, gStruct1_.y) && (!flag2 || !flag3) && @class.Double_0 < current.Double_0 && this.method_43(gStruct1_.x, gStruct1_.y) == null && (!flag4 || !flag))
									{
										double double_;
										if (flag3)
										{
											double_ = current.Double_0;
										}
										else
										{
											double_ = current.Double_0 - @class.Double_1 + this.Class28_0.double_1[gStruct1_.x, gStruct1_.y];
										}
										this.method_41(current, gStruct1_, @class.uint_0, double_);
										list.Add(current.uint_0);
									}
								}
								if (class2 != null && (!flag2 || !flag3) && this.method_37(gStruct1_.x, gStruct1_.y, false, true, false, true, true) && !list2.Contains(class2.uint_0) && !class2.bool_6)
								{
									if (this.double_2[gStruct1_.x, gStruct1_.y] > 0.0)
									{
										num = this.method_84(gStruct1_.x, gStruct1_.y, this.method_93(gStruct1_.x, gStruct1_.y));
									}
									if (class2.Boolean_4 && class2.class34_0.class33_0 != null)
									{
										this.method_42(class2, gStruct1_, @class.uint_0, num);
										list2.Add(class2.uint_0);
										this.method_42(class2.class34_0.class33_0, gStruct1_, @class.uint_0, num + 1.0);
										list2.Add(class2.class34_0.class33_0.uint_0);
									}
									else
									{
										if (class2.class34_1 == null)
										{
											this.method_42(class2, gStruct1_, @class.uint_0, num);
											list2.Add(class2.uint_0);
										}
									}
								}
							}
						}
					}
					hashtable.Clear();
					hashtable = null;
					list.Clear();
					list2.Clear();
					this.int_16 = 0;
				}
				else
				{
					this.int_16++;
				}
			}
		}
		public bool method_36(int int_17, int int_18)
		{
			bool result;
			if (!this.method_92(int_17, int_18))
			{
				result = false;
			}
			else
			{
                if (this.Class28_0.squareState[int_17, int_18] == SquareState.BLOCKED)
				{
					result = false;
				}
				else
				{
					List<UserItemData> list = this.method_93(int_17, int_18);
					if (list.Count > 1)
					{
						foreach (UserItemData current in list)
						{
							if (current.Boolean_0)
							{
								result = true;
								return result;
							}
						}
					}
					result = true;
				}
			}
			return result;
		}
		public bool method_37(int int_17, int int_18, bool bool_13, bool bool_14, bool bool_15, bool bool_16, bool bool_17)
		{
			bool result;
			if (!this.method_92(int_17, int_18))
			{
				result = false;
			}
			else
			{
                if (this.Class28_0.squareState[int_17, int_18] == SquareState.BLOCKED)
				{
					result = false;
				}
				else
				{
					if (bool_17 && this.double_2[int_17, int_18] > 0.0)
					{
						result = true;
					}
					else
					{
						if (bool_13 && this.method_97(int_17, int_18))
						{
							result = false;
						}
						else
						{
							if (bool_14)
							{
								List<UserItemData> list = this.method_93(int_17, int_18);
								if (list.Count > 0)
								{
									if (!bool_15 && !bool_16 && !bool_17)
									{
										result = false;
										return result;
									}
									if (bool_15)
									{
										foreach (UserItemData current in list)
										{
											if (!current.GetBaseItem().bool_0)
											{
												result = false;
												return result;
											}
										}
									}
									if (bool_16 && bool_17)
									{
										using (List<UserItemData>.Enumerator enumerator = list.GetEnumerator())
										{
											while (enumerator.MoveNext())
											{
												UserItemData current = enumerator.Current;
												if (!current.GetBaseItem().bool_1 && !current.GetBaseItem().bool_2)
												{
													result = false;
													return result;
												}
											}
											goto IL_1DD;
										}
									}
									if (bool_16)
									{
										using (List<UserItemData>.Enumerator enumerator = list.GetEnumerator())
										{
											while (enumerator.MoveNext())
											{
												UserItemData current = enumerator.Current;
												if (!current.GetBaseItem().bool_1)
												{
													result = false;
													return result;
												}
											}
											goto IL_1DD;
										}
									}
									if (bool_17)
									{
										foreach (UserItemData current in list)
										{
											if (!current.GetBaseItem().bool_2)
											{
												result = false;
												return result;
											}
										}
									}
								}
							}
							IL_1DD:
							result = true;
						}
					}
				}
			}
			return result;
		}
		internal void method_38(int int_17, int int_18)
		{
			this.byte_0[int_17, int_18] = 1;
		}
		internal void method_39(int int_17, int int_18)
		{
			this.byte_0[int_17, int_18] = 0;
		}
		private void method_40(UserItemData class63_0, int int_17, int int_18, uint uint_2, double double_3)
		{
			ServerMessage gClass = new ServerMessage();
			gClass.Init(230u);
			gClass.AppendInt32(class63_0.Int32_0);
			gClass.AppendInt32(class63_0.Int32_1);
			gClass.AppendInt32(int_17);
			gClass.AppendInt32(int_18);
			gClass.AppendInt32(1);
			gClass.AppendUInt(class63_0.uint_0);
			gClass.AppendStringWithBreak(class63_0.Double_0.ToString().Replace(',', '.'));
			gClass.AppendStringWithBreak(double_3.ToString().Replace(',', '.'));
			gClass.AppendUInt(uint_2);
			this.SendMessage(gClass, null);
			this.method_81(class63_0, int_17, int_18, double_3);
		}
		private void method_41(UserItemData class63_0, ThreeDCoord gstruct1_1, uint uint_2, double double_3)
		{
			this.method_40(class63_0, gstruct1_1.x, gstruct1_1.y, uint_2, double_3);
		}
		private void method_42(Class33 class33_1, ThreeDCoord gstruct1_1, uint uint_2, double double_3)
		{
			ServerMessage gClass = new ServerMessage();
			gClass.Init(230u);
			gClass.AppendInt32(class33_1.int_3);
			gClass.AppendInt32(class33_1.int_4);
			gClass.AppendInt32(gstruct1_1.x);
			gClass.AppendInt32(gstruct1_1.y);
			gClass.AppendInt32(0);
			gClass.AppendUInt(uint_2);
			gClass.AppendString("J");
			gClass.AppendInt32(class33_1.int_0);
			gClass.AppendStringWithBreak(class33_1.double_0.ToString().Replace(',', '.'));
			gClass.AppendStringWithBreak(double_3.ToString().Replace(',', '.'));
			this.SendMessage(gClass, null);
			this.byte_0[class33_1.int_3, class33_1.int_4] = 1;
			class33_1.int_3 = gstruct1_1.x;
			class33_1.int_4 = gstruct1_1.y;
			class33_1.double_0 = double_3;
			class33_1.int_12 = gstruct1_1.x;
			class33_1.int_13 = gstruct1_1.y;
			class33_1.double_1 = double_3;
			class33_1.int_9 = 2;
			this.byte_0[class33_1.int_3, class33_1.int_4] = 0;
			this.method_87(class33_1, false, true);
		}
		internal Class33 method_43(int int_17, int int_18)
		{
			Class33 result;
			if (this.class33_0 != null)
			{
				for (int i = 0; i < this.class33_0.Length; i++)
				{
					Class33 @class = this.class33_0[i];
					if (@class != null && (@class.int_3 == int_17 && @class.int_4 == int_18))
					{
						result = @class;
						return result;
					}
				}
			}
			result = null;
			return result;
		}
		internal Class33 method_44(int int_17, int int_18)
		{
			Class33 result;
			if (this.class33_0 != null)
			{
				for (int i = 0; i < this.class33_0.Length; i++)
				{
					Class33 @class = this.class33_0[i];
					if (@class != null)
					{
						if (@class.int_3 == int_17 && @class.int_4 == int_18)
						{
							result = @class;
							return result;
						}
						if (@class.int_12 == int_17 && @class.int_13 == int_18)
						{
							result = @class;
							return result;
						}
					}
				}
			}
			result = null;
			return result;
		}
		private List<UserItemData> method_45(int int_17, int int_18)
		{
			List<UserItemData> list = new List<UserItemData>();
			foreach (UserItemData @class in this.Hashtable_0.Values)
			{
				if (@class.Int32_0 == int_17 && @class.Int32_1 == int_18)
				{
					list.Add(@class);
				}
			}
			return list;
		}
		public void method_46(GameClient class16_0, bool bool_13)
		{
			Class33 @class = new Class33(class16_0.GetHabbo().Id, this.Id, this.int_7++, class16_0.GetHabbo().bool_1);
			if (@class != null && @class.method_16() != null && @class.method_16().GetHabbo() != null)
			{
				if (bool_13 || !@class.bool_12)
				{
					@class.bool_11 = true;
				}
				else
				{
					@class.method_7(this.Class28_0.int_0, this.Class28_0.int_1, this.Class28_0.double_0);
					@class.method_9(this.Class28_0.int_2);
					if (this.method_27(class16_0, true))
					{
						@class.method_11("flatctrl", "useradmin");
					}
					else
					{
						if (this.method_26(class16_0))
						{
							@class.method_11("flatctrl", "");
						}
					}
					if (!@class.Boolean_4 && @class.method_16().GetHabbo().bool_7)
					{
						UserItemData class2 = this.method_28(@class.method_16().GetHabbo().uint_5);
						if (class2 != null)
						{
							@class.method_7(class2.Int32_0, class2.Int32_1, class2.Double_0);
							@class.method_9(class2.int_3);
							class2.uint_4 = class16_0.GetHabbo().Id;
							class2.string_0 = "2";
							class2.method_5(false, true);
						}
					}
					@class.method_16().GetHabbo().bool_7 = false;
					@class.method_16().GetHabbo().uint_5 = 0u;
					ServerMessage gClass = new ServerMessage(28u);
					gClass.AppendInt32(1);
					@class.method_14(gClass);
					this.SendMessage(gClass, null);
				}
				int num = this.method_5();
				@class.int_20 = num;
				this.class33_0[num] = @class;
				if (!bool_13)
				{
					this.bool_10 = true;
				}
				class16_0.GetHabbo().CurrentRoomId = this.uint_0;
				class16_0.GetHabbo().method_21().method_5(false);
				class16_0.GetHabbo().RoomVisits++;
				int num2 = class16_0.GetHabbo().RoomVisits;
				if (num2 <= 500)
				{
					if (num2 <= 50)
					{
						if (num2 != 5)
						{
							if (num2 == 50)
							{
								Phoenix.GetGame().GetAchievementManager().method_3(class16_0, 13u, 2);
							}
						}
						else
						{
							Phoenix.GetGame().GetAchievementManager().method_3(class16_0, 13u, 1);
						}
					}
					else
					{
						if (num2 != 100)
						{
							if (num2 != 200)
							{
								if (num2 == 500)
								{
									Phoenix.GetGame().GetAchievementManager().method_3(class16_0, 13u, 5);
								}
							}
							else
							{
								Phoenix.GetGame().GetAchievementManager().method_3(class16_0, 13u, 4);
							}
						}
						else
						{
							Phoenix.GetGame().GetAchievementManager().method_3(class16_0, 13u, 3);
						}
					}
				}
				else
				{
					if (num2 <= 1500)
					{
						if (num2 != 750)
						{
							if (num2 == 1500)
							{
								Phoenix.GetGame().GetAchievementManager().method_3(class16_0, 13u, 7);
							}
						}
						else
						{
							Phoenix.GetGame().GetAchievementManager().method_3(class16_0, 13u, 6);
						}
					}
					else
					{
						if (num2 != 2500)
						{
							if (num2 != 4000)
							{
								if (num2 == 5000)
								{
									Phoenix.GetGame().GetAchievementManager().method_3(class16_0, 13u, 10);
								}
							}
							else
							{
								Phoenix.GetGame().GetAchievementManager().method_3(class16_0, 13u, 9);
							}
						}
						else
						{
							Phoenix.GetGame().GetAchievementManager().method_3(class16_0, 13u, 8);
						}
					}
				}
				class16_0.GetHabbo().method_10(this.uint_0);
				if (class16_0.GetHabbo().int_0 > 0)
				{
					GroupsManager class3 = Groups.smethod_2(class16_0.GetHabbo().int_0);
					if (class3 != null && !this.list_17.Contains(class3))
					{
						this.list_17.Add(class3);
						ServerMessage gClass2 = new ServerMessage(309u);
						gClass2.AppendInt32(this.list_17.Count);
						foreach (GroupsManager current in this.list_17)
						{
							gClass2.AppendInt32(current.int_0);
							gClass2.AppendStringWithBreak(current.string_2);
						}
						this.SendMessage(gClass2, null);
					}
				}
				if (!bool_13)
				{
					this.method_51();
					for (int i = 0; i < this.class33_0.Length; i++)
					{
						Class33 class4 = this.class33_0[i];
						if (class4 != null && class4.Boolean_4)
						{
							class4.class99_0.OnUserEnterRoom(@class);
						}
					}
				}
			}
		}
		public void method_47(GameClient class16_0, bool bool_13, bool bool_14)
		{
			int num = 1;
			if (!bool_14 || !class16_0.GetHabbo().bool_0)
			{
				if (this.bool_12)
				{
					if (bool_13 && class16_0 != null)
					{
						if (bool_14)
						{
							ServerMessage gClass = new ServerMessage(33u);
							gClass.AppendInt32(4008);
							class16_0.method_14(gClass);
						}
						ServerMessage gclass5_ = new ServerMessage(18u);
						class16_0.method_14(gclass5_);
					}
				}
				else
				{
					try
					{
						if (class16_0 != null && class16_0.GetHabbo() != null)
						{
							num = 2;
							Class33 @class = this.method_53(class16_0.GetHabbo().Id);
							if (@class != null)
							{
								this.class33_0[@class.int_20] = null;
								@class.int_20 = -1;
								this.byte_0[@class.int_3, @class.int_4] = @class.byte_0;
							}
							num = 3;
							if (bool_13)
							{
								if (bool_14)
								{
									ServerMessage gClass = new ServerMessage(33u);
									gClass.AppendInt32(4008);
									class16_0.method_14(gClass);
								}
								ServerMessage gclass5_ = new ServerMessage(18u);
								class16_0.method_14(gclass5_);
							}
							num = 4;
							if (@class != null && !@class.bool_11)
							{
								if (@class.byte_1 > 0 && @class.method_16() != null)
								{
									@class.method_16().GetHabbo().method_24().int_0 = -1;
								}
								this.byte_0[@class.int_3, @class.int_4] = @class.byte_0;
								if (!this.Boolean_3)
								{
									ServerMessage gClass2 = new ServerMessage(700u);
									gClass2.AppendBoolean(false);
									class16_0.method_14(gClass2);
								}
								ServerMessage gClass3 = new ServerMessage(29u);
								gClass3.AppendRawInt32(@class.int_0);
								this.SendMessage(gClass3, null);
								if (this.method_74(class16_0.GetHabbo().Id))
								{
									this.method_78(class16_0.GetHabbo().Id);
								}
								num = 5;
								if (class16_0.GetHabbo().Username.ToLower() == this.Owner.ToLower() && this.Boolean_0)
								{
									this.Event = null;
									ServerMessage Logging = new ServerMessage(370u);
									Logging.AppendStringWithBreak("-1");
									this.SendMessage(Logging, null);
								}
								num = 6;
								if (@class.class34_1 != null)
								{
									@class.class34_1.class33_0 = null;
									@class.class34_1 = null;
									class16_0.GetHabbo().method_24().int_0 = -1;
								}
								class16_0.GetHabbo().method_11();
								this.bool_10 = true;
								this.method_51();
								List<Class33> list = new List<Class33>();
								for (int i = 0; i < this.class33_0.Length; i++)
								{
									Class33 class2 = this.class33_0[i];
									if (class2 != null && class2.Boolean_4)
									{
										list.Add(class2);
									}
								}
								num = 7;
								foreach (Class33 current in list)
								{
									current.class99_0.OnUserLeaveRoom(class16_0);
								}
							}
						}
					}
					catch (Exception ex)
					{
                        Logging.LogCriticalException(string.Concat(new object[]
						{
							"Error during removing user from room [Part: ",
							num,
							"]: ",
							ex.ToString()
						}));
					}
				}
			}
		}
		public Class33 method_48(uint uint_2)
		{
			Class33 result;
			for (int i = 0; i < this.class33_0.Length; i++)
			{
				Class33 @class = this.class33_0[i];
				if (@class != null && @class.Boolean_4 && @class.Boolean_0 && @class.class15_0 != null && @class.class15_0.PetId == uint_2)
				{
					result = @class;
					return result;
				}
			}
			result = null;
			return result;
		}
		public bool method_49(uint uint_2)
		{
			return this.method_48(uint_2) != null;
		}
		public void method_50()
		{
			this.UsersNow = this.Int32_0;
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				@class.ExecuteQuery(string.Concat(new object[]
				{
					"UPDATE rooms SET users_now = '",
					this.Int32_0,
					"' WHERE id = '",
					this.uint_0,
					"' LIMIT 1"
				}));
			}
		}
		public void method_51()
		{
			this.UsersNow = this.Int32_0;
		}
		public Class33 method_52(int int_17)
		{
			Class33 result;
			for (int i = 0; i < this.class33_0.Length; i++)
			{
				Class33 @class = this.class33_0[i];
				if (@class != null && @class.int_0 == int_17)
				{
					result = @class;
					return result;
				}
			}
			result = null;
			return result;
		}
		public Class33 method_53(uint uint_2)
		{
			Class33 result;
			for (int i = 0; i < this.class33_0.Length; i++)
			{
				Class33 @class = this.class33_0[i];
				if (@class != null && !@class.Boolean_4 && @class.uint_0 == uint_2)
				{
					result = @class;
					return result;
				}
			}
			result = null;
			return result;
		}
		public void method_54()
		{
			for (int i = 0; i < this.class33_0.Length; i++)
			{
				Class33 @class = this.class33_0[i];
				if (@class != null && (!@class.Boolean_4 && @class.class34_1 == null))
				{
					@class.int_15 = 1;
					ServerMessage gClass = new ServerMessage(480u);
					gClass.AppendInt32(@class.int_0);
					gClass.AppendInt32(1);
					this.SendMessage(gClass, null);
				}
			}
		}
		public void method_55()
		{
			for (int i = 0; i < this.class33_0.Length; i++)
			{
				Class33 @class = this.class33_0[i];
				if (@class != null && (!@class.Boolean_4 && @class.class34_1 == null) && (!@class.Statusses.ContainsKey("sit") && !@class.Statusses.ContainsKey("lay") && @class.int_8 != 1 && @class.int_8 != 3 && @class.int_8 != 5 && @class.int_8 != 7))
				{
					@class.method_11("sit", ((@class.double_0 + 1.0) / 2.0 - @class.double_0 * 0.5).ToString());
					@class.bool_7 = true;
				}
			}
		}
		public Class33 method_56(string string_10)
		{
			Class33 result;
			for (int i = 0; i < this.class33_0.Length; i++)
			{
				Class33 @class = this.class33_0[i];
				if (@class != null && !@class.Boolean_4 && @class.method_16().GetHabbo() != null && @class.method_16().GetHabbo().Username.ToLower() == string_10.ToLower())
				{
					result = @class;
					return result;
				}
			}
			result = null;
			return result;
		}
		public Class33 method_57(string string_10)
		{
			Class33 result;
			for (int i = 0; i < this.class33_0.Length; i++)
			{
				Class33 @class = this.class33_0[i];
				if (@class != null && @class.Boolean_4 && @class.class34_0.string_1.ToLower() == string_10.ToLower())
				{
					result = @class;
					return result;
				}
			}
			result = null;
			return result;
		}
		internal void method_58(ServerMessage gclass5_0, List<uint> list_18, uint uint_2)
		{
			List<uint> list = new List<uint>();
			if (list_18 != null)
			{
				if (this.class33_0 == null)
				{
					return;
				}
				for (int i = 0; i < this.class33_0.Length; i++)
				{
					Class33 @class = this.class33_0[i];
					if (@class != null && !@class.Boolean_4)
					{
						GameClient class2 = @class.method_16();
						if (class2 != null && class2.GetHabbo().Id != uint_2 && class2.GetHabbo().list_2.Contains(uint_2))
						{
							list.Add(class2.GetHabbo().Id);
						}
					}
				}
			}
			this.SendMessage(gclass5_0, list);
		}
		internal void SendMessage(ServerMessage gclass5_0, List<uint> list_18)
		{
			try
			{
				if (this.class33_0 != null)
				{
					byte[] array = gclass5_0.GetBytes();
					for (int i = 0; i < this.class33_0.Length; i++)
					{
						Class33 @class = this.class33_0[i];
						if (@class != null && !@class.Boolean_4)
						{
							GameClient class2 = @class.method_16();
							if (class2 != null && (list_18 == null || !list_18.Contains(class2.GetHabbo().Id)))
							{
								try
								{
									class2.GetConnection().SendData(array);
								}
								catch
								{
								}
							}
						}
					}
				}
			}
			catch (InvalidOperationException)
			{
			}
		}
		internal void method_60(ServerMessage gclass5_0, int int_17)
		{
			try
			{
				byte[] array = gclass5_0.GetBytes();
				for (int i = 0; i < this.class33_0.Length; i++)
				{
					Class33 @class = this.class33_0[i];
					if (@class != null && !@class.Boolean_4)
					{
						GameClient class2 = @class.method_16();
						if (class2 != null && class2.GetHabbo() != null && (ulong)class2.GetHabbo().uint_1 >= (ulong)((long)int_17))
						{
							try
							{
								class2.GetConnection().SendData(array);
							}
							catch
							{
							}
						}
					}
				}
			}
			catch (InvalidOperationException)
			{
			}
		}
		public void method_61(ServerMessage gclass5_0)
		{
			try
			{
				byte[] array = gclass5_0.GetBytes();
				for (int i = 0; i < this.class33_0.Length; i++)
				{
					Class33 @class = this.class33_0[i];
					if (@class != null && !@class.Boolean_4)
					{
						GameClient class2 = @class.method_16();
						if (class2 != null && this.method_26(class2))
						{
							try
							{
								class2.GetConnection().SendData(array);
							}
							catch
							{
							}
						}
					}
				}
			}
			catch (InvalidOperationException)
			{
			}
		}
		public void method_62()
		{
			this.SendMessage(new ServerMessage(18u), null);
			this.method_63();
		}
		public void method_63()
		{
			this.method_66(true);
			GC.SuppressFinalize(this);
		}
		internal void method_64()
		{
			StringBuilder stringBuilder = new StringBuilder();
			Dictionary<uint, bool> dictionary = new Dictionary<uint, bool>();
			try
			{
				try
				{
					using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
					{
						if (this.list_14.Count > 0)
						{
							lock (this.list_14)
							{
								foreach (UserItemData class2 in this.list_14)
								{
									try
									{
										if (!dictionary.ContainsKey(class2.uint_0))
										{
											if (class2.string_2 != "" || class2.string_3 != "" || class2.string_4 != "" || class2.string_5 != "" || class2.string_6 != "")
											{
												@class.AddParamWithValue(class2.uint_0 + "Extra1", class2.string_2);
												@class.AddParamWithValue(class2.uint_0 + "Extra2", class2.string_3);
												@class.AddParamWithValue(class2.uint_0 + "Extra3", class2.string_4);
												@class.AddParamWithValue(class2.uint_0 + "Extra4", class2.string_5);
												@class.AddParamWithValue(class2.uint_0 + "Extra5", class2.string_6);
												stringBuilder.Append(string.Concat(new object[]
												{
													"DELETE FROM wired_items WHERE item_id = '",
													class2.uint_0,
													"' LIMIT 1; INSERT INTO wired_items (item_id,extra1,extra2,extra3,extra4,extra5) VALUES ('",
													class2.uint_0,
													"',@",
													class2.uint_0,
													"Extra1,@",
													class2.uint_0,
													"Extra2,@",
													class2.uint_0,
													"Extra3,@",
													class2.uint_0,
													"Extra4,@",
													class2.uint_0,
													"Extra5); "
												}));
											}
											dictionary.Add(class2.uint_0, true);
										}
									}
									catch
									{
									}
								}
							}
						}
						if (this.list_15.Count > 0)
						{
							lock (this.list_15)
							{
								foreach (UserItemData class2 in this.list_15)
								{
									try
									{
										if (!dictionary.ContainsKey(class2.uint_0))
										{
											if (class2.string_2 != "" || class2.string_3 != "" || class2.string_4 != "" || class2.string_5 != "" || class2.string_6 != "")
											{
												@class.AddParamWithValue(class2.uint_0 + "Extra1", class2.string_2);
												@class.AddParamWithValue(class2.uint_0 + "Extra2", class2.string_3);
												@class.AddParamWithValue(class2.uint_0 + "Extra3", class2.string_4);
												@class.AddParamWithValue(class2.uint_0 + "Extra4", class2.string_5);
												@class.AddParamWithValue(class2.uint_0 + "Extra5", class2.string_6);
												stringBuilder.Append(string.Concat(new object[]
												{
													"DELETE FROM wired_items WHERE item_id = '",
													class2.uint_0,
													"' LIMIT 1; INSERT INTO wired_items (item_id,extra1,extra2,extra3,extra4,extra5) VALUES ('",
													class2.uint_0,
													"',@",
													class2.uint_0,
													"Extra1,@",
													class2.uint_0,
													"Extra2,@",
													class2.uint_0,
													"Extra3,@",
													class2.uint_0,
													"Extra4,@",
													class2.uint_0,
													"Extra5); "
												}));
											}
											dictionary.Add(class2.uint_0, true);
										}
									}
									catch
									{
									}
								}
							}
						}
						if (this.list_16.Count > 0)
						{
							lock (this.list_16)
							{
								foreach (UserItemData class2 in this.list_16)
								{
									try
									{
										if (!dictionary.ContainsKey(class2.uint_0))
										{
											if (class2.string_2 != "" || class2.string_3 != "" || class2.string_4 != "" || class2.string_5 != "" || class2.string_6 != "")
											{
												@class.AddParamWithValue(class2.uint_0 + "Extra1", class2.string_2);
												@class.AddParamWithValue(class2.uint_0 + "Extra2", class2.string_3);
												@class.AddParamWithValue(class2.uint_0 + "Extra3", class2.string_4);
												@class.AddParamWithValue(class2.uint_0 + "Extra4", class2.string_5);
												@class.AddParamWithValue(class2.uint_0 + "Extra5", class2.string_6);
												stringBuilder.Append(string.Concat(new object[]
												{
													"DELETE FROM wired_items WHERE item_id = '",
													class2.uint_0,
													"' LIMIT 1; INSERT INTO wired_items (item_id,extra1,extra2,extra3,extra4,extra5) VALUES ('",
													class2.uint_0,
													"',@",
													class2.uint_0,
													"Extra1,@",
													class2.uint_0,
													"Extra2,@",
													class2.uint_0,
													"Extra3,@",
													class2.uint_0,
													"Extra4,@",
													class2.uint_0,
													"Extra5); "
												}));
											}
											dictionary.Add(class2.uint_0, true);
										}
									}
									catch
									{
									}
								}
							}
						}
						if (stringBuilder.Length > 0)
						{
							@class.ExecuteQuery(stringBuilder.ToString());
						}
						dictionary.Clear();
					}
				}
				catch (Exception ex)
				{
                    Logging.LogCriticalException(string.Concat(new object[]
					{
						"Error during saving wired items for room ",
						this.Id,
						". Stack: ",
						ex.ToString(),
						"\rQuery: ",
						stringBuilder.ToString()
					}));
				}
				if (this.hashtable_3.Count > 0 || this.hashtable_1.Count > 0 || this.hashtable_2.Count > 0 || this.Boolean_4)
				{
					using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
					{
						stringBuilder.Clear();
						lock (this.hashtable_1)
						{
							foreach (UserItemData class2 in this.hashtable_1.Values)
							{
								stringBuilder.Append(string.Concat(new object[]
								{
									"UPDATE items SET room_id = '0' WHERE id = '",
									class2.uint_0,
									"' AND room_id = '",
									this.Id,
									"' LIMIT 1; "
								}));
							}
						}
						this.hashtable_1.Clear();
						lock (this.hashtable_3)
						{
							if (this.hashtable_3.Count > 0)
							{
								int num = 0;
								int num2 = 0;
								foreach (UserItemData class2 in this.hashtable_3.Values)
								{
									if (class2.Boolean_2)
									{
										num2++;
									}
									else
									{
										num++;
									}
								}
								if (num2 > 0)
								{
									foreach (UserItemData class2 in this.hashtable_3.Values)
									{
										if (class2.Boolean_2)
										{
											@class.AddParamWithValue("extra_data" + class2.uint_0, class2.string_0);
											stringBuilder.Append(string.Concat(new object[]
											{
												"UPDATE items SET room_id = '",
												this.Id,
												"', base_item = '",
												class2.uint_2,
												"', extra_data = @extra_data",
												class2.uint_0,
												", x = '",
												class2.Int32_0,
												"', y = '",
												class2.Int32_1,
												"', z = '",
												class2.Double_0,
												"', rot = '",
												class2.int_3,
												"', wall_pos = '' WHERE id = '",
												class2.uint_0,
												"' LIMIT 1; "
											}));
										}
									}
								}
								if (num > 0)
								{
									foreach (UserItemData class2 in this.hashtable_3.Values)
									{
										if (class2.Boolean_1)
										{
											@class.AddParamWithValue("extra_data" + class2.uint_0, class2.string_0);
											@class.AddParamWithValue("pos" + class2.uint_0, class2.string_7);
											stringBuilder.Append(string.Concat(new object[]
											{
												"UPDATE items SET room_id = '",
												this.Id,
												"', base_item = '",
												class2.uint_2,
												"', extra_data = @extra_data",
												class2.uint_0,
												", x = '0', y = '0', z = '0', rot = '0', wall_pos = @pos",
												class2.uint_0,
												" WHERE id = '",
												class2.uint_0,
												"' LIMIT 1; "
											}));
										}
									}
								}
							}
						}
						this.hashtable_3.Clear();
						lock (this.hashtable_2)
						{
							foreach (UserItemData class2 in this.hashtable_2.Values)
							{
								@class.AddParamWithValue("mextra_data" + class2.uint_0, class2.string_0);
								stringBuilder.Append(string.Concat(new object[]
								{
									"UPDATE items SET x = '",
									class2.Int32_0,
									"', y = '",
									class2.Int32_1,
									"', z = '",
									class2.Double_0,
									"', rot = '",
									class2.int_3,
									"', wall_pos = '",
									class2.string_7,
									"', extra_data = @mextra_data",
									class2.uint_0,
									" WHERE id = '",
									class2.uint_0,
									"' LIMIT 1; "
								}));
							}
						}
						this.hashtable_2.Clear();
						lock (this.method_2())
						{
							foreach (Pet current in this.method_2())
							{
								if (current.DBState == DatabaseUpdateState.NeedsInsert)
								{
									@class.AddParamWithValue("petname" + current.PetId, current.Name);
									@class.AddParamWithValue("petcolor" + current.PetId, current.Color);
									@class.AddParamWithValue("petrace" + current.PetId, current.Race);
									stringBuilder.Append(string.Concat(new object[]
									{
										"INSERT INTO `user_pets` VALUES ('",
										current.PetId,
										"', '",
										current.OwnerId,
										"', '",
										current.RoomId,
										"', @petname",
										current.PetId,
										", @petrace",
										current.PetId,
										", @petcolor",
										current.PetId,
										", '",
										current.Type,
										"', '",
										current.Expirience,
										"', '",
										current.Energy,
										"', '",
										current.Nutrition,
										"', '",
										current.Respect,
										"', '",
										current.CreationStamp,
										"', '",
										current.X,
										"', '",
										current.Y,
										"', '",
										current.Z,
										"'); "
									}));
								}
								else
								{
									if (current.DBState == DatabaseUpdateState.NeedsUpdate)
									{
										stringBuilder.Append(string.Concat(new object[]
										{
											"UPDATE user_pets SET room_id = '",
											current.RoomId,
											"', expirience = '",
											current.Expirience,
											"', energy = '",
											current.Energy,
											"', nutrition = '",
											current.Nutrition,
											"', respect = '",
											current.Respect,
											"', x = '",
											current.X,
											"', y = '",
											current.Y,
											"', z = '",
											current.Z,
											"' WHERE id = '",
											current.PetId,
											"' LIMIT 1; "
										}));
									}
								}
								current.DBState = DatabaseUpdateState.Updated;
							}
						}
						if (stringBuilder.Length > 0)
						{
							@class.ExecuteQuery(stringBuilder.ToString());
						}
					}
				}
			}
			catch (Exception ex)
			{
                Logging.LogCriticalException(string.Concat(new object[]
				{
					"Error during saving furniture for room ",
					this.Id,
					". Stack: ",
					ex.ToString(),
					"\r Query: ",
					stringBuilder.ToString()
				}));
			}
		}
		internal void method_65(DatabaseClient class6_0)
		{
			try
			{
				Dictionary<uint, bool> dictionary = new Dictionary<uint, bool>();
				StringBuilder stringBuilder = new StringBuilder();
				if (this.list_14.Count > 0)
				{
					foreach (UserItemData @class in this.list_14)
					{
						if (@class.string_2 != "" || @class.string_3 != "" || @class.string_4 != "" || @class.string_5 != "" || @class.string_6 != "")
						{
							try
							{
								if (!dictionary.ContainsKey(@class.uint_0))
								{
									if (@class.string_2 != "" || @class.string_3 != "" || @class.string_4 != "" || @class.string_5 != "" || @class.string_6 != "")
									{
										class6_0.AddParamWithValue(@class.uint_0 + "Extra1", @class.string_2);
										class6_0.AddParamWithValue(@class.uint_0 + "Extra2", @class.string_3);
										class6_0.AddParamWithValue(@class.uint_0 + "Extra3", @class.string_4);
										class6_0.AddParamWithValue(@class.uint_0 + "Extra4", @class.string_5);
										class6_0.AddParamWithValue(@class.uint_0 + "Extra5", @class.string_6);
										stringBuilder.Append(string.Concat(new object[]
										{
											"DELETE FROM wired_items WHERE item_id = '",
											@class.uint_0,
											"' LIMIT 1; INSERT INTO wired_items (item_id,extra1,extra2,extra3,extra4,extra5) VALUES ('",
											@class.uint_0,
											"',@",
											@class.uint_0,
											"Extra1,@",
											@class.uint_0,
											"Extra2,@",
											@class.uint_0,
											"Extra3,@",
											@class.uint_0,
											"Extra4,@",
											@class.uint_0,
											"Extra5); "
										}));
									}
									dictionary.Add(@class.uint_0, true);
								}
							}
							catch
							{
							}
						}
					}
				}
				if (this.list_15.Count > 0)
				{
					foreach (UserItemData @class in this.list_15)
					{
						if (@class.string_2 != "" || @class.string_3 != "" || @class.string_4 != "" || @class.string_5 != "" || @class.string_6 != "")
						{
							try
							{
								if (!dictionary.ContainsKey(@class.uint_0))
								{
									if (@class.string_2 != "" || @class.string_3 != "" || @class.string_4 != "" || @class.string_5 != "" || @class.string_6 != "")
									{
										class6_0.AddParamWithValue(@class.uint_0 + "Extra1", @class.string_2);
										class6_0.AddParamWithValue(@class.uint_0 + "Extra2", @class.string_3);
										class6_0.AddParamWithValue(@class.uint_0 + "Extra3", @class.string_4);
										class6_0.AddParamWithValue(@class.uint_0 + "Extra4", @class.string_5);
										class6_0.AddParamWithValue(@class.uint_0 + "Extra5", @class.string_6);
										stringBuilder.Append(string.Concat(new object[]
										{
											"DELETE FROM wired_items WHERE item_id = '",
											@class.uint_0,
											"' LIMIT 1; INSERT INTO wired_items (item_id,extra1,extra2,extra3,extra4,extra5) VALUES ('",
											@class.uint_0,
											"',@",
											@class.uint_0,
											"Extra1,@",
											@class.uint_0,
											"Extra2,@",
											@class.uint_0,
											"Extra3,@",
											@class.uint_0,
											"Extra4,@",
											@class.uint_0,
											"Extra5); "
										}));
									}
									dictionary.Add(@class.uint_0, true);
								}
							}
							catch
							{
							}
						}
					}
				}
				if (this.list_16.Count > 0)
				{
					foreach (UserItemData @class in this.list_16)
					{
						if (@class.string_2 != "" || @class.string_3 != "" || @class.string_4 != "" || @class.string_5 != "" || @class.string_6 != "")
						{
							try
							{
								if (!dictionary.ContainsKey(@class.uint_0))
								{
									if (@class.string_2 != "" || @class.string_3 != "" || @class.string_4 != "" || @class.string_5 != "" || @class.string_6 != "")
									{
										class6_0.AddParamWithValue(@class.uint_0 + "Extra1", @class.string_2);
										class6_0.AddParamWithValue(@class.uint_0 + "Extra2", @class.string_3);
										class6_0.AddParamWithValue(@class.uint_0 + "Extra3", @class.string_4);
										class6_0.AddParamWithValue(@class.uint_0 + "Extra4", @class.string_5);
										class6_0.AddParamWithValue(@class.uint_0 + "Extra5", @class.string_6);
										stringBuilder.Append(string.Concat(new object[]
										{
											"DELETE FROM wired_items WHERE item_id = '",
											@class.uint_0,
											"' LIMIT 1; INSERT INTO wired_items (item_id,extra1,extra2,extra3,extra4,extra5) VALUES ('",
											@class.uint_0,
											"',@",
											@class.uint_0,
											"Extra1,@",
											@class.uint_0,
											"Extra2,@",
											@class.uint_0,
											"Extra3,@",
											@class.uint_0,
											"Extra4,@",
											@class.uint_0,
											"Extra5); "
										}));
									}
									dictionary.Add(@class.uint_0, true);
								}
							}
							catch
							{
							}
						}
					}
				}
				dictionary.Clear();
				if (this.hashtable_3.Count > 0 || this.hashtable_1.Count > 0 || this.hashtable_2.Count > 0 || this.Boolean_4)
				{
					foreach (UserItemData @class in this.hashtable_1.Values)
					{
						stringBuilder.Append(string.Concat(new object[]
						{
							"UPDATE items SET room_id = 0 WHERE id = '",
							@class.uint_0,
							"' AND room_id = '",
							this.Id,
							"' LIMIT 1; "
						}));
					}
					this.hashtable_1.Clear();
					IEnumerator enumerator2;
					if (this.hashtable_3.Count > 0)
					{
						enumerator2 = this.hashtable_3.Values.GetEnumerator();
						try
						{
							while (enumerator2.MoveNext())
							{
								UserItemData @class = (UserItemData)enumerator2.Current;
								stringBuilder.Append("UPDATE items SET room_id = 0 WHERE id = '" + @class.uint_0 + "' LIMIT 1; ");
							}
						}
						finally
						{
							IDisposable disposable = enumerator2 as IDisposable;
							if (disposable != null)
							{
								disposable.Dispose();
							}
						}
						int num = 0;
						int num2 = 0;
						enumerator2 = this.hashtable_3.Values.GetEnumerator();
						try
						{
							while (enumerator2.MoveNext())
							{
								UserItemData @class = (UserItemData)enumerator2.Current;
								if (@class.Boolean_2)
								{
									num2++;
								}
								else
								{
									num++;
								}
							}
						}
						finally
						{
							IDisposable disposable = enumerator2 as IDisposable;
							if (disposable != null)
							{
								disposable.Dispose();
							}
						}
						if (num2 > 0)
						{
							enumerator2 = this.hashtable_3.Values.GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									UserItemData @class = (UserItemData)enumerator2.Current;
									if (@class.Boolean_2)
									{
										class6_0.AddParamWithValue("extra_data" + @class.uint_0, @class.string_0);
										stringBuilder.Append(string.Concat(new object[]
										{
											"UPDATE items SET room_id = '",
											this.Id,
											"', base_item = '",
											@class.uint_2,
											"', extra_data = @extra_data",
											@class.uint_0,
											", x = '",
											@class.Int32_0,
											"', y = '",
											@class.Int32_1,
											"', z = '",
											@class.Double_0,
											"', rot = '",
											@class.int_3,
											"', wall_pos = '' WHERE id = '",
											@class.uint_0,
											"' LIMIT 1; "
										}));
									}
								}
							}
							finally
							{
								IDisposable disposable = enumerator2 as IDisposable;
								if (disposable != null)
								{
									disposable.Dispose();
								}
							}
						}
						if (num > 0)
						{
							enumerator2 = this.hashtable_3.Values.GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									UserItemData @class = (UserItemData)enumerator2.Current;
									if (@class.Boolean_1)
									{
										class6_0.AddParamWithValue("extra_data" + @class.uint_0, @class.string_0);
										class6_0.AddParamWithValue("pos" + @class.uint_0, @class.string_7);
										stringBuilder.Append(string.Concat(new object[]
										{
											"UPDATE items SET room_id = '",
											this.Id,
											"', base_item = '",
											@class.uint_2,
											"', extra_data = @extra_data",
											@class.uint_0,
											", x = '0', y = '0', z = '0', rot = '0', wall_pos = @pos",
											@class.uint_0,
											" WHERE id = '",
											@class.uint_0,
											"' LIMIT 1; "
										}));
									}
								}
							}
							finally
							{
								IDisposable disposable = enumerator2 as IDisposable;
								if (disposable != null)
								{
									disposable.Dispose();
								}
							}
						}
						this.hashtable_3.Clear();
					}
					enumerator2 = this.hashtable_2.Values.GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							UserItemData @class = (UserItemData)enumerator2.Current;
							stringBuilder.Append(string.Concat(new object[]
							{
								"UPDATE items SET x = '",
								@class.Int32_0,
								"', y = '",
								@class.Int32_1,
								"', z = '",
								@class.Double_0,
								"', rot = '",
								@class.int_3,
								"', wall_pos = '' WHERE id = '",
								@class.uint_0,
								"' LIMIT 1; "
							}));
						}
					}
					finally
					{
						IDisposable disposable = enumerator2 as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
					this.hashtable_2.Clear();
					foreach (Pet current in this.method_2())
					{
						if (current.DBState == DatabaseUpdateState.NeedsInsert)
						{
							class6_0.AddParamWithValue("petname" + current.PetId, current.Name);
							class6_0.AddParamWithValue("petcolor" + current.PetId, current.Color);
							class6_0.AddParamWithValue("petrace" + current.PetId, current.Race);
							stringBuilder.Append(string.Concat(new object[]
							{
								"INSERT INTO `user_pets` VALUES ('",
								current.PetId,
								"', '",
								current.OwnerId,
								"', '",
								current.RoomId,
								"', @petname",
								current.PetId,
								", @petrace",
								current.PetId,
								", @petcolor",
								current.PetId,
								", '",
								current.Type,
								"', '",
								current.Expirience,
								"', '",
								current.Energy,
								"', '",
								current.Nutrition,
								"', '",
								current.Respect,
								"', '",
								current.CreationStamp,
								"', '",
								current.X,
								"', '",
								current.Y,
								"', '",
								current.Z,
								"');"
							}));
						}
						else
						{
							if (current.DBState == DatabaseUpdateState.NeedsUpdate)
							{
								stringBuilder.Append(string.Concat(new object[]
								{
									"UPDATE user_pets SET room_id = '",
									current.RoomId,
									"', expirience = '",
									current.Expirience,
									"', energy = '",
									current.Energy,
									"', nutrition = '",
									current.Nutrition,
									"', respect = '",
									current.Respect,
									"', x = '",
									current.X,
									"', y = '",
									current.Y,
									"', z = '",
									current.Z,
									"' WHERE id = '",
									current.PetId,
									"' LIMIT 1; "
								}));
							}
						}
						current.DBState = DatabaseUpdateState.Updated;
					}
				}
				if (stringBuilder.Length > 0)
				{
					class6_0.ExecuteQuery(stringBuilder.ToString());
				}
			}
			catch (Exception ex)
			{
                Logging.LogCriticalException(string.Concat(new object[]
				{
					"Error during saving furniture for room ",
					this.Id,
					". Stack: ",
					ex.ToString()
				}));
			}
		}
		private void method_66(bool bool_13)
		{
			if (!this.bool_12)
			{
				this.bool_12 = true;
				if (bool_13)
				{
					this.bool_11 = false;
					if (this.timer_0 != null)
					{
						this.bool_6 = true;
						this.timer_0.Change(-1, -1);
					}
					this.method_64();
					using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
					{
						@class.ExecuteQuery(string.Concat(new object[]
						{
							"UPDATE user_pets SET room_id = 0 WHERE room_id = ",
							this.uint_0,
							" AND NOT user_id = ",
							Phoenix.GetGame().GetClientManager().method_27(this.Owner)
						}));
					}
					this.timer_0.Dispose();
					this.timer_0 = null;
					this.bool_9 = false;
					if (this.Tags != null)
					{
						this.Tags.Clear();
					}
					this.Tags = null;
					if (this.class33_0 != null)
					{
						Array.Clear(this.class33_0, 0, this.class33_0.Length);
					}
					this.class33_0 = null;
					this.class29_0 = null;
					if (this.list_1 != null)
					{
						this.list_1.Clear();
					}
					this.class29_0 = null;
					if (this.dictionary_0 != null)
					{
						this.dictionary_0.Clear();
					}
					this.dictionary_0 = null;
					this.Wallpaper = null;
					this.Floor = null;
					this.Landscape = null;
					if (this.hashtable_0 != null)
					{
						this.hashtable_0.Clear();
					}
					this.hashtable_0 = null;
					if (this.hashtable_4 != null)
					{
						this.hashtable_4.Clear();
					}
					this.hashtable_4 = null;
					this.class67_0 = null;
					if (this.list_2 != null)
					{
						this.list_2.Clear();
					}
					this.list_2 = null;
				}
			}
		}
		public ServerMessage method_67(bool bool_13)
		{
			List<Class33> list = new List<Class33>();
			for (int i = 0; i < this.class33_0.Length; i++)
			{
				Class33 @class = this.class33_0[i];
				if (@class != null)
				{
					if (!bool_13)
					{
						if (!@class.bool_7)
						{
							goto IL_35;
						}
						@class.bool_7 = false;
					}
					list.Add(@class);
				}
				IL_35:;
			}
			ServerMessage result;
			if (list.Count == 0)
			{
				result = null;
			}
			else
			{
				ServerMessage gClass = new ServerMessage(34u);
				gClass.AppendInt32(list.Count);
				foreach (Class33 @class in list)
				{
					@class.method_15(gClass);
				}
				result = gClass;
			}
			return result;
		}
		public bool method_68(uint uint_2)
		{
			return this.dictionary_0.ContainsKey(uint_2);
		}
		public void method_69(uint uint_2)
		{
			this.dictionary_0.Remove(uint_2);
		}
		public void method_70(uint uint_2)
		{
			this.dictionary_0.Add(uint_2, Phoenix.GetUnixTimestamp());
		}
		public bool method_71(uint uint_2)
		{
			bool result;
			if (!this.method_68(uint_2))
			{
				result = true;
			}
			else
			{
				double num = Phoenix.GetUnixTimestamp() - this.dictionary_0[uint_2];
				result = (num > 900.0);
			}
			return result;
		}
		public int method_72(string string_10)
		{
			int num = 0;
			foreach (UserItemData @class in this.Hashtable_1.Values)
			{
				if (@class.GetBaseItem().InteractionType.ToLower() == string_10.ToLower())
				{
					num++;
				}
			}
			foreach (UserItemData @class in this.Hashtable_0.Values)
			{
				if (@class.GetBaseItem().InteractionType.ToLower() == string_10.ToLower())
				{
					num++;
				}
			}
			return num;
		}
		public bool method_73(Class33 class33_1)
		{
			return !class33_1.Boolean_4 && this.method_74(class33_1.method_16().GetHabbo().Id);
		}
		public bool method_74(uint uint_2)
		{
			bool result;
			using (TimedLock.Lock(this.list_2))
			{
				foreach (Trade current in this.list_2)
				{
					if (current.method_0(uint_2))
					{
						result = true;
						return result;
					}
				}
			}
			result = false;
			return result;
		}
		public Trade method_75(Class33 class33_1)
		{
			Trade result;
			if (class33_1.Boolean_4)
			{
				result = null;
			}
			else
			{
				result = this.method_76(class33_1.method_16().GetHabbo().Id);
			}
			return result;
		}
		public Trade method_76(uint uint_2)
		{
			Trade result;
			using (TimedLock.Lock(this.list_2))
			{
				foreach (Trade current in this.list_2)
				{
					if (current.method_0(uint_2))
					{
						result = current;
						return result;
					}
				}
			}
			result = null;
			return result;
		}
		public void method_77(Class33 class33_1, Class33 class33_2)
		{
			if (class33_1 != null && class33_2 != null && (!class33_1.Boolean_4 || class33_1.class34_0.Boolean_1) && (!class33_2.Boolean_4 || class33_2.class34_0.Boolean_1) && !class33_1.Boolean_3 && !class33_2.Boolean_3 && !this.method_73(class33_1) && !this.method_73(class33_2))
			{
				this.list_2.Add(new Trade(class33_1.method_16().GetHabbo().Id, class33_2.method_16().GetHabbo().Id, this.Id));
			}
		}
		public void method_78(uint uint_2)
		{
			Trade @class = this.method_76(uint_2);
			if (@class != null)
			{
				@class.method_12(uint_2);
				this.list_2.Remove(@class);
			}
		}
		public bool method_79(GameClient class16_0, UserItemData class63_0, int int_17, int int_18, int int_19, bool bool_13, bool bool_14, bool bool_15)
		{
			Dictionary<int, Coordinates> dictionary = this.method_94(class63_0.GetBaseItem().int_2, class63_0.GetBaseItem().int_1, int_17, int_18, int_19);
			bool result;
			if (!this.method_92(int_17, int_18))
			{
				result = false;
			}
			else
			{
				foreach (Coordinates current in dictionary.Values)
				{
					if (!this.method_92(current.X, current.Y))
					{
						result = false;
						return result;
					}
				}
				double num = this.Class28_0.double_1[int_17, int_18];
				if (!bool_14)
				{
					if (class63_0.int_3 == int_19 && class63_0.Int32_0 == int_17 && class63_0.Int32_1 == int_18 && class63_0.Double_0 != num)
					{
						result = false;
						return result;
					}
                    if (this.Class28_0.squareState[int_17, int_18] != SquareState.OPEN)
					{
						result = false;
						return result;
					}
					foreach (Coordinates current in dictionary.Values)
					{
                        if (this.Class28_0.squareState[current.X, current.Y] != SquareState.OPEN)
						{
							result = false;
							return result;
						}
					}
					if (class63_0.GetBaseItem().bool_2 || class63_0.Boolean_0)
					{
						goto IL_1FE;
					}
					if (this.method_97(int_17, int_18))
					{
						result = false;
						return result;
					}
					using (Dictionary<int, Coordinates>.ValueCollection.Enumerator enumerator = dictionary.Values.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							Coordinates current = enumerator.Current;
							if (this.method_97(current.X, current.Y))
							{
								result = false;
								return result;
							}
						}
						goto IL_1FE;
					}
				}
                if (this.Class28_0.squareState[int_17, int_18] != SquareState.OPEN)
				{
					result = false;
					return result;
				}
				if (!bool_15 && this.method_97(int_17, int_18))
				{
					result = false;
					return result;
				}
				IL_1FE:
				List<UserItemData> list = this.method_93(int_17, int_18);
				List<UserItemData> list2 = new List<UserItemData>();
				List<UserItemData> list3 = new List<UserItemData>();
				foreach (Coordinates current in dictionary.Values)
                {
                    List<UserItemData> list4 = this.method_93(current.X, current.Y);
					if (list4 != null)
					{
						list2.AddRange(list4);
					}
				}
				if (list == null)
				{
					list = new List<UserItemData>();
				}
				list3.AddRange(list);
				list3.AddRange(list2);
				int num2 = 0;
				foreach (UserItemData current2 in list3)
				{
					if (current2 != null && current2.uint_0 != class63_0.uint_0 && current2.GetBaseItem() != null)
					{
						if (!current2.GetBaseItem().bool_0)
						{
							result = false;
							return result;
						}
						if (class63_0.GetBaseItem().InteractionType.ToLower() == "wf_trg_timer" && current2.GetBaseItem().InteractionType.ToLower() == "wf_trg_timer")
						{
							result = false;
							return result;
						}
						if (class63_0.GetBaseItem().InteractionType.ToLower() == "ball")
						{
							if (current2.GetBaseItem().InteractionType.ToLower() == "blue_goal")
							{
								num2 = 11;
							}
							if (current2.GetBaseItem().InteractionType.ToLower() == "red_goal")
							{
								num2 = 5;
							}
							if (current2.GetBaseItem().InteractionType.ToLower() == "yellow_goal")
							{
								num2 = 14;
							}
							if (current2.GetBaseItem().InteractionType.ToLower() == "green_goal")
							{
								num2 = 8;
							}
						}
					}
				}
				if (num2 > 0)
				{
					this.method_89(num2, class63_0, false);
				}
				if (!class63_0.Boolean_0)
				{
					if (class63_0.int_3 != int_19 && class63_0.Int32_0 == int_17 && class63_0.Int32_1 == int_18)
					{
						num = class63_0.Double_0;
					}
					foreach (UserItemData current2 in list3)
					{
						if (current2.uint_0 != class63_0.uint_0 && current2.Double_1 > num)
						{
							num = current2.Double_1;
						}
					}
				}
				if (int_19 != 0 && int_19 != 2 && int_19 != 4 && int_19 != 6 && int_19 != 8)
				{
					int_19 = 0;
				}
				Dictionary<int, Coordinates> dictionary2 = new Dictionary<int, Coordinates>();
				dictionary2 = this.method_94(class63_0.GetBaseItem().int_2, class63_0.GetBaseItem().int_1, class63_0.Int32_0, class63_0.Int32_1, class63_0.int_3);
				int num3 = 0;
				int num4 = 0;
				if (!bool_13)
				{
					num3 = class63_0.Int32_0;
					num4 = class63_0.Int32_1;
				}
				class63_0.int_3 = int_19;
				class63_0.method_0(int_17, int_18, num);
				if (!bool_14 && class16_0 != null)
				{
					class63_0.Class69_0.OnPlace(class16_0, class63_0);
				}
				if (bool_13)
				{
					if (this.hashtable_1.Contains(class63_0.uint_0))
					{
						this.hashtable_1.Remove(class63_0.uint_0);
					}
					if (this.hashtable_3.Contains(class63_0.uint_0))
					{
						result = false;
						return result;
					}
					this.hashtable_3.Add(class63_0.uint_0, class63_0);
					if (class63_0.Boolean_2)
					{
						if (this.hashtable_0.Contains(class63_0.uint_0))
						{
							this.hashtable_0.Remove(class63_0.uint_0);
						}
						this.hashtable_0.Add(class63_0.uint_0, class63_0);
					}
					else
					{
						if (this.hashtable_4.Contains(class63_0.uint_0))
						{
							this.hashtable_4.Remove(class63_0.uint_0);
						}
						this.hashtable_4.Add(class63_0.uint_0, class63_0);
					}
					ServerMessage gclass5_ = new ServerMessage(93u);
					class63_0.method_6(gclass5_);
					this.SendMessage(gclass5_, null);
					string text = class63_0.GetBaseItem().InteractionType.ToLower();
					switch (text)
					{
					case "bb_patch":
						this.list_5.Add(class63_0);
						if (class63_0.string_0 == "5")
						{
							this.list_6.Add(class63_0);
						}
						else
						{
							if (class63_0.string_0 == "8")
							{
								this.list_7.Add(class63_0);
							}
							else
							{
								if (class63_0.string_0 == "11")
								{
									this.list_9.Add(class63_0);
								}
								else
								{
									if (class63_0.string_0 == "14")
									{
										this.list_8.Add(class63_0);
									}
								}
							}
						}
						break;
					case "blue_score":
						this.list_12.Add(class63_0);
						break;
					case "green_score":
						this.list_13.Add(class63_0);
						break;
					case "red_score":
						this.list_10.Add(class63_0);
						break;
					case "yellow_score":
						this.list_11.Add(class63_0);
						break;
					case "stickiepole":
						this.list_3.Add(class63_0);
						break;
					case "wf_trg_onsay":
					case "wf_trg_enterroom":
					case "wf_trg_furnistate":
					case "wf_trg_onfurni":
					case "wf_trg_offfurni":
					case "wf_trg_gameend":
					case "wf_trg_gamestart":
					case "wf_trg_attime":
					case "wf_trg_atscore":
						if (!this.list_14.Contains(class63_0))
						{
							this.list_14.Add(class63_0);
						}
						break;
					case "wf_trg_timer":
						if (class63_0.string_2.Length <= 0)
						{
							class63_0.string_2 = "10";
						}
						if (!this.list_14.Contains(class63_0))
						{
							this.list_14.Add(class63_0);
						}
						class63_0.bool_0 = true;
						class63_0.method_3(1);
						break;
					case "wf_act_saymsg":
					case "wf_act_moveuser":
					case "wf_act_togglefurni":
					case "wf_act_givepoints":
					case "wf_act_moverotate":
					case "wf_act_matchfurni":
					case "wf_act_give_phx":
						if (!this.list_15.Contains(class63_0))
						{
							this.list_15.Add(class63_0);
						}
						break;
					case "wf_cnd_trggrer_on_frn":
					case "wf_cnd_furnis_hv_avtrs":
					case "wf_cnd_has_furni_on":
					case "wf_cnd_phx":
						if (!this.list_16.Contains(class63_0))
						{
							this.list_16.Add(class63_0);
						}
						break;
					}
				}
				else
				{
					if (!this.hashtable_2.Contains(class63_0.uint_0) && !this.hashtable_3.ContainsKey(class63_0.uint_0))
					{
						this.hashtable_2.Add(class63_0.uint_0, class63_0);
					}
					if (class63_0.GetBaseItem().InteractionType.ToLower() == "wf_act_give_phx" && class16_0 != null)
					{
						string text2 = class63_0.string_2.Split(new char[]
						{
							':'
						})[0].ToLower();
						if (!Phoenix.GetGame().GetRoleManager().method_12(text2, class16_0))
						{
							class63_0.string_2 = "";
						}
					}
					if (class63_0.GetBaseItem().InteractionType.ToLower() == "wf_cnd_phx" && class16_0 != null)
					{
						string text2 = class63_0.string_2.Split(new char[]
						{
							':'
						})[0].ToLower();
						if (!Phoenix.GetGame().GetRoleManager().method_11(text2, class16_0))
						{
							class63_0.string_2 = "";
						}
					}
					ServerMessage gclass5_ = new ServerMessage(95u);
					class63_0.method_6(gclass5_);
					this.SendMessage(gclass5_, null);
				}
				this.method_22();
				if (!bool_14)
				{
					this.method_87(this.method_43(int_17, int_18), true, true);
					foreach (Coordinates current in dictionary.Values)
					{
						this.method_87(this.method_43(current.X, current.Y), true, true);
					}
					if (num3 > 0 || num4 > 0)
					{
						this.method_87(this.method_43(num3, num4), true, true);
					}
					foreach (Coordinates current in dictionary2.Values)
					{
						this.method_87(this.method_43(current.X, current.Y), true, true);
					}
				}
				result = true;
			}
			return result;
		}
		internal void method_80(UserItemData class63_0)
		{
			if (!this.hashtable_2.Contains(class63_0.uint_0) && !this.hashtable_3.ContainsKey(class63_0.uint_0))
			{
				this.hashtable_2.Add(class63_0.uint_0, class63_0);
			}
		}
		public bool method_81(UserItemData class63_0, int int_17, int int_18, double double_3)
		{
			Dictionary<int, Coordinates> dictionary = this.method_94(class63_0.GetBaseItem().int_2, class63_0.GetBaseItem().int_1, int_17, int_18, class63_0.int_3);
			class63_0.method_0(int_17, int_18, double_3);
			if (!this.hashtable_2.Contains(class63_0.uint_0))
			{
				this.hashtable_2.Add(class63_0.uint_0, class63_0);
			}
			this.method_22();
			this.method_87(this.method_43(int_17, int_18), true, true);
			foreach (Coordinates current in dictionary.Values)
			{
				this.method_87(this.method_43(current.X, current.Y), true, true);
			}
			return true;
		}
		public bool method_82(GameClient class16_0, UserItemData class63_0, bool bool_13, string string_10)
		{
			if (bool_13)
			{
				class63_0.Class69_0.OnPlace(class16_0, class63_0);
				string text = class63_0.GetBaseItem().InteractionType.ToLower();
				if (text != null && text == "dimmer" && this.class67_0 == null)
				{
					this.class67_0 = new MoodlightData(class63_0.uint_0);
					class63_0.string_0 = this.class67_0.method_7();
				}
				if (!this.hashtable_3.ContainsKey(class63_0.uint_0))
				{
					this.hashtable_3.Add(class63_0.uint_0, class63_0);
					if (class63_0.Boolean_2)
					{
						this.hashtable_0.Add(class63_0.uint_0, class63_0);
					}
					else
					{
						if (!this.hashtable_4.Contains(class63_0.uint_0))
						{
							this.hashtable_4.Add(class63_0.uint_0, class63_0);
						}
					}
				}
				ServerMessage gclass5_ = new ServerMessage(83u);
				class63_0.method_6(gclass5_);
				this.SendMessage(gclass5_, null);
			}
			else
			{
				if (!this.hashtable_2.Contains(class63_0.uint_0))
				{
					this.hashtable_2.Add(class63_0.uint_0, class63_0);
				}
			}
			if (!bool_13)
			{
				class63_0.string_7 = string_10;
				ServerMessage gclass5_ = new ServerMessage(85u);
				class63_0.method_6(gclass5_);
				this.SendMessage(gclass5_, null);
			}
			return true;
		}
		public void method_83()
		{
			for (int i = 0; i < this.class33_0.Length; i++)
			{
				Class33 @class = this.class33_0[i];
				if (@class != null)
				{
					this.method_87(@class, true, true);
				}
			}
		}
		public double method_84(int int_17, int int_18, List<UserItemData> list_18)
		{
			double result;
			try
			{
				bool flag = false;
				if (this.double_2[int_17, int_18] != 0.0)
				{
					flag = true;
				}
				double num = 0.0;
				bool flag2 = false;
				double num2 = 0.0;
				if (list_18 == null)
				{
					list_18 = new List<UserItemData>();
				}
				if (list_18 != null)
				{
					foreach (UserItemData current in list_18)
					{
						if ((current.GetBaseItem().bool_2 || current.GetBaseItem().InteractionType.ToLower() == "bed") && flag)
						{
							result = current.Double_0;
							return result;
						}
						if (current.Double_1 > num)
						{
							if (current.GetBaseItem().bool_2 || current.GetBaseItem().InteractionType.ToLower() == "bed")
							{
								if (flag)
								{
									result = current.Double_0;
									return result;
								}
								flag2 = true;
								num2 = current.GetBaseItem().Height;
							}
							else
							{
								flag2 = false;
							}
							num = current.Double_1;
						}
					}
				}
				double num3 = this.Class28_0.double_1[int_17, int_18];
				double num4 = num - this.Class28_0.double_1[int_17, int_18];
				if (flag2)
				{
					num4 -= num2;
				}
				if (num4 < 0.0)
				{
					num4 = 0.0;
				}
				result = num3 + num4;
			}
			catch
			{
				result = 0.0;
			}
			return result;
		}
		public void method_85(Class33 class33_1)
		{
			List<UserItemData> list = this.method_93(class33_1.int_3, class33_1.int_4);
			foreach (UserItemData current in list)
			{
				this.method_12(class33_1, current);
				if (current.GetBaseItem().InteractionType.ToLower() == "pressure_pad")
				{
					current.string_0 = "0";
					current.method_5(false, true);
				}
			}
			this.byte_0[class33_1.int_3, class33_1.int_4] = 1;
		}
		public void method_86(Class33 class33_1)
		{
			List<UserItemData> list = this.method_93(class33_1.int_3, class33_1.int_4);
			foreach (UserItemData current in list)
			{
				string text = current.GetBaseItem().InteractionType.ToLower();
				if (text != null)
				{
					if (!(text == "pressure_pad"))
					{
						if (text == "fbgate" && (!string.IsNullOrEmpty(current.string_2) || !string.IsNullOrEmpty(current.string_3)))
						{
							class33_1 = this.method_43(current.GStruct1_0.x, current.GStruct1_0.y);
							if (class33_1 != null && !class33_1.Boolean_4 && current.string_2 != null && current.string_3 != null)
							{
								string a = class33_1.method_16().GetHabbo().string_6;
								if (a == "m")
								{
									AntiMutant.smethod_1(class33_1, current.string_2);
								}
								else
								{
									AntiMutant.smethod_1(class33_1, current.string_3);
								}
								ServerMessage gClass = new ServerMessage(266u);
								gClass.AppendInt32(class33_1.int_0);
								gClass.AppendStringWithBreak(class33_1.method_16().GetHabbo().string_5);
								gClass.AppendStringWithBreak(class33_1.method_16().GetHabbo().string_6.ToLower());
								gClass.AppendStringWithBreak(class33_1.method_16().GetHabbo().string_4);
								gClass.AppendInt32(class33_1.method_16().GetHabbo().int_13);
								gClass.AppendStringWithBreak("");
								this.SendMessage(gClass, null);
							}
						}
					}
					else
					{
						current.string_0 = "1";
						current.method_5(false, true);
					}
				}
			}
		}
		public void method_87(Class33 User, bool bool_13, bool bool_14)
		{
			int num = 0;
			try
			{
				if (User != null)
				{
					num = 1;
					if (User.Boolean_0)
					{
						User.class15_0.X = User.int_3;
						User.class15_0.Y = User.int_4;
						User.class15_0.Z = User.double_0;
					}
					else
					{
						if (User.Boolean_4)
						{
							User.class34_0.int_1 = User.int_3;
							User.class34_0.int_2 = User.int_4;
							User.class34_0.double_0 = User.double_0;
						}
						else
						{
							if (User.class34_1 != null && User.class33_0 != null)
							{
								return;
							}
						}
					}
					num = 2;
					if (!User.bool_12)
					{
						User.bool_7 = false;
					}
					else
					{
						num = 3;
						if (bool_13)
						{
							num = 4;
							if (User.byte_1 > 0)
							{
								num = 5;
								if (User.Boolean_4)
								{
									if (this.byte_1[User.int_3, User.int_4] == 0)
									{
										User.class34_0.int_0 = -1;
										User.byte_1 = 0;
									}
								}
								else
								{
									num = 6;
									if ((User.method_16().GetHabbo().string_6.ToLower() == "m" && this.byte_1[User.int_3, User.int_4] == 0) || (User.method_16().GetHabbo().string_6.ToLower() == "f" && this.byte_2[User.int_3, User.int_4] == 0))
									{
										User.method_16().GetHabbo().method_24().method_2(-1, true);
										User.byte_1 = 0;
									}
								}
							}
							num = 7;
							if (User.Statusses.ContainsKey("lay") || User.Statusses.ContainsKey("sit"))
							{
								User.Statusses.Remove("lay");
								User.Statusses.Remove("sit");
								User.bool_7 = true;
							}
							List<UserItemData> list = this.method_93(User.int_3, User.int_4);
							double num2 = this.method_84(User.int_3, User.int_4, list);
							if (num2 != User.double_0)
							{
								User.double_0 = num2;
								User.bool_7 = true;
							}
							num = 8;
                            if (this.Class28_0.squareState[User.int_3, User.int_4] == SquareState.SEAT)
							{
								if (!User.Statusses.ContainsKey("sit"))
								{
									User.Statusses.Add("sit", "1.0");
									if (User.byte_1 > 0)
									{
										if (!User.Boolean_4)
										{
											User.method_16().GetHabbo().method_24().method_2(-1, true);
										}
										else
										{
											User.class34_0.int_0 = -1;
										}
										User.byte_1 = 0;
									}
								}
								num = 9;
								User.double_0 = this.Class28_0.double_1[User.int_3, User.int_4];
								User.int_7 = this.Class28_0.int_3[User.int_3, User.int_4];
								User.int_8 = this.Class28_0.int_3[User.int_3, User.int_4];
								if (User.Boolean_4 && User.class34_0.class33_0 != null)
								{
									User.class34_0.class33_0.double_0 = User.double_0 + 1.0;
									User.class34_0.class33_0.int_7 = User.int_7;
									User.class34_0.class33_0.int_8 = User.int_8;
								}
								User.bool_7 = true;
							}
							if (list.Count < 1 && this.list_4.Contains(User.uint_0))
							{
								User.method_16().GetHabbo().method_24().method_2(-1, false);
								this.list_4.Remove(User.uint_0);
								User.int_14 = 0;
								User.bool_7 = true;
							}
							num = 10;
							lock (list)
							{
								foreach (UserItemData Item in list)
								{
									num = 11;
									if (Item.GetBaseItem().bool_2 && (!User.Boolean_0 || User.class34_0.class33_0 == null))
									{
										if (!User.Statusses.ContainsKey("sit"))
										{
											double num3;
											try
											{
												if (Item.GetBaseItem().list_0.Count > 1)
												{
													num3 = Item.GetBaseItem().list_0[(int)Convert.ToInt16(Item.string_0)];
												}
												else
												{
													num3 = Item.GetBaseItem().Height;
												}
												goto IL_BCA;
											}
											catch
											{
												num3 = Item.GetBaseItem().Height;
												goto IL_BCA;
											}
											IL_51B:
											if (User.byte_1 > 0)
											{
												if (!User.Boolean_4)
												{
													User.method_16().GetHabbo().method_24().method_2(-1, true);
												}
												else
												{
													User.class34_0.int_0 = -1;
												}
												User.byte_1 = 0;
												goto IL_55D;
											}
											goto IL_55D;
											IL_BCA:
											if (User.Statusses.ContainsKey("sit"))
											{
												goto IL_51B;
											}
											User.Statusses.Add("sit", num3.ToString().Replace(',', '.'));
											goto IL_51B;
										}
										IL_55D:
										User.double_0 = Item.Double_0;
										User.int_7 = Item.int_3;
										User.int_8 = Item.int_3;
										if (User.Boolean_4 && User.class34_0.class33_0 != null)
										{
											User.class34_0.class33_0.double_0 = User.double_0 + 1.0;
											User.class34_0.class33_0.int_7 = User.int_7;
											User.class34_0.class33_0.int_8 = User.int_8;
										}
										User.bool_7 = true;
									}
									num = 12;
									if (Item.GetBaseItem().InteractionType.ToLower() == "bed")
									{
										if (!User.Statusses.ContainsKey("lay"))
										{
											double num3;
											try
											{
												if (Item.GetBaseItem().list_0.Count > 1)
												{
													num3 = Item.GetBaseItem().list_0[(int)Convert.ToInt16(Item.string_0)];
												}
												else
												{
													num3 = Item.GetBaseItem().Height;
												}
											}
											catch
											{
												//num3 = ;
											}
											if (!User.Statusses.ContainsKey("lay"))
											{
												User.Statusses.Add("lay", Item.GetBaseItem().Height.ToString().Replace(',', '.') + " null");
											}
											if (User.byte_1 > 0)
											{
												if (!User.Boolean_4)
												{
													User.method_16().GetHabbo().method_24().method_2(-1, true);
												}
												else
												{
													User.class34_0.int_0 = -1;
												}
												User.byte_1 = 0;
											}
										}
										User.double_0 = Item.Double_0;
										User.int_7 = Item.int_3;
										User.int_8 = Item.int_3;
										if (User.Boolean_4 && User.class34_0.class33_0 != null)
										{
											User.class34_0.class33_0.double_0 = User.double_0 + 1.0;
											User.class34_0.class33_0.int_7 = User.int_7;
											User.class34_0.class33_0.int_8 = User.int_8;
										}
										User.bool_7 = true;
									}
									num = 13;
									if (Item.GetBaseItem().InteractionType.ToLower().IndexOf("bb_") > -1 && !User.Boolean_4)
									{
										if (Item.GetBaseItem().InteractionType.ToLower().IndexOf("_gate") > -1)
										{
											int num4 = 0;
											int num5 = 0;
											if (Item.GetBaseItem().InteractionType.ToLower() == "bb_yellow_gate")
											{
												num5 = 12;
												num4 = 36;
											}
											else
											{
												if (Item.GetBaseItem().InteractionType.ToLower() == "bb_red_gate")
												{
													num5 = 3;
													num4 = 33;
												}
												else
												{
													if (Item.GetBaseItem().InteractionType.ToLower() == "bb_green_gate")
													{
														num5 = 6;
														num4 = 34;
													}
													else
													{
														if (Item.GetBaseItem().InteractionType.ToLower() == "bb_blue_gate")
														{
															num5 = 9;
															num4 = 35;
														}
													}
												}
											}
											if (!this.list_4.Contains(User.uint_0))
											{
												User.method_16().GetHabbo().method_24().method_2(num4, true);
												User.bool_7 = true;
												User.int_14 = num5;
												this.list_4.Add(User.uint_0);
											}
											else
											{
												User.method_16().GetHabbo().method_24().method_2(-1, false);
												User.bool_7 = true;
												User.int_14 = 0;
												this.list_4.Remove(User.uint_0);
											}
										}
										if (Item.GetBaseItem().InteractionType.ToLower() == "bb_teleport")
										{
											this.method_91(Item, User);
										}
										if (Item.GetBaseItem().InteractionType.ToLower() == "bb_patch" && User.int_14 > 0 && User.bool_6 && Item.string_0 != "14" && Item.string_0 != "5" && Item.string_0 != "8" && Item.string_0 != "11" && Item.string_0 != "1")
										{
											if (Item.string_0 == "0" || Item.string_0 == "")
											{
												Item.string_0 = Convert.ToString(User.int_14);
											}
											else
											{
												if (Convert.ToInt32(Item.string_0) > 0)
												{
													if (User.int_14 == 12 && (Item.string_0 == "12" || Item.string_0 == "13"))
													{
														Item.string_0 = Convert.ToString(Convert.ToInt32(Item.string_0) + 1);
													}
													else
													{
														if (User.int_14 == 3 && (Item.string_0 == "3" || Item.string_0 == "4"))
														{
															Item.string_0 = Convert.ToString(Convert.ToInt32(Item.string_0) + 1);
														}
														else
														{
															if (User.int_14 == 6 && (Item.string_0 == "6" || Item.string_0 == "7"))
															{
																Item.string_0 = Convert.ToString(Convert.ToInt32(Item.string_0) + 1);
															}
															else
															{
																if (User.int_14 == 9 && (Item.string_0 == "9" || Item.string_0 == "10"))
																{
																	Item.string_0 = Convert.ToString(Convert.ToInt32(Item.string_0) + 1);
																}
																else
																{
																	Item.string_0 = Convert.ToString(User.int_14);
																}
															}
														}
													}
												}
											}
											this.method_89(User.int_14 + 2, Item, false);
											Item.method_5(true, true);
										}
									}
								}
								goto IL_1155;
							}
						}
						num = 14;
						List<UserItemData> list2 = this.method_93(User.int_12, User.int_13);
						lock (list2)
						{
							foreach (UserItemData current in list2)
							{
								if (this.double_0[current.Int32_0, current.Int32_1] <= current.Double_0)
								{
									if (bool_14)
									{
										this.method_11(User, current);
									}
									if (current.GetBaseItem().InteractionType.ToLower() == "pressure_pad")
									{
										current.string_0 = "1";
										current.method_5(false, true);
									}
									num = 15;
									if (current.GetBaseItem().InteractionType.ToLower() == "fbgate" && (!string.IsNullOrEmpty(current.string_2) || !string.IsNullOrEmpty(current.string_3)) && User != null && !User.Boolean_4)
									{
										if (User.string_0 != "")
										{
											User.method_16().GetHabbo().string_5 = User.string_0;
											User.string_0 = "";
											ServerMessage gClass = new ServerMessage(266u);
											gClass.AppendInt32(User.int_0);
											gClass.AppendStringWithBreak(User.method_16().GetHabbo().string_5);
											gClass.AppendStringWithBreak(User.method_16().GetHabbo().string_6.ToLower());
											gClass.AppendStringWithBreak(User.method_16().GetHabbo().string_4);
											gClass.AppendInt32(User.method_16().GetHabbo().int_13);
											gClass.AppendStringWithBreak("");
											this.SendMessage(gClass, null);
										}
										else
										{
											string a = User.method_16().GetHabbo().string_6;
											User.string_0 = User.method_16().GetHabbo().string_5;
											if (a == "m")
											{
												AntiMutant.smethod_1(User, current.string_2);
											}
											else
											{
												AntiMutant.smethod_1(User, current.string_3);
											}
											ServerMessage gClass = new ServerMessage(266u);
											gClass.AppendInt32(User.int_0);
											gClass.AppendStringWithBreak(User.method_16().GetHabbo().string_5);
											gClass.AppendStringWithBreak(User.method_16().GetHabbo().string_6.ToLower());
											gClass.AppendStringWithBreak(User.method_16().GetHabbo().string_4);
											gClass.AppendInt32(User.method_16().GetHabbo().int_13);
											gClass.AppendStringWithBreak("");
											this.SendMessage(gClass, null);
										}
									}
									num = 16;
									if (current.GetBaseItem().InteractionType.ToLower() == "ball")
									{
										int num6 = current.Int32_0;
										int num7 = current.Int32_1;
										current.string_0 = "11";
										if (User.int_8 == 4)
										{
											num7++;
											if (!this.method_79(null, current, num6, num7, 0, false, true, false))
											{
												this.method_79(null, current, num6, num7 - 2, 0, false, true, true);
											}
										}
										else
										{
											if (User.int_8 == 0)
											{
												num7--;
												if (!this.method_79(null, current, num6, num7, 0, false, true, false))
												{
													this.method_79(null, current, num6, num7 + 2, 0, false, true, true);
												}
											}
											else
											{
												if (User.int_8 == 6)
												{
													num6--;
													if (!this.method_79(null, current, num6, num7, 0, false, true, false))
													{
														this.method_79(null, current, num6 + 2, num7, 0, false, true, true);
													}
												}
												else
												{
													if (User.int_8 == 2)
													{
														num6++;
														if (!this.method_79(null, current, num6, num7, 0, false, true, false))
														{
															this.method_79(null, current, num6 - 2, num7, 0, false, true, true);
														}
													}
													else
													{
														if (User.int_8 == 3)
														{
															num6++;
															num7++;
															if (!this.method_79(null, current, num6, num7, 0, false, true, false))
															{
																this.method_79(null, current, num6 - 2, num7 - 2, 0, false, true, true);
															}
														}
														else
														{
															if (User.int_8 == 1)
															{
																num6++;
																num7--;
																if (!this.method_79(null, current, num6, num7, 0, false, true, false))
																{
																	this.method_79(null, current, num6 - 2, num7 + 2, 0, false, true, true);
																}
															}
															else
															{
																if (User.int_8 == 7)
																{
																	num6--;
																	num7--;
																	if (!this.method_79(null, current, num6, num7, 0, false, true, false))
																	{
																		this.method_79(null, current, num6 + 2, num7 + 2, 0, false, true, true);
																	}
																}
																else
																{
																	if (User.int_8 == 5)
																	{
																		num6--;
																		num7++;
																		if (!this.method_79(null, current, num6, num7, 0, false, true, false))
																		{
																			this.method_79(null, current, num6 + 2, num7 - 2, 0, false, true, true);
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
						IL_1155:;
					}
				}
			}
			catch (Exception ex)
			{
                Logging.LogThreadException(ex.ToString(), string.Concat(new object[]
				{
					"Room [ID: ",
					this.Id,
					"] [Part: ",
					num,
					"] Update User Status"
				}));
				this.method_34();
			}
		}
		public void method_88(int int_17, int int_18, UserItemData class63_0)
		{
			if (int_17 == 5)
			{
				this.int_9 += int_18 - 1;
			}
			else
			{
				if (int_17 == 8)
				{
					this.int_12 += int_18 - 1;
				}
				else
				{
					if (int_17 == 11)
					{
						this.int_11 += int_18 - 1;
					}
					else
					{
						if (int_17 == 14)
						{
							this.int_10 += int_18 - 1;
						}
					}
				}
			}
			this.method_89(int_17, class63_0, false);
		}
		public void method_89(int int_17, UserItemData class63_0, bool bool_13)
		{
			if (int_17 == 5)
			{
				this.int_9++;
				if (class63_0.string_0 == "5")
				{
					this.list_6.Add(class63_0);
				}
				if (this.list_10.Count > 0)
				{
					foreach (UserItemData current in this.list_10)
					{
						current.string_0 = Convert.ToString(this.int_9);
						current.method_5(true, true);
					}
				}
				this.method_17(this.int_9);
			}
			else
			{
				if (int_17 == 8)
				{
					this.int_12++;
					if (class63_0.string_0 == "8")
					{
						this.list_7.Add(class63_0);
					}
					if (this.list_13.Count > 0)
					{
						foreach (UserItemData current in this.list_13)
						{
							current.string_0 = Convert.ToString(this.int_12);
							current.method_5(true, true);
						}
					}
					this.method_17(this.int_12);
				}
				else
				{
					if (int_17 == 11)
					{
						this.int_11++;
						if (class63_0.string_0 == "11")
						{
							this.list_9.Add(class63_0);
						}
						if (this.list_12.Count > 0)
						{
							foreach (UserItemData current in this.list_12)
							{
								current.string_0 = Convert.ToString(this.int_11);
								current.method_5(true, true);
							}
						}
						this.method_17(this.int_11);
					}
					else
					{
						if (int_17 == 14)
						{
							this.int_10++;
							if (class63_0.string_0 == "14")
							{
								this.list_8.Add(class63_0);
							}
							if (this.list_11.Count > 0)
							{
								foreach (UserItemData current in this.list_11)
								{
									current.string_0 = Convert.ToString(this.int_10);
									current.method_5(true, true);
								}
							}
							this.method_17(this.int_10);
						}
					}
				}
			}
			if (bool_13 || (this.list_5.Count > 0 && this.list_6.Count + this.list_7.Count + this.list_9.Count + this.list_8.Count >= this.list_5.Count))
			{
				bool_13 = true;
				if (this.int_10 > this.int_9 && this.int_10 > this.int_11 && this.int_10 > this.int_12)
				{
					new Room.Delegate2(this.method_90).BeginInvoke(14, null, null);
				}
				else
				{
					if (this.int_9 > this.int_10 && this.int_9 > this.int_11 && this.int_9 > this.int_12)
					{
						new Room.Delegate2(this.method_90).BeginInvoke(5, null, null);
					}
					else
					{
						if (this.int_11 > this.int_9 && this.int_11 > this.int_10 && this.int_11 > this.int_12)
						{
							new Room.Delegate2(this.method_90).BeginInvoke(11, null, null);
						}
						else
						{
							if (this.int_12 > this.int_9 && this.int_12 > this.int_11 && this.int_12 > this.int_10)
							{
								new Room.Delegate2(this.method_90).BeginInvoke(8, null, null);
							}
						}
					}
				}
			}
			if (bool_13)
			{
				this.method_13();
			}
		}
		public void method_90(int int_17)
		{
			List<UserItemData> list = new List<UserItemData>();
			if (int_17 == 5)
			{
				list = this.list_6;
			}
			else
			{
				if (int_17 == 8)
				{
					list = this.list_7;
				}
				else
				{
					if (int_17 == 11)
					{
						list = this.list_9;
					}
					else
					{
						if (int_17 == 14)
						{
							list = this.list_8;
						}
					}
				}
			}
			try
			{
				for (int i = 4; i > 0; i--)
				{
					Thread.Sleep(500);
					foreach (UserItemData current in list)
					{
						current.string_0 = "1";
						current.method_5(false, true);
					}
					Thread.Sleep(500);
					foreach (UserItemData current in list)
					{
						current.string_0 = Convert.ToString(int_17);
						current.method_5(false, true);
					}
				}
				foreach (UserItemData current in this.list_5)
				{
					current.string_0 = "0";
					current.method_5(true, true);
				}
			}
			catch
			{
			}
			this.list_9.Clear();
			this.list_7.Clear();
			this.list_6.Clear();
			this.list_8.Clear();
			this.int_10 = 0;
			this.int_11 = 0;
			this.int_9 = 0;
			this.int_12 = 0;
			foreach (UserItemData current in this.list_10)
			{
				current.string_0 = "0";
				current.method_5(true, true);
			}
			foreach (UserItemData current in this.list_13)
			{
				current.string_0 = "0";
				current.method_5(true, true);
			}
			foreach (UserItemData current in this.list_12)
			{
				current.string_0 = "0";
				current.method_5(true, true);
			}
			foreach (UserItemData current in this.list_11)
			{
				current.string_0 = "0";
				current.method_5(true, true);
			}
		}
		public void method_91(UserItemData class63_0, Class33 class33_1)
		{
			class63_0.string_0 = "1";
			class63_0.method_5(false, true);
			class63_0.method_3(1);
			List<UserItemData> list = new List<UserItemData>();
			class33_1.method_3(true);
			foreach (UserItemData @class in this.Hashtable_0.Values)
			{
				if (@class != class63_0 && !(@class.GetBaseItem().InteractionType.ToLower() != "bb_teleport"))
				{
					list.Add(@class);
				}
			}
			if (list.Count > 0)
			{
				Random random = new Random((int)Phoenix.GetUnixTimestamp() * (int)class33_1.uint_0);
				int index = random.Next(0, list.Count);
				list[index].string_0 = "1";
				list[index].method_5(false, true);
				list[index].method_3(1);
				this.byte_0[class33_1.int_3, class33_1.int_4] = 1;
				this.byte_0[list[index].Int32_0, list[index].Int32_1] = 1;
				class33_1.method_7(list[index].Int32_0, list[index].Int32_1, list[index].Double_0);
				class33_1.bool_7 = true;
			}
		}
		public bool method_92(int int_17, int int_18)
		{
			return int_17 >= 0 && int_18 >= 0 && int_17 < this.Class28_0.int_4 && int_18 < this.Class28_0.int_5;
		}
		public List<UserItemData> method_93(int int_17, int int_18)
		{
			List<UserItemData> list = new List<UserItemData>();
			List<UserItemData> result;
			if (this.Hashtable_0 != null)
			{
				foreach (UserItemData @class in this.Hashtable_0.Values)
				{
					if (@class.Int32_0 == int_17 && @class.Int32_1 == int_18)
					{
						list.Add(@class);
					}
					Dictionary<int, Coordinates> dictionary = this.method_94(@class.GetBaseItem().int_2, @class.GetBaseItem().int_1, @class.Int32_0, @class.Int32_1, @class.int_3);
					foreach (Coordinates current in dictionary.Values)
					{
						if (current.X == int_17 && current.Y == int_18)
						{
							list.Add(@class);
						}
					}
				}
				result = list;
			}
			else
			{
				result = null;
			}
			return result;
		}
		public Dictionary<int, Coordinates> method_94(int int_17, int int_18, int int_19, int int_20, int int_21)
		{
			int num = 0;
			Dictionary<int, Coordinates> dictionary = new Dictionary<int, Coordinates>();
			if (int_17 > 1)
			{
				if (int_21 == 0 || int_21 == 4)
				{
					for (int i = 1; i < int_17; i++)
					{
						dictionary.Add(num++, new Coordinates(int_19, int_20 + i, i));
						for (int j = 1; j < int_18; j++)
						{
							dictionary.Add(num++, new Coordinates(int_19 + j, int_20 + i, (i < j) ? j : i));
						}
					}
				}
				else
				{
					if (int_21 == 2 || int_21 == 6)
					{
						for (int i = 1; i < int_17; i++)
						{
							dictionary.Add(num++, new Coordinates(int_19 + i, int_20, i));
							for (int j = 1; j < int_18; j++)
							{
								dictionary.Add(num++, new Coordinates(int_19 + i, int_20 + j, (i < j) ? j : i));
							}
						}
					}
				}
			}
			if (int_18 > 1)
			{
				if (int_21 == 0 || int_21 == 4)
				{
					for (int i = 1; i < int_18; i++)
					{
						dictionary.Add(num++, new Coordinates(int_19 + i, int_20, i));
						for (int j = 1; j < int_17; j++)
						{
							dictionary.Add(num++, new Coordinates(int_19 + i, int_20 + j, (i < j) ? j : i));
						}
					}
				}
				else
				{
					if (int_21 == 2 || int_21 == 6)
					{
						for (int i = 1; i < int_18; i++)
						{
							dictionary.Add(num++, new Coordinates(int_19, int_20 + i, i));
							for (int j = 1; j < int_17; j++)
							{
								dictionary.Add(num++, new Coordinates(int_19 + j, int_20 + i, (i < j) ? j : i));
							}
						}
					}
				}
			}
			return dictionary;
		}
		public bool method_95(int int_17, int int_18, bool bool_13)
		{
			return !this.AllowWalkthrough && this.method_96(int_17, int_18);
		}
		public bool method_96(int int_17, int int_18)
		{
			return this.method_43(int_17, int_18) != null;
		}
		public bool method_97(int int_17, int int_18)
		{
			return this.method_44(int_17, int_18) != null;
		}
		public string method_98(string string_10)
		{
			string result;
			try
			{
				if (string_10.Contains(Convert.ToChar(13)))
				{
					result = null;
				}
				else
				{
					if (string_10.Contains(Convert.ToChar(9)))
					{
						result = null;
					}
					else
					{
						string[] array = string_10.Split(new char[]
						{
							' '
						});
						if (array[2] != "l" && array[2] != "r")
						{
							result = null;
						}
						else
						{
							string[] array2 = array[0].Substring(3).Split(new char[]
							{
								','
							});
							int num = int.Parse(array2[0]);
							int num2 = int.Parse(array2[1]);
							if (num < 0 || num2 < 0 || num > 200 || num2 > 200)
							{
								result = null;
							}
							else
							{
								string[] array3 = array[1].Substring(2).Split(new char[]
								{
									','
								});
								int num3 = int.Parse(array3[0]);
								int num4 = int.Parse(array3[1]);
								if (num3 < 0 || num4 < 0 || num3 > 200 || num4 > 200)
								{
									result = null;
								}
								else
								{
									result = string.Concat(new object[]
									{
										":w=",
										num,
										",",
										num2,
										" l=",
										num3,
										",",
										num4,
										" ",
										array[2]
									});
								}
							}
						}
					}
				}
			}
			catch
			{
				result = null;
			}
			return result;
		}
		public bool method_99(int int_17, int int_18, int int_19, int int_20)
		{
			return (Math.Abs(int_17 - int_19) <= 1 && Math.Abs(int_18 - int_20) <= 1) || (int_17 == int_19 && int_18 == int_20);
		}
		public int method_100(int int_17, int int_18, int int_19, int int_20)
		{
			return Math.Abs(int_17 - int_19) + Math.Abs(int_18 - int_20);
		}
		internal void method_101()
		{
			for (int i = 0; i < this.class33_0.Length; i++)
			{
				Class33 @class = this.class33_0[i];
				if (@class != null)
				{
					@class.int_10 = @class.int_3;
					@class.int_11 = @class.int_4;
					@class.method_13();
					@class.method_3(false);
				}
			}
		}
		internal void method_102(int int_17)
		{
			this.int_15 = int_17;
		}
	}
}
