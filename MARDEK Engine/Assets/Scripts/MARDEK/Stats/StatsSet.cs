using System;
using System.Collections.Generic;

namespace MARDEK.Stats
{
    [System.Serializable]
    public class StatsSet : IStats
    {
        public StatsSet(){
            intStats = new List<StatHolder<int, StatOfType<int>>>();
            floatStats = new List<StatHolder<float, StatOfType<float>>>();
        }
        public List<StatHolder<int, StatOfType<int>>> intStats;
        public List<StatHolder<float, StatOfType<float>>> floatStats;

        public StatHolder<T, StatOfType<T>> GetStat<T>(StatOfType<T> stat)
        {
            if (typeof(T) == typeof(int))
                return GetStatFromList(stat as StatOfType<int>, intStats) as StatHolder<T, StatOfType<T>>;
            if (typeof(T) == typeof(float))
                return GetStatFromList(stat as StatOfType<float>, floatStats) as StatHolder<T, StatOfType<T>>;
            return null;
        }

        public void ModifyStat<T>(StatOfType<T> stat, float delta)
        {
            if (typeof(T) == typeof(int))
                (GetStat(stat) as StatHolder<int, StatOfType<int>>).Value += (int)delta;
            if (typeof(T) == typeof(float))
                (GetStat(stat) as StatHolder<float, StatOfType<float>>).Value += delta;
        }

        private StatHolder<T, StatOfType<T>> GetStatFromList<T>(StatOfType<T> stat, List<StatHolder<T, StatOfType<T>>> statList)
        {
            foreach (var statusHolder in statList)
                if (statusHolder.statusEnum == stat)
                    return statusHolder as StatHolder<T, StatOfType<T>>;
            return new StatHolder<T, StatOfType<T>>(stat);
        }
    }
}