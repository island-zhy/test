using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyTile : MapObject {
  public override void Start() {
    this.gameObject.SetActive(false);
  }

}
