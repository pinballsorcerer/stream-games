# stream-games

## Setting up Streamer.bot

Create a an "Execute Code" sub-action (set to 'Keep Instance Alive') with the code from the `CPHInline.cs` file (not `.gen.cs`).

Now the action will execute any code in the `Start` method.

Giving the action a name will allow you to reference the `Roll` method from a separate sub-action (after initialization).
