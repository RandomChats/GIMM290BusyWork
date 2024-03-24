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
  CharacterController characterController;
  Vector3 moveVelocity;
  Vector3 turnVelocity;

  private bool playerGrounded = true;
  void Awake()
  {
    characterController = GetComponent<CharacterController>();
  }
  void Update() {

    bool wKeyDown = Input.GetKey(KeyCode.W);
    bool aKeyDown = Input.GetKey(KeyCode.A);
    bool dKeyDown = Input.GetKey(KeyCode.D);
    
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
    if(Input.GetButtonDown("Jump") && playerGrounded)
    {
      moveVelocity.y = jumpSpeed;
      playerGrounded = false;
    }
    //Adding gravity
    moveVelocity.y += gravity * Time.deltaTime;
    characterController.Move(moveVelocity * Time.deltaTime);
    transform.Rotate(turnVelocity * Time.deltaTime);
  }
}