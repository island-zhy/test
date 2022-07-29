using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStateIdle : IState {

  private FSM m_FSMManager;
  private EnemyParameter m_enemyParameter;

  public IStateIdle(FSM fSMManager) {
    this.m_FSMManager = fSMManager;
    this.m_enemyParameter = fSMManager.m_enemyParameter;
  }

  public void OnEnter() {
  
  }

  public void OnUpdate() {
  
  }

  public void OnExit() {
  
  }
}
