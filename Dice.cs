using System;
using System.Collections.Generic;
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
            string user = "You";

            Proxy.SendMessage($"{user} rolled a d20: and got a {diceResult}!", bot: true);

            return ValueTuple.Create();
        }

        public static ValueTuple RollD20(InlineInvokeProxy proxy, Dictionary<string,object> args)
        {
            var random = new Random();
            var diceResult = random.Next(1, 21);
            string user = args != null && args.ContainsKey("user") ? args["user"]?.ToString() : "You";

            proxy.SendMessage($"{user} rolled a d20: and got a {diceResult}!", bot: true);

            return ValueTuple.Create();
        }
    }
}
