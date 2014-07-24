using System;
using System.Collections.Generic;
using CupCake;
using CupCake.Messages.Receive;
using CupCake.Players;
using PlayerIOClient;

namespace EEAntiGhost
{
    public class AntiGhost : CupCakeMuffin
    {
        private readonly List<int> _unknownLeftIds = new List<int>();
 
        protected override void Enable()
        {
            this.Events.Bind<LeftReceiveEvent>(this.OnLeft);
            this.Events.Bind<AddPlayerEvent>(this.OnAdd);
        }

        private void OnLeft(object sender, LeftReceiveEvent e)
        {
            Player player;
            this.PlayerService.TryGetPlayer(e.UserId, out player);
            if (player == null)
            {
                this._unknownLeftIds.Add(e.UserId);
            }
        }

        private void OnAdd(object sender, AddPlayerEvent e)
        {
            if (this._unknownLeftIds.Remove(e.Player.UserId))
            {
                var message = Message.Create(String.Empty, e.Player.UserId);
                var ev = new LeftReceiveEvent(message);

                this.SynchronizePlatform.Do(() =>
                {
                    this.Events.Raise<ReceiveEvent>(ev);
                    this.Events.Raise(ev);
                });
            }
        }
    }
}
