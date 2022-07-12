# stream-games

## Setting up Streamer.bot

Create a an "Execute Code" sub-action (set to 'Keep Instance Alive') with the following code block:

```
using System;
using System.Collections.Generic;

public class CPHInline
{
	public static Dictionary<string,Func<ValueTuple>> functions;

	public bool Roll()
	{
		functions["roll"]?.Invoke();
		return true;
	}

	public bool Execute()
	{
			CPH.LogInfo("Start here");
		    var assembly = System.Reflection.Assembly.LoadFile(
"C:\\Users\\Pinball\\source\\repos\\stream-games\\bin\\Debug\\net472\\stream-games.dll");

			CPH.LogInfo("Found assembly " + assembly.FullName);

            var type = assembly.GetType("Pinball.StreamerBotLoader");
			CPH.LogInfo("Found type " + type.FullName);

            var method = type.GetMethod("Start");
			CPH.LogInfo("Found method " + method);

            functions = method.Invoke(null, new object[] { CPH }) as Dictionary<string,Func<ValueTuple>>;
			CPH.LogInfo("Result " + functions);

			CPH.SendMessage($"Initialized with {functions}", bot: true);

            return true;
	}
}
```

Now the action will execute any code in the `Start` method.

Giving the action a name will allow you to reference the `Roll` method from a separate sub-action (after initialization).
