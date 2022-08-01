/// <summary>
/// 背包内道具状态 (动态描述)
/// </summary>
public class Item : ItemDef
{
  /// <summary>
  /// 当前持有数量
  /// </summary>
  public int count;

  public Item(ItemDef itemDef, int count = 0)
  {
    // 模板定义属性
    name = itemDef.name;
    displayName = itemDef.displayName;
    info = itemDef.info;
    type = itemDef.type;
    countLimit = itemDef.countLimit;

    // 道具数量
    this.count = count;
  }
}