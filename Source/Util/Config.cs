using System;
using System.Security.Cryptography;
using System.Text;
namespace Phoenix.Util
{
	internal static class Config
	{
		public const string string_0 = "a";
		public const string string_1 = "b";
		public const string string_2 = "c";
		public const string string_3 = "d";
		public const string string_4 = "e";
		public const string string_5 = "f";
		public const string string_6 = "g";
		public const string string_7 = "h";
		public const string string_8 = "i";
		public const string string_9 = "j";
		public const string string_10 = "k";
		public const string string_11 = "l";
		public const string string_12 = "m";
		public const string string_13 = "n";
		public const string string_14 = "o";
		public const string string_15 = "p";
		public const string string_16 = "q";
		public const string string_17 = "r";
		public const string string_18 = "s";
		public const string string_19 = "t";
		public const string string_20 = "u";
		public const string string_21 = "v";
		public const string string_22 = "w";
		public const string string_23 = "x";
		public const string string_24 = "y";
		public const string string_25 = "z";
		public static int int_0;
		public static int int_1;
		public static int int_2;
		public static bool AntiDDoSOff;
		public static int int_3;
		public static int int_4;
		public static int int_5;
		private static string string_26 = "";
		private static string string_27 = "";
		private static int int_6 = -1;
		private static int int_7 = 15;
		private static int int_8 = 75;
		private static int int_9 = 15;
		private static int int_10 = 0;
		private static bool bool_1 = true;
		private static bool bool_2 = true;
		private static bool bool_3 = true;
		private static bool bool_4 = true;
		private static bool bool_5 = true;
		private static int int_11 = 50;
		private static string string_28 = "disabled";
		private static bool bool_6 = true;
		private static bool bool_7 = false;
		private static bool bool_8 = false;
		private static bool bool_9 = false;
		private static bool bool_10 = false;
		private static bool bool_11 = false;
		private static bool bool_12 = false;
		private static bool bool_13 = false;
		private static string string_29 = "D93196DD0B540C93941AFB3FD1D7E7C3";
		private static string string_30 = "";
		//private static string string_31 = "";
		//private static string string_32 = "";
		private static bool bool_14 = false;
		public static bool bool_15 = false;
		//public static bool bool_16 = false;
		//public static string string_33 = "";
		public static int GamePort = 0;
		public static int MusPort = 0;
		public static bool bool_17 = false;
		public static bool bool_18 = true;
		public static bool bool_19 = true;
		public static int int_14 = 300;
		public static int int_15 = 1200;
		public static bool bool_20 = false;
		public static bool Boolean_0
		{
			get
			{
				return Config.bool_14;
			}
			set
			{
				Config.bool_14 = value;
			}
		}
		/*public static string String_0
		{
			get
			{
				return Class13.string_31;
			}
			set
			{
				Class13.string_31 = GClass8.smethod_0(value);
			}
		}*/
		/*public static string String_1
		{
			get
			{
				return Class13.string_32;
			}
			set
			{
				Class13.string_32 = value;
				Class13.String_0 = value;
			}
		}*/
		public static bool Boolean_1
		{
			get
			{
				return Config.bool_5;
			}
			set
			{
				Config.bool_5 = value;
			}
		}
		public static bool Boolean_2
		{
			get
			{
				return Config.bool_6;
			}
			set
			{
				Config.bool_6 = value;
			}
		}
		public static string String_2
		{
			get
			{
				return Config.string_28;
			}
			set
			{
				Config.string_28 = value;
			}
		}
		public static string String_3
		{
			get
			{
				return Config.string_30;
			}
			set
			{
				Config.string_30 = value;
			}
		}
		public static string String_4
		{
			get
			{
				return Config.string_26;
			}
			set
			{
				Config.string_26 = value.Replace("\\n", "\n");
			}
		}
		public static string String_5
		{
			get
			{
				return Config.string_29;
			}
			set
			{
				Config.string_29 = Config.MD5(Config.string_29 + value);
			}
		}
		public static bool Boolean_3
		{
			get
			{
				return Config.bool_4;
			}
			set
			{
				Config.bool_4 = value;
			}
		}
		public static bool Boolean_4
		{
			get
			{
				return Config.bool_1;
			}
			set
			{
				Config.bool_1 = value;
			}
		}
		public static bool Boolean_5
		{
			get
			{
				return Config.bool_2;
			}
			set
			{
				Config.bool_2 = value;
			}
		}
		public static bool Boolean_6
		{
			get
			{
				return Config.bool_3;
			}
			set
			{
				Config.bool_3 = value;
			}
		}
		public static int Int32_0
		{
			get
			{
				return Config.int_7;
			}
			set
			{
				Config.int_7 = value;
			}
		}
		public static int Int32_1
		{
			get
			{
				return Config.int_8;
			}
			set
			{
				Config.int_8 = value;
			}
		}
		public static int Int32_2
		{
			get
			{
				return Config.int_10;
			}
			set
			{
				Config.int_10 = value;
			}
		}
		public static int Int32_3
		{
			get
			{
				return Config.int_9;
			}
			set
			{
				Config.int_9 = value;
			}
		}
		public static int Int32_4
		{
			get
			{
				return Config.int_11;
			}
			set
			{
				Config.int_11 = value;
			}
		}
		public static string String_6
		{
			get
			{
				return Config.string_27;
			}
			set
			{
				Config.string_27 = value;
			}
		}
		public static int Int32_5
		{
			get
			{
				return Config.int_6;
			}
			set
			{
				Config.int_6 = value;
			}
		}
		public static bool Boolean_7
		{
			get
			{
				return Config.bool_7;
			}
			set
			{
				if (!Config.bool_7 && !Config.Boolean_7)
				{
					Config.bool_7 = value;
				}
				else
				{
					Config.bool_7 = false;
				}
			}
		}
		public static bool Boolean_8
		{
			get
			{
				return Config.bool_8;
			}
			set
			{
				Config.bool_8 = value;
			}
		}
		public static bool Boolean_9
		{
			get
			{
				return Config.bool_13;
			}
			set
			{
				Config.bool_13 = value;
			}
		}
		public static bool Boolean_10
		{
			get
			{
				return Config.bool_9;
			}
			set
			{
				Config.bool_9 = value;
			}
		}
		public static bool Boolean_11
		{
			get
			{
				return Config.bool_10;
			}
			set
			{
				Config.bool_10 = value;
			}
		}
		public static bool Boolean_12
		{
			get
			{
				return Config.bool_11;
			}
			set
			{
				Config.bool_11 = value;
			}
		}
		public static bool Boolean_13
		{
			get
			{
				return Config.bool_12;
			}
			set
			{
				Config.bool_12 = value;
			}
		}
		public static string MD5(string string_34)
		{
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] array = Encoding.UTF8.GetBytes(string_34);
			array = mD5CryptoServiceProvider.ComputeHash(array);
			StringBuilder stringBuilder = new StringBuilder();
			byte[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				byte b = array2[i];
				stringBuilder.Append(b.ToString("x2").ToLower());
			}
			string text = stringBuilder.ToString();
			return text.ToUpper();
		}
		public static string SHA1(string string_34)
		{
			byte[] bytes = Encoding.ASCII.GetBytes(string_34);
			byte[] array = new SHA1Managed().ComputeHash(bytes);
			string text = string.Empty;
			byte[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				byte b = array2[i];
				text += b.ToString("X2");
			}
			return text;
		}
		private static string smethod_2(string string_34)
		{
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] bytes = Encoding.ASCII.GetBytes(string_34);
			return BitConverter.ToString(mD5CryptoServiceProvider.ComputeHash(bytes)).Replace("-", "").ToLower();
		}
	}
}
