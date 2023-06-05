using Runner.Player;

namespace Runner.Boosters
{
    public class InvulnerableBooster : BoosterBase
    {
        protected override void OnBoosterPicked(IPlayerInteraction player)
        {
            player.OnInvulnerableBoosterTriggered();
        }
    }
}

