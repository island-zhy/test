using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedTile : MapObject {

  public override void OverInteractable() {
    if (this.height == m_playerTile.height) {
      if (Mathf.Abs(m_playerTile.row - row) <= 3 && Mathf.Abs(m_playerTile.col - col) <= 1) {
        foreach (Material material in m_materialList) {
          material.shader = m_shader;
          material.SetColor("_lineColor", out_color);
          material.SetInt("_lineWidth", out_width);
        }
      } else {
        foreach (Material material in m_materialList) {
          material.shader = m_standardShader;
        }
      }
    }
  }

  public override void UpInteractable() {
    //save or sleep
    if (this.height == m_playerTile.height) {
      Debug.Log("save");
    }
  }


}
