using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory : MonoBehaviour {

    public GameObject food;
    //the actual image sprites to be displayed
    public static GameObject apple;
    public static GameObject fish;
    public static GameObject carrot;
    public static GameObject broc;
    public static GameObject grape;

    Dictionary<GameObject, int> items = new Dictionary<GameObject, int>();
    //public static Inventory instance;

    void Start () {
        //not sure about this
        //apple = GameObject.F
        //how to grab the foodz indGameObjectWithTag("food");
        
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

    public GameObject pickRandomItem()
    {
        //generate random number and choose an item to add 
        var randomInt = Random.Range(1, 6);
        var randomFood = foodsList[randomInt];
        return randomFood;
    }

    
    public void addItem()
    {
        //if the item has never been added
        GameObject foodName = pickRandomItem();
        if ((items.ContainsKey(foodName)))
        {
            Debug.Log("incrementing item");
            items[foodName]++;
        }
        //if the item is already in it
        else if ((!items.ContainsKey(foodName))) {
            //add the sprite
            Debug.Log("adding item");
            //activate panel for first time
            foodName = GameObject.Find(foodName.name);
            foodName.SetActive(true);
            items.Add(foodName, 1);
        }
   

       
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
    Dictionary<int, GameObject> foodsList = new Dictionary<int, GameObject>()
    {
        {1, apple},
        {2, fish},
        {3, carrot},
        {4, broc},
        {5, grape},
        //{"Bun", 20 },
        //{"Tomato", 50 },
        //{"Lettuce", 15 },
        //{"Meat", 300 },
        //{"Cheese", 150 },
        //{"Apple", 75 }
    };
}
