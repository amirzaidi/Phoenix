using System;
using System.Data;
using System.Threading.Tasks;
using Phoenix.HabboHotel.Misc;
using Phoenix.Core;
using Phoenix.HabboHotel.Navigators;
using Phoenix.HabboHotel.Catalogs;
using Phoenix.HabboHotel.Support;
using Phoenix.HabboHotel.Roles;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Items;
using Phoenix.HabboHotel.Rooms;
using Phoenix.HabboHotel.Advertisements;
using Phoenix.HabboHotel.Achievements;
using Phoenix.HabboHotel.RoomBots;
using Phoenix.HabboHotel.Quests;
using Phoenix.Util;
using Phoenix.Storage;
namespace Phoenix.HabboHotel
{
	internal sealed class Game
	{
		private GameClientManager ClientManager;
		private ModerationBanManager BanManager;
		private RoleManager RoleManager;
		private HelpTool HelpTool;
		private Catalog Catalog;
		private Navigator Navigator;
		private ItemManager ItemManager;
		private RoomManager RoomManager;
		private AdvertisementManager AdvertisementManager;
		private PixelManager PixelManager;
		private AchievementManager AchievementManager;
		private ModerationTool ModerationTool;
		private BotManager BotManager;
		private Task task_0;
		private NavigatorCache class276_0;
		private Marketplace Marketplace;
		private QuestManager QuestManager;
		private PhoenixEnvironment Environment;
		private Groups Groups;

		public Game(int conns)
		{
			this.ClientManager = new GameClientManager(conns);
			if (Phoenix.GetConfig().data["client.ping.enabled"] == "1")
			{
				this.ClientManager.method_10();
			}

			DateTime StartTime = DateTime.Now;
			Logging.Write("Connecting to database...");

			using (DatabaseClient adapter = Phoenix.GetDatabase().GetClient())
			{
				Logging.WriteLine("completed!");
				Phoenix.Game = this;
				this.method_17(adapter);
				this.BanManager = new ModerationBanManager();
				this.RoleManager = new RoleManager();
				this.HelpTool = new HelpTool();
				this.Catalog = new Catalog();
				this.Navigator = new Navigator();
				this.ItemManager = new ItemManager();
				this.RoomManager = new RoomManager();
				this.AdvertisementManager = new AdvertisementManager();
				this.PixelManager = new PixelManager();
				this.AchievementManager = new AchievementManager();
				this.ModerationTool = new ModerationTool();
				this.BotManager = new BotManager();
				this.Marketplace = new Marketplace();
				this.QuestManager = new QuestManager();
				this.Environment = new PhoenixEnvironment();
				this.Groups = new Groups();
				PhoenixEnvironment.smethod_0(adapter);
				this.BanManager.method_0(adapter);
				Config.String_5 = "FB3A78763D7819F39D79781F6F8DFCCD";
				this.RoleManager.Load(adapter);
				this.HelpTool.method_0(adapter);
				this.HelpTool.method_3(adapter);
				this.ModerationTool.method_1(adapter);
				this.ModerationTool.method_2(adapter);
				Config.String_5 = "B8AC48FA7DB791129E59CBA4BC2CC5DD";
				this.ItemManager.method_0(adapter);
				Config.String_5 = "7866151A40EEB2379D61F640B26ED23B";
				this.Catalog.method_0(adapter);
				this.Catalog.method_1();
				this.Navigator.method_0(adapter);
				Config.String_5 = Config.String_6;
				this.RoomManager.method_8(adapter);
				this.RoomManager.method_0();
				this.class276_0 = new NavigatorCache();
				this.AdvertisementManager.method_0(adapter);
				this.BotManager.method_0(adapter);
				Config.String_5 = Config.String_3;
				Config.String_5 = Config.String_6.Length.ToString();
				AchievementManager.smethod_0(adapter);
				this.PixelManager.method_0();
				ChatCommandHandler.smethod_0(adapter);
				Config.String_5 = Config.String_3.Length.ToString();
				this.QuestManager.method_0();
				Groups.smethod_0(adapter);
				this.method_0(adapter, 1);
			}
			this.task_0 = new Task(new Action(LowPriorityWorker.smethod_0));
			this.task_0.Start();
		}
		public void method_0(DatabaseClient DBClient, int int_0)
		{
			Logging.Write(PhoenixEnvironment.GetExternalText("emu_cleandb"));
			bool flag = true;
			try
			{
				if (int.Parse(Phoenix.GetConfig().data["debug"]) == 1)
				{
					flag = false;
				}
			}
			catch
			{
			}
			if (flag)
			{
				DBClient.ExecuteQuery("UPDATE users SET online = '0' WHERE online != '0'");
				DBClient.ExecuteQuery("UPDATE rooms SET users_now = '0' WHERE users_now != '0'");
				DBClient.ExecuteQuery("UPDATE user_roomvisits SET exit_timestamp = UNIX_TIMESTAMP() WHERE exit_timestamp <= 0");
				DBClient.ExecuteQuery(string.Concat(new object[]
				{
					"UPDATE server_status SET status = '",
					int_0,
					"', users_online = '0', rooms_loaded = '0', server_ver = '",
					Phoenix.PrettyVersion,
					"', stamp = UNIX_TIMESTAMP() LIMIT 1;"
				}));
			}
			Logging.WriteLine("completed!");
		}
		public void ContinueLoading()
		{
			if (this.task_0 != null)
			{
				this.task_0 = null;
			}
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				this.method_0(@class, 0);
			}
			if (this.GetClientManager() != null)
			{
				this.GetClientManager().method_6();
				this.GetClientManager().method_11();
			}
			if (this.GetPixelManager() != null)
			{
				this.PixelManager.KeepAlive = false;
			}
			this.ClientManager = null;
			this.BanManager = null;
			this.RoleManager = null;
			this.HelpTool = null;
			this.Catalog = null;
			this.Navigator = null;
			this.ItemManager = null;
			this.RoomManager = null;
			this.AdvertisementManager = null;
			this.PixelManager = null;
		}
		public GameClientManager GetClientManager()
		{
			return this.ClientManager;
		}
		public ModerationBanManager GetBanManager()
		{
			return this.BanManager;
		}
		public RoleManager GetRoleManager()
		{
			return this.RoleManager;
		}
		public HelpTool GetHelpTool()
		{
			return this.HelpTool;
		}
		public Catalog GetCatalog()
		{
			return this.Catalog;
		}
		public Navigator GetNavigator()
		{
			return this.Navigator;
		}
		public ItemManager GetItemManager()
		{
			return this.ItemManager;
		}
		public RoomManager GetRoomManager()
		{
			return this.RoomManager;
		}
		public AdvertisementManager GetAdvertisementManager()
		{
			return this.AdvertisementManager;
		}
		public PixelManager GetPixelManager()
		{
			return this.PixelManager;
		}
		public AchievementManager GetAchievementManager()
		{
			return this.AchievementManager;
		}
		public ModerationTool GetModerationTool()
		{
			return this.ModerationTool;
		}
		public BotManager GetBotManager()
		{
			return this.BotManager;
		}
		internal NavigatorCache method_15()
		{
			return this.class276_0;
		}
		public QuestManager GetQuestManager()
		{
			return this.QuestManager;
		}
		public void method_17(DatabaseClient class6_0)
		{
			Logging.Write("Loading your settings..");
			DataRow dataRow = class6_0.ReadDataRow("SELECT * FROM server_settings LIMIT 1");
			Config.Int32_4 = (int)dataRow["MaxRoomsPerUser"];
			Config.String_4 = (string)dataRow["motd"];
			Config.Int32_0 = (int)dataRow["timer"];
			Config.Int32_1 = (int)dataRow["credits"];
			Config.Int32_3 = (int)dataRow["pixels"];
			Config.Int32_2 = (int)dataRow["points"];
			Config.int_3 = (int)dataRow["pixels_max"];
			Config.int_5 = (int)dataRow["credits_max"];
			Config.int_4 = (int)dataRow["points_max"];
			Config.int_2 = (int)dataRow["MaxPetsPerRoom"];
			Config.int_0 = (int)dataRow["MaxMarketPlacePrice"];
			Config.int_1 = (int)dataRow["MarketPlaceTax"];
			Config.AntiDDoSOff = Phoenix.smethod_3(dataRow["enable_antiddos"].ToString());
			Config.Boolean_3 = Phoenix.smethod_3(dataRow["vipclothesforhcusers"].ToString());
			Config.Boolean_4 = Phoenix.smethod_3(dataRow["enable_chatlogs"].ToString());
			Config.Boolean_5 = Phoenix.smethod_3(dataRow["enable_cmdlogs"].ToString());
			Config.Boolean_6 = Phoenix.smethod_3(dataRow["enable_roomlogs"].ToString());
			Config.String_2 = (string)dataRow["enable_externalchatlinks"];
			Config.Boolean_2 = Phoenix.smethod_3(dataRow["enable_securesessions"].ToString());
			Config.Boolean_1 = Phoenix.smethod_3(dataRow["allow_friendfurnidrops"].ToString());
			Config.Boolean_0 = Phoenix.smethod_3(dataRow["enable_cmd_redeemcredits"].ToString());
			Config.bool_18 = Phoenix.smethod_3(dataRow["unload_crashedrooms"].ToString());
			Config.bool_19 = Phoenix.smethod_3(dataRow["ShowUsersAndRoomsInAbout"].ToString());
			Config.int_14 = (int)dataRow["idlesleep"];
			Config.int_15 = (int)dataRow["idlekick"];
			Config.bool_20 = Phoenix.smethod_3(dataRow["ip_lastforbans"].ToString());
			Logging.WriteLine("completed!");
		}
	}
}
