using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTile : MapObject {

  private Material m_material2;
  // Use this for initialization
  private bool m_ifUpFloor = false;
  public override void UpInteractable() {
    if (Mathf.Abs(m_playerTile.row - row) <= 1 && Mathf.Abs(m_playerTile.col - col) <= 1) {
      if (m_ifUpFloor) {
        m_ifUpFloor = false;
        m_player.transform.position = new Vector3(row, 0f, col);
      } else {
        m_ifUpFloor = true;
        m_player.transform.position = new Vector3(row - 1, 1.5f, col);
      }
    }
  }

  public override void OverInteractable() {
    if (Mathf.Abs(m_playerTile.row - row) <= 1 && Mathf.Abs(m_playerTile.col - col) <= 1) {
      m_material.shader = m_shader;
      m_material2.shader = m_shader;
    } else {
      m_material.shader = m_standardShader;
      m_material2.shader = m_standardShader;
    }
  }

  public override void ExitInteractable() {
    m_material.shader = m_standardShader;
    m_material2.shader = m_standardShader;
  }

  public override void Start() {
    this.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
    m_player = GameObject.FindGameObjectWithTag("Player");
    m_playerTile = m_player.GetComponent<PlayerTile>();
    m_material = this.transform.Find("Ladder1Tile").GetComponent<SpriteRenderer>().material;
    m_material2 = this.transform.Find("Ladder2Tile").GetComponent<SpriteRenderer>().material;
    m_standardShader = m_material.shader;
  }
}
