using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour {
  private void OnTriggerEnter(Collider hitObject) {
    if (hitObject.gameObject.CompareTag("PlayerTwo")) {
      hitObject.gameObject.GetComponent<SecondPlayerController>().playerStagger();
      Destroy(this.gameObject);
    } else if (hitObject.gameObject.CompareTag("Player")) {
      hitObject.gameObject.GetComponent<PlayerController>().playerStagger();
      Destroy(this.gameObject);
    }
  }
}
