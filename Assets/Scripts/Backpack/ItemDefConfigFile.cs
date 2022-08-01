/// <summary>
/// 道具描述配置文件 (策划给出的道具定义清单)
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
        "This is just a dummy nothing as you can see, it of course does no any effects :)",
        ItemType.Unkown,
        -1),
      new ItemDef(
        "bomb",
        "Art is Boom!",
        "Yet another item, but more threatening",
        ItemType.Weapon,
        10),
    };
  }
}
