/// <summary>
/// 所有状态的接口
/// </summary>
public interface IState {

  void OnEnter();
  void OnUpdate();
  void OnExit();

}