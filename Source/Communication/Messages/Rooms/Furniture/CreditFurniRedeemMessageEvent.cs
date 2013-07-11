using System;
using System.Data;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Items;
using Phoenix.Messages;
using Phoenix.Storage;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Furniture
{
	internal sealed class CreditFurniRedeemMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			try
			{
				Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
				if (@class != null && @class.method_27(class16_0, true))
				{
					UserItemData class2 = @class.method_28(class18_0.PopWiredUInt());
					Class39 class3 = class16_0.GetHabbo().method_23().method_10(class2.uint_0);
					if (class2 != null)
					{
						if (class2.GetBaseItem().string_1.StartsWith("CF_") || class2.GetBaseItem().string_1.StartsWith("CFC_") || class2.GetBaseItem().string_1.StartsWith("PixEx_") || class2.GetBaseItem().string_1.StartsWith("PntEx_"))
						{
							if (class3 != null)
							{
								@class.method_29(null, class3.uint_0, true, true);
							}
							else
							{
								DataRow dataRow = null;
								using (DatabaseClient class4 = Phoenix.GetDatabase().GetClient())
								{
									dataRow = class4.ReadDataRow("SELECT ID FROM items WHERE ID = '" + class2.uint_0 + "' LIMIT 1");
								}
								if (dataRow != null)
								{
									string[] array = class2.GetBaseItem().string_1.Split(new char[]
									{
										'_'
									});
									int num = int.Parse(array[1]);
									if (num > 0)
									{
										if (class2.GetBaseItem().string_1.StartsWith("CF_") || class2.GetBaseItem().string_1.StartsWith("CFC_"))
										{
											class16_0.GetHabbo().Credits += num;
											class16_0.GetHabbo().method_13(true);
										}
										else
										{
											if (class2.GetBaseItem().string_1.StartsWith("PixEx_"))
											{
												class16_0.GetHabbo().ActivityPoints += num;
												class16_0.GetHabbo().method_15(true);
											}
											else
											{
												if (class2.GetBaseItem().string_1.StartsWith("PntEx_"))
												{
													class16_0.GetHabbo().VipPoints += num;
													class16_0.GetHabbo().method_14(false, true);
												}
											}
										}
									}
								}
								@class.method_29(null, class2.uint_0, true, true);
								ServerMessage gclass5_ = new ServerMessage(219u);
								class16_0.method_14(gclass5_);
							}
						}
					}
				}
			}
			catch
			{
			}
		}
	}
}
