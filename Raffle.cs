using System;
using System.Collections.Generic;
using System.Linq;

namespace Pinball
{
    public class Raffle
    {
        public static IState Start() => new NoEntries();

        public static IState Enter(IState state, string entry) =>
            state is NoEntries ? new HasEntries(new HashSet<string>(new [] { entry })) :
            state is HasEntries current && 
            current.Entries is HashSet<string> entries &&
            entries.Add(entry) ? new HasEntries(entries) :
            state;

        public static IState PickWinner(IState state, int seed) =>
            state is HasEntries current && current.Entries.Count > 0 ?
            (IState)new HasWinner(current.Entries.ElementAt(new Random(seed).Next(0, current.Entries.Count))) :
            new NoWinners();

        public interface IState
        {
            T Accept<T>(IStateVisitor<T> visitor);
        }

        public interface IStateVisitor<T>
        {
            T NoEntries();

            T HasEntries(HashSet<string> entries);

            T NoWinners();
            
            T HasWinner(string winner);

            T HasWinners(HashSet<string> winners);
        }

        public class NoEntries : IState
        {
            public T Accept<T>(IStateVisitor<T> visitor) => visitor.NoEntries();
        }

        public class HasEntries : IState
        {
            public HashSet<string> Entries { get; private set; }

            public HasEntries(HashSet<string> entries)
            {
                Entries = entries;
            }

            public T Accept<T>(IStateVisitor<T> visitor) => visitor.HasEntries(Entries);
        }

        public class NoWinners : IState
        {
            public T Accept<T>(IStateVisitor<T> visitor) => visitor.NoWinners();
        }

        public class HasWinner : IState
        {
            public string Winner { get; private set; }

            public HasWinner(string winner)
            {
                Winner = winner;
            }

            public T Accept<T>(IStateVisitor<T> visitor) => visitor.HasWinner(Winner);
        }
        

        public class HasWinners : IState
        {
            public HashSet<string> Winners { get; private set; }

            public HasWinners(HashSet<string> winners)
            {
                Winners = winners;
            }

            public T Accept<T>(IStateVisitor<T> visitor) => visitor.HasWinners(Winners);
        }
    }
}
