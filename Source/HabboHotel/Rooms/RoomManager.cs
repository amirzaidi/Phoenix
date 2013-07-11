using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Phoenix.Core;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Collections;
using Phoenix.Storage;
namespace Phoenix.HabboHotel.Rooms
{
	internal sealed class RoomManager
	{
		private readonly object MAX_PETS_PER_ROOM = new object();
		private Class25 class25_0;
		private List<uint> list_0;
		private Dictionary<string, RoomModel> Models;
		private Hashtable hashtable_0;
		private List<Teleport> list_1;
		private Task task_0;
		private DateTime dateTime_0;
		private List<uint> list_2;
		internal List<RoomData> list_3;
		internal int LoadedRoomsCount
		{
			get
			{
				return this.class25_0.Count;
			}
		}
		internal int Int32_1
		{
			get
			{
				int result = 0;
				using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
				{
					result = int.Parse(@class.ReadString("SELECT COUNT(*) FROM rooms"));
				}
				return result;
			}
		}
		public RoomManager()
		{
			this.class25_0 = new Class25();
			this.list_0 = new List<uint>();
			this.Models = new Dictionary<string, RoomModel>();
			this.list_1 = new List<Teleport>();
			this.list_2 = new List<uint>();
			this.hashtable_0 = new Hashtable();
			this.task_0 = new Task(new Action(this.method_7));
			this.task_0.Start();
		}
		internal void method_0()
		{
			Logging.Write("Loading Room Cache..");
			this.list_3 = new List<RoomData>();
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				for (int i = 0; i < 12; i++)
				{
					DataTable dataTable = @class.ReadDataTable("SELECT * FROM rooms WHERE category = '" + i + "' AND roomtype = 'private' ORDER BY users_now DESC LIMIT 40");
					foreach (DataRow dataRow in dataTable.Rows)
					{
						this.list_3.Add(this.method_17((uint)dataRow["id"], dataRow));
					}
				}
			}
			Logging.WriteLine("completed!");
		}
		private bool method_1(uint uint_0)
		{
			bool result;
			foreach (RoomData current in this.list_3)
			{
				if (current.Id == uint_0)
				{
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}
		internal void method_2(uint uint_0)
		{
			if (this.method_1(uint_0))
			{
				this.method_0();
			}
		}
		internal void method_3(string string_0, uint uint_0, uint uint_1, string string_1)
		{
		}
		internal void EmptyAllRooms()
		{
			using (Class26 class26_ = this.class25_0.Class26_0)
			{
				IEnumerator enumerator;
				using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
				{
					enumerator = class26_.Values.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							Room class2 = (Room)enumerator.Current;
							class2.method_65(@class);
						}
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
				if (Phoenix.GetConfig().data["emu.messages.roommgr"] == "1")
				{
					Console.WriteLine("[RoomMgr] Done with furniture saving, disposing rooms");
				}
				enumerator = class26_.Values.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Room class2 = (Room)enumerator.Current;
						try
						{
							class2.method_62();
						}
						catch
						{
						}
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
				if (Phoenix.GetConfig().data["emu.messages.roommgr"] == "1")
				{
					Console.WriteLine("[RoomMgr] Done disposing rooms!");
				}
			}
		}
		public void method_5(Teleport class109_0)
		{
			this.list_1.Add(class109_0);
		}
		public List<Room> method_6(int int_0)
		{
			List<Room> list = new List<Room>();
			try
			{
				using (Class26 class26_ = this.class25_0.Class26_0)
				{
					foreach (Room @class in class26_.Values)
					{
						if (@class.Event != null && (int_0 <= 0 || @class.Event.Category == int_0))
						{
							list.Add(@class);
						}
					}
				}
			}
			catch
			{
			}
			return list;
		}
		private void method_7()
		{
			Thread.Sleep(5000);
			while (true)
			{
				try
				{
					if (this.list_1.Count > 0)
					{
						DateTime now = DateTime.Now;
						try
						{
							try
							{
								this.dateTime_0 = DateTime.Now;
								List<Teleport> list = null;
								using (TimedLock.Lock(this.list_1))
								{
									list = this.list_1;
									this.list_1 = new List<Teleport>();
								}
								if (list != null)
								{
									foreach (Teleport current in list)
									{
										if (current != null)
										{
											current.method_0();
										}
									}
								}
							}
							catch (Exception ex)
							{
                                Logging.LogException("Tele code error: " + ex.ToString());
							}
							continue;
						}
						finally
						{
							DateTime now2 = DateTime.Now;
							double num = 500.0 - (now2 - now).TotalMilliseconds;
							if (num < 0.0)
							{
								num = 0.0;
							}
							if (num > 500.0)
							{
								num = 500.0;
							}
							Thread.Sleep((int)Math.Floor(num));
						}
					}
					Thread.Sleep(500);
				}
				catch (Exception ex)
				{
                    Logging.LogThreadException(ex.ToString(), "Room manager task (Process engine)");
					try
					{
						if (this.list_1 != null)
						{
							this.list_1.Clear();
						}
					}
					catch
					{
					}
					Thread.Sleep(500);
				}
			}
		}
		public void method_8(DatabaseClient class6_0)
		{
			Logging.Write("Loading Room Models..");
			this.Models.Clear();
			DataTable dataTable = class6_0.ReadDataTable("SELECT id,door_x,door_y,door_z,door_dir,heightmap,public_items,club_only FROM room_models");
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					string text = (string)dataRow["id"];
					this.Models.Add(text, new RoomModel(text, (int)dataRow["door_x"], (int)dataRow["door_y"], (double)dataRow["door_z"], (int)dataRow["door_dir"], (string)dataRow["heightmap"], (string)dataRow["public_items"], Phoenix.smethod_3(dataRow["club_only"].ToString())));
				}
				Logging.WriteLine("completed!");
			}
		}
		private RoomModel method_9(uint uint_0)
		{
			DataRow dataRow;
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				dataRow = @class.ReadDataRow("SELECT doorx,doory,height,modeldata FROM room_models_customs WHERE roomid = '" + uint_0 + "'");
			}
			return new RoomModel("custom", (int)dataRow["doorx"], (int)dataRow["doory"], (double)dataRow["height"], 2, (string)dataRow["modeldata"], "", false);
		}
		public RoomModel GetModel(string Model, uint uint_0)
		{
			RoomModel result;
			if (Model == "custom")
			{
				result = this.method_9(uint_0);
			}
			else
			{
				if (this.Models.ContainsKey(Model))
				{
					result = this.Models[Model];
				}
				else
				{
					result = null;
				}
			}
			return result;
		}
		public RoomData method_11(uint uint_0)
		{
			RoomData result;
			if (this.method_12(uint_0) != null)
			{
				result = this.method_12(uint_0);
			}
			else
			{
				RoomData @class = new RoomData();
				@class.FillNull(uint_0);
				result = @class;
			}
			return result;
		}
		public RoomData method_12(uint uint_0)
		{
			RoomData @class = new RoomData();
			RoomData result;
			lock (this.hashtable_0)
			{
				if (this.hashtable_0.ContainsKey(uint_0))
				{
					result = (this.hashtable_0[uint_0] as RoomData);
					return result;
				}
				if (this.method_13(uint_0))
				{
					result = this.GetRoom(uint_0).Class27_0;
					return result;
				}
				DataRow dataRow = null;
				using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
				{
					dataRow = class2.ReadDataRow("SELECT * FROM rooms WHERE id = '" + uint_0 + "' LIMIT 1");
				}
				if (dataRow == null)
				{
					result = null;
					return result;
				}
				@class.method_1(dataRow);
			}
			if (!this.hashtable_0.ContainsKey(uint_0))
			{
				this.hashtable_0.Add(uint_0, @class);
			}
			result = @class;
			return result;
		}
		public bool method_13(uint uint_0)
		{
			return this.class25_0.ContainsKey(uint_0);
		}
		public bool method_14(uint uint_0)
		{
			return this.list_0.Contains(uint_0);
		}
		internal Room method_15(uint uint_0)
		{
			Room @class = null;
			Room result;
			try
			{
				lock (this.MAX_PETS_PER_ROOM)
				{
					if (this.method_13(uint_0))
					{
						result = this.GetRoom(uint_0);
						return result;
					}
					RoomData class2 = this.method_12(uint_0);
					if (class2 == null)
					{
						result = null;
						return result;
					}
					@class = new Room(class2.Id, class2.Name, class2.Description, class2.Type, class2.Owner, class2.Category, class2.State, class2.UsersMax, class2.ModelName, class2.CCTs, class2.Score, class2.Tags, class2.AllowPet, class2.AllowPetsEating, class2.AllowWalkthrough, class2.Hidewall, class2.Icon, class2.Password, class2.Wallpaper, class2.Floor, class2.Landscape, class2, class2.bool_3, class2.Wallthick, class2.Floorthick, class2.Achievement);
					this.class25_0.Add(@class.Id, @class);
				}
			}
			catch
			{
				Logging.WriteLine("Error while loading room " + uint_0 + ", we crashed out..");
				result = null;
				return result;
			}
			@class.method_0();
			@class.method_1();
			result = @class;
			return result;
		}
		internal void method_16(Room class14_0)
		{
			if (class14_0 != null)
			{
				this.class25_0.Remove(class14_0.Id);
				this.method_18(class14_0.Id);
				class14_0.method_62();
				if (Phoenix.GetConfig().data["emu.messages.roommgr"] == "1")
				{
					Logging.WriteLine("[RoomMgr] Unloaded room [ID: " + class14_0.Id + "]");
				}
			}
		}
		public RoomData method_17(uint uint_0, DataRow dataRow_0)
		{
			RoomData result;
			if (this.hashtable_0.ContainsKey(uint_0))
			{
				result = (this.hashtable_0[uint_0] as RoomData);
			}
			else
			{
				RoomData @class = new RoomData();
				if (this.method_13(uint_0))
				{
					@class = this.GetRoom(uint_0).Class27_0;
				}
				else
				{
					@class.method_1(dataRow_0);
				}
				this.hashtable_0.Add(uint_0, @class);
				result = @class;
			}
			return result;
		}
		public void method_18(uint uint_0)
		{
			this.hashtable_0.Remove(uint_0);
		}
		public Room GetRoom(uint uint_0)
		{
			Room result;
			if (this.class25_0.ContainsKey(uint_0))
			{
				result = (this.class25_0[uint_0] as Room);
			}
			else
			{
				result = null;
			}
			return result;
		}
		public RoomData method_20(GameClient class16_0, string string_0, string string_1)
		{
			string_0 = Phoenix.smethod_7(string_0);
			RoomData result;
			if (!this.Models.ContainsKey(string_1))
			{
				class16_0.SendNotif("Sorry, this room model has not been added yet. Try again later.");
				result = null;
			}
			else
			{
				if (this.Models[string_1].bool_0 && !class16_0.GetHabbo().method_20().method_2("habbo_club") && !class16_0.GetHabbo().method_20().method_2("habbo_vip"))
				{
					class16_0.SendNotif("You must be an Phoenix Club member to use that room layout.");
					result = null;
				}
				else
				{
					if (string_0.Length < 3)
					{
						class16_0.SendNotif("Room name is too short for room creation!");
						result = null;
					}
					else
					{
						uint uint_ = 0u;
						using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
						{
							@class.AddParamWithValue("caption", string_0);
							@class.AddParamWithValue("model", string_1);
							@class.AddParamWithValue("username", class16_0.GetHabbo().Username);
							@class.ExecuteQuery("INSERT INTO rooms (roomtype,caption,owner,model_name) VALUES ('private',@caption,@username,@model)");
							class16_0.GetHabbo().Class12_0.DataTable_10 = @class.ReadDataTable("SELECT * FROM rooms WHERE owner = @username ORDER BY id ASC");
							uint_ = (uint)@class.ReadDataRow("SELECT id FROM rooms WHERE owner = @username AND caption = @caption ORDER BY id DESC")[0];
							class16_0.GetHabbo().method_1(@class);
						}
						result = this.method_12(uint_);
					}
				}
			}
			return result;
		}
		internal Dictionary<Room, int> method_21()
		{
			Dictionary<Room, int> dictionary = new Dictionary<Room, int>();
			using (Class26 class26_ = this.class25_0.Class26_0)
			{
				foreach (Room @class in class26_.Values)
				{
					if (@class != null && @class.Int32_0 > 0 && !@class.Boolean_3)
					{
						dictionary.Add(@class, @class.Int32_0);
					}
				}
			}
			return dictionary;
		}
		internal Dictionary<Room, int> method_22()
		{
			Dictionary<Room, int> dictionary = new Dictionary<Room, int>();
			using (Class26 class26_ = this.class25_0.Class26_0)
			{
				foreach (Room @class in class26_.Values)
				{
					if (@class != null)
					{
						dictionary.Add(@class, @class.Int32_0);
					}
				}
			}
			return dictionary;
		}
	}
}
