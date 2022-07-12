using System;
using System.Collections.Generic;
using Plugins;

namespace Pinball
{
    public static class StreamerBotLoader
    {
        public static Dictionary<string,Func<ValueTuple>> Start(InlineInvokeProxy CPH)
        {
            CPH.LogInfo($"Logging from {nameof(StreamerBotLoader)}");
            
            var dice = new Dice(CPH);

            return new Dictionary<string,Func<ValueTuple>>
            {
                { "roll", dice.D20 }
            };
        }
    }
}
