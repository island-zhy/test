using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour {

	[SerializeField]
	protected Shader m_shader;
  [SerializeField]
	protected Color out_color;
  [SerializeField]
	[Range(0, 10)]
	protected int out_width;

	protected GameObject m_player;
	protected PlayerTile m_playerTile;
	protected Material m_material;
	private float m_height;
	protected Shader m_standardShader;

	private int m_row;
	private int m_col;
	//private bool m_ifOnSecondFloor;
	public enum MAP_PROPERTY {
    EMPTY = 0,
		PLANT = 1,
		LADDER = 2,
		BED = 3,
	}

	public int row {
		get {
			return m_row;
		}
		set {
			m_row = value;
		}
	} 

	public int col {
		get {
			return m_col;
		}
		set {
			m_col = value;
		}
	}

	public float height {
		get {
			return m_height;
		}
		set {
			m_height = value;
		}
	}


	public MAP_PROPERTY m_mapProperty = MAP_PROPERTY.EMPTY;


	public virtual void OverInteractable() {
		if (height == m_playerTile.height) {
			if (Mathf.Abs(m_playerTile.row - row) <= 1 && Mathf.Abs(m_playerTile.col - col) <= 1) {
				m_material.shader = m_shader;
				m_material.SetColor("_lineColor", out_color);
				m_material.SetInt("_lineWidth", out_width);
			} else {
				m_material.shader = m_standardShader;
			}
		}
	}
	public virtual void ExitInteractable() {
		m_material.shader = m_standardShader;
	}
	public virtual void UpInteractable() {
		
	}

	void OnMouseOver() {
		OverInteractable();
	}

	void OnMouseExit() {
		ExitInteractable();
	}

	void OnMouseUp() {
		UpInteractable();
	}

	// Use this for initialization
	public virtual void Start() {
		m_player = GameObject.FindGameObjectWithTag("Player");
		m_playerTile = m_player.GetComponent<PlayerTile>();
		m_material = GetComponent<SpriteRenderer>().material;
		m_standardShader = m_material.shader;
	}

}
