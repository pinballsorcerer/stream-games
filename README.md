# stream-games

## Setting up Streamer.bot

Create a an "Execute Code" sub-action with the following code block:

```
using System;

public class CPHInline
{
    public bool Execute()
    {
        CPH.LogInfo("Start here");
        var assembly = System.Reflection.Assembly.LoadFile(
        "C:\\path\\to\\repos\\stream-games\\bin\\Debug\\net472\\stream-games.dll");

        CPH.LogInfo("Found assembly " + assembly.FullName);

        var type = assembly.GetType("Pinball.StreamerBotLoader");
        CPH.LogInfo("Found type " + type.FullName);

        var method = type.GetMethod("Start");
        CPH.LogInfo("Found method " + method);

        var result = method.Invoke(null, new object[] { CPH });
        CPH.LogInfo("Result " + result);
        return true;
    }
}
```

Now the action will execute any code in the `Start` method.
