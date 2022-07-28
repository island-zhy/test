using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class MapController : MonoBehaviour {

	public int mapScaleX = 21;
	public int mapScaleY = 15;
  [SerializeField]
	private GameObject _planted;
	[SerializeField]
	private GameObject _empty;
  [SerializeField]
	private Transform m_emptyTileSet, m_plantedTileSet;

	[Serializable]
	private class Map {
		public int[,] mapTable;
	}

	private string m_upMapAddress;
	private SpriteRenderer m_mapSpriteRenderer;
	private float m_mapWidth, m_mapHeight, m_mapPixelsPerUnit;
	private Map m_mapFromJson;
	private MapObject[,] m_mapInScene;

	public MapObject[,] mapInScene {
		get {
			return m_mapInScene;
		}
	}

	private void _ReadMapJson() {
		StreamReader sr = new StreamReader(m_upMapAddress);
		m_mapFromJson = JsonConvert.DeserializeObject<Map>(sr.ReadToEnd());
		sr.Close();
	}

	private void _InitMap() {
		for (int i = 0; i < mapScaleY; i++) {
			for (int j = 0; j < mapScaleX; j++) {
				MapObject tile;
				if (m_mapFromJson.mapTable[i, j] == 1) {
					tile = Instantiate(_planted, transform.position, transform.rotation, m_plantedTileSet).GetComponent<MapObject>();
					m_mapInScene[j, mapScaleY - i - 1] = tile;
				} else {
					tile = Instantiate(_empty, transform.position, transform.rotation, m_emptyTileSet).GetComponent<MapObject>();
					m_mapInScene[j, mapScaleY - i - 1] = tile;
				}
				_ResetPosition(tile, j, mapScaleY - i - 1, m_mapFromJson.mapTable[i, j]);
			}
		}
	}

	private void _ResetPosition(MapObject tile, int row, int col, int property) {
		tile.row = row;
		tile.col = col;
		tile.m_mapProperty = (MapObject.MAP_PROPERTY) property;
		tile.transform.position = new Vector3(tile.row * m_mapWidth / m_mapPixelsPerUnit / mapScaleX + 0.305f, 0, tile.col * m_mapHeight / m_mapPixelsPerUnit / mapScaleY + 0.305f);
		tile.gameObject.SetActive(false);
	}
	
	// Use this for initialization
	void Start () {
		m_mapInScene = new MapObject[mapScaleX, mapScaleY];
		m_upMapAddress = Application.dataPath + "/jsontable/upMap.json";
		m_mapSpriteRenderer = GetComponent<SpriteRenderer>();
		m_mapWidth = m_mapSpriteRenderer.sprite.texture.width;
		m_mapHeight = m_mapSpriteRenderer.sprite.texture.height;
		m_mapPixelsPerUnit = m_mapSpriteRenderer.sprite.pixelsPerUnit;
		//_InitJson();
		_ReadMapJson();
		_InitMap();
	}
	
	// Update is called once per frame

	private void _InitJson() {
		m_mapFromJson = new Map();
		m_mapFromJson.mapTable = new int[mapScaleY, mapScaleX];
		for (int i = 0; i < mapScaleY; i++) {
			for (int j = 0; j < mapScaleX; j++) {
				m_mapFromJson.mapTable[i, j] = 0;
			}
		}
		_WriteMapJson();
	}
	private void _WriteMapJson() {
		StreamWriter sr = new StreamWriter(m_upMapAddress);
		sr.WriteLine(JsonConvert.SerializeObject(m_mapFromJson));
		sr.Close();
	}
}
