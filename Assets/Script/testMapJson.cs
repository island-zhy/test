using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
public class testMapJson : MonoBehaviour {

	private string m_upMapAddress;
	private string m_underMapAddress;
	private Map m_upMap;
	private Map m_underMap;

  [Serializable]
	private class Map{
		public List<List<int>> mapTable;
		public string mapProperties;
	}

	// Use this for initialization
	void Start () {
		m_upMapAddress = Application.dataPath + "/jsontable/upMap.json";
		m_underMapAddress = Application.dataPath + "/jsontable/underMap.json";
		//_WriteJson();
		_ReadJson();
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void _WriteJson() {

		StreamWriter sw = new StreamWriter(m_upMapAddress);
		sw.WriteLine(JsonConvert.SerializeObject(m_upMap));
		sw.Close();
	}

	private void _ReadJson() {
		StreamReader sr = new StreamReader(m_upMapAddress);
		m_upMap = JsonConvert.DeserializeObject<Map>(sr.ReadLine());
	}
}
