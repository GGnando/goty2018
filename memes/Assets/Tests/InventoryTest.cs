using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using NUnit.Framework;
using System.Collections;

public class InventoryTest {

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode

    //Tests if inventory gets the same item that is picked up 
	[UnityTest]
	public IEnumerator InventoryUpdatesAddingItem() {
        // Use the Assert class to test conditions.
        // yield to skip a frame

        var inv = new GameObject().AddComponent<Inventory>(); //Creates inventory object

        Item itemPickedUp = (Item)Resources.Load("Items/ExampleItem"); //The item that is simulated being picked up is ExampleItem in the directory

        inv.Add(itemPickedUp); //Calls inventory method to add item

        var items = inv.getItems(); //Gets the list of items in inventory class

        var itemInSlot1 = items[0]; //Gets the first slot of inventory

        yield return null; //Waits a second

        Assert.AreEqual(itemInSlot1, itemPickedUp); //Asserts item picked up and item in 1st inv slot are same
	}

    //Checks to see if 1st slot in inv is empty after adding item, then removing it
    [UnityTest]
    public IEnumerator InventoryUpdatesRemovingItem()
    {
        var inv = new GameObject().AddComponent<Inventory>();

        Item itemPickedUp = (Item)Resources.Load("Items/ExampleItem");

        inv.Add(itemPickedUp);

        inv.Remove(itemPickedUp);

        var items = inv.getItems(); //Same as above

        bool exceptionCaught = false; //Exception should be thrown for going out of bounds of list, bool to track

        try
        {
            var itemInSlot1 = items[0]; //Try to get 1st item in empty list
        }
        catch(System.Exception e)
        {
            exceptionCaught = true; //Means successfuly do not have item in inv
        }

        yield return null;

        Assert.IsTrue(exceptionCaught); //Asserts error was thrown
    }

    //Checks to see if 1st slot in inv is empty after adding item, then removing it
    [UnityTest]
    public IEnumerator InventoryCount()
    {
        var inv = new GameObject().AddComponent<Inventory>();

        Item itemPickedUp = (Item)Resources.Load("Items/ExampleItem");

        inv.Add(itemPickedUp);  //Same as above

        int itemCount = inv.items.Count; //Item count for inventory should be 1

        yield return null;

        Assert.AreEqual(itemCount, 1); //Asserts item count of inv == 1
    }

    //Deletes everything created
    [TearDown]
    public void AfterEveryTest()
    {
        foreach(var GameObject in GameObject.FindObjectsOfType<Inventory>())
        {
            Object.Destroy(GameObject);
        }

        foreach (var GameObject in GameObject.FindObjectsOfType<Item>())
        {
            Object.Destroy(GameObject);
        }
    }
}
