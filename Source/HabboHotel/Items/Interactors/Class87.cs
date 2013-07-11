using System;
using System.Collections.Generic;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Items;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.HabboHotel.Items.Interactors
{
	internal sealed class Class87 : Class69
	{
		private int int_0;
		public Class87(int int_1)
		{
			this.int_0 = int_1 - 1;
			if (this.int_0 < 0)
			{
				this.int_0 = 0;
			}
		}
		public override void OnPlace(GameClient class16_0, UserItemData class63_0)
		{
		}
		public override void OnRemove(GameClient class16_0, UserItemData class63_0)
		{
		}
		public override void OnTrigger(GameClient class16_0, UserItemData class63_0, int int_1, bool bool_0)
		{
			if (bool_0)
			{
				if (this.int_0 == 0)
				{
					class63_0.method_5(false, true);
				}
				int num = 0;
				int num2 = 0;
				if (class63_0.string_0.Length > 0)
				{
					num = int.Parse(class63_0.string_0);
				}
				if (num <= 0)
				{
					num2 = 1;
				}
				else
				{
					if (num >= this.int_0)
					{
						num2 = 0;
					}
					else
					{
						num2 = num + 1;
					}
				}
				if (num2 == 0)
				{
					if (class63_0.method_8().method_97(class63_0.Int32_0, class63_0.Int32_1))
					{
						return;
					}
					Dictionary<int, Coordinates> dictionary = class63_0.method_8().method_94(class63_0.GetBaseItem().int_2, class63_0.GetBaseItem().int_1, class63_0.Int32_0, class63_0.Int32_1, class63_0.int_3);
					if (dictionary == null)
					{
						dictionary = new Dictionary<int, Coordinates>();
					}
					foreach (Coordinates current in dictionary.Values)
					{
						if (class63_0.method_8().method_97(current.X, current.Y))
						{
							return;
						}
					}
				}
				class63_0.string_0 = num2.ToString();
				class63_0.method_4();
				class63_0.method_8().method_22();
			}
		}
	}
}
