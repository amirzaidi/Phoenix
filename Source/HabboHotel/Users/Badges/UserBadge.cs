using System;
namespace Phoenix.HabboHotel.Users.Badges
{
	internal sealed class UserBadge
	{
		public string Code;
		public int Slot;
		public UserBadge(string mCode, int mSlot)
		{
			this.Code = mCode;
			this.Slot = mSlot;
		}
	}
}
