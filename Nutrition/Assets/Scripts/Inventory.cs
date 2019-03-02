using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory : MonoBehaviour {

    public GameObject food;

    //TODO: change later when have added all the food details like sprite and nutritional content
    //for now name of food is key and value is its calories
    //for later, name of food is key, will store sprite/img and stat values in object array as dict value

    Dictionary<string, int> items = new Dictionary<string, int>();
    public static Inventory instance;

    void Start () {
       //not sure about this
        food = GameObject.FindGameObjectWithTag("food");
        instance = this;
	}

    public void addItem(string food)
    {
        //TODO: add the name of the item and its list of information
        //only add if the item is in the dictionary!!! 
        items.Add(food, dict[food]);
        Debug.Log("added item: " + items[food]);
    }

    //TODO: if the user wants to delete things
    public void removeItem(GameObject food)
    {
        //add the name of the item and its list of information (if in inventory)
        items.Remove(food.name);
    }


    // Update is called once per frame
    void Update () {
		
	}


    // our "data base :P" of food, their sprites and stats
    Dictionary<string, int> dict = new Dictionary<string, int>()
    {
        {"Bun", 20 },
        {"Tomato", 50 },
        {"Lettuce", 15 },
        {"Meat", 300 },
        {"Cheese", 150 },
        {"Apple", 75 }
    };
}
