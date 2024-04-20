using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpeedItem : MonoBehaviour {
    [SerializeField] private string itemName;
    private float speedIncrease = 2.0f;
    
    
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Item Collected: " + itemName);

        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerController>().speed += speedIncrease;
            Manager.Inventory.AddItem(itemName);    
        } else if (other.gameObject.CompareTag("PlayerTwo")) {
            other.gameObject.GetComponent<SecondPlayerController>().speed += speedIncrease;

        }
        Destroy(this.gameObject);
    }
}
