using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotatingCamera : MonoBehaviour {
  public float rotateTime = 0.2f;
  private Transform player;
  private bool isRotating = false;
  private float rotateDeltaTime = 0.2f;
  void Start() {
    player = GameObject.FindGameObjectWithTag("Player").transform;
  }

  void Update() {
    transform.position = player.position;
    Rotate();
  }

  void Rotate() {
    if (!isRotating) {
      if (Input.GetKeyDown(KeyCode.Q)) {
        this.transform.DORotate(this.transform.rotation.eulerAngles + new Vector3(0f, 0f, -90f), rotateTime);
        isRotating = true;
      }
      if (Input.GetKeyDown(KeyCode.E)) {
        this.transform.DORotate(this.transform.rotation.eulerAngles + new Vector3(0f, 0f, 90f), rotateTime);
        isRotating = true;
      }
    } else {  
      rotateDeltaTime = rotateDeltaTime - Time.deltaTime;
      if (rotateDeltaTime <= 0f) {
        rotateDeltaTime = 0.2f;
        isRotating = false;
      }
    }
  }
}
