using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStateNavigate : IState {

	private FSM m_FSMManager;
	private EnemyParameter m_enemyParameter;

	public IStateNavigate(FSM fSMManager) {
    m_FSMManager = fSMManager;
    m_enemyParameter = fSMManager.m_enemyParameter;
  }

  public void OnEnter() {
  
  }

  public void OnUpdate() {
  
  }

  public void OnExit() {
  
  }
}
