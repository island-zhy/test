/// <summary>
/// 道具名单 (可能没用)
/// </summary>
public class ItemName
{
  public const string KusaSeed = "whatsoever seed";
  public const string HanaSeed = "not a seed";
  public const string LumineDot = "rwkk";
  public const string LumineRock = "can can need";
  public const string PonponBakudan = "kureeeee!";
}

/// <summary>
/// 道具类型 (如果要做背包分页的话)
/// NOTE: 是抽象的功能分类而不是具体道具种类，这个枚举可能用不上，但是先写着)
/// </summary>
public enum ItemType
{
  Unkown,

  /// <summary>
  /// 种子
  /// </summary>
  Seed,

  /// <summary>
  /// 光照值 (由种子/植物生长、光点、光矿等转化而来
  /// </summary>
  Lumens,

  /// <summary>
  /// 武器，应该是那些种植收获得到的果实
  /// </summary>
  Weapon,
}

/// <summary>
/// 道具定义数据类 (静态描述)
/// </summary>
public class ItemDef
{
  /// <summary>
  /// 名称，亦作唯一标识符
  /// </summary>
  public string name;
  /// <summary>
  /// 显示名称
  /// </summary>
  public string displayName;
  /// <summary>
  /// 类型
  /// </summary>
  public ItemType type;
  /// <summary>
  /// 详细描述
  /// </summary>
  public string info;
  /// <summary>
  /// 持有数量上限
  /// </summary>
  public int countLimit;

  public ItemDef() { }

  public ItemDef(string name, string displayName, ItemType type, string info, int countLimit)
  {
    this.name = name;
    this.displayName = displayName;
    this.type = type;
    this.info = info;
    this.countLimit = countLimit;
  }
}

/// <summary>
/// 道具描述配置文件 (策划侧给出的道具定义清单)
/// </summary>
public class ItemDefConfigFile
{
  public ItemDef[] itemDefs;

  /// <summary>
  /// 无参构造仅用于创建配置文件模板
  /// </summary>
  public ItemDefConfigFile()
  {
    itemDefs = new ItemDef[] {
      new ItemDef(
        "testItem",
        "A Test Item..",
        ItemType.Unkown,
        "This is just a dummy nothing as you can see, it of course does no any effects :)",
        -1),
      new ItemDef(
        "bomb",
        "Art is Boom!",
        ItemType.Weapon,
        "Yet another item, but more threatening",
        10),
    };
  }
}

/// <summary>
/// 背包内道具状态 (动态描述)
/// </summary>
public class Item : ItemDef
{
  /// <summary>
  /// 当前持有数量
  /// </summary>
  public int count;

  public Item(ItemDef itemDef, int count=0)
  {
    name = itemDef.name;
    displayName = itemDef.displayName;
    type = itemDef.type;
    info = itemDef.info;
    countLimit = itemDef.countLimit;

    this.count = count;
  }
}