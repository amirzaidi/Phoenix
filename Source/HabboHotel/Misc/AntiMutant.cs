using System;
using System.Text.RegularExpressions;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.HabboHotel.Misc
{
	internal sealed class AntiMutant
	{
		public static bool smethod_0(string string_0, string string_1)
		{
			bool flag = false;
			if (string_0.Length < 1)
			{
				return false;
			}
			else
			{
				try
				{
					string[] array = string_0.Split(new char[]
					{
						'.'
					});
					if (array.Length < 4)
					{
                        return false;
					}
					string[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						string text = array2[i];
						string[] array3 = text.Split(new char[]
						{
							'-'
						});
						if (array3.Length < 3)
						{
                            return false;
						}
						string text2 = array3[0];
						int num = int.Parse(array3[1]);
						int num2 = int.Parse(array3[1]);
						if (num <= 0 || num2 < 0)
						{
                            return false;
						}
						if (text2.Length != 2)
						{
							return false;
						}
						if (text2 == "hd")
						{
							flag = true;
						}
					}
				}
				catch (Exception)
				{
					return false;
				}
				return (flag && (!(string_1 != "M") || !(string_1 != "F")) && Phoenix.int_1 != 0);
			}
		}
		public static void smethod_1(Class33 class33_0, string string_0)
		{
			if (string_0.Contains("hr-"))
			{
				string text = Regex.Split(string_0, "hr-")[1];
				text = "hr-" + text.Split(new char[]
				{
					'.'
				})[0];
				int num = class33_0.method_16().GetHabbo().string_5.IndexOf("hr-");
				if (num == -1)
				{
					class33_0.method_16().GetHabbo().string_5 = class33_0.method_16().GetHabbo().string_5 + text;
				}
				else
				{
					string text2 = Regex.Split(class33_0.method_16().GetHabbo().string_5, "hr-")[1];
					text2 = "hr-" + text2.Split(new char[]
					{
						'.'
					})[0];
					class33_0.method_16().GetHabbo().string_5 = class33_0.method_16().GetHabbo().string_5.Replace(text2, text);
				}
			}
			if (string_0.Contains("hd-"))
			{
				string text = Regex.Split(string_0, "hd-")[1];
				text = "hd-" + text.Split(new char[]
				{
					'.'
				})[0];
				int num = class33_0.method_16().GetHabbo().string_5.IndexOf("hd-");
				if (num == -1)
				{
					class33_0.method_16().GetHabbo().string_5 = class33_0.method_16().GetHabbo().string_5 + text;
				}
				else
				{
					string text2 = Regex.Split(class33_0.method_16().GetHabbo().string_5, "hd-")[1];
					text2 = "hd-" + text2.Split(new char[]
					{
						'.'
					})[0];
					class33_0.method_16().GetHabbo().string_5 = class33_0.method_16().GetHabbo().string_5.Replace(text2, text);
				}
			}
			if (string_0.Contains("ch-"))
			{
				string text = Regex.Split(string_0, "ch-")[1];
				text = "ch-" + text.Split(new char[]
				{
					'.'
				})[0];
				int num = class33_0.method_16().GetHabbo().string_5.IndexOf("ch-");
				if (num == -1)
				{
					class33_0.method_16().GetHabbo().string_5 = class33_0.method_16().GetHabbo().string_5 + text;
				}
				else
				{
					string text2 = Regex.Split(class33_0.method_16().GetHabbo().string_5, "ch-")[1];
					text2 = "ch-" + text2.Split(new char[]
					{
						'.'
					})[0];
					class33_0.method_16().GetHabbo().string_5 = class33_0.method_16().GetHabbo().string_5.Replace(text2, text);
				}
			}
			if (string_0.Contains("lg-"))
			{
				string text = Regex.Split(string_0, "lg-")[1];
				text = "lg-" + text.Split(new char[]
				{
					'.'
				})[0];
				int num = class33_0.method_16().GetHabbo().string_5.IndexOf("lg-");
				if (num == -1)
				{
					class33_0.method_16().GetHabbo().string_5 = class33_0.method_16().GetHabbo().string_5 + text;
				}
				else
				{
					string text2 = Regex.Split(class33_0.method_16().GetHabbo().string_5, "lg-")[1];
					text2 = "lg-" + text2.Split(new char[]
					{
						'.'
					})[0];
					class33_0.method_16().GetHabbo().string_5 = class33_0.method_16().GetHabbo().string_5.Replace(text2, text);
				}
			}
			if (string_0.Contains("sh-"))
			{
				string text = Regex.Split(string_0, "sh-")[1];
				text = "sh-" + text.Split(new char[]
				{
					'.'
				})[0];
				int num = class33_0.method_16().GetHabbo().string_5.IndexOf("sh-");
				if (num == -1)
				{
					class33_0.method_16().GetHabbo().string_5 = class33_0.method_16().GetHabbo().string_5 + text;
				}
				else
				{
					string text2 = Regex.Split(class33_0.method_16().GetHabbo().string_5, "sh-")[1];
					text2 = "sh-" + text2.Split(new char[]
					{
						'.'
					})[0];
					class33_0.method_16().GetHabbo().string_5 = class33_0.method_16().GetHabbo().string_5.Replace(text2, text);
				}
			}
			if (string_0.Contains("ea-"))
			{
				string text = Regex.Split(string_0, "ea-")[1];
				text = "ea-" + text.Split(new char[]
				{
					'.'
				})[0];
				int num = class33_0.method_16().GetHabbo().string_5.IndexOf("ea-");
				if (num == -1)
				{
					class33_0.method_16().GetHabbo().string_5 = class33_0.method_16().GetHabbo().string_5 + text;
				}
				else
				{
					string text2 = Regex.Split(class33_0.method_16().GetHabbo().string_5, "ea-")[1];
					text2 = "ea-" + text2.Split(new char[]
					{
						'.'
					})[0];
					class33_0.method_16().GetHabbo().string_5 = class33_0.method_16().GetHabbo().string_5.Replace(text2, text);
				}
			}
			if (string_0.Contains("ca-"))
			{
				string text = Regex.Split(string_0, "ca-")[1];
				text = "ca-" + text.Split(new char[]
				{
					'.'
				})[0];
				int num = class33_0.method_16().GetHabbo().string_5.IndexOf("ca-");
				if (num == -1)
				{
					class33_0.method_16().GetHabbo().string_5 = class33_0.method_16().GetHabbo().string_5 + text;
				}
				else
				{
					string text2 = Regex.Split(class33_0.method_16().GetHabbo().string_5, "ca-")[1];
					text2 = "ca-" + text2.Split(new char[]
					{
						'.'
					})[0];
					class33_0.method_16().GetHabbo().string_5 = class33_0.method_16().GetHabbo().string_5.Replace(text2, text);
				}
			}
			if (string_0.Contains("ha-"))
			{
				string text = Regex.Split(string_0, "ha-")[1];
				text = "ha-" + text.Split(new char[]
				{
					'.'
				})[0];
				int num = class33_0.method_16().GetHabbo().string_5.IndexOf("ha-");
				if (num == -1)
				{
					class33_0.method_16().GetHabbo().string_5 = class33_0.method_16().GetHabbo().string_5 + text;
				}
				else
				{
					string text2 = Regex.Split(class33_0.method_16().GetHabbo().string_5, "ha-")[1];
					text2 = "ha-" + text2.Split(new char[]
					{
						'.'
					})[0];
					class33_0.method_16().GetHabbo().string_5 = class33_0.method_16().GetHabbo().string_5.Replace(text2, text);
				}
			}
			if (string_0.Contains("he-"))
			{
				string text = Regex.Split(string_0, "he-")[1];
				text = "he-" + text.Split(new char[]
				{
					'.'
				})[0];
				int num = class33_0.method_16().GetHabbo().string_5.IndexOf("he-");
				if (num == -1)
				{
					class33_0.method_16().GetHabbo().string_5 = class33_0.method_16().GetHabbo().string_5 + text;
				}
				else
				{
					string text2 = Regex.Split(class33_0.method_16().GetHabbo().string_5, "he-")[1];
					text2 = "he-" + text2.Split(new char[]
					{
						'.'
					})[0];
					class33_0.method_16().GetHabbo().string_5 = class33_0.method_16().GetHabbo().string_5.Replace(text2, text);
				}
			}
			if (string_0.Contains("wa-"))
			{
				string text = Regex.Split(string_0, "wa-")[1];
				text = "wa-" + text.Split(new char[]
				{
					'.'
				})[0];
				int num = class33_0.method_16().GetHabbo().string_5.IndexOf("wa-");
				if (num == -1)
				{
					class33_0.method_16().GetHabbo().string_5 = class33_0.method_16().GetHabbo().string_5 + text;
				}
				else
				{
					string text2 = Regex.Split(class33_0.method_16().GetHabbo().string_5, "wa-")[1];
					text2 = "wa-" + text2.Split(new char[]
					{
						'.'
					})[0];
					class33_0.method_16().GetHabbo().string_5 = class33_0.method_16().GetHabbo().string_5.Replace(text2, text);
				}
			}
			if (string_0.Contains("fa-"))
			{
				string text = Regex.Split(string_0, "fa-")[1];
				text = "fa-" + text.Split(new char[]
				{
					'.'
				})[0];
				int num = class33_0.method_16().GetHabbo().string_5.IndexOf("fa-");
				if (num == -1)
				{
					class33_0.method_16().GetHabbo().string_5 = class33_0.method_16().GetHabbo().string_5 + text;
				}
				else
				{
					string text2 = Regex.Split(class33_0.method_16().GetHabbo().string_5, "fa-")[1];
					text2 = "fa-" + text2.Split(new char[]
					{
						'.'
					})[0];
					class33_0.method_16().GetHabbo().string_5 = class33_0.method_16().GetHabbo().string_5.Replace(text2, text);
				}
			}
			if (string_0.Contains("cc-"))
			{
				string text = Regex.Split(string_0, "cc-")[1];
				text = "cc-" + text.Split(new char[]
				{
					'.'
				})[0];
				int num = class33_0.method_16().GetHabbo().string_5.IndexOf("cc-");
				if (num == -1)
				{
					class33_0.method_16().GetHabbo().string_5 = class33_0.method_16().GetHabbo().string_5 + text;
				}
				else
				{
					string text2 = Regex.Split(class33_0.method_16().GetHabbo().string_5, "cc-")[1];
					text2 = "cc-" + text2.Split(new char[]
					{
						'.'
					})[0];
					class33_0.method_16().GetHabbo().string_5 = class33_0.method_16().GetHabbo().string_5.Replace(text2, text);
				}
			}
		}
	}
}
