using System;
using Phoenix.HabboHotel.Misc;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Items;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Wired
{
	internal sealed class UpdateActionMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			try
			{
				Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
				uint uint_ = class18_0.PopWiredUInt();
				UserItemData class2 = @class.method_28(uint_);
				string text = class2.GetBaseItem().InteractionType.ToLower();
				switch (text)
				{
				case "wf_act_give_phx":
				{
					class18_0.PopWiredBoolean();
					string text2 = class18_0.PopFixedString();
					text2 = Phoenix.smethod_8(text2, false, true);
					text2 = ChatCommandHandler.smethod_4(text2);
					if (!(text2 == class2.string_2))
					{
						string string_ = text2.Split(new char[]
						{
							':'
						})[0].ToLower();
						if (Phoenix.GetGame().GetRoleManager().method_12(string_, class16_0))
						{
							class2.string_2 = text2;
						}
						else
						{
							class16_0.GetHabbo().method_28(PhoenixEnvironment.GetExternalText("wired_error_permissions"));
						}
					}
					break;
				}
				case "wf_cnd_phx":
				{
					class18_0.PopWiredBoolean();
					string text2 = class18_0.PopFixedString();
					text2 = Phoenix.smethod_8(text2, false, true);
					text2 = ChatCommandHandler.smethod_4(text2);
					if (!(text2 == class2.string_2))
					{
						string string_ = text2.Split(new char[]
						{
							':'
						})[0].ToLower();
						if (Phoenix.GetGame().GetRoleManager().method_11(string_, class16_0))
						{
							class2.string_2 = text2;
						}
						else
						{
							class16_0.GetHabbo().method_28(PhoenixEnvironment.GetExternalText("wired_error_permissions"));
						}
					}
					break;
				}
				case "wf_act_saymsg":
				{
					class18_0.PopWiredBoolean();
					string text2 = class18_0.PopFixedString();
					text2 = Phoenix.smethod_8(text2, false, true);
					if (text2.Length > 100)
					{
						text2 = text2.Substring(0, 100);
					}
					class2.string_2 = text2;
					break;
				}
				case "wf_trg_furnistate":
				case "wf_trg_onfurni":
				case "wf_trg_offfurni":
				case "wf_act_moveuser":
				case "wf_act_togglefurni":
				{
					class18_0.PopWiredBoolean();
					class18_0.PopFixedString();
					class2.string_2 = class18_0.ToString().Substring(class18_0.Length - (class18_0.RemainingLength - 2));
					class2.string_2 = class2.string_2.Substring(0, class2.string_2.Length - 2);
					class18_0.ResetPointer();
					class2 = @class.method_28(class18_0.PopWiredUInt());
					class18_0.PopWiredBoolean();
					class18_0.PopFixedString();
					int num2 = class18_0.PopWiredInt32();
					class2.string_3 = "";
					for (int i = 0; i < num2; i++)
					{
						class2.string_3 = class2.string_3 + "," + Convert.ToString(class18_0.PopWiredUInt());
					}
					if (class2.string_3.Length > 0)
					{
						class2.string_3 = class2.string_3.Substring(1);
					}
					break;
				}
				case "wf_act_givepoints":
					class18_0.PopWiredInt32();
					class2.string_2 = Convert.ToString(class18_0.PopWiredInt32());
					class2.string_3 = Convert.ToString(class18_0.PopWiredInt32());
					break;
				case "wf_act_moverotate":
				{
					class18_0.PopWiredInt32();
					class2.string_2 = Convert.ToString(class18_0.PopWiredInt32());
					class2.string_3 = Convert.ToString(class18_0.PopWiredInt32());
					class18_0.PopFixedString();
					int num2 = class18_0.PopWiredInt32();
					class2.string_4 = "";
					class2.string_5 = "";
					if (num2 > 0)
					{
						class2.string_5 = OldEncoding.encodeVL64(num2);
						for (int i = 0; i < num2; i++)
						{
							int num3 = class18_0.PopWiredInt32();
							class2.string_5 += OldEncoding.encodeVL64(num3);
							class2.string_4 = class2.string_4 + "," + Convert.ToString(num3);
						}
						class2.string_4 = class2.string_4.Substring(1);
					}
					class2.string_6 = Convert.ToString(class18_0.PopWiredInt32());
					break;
				}
				case "wf_act_matchfurni":
				{
					class18_0.PopWiredInt32();
					class2.string_3 = "";
					if (class18_0.PopWiredBoolean())
					{
						UserItemData expr_4A8 = class2;
						expr_4A8.string_3 += "I";
					}
					else
					{
						UserItemData expr_4C0 = class2;
						expr_4C0.string_3 += "H";
					}
					if (class18_0.PopWiredBoolean())
					{
						UserItemData expr_4E1 = class2;
						expr_4E1.string_3 += "I";
					}
					else
					{
						UserItemData expr_4F9 = class2;
						expr_4F9.string_3 += "H";
					}
					if (class18_0.PopWiredBoolean())
					{
						UserItemData expr_51A = class2;
						expr_51A.string_3 += "I";
					}
					else
					{
						UserItemData expr_532 = class2;
						expr_532.string_3 += "H";
					}
					class18_0.PopFixedString();
					int num2 = class18_0.PopWiredInt32();
					class2.string_2 = "";
					class2.string_4 = "";
					class2.string_5 = "";
					if (num2 > 0)
					{
						class2.string_5 = OldEncoding.encodeVL64(num2);
						for (int i = 0; i < num2; i++)
						{
							int num3 = class18_0.PopWiredInt32();
							class2.string_5 += OldEncoding.encodeVL64(num3);
							class2.string_4 = class2.string_4 + "," + Convert.ToString(num3);
							UserItemData class3 = @class.method_28(Convert.ToUInt32(num3));
							UserItemData expr_5E6 = class2;
							object string_2 = expr_5E6.string_2;
							expr_5E6.string_2 = string.Concat(new object[]
							{
								string_2,
								";",
								class3.Int32_0,
								",",
								class3.Int32_1,
								",",
								class3.Double_0,
								",",
								class3.int_3,
								",",
								class3.string_0
							});
						}
						class2.string_4 = class2.string_4.Substring(1);
						class2.string_2 = class2.string_2.Substring(1);
					}
					class2.string_6 = Convert.ToString(class18_0.PopWiredInt32());
					break;
				}
				}
				class2.method_5(true, false);
			}
			catch
			{
			}
		}
	}
}
