using System.Threading.Tasks;

namespace FlexEngine.Essence
{
    public static class TimeAwaiter
    {
        private const int ticksInSecond = 1000;
        
        public static async Task WaitForSeconds(float seconds)
        {
            float ticks = seconds * ticksInSecond;
            int intTicks = (int)ticks;
            await Task.Delay(intTicks);
        }
    }
}

