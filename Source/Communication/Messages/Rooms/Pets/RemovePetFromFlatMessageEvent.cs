using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Pets;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Rooms.Pets
{
	internal sealed class RemovePetFromFlatMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && !@class.Boolean_3 && (@class.AllowPet || @class.method_27(class16_0, true)))
			{
				uint uint_ = class18_0.PopWiredUInt();
				Class33 class2 = @class.method_48(uint_);
				if (class2 != null && class2.class15_0 != null && class2.class15_0.OwnerId == class16_0.GetHabbo().Id)
				{
					using (DatabaseClient class3 = Phoenix.GetDatabase().GetClient())
					{
						if (class2.class15_0.DBState == DatabaseUpdateState.NeedsInsert)
						{
							class3.AddParamWithValue("petname" + class2.class15_0.PetId, class2.class15_0.Name);
							class3.AddParamWithValue("petcolor" + class2.class15_0.PetId, class2.class15_0.Color);
							class3.AddParamWithValue("petrace" + class2.class15_0.PetId, class2.class15_0.Race);
							class3.ExecuteQuery(string.Concat(new object[]
							{
								"INSERT INTO `user_pets` VALUES ('",
								class2.class15_0.PetId,
								"', '",
								class2.class15_0.OwnerId,
								"', '0', @petname",
								class2.class15_0.PetId,
								", @petrace",
								class2.class15_0.PetId,
								", @petcolor",
								class2.class15_0.PetId,
								", '",
								class2.class15_0.Type,
								"', '",
								class2.class15_0.Expirience,
								"', '",
								class2.class15_0.Energy,
								"', '",
								class2.class15_0.Nutrition,
								"', '",
								class2.class15_0.Respect,
								"', '",
								class2.class15_0.CreationStamp,
								"', '",
								class2.class15_0.X,
								"', '",
								class2.class15_0.Y,
								"', '",
								class2.class15_0.Z,
								"');"
							}));
						}
						else
						{
							class3.ExecuteQuery(string.Concat(new object[]
							{
								"UPDATE user_pets SET room_id = '0', expirience = '",
								class2.class15_0.Expirience,
								"', energy = '",
								class2.class15_0.Energy,
								"', nutrition = '",
								class2.class15_0.Nutrition,
								"', respect = '",
								class2.class15_0.Respect,
								"' WHERE id = '",
								class2.class15_0.PetId,
								"' LIMIT 1; "
							}));
						}
						class2.class15_0.DBState = DatabaseUpdateState.Updated;
					}
					class16_0.GetHabbo().method_23().method_7(class2.class15_0);
					@class.method_6(class2.int_0, false);
					class2.uint_1 = 0u;
				}
			}
		}
	}
}
