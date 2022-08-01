using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

// 地图描述的数据结构
[Serializable]
public class JsonMap
{
  public int[,] mapTable;
  public int[,] mapHeightTable;

  public JsonMap(int mapScaleY, int mapScaleX)
  {
    mapTable = new int[mapScaleY, mapScaleX];
    mapHeightTable = new int[mapScaleY, mapScaleX];
    for (int i = 0; i < mapScaleY; i++)
      for (int j = 0; j < mapScaleX; j++)
        mapTable[i, j] = mapHeightTable[i, j] = 0;
  }
}

public class MapController : MonoBehaviour
{
	public int mapScaleX = 19;
	public int mapScaleY = 11;

  [SerializeField]
	private GameObject _planted, _empty, _ladder, _bed;
	[SerializeField]
	private Transform m_emptyTileSet, m_plantedTileSet, m_ladderTileSet, m_bedTileSet;

	private SpriteRenderer m_mapSpriteRenderer;
	private float m_mapWidth, m_mapHeight, m_mapPixelsPerUnit;

  // 地图描述文件
  private string m_upMapFilePath;
  private JsonMap m_jsonMap;

  // 场景内地图
  private MapObject[,] m_mapInScene;

	public MapObject[,] mapInScene {
		get { return m_mapInScene; }
	}

	// Use this for initialization
	void Start ()
  {
		m_mapInScene = new MapObject[mapScaleX, mapScaleY];
		m_upMapFilePath = Application.dataPath + "/Data/jsonMap/upMap.json";
		m_mapSpriteRenderer = GetComponent<SpriteRenderer>();
		m_mapWidth = m_mapSpriteRenderer.sprite.texture.width;
		m_mapHeight = m_mapSpriteRenderer.sprite.texture.height;
		m_mapPixelsPerUnit = m_mapSpriteRenderer.sprite.pixelsPerUnit;

    _LoadMapFromJson();
	}

  private void _LoadMapFromJson()
  {
    // 如果地图描述文件不存在，全零初始化一个
    if (!File.Exists(m_upMapFilePath))
    {
      m_jsonMap = new JsonMap(mapScaleY, mapScaleX);
      JsonUtil.Save(m_upMapFilePath, m_jsonMap);
    }

    // 加载地图描述并转化为Unity中的地图对象
    m_jsonMap = JsonUtil.Load<JsonMap>(m_upMapFilePath);
    for (int i = 0; i < mapScaleY; i++)
    {
      for (int j = 0; j < mapScaleX; j++)
      {
        MapObject tile;
        Vector3 offset = Vector3.zero;
        // TODO: 改成switch
        if (m_jsonMap.mapTable[i, j] == 1)
        {
          tile = Instantiate(_planted, transform.position, _planted.transform.rotation, m_plantedTileSet).GetComponent<MapObject>();
          m_mapInScene[j, mapScaleY - i - 1] = tile;
          offset.Set(0.5f, 0f, 0.5f);
        }
        else if (m_jsonMap.mapTable[i, j] == 2)
        {
          tile = Instantiate(_ladder, transform.position, _ladder.transform.rotation, m_ladderTileSet).GetComponent<MapObject>();
          m_mapInScene[j, mapScaleY - i - 1] = tile;
        }
        else if (m_jsonMap.mapTable[i, j] == 3)
        {
          tile = Instantiate(_bed, transform.position, _bed.transform.rotation, m_bedTileSet).GetComponent<MapObject>();
          m_mapInScene[j, mapScaleY - i - 1] = tile;
          offset.Set(0, 0.5f, 1f);
        }
        else
        {
          tile = Instantiate(_empty, transform.position, _empty.transform.rotation, m_emptyTileSet).GetComponent<MapObject>();
          m_mapInScene[j, mapScaleY - i - 1] = tile;
        }
        tile.height = m_jsonMap.mapHeightTable[i, j] == 1 ? 1.5f : 0f;

        _ResetPosition(tile, j, mapScaleY - i - 1, m_jsonMap.mapTable[i, j], offset);
      }
    }
  }

  private void _ResetPosition(MapObject tile, int row, int col, int property, Vector3 offset)
  {
    tile.row = row;
    tile.col = col;
    tile.m_mapProperty = (MapObject.MAP_PROPERTY) property;
    float x = tile.row * m_mapWidth / m_mapPixelsPerUnit / mapScaleX;
    float z = tile.col * m_mapHeight / m_mapPixelsPerUnit / mapScaleY;
    tile.transform.position = new Vector3(x, tile.height, z) + offset;
  }

}
