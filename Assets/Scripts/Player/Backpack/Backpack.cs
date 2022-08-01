using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家的背包
/// </summary>
public class Backpack : MonoBehaviour {

  /// <summary>
  /// 背包总容量上限（如果需要限制的话？）
  /// </summary>
  public int capacity { get; private set; }

  /// <summary>
  /// 背包内容，按ID记录所持有物品的字典 (名称 -> 道具状态)
  /// </summary>
  Dictionary<string, Item> items;


  void Awake() {
    items = new Dictionary<string, Item>();

  }

  void Start () {
    // TODO: 读取配置文件 Data/items_def.json, 初始化`items`

  }

}
