using System;
using Phoenix.HabboHotel.Navigators;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Messages;
namespace Phoenix.HabboHotel.Navigators
{
	internal sealed class NavigatorPublic
	{
		private int int_0;
		public int int_1;
		public string string_0;
		public string string_1;
		public PublicImageType enum1_0;
		public uint uint_0;
		public int int_2;
		public bool bool_0;
		public int Int32_0
		{
			get
			{
				return this.int_0;
			}
		}
		public RoomData Class27_0
		{
			get
			{
				RoomData result;
				if (this.uint_0 == 0u)
				{
					result = new RoomData();
				}
				else
				{
					result = Phoenix.GetGame().GetRoomManager().method_12(this.uint_0);
				}
				return result;
			}
		}
		public NavigatorPublic(int int_3, int int_4, string string_2, string string_3, PublicImageType enum1_1, uint uint_1, bool bool_1, int int_5)
		{
			this.int_0 = int_3;
			this.int_1 = int_4;
			this.string_0 = string_2;
			this.string_1 = string_3;
			this.enum1_0 = enum1_1;
			this.uint_0 = uint_1;
			this.bool_0 = bool_1;
			this.int_2 = int_5;
		}
		public void method_0(ServerMessage gclass5_0)
		{
			if (!this.bool_0)
			{
				gclass5_0.AppendInt32(this.Int32_0);
				gclass5_0.AppendStringWithBreak((this.int_1 == 1) ? this.string_0 : this.Class27_0.Name);
				gclass5_0.AppendStringWithBreak(this.Class27_0.Description);
				gclass5_0.AppendInt32(this.int_1);
				gclass5_0.AppendStringWithBreak(this.string_0);
				gclass5_0.AppendStringWithBreak((this.enum1_0 == PublicImageType.EXTERNAL) ? this.string_1 : "");
				gclass5_0.AppendInt32(this.int_2);
				gclass5_0.AppendInt32(this.Class27_0.UsersNow);
				gclass5_0.AppendInt32(3);
				gclass5_0.AppendStringWithBreak((this.enum1_0 == PublicImageType.INTERNAL) ? this.string_1 : "");
				gclass5_0.AppendUInt(1337u);
				gclass5_0.AppendBoolean(true);
				gclass5_0.AppendStringWithBreak(this.Class27_0.CCTs);
				gclass5_0.AppendInt32(this.Class27_0.UsersMax);
				gclass5_0.AppendUInt(this.uint_0);
			}
			else
			{
				if (this.bool_0)
				{
					gclass5_0.AppendInt32(this.Int32_0);
					gclass5_0.AppendStringWithBreak(this.string_0);
					gclass5_0.AppendStringWithBreak("");
					gclass5_0.AppendBoolean(true);
					gclass5_0.AppendStringWithBreak("");
					gclass5_0.AppendStringWithBreak((this.enum1_0 == PublicImageType.EXTERNAL) ? this.string_1 : "");
					gclass5_0.AppendBoolean(false);
					gclass5_0.AppendBoolean(false);
					gclass5_0.AppendInt32(4);
					gclass5_0.AppendBoolean(false);
				}
			}
		}
	}
}
