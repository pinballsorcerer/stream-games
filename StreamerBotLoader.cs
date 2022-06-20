using System;
using Plugins;

namespace Pinball
{
    public static class StreamerBotLoader
    {
        public static ValueTuple Start(InlineInvokeProxy CPH)
        {
            CPH.LogInfo($"Logging from {nameof(StreamerBotLoader)}");

            return ValueTuple.Create();
        }
    }
}
