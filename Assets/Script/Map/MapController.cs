using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class MapController : MonoBehaviour {

	public int mapScaleX = 19;
	public int mapScaleY = 11;
  [SerializeField]
	private GameObject _planted, _empty, _ladder, _bed;
	[SerializeField]
	private Transform m_emptyTileSet, m_plantedTileSet, m_ladderTileSet, m_bedTileSet;

	[Serializable]
	private class Map {
		public int[,] mapTable;
		public int[,] mapHeightTable;
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
				Vector3 offset = Vector3.zero;
				if (m_mapFromJson.mapTable[i, j] == 1) {
					tile = Instantiate(_planted, transform.position, _planted.transform.rotation, m_plantedTileSet).GetComponent<MapObject>();
					m_mapInScene[j, mapScaleY - i - 1] = tile;
					offset.Set(0.5f, 0f, 0.5f);
				} else if (m_mapFromJson.mapTable[i, j] == 2) {
					tile = Instantiate(_ladder, transform.position, _ladder.transform.rotation, m_ladderTileSet).GetComponent<MapObject>();
					m_mapInScene[j, mapScaleY - i - 1] = tile;
				} else if (m_mapFromJson.mapTable[i, j] == 3) {
					tile = Instantiate(_bed, transform.position, _bed.transform.rotation, m_bedTileSet).GetComponent<MapObject>();
					m_mapInScene[j, mapScaleY - i - 1] = tile;
					offset.Set(0, 0.5f, 1f);
				} else {
					tile = Instantiate(_empty, transform.position, _empty.transform.rotation, m_emptyTileSet).GetComponent<MapObject>();
					m_mapInScene[j, mapScaleY - i - 1] = tile;
				}
				tile.height = m_mapFromJson.mapHeightTable[i, j] == 1 ? 1.5f : 0f;
				_ResetPosition(tile, j, mapScaleY - i - 1, m_mapFromJson.mapTable[i, j], offset);
			}
		}
	}

	private void _ResetPosition(MapObject tile, int row, int col, int property, Vector3 offset) {
		tile.row = row;
		tile.col = col;
		tile.m_mapProperty = (MapObject.MAP_PROPERTY) property;
		tile.transform.position = new Vector3(tile.row * m_mapWidth / m_mapPixelsPerUnit / mapScaleX, tile.height, tile.col * m_mapHeight / m_mapPixelsPerUnit / mapScaleY) + offset;
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
		m_mapFromJson.mapHeightTable = new int[mapScaleY, mapScaleX]; 
		for (int i = 0; i < mapScaleY; i++) {
			for (int j = 0; j < mapScaleX; j++) {
				m_mapFromJson.mapTable[i, j] = 0;
				m_mapFromJson.mapHeightTable[i, j] = 0;
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
