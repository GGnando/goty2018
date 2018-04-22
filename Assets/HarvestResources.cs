using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HarvestResources : MonoBehaviour
{

    public int maxHarvestDistance = 3;
    private RaycastHit hit;
    private GameObject tree;
    private GameObject rock;

    public Text harvestText;

    private int choppingPower = 1;
    private int miningPower = 0;
    private int ironPower = 0;

    // Use this for initialization
    void Start()
    {
        harvestText.enabled = false;
    }
<<<<<<< HEAD

    // Update is called once per frame
    void Update()
    {
        int cp;
        int mp;
        int ip;
        UpdatePowers();
=======
	
	// Update is called once per frame
	void Update () {
        int cp;
        int mp;
        int ip;
		UpdatePowers();
>>>>>>> origin/ItemStuff
        cp = GetChoppingPower();
        mp = GetMiningPower();
        ip = GetIronPower();

        if (Input.GetMouseButtonDown(0)) // TODO: add && HasAxeEquipped
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 30f))
            {
                if (hit.collider.gameObject.tag == "Tree")
                {
                    if (CheckIfInRange())
                    {
                        tree = hit.collider.transform.parent.gameObject;

                        tree.GetComponent<HarvestableTree>().ChopWood(choppingPower);
                        print("Tree has been hit. " + "Its current health is: " + tree.GetComponent<HarvestableTree>().GetTreeHealth());
                        Debug.Log("Power: " + cp);
<<<<<<< HEAD
                        for (int i = 0; i < cp; i++)
                        {
                            Inventory.instance.Add("Wood");
                        }
                        StartCoroutine(ShowMessage("+" + cp + " Wood", 0.5f));
=======
                        for(int i = 0; i < cp; i++){    
                            Inventory.instance.Add("Wood");
                        }
                        StartCoroutine(ShowMessage("+" + cp +" Wood", 0.5f));
>>>>>>> origin/ItemStuff
                        if (tree.GetComponent<HarvestableTree>().GetTreeHealth() <= 0)
                        {
                            tree.SetActive(false);
                        }
                    }
                }
                else if (hit.collider.gameObject.tag == "Rock")
                {
                    if (CheckIfInRange())
                    {
                        rock = hit.collider.gameObject;

                        rock.GetComponent<HarvestableRock>().MineRock(miningPower);
                        print("Rock has been hit. " + "Its current health is: " + rock.GetComponent<HarvestableRock>().GetRockHealth());
<<<<<<< HEAD
                        for (int i = 0; i < mp; i++)
                        {
                            Inventory.instance.Add("Stone");
                            StartCoroutine(ShowMessage("+1 Stone", 0.5f));
                        }
                        for (int i = 0; i < ip; i++)
                        {
=======
                        for(int i = 0; i < mp; i++){    
                            Inventory.instance.Add("Stone");
                            StartCoroutine(ShowMessage("+1 Stone", 0.5f));
                        }
                        for(int i = 0; i <  ip; i++){
>>>>>>> origin/ItemStuff
                            Inventory.instance.Add("Iron");
                            StartCoroutine(ShowMessage("+1 Iron", 0.5f));
                        }
                        if (rock.GetComponent<HarvestableRock>().GetRockHealth() <= 0)
                        {
                            rock.SetActive(false);
                        }
                    }
                }


            }



        }

    }

    private bool CheckIfInRange()
    {
        if (Vector3.Distance(transform.position, hit.point) > maxHarvestDistance)
            return false;
        else
            return true;
    }

    public int GetChoppingPower() { return choppingPower; }
    public void SetChoppingPower(int newPower) { choppingPower = newPower; }
    public int GetMiningPower() { return miningPower; }
    public void SetMiningPower(int newPower) { miningPower = newPower; }
    public int GetIronPower() { return ironPower; }
    public void SetIronPower(int newPower) { ironPower = newPower; }

<<<<<<< HEAD
    public void UpdatePowers()
    {
        if (Inventory.instance.currentWeapon == null)
        {
=======
    public void UpdatePowers(){
        if (Inventory.instance.currentWeapon == null){
>>>>>>> origin/ItemStuff
            return;
        }
        Debug.Log(Inventory.instance.currentWeapon.name);
        SetChoppingPower(Inventory.instance.currentWeapon.woodPower);
        SetMiningPower(Inventory.instance.currentWeapon.stonePower);
        SetIronPower(Inventory.instance.currentWeapon.ironPower);
    }

    IEnumerator ShowMessage(string message, float delay)
    {
        harvestText.text = message;
        harvestText.gameObject.transform.localPosition = new Vector3(Random.Range(-40.0f, 40.0f), Random.Range(-40.0f, 40.0f));
        harvestText.enabled = true;
        yield return new WaitForSeconds(delay);
        harvestText.enabled = false;
    }
}
