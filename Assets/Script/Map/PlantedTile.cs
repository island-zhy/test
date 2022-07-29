using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantedTile : MapObject {
  private Material m_material;
  [SerializeField]
  private Shader m_shader;

  private Shader m_standardShader;
  public override void EnterInteractable() {
    //高亮显示
    m_material.shader = m_shader;
  }

  public override void ExitInteractable() {
    //取消高亮
    m_material.shader = m_standardShader;
  }

  public override void UpInteractable() {
    //正常的交互逻辑
  }

  private void Start() {
    m_material = GetComponent<SpriteRenderer>().material;
    m_standardShader = m_material.shader;
  }
}
