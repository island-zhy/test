using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldFlip : MonoBehaviour {

  public void RunWorldFlip() {
    this.transform.Rotate(180f, 0, 0);
  }


}
