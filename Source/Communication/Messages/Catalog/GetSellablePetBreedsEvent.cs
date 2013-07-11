using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Catalog
{
	internal sealed class GetSellablePetBreedsEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			ServerMessage gClass = new ServerMessage(827u);
			string text = class18_0.ToString().Split(new char[]
			{
				' '
			})[1];
			if (text.ToLower().Contains("pet"))
			{
				int num = Convert.ToInt32(text.Substring(3));
				gClass.AppendStringWithBreak("a0 pet" + num);
				switch (num)
				{
				case 0:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_0"));
					break;
				case 1:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_1"));
					break;
				case 2:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_2"));
					break;
				case 3:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_3"));
					break;
				case 4:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_4"));
					break;
				case 5:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_5"));
					break;
				case 6:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_6"));
					break;
				case 7:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_7"));
					break;
				case 8:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_8"));
					break;
				case 9:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_9"));
					break;
				case 10:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_10"));
					break;
				case 11:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_11"));
					break;
				case 12:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_12"));
					break;
				case 13:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_13"));
					break;
				case 14:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_14"));
					break;
				case 15:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_15"));
					break;
				case 16:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_16"));
					break;
				case 17:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_17"));
					break;
				case 18:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_18"));
					break;
				case 19:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_19"));
					break;
				case 20:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_20"));
					break;
				case 21:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_21"));
					break;
				case 22:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_22"));
					break;
				case 23:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_23"));
					break;
				case 24:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_24"));
					break;
				case 25:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_25"));
					break;
				case 26:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_26"));
					break;
				case 27:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_27"));
					break;
				case 28:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_28"));
					break;
				case 29:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_29"));
					break;
				case 30:
					gClass.AppendString(PhoenixEnvironment.GetExternalText("pet_breeds_30"));
					break;
				}
				class16_0.method_14(gClass);
			}
		}
	}
}
