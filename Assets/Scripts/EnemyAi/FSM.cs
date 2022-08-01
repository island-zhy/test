using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParameter {
	 
}

public class FSM : MonoBehaviour {
	public enum STATE_TYPE {
		IDLE = 0,
		NAVIGATE = 1,
	}

	private IState m_currentIState;
	private Dictionary<STATE_TYPE, IState> m_enemyStateSet;
	public EnemyParameter m_enemyParameter;

	public void _TransitionState(STATE_TYPE stateType) {
		if (m_currentIState != null) {
			m_currentIState.OnExit();
		}
		m_currentIState = m_enemyStateSet[stateType];
		m_currentIState.OnEnter();
	}

	// Use this for initialization
	void Start () {
		m_enemyStateSet = new Dictionary<STATE_TYPE, IState>();
		m_enemyStateSet = new Dictionary<STATE_TYPE, IState>();

		m_enemyStateSet.Add(STATE_TYPE.IDLE, new IdleState(this));
		m_enemyStateSet.Add(STATE_TYPE.NAVIGATE, new NavigateState(this));

		m_currentIState = m_enemyStateSet[STATE_TYPE.IDLE];
	}
	
	// Update is called once per frame
	void Update () {
		m_currentIState.OnUpdate();
	}

	


}
