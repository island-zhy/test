using System.IO;
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
    _LoadItemConfig();

    _DumpItemStatus();
  }

  void _LoadItemConfig()
  {
    //Debug.Log("[_LoadItemConfig]");
    string fp = Path.Combine(Application.dataPath, "Data/item_def.json");
    ItemDefConfigFile config;

    // 如果配置文件不存在，创建一个示例模板
    if (!File.Exists(fp)) {
      config = new ItemDefConfigFile();
      JsonUtil.Save(fp, config);
    }

    // 读取配置文件
    config = JsonUtil.Load<ItemDefConfigFile>(fp);
    foreach (var itemDef in config.itemDefs)
      items[itemDef.name] = new Item(itemDef);
  }

  void _DumpItemStatus()
  {
    //Debug.Log("[_DumpItemStatus]");

    // 转储背包道具状态，仅用作调试检查（不用于存档！！）
    string fp = Path.Combine(Application.dataPath, "Data/item_status.json");
    JsonUtil.Save(fp, items);
  }

}
