using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantedTile : MapObject {

  public override void UpInteractable() {
    //plant
  }

  public override void OverInteractable() {
    if (this.height == m_playerTile.height) {
      base.OverInteractable();
    }    
  }

}
