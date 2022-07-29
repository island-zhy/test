using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour {

	[SerializeField]
	protected Shader m_shader;

	protected GameObject player;
	protected PlayerTile m_player;
	private Material m_material;
	private Shader m_standardShader;

	private int m_row;
	private int m_col;
	//private bool m_ifOnSecondFloor;
	public enum MAP_PROPERTY {
    EMPTY = 0,
		PLANT = 1,
		LADDER1 = 2,
		LADDER2 = 3,
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


	public MAP_PROPERTY m_mapProperty = MAP_PROPERTY.EMPTY;


	public virtual void OverInteractable() {
		if (Mathf.Abs(m_player.row - row) <= 1 && Mathf.Abs(m_player.col - col) <= 1) {
			m_material.shader = m_shader;
		} else {
			m_material.shader = m_standardShader;
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
	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
		m_player = player.GetComponent<PlayerTile>();
		m_material = GetComponent<SpriteRenderer>().material;
		m_standardShader = m_material.shader;
	}

}
