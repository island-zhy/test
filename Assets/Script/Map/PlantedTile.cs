using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantedTile : MapObject {

	[SerializeField]
	private Sprite _plantedSprite;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		this.GetComponent<SpriteRenderer>().sprite = _plantedSprite;
	}
}
