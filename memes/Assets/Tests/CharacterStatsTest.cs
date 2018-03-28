using UnityEngine.TestTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tests {
    public class CharacterStatsTest {
        CharacterStat testStats;
        [UnityTest]
        public IEnumerator test() {
            var player = Resources.Load("Test_res/Player");
            CharacterStat testStats = new GameObject().AddComponent<Player>().playerStats;
            yield return null;
            testStats.AddStatBonus(tempBaseStat(50));
            yield return null;
            for (int i = 0; i < 6; ++i) {
                LogAssert.Equals(testStats.stats[i].getBaseValue(), 53);
            }
            testStats.RemoveStatBonus(tempBaseStat(50));
            yield return null;
            for (int i = 0; i < 6; ++i) {
                LogAssert.Equals(testStats.stats[i].getBaseValue(), 3);
            }
        }
        
        public List<BaseStat> tempBaseStat(int statValue) {
            List<BaseStat> templist = new List<BaseStat>();
            templist.Add(new BaseStat(StatType.Attack, 69, "Attack", "attackonly"));
            templist.Add(new BaseStat(StatType.Defense, 69, "Attack", "attackonly"));
            templist.Add(new BaseStat(StatType.Constitution, 69, "Attack", "attackonly"));
            templist.Add(new BaseStat(StatType.Vitality, 69, "Attack", "attackonly"));
            return templist;
        }

    }
}
    