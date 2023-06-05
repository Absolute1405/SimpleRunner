using Runner.Player;

namespace Runner.Boosters
{
    public class SpeedBooster : BoosterBase
    {
        protected override void OnBoosterPicked(IPlayerInteraction player)
        {
            player.OnSpeedBoosterTriggered();
        }
    }
}
