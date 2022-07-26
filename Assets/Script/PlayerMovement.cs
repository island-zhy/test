using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
  public float speed;
  new private Rigidbody rigidbody;
  private Animator animator;
  private float inputX, inputY;
  private float stopX, stopY;

  void Start() {
    rigidbody = GetComponent<Rigidbody>();
    animator = GetComponent<Animator>();
  }

  void Update() {
    this.transform.rotation = Camera.main.transform.rotation;
    inputX = Input.GetAxisRaw("Horizontal");
    inputY = Input.GetAxisRaw("Vertical");
    Vector2 input = (transform.right * inputX + transform.up * inputY).normalized;
    rigidbody.velocity = input * speed;

    if (input != Vector2.zero) {
      animator.SetBool("isMoving", true);
      stopX = inputX;
      stopY = inputY;
    } else {
      animator.SetBool("isMoving", false);
    }
    animator.SetFloat("InputX", stopX);
    animator.SetFloat("InputY", stopY);

  } 
}
