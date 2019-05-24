using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public GameObject food;

    void Start()
    {
        food = GetComponent<GameObject>();
    }

    /*
  void OnTriggerEnter(Collider other)
  {
      if (other.gameObject.CompareTag("Pick Up"))
      {
          Inventory.instance.addItem(food.name);
          // add the item to the inventory
          print("Item Collected");
          Destroy(gameObject);
      }
  }
    */

        // PICK UP AINT WORKIN N I DONT KNOW WHY :D

  //  void OnCollisionEnter(Collision other)
  //{
  //    if (other.gameObject.tag == "Hand")
  //    {
  //        Destroy(gameObject);

  //        Inventory.instance.addItem(gameObject.name);
  //        // add the item to the inventory
  //        print("Item Collected" + gameObject.name);
  //    }
  //}

}
