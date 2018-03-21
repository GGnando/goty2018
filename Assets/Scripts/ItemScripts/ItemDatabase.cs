using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json; //Reference to namespace for json file to use methods

public class ItemDatabase : MonoBehaviour {

    //Same singleton way as inventory
    public static ItemDatabase instance;

    //Private list of our items
    private List<Item> items;

	void Start () {
		if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else{
            instance = this;
        }

        buildDatabase();
	}
	
	public void buildDatabase()
    {
        //Deserialize json file into a collection of items
        items = JsonConvert.DeserializeObject<List<Item>>(Resources.Load<TextAsset>("ItemDatabase/Items").ToString());
        Debug.Log(getItem("Iron Sword").stats[0].name);
    }

    //Get item by name
    public Item getItem(string wantedItemName)
    {
        //Loop through each item and get item of name
        foreach(Item item in items)
        {
            if (item.name.Equals(wantedItemName)) {
                return item;
            }
        }

        return null; //No item found
    }
}
