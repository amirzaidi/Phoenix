using System;
using System.Collections.Generic;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Items;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.HabboHotel.Rooms
{
	internal sealed class Class65
	{
		public uint uint_0;
		private uint uint_1;
		private bool bool_0;
		public List<Class39> list_0;
		public bool Boolean_0
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}
		public Class65(uint UserId, uint RoomId)
		{
			this.uint_0 = UserId;
			this.uint_1 = RoomId;
			this.bool_0 = false;
			this.list_0 = new List<Class39>();
		}

		public Class33 method_0()
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(this.uint_1);
			if (@class == null)
			{
				return null;
			}
			else
			{
				return @class.method_53(this.uint_0);
			}
		}
		public GameClient method_1()
		{
			return Phoenix.GetGame().GetClientManager().method_2(this.uint_0);
		}
	}
}
