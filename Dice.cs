using System;
using Plugins;

namespace Pinball
{
    public class Dice
    {
        public Dice(InlineInvokeProxy proxy)
        {
            Proxy = proxy;
        }

        public InlineInvokeProxy Proxy { get; }

        public ValueTuple D20()
        {
            var random = new Random();
            var diceResult = random.Next(1, 21);

            Proxy.SendMessage($"You rolled a d20: and got a {diceResult}!", bot: true);

            return ValueTuple.Create();
        }
    }
}
