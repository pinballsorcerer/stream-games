using System;
using System.Collections.Generic;
using Pinball;

public partial class CPHInline
{
	public static Raffle.IState RaffleState { get; set; }

	public bool StartRaffle()
	{
		RaffleState = Raffle.Start();
		CPH.SendMessage("Raffle started, enter with !enter", bot: true);
		return true;
	}

	public bool EnterRaffle()
	{
		if (RaffleState == null)
		{
			CPH.SendMessage("Raffle has not started yet; please wait for the streamer to start it", bot: true);
			return true;
		}

        const string UserKey = "user";

        if (args != null && args.ContainsKey(UserKey) && args[UserKey] is string user)
		{
			RaffleState = Raffle.Enter(RaffleState, user);
		}

		return true;
	}

	public bool StatusRaffle()
	{
		if (RaffleState == null)
		{
			CPH.SendMessage("Raffle has not started yet", bot: true);
			return true;
		}
		else
		{
			string message = RaffleState.Accept(default(StatusVisitor));
			CPH.SendMessage(message, bot: true);
			return true;
		}
	}

	public bool PickRaffle()
	{
		RaffleState = Raffle.PickWinner(RaffleState, DateTime.Now.Millisecond);
		string message = RaffleState.Accept(default(StatusVisitor));
		CPH.SendMessage(message, bot: true);
		return true;
	}

	public bool Execute()
	{
        return true;
	}

    private struct StatusVisitor : Raffle.IStateVisitor<string>
    {
        public string HasEntries(HashSet<string> entries) =>
			$"Raffle currently has {entries.Count} entrants";

        public string HasWinner(string winner) =>
			$"Raffle has ended with winner: {winner}";

        public string HasWinners(HashSet<string> winners) =>
			$"Raffle has ended with {winners.Count} winners";

        public string NoEntries() =>
			$"Raffle has started, but no one has entered it";

        public string NoWinners() =>
			$"The raffle ended with no winners";
    }
}
