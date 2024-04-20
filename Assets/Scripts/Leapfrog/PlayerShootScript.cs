using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour {

  [SerializeField] private GameObject projectile;
  [SerializeField] private Transform projectileSpawn;
  private float speed = 12f;
  private bool outShot;

  private void Start() {
    outShot = false;
  }
  
  private void Update() {
    bool playerOneKeyDown = Input.GetKey(KeyCode.E);

    
    if (playerOneKeyDown && !outShot) {
      outShot = true;
      StartCoroutine(ShootSpit());
    }

    /*if (playerTwoKeyDown) {
      Instantiate(projectile, transform.position, transform.rotation);
    }*/
  }

  private IEnumerator ShootSpit() {
    Debug.Log("Shot");
    GameObject spitSpot = Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);

    spitSpot.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, speed));
    yield return new WaitForSeconds(0.5f);
    
    Destroy(spitSpot);
    outShot = false;
  }
}
