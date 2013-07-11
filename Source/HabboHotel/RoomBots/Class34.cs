using System;
using System.Collections.Generic;
using Phoenix.HabboHotel.RoomBots;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.HabboHotel.RoomBots
{
	internal sealed class Class34
	{
		public uint uint_0;
		public uint uint_1;
		public Enum2 enum2_0;
		public string string_0;
		public string string_1;
		public string string_2;
		public string string_3;
		public int int_0;
		public bool bool_0;
		public int int_1;
		public int int_2;
		public double double_0;
		public int int_3;
		public int int_4;
		public int int_5;
		public int int_6;
		public int int_7;
		public List<Class36> list_0;
		public List<Class35> list_1;
		public Class33 class33_0;
		public bool Boolean_0
		{
			get
			{
				return this.enum2_0 == Enum2.const_0;
			}
		}
		public bool Boolean_1
		{
			get
			{
				return this.enum2_0 == Enum2.const_3;
			}
		}
		public Class34(uint uint_2, uint uint_3, Enum2 enum2_1, string string_4, string string_5, string string_6, string string_7, int int_8, int int_9, int int_10, int int_11, int int_12, int int_13, int int_14, int int_15, ref List<Class36> list_2, ref List<Class35> list_3, int int_16)
		{
			this.uint_0 = uint_2;
			this.uint_1 = uint_3;
			this.enum2_0 = enum2_1;
			this.string_0 = string_4;
			this.string_1 = string_5;
			this.string_2 = string_6;
			this.string_3 = string_7;
			this.int_1 = int_8;
			this.int_2 = int_9;
			this.double_0 = (double)int_10;
			this.int_3 = int_11;
			this.int_4 = int_12;
			this.int_6 = int_13;
			this.int_5 = int_14;
			this.int_7 = int_15;
			this.int_0 = int_16;
			this.bool_0 = true;
			this.class33_0 = null;
			this.method_0(list_2);
			this.method_1(list_3);
		}
		public void method_0(List<Class36> list_2)
		{
			this.list_0 = new List<Class36>();
			foreach (Class36 current in list_2)
			{
				if (current.uint_0 == this.uint_0)
				{
					this.list_0.Add(current);
				}
			}
		}
		public void method_1(List<Class35> list_2)
		{
			this.list_1 = new List<Class35>();
			foreach (Class35 current in list_2)
			{
				if (current.uint_1 == this.uint_0)
				{
					this.list_1.Add(current);
				}
			}
		}
		public Class35 method_2(string string_4)
		{
			using (TimedLock.Lock(this.list_1))
			{
				foreach (Class35 current in this.list_1)
				{
					if (current.method_0(string_4))
					{
						return current;
					}
				}
			}
			return null;
		}
		public Class36 method_3()
		{
			return this.list_0[Phoenix.smethod_5(0, this.list_0.Count - 1)];
		}
		public Class99 method_4(int int_8)
		{
			switch (this.enum2_0)
			{
			case Enum2.const_0:
				return new Class103(int_8);
			case Enum2.const_1:
				return new Class102();
			case Enum2.const_3:
				return new Class100(int_8);
			}
			return new Class101(int_8);
		}
	}
}
