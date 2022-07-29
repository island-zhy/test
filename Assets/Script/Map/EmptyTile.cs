using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyTile : MapObject {
  void Start() {
    this.gameObject.SetActive(false);
  }

}
