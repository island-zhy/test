using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class MapController : MonoBehaviour {

	[SerializeField]
	private int _mapScaleX = 21;
	private int _mapScaleY = 15;
  [SerializeField]
	private GameObject _grow;
  [SerializeField]
	private Transform m_digAndGrow;

	[Serializable]
	private class Map {
		public int[,] mapTable;
	}

	private string m_upMapAddress;
	private SpriteRenderer m_mapSpriteRenderer;
	private float m_mapWidth, m_mapHeight;
	private Map m_mapFromJson;
	private Map m_mapInScene;

	private void _ReadMapJson() {
		StreamReader sr = new StreamReader(m_upMapAddress);
		m_mapFromJson = JsonConvert.DeserializeObject<Map>(sr.ReadToEnd());
		sr.Close();
	}

	private void _InitMap() {
		for (int i = 0; i < _mapScaleY; i++) {
			for (int j = 0; j < _mapScaleX; j++) {
				m_mapInScene.mapTable[j, _mapScaleY - i - 1] = m_mapFromJson.mapTable[i, j];
			}
		}
		for (int i = 0; i < _mapScaleX; i++) {
			for (int j = 0; j < _mapScaleY; j++) {
				if (m_mapInScene.mapTable[i, j] == 1) {
					Instantiate(_grow, new Vector3(i * m_mapWidth / 100 / _mapScaleX + 0.305f, 0, j * m_mapHeight / 100 / _mapScaleY + 0.305f), _grow.transform.rotation, m_digAndGrow);
				}
			}
		}
	}

	// Use this for initialization
	void Start () {
		m_mapInScene = new Map();
		m_mapInScene.mapTable = new int[_mapScaleX, _mapScaleY];
		m_upMapAddress = Application.dataPath + "/jsontable/upMap.json";
		m_mapSpriteRenderer = GetComponent<SpriteRenderer>();
		m_mapWidth = m_mapSpriteRenderer.sprite.texture.width;
		m_mapHeight = m_mapSpriteRenderer.sprite.texture.height;
		Debug.Log(m_mapHeight);
		//_InitJson();
		_ReadMapJson();
		_InitMap();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private void _InitJson() {
		m_mapFromJson = new Map();
		m_mapFromJson.mapTable = new int[_mapScaleY, _mapScaleX];
		for (int i = 0; i < _mapScaleY; i++) {
			for (int j = 0; j < _mapScaleX; j++) {
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
