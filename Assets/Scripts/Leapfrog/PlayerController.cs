using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
  public float speed = 3;
  public float rotationSpeed = 90;
  public float gravity = -20f;
  public float jumpSpeed = 15;
  private float pushForce = 3.0f;
  CharacterController characterController;
  Vector3 moveVelocity;
  Vector3 turnVelocity;
  private ControllerColliderHit contact;

  private bool playerGrounded = true;
  void Awake()
  {
    characterController = GetComponent<CharacterController>();
  }
  void Update() {

    bool wKeyDown = Input.GetKey(KeyCode.W);
    bool aKeyDown = Input.GetKey(KeyCode.A);
    bool dKeyDown = Input.GetKey(KeyCode.D);
    bool eKeyDown = Input.GetKey(KeyCode.E);
    
    if(characterController.isGrounded) {
      int playerFor = 0;
      int playerRot = 0;
      
      if (wKeyDown) {
        playerFor = 1;
      } else {
        playerFor = 0;
      }

      if (aKeyDown) {
        playerRot = -1;
      } else if (dKeyDown) {
        playerRot = 1;
      } else {
        playerRot = 0;
      }
      
      moveVelocity = transform.forward * speed * playerFor;
      turnVelocity = transform.up * rotationSpeed * playerRot;
      playerGrounded = true;
    }
    if(Input.GetButtonDown("Jump") && playerGrounded) {
      moveVelocity.y = jumpSpeed;
      playerGrounded = false;
    }

    if (eKeyDown) {
      
    }
    //Adding gravity
    moveVelocity.y += gravity * Time.deltaTime;
    characterController.Move(moveVelocity * Time.deltaTime);
    transform.Rotate(turnVelocity * Time.deltaTime);
  }

  private void OnControllerColliderHit(ControllerColliderHit hit) {
    contact = hit;

    Rigidbody body = hit.collider.attachedRigidbody;
    if (body != null && !body.isKinematic && body.CompareTag("LevelObjects")) {
      body.velocity = hit.moveDirection * pushForce;
    }
  }

  public void playerStagger() {
    StartCoroutine(PlayerStagger());
  }

  private IEnumerator PlayerStagger() {
    float oldSpeed = speed;
    float oldRot = rotationSpeed;
    
    Debug.Log("Sloooow");
    speed = speed/2;
    rotationSpeed = rotationSpeed / 2;

    yield return new WaitForSeconds(1.5f);

    speed = oldSpeed;
    rotationSpeed = oldRot;
    yield return new WaitForSeconds(0.3f);
  }

}