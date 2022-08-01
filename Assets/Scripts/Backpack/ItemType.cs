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
