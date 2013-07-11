using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Phoenix.Core;
using Phoenix.HabboHotel.Users.UserDataManagement;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Pets;
using Phoenix.HabboHotel.Items;
using Phoenix.Messages;
using Phoenix.Storage;
namespace Phoenix.HabboHotel.Users.Inventory
{
	internal sealed class UserInventory
	{
		public List<Class39> list_0;
		private Hashtable hashtable_0;
		private Hashtable hashtable_1;
		public List<uint> list_1;
		private GameClient class16_0;
		public uint uint_0;
		public int Int32_0
		{
			get
			{
				return this.list_0.Count;
			}
		}
		public int Int32_1
		{
			get
			{
				return this.hashtable_0.Count;
			}
		}
		public UserInventory(uint uint_1, GameClient class16_1, UserDataFactory class12_0)
		{
			this.class16_0 = class16_1;
			this.uint_0 = uint_1;
			this.list_0 = new List<Class39>();
			this.hashtable_0 = new Hashtable();
			this.hashtable_1 = new Hashtable();
			this.list_1 = new List<uint>();
			this.list_0.Clear();
			DataTable dataTable_ = class12_0.DataTable_6;
			foreach (DataRow dataRow in dataTable_.Rows)
			{
				this.list_0.Add(new Class39((uint)dataRow["id"], (uint)dataRow["base_item"], (string)dataRow["extra_data"]));
			}
			this.hashtable_0.Clear();
			DataTable dataTable_2 = class12_0.DataTable_11;
			foreach (DataRow dataRow in dataTable_2.Rows)
			{
				Pet @class = Phoenix.GetGame().GetCatalog().method_12(dataRow);
				this.hashtable_0.Add(@class.PetId, @class);
			}
		}
		public void EmptyInventory()
		{
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				@class.ExecuteQuery("DELETE FROM items WHERE room_id = 0 AND user_id = '" + this.uint_0 + "';");
			}
			this.hashtable_1.Clear();
			this.list_1.Clear();
			this.list_0.Clear();
			ServerMessage gclass5_ = new ServerMessage(101u);
			this.method_16().method_14(gclass5_);
		}
		public void method_1(GameClient class16_1)
		{
			int num = 0;
			List<Class39> list = new List<Class39>();
			foreach (Class39 current in this.list_0)
			{
				if (current != null && (current.method_1().string_1.StartsWith("CF_") || current.method_1().string_1.StartsWith("CFC_")))
				{
					string[] array = current.method_1().string_1.Split(new char[]
					{
						'_'
					});
					int num2 = int.Parse(array[1]);
					if (!this.list_1.Contains(current.uint_0))
					{
						if (num2 > 0)
						{
							num += num2;
						}
						list.Add(current);
					}
				}
			}
			foreach (Class39 current in list)
			{
				this.method_12(current.uint_0, 0u, false);
			}
			class16_1.GetHabbo().Credits += num;
			class16_1.GetHabbo().method_13(true);
			class16_1.SendNotif("All coins in your inventory have been converted back into " + num + " credits!");
		}
		public void method_2()
		{
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				@class.ExecuteQuery("DELETE FROM user_pets WHERE user_id = " + this.uint_0 + " AND room_id = 0;");
			}
			foreach (Pet class2 in this.hashtable_0.Values)
			{
				ServerMessage gClass = new ServerMessage(604u);
				gClass.AppendUInt(class2.PetId);
				this.method_16().method_14(gClass);
			}
			this.hashtable_0.Clear();
		}
		public void method_3(bool bool_0)
		{
			if (bool_0)
			{
				this.method_8();
			}
			this.method_16().method_14(this.method_15());
		}
		public Pet method_4(uint uint_1)
		{
			return this.hashtable_0[uint_1] as Pet;
		}
		public bool method_5(uint uint_1)
		{
			ServerMessage gClass = new ServerMessage(604u);
			gClass.AppendUInt(uint_1);
			this.method_16().method_14(gClass);
			this.hashtable_0.Remove(uint_1);
			return true;
		}
		public void method_6(uint uint_1, uint uint_2)
		{
			this.method_5(uint_1);
		}
		public void method_7(Pet class15_0)
		{
			try
			{
				if (class15_0 != null)
				{
					class15_0.PlacedInRoom = false;
					if (!this.hashtable_0.ContainsKey(class15_0.PetId))
					{
						this.hashtable_0.Add(class15_0.PetId, class15_0);
					}
					ServerMessage gclass5_ = new ServerMessage(603u);
					class15_0.SerializeInventory(gclass5_);
					this.method_16().method_14(gclass5_);
				}
			}
			catch
			{
			}
		}
		public void method_8()
		{
			using (TimedLock.Lock(this.list_0))
			{
				this.list_0.Clear();
				this.hashtable_1.Clear();
				this.list_1.Clear();
				DataTable dataTable;
				using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
				{
					dataTable = @class.ReadDataTable("SELECT id,base_item,extra_data,user_id FROM items WHERE room_id = 0 AND user_id = " + this.uint_0);
				}
				if (dataTable != null)
				{
					foreach (DataRow dataRow in dataTable.Rows)
					{
						this.list_0.Add(new Class39((uint)dataRow["id"], (uint)dataRow["base_item"], (string)dataRow["extra_data"]));
					}
				}
				using (TimedLock.Lock(this.hashtable_0))
				{
					this.hashtable_0.Clear();
					DataTable dataTable2;
					using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
					{
						@class.AddParamWithValue("userid", this.uint_0);
						dataTable2 = @class.ReadDataTable("SELECT id, user_id, room_id, name, type, race, color, expirience, energy, nutrition, respect, createstamp, x, y, z FROM user_pets WHERE user_id = @userid AND room_id <= 0");
					}
					if (dataTable2 != null)
					{
						foreach (DataRow dataRow in dataTable2.Rows)
						{
							Pet class2 = Phoenix.GetGame().GetCatalog().method_12(dataRow);
							this.hashtable_0.Add(class2.PetId, class2);
						}
					}
				}
			}
		}
		public void method_9(bool bool_0)
		{
			if (bool_0)
			{
				this.method_8();
				this.method_18();
			}
			if (this.method_16() != null)
			{
				this.method_16().method_14(new ServerMessage(101u));
			}
		}
		public Class39 method_10(uint uint_1)
		{
			List<Class39>.Enumerator enumerator = this.list_0.GetEnumerator();
			Class39 result;
			while (enumerator.MoveNext())
			{
				Class39 current = enumerator.Current;
				if (current.uint_0 == uint_1)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}
		public void method_11(uint uint_1, uint uint_2, string string_0, bool bool_0)
		{
			Class39 item = new Class39(uint_1, uint_2, string_0);
			this.list_0.Add(item);
			if (this.list_1.Contains(uint_1))
			{
				this.list_1.Remove(uint_1);
			}
			if (!this.hashtable_1.ContainsKey(uint_1))
			{
				if (bool_0)
				{
					using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
					{
						@class.AddParamWithValue("extra_data", string_0);
						@class.ExecuteQuery(string.Concat(new object[]
						{
							"INSERT INTO items (id,user_id,base_item,extra_data,wall_pos) VALUES ('",
							uint_1,
							"','",
							this.uint_0,
							"','",
							uint_2,
							"',@extra_data, '')"
						}));
						return;
					}
				}
				using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
				{
					@class.ExecuteQuery(string.Concat(new object[]
					{
						"UPDATE items SET room_id = 0, user_id = '",
						this.uint_0,
						"' WHERE id = '",
						uint_1,
						"'"
					}));
				}
			}
		}
		public void method_12(uint uint_1, uint uint_2, bool bool_0)
		{
			ServerMessage gClass = new ServerMessage(99u);
			gClass.AppendUInt(uint_1);
			this.method_16().method_14(gClass);
			if (this.hashtable_1.ContainsKey(uint_1))
			{
				this.hashtable_1.Remove(uint_1);
			}
			if (!this.list_1.Contains(uint_1))
			{
				this.list_0.Remove(this.method_10(uint_1));
				this.list_1.Add(uint_1);
				if (bool_0)
				{
					using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
					{
						@class.ExecuteQuery(string.Concat(new object[]
						{
							"UPDATE items SET user_id = '",
							uint_2,
							"' WHERE id = '",
							uint_1,
							"' LIMIT 1"
						}));
						return;
					}
				}
				if (uint_2 == 0u && !bool_0)
				{
					using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
					{
						@class.ExecuteQuery("DELETE FROM items WHERE id = '" + uint_1 + "' LIMIT 1");
					}
				}
			}
		}
		public ServerMessage method_13()
		{
			ServerMessage gClass = new ServerMessage(140u);
			gClass.AppendStringWithBreak("S");
			gClass.AppendInt32(1);
			gClass.AppendInt32(1);
			gClass.AppendInt32(this.Int32_0);
			List<Class39>.Enumerator enumerator = this.list_0.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.method_0(gClass, true);
			}
			return gClass;
		}
		public ServerMessage method_14()
		{
			ServerMessage gClass = new ServerMessage(140u);
			gClass.AppendStringWithBreak("I");
			gClass.AppendString("II");
			gClass.AppendInt32(0);
			return gClass;
		}
		public ServerMessage method_15()
		{
			ServerMessage gClass = new ServerMessage(600u);
			gClass.AppendInt32(this.hashtable_0.Count);
			foreach (Pet @class in this.hashtable_0.Values)
			{
				@class.SerializeInventory(gClass);
			}
			return gClass;
		}
		private GameClient method_16()
		{
			return Phoenix.GetGame().GetClientManager().method_2(this.uint_0);
		}
		public void method_17(List<UserItemData> list_2)
		{
			foreach (UserItemData current in list_2)
			{
				this.method_11(current.uint_0, current.uint_2, current.string_0, false);
			}
		}
		internal void method_18()
		{
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				this.method_19(@class, false);
			}
		}
		internal void method_19(DatabaseClient class6_0, bool bool_0)
		{
			try
			{
				if (this.list_1.Count > 0 || this.hashtable_1.Count > 0 || this.hashtable_0.Count > 0)
				{
					StringBuilder stringBuilder = new StringBuilder();
					foreach (Pet @class in this.hashtable_0.Values)
					{
						if (@class.DBState == DatabaseUpdateState.NeedsInsert)
						{
							class6_0.AddParamWithValue("petname" + @class.PetId, @class.Name);
							class6_0.AddParamWithValue("petcolor" + @class.PetId, @class.Color);
							class6_0.AddParamWithValue("petrace" + @class.PetId, @class.Race);
							stringBuilder.Append(string.Concat(new object[]
							{
								"INSERT INTO `user_pets` VALUES ('",
								@class.PetId,
								"', '",
								@class.OwnerId,
								"', '",
								@class.RoomId,
								"', @petname",
								@class.PetId,
								", @petrace",
								@class.PetId,
								", @petcolor",
								@class.PetId,
								", '",
								@class.Type,
								"', '",
								@class.Expirience,
								"', '",
								@class.Energy,
								"', '",
								@class.Nutrition,
								"', '",
								@class.Respect,
								"', '",
								@class.CreationStamp,
								"', '",
								@class.X,
								"', '",
								@class.Y,
								"', '",
								@class.Z,
								"');"
							}));
						}
						else
						{
							if (@class.DBState == DatabaseUpdateState.NeedsUpdate)
							{
								stringBuilder.Append(string.Concat(new object[]
								{
									"UPDATE user_pets SET room_id = '",
									@class.RoomId,
									"', expirience = '",
									@class.Expirience,
									"', energy = '",
									@class.Energy,
									"', nutrition = '",
									@class.Nutrition,
									"', respect = '",
									@class.Respect,
									"', x = '",
									@class.X,
									"', y = '",
									@class.Y,
									"', z = '",
									@class.Z,
									"' WHERE id = '",
									@class.PetId,
									"' LIMIT 1; "
								}));
							}
						}
						@class.DBState = DatabaseUpdateState.Updated;
					}
					if (stringBuilder.Length > 0)
					{
						class6_0.ExecuteQuery(stringBuilder.ToString());
					}
				}
				if (bool_0)
				{
					Console.WriteLine("Inventory for user: " + this.method_16().GetHabbo().Username + " saved.");
				}
			}
			catch (Exception ex)
			{
                Logging.LogCacheError("FATAL ERROR DURING DB UPDATE: " + ex.ToString());
			}
		}
	}
}
