using System;
namespace Phoenix.HabboHotel.Support
{
	internal sealed class Class130
	{
		private uint uint_0;
		public string string_0;
		public string string_1;
		public uint uint_1;
		public uint UInt32_0
		{
			get
			{
				return this.uint_0;
			}
		}
		public Class130(uint Id, string Caption, string Body, uint CategoryId)
		{
			this.uint_0 = Id;
			this.string_0 = Caption;
			this.string_1 = Body;
			this.uint_1 = CategoryId;
		}
	}
}
