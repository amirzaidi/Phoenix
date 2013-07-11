using System;
using Phoenix.Core;
using Phoenix.Messages;
namespace Phoenix.HabboHotel.Items
{
	internal sealed class Class39
	{
		internal uint uint_0;
		internal uint uint_1;
		internal string string_0;
		private FurnitureData class40_0;
		internal Class39(uint uint_2, uint uint_3, string string_1)
		{
			this.uint_0 = uint_2;
			this.uint_1 = uint_3;
			this.string_0 = string_1;
			this.class40_0 = this.method_1();
		}
		internal void method_0(ServerMessage gclass5_0, bool bool_0)
		{
			if (this.class40_0 == null)
			{
                Logging.LogException("Unknown base: " + this.uint_1);
			}
			gclass5_0.AppendUInt(this.uint_0);
			gclass5_0.AppendStringWithBreak(this.class40_0.char_0.ToString().ToUpper());
			gclass5_0.AppendUInt(this.uint_0);
			gclass5_0.AppendInt32(this.class40_0.int_0);
			if (this.class40_0.string_1.Contains("a2 "))
			{
				gclass5_0.AppendInt32(3);
			}
			else
			{
				if (this.class40_0.string_1.Contains("wallpaper"))
				{
					gclass5_0.AppendInt32(2);
				}
				else
				{
					if (this.class40_0.string_1.Contains("landscape"))
					{
						gclass5_0.AppendInt32(4);
					}
					else
					{
						if (this.method_1().string_1 == "poster")
						{
							gclass5_0.AppendInt32(6);
						}
						else
						{
							if (this.method_1().string_1 == "song_disk")
							{
								gclass5_0.AppendInt32(8);
							}
							else
							{
								gclass5_0.AppendInt32(1);
							}
						}
					}
				}
			}
			if (this.method_1().string_1 == "song_disk")
			{
				gclass5_0.AppendInt32(0);
				gclass5_0.AppendStringWithBreak("");
			}
			else
			{
				if (this.method_1().string_1.StartsWith("poster_"))
				{
					gclass5_0.AppendStringWithBreak(this.method_1().string_1.Split(new char[]
					{
						'_'
					})[1]);
				}
				else
				{
					gclass5_0.AppendInt32(0);
					gclass5_0.AppendStringWithBreak(this.string_0);
				}
			}
			gclass5_0.AppendBoolean(this.class40_0.bool_3);
			gclass5_0.AppendBoolean(this.class40_0.bool_4);
			gclass5_0.AppendBoolean(this.class40_0.bool_7);
			gclass5_0.AppendBoolean(Phoenix.GetGame().GetCatalog().method_22().method_0(this));
			gclass5_0.AppendInt32(-1);
			if (this.class40_0.char_0 == 's')
			{
				gclass5_0.AppendStringWithBreak("");
				if (this.method_1().string_1 == "song_disk" && this.string_0.Length > 0)
				{
					gclass5_0.AppendInt32(Convert.ToInt32(this.string_0));
				}
				else
				{
					gclass5_0.AppendInt32(0);
				}
			}
		}
		internal FurnitureData method_1()
		{
			return Phoenix.GetGame().GetItemManager().method_2(this.uint_1);
		}
	}
}
