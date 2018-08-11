using System;
using System.Collections.Generic;
using System.Linq;

namespace CoinChange
{
    public static class CoinChangeCalculationExtensions
    {
        public static Option<IEnumerable<Coin>> ChangeFor(this IEnumerable<Coin> coins, int amount) =>
            ChangeFor(new ChangeCalculationState(coins, amount));

        private static Option<IEnumerable<Coin>> ChangeFor(ChangeCalculationState state)
        {
            if (state.IsPaidFully)
                return state.Result;

            return state.CoinBeingProcessed
                        .Map(coin =>
                        {
                            if (!state.IsAvailable(coin))
                                return ChangeFor(state.Next());

                            state.UseAsMuchAsPossibleOf(coin);

                            return ChangeFor(state.Next())
                                   .TryReduce(() => WithSmallerCoin(state.Next()))
                                   .TryReduce(() => WithBacktrack(coin, state));
                        })
                        .Reduce(None.Value);
        }
        
        private static Option<IEnumerable<Coin>> WithSmallerCoin(ChangeCalculationState state) =>
            state.CoinBeingProcessed
                 .Map(_ => ChangeFor(state.Next())
                            .TryReduce(() => WithSmallerCoin(state.Next())))
                 .Reduce(None.Value);

        private static Option<IEnumerable<Coin>> WithBacktrack(Coin coin, ChangeCalculationState state)
        {
            if (!state.IsUsed(coin))
                return None.Value;

            state.Unuse(coin);

            return ChangeFor(state.Next())
                   .TryReduce(() => WithBacktrack(coin, state));
        }

        private class ChangeCalculationState
        {
            private int Remaining { get; set; }
            private int CoinIndex { get; }
            private IDictionary<Coin, int> CoinsByCount { get; }

            public bool IsPaidFully => Remaining == 0;
            public Option<Coin> CoinBeingProcessed => CoinIndex < Coins.Count ? (Option<Coin>)Coins.AllCoinsHighestToLowest[CoinIndex] : None.Value;
            public List<Coin> Result { get; }

            public ChangeCalculationState(IEnumerable<Coin> coins, int amount)
            {
                Remaining = amount;
                CoinsByCount = coins
                               .GroupBy(coin => coin)
                               .ToDictionary(group => group.Key, group => group.Count());

                CoinIndex = 0;
                Result = new List<Coin>();
            }

            private ChangeCalculationState(int remaining, IDictionary<Coin, int> coinsByCount, int coinIndex, List<Coin> result)
            {
                Remaining = remaining;
                CoinsByCount = coinsByCount;
                CoinIndex = coinIndex;
                Result = result;
            }

            public ChangeCalculationState Next() =>
                new ChangeCalculationState(Remaining, CoinsByCount, CoinIndex + 1, Result);

            public bool IsAvailable(Coin coin) =>
                CoinsByCount.ContainsKey(coin);

            public bool IsUsed(Coin coin) =>
                Result.Contains(coin);

            public void UseAsMuchAsPossibleOf(Coin coin)
            {
                int availableNumberOfCoins = Math.Min(Remaining / coin, CoinsByCount[coin]);

                Remaining -= coin * availableNumberOfCoins;
                CoinsByCount[coin] = CoinsByCount[coin] - availableNumberOfCoins;
                Result.AddRange(Enumerable.Repeat(coin, availableNumberOfCoins));
            }

            public void Unuse(Coin coin)
            {
                Result.RemoveAt(Result.Count - 1);
                Remaining += coin;
                CoinsByCount[coin] = CoinsByCount[coin] + 1;
            }
        }
    }
}
