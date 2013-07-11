using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Catalog
{
    internal sealed class GetGiftWrappingConfigurationEvent : Interface
    {
        public void imethod_0(GameClient class16_0, ClientMessage class18_0)
        {
            ServerMessage gClass = new ServerMessage(620u);
            for (int i = 187; i < 191; i++)
            {
                gClass.AppendInt32(i);
            }
            gClass.AppendInt32(187);
            gClass.AppendInt32(188);
            gClass.AppendInt32(189);
            gClass.AppendInt32(190);
            gClass.AppendInt32(191);
            class16_0.method_14(gClass);
        }
    }
}