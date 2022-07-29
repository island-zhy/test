///<summary>
///所有状态的接口
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IState {

  void OnEnter();
  void OnUpdate();
  void OnExit();
}
 