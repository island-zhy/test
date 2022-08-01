using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigateState : IState {

	private FSM m_fsmManager;
	private EnemyParameter m_enemyParameter;

	public NavigateState(FSM fsmManager) {
    m_fsmManager = fsmManager;
    m_enemyParameter = fsmManager.m_enemyParameter;
  }

  public void OnEnter() {
  
  }

  public void OnUpdate() {
  
  }

  public void OnExit() {
  
  }
}
