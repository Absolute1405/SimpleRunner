using Runner.Player;

namespace Runner.Boosters
{
    public class HealthBooster : BoosterBase
    {
        protected override void OnBoosterPicked(IPlayerInteraction player)
        {
            player.OnHealthBoosterTriggered();
        }
    }
}

