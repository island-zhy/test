﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour {


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


	// Use this for initialization
	void Start () {
	}

	public virtual void EnterInteractable() {
		
	}

	public virtual void UpInteractable() {
		
	}

	public virtual void ExitInteractable() {

	}

	void OnMouseEnter() {
		EnterInteractable();
	}

	void OnMouseExit() {
		ExitInteractable();
	}

	void OnMouseUp() {
		UpInteractable();
	}

}
