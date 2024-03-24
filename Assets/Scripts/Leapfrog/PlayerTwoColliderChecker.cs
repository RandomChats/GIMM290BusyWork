using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoColliderChecker : MonoBehaviour {
  // Start is called before the first frame update
  private GameObject player;
  private int playerTwoScore = 0;

  void Start() {
    player = this.gameObject;
  }

  // Update is called once per frame
  void Update() {
        
  }

  private void OnTriggerEnter(Collider coll) {

    if (coll.gameObject.CompareTag("Player")) {
      StartCoroutine(CollisionChecker());
    }
        
  }

  IEnumerator CollisionChecker() {
    playerTwoScore++;
    Debug.Log("Player One Score: " + playerTwoScore);
    yield return new WaitForSeconds(0.8f);
  }
    
}