using System;
namespace Phoenix.HabboHotel.Users.Subscriptions
{
	internal sealed class Subscription
	{
		private string Type;
		private int Months;
		private int ItemsSelected;
		public string String_0
		{
			get
			{
				return this.Type;
			}
		}
		public int Int32_0
		{
			get
			{
				return this.ItemsSelected;
			}
		}
		public Subscription(string mType, int mMonths, int mItemsSelected)
		{
			this.Type = mType;
			this.Months = mMonths;
			this.ItemsSelected = mItemsSelected;
		}
		public bool method_0()
		{
			return (double)this.ItemsSelected > Phoenix.GetUnixTimestamp();
		}
		public void method_1(int int_2)
		{
			if (this.ItemsSelected + int_2 < 2147483647)
			{
				this.ItemsSelected += int_2;
			}
		}
	}
}
