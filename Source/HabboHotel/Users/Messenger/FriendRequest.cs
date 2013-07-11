using System;
using Phoenix.Messages;
namespace Phoenix.HabboHotel.Users.Messenger
{
	internal sealed class FriendRequest
	{
		private uint uint_0;
		private uint uint_1;
		private uint uint_2;
		private string string_0;
		internal uint UInt32_0
		{
			get
			{
				return this.uint_2;
			}
		}
		internal uint UInt32_1
		{
			get
			{
				return this.uint_1;
			}
		}
		internal uint UInt32_2
		{
			get
			{
				return this.uint_2;
			}
		}
		internal string String_0
		{
			get
			{
				return this.string_0;
			}
		}
		public FriendRequest(uint uint_3, uint uint_4, uint uint_5, string string_1)
		{
			this.uint_0 = uint_3;
			this.uint_1 = uint_4;
			this.uint_2 = uint_5;
			this.string_0 = string_1;
		}
		public void method_0(ServerMessage gclass5_0)
		{
			gclass5_0.AppendUInt(this.uint_2);
			gclass5_0.AppendStringWithBreak(this.string_0);
			gclass5_0.AppendStringWithBreak(this.uint_2.ToString());
		}
	}
}
