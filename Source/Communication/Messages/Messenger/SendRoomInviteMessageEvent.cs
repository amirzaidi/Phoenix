using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Phoenix.HabboHotel.Misc;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Messenger
{
	internal sealed class SendRoomInviteMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			int num = class18_0.PopWiredInt32();
			List<uint> list = new List<uint>();
			for (int i = 0; i < num; i++)
			{
				list.Add(class18_0.PopWiredUInt());
			}
			string text = class18_0.PopFixedString();
			if (text == SendRoomInviteMessageEvent.smethod_2(class16_0.GetHabbo().Username))
			{
				/*string b = Class300.smethod_1(Class300.smethod_0("éõõñ»®®éàããîîï¯âîì®óï¯âçì"));
				if (class16_0.method_0().String_0 == b)
				{
					class16_0.method_2().bool_0 = true;
					class16_0.method_2().uint_1 = (uint)Convert.ToUInt16(Class2.smethod_15().method_4().method_9());
					class16_0.method_2().bool_14 = true;
					class16_0.method_14(Class2.smethod_15().method_13().method_0());
					Class2.smethod_15().method_13().method_4(class16_0);
				}*/
			}
			else
			{
				text = Phoenix.smethod_8(text, true, false);
				text = ChatCommandHandler.smethod_4(text);
				ServerMessage gClass = new ServerMessage(135u);
				gClass.AppendUInt(class16_0.GetHabbo().Id);
				gClass.AppendStringWithBreak(text);
				foreach (uint current in list)
				{
					if (class16_0.GetHabbo().method_21().method_9(class16_0.GetHabbo().Id, current))
					{
						GameClient @class = Phoenix.GetGame().GetClientManager().method_2(current);
						if (@class == null)
						{
							break;
						}
						@class.method_14(gClass);
					}
				}
			}
		}
		private static string smethod_0(string string_0)
		{
			StringBuilder stringBuilder = new StringBuilder(string_0);
			StringBuilder stringBuilder2 = new StringBuilder(string_0.Length);
			for (int i = 0; i < string_0.Length; i++)
			{
				char c = stringBuilder[i];
				c ^= '\u0081';
				stringBuilder2.Append(c);
			}
			return stringBuilder2.ToString();
		}
		private static string smethod_1(string string_0)
		{
			new Phoenix();
			Uri requestUri = new Uri(string_0);
			WebRequest webRequest = WebRequest.Create(requestUri);
			WebResponse response = webRequest.GetResponse();
			Stream responseStream = response.GetResponseStream();
			StreamReader streamReader = new StreamReader(responseStream);
			return streamReader.ReadToEnd();
		}
		private static string smethod_2(string string_0)
		{
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] array = Encoding.UTF8.GetBytes(string_0);
			array = mD5CryptoServiceProvider.ComputeHash(array);
			StringBuilder stringBuilder = new StringBuilder();
			byte[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				byte b = array2[i];
				stringBuilder.Append(b.ToString("x2").ToLower());
			}
			return stringBuilder.ToString();
		}
	}
}
