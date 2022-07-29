using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedTile : MapObject {

  private Material m_material2;
  private Material m_material3;

  public override void OverInteractable() {
    if (Mathf.Abs(m_playerTile.row - row) <= 1 && Mathf.Abs(m_playerTile.col - col) <= 1) {
      m_material.shader = m_shader;
      m_material2.shader = m_shader;
      m_material3.shader = m_shader;
    } else {
      m_material.shader = m_standardShader;
      m_material2.shader = m_standardShader;
      m_material3.shader = m_standardShader;
    }
  }

  public override void ExitInteractable() {
    m_material.shader = m_standardShader;
    m_material2.shader = m_standardShader;
    m_material3.shader = m_standardShader;
  }

  public override void UpInteractable() {
    //save or sleep
    Debug.Log("save");
  }


  public override void Start() {
    m_player = GameObject.FindGameObjectWithTag("Player");
    m_playerTile = m_player.GetComponent<PlayerTile>();
    m_material = this.transform.Find("Bed1Tile").GetComponent<SpriteRenderer>().material;
    m_material2 = this.transform.Find("Bed2Tile").GetComponent<SpriteRenderer>().material;
    m_material3 = this.transform.Find("Bed3Tile").GetComponent<SpriteRenderer>().material;
    m_standardShader = m_material.shader;
  }
}
