using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableTurnItem : MonoBehaviour {
    [SerializeField] private string itemName;
    private float turnIncrease = 2.0f;
    
    
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Item Collected: " + itemName);

        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerController>().rotationSpeed += turnIncrease;
        } else if (other.gameObject.CompareTag("PlayerTwo")) {
            other.gameObject.GetComponent<SecondPlayerController>().rotationSpeed += turnIncrease;

        }
        Destroy(this.gameObject);
    }
}
