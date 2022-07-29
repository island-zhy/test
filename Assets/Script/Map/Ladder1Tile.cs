using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder1Tile : MapObject {
  // Use this for initialization
  private bool m_ifUpFloor = false;
  public override void UpInteractable() {
    
    if (Mathf.Abs(m_player.row - row) <= 1 && Mathf.Abs(m_player.col - col) <= 1) {
      if (m_ifUpFloor) {
        m_ifUpFloor = false;
        player.transform.position = new Vector3(row, 0f, col);
      } else {
        m_ifUpFloor = true;
        player.transform.position = new Vector3(row - 1, 1.5f, col);
      }
    }
  }

}
