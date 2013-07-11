using System;
namespace Phoenix.HabboHotel.Rooms
{
	public sealed class Coordinates
	{
		private int int_x;
		private int int_y;
		private int int_z;

		public int X
		{
			get
			{
				return this.int_x;
			}
		}
		public int Y
		{
			get
			{
				return this.int_y;
			}
		}
		public int Z
		{
			get
			{
				return this.int_z;
			}
		}

		public Coordinates(int x, int y, int z)
		{
			this.int_x = x;
			this.int_y = y;
			this.int_z = z;
		}
	}
}
