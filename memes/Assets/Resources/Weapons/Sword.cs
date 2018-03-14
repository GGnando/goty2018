using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon {
    List<BonusStat> swordStats;
    bool isAttacking;
    Animator swordAnimator;

    public Animator animator {
        get {
            return swordAnimator;
        }

        set {
            this.swordAnimator= value;
        }
    }

    public Sword() {
        
    }

    public void PerfromAttack(Animator animator) {
        animator.SetBool("isAttacking",true);
    }
    public void PerformAttackEnd(Animator animator) {
        animator.SetBool("isAttacking", false);
    }
    public List<BonusStat> GetStats() {
        return swordStats;
    }

    public void SetStats(List<BonusStat> newStats) {
        swordStats = newStats;
    }
    void OnTriggerEnter(Collider hitObject) {
        if(hitObject.tag == "Enemy") {
            hitObject.GetComponent<IEnemy>().TakeDamage(swordStats[(int)StatType.Attack].bonus);
            Debug.Log("did" + swordStats[(int)StatType.Attack].bonus + " damage");
        }
 
    }
}
