using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class RobotBoyMove : MonoBehaviour {

  [SerializeField]
  private float _jump_Force = 400f;

  private bool m_IfGround;
  private Rigidbody m_rigidbody;

  private void _Jump() {
    m_rigidbody.AddForce(new Vector3(0, _jump_Force, 0));
    m_IfGround = false;
  }

  void Start() {
    m_IfGround = false;
    m_rigidbody = GetComponent<Rigidbody>();
  }

  void FixedUpdate() {

    if ((Input.GetAxis("Jump_k") != 0 || Input.GetAxis("Jump_j1") != 0) && !m_IfGround) {
      _Jump();
    }
  }
}
