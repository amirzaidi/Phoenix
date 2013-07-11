using System;
using System.Collections.Generic;
using System.Data;
using Phoenix.Core;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Util;
using Phoenix.Storage;
namespace Phoenix.HabboHotel.Roles
{
	internal sealed class RoleManager
	{
		private Dictionary<uint, List<string>> dictionary_0;
		private Dictionary<uint, List<string>> dictionary_1;
		public Dictionary<uint, string> dictionary_2;
		private Dictionary<uint, int> dictionary_3;
		public Dictionary<string, int> dictionary_4;
		public Dictionary<string, int> dictionary_5;
		public RoleManager()
		{
			this.dictionary_0 = new Dictionary<uint, List<string>>();
			this.dictionary_1 = new Dictionary<uint, List<string>>();
			this.dictionary_2 = new Dictionary<uint, string>();
			this.dictionary_3 = new Dictionary<uint, int>();
			this.dictionary_4 = new Dictionary<string, int>();
			this.dictionary_5 = new Dictionary<string, int>();
		}
		public void Load(DatabaseClient class6_0)
		{
			Logging.Write(PhoenixEnvironment.GetExternalText("emu_loadroles"));
			this.method_10();
			DataTable dataTable = class6_0.ReadDataTable("SELECT * FROM ranks ORDER BY id ASC;");
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					this.dictionary_2.Add((uint)dataRow["id"], dataRow["badgeid"].ToString());
				}
			}
			dataTable = class6_0.ReadDataTable("SELECT * FROM permissions_users ORDER BY userid ASC;");
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					List<string> list = new List<string>();
					if (Phoenix.smethod_3(dataRow["cmd_update_settings"].ToString()))
					{
						list.Add("cmd_update_settings");
					}
					if (Phoenix.smethod_3(dataRow["cmd_update_bans"].ToString()))
					{
						list.Add("cmd_update_bans");
					}
					if (Phoenix.smethod_3(dataRow["cmd_update_bots"].ToString()))
					{
						list.Add("cmd_update_bots");
					}
					if (Phoenix.smethod_3(dataRow["cmd_update_catalogue"].ToString()))
					{
						list.Add("cmd_update_catalogue");
					}
					if (Phoenix.smethod_3(dataRow["cmd_update_navigator"].ToString()))
					{
						list.Add("cmd_update_navigator");
					}
					if (Phoenix.smethod_3(dataRow["cmd_update_items"].ToString()))
					{
						list.Add("cmd_update_items");
					}
					if (Phoenix.smethod_3(dataRow["cmd_award"].ToString()))
					{
						list.Add("cmd_award");
					}
					if (Phoenix.smethod_3(dataRow["cmd_coords"].ToString()))
					{
						list.Add("cmd_coords");
					}
					if (Phoenix.smethod_3(dataRow["cmd_override"].ToString()))
					{
						list.Add("cmd_override");
					}
					if (Phoenix.smethod_3(dataRow["cmd_coins"].ToString()))
					{
						list.Add("cmd_coins");
					}
					if (Phoenix.smethod_3(dataRow["cmd_pixels"].ToString()))
					{
						list.Add("cmd_pixels");
					}
					if (Phoenix.smethod_3(dataRow["cmd_ha"].ToString()))
					{
						list.Add("cmd_ha");
					}
					if (Phoenix.smethod_3(dataRow["cmd_hal"].ToString()))
					{
						list.Add("cmd_hal");
					}
					if (Phoenix.smethod_3(dataRow["cmd_freeze"].ToString()))
					{
						list.Add("cmd_freeze");
					}
					if (Phoenix.smethod_3(dataRow["cmd_enable"].ToString()))
					{
						list.Add("cmd_enable");
					}
					if (Phoenix.smethod_3(dataRow["cmd_roommute"].ToString()))
					{
						list.Add("cmd_roommute");
					}
					if (Phoenix.smethod_3(dataRow["cmd_setspeed"].ToString()))
					{
						list.Add("cmd_setspeed");
					}
					if (Phoenix.smethod_3(dataRow["cmd_masscredits"].ToString()))
					{
						list.Add("cmd_masscredits");
					}
					if (Phoenix.smethod_3(dataRow["cmd_globalcredits"].ToString()))
					{
						list.Add("cmd_globalcredits");
					}
					if (Phoenix.smethod_3(dataRow["cmd_masspixels"].ToString()))
					{
						list.Add("cmd_masspixels");
					}
					if (Phoenix.smethod_3(dataRow["cmd_globalpixels"].ToString()))
					{
						list.Add("cmd_globalpixels");
					}
					if (Phoenix.smethod_3(dataRow["cmd_roombadge"].ToString()))
					{
						list.Add("cmd_roombadge");
					}
					if (Phoenix.smethod_3(dataRow["cmd_massbadge"].ToString()))
					{
						list.Add("cmd_massbadge");
					}
					if (Phoenix.smethod_3(dataRow["cmd_userinfo"].ToString()))
					{
						list.Add("cmd_userinfo");
					}
					if (Phoenix.smethod_3(dataRow["cmd_userinfo_viewip"].ToString()))
					{
						list.Add("cmd_userinfo_viewip");
					}
					if (Phoenix.smethod_3(dataRow["cmd_shutdown"].ToString()))
					{
						list.Add("cmd_shutdown");
					}
					if (Phoenix.smethod_3(dataRow["cmd_givebadge"].ToString()))
					{
						list.Add("cmd_givebadge");
					}
					if (Phoenix.smethod_3(dataRow["cmd_removebadge"].ToString()))
					{
						list.Add("cmd_removebadge");
					}
					if (Phoenix.smethod_3(dataRow["cmd_summon"].ToString()))
					{
						list.Add("cmd_summon");
					}
					if (Phoenix.smethod_3(dataRow["cmd_invisible"].ToString()))
					{
						list.Add("cmd_invisible");
					}
					if (Phoenix.smethod_3(dataRow["cmd_ban"].ToString()))
					{
						list.Add("cmd_ban");
					}
					if (Phoenix.smethod_3(dataRow["cmd_superban"].ToString()))
					{
						list.Add("cmd_superban");
					}
					if (Phoenix.smethod_3(dataRow["cmd_roomkick"].ToString()))
					{
						list.Add("cmd_roomkick");
					}
					if (Phoenix.smethod_3(dataRow["cmd_roomalert"].ToString()))
					{
						list.Add("cmd_roomalert");
					}
					if (Phoenix.smethod_3(dataRow["cmd_mute"].ToString()))
					{
						list.Add("cmd_mute");
					}
					if (Phoenix.smethod_3(dataRow["cmd_unmute"].ToString()))
					{
						list.Add("cmd_unmute");
					}
					if (Phoenix.smethod_3(dataRow["cmd_alert"].ToString()))
					{
						list.Add("cmd_alert");
					}
					if (Phoenix.smethod_3(dataRow["cmd_motd"].ToString()))
					{
						list.Add("cmd_motd");
					}
					if (Phoenix.smethod_3(dataRow["cmd_kick"].ToString()))
					{
						list.Add("cmd_kick");
					}
					if (Phoenix.smethod_3(dataRow["cmd_update_filter"].ToString()))
					{
						list.Add("cmd_update_filter");
					}
					if (Phoenix.smethod_3(dataRow["cmd_update_permissions"].ToString()))
					{
						list.Add("cmd_update_permissions");
					}
					if (Phoenix.smethod_3(dataRow["cmd_sa"].ToString()))
					{
						list.Add("cmd_sa");
					}
					if (Phoenix.smethod_3(dataRow["receive_sa"].ToString()))
					{
						list.Add("receive_sa");
					}
					if (Phoenix.smethod_3(dataRow["cmd_ipban"].ToString()))
					{
						list.Add("cmd_ipban");
					}
					if (Phoenix.smethod_3(dataRow["cmd_spull"].ToString()))
					{
						list.Add("cmd_spull");
					}
					if (Phoenix.smethod_3(dataRow["cmd_disconnect"].ToString()))
					{
						list.Add("cmd_disconnect");
					}
					if (Phoenix.smethod_3(dataRow["cmd_update_achievements"].ToString()))
					{
						list.Add("cmd_update_achievements");
					}
					if (Phoenix.smethod_3(dataRow["cmd_update_texts"].ToString()))
					{
						list.Add("cmd_update_texts");
					}
					if (Phoenix.smethod_3(dataRow["cmd_teleport"].ToString()))
					{
						list.Add("cmd_teleport");
					}
					if (Phoenix.smethod_3(dataRow["cmd_points"].ToString()))
					{
						list.Add("cmd_points");
					}
					if (Phoenix.smethod_3(dataRow["cmd_masspoints"].ToString()))
					{
						list.Add("cmd_masspoints");
					}
					if (Phoenix.smethod_3(dataRow["cmd_globalpoints"].ToString()))
					{
						list.Add("cmd_globalpoints");
					}
					if (Phoenix.smethod_3(dataRow["cmd_empty"].ToString()))
					{
						list.Add("cmd_empty");
					}
					if (Phoenix.smethod_3(dataRow["ignore_roommute"].ToString()))
					{
						list.Add("ignore_roommute");
					}
					if (Phoenix.smethod_3(dataRow["acc_anyroomrights"].ToString()))
					{
						list.Add("acc_anyroomrights");
					}
					if (Phoenix.smethod_3(dataRow["acc_anyroomowner"].ToString()))
					{
						list.Add("acc_anyroomowner");
					}
					if (Phoenix.smethod_3(dataRow["acc_supporttool"].ToString()))
					{
						list.Add("acc_supporttool");
					}
					if (Phoenix.smethod_3(dataRow["acc_chatlogs"].ToString()))
					{
						list.Add("acc_chatlogs");
					}
					if (Phoenix.smethod_3(dataRow["acc_enter_fullrooms"].ToString()))
					{
						list.Add("acc_enter_fullrooms");
					}
					if (Phoenix.smethod_3(dataRow["acc_enter_anyroom"].ToString()))
					{
						list.Add("acc_enter_anyroom");
					}
					if (Phoenix.smethod_3(dataRow["acc_restrictedrooms"].ToString()))
					{
						list.Add("acc_restrictedrooms");
					}
					if (Phoenix.smethod_3(dataRow["acc_unkickable"].ToString()))
					{
						list.Add("acc_unkickable");
					}
					if (Phoenix.smethod_3(dataRow["acc_unbannable"].ToString()))
					{
						list.Add("acc_unbannable");
					}
					if (Phoenix.smethod_3(dataRow["ignore_friendsettings"].ToString()))
					{
						list.Add("ignore_friendsettings");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_sql"].ToString()))
					{
						list.Add("wired_give_sql");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_badge"].ToString()))
					{
						list.Add("wired_give_badge");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_effect"].ToString()))
					{
						list.Add("wired_give_effect");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_award"].ToString()))
					{
						list.Add("wired_give_award");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_dance"].ToString()))
					{
						list.Add("wired_give_dance");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_send"].ToString()))
					{
						list.Add("wired_give_send");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_credits"].ToString()))
					{
						list.Add("wired_give_credits");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_pixels"].ToString()))
					{
						list.Add("wired_give_pixels");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_points"].ToString()))
					{
						list.Add("wired_give_points");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_rank"].ToString()))
					{
						list.Add("wired_give_rank");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_respect"].ToString()))
					{
						list.Add("wired_give_respect");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_handitem"].ToString()))
					{
						list.Add("wired_give_handitem");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_alert"].ToString()))
					{
						list.Add("wired_give_alert");
					}
					if (Phoenix.smethod_3(dataRow["wired_cnd_roomusers"].ToString()))
					{
						list.Add("wired_cnd_roomusers");
					}
					if (Phoenix.smethod_3(dataRow["wired_cnd_userhasachievement"].ToString()))
					{
						list.Add("wired_cnd_userhasachievement");
					}
					if (Phoenix.smethod_3(dataRow["wired_cnd_userhasbadge"].ToString()))
					{
						list.Add("wired_cnd_userhasbadge");
					}
					if (Phoenix.smethod_3(dataRow["wired_cnd_userhasvip"].ToString()))
					{
						list.Add("wired_cnd_userhasvip");
					}
					if (Phoenix.smethod_3(dataRow["wired_cnd_userhaseffect"].ToString()))
					{
						list.Add("wired_cnd_userhaseffect");
					}
					if (Phoenix.smethod_3(dataRow["wired_cnd_userrank"].ToString()))
					{
						list.Add("wired_cnd_userrank");
					}
					if (Phoenix.smethod_3(dataRow["wired_cnd_usercredits"].ToString()))
					{
						list.Add("wired_cnd_usercredits");
					}
					if (Phoenix.smethod_3(dataRow["wired_cnd_userpixels"].ToString()))
					{
						list.Add("wired_cnd_userpixels");
					}
					if (Phoenix.smethod_3(dataRow["wired_cnd_userpoints"].ToString()))
					{
						list.Add("wired_cnd_userpoints");
					}
					if (Phoenix.smethod_3(dataRow["wired_cnd_usergroups"].ToString()))
					{
						list.Add("wired_cnd_usergroups");
					}
					if (Phoenix.smethod_3(dataRow["wired_cnd_wearing"].ToString()))
					{
						list.Add("wired_cnd_wearing");
					}
					if (Phoenix.smethod_3(dataRow["wired_cnd_carrying"].ToString()))
					{
						list.Add("wired_cnd_carrying");
					}
					this.dictionary_0.Add((uint)dataRow["userid"], list);
				}
			}
			dataTable = class6_0.ReadDataTable("SELECT * FROM permissions_ranks ORDER BY rank ASC;");
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					this.dictionary_3.Add((uint)dataRow["rank"], (int)dataRow["floodtime"]);
				}
				foreach (DataRow dataRow in dataTable.Rows)
				{
					List<string> list = new List<string>();
					if (Phoenix.smethod_3(dataRow["cmd_update_settings"].ToString()))
					{
						list.Add("cmd_update_settings");
					}
					if (Phoenix.smethod_3(dataRow["cmd_update_bans"].ToString()))
					{
						list.Add("cmd_update_bans");
					}
					if (Phoenix.smethod_3(dataRow["cmd_update_bots"].ToString()))
					{
						list.Add("cmd_update_bots");
					}
					if (Phoenix.smethod_3(dataRow["cmd_update_catalogue"].ToString()))
					{
						list.Add("cmd_update_catalogue");
					}
					if (Phoenix.smethod_3(dataRow["cmd_update_navigator"].ToString()))
					{
						list.Add("cmd_update_navigator");
					}
					if (Phoenix.smethod_3(dataRow["cmd_update_items"].ToString()))
					{
						list.Add("cmd_update_items");
					}
					if (Phoenix.smethod_3(dataRow["cmd_award"].ToString()))
					{
						list.Add("cmd_award");
					}
					if (Phoenix.smethod_3(dataRow["cmd_coords"].ToString()))
					{
						list.Add("cmd_coords");
					}
					if (Phoenix.smethod_3(dataRow["cmd_override"].ToString()))
					{
						list.Add("cmd_override");
					}
					if (Phoenix.smethod_3(dataRow["cmd_coins"].ToString()))
					{
						list.Add("cmd_coins");
					}
					if (Phoenix.smethod_3(dataRow["cmd_pixels"].ToString()))
					{
						list.Add("cmd_pixels");
					}
					if (Phoenix.smethod_3(dataRow["cmd_ha"].ToString()))
					{
						list.Add("cmd_ha");
					}
					if (Phoenix.smethod_3(dataRow["cmd_hal"].ToString()))
					{
						list.Add("cmd_hal");
					}
					if (Phoenix.smethod_3(dataRow["cmd_freeze"].ToString()))
					{
						list.Add("cmd_freeze");
					}
					if (Phoenix.smethod_3(dataRow["cmd_enable"].ToString()))
					{
						list.Add("cmd_enable");
					}
					if (Phoenix.smethod_3(dataRow["cmd_roommute"].ToString()))
					{
						list.Add("cmd_roommute");
					}
					if (Phoenix.smethod_3(dataRow["cmd_setspeed"].ToString()))
					{
						list.Add("cmd_setspeed");
					}
					if (Phoenix.smethod_3(dataRow["cmd_masscredits"].ToString()))
					{
						list.Add("cmd_masscredits");
					}
					if (Phoenix.smethod_3(dataRow["cmd_globalcredits"].ToString()))
					{
						list.Add("cmd_globalcredits");
					}
					if (Phoenix.smethod_3(dataRow["cmd_masspixels"].ToString()))
					{
						list.Add("cmd_masspixels");
					}
					if (Phoenix.smethod_3(dataRow["cmd_globalpixels"].ToString()))
					{
						list.Add("cmd_globalpixels");
					}
					if (Phoenix.smethod_3(dataRow["cmd_roombadge"].ToString()))
					{
						list.Add("cmd_roombadge");
					}
					if (Phoenix.smethod_3(dataRow["cmd_massbadge"].ToString()))
					{
						list.Add("cmd_massbadge");
					}
					if (Phoenix.smethod_3(dataRow["cmd_userinfo"].ToString()))
					{
						list.Add("cmd_userinfo");
					}
					if (Phoenix.smethod_3(dataRow["cmd_userinfo_viewip"].ToString()))
					{
						list.Add("cmd_userinfo_viewip");
					}
					if (Phoenix.smethod_3(dataRow["cmd_shutdown"].ToString()))
					{
						list.Add("cmd_shutdown");
					}
					if (Phoenix.smethod_3(dataRow["cmd_givebadge"].ToString()))
					{
						list.Add("cmd_givebadge");
					}
					if (Phoenix.smethod_3(dataRow["cmd_removebadge"].ToString()))
					{
						list.Add("cmd_removebadge");
					}
					if (Phoenix.smethod_3(dataRow["cmd_summon"].ToString()))
					{
						list.Add("cmd_summon");
					}
					if (Phoenix.smethod_3(dataRow["cmd_invisible"].ToString()))
					{
						list.Add("cmd_invisible");
					}
					if (Phoenix.smethod_3(dataRow["cmd_ban"].ToString()))
					{
						list.Add("cmd_ban");
					}
					if (Phoenix.smethod_3(dataRow["cmd_superban"].ToString()))
					{
						list.Add("cmd_superban");
					}
					if (Phoenix.smethod_3(dataRow["cmd_roomkick"].ToString()))
					{
						list.Add("cmd_roomkick");
					}
					if (Phoenix.smethod_3(dataRow["cmd_roomalert"].ToString()))
					{
						list.Add("cmd_roomalert");
					}
					if (Phoenix.smethod_3(dataRow["cmd_mute"].ToString()))
					{
						list.Add("cmd_mute");
					}
					if (Phoenix.smethod_3(dataRow["cmd_unmute"].ToString()))
					{
						list.Add("cmd_unmute");
					}
					if (Phoenix.smethod_3(dataRow["cmd_alert"].ToString()))
					{
						list.Add("cmd_alert");
					}
					if (Phoenix.smethod_3(dataRow["cmd_motd"].ToString()))
					{
						list.Add("cmd_motd");
					}
					if (Phoenix.smethod_3(dataRow["cmd_kick"].ToString()))
					{
						list.Add("cmd_kick");
					}
					if (Phoenix.smethod_3(dataRow["cmd_update_filter"].ToString()))
					{
						list.Add("cmd_update_filter");
					}
					if (Phoenix.smethod_3(dataRow["cmd_update_permissions"].ToString()))
					{
						list.Add("cmd_update_permissions");
					}
					if (Phoenix.smethod_3(dataRow["cmd_sa"].ToString()))
					{
						list.Add("cmd_sa");
					}
					if (Phoenix.smethod_3(dataRow["receive_sa"].ToString()))
					{
						list.Add("receive_sa");
					}
					if (Phoenix.smethod_3(dataRow["cmd_ipban"].ToString()))
					{
						list.Add("cmd_ipban");
					}
					if (Phoenix.smethod_3(dataRow["cmd_spull"].ToString()))
					{
						list.Add("cmd_spull");
					}
					if (Phoenix.smethod_3(dataRow["cmd_disconnect"].ToString()))
					{
						list.Add("cmd_disconnect");
					}
					if (Phoenix.smethod_3(dataRow["cmd_update_achievements"].ToString()))
					{
						list.Add("cmd_update_achievements");
					}
					if (Phoenix.smethod_3(dataRow["cmd_update_texts"].ToString()))
					{
						list.Add("cmd_update_texts");
					}
					if (Phoenix.smethod_3(dataRow["cmd_teleport"].ToString()))
					{
						list.Add("cmd_teleport");
					}
					if (Phoenix.smethod_3(dataRow["cmd_points"].ToString()))
					{
						list.Add("cmd_points");
					}
					if (Phoenix.smethod_3(dataRow["cmd_masspoints"].ToString()))
					{
						list.Add("cmd_masspoints");
					}
					if (Phoenix.smethod_3(dataRow["cmd_globalpoints"].ToString()))
					{
						list.Add("cmd_globalpoints");
					}
					if (Phoenix.smethod_3(dataRow["cmd_empty"].ToString()))
					{
						list.Add("cmd_empty");
					}
					if (Phoenix.smethod_3(dataRow["ignore_roommute"].ToString()))
					{
						list.Add("ignore_roommute");
					}
					if (Phoenix.smethod_3(dataRow["acc_anyroomrights"].ToString()))
					{
						list.Add("acc_anyroomrights");
					}
					if (Phoenix.smethod_3(dataRow["acc_anyroomowner"].ToString()))
					{
						list.Add("acc_anyroomowner");
					}
					if (Phoenix.smethod_3(dataRow["acc_supporttool"].ToString()))
					{
						list.Add("acc_supporttool");
					}
					if (Phoenix.smethod_3(dataRow["acc_chatlogs"].ToString()))
					{
						list.Add("acc_chatlogs");
					}
					if (Phoenix.smethod_3(dataRow["acc_enter_fullrooms"].ToString()))
					{
						list.Add("acc_enter_fullrooms");
					}
					if (Phoenix.smethod_3(dataRow["acc_enter_anyroom"].ToString()))
					{
						list.Add("acc_enter_anyroom");
					}
					if (Phoenix.smethod_3(dataRow["acc_restrictedrooms"].ToString()))
					{
						list.Add("acc_restrictedrooms");
					}
					if (Phoenix.smethod_3(dataRow["acc_unkickable"].ToString()))
					{
						list.Add("acc_unkickable");
					}
					if (Phoenix.smethod_3(dataRow["acc_unbannable"].ToString()))
					{
						list.Add("acc_unbannable");
					}
					if (Phoenix.smethod_3(dataRow["ignore_friendsettings"].ToString()))
					{
						list.Add("ignore_friendsettings");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_sql"].ToString()))
					{
						list.Add("wired_give_sql");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_badge"].ToString()))
					{
						list.Add("wired_give_badge");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_effect"].ToString()))
					{
						list.Add("wired_give_effect");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_award"].ToString()))
					{
						list.Add("wired_give_award");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_dance"].ToString()))
					{
						list.Add("wired_give_dance");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_send"].ToString()))
					{
						list.Add("wired_give_send");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_credits"].ToString()))
					{
						list.Add("wired_give_credits");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_pixels"].ToString()))
					{
						list.Add("wired_give_pixels");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_points"].ToString()))
					{
						list.Add("wired_give_points");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_rank"].ToString()))
					{
						list.Add("wired_give_rank");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_respect"].ToString()))
					{
						list.Add("wired_give_respect");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_handitem"].ToString()))
					{
						list.Add("wired_give_handitem");
					}
					if (Phoenix.smethod_3(dataRow["wired_give_alert"].ToString()))
					{
						list.Add("wired_give_alert");
					}
					if (Phoenix.smethod_3(dataRow["wired_cnd_roomusers"].ToString()))
					{
						list.Add("wired_cnd_roomusers");
					}
					if (Phoenix.smethod_3(dataRow["wired_cnd_userhasachievement"].ToString()))
					{
						list.Add("wired_cnd_userhasachievement");
					}
					if (Phoenix.smethod_3(dataRow["wired_cnd_userhasbadge"].ToString()))
					{
						list.Add("wired_cnd_userhasbadge");
					}
					if (Phoenix.smethod_3(dataRow["wired_cnd_userhasvip"].ToString()))
					{
						list.Add("wired_cnd_userhasvip");
					}
					if (Phoenix.smethod_3(dataRow["wired_cnd_userhaseffect"].ToString()))
					{
						list.Add("wired_cnd_userhaseffect");
					}
					if (Phoenix.smethod_3(dataRow["wired_cnd_userrank"].ToString()))
					{
						list.Add("wired_cnd_userrank");
					}
					if (Phoenix.smethod_3(dataRow["wired_cnd_usercredits"].ToString()))
					{
						list.Add("wired_cnd_usercredits");
					}
					if (Phoenix.smethod_3(dataRow["wired_cnd_userpixels"].ToString()))
					{
						list.Add("wired_cnd_userpixels");
					}
					if (Phoenix.smethod_3(dataRow["wired_cnd_userpoints"].ToString()))
					{
						list.Add("wired_cnd_userpoints");
					}
					if (Phoenix.smethod_3(dataRow["wired_cnd_usergroups"].ToString()))
					{
						list.Add("wired_cnd_usergroups");
					}
					if (Phoenix.smethod_3(dataRow["wired_cnd_wearing"].ToString()))
					{
						list.Add("wired_cnd_wearing");
					}
					if (Phoenix.smethod_3(dataRow["wired_cnd_carrying"].ToString()))
					{
						list.Add("wired_cnd_carrying");
					}
					this.dictionary_1.Add((uint)dataRow["rank"], list);
				}
			}
			dataTable = class6_0.ReadDataTable("SELECT * FROM permissions_vip;");
			if (dataTable != null)
			{
				Config.Boolean_8 = false;
				Config.Boolean_10 = false;
				Config.Boolean_11 = false;
				Config.Boolean_12 = false;
				Config.Boolean_13 = false;
				Config.Boolean_9 = false;
				foreach (DataRow dataRow in dataTable.Rows)
				{
					if (Phoenix.smethod_3(dataRow["cmdPush"].ToString()))
					{
						Config.Boolean_8 = true;
					}
					if (Phoenix.smethod_3(dataRow["cmdPull"].ToString()))
					{
						Config.Boolean_10 = true;
					}
					if (Phoenix.smethod_3(dataRow["cmdFlagme"].ToString()))
					{
						Config.Boolean_11 = true;
					}
					if (Phoenix.smethod_3(dataRow["cmdMimic"].ToString()))
					{
						Config.Boolean_12 = true;
					}
					if (Phoenix.smethod_3(dataRow["cmdMoonwalk"].ToString()))
					{
						Config.Boolean_13 = true;
					}
					if (Phoenix.smethod_3(dataRow["cmdFollow"].ToString()))
					{
						Config.Boolean_9 = true;
					}
				}
			}
			this.dictionary_5.Clear();
			this.dictionary_5.Add(PhoenixEnvironment.GetExternalText("pet_cmd_sleep"), 1);
			this.dictionary_5.Add(PhoenixEnvironment.GetExternalText("pet_cmd_free"), 2);
			this.dictionary_5.Add(PhoenixEnvironment.GetExternalText("pet_cmd_sit"), 3);
			this.dictionary_5.Add(PhoenixEnvironment.GetExternalText("pet_cmd_lay"), 4);
			this.dictionary_5.Add(PhoenixEnvironment.GetExternalText("pet_cmd_stay"), 5);
			this.dictionary_5.Add(PhoenixEnvironment.GetExternalText("pet_cmd_here"), 6);
			this.dictionary_5.Add(PhoenixEnvironment.GetExternalText("pet_cmd_dead"), 7);
			this.dictionary_5.Add(PhoenixEnvironment.GetExternalText("pet_cmd_beg"), 8);
			this.dictionary_5.Add(PhoenixEnvironment.GetExternalText("pet_cmd_jump"), 9);
			this.dictionary_5.Add(PhoenixEnvironment.GetExternalText("pet_cmd_stfu"), 10);
			this.dictionary_5.Add(PhoenixEnvironment.GetExternalText("pet_cmd_talk"), 11);
			this.dictionary_4.Clear();
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_about_name"), 1);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_alert_name"), 2);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_award_name"), 3);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_ban_name"), 4);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_buy_name"), 5);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_coins_name"), 6);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_coords_name"), 7);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_disablediagonal_name"), 8);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_emptyitems_name"), 9);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_empty_name"), 10);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_enable_name"), 11);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_flagme_name"), 12);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_follow_name"), 13);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_freeze_name"), 14);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_givebadge_name"), 15);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_globalcredits_name"), 16);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_globalpixels_name"), 17);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_globalpoints_name"), 18);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_hal_name"), 19);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_ha_name"), 20);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_invisible_name"), 21);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_ipban_name"), 22);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_kick_name"), 23);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_massbadge_name"), 24);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_masscredits_name"), 25);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_masspixels_name"), 26);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_masspoints_name"), 27);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_mimic_name"), 28);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_moonwalk_name"), 29);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_motd_name"), 30);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_mute_name"), 31);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_override_name"), 32);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_pickall_name"), 33);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_pixels_name"), 34);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_points_name"), 35);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_pull_name"), 36);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_push_name"), 37);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_redeemcreds_name"), 38);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_removebadge_name"), 39);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_ride_name"), 40);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_roomalert_name"), 41);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_roombadge_name"), 42);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_roomkick_name"), 43);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_roommute_name"), 44);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_sa_name"), 45);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_setmax_name"), 46);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_setspeed_name"), 47);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_shutdown_name"), 48);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_spull_name"), 49);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_summon_name"), 50);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_superban_name"), 51);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_teleport_name"), 52);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_unload_name"), 53);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_unmute_name"), 54);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_update_achievements_name"), 55);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_update_bans_name"), 56);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_update_bots_name"), 57);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_update_catalogue_name"), 58);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_update_filter_name"), 59);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_update_items_name"), 60);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_update_navigator_name"), 61);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_update_permissions_name"), 62);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_update_settings_name"), 63);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_userinfo_name"), 64);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_update_texts_name"), 65);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_disconnect_name"), 66);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_commands_name"), 67);
			this.dictionary_4.Add("about", 68);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_roominfo_name"), 69);
			this.dictionary_4.Add("neto737", 70);
			//this.dictionary_4.Add(PhoenixEnvironment.smethod_1("cmd_dance_name"), 71);
			//this.dictionary_4.Add(PhoenixEnvironment.smethod_1("cmd_rave_name"), 72);
			//this.dictionary_4.Add(PhoenixEnvironment.smethod_1("cmd_roll_name"), 73);
			//this.dictionary_4.Add(PhoenixEnvironment.smethod_1("cmd_control_name"), 74);
		    //this.dictionary_4.Add(PhoenixEnvironment.smethod_1("cmd_makesay_name"), 75);
            //this.dictionary_4.Add(PhoenixEnvironment.smethod_1("cmd_sitdown_name"), 76);
            this.dictionary_4.Add("dance", 71);
            this.dictionary_4.Add("rave", 72);
            this.dictionary_4.Add("roll", 73);
            this.dictionary_4.Add("control", 74);
            this.dictionary_4.Add("makesay", 75);
            this.dictionary_4.Add("sitdown", 76);
            this.dictionary_4.Add("exe", 77);
			this.dictionary_4.Add("giveitem", 79);
			this.dictionary_4.Add("sit", 80);
			this.dictionary_4.Add("dismount", 81);
			this.dictionary_4.Add("getoff", 82);
			this.dictionary_4.Add(PhoenixEnvironment.GetExternalText("cmd_emptypets_name"), 83);
			Logging.WriteLine("completed!");
			try
			{
				if (int.Parse(Phoenix.GetConfig().data["debug"]) == 1)
				{
					Logging.WriteLine("Commands loaded:" + this.dictionary_4.Count.ToString());
				}
			}
			catch
			{
			}
		}
		public bool method_1(uint uint_0, string string_0)
		{
			bool result;
			/*if (Phoenix.int_2 == 0)
			{
				result = false;
			}
			else*/
			{
				if (!this.method_7(uint_0))
				{
					result = false;
				}
				else
				{
					List<string> list = this.dictionary_1[uint_0];
					result = list.Contains(string_0);
				}
			}
			return result;
		}
		public int method_2(uint uint_0)
		{
			return this.dictionary_3[uint_0];
		}
		public bool method_3(uint uint_0)
		{
			return this.method_6(uint_0);
		}
		public bool method_4(uint uint_0, string string_0)
		{
			bool result;
			if (!this.method_6(uint_0))
			{
				result = false;
			}
			else
			{
				List<string> list = this.dictionary_0[uint_0];
				result = list.Contains(string_0);
			}
			return result;
		}
		public List<string> method_5(uint uint_0, uint uint_1)
		{
			List<string> result = new List<string>();
			if (this.method_6(uint_0))
			{
				result = this.dictionary_0[uint_0];
			}
			else
			{
				result = this.dictionary_1[uint_1];
			}
			return result;
		}
		public bool method_6(uint uint_0)
		{
			return this.dictionary_0.ContainsKey(uint_0);
		}
		public bool method_7(uint uint_0)
		{
			return this.dictionary_1.ContainsKey(uint_0);
		}
		public string method_8(uint uint_0)
		{
			return this.dictionary_2[uint_0];
		}
		public int method_9()
		{
			return this.dictionary_2.Count;
		}
		public void method_10()
		{
			this.dictionary_2.Clear();
			this.dictionary_0.Clear();
			this.dictionary_1.Clear();
			this.dictionary_3.Clear();
		}
		public bool method_11(string string_0, GameClient class16_0)
		{
			bool result;
			switch (string_0)
			{
			case "roomuserseq":
			case "roomuserslt":
			case "roomusersmt":
			case "roomusersmte":
			case "roomuserslte":
				if (class16_0.GetHabbo().HasFuse("wired_cnd_roomusers"))
				{
					result = true;
					return result;
				}
				break;
			case "userhasachievement":
			case "userhasntachievement":
				if (class16_0.GetHabbo().HasFuse("wired_cnd_userhasachievement"))
				{
					result = true;
					return result;
				}
				break;
			case "userhasbadge":
			case "userhasntbadge":
				if (class16_0.GetHabbo().HasFuse("wired_cnd_userhasbadge"))
				{
					result = true;
					return result;
				}
				break;
			case "userhasvip":
			case "userhasntvip":
				if (class16_0.GetHabbo().HasFuse("wired_cnd_userhasvip"))
				{
					result = true;
					return result;
				}
				break;
			case "userhaseffect":
			case "userhasnteffect":
				if (class16_0.GetHabbo().HasFuse("wired_cnd_userhaseffect"))
				{
					result = true;
					return result;
				}
				break;
			case "userrankeq":
			case "userrankmt":
			case "userrankmte":
			case "userranklt":
			case "userranklte":
				if (class16_0.GetHabbo().HasFuse("wired_cnd_userrank"))
				{
					result = true;
					return result;
				}
				break;
			case "usercreditseq":
			case "usercreditsmt":
			case "usercreditsmte":
			case "usercreditslt":
			case "usercreditslte":
				if (class16_0.GetHabbo().HasFuse("wired_cnd_usercredits"))
				{
					result = true;
					return result;
				}
				break;
			case "userpixelseq":
			case "userpixelsmt":
			case "userpixelsmte":
			case "userpixelslt":
			case "userpixelslte":
				if (class16_0.GetHabbo().HasFuse("wired_cnd_userpixels"))
				{
					result = true;
					return result;
				}
				break;
			case "userpointseq":
			case "userpointsmt":
			case "userpointsmte":
			case "userpointslt":
			case "userpointslte":
				if (class16_0.GetHabbo().HasFuse("wired_cnd_userpoints"))
				{
					result = true;
					return result;
				}
				break;
			case "usergroupeq":
			case "userisingroup":
				if (class16_0.GetHabbo().HasFuse("wired_cnd_usergroups"))
				{
					result = true;
					return result;
				}
				break;
			case "wearing":
			case "notwearing":
				if (class16_0.GetHabbo().HasFuse("wired_cnd_wearing"))
				{
					result = true;
					return result;
				}
				break;
			case "carrying":
			case "notcarrying":
				if (class16_0.GetHabbo().HasFuse("wired_cnd_carrying"))
				{
					result = true;
					return result;
				}
				break;
			}
			result = false;
			return result;
		}
		public bool method_12(string string_0, GameClient class16_0)
		{
			bool result;
			switch (string_0)
			{
			case "sql":
				if (class16_0.GetHabbo().HasFuse("wired_give_sql"))
				{
					result = true;
					return result;
				}
				break;
			case "badge":
				if (class16_0.GetHabbo().HasFuse("wired_give_badge"))
				{
					result = true;
					return result;
				}
				break;
			case "effect":
				if (class16_0.GetHabbo().HasFuse("wired_give_effect"))
				{
					result = true;
					return result;
				}
				break;
			case "award":
				if (class16_0.GetHabbo().HasFuse("wired_give_award"))
				{
					result = true;
					return result;
				}
				break;
			case "dance":
				if (class16_0.GetHabbo().HasFuse("wired_give_dance"))
				{
					result = true;
					return result;
				}
				break;
			case "send":
				if (class16_0.GetHabbo().HasFuse("wired_give_send"))
				{
					result = true;
					return result;
				}
				break;
			case "credits":
				if (class16_0.GetHabbo().HasFuse("wired_give_credits"))
				{
					result = true;
					return result;
				}
				break;
			case "pixels":
				if (class16_0.GetHabbo().HasFuse("wired_give_pixels"))
				{
					result = true;
					return result;
				}
				break;
			case "points":
				if (class16_0.GetHabbo().HasFuse("wired_give_points"))
				{
					result = true;
					return result;
				}
				break;
			case "rank":
				if (class16_0.GetHabbo().HasFuse("wired_give_rank"))
				{
					result = true;
					return result;
				}
				break;
			case "respect":
				if (class16_0.GetHabbo().HasFuse("wired_give_respect"))
				{
					result = true;
					return result;
				}
				break;
			case "handitem":
				if (class16_0.GetHabbo().HasFuse("wired_give_handitem"))
				{
					result = true;
					return result;
				}
				break;
			case "alert":
				if (class16_0.GetHabbo().HasFuse("wired_give_alert"))
				{
					result = true;
					return result;
				}
				break;
			}
			result = false;
			return result;
		}
	}
}
