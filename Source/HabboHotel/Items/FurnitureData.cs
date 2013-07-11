using System;
using System.Collections.Generic;
namespace Phoenix.HabboHotel.Items
{
	internal sealed class FurnitureData
	{
		private uint uint_0;
		internal int int_0;
		internal string string_0;
		internal string string_1;
		internal char char_0;
		public int int_1;
		public int int_2;
		public double Height;
		public List<double> list_0;
		public bool bool_0;
		public bool bool_1;
		public bool bool_2;
		public bool bool_3;
		public bool bool_4;
		public bool bool_5;
		public bool bool_6;
		public bool bool_7;
		public string InteractionType;
		public byte byte_0;
		public byte byte_1;
		public List<int> list_1;
		public int int_3;
		public uint UInt32_0
		{
			get
			{
				return this.uint_0;
			}
		}
		public FurnitureData(uint uint_1, int int_4, string string_3, string string_4, string string_5, int int_5, int int_6, double double_1, bool bool_8, bool bool_9, bool bool_10, bool bool_11, bool bool_12, bool bool_13, bool bool_14, bool bool_15, string string_6, int int_7, string string_7, string string_8, byte byte_2, byte byte_3)
		{
			this.uint_0 = uint_1;
			this.int_0 = int_4;
			this.string_0 = string_3;
			this.string_1 = string_4;
			this.char_0 = char.Parse(string_5);
			this.int_1 = int_5;
			this.int_2 = int_6;
			this.Height = double_1;
			this.bool_0 = bool_8;
			this.bool_1 = bool_9;
			this.bool_2 = bool_10;
			this.bool_3 = bool_11;
			this.bool_4 = bool_12;
			this.bool_5 = bool_13;
			this.bool_6 = bool_14;
			this.bool_7 = bool_15;
			this.InteractionType = string_6;
			this.int_3 = int_7;
			this.list_1 = new List<int>();
			this.list_0 = new List<double>();
			this.byte_1 = byte_2;
			this.byte_0 = byte_3;
			string[] array = string_7.Split(new char[]
			{
				','
			});
			for (int i = 0; i < array.Length; i++)
			{
				string s = array[i];
				this.list_1.Add(int.Parse(s));
			}
			array = string_8.Split(new char[]
			{
				','
			});
			for (int i = 0; i < array.Length; i++)
			{
				string s2 = array[i];
				this.list_0.Add(double.Parse(s2));
			}
		}
	}
}
