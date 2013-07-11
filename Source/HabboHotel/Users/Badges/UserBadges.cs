using System;
using System.Collections.Generic;
using System.Data;
using Phoenix.HabboHotel.Users.UserDataManagement;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.Storage;
namespace Phoenix.HabboHotel.Users.Badges
{
	internal sealed class UserBadges
	{
		private List<UserBadge> list_0;
		private uint uint_0;
		public int Int32_0
		{
			get
			{
				return this.list_0.Count;
			}
		}
		public int Int32_1
		{
			get
			{
				int num = 0;
				foreach (UserBadge current in this.list_0)
				{
					if (current.Slot > 0)
					{
						num++;
					}
				}
				return num;
			}
		}
		public List<UserBadge> List_0
		{
			get
			{
				return this.list_0;
			}
		}
		public UserBadges(uint uint_1, UserDataFactory class12_0)
		{
			this.list_0 = new List<UserBadge>();
			this.uint_0 = uint_1;
			DataTable dataTable_ = class12_0.DataTable_5;
			if (dataTable_ != null)
			{
				foreach (DataRow dataRow in dataTable_.Rows)
				{
					this.list_0.Add(new UserBadge((string)dataRow["badge_id"], (int)dataRow["badge_slot"]));
				}
			}
		}
		public UserBadge method_0(string string_0)
		{
			UserBadge result;
			foreach (UserBadge current in this.list_0)
			{
				if (string_0.ToLower() == current.Code.ToLower())
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}
		public bool method_1(string string_0)
		{
			return this.method_0(string_0) != null;
		}
		public void method_2(GameClient class16_0, string string_0, bool bool_0)
		{
			this.method_3(string_0, 0, bool_0);
			ServerMessage gClass = new ServerMessage(832u);
			gClass.AppendInt32(1);
			gClass.AppendInt32(4);
			gClass.AppendInt32(1);
			gClass.AppendUInt(Phoenix.GetGame().GetAchievementManager().method_0(string_0));
			class16_0.method_14(gClass);
		}
		public void method_3(string string_0, int int_0, bool bool_0)
		{
			if (!this.method_1(string_0))
			{
				if (bool_0)
				{
					using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
					{
						@class.AddParamWithValue("badge", string_0);
						@class.ExecuteQuery(string.Concat(new object[]
						{
							"INSERT INTO user_badges (user_id,badge_id,badge_slot) VALUES ('",
							this.uint_0,
							"',@badge,'",
							int_0,
							"')"
						}));
					}
				}
				this.list_0.Add(new UserBadge(string_0, int_0));
			}
		}
		public void method_4(string string_0, int int_0)
		{
			UserBadge @class = this.method_0(string_0);
			if (@class != null)
			{
				@class.Slot = int_0;
			}
		}
		public void method_5()
		{
			foreach (UserBadge current in this.list_0)
			{
				current.Slot = 0;
			}
		}
		public void method_6(string string_0)
		{
			if (this.method_1(string_0))
			{
				using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
				{
					@class.AddParamWithValue("badge", string_0);
					@class.ExecuteQuery("DELETE FROM user_badges WHERE badge_id = @badge AND user_id = '" + this.uint_0 + "' LIMIT 1");
				}
				this.list_0.Remove(this.method_0(string_0));
			}
		}
		public ServerMessage method_7()
		{
			List<UserBadge> list = new List<UserBadge>();
			ServerMessage gClass = new ServerMessage(229u);
			gClass.AppendInt32(this.Int32_0);
			foreach (UserBadge current in this.list_0)
			{
				gClass.AppendUInt(Phoenix.GetGame().GetAchievementManager().method_0(current.Code));
				gClass.AppendStringWithBreak(current.Code);
				if (current.Slot > 0)
				{
					list.Add(current);
				}
			}
			gClass.AppendInt32(list.Count);
			foreach (UserBadge current in list)
			{
				gClass.AppendInt32(current.Slot);
				gClass.AppendStringWithBreak(current.Code);
			}
			return gClass;
		}
	}
}
