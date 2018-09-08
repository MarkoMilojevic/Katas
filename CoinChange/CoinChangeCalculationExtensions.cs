using System;
using System.Collections.Generic;
using System.Linq;
using CoinChange.Functional;

namespace CoinChange
{
    public static class CoinChangeCalculationExtensions
    {
        public static Option<IEnumerable<Coin>> ChangeFor(this IEnumerable<Coin> coins, int amount) =>
            CalculateChange(new ChangeCalculationState(coins, amount));

        private static Option<IEnumerable<Coin>> CalculateChange(ChangeCalculationState state) =>
            state.IsChangePaidOut
                ? new Some<IEnumerable<Coin>>(state.CalculatedChange)
                : state.CoinBeingProcessed
                       .Map(coin =>
                       {
                           state.UseAsMuchAsPossible(coin);

                           return CalculateChange(state.ForNextCoin())
                               .TryReduce(() => Backtrack(state));
                       })
                       .Reduce(None.Value);

        private static Option<IEnumerable<Coin>> Backtrack(ChangeCalculationState state) =>
            state.CoinBeingProcessed
                 .Map(coin =>
                 {
                     if (!state.IsUsed(coin))
                         return None.Value;

                     state.Unuse(coin);

                     return CalculateChange(state.ForNextCoin())
                         .TryReduce(() => Backtrack(state));
                 })
                 .Reduce(None.Value);

        private class ChangeCalculationState
        {
            private int Remaining { get; set; }
            private int CoinIndex { get; }
            private IDictionary<Coin, int> CoinsByCount { get; }
            private List<Coin> UsedCoins { get; }

            public bool IsChangePaidOut => Remaining == 0;
            public Option<Coin> CoinBeingProcessed => CoinIndex < Coins.Count ? (Option<Coin>) Coins.HighestToLowest[CoinIndex] : None.Value;
            public IEnumerable<Coin> CalculatedChange => UsedCoins;

            public ChangeCalculationState(IEnumerable<Coin> coins, int amount)
            {
                Remaining = amount;
                CoinsByCount = coins
                               .GroupBy(coin => coin)
                               .ToDictionary(group => group.Key, group => group.Count());

                CoinIndex = 0;
                UsedCoins = new List<Coin>();
            }

            private ChangeCalculationState(int remaining, IDictionary<Coin, int> coinsByCount, int coinIndex, List<Coin> usedCoins)
            {
                Remaining = remaining;
                CoinsByCount = coinsByCount;
                CoinIndex = coinIndex;
                UsedCoins = usedCoins;
            }

            public ChangeCalculationState ForNextCoin() =>
                new ChangeCalculationState(Remaining, CoinsByCount, CoinIndex + 1, UsedCoins);
            
            public bool IsUsed(Coin coin) =>
                UsedCoins.Contains(coin);

            public void UseAsMuchAsPossible(Coin coin)
            {
                if (!CoinsByCount.ContainsKey(coin))
                    return;

                int numberOfTimesCoinCanBeUsed = Math.Min(CoinsByCount[coin], Remaining / coin);

                Remaining -= coin * numberOfTimesCoinCanBeUsed;
                CoinsByCount[coin] -= numberOfTimesCoinCanBeUsed;
                UsedCoins.AddRange(Enumerable.Repeat(coin, numberOfTimesCoinCanBeUsed));
            }

            public void Unuse(Coin coin)
            {
                if (!IsUsed(coin))
                    return;

                UsedCoins.Remove(coin);
                Remaining += coin;
                CoinsByCount[coin] += 1;
            }
        }
    }
}
