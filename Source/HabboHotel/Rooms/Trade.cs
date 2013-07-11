using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Phoenix.Core;
using Phoenix.HabboHotel.Items;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Storage;
namespace Phoenix.HabboHotel.Rooms
{
	internal sealed class Trade
	{
		private Class65[] class65_0;
		private int int_0;
		private uint uint_0;
		private uint uint_1;
		private uint uint_2;
		public bool Boolean_0
		{
			get
			{
				bool result;
				for (int i = 0; i < this.class65_0.Length; i++)
				{
					if (this.class65_0[i] != null && !this.class65_0[i].Boolean_0)
					{
						result = false;
						return result;
					}
				}
				result = true;
				return result;
			}
		}
		public Trade(uint uint_3, uint uint_4, uint uint_5)
		{
			this.uint_1 = uint_3;
			this.uint_2 = uint_4;
			this.class65_0 = new Class65[2];
			this.class65_0[0] = new Class65(uint_3, uint_5);
			this.class65_0[1] = new Class65(uint_4, uint_5);
			this.int_0 = 1;
			this.uint_0 = uint_5;
			Class65[] array = this.class65_0;
			for (int i = 0; i < array.Length; i++)
			{
				Class65 @class = array[i];
				if (!@class.method_0().Statusses.ContainsKey("trd"))
				{
					@class.method_0().method_11("trd", "");
					@class.method_0().bool_7 = true;
				}
			}
			ServerMessage gClass = new ServerMessage(104u);
			gClass.AppendUInt(uint_3);
			gClass.AppendBoolean(true);
			gClass.AppendUInt(uint_4);
			gClass.AppendBoolean(true);
			this.method_13(gClass);
		}
		public bool method_0(uint uint_3)
		{
			bool result;
			for (int i = 0; i < this.class65_0.Length; i++)
			{
				if (this.class65_0[i] != null && this.class65_0[i].uint_0 == uint_3)
				{
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}
		public Class65 method_1(uint uint_3)
		{
			Class65 result;
			for (int i = 0; i < this.class65_0.Length; i++)
			{
				if (this.class65_0[i] != null && this.class65_0[i].uint_0 == uint_3)
				{
					result = this.class65_0[i];
					return result;
				}
			}
			result = null;
			return result;
		}
		public void method_2(uint uint_3, Class39 class39_0)
		{
			Class65 @class = this.method_1(uint_3);
			if (@class != null && class39_0 != null && class39_0.method_1().bool_4 && !@class.Boolean_0 && this.int_0 == 1)
			{
				this.method_8();
				@class.list_0.Add(class39_0);
				this.method_9();
			}
		}
		public void method_3(uint uint_3, Class39 class39_0)
		{
			Class65 @class = this.method_1(uint_3);
			if (@class != null && class39_0 != null && !@class.Boolean_0 && this.int_0 == 1)
			{
				this.method_8();
				@class.list_0.Remove(class39_0);
				this.method_9();
			}
		}
		public void method_4(uint uint_3)
		{
			Class65 @class = this.method_1(uint_3);
			if (@class != null && this.int_0 == 1)
			{
				@class.Boolean_0 = true;
				ServerMessage gClass = new ServerMessage(109u);
				gClass.AppendUInt(uint_3);
				gClass.AppendBoolean(true);
				this.method_13(gClass);
				if (this.Boolean_0)
				{
					this.method_13(new ServerMessage(111u));
					this.int_0++;
					this.method_8();
				}
			}
		}
		public void method_5(uint uint_3)
		{
			Class65 @class = this.method_1(uint_3);
			if (@class != null && this.int_0 == 1 && !this.Boolean_0)
			{
				@class.Boolean_0 = false;
				ServerMessage gClass = new ServerMessage(109u);
				gClass.AppendUInt(uint_3);
				gClass.AppendBoolean(false);
				this.method_13(gClass);
			}
		}
		public void method_6(uint uint_3)
		{
			Class65 @class = this.method_1(uint_3);
			if (@class != null && this.int_0 == 2)
			{
				@class.Boolean_0 = true;
				ServerMessage gClass = new ServerMessage(109u);
				gClass.AppendUInt(uint_3);
				gClass.AppendBoolean(true);
				this.method_13(gClass);
				if (this.Boolean_0)
				{
					this.int_0 = 999;
					Task task = new Task(new Action(this.method_7));
					task.Start();
				}
			}
		}
		private void method_7()
		{
			try
			{
				this.method_10();
				this.method_11();
			}
			catch (Exception ex)
			{
                Logging.LogThreadException(ex.ToString(), "Trade task");
			}
		}
		public void method_8()
		{
			using (TimedLock.Lock(this.class65_0))
			{
				Class65[] array = this.class65_0;
				for (int i = 0; i < array.Length; i++)
				{
					Class65 @class = array[i];
					@class.Boolean_0 = false;
				}
			}
		}
		public void method_9()
		{
			ServerMessage gClass = new ServerMessage(108u);
			using (TimedLock.Lock(this.class65_0))
			{
				for (int i = 0; i < this.class65_0.Length; i++)
				{
					Class65 @class = this.class65_0[i];
					if (@class != null)
					{
						gClass.AppendUInt(@class.uint_0);
						gClass.AppendInt32(@class.list_0.Count);
						using (TimedLock.Lock(@class.list_0))
						{
							foreach (Class39 current in @class.list_0)
							{
								gClass.AppendUInt(current.uint_0);
								gClass.AppendStringWithBreak(current.method_1().char_0.ToString().ToLower());
								gClass.AppendUInt(current.uint_0);
								gClass.AppendInt32(current.method_1().int_0);
								gClass.AppendBoolean(true);
								gClass.AppendBoolean(true);
								gClass.AppendStringWithBreak("");
								gClass.AppendBoolean(false);
								gClass.AppendBoolean(false);
								gClass.AppendBoolean(false);
								if (current.method_1().char_0 == 's')
								{
									gClass.AppendInt32(-1);
								}
							}
						}
					}
				}
			}
			this.method_13(gClass);
		}
		public void method_10()
		{
			List<Class39> list_ = this.method_1(this.uint_1).list_0;
			List<Class39> list_2 = this.method_1(this.uint_2).list_0;
			foreach (Class39 current in list_)
			{
				if (this.method_1(this.uint_1).method_1().GetHabbo().method_23().method_10(current.uint_0) == null)
				{
					this.method_1(this.uint_1).method_1().SendNotif("Trade failed.");
					this.method_1(this.uint_2).method_1().SendNotif("Trade failed.");
					return;
				}
			}
			foreach (Class39 current in list_2)
			{
				if (this.method_1(this.uint_2).method_1().GetHabbo().method_23().method_10(current.uint_0) == null)
				{
					this.method_1(this.uint_1).method_1().SendNotif("Trade failed.");
					this.method_1(this.uint_2).method_1().SendNotif("Trade failed.");
					return;
				}
			}
			this.method_1(this.uint_2).method_1().GetHabbo().method_23().method_18();
			this.method_1(this.uint_1).method_1().GetHabbo().method_23().method_18();
			foreach (Class39 current in list_)
			{
				using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
				{
					@class.ExecuteQuery(string.Concat(new object[]
					{
						"UPDATE items SET room_id = '0', user_id = '",
						this.method_1(this.uint_2).method_1().GetHabbo().Id,
						"' WHERE id = '",
						current.uint_0,
						"' LIMIT 1"
					}));
				}
				this.method_1(this.uint_1).method_1().GetHabbo().method_23().method_12(current.uint_0, this.method_1(this.uint_2).method_1().GetHabbo().Id, true);
				this.method_1(this.uint_2).method_1().GetHabbo().method_23().method_11(current.uint_0, current.uint_1, current.string_0, false);
			}
			foreach (Class39 current in list_2)
			{
				using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
				{
					@class.ExecuteQuery(string.Concat(new object[]
					{
						"UPDATE items SET room_id = '0', user_id = '",
						this.method_1(this.uint_1).method_1().GetHabbo().Id,
						"' WHERE id = '",
						current.uint_0,
						"' LIMIT 1"
					}));
				}
				this.method_1(this.uint_2).method_1().GetHabbo().method_23().method_12(current.uint_0, this.method_1(this.uint_1).method_1().GetHabbo().Id, true);
				this.method_1(this.uint_1).method_1().GetHabbo().method_23().method_11(current.uint_0, current.uint_1, current.string_0, false);
			}
			this.method_1(this.uint_1).method_1().GetHabbo().method_23().method_9(true);
			this.method_1(this.uint_2).method_1().GetHabbo().method_23().method_9(true);

		}
		public void method_11()
		{
			for (int i = 0; i < this.class65_0.Length; i++)
			{
				Class65 @class = this.class65_0[i];
				if (@class != null && @class.method_0() != null)
				{
					@class.method_0().method_12("trd");
					@class.method_0().bool_7 = true;
				}
			}
			this.method_13(new ServerMessage(112u));
			this.method_14().list_2.Remove(this);
		}
		public void method_12(uint uint_3)
		{
			for (int i = 0; i < this.class65_0.Length; i++)
			{
				Class65 @class = this.class65_0[i];
				if (@class != null && @class.method_0() != null)
				{
					@class.method_0().method_12("trd");
					@class.method_0().bool_7 = true;
				}
			}
			ServerMessage gClass = new ServerMessage(110u);
			gClass.AppendUInt(uint_3);
			this.method_13(gClass);
		}
		public void method_13(ServerMessage gclass5_0)
		{
			if (this.class65_0 != null)
			{
				for (int i = 0; i < this.class65_0.Length; i++)
				{
					Class65 @class = this.class65_0[i];
					if (@class != null && @class != null && @class.method_1() != null)
					{
						@class.method_1().method_14(gclass5_0);
					}
				}
			}
		}
		private Room method_14()
		{
			return Phoenix.GetGame().GetRoomManager().GetRoom(this.uint_0);
		}
	}
}
