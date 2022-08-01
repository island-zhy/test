using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTile : MapObject {

  // Use this for initialization
  private bool m_ifUpFloor = false;
  public override void UpInteractable() {
    if (Mathf.Abs(m_playerTile.row - row) <= 1 && Mathf.Abs(m_playerTile.col - col) <= 1) {
      if (m_ifUpFloor) {
        m_ifUpFloor = false;
        m_player.transform.position = new Vector3(row, 0f, col);
        m_playerTile.height = 0f;
      } else {
        m_ifUpFloor = true;
        m_player.transform.position = new Vector3(row - 1, 1.5f, col);
        m_playerTile.height = 1.5f;
      }
    }
  }

  public override void OverInteractable() {
    base.OverInteractable();
  }

}
