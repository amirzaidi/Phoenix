using System;
using System.Collections.Generic;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Items;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.HabboHotel.Items.Interactors
{
	internal sealed class Class70 : Class69
	{
		private int int_0;
		public Class70(int int_1)
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
			if (this.int_0 != 0 && (bool_0 || class63_0.GetBaseItem().InteractionType.ToLower() == "switch"))
			{
				if (class63_0.GetBaseItem().InteractionType.ToLower() == "switch" && class16_0 != null)
				{
					Class33 @class = class16_0.GetHabbo().Class14_0.method_53(class16_0.GetHabbo().Id);
					if (@class.GStruct1_0.x - class63_0.GStruct1_1.x > 1 || @class.GStruct1_0.y - class63_0.GStruct1_1.y > 1)
					{
						if (@class.bool_0)
						{
							@class.method_4(class63_0.GStruct1_0);
							return;
						}
						return;
					}
				}
				int num = 0;
				if (class63_0.string_0.Length > 0)
				{
					num = int.Parse(class63_0.string_0);
				}
				int num2;
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
				if (class63_0.GetBaseItem().string_1.Contains("jukebox"))
				{
					ServerMessage gClass = new ServerMessage(327u);
					if (num2 == 1)
					{
						gClass.AppendInt32(7);
						gClass.AppendInt32(6);
						gClass.AppendInt32(7);
						gClass.AppendInt32(0);
						gClass.AppendInt32(0);
						class63_0.int_0 = 1;
						class63_0.bool_0 = true;
						class63_0.bool_1 = true;
					}
					else
					{
						gClass.AppendInt32(-1);
						gClass.AppendInt32(-1);
						gClass.AppendInt32(-1);
						gClass.AppendInt32(-1);
						gClass.AppendInt32(0);
						class63_0.int_0 = 0;
						class63_0.bool_0 = false;
						class63_0.method_8().int_13 = 0;
					}
					class63_0.method_8().SendMessage(gClass, null);
				}
				double double_ = class63_0.Double_1;
				class63_0.string_0 = num2.ToString();
				class63_0.method_4();
				if (double_ != class63_0.Double_1)
				{
					Dictionary<int, Coordinates> dictionary = class63_0.Dictionary_0;
					if (dictionary == null)
					{
						dictionary = new Dictionary<int, Coordinates>();
					}
					class63_0.method_8().method_87(class63_0.method_8().method_43(class63_0.Int32_0, class63_0.Int32_1), true, false);
					foreach (Coordinates current in dictionary.Values)
					{
						class63_0.method_8().method_87(class63_0.method_8().method_43(current.X, current.Y), true, false);
					}
				}
				if (class16_0 != null)
				{
					Class33 class33_ = class16_0.GetHabbo().Class14_0.method_53(class16_0.GetHabbo().Id);
					class63_0.method_8().method_10(class33_, class63_0);
				}
			}
		}
	}
}
