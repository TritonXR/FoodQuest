using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory : MonoBehaviour {

    public GameObject food;
    //the actual image sprites to be displayed
    public GameObject apple;
    public  GameObject fish;
    public  GameObject carrot;
    public  GameObject broc;
    public  GameObject grape;
    private GameObject randomFood;
    Dictionary<GameObject, int> items = new Dictionary<GameObject, int>();
    //public static Inventory instance;

    void Start () {
        //not sure about this
        //apple = GameObject.F
        //how to grab the foodz
        // findGameObjectWithTag("food");
        randomFood = null;

    }

    void OnCollisionEnter(Collision otherObj)
    {

        if (otherObj.gameObject.tag == "Weapon" || otherObj.gameObject.tag == "Rage Sword")
        {

            food.SetActive(true);
            Debug.Log("food is " + food.activeSelf);
            if (food != null)
            {
                Debug.Log("food is destroyed!!!!!!!!!!!!!!!!!!!");
                food.SetActive(false);
                //Destroy(food);
                //Debug.Log("food is destroyed " + food.activeSelf);
                addItem();
            }
        }
    }

    public GameObject pickRandomItem()
    {
        //generate random number and choose an item to add 
        var randomInt = Random.Range(1, 5);

        switch (randomInt)
        {
            case 1:
                randomFood = apple;
                break;
            case 2:
                randomFood = fish;
                break;
            case 3:
                randomFood = carrot;
                break;
            case 4:
                randomFood = broc;
                break;
            case 5:
                randomFood = grape;
                break;
        }
        return fish;


    }

    public bool CompareObjs(GameObject compareToEach)
    {

        foreach (var item in items.Keys)
        {
            if (compareToEach.GetInstanceID() == item.GetInstanceID())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }


    public void addItem()
    {
        //if the item has  been added
        GameObject foodName = pickRandomItem();
        Debug.Log("item chosen: " + foodName.name);
        if (CompareObjs(foodName) == true)
        {
            Debug.Log("incrementing item");
            items[foodName]++;
        }
        //if the item is not already in it
        if (!items.ContainsKey(foodName)) {
            //add the sprite
            Debug.Log("adding item");
            foodName.SetActive(true);
            items.Add(foodName, 1);
            Debug.Log("now has " + items[(foodName)] + " things called " + foodName.name );
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
    //Dictionary<int, GameObject> foodsList = new Dictionary<int, GameObject>()
    //{
    //    {1, apple},
    //    {2, fish},
    //    {3, carrot},
    //    {4, broc},
    //    {5, grape},
    //    {"Bun", 20 },
    //    {"Tomato", 50 },
    //    {"Lettuce", 15 },
    //    {"Meat", 300 },
    //    {"Cheese", 150 },
    //    {"Apple", 75 }
    //};
}
