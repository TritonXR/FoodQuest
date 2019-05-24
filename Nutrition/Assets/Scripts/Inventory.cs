using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory : MonoBehaviour {

    public GameObject food;
    public GameObject panelImage;

    //TODO: change later when have added all the food details like sprite and nutritional content
    //for now name of food is key and value is its calories
    //for later, name of food is key, will store sprite/img and stat values in object array as dict value

    //call Inventory.updateFood()
    //generate random number
    //go into conditional, 
    //if not in inventory yet, enable,
    //if it is then increase the count. 


    Dictionary<string, int> items = new Dictionary<string, int>();
    //public static Inventory instance;

    void Start () {
       //not sure about this
        //food = GameObject.FindGameObjectWithTag("food");
        //instance = this;
	}

    void OnCollisionEnter(Collision otherObj)
    {

        if (otherObj.gameObject.tag == "Weapon")
        {

            Debug.Log("food is destroyed!!!!!!!!!!!!!!!!!!!");
            food.SetActive(false);
            Destroy(food);
            Debug.Log("food is destroyed " + food.activeSelf);
            addItem();
        }
    }

    public string pickRandomItem()
    {
        //generate random number and choose an item to add 
        return "apple";
    }

    
    public void addItem()
    {
        //if the item has never been added
        string foodName = pickRandomItem();
        if ((items.ContainsKey(foodName)))
        {
            Debug.Log("incrementing item");
            items[foodName]++;
        }
        else if ((!items.ContainsKey(foodName))) {
            //add the sprite
            Debug.Log("adding item");
            //activate panel for first time
            panelImage.SetActive(true);
            items.Add(foodName, 1);
        }
        //if the item is already in it


       
    }

    //TODO: if the user wants to delete things
    public void removeItem(GameObject food)
    {
        //add the name of the item and its list of information (if in inventory)
       // items.Remove(food.name);
    }


    // Update is called once per frame
    void Update () {
		
	}


    // our "data base :P" of food, their sprites and stats
    //Dictionary<string, int> foodsList = new Dictionary<string, int>()
    //{
    //    {"Bun", 20 },
    //    {"Tomato", 50 },
    //    {"Lettuce", 15 },
    //    {"Meat", 300 },
    //    {"Cheese", 150 },
    //    {"Apple", 75 }
    //};
}
