using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneColliderChecker : MonoBehaviour {
    // Start is called before the first frame update
    private GameObject player;
    private int playerOneScore = 0;

    void Start() {
        player = this.gameObject;
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter(Collider coll) {

        if (coll.gameObject.CompareTag("PlayerTwo")) {
            StartCoroutine(CollisionChecker());
        }
        
    }

    IEnumerator CollisionChecker() {
        playerOneScore++;
        Debug.Log("Player One Score: " + playerOneScore);
        yield return new WaitForSeconds(0.8f);
    }
    
}
