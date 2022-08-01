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
  /// 详细描述
  /// </summary>
  public string info;
  /// <summary>
  /// 类型
  /// </summary>
  public ItemType type;
  /// <summary>
  /// 持有数量上限
  /// </summary>
  public int countLimit;

  public ItemDef() { }

  public ItemDef(string name, string displayName, string info, ItemType type, int countLimit)
  {
    this.name = name;
    this.displayName = displayName;
    this.info = info;
    this.type = type;
    this.countLimit = countLimit;
  }
}
