using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTile : MonoBehaviour{

	[SerializeField]
	private GameObject _mapController;
	[SerializeField]
	private int _interactRange = 2;

	private Sprite m_mapSprite;
	private MapController m_mapController;
	private int m_row;
	private int m_col;
	private MapObject[,] m_mapInScene;

	private void _UpdatePlayRowAndCol() {
		m_row = Mathf.RoundToInt(this.transform.position.x * m_mapSprite.pixelsPerUnit * m_mapController.mapScaleX / m_mapSprite.texture.width);
		m_col = Mathf.RoundToInt(this.transform.position.z * m_mapSprite.pixelsPerUnit * m_mapController.mapScaleY / m_mapSprite.texture.height);
		Debug.Log(m_row + " " + m_col);
	}

	private void _FindTileInteractable() {
		for (int i = 0; i < m_mapController.mapScaleX; i++) {
			for (int j = 0; j < m_mapController.mapScaleY; j++) {
				if (Mathf.Abs(m_row - i) + Mathf.Abs(m_col - j) <= _interactRange && m_mapInScene[i, j].m_mapProperty != MapObject.MAP_PROPERTY.EMPTY) {
					m_mapInScene[i, j].gameObject.SetActive(true);
				} else if (Mathf.Abs(m_row - i) + Mathf.Abs(m_col - j) > _interactRange) {
					m_mapInScene[i, j].gameObject.SetActive(false);
				}
			}
		}
	}

	// Use this for initialization
	void Start () {
		_mapController = GameObject.FindGameObjectWithTag("Map");
		m_mapSprite = _mapController.GetComponent<SpriteRenderer>().sprite;
		m_mapController = _mapController.GetComponent<MapController>();
		m_mapInScene = _mapController.GetComponent<MapController>().mapInScene;
	}
	
	// Update is called once per frame
	void Update () {
		_UpdatePlayRowAndCol();
		_FindTileInteractable();	
	}
}
