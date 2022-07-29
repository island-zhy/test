using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantedTile : MapObject {
  [SerializeField]
  private Shader m_shader;
  private PlayerTile m_player;

  private Material m_material;
  private Shader m_standardShader;
  public override void OverInteractable() {
    //高亮显示
    if (Mathf.Abs(m_player.row - row) <= 1 && Mathf.Abs(m_player.col - col) <= 1) {
      m_material.shader = m_shader;
    } else {
      m_material.shader = m_standardShader;
    }
  }

  public override void ExitInteractable() {
    //取消高亮
    m_material.shader = m_standardShader;
  }

  public override void UpInteractable() {
    //正常的交互逻辑
  }

  private void Start() {
    m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTile>();
    m_material = GetComponent<SpriteRenderer>().material;
    m_standardShader = m_material.shader;
  }
}
