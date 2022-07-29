using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedTile : MapObject {

  public override void UpInteractable() {
    //save or sleep
    if (this.height == m_playerTile.height) {
      Debug.Log("save");
    }
  }


}
