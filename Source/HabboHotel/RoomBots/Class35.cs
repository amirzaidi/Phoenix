using System;
using System.Collections.Generic;
namespace Phoenix.HabboHotel.RoomBots
{
	internal sealed class Class35
	{
		private uint uint_0;
		public uint uint_1;
		public List<string> list_0;
		public string string_0;
		public string string_1;
		public int int_0;
		public Class35(uint Id, uint BotId, string Keywords, string ResponseText, string ResponseType, int ServeId)
		{
			this.uint_0 = Id;
			this.uint_1 = BotId;
			this.list_0 = new List<string>();
			this.string_0 = ResponseText;
			this.string_1 = ResponseType;
			this.int_0 = ServeId;
			string[] array = Keywords.Split(new char[]	{ ';' });
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				this.list_0.Add(text.ToLower());
			}
		}
		public bool method_0(string string_2)
		{
			using (TimedLock.Lock(this.list_0))
			{
				foreach (string current in this.list_0)
				{
					if (string_2.ToLower().Contains(current.ToLower()))
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
