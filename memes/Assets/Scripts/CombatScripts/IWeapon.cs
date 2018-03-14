using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon {
    Animator animator { get; set; }
    void PerfromAttack(Animator animator);

    void PerformAttackEnd(Animator animator);

    List<BonusStat> GetStats();

    void SetStats(List<BonusStat> newStats);
}
