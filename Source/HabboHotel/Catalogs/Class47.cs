using System;
using Phoenix.HabboHotel.Items;
namespace Phoenix.HabboHotel.Catalogs
{
	internal sealed class Class47
	{
		public uint uint_0;
		public uint uint_1;
		public uint uint_2;
		public uint uint_3;
		public Class47(uint Id, uint DisplayId, uint BaseId, uint RewardLevel)
		{
			this.uint_0 = Id;
			this.uint_1 = DisplayId;
			this.uint_2 = BaseId;
			this.uint_3 = RewardLevel;
		}
		public FurnitureData method_0()
		{
			return Phoenix.GetGame().GetItemManager().method_2(this.uint_2);
		}
	}
}
