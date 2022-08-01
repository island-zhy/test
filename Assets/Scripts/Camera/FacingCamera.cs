using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingCamera : MonoBehaviour {
  private List<Transform> childs;

  void Start() {
    childs = new List<Transform>();
    for (int i = 0; i < transform.childCount; i++) {
      childs.Add(transform.GetChild(i));
    }
  }

  void Update() {
    for (int i = 0; i < childs.Count; i++) {
      childs[i].rotation = Camera.main.transform.rotation;
    }
  }

  public void AddChild() {
    Debug.Log("1");
    childs.Add(transform.GetChild(transform.childCount - 1));
  }
}
