using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {
    public GameObject playerHand;
    public GameObject equippedWeapon;
    private CharacterStat characterStats;
    public IWeapon weapon;
    private Animator animator;

    // Use this for initialization
    void Start() {
        characterStats = GetComponent<CharacterStat>();
        animator = GetComponent<Animator>();
    }


    public void EquipWeapon(Item weapon) {
        if (equippedWeapon != null) {
            characterStats.RemoveStatBonus(this.weapon.GetStats());
            Destroy(equippedWeapon);
            animator.SetBool("swordEquipped", false);
        }
        else {
            equippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/Sword"), playerHand.transform.position, playerHand.transform.rotation);
            this.weapon = equippedWeapon.GetComponent<IWeapon>();
            this.weapon.SetStats(DummyList());
            equippedWeapon.transform.SetParent(playerHand.transform);
            characterStats.AddStatBonus(DummyList());
            equippedWeapon.transform.Rotate(90f,0f,0f);
            equippedWeapon.transform.localPosition = new Vector3(-.078f, .031f,.07f);
            animator.SetBool("swordEquipped", true);
            this.weapon.animator = animator;
        }

    }
    //Update is called once per frame
    void Update() {
        if (weapon != null) {
            weapon.PerformAttackEnd(animator);
            if (Input.GetKeyDown(KeyCode.O)) {
                weapon.PerfromAttack(animator);
            }
        }
    }
    public List<BonusStat> DummyList() {
        List<BonusStat> templist = new List<BonusStat>();
        templist.Add(new BonusStat(69, StatType.Attack, "attackonly", Modifier.Additive));
        templist.Add(new BonusStat(69, StatType.Ranged, "attackonly", Modifier.Additive));
        templist.Add(new BonusStat(69, StatType.Magic, "attackonly", Modifier.Additive));
        templist.Add(new BonusStat(69, StatType.Defense, "attackonly", Modifier.Additive));
        templist.Add(new BonusStat(69, StatType.Constitution, "attackonly", Modifier.Additive));
        templist.Add(new BonusStat(69, StatType.Vitality, "attackonly", Modifier.Additive));

        return templist;
    }
}
