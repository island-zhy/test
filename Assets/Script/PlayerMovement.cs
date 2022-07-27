using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
  [SerializeField]
  private float _speed;

  [SerializeField]
  private MapController _mapController;

  private Rigidbody m_playerRigidbody ;
  private float m_inputX, m_inputZ;
  private float m_mapX, m_mapY;

  void Start() {
    m_playerRigidbody = GetComponent<Rigidbody>();
  }

  void Update() {
    m_inputX = Input.GetAxisRaw("Horizontal");
    m_inputZ = Input.GetAxisRaw("Vertical");
    Vector3 input = new Vector3(m_inputX, 0, m_inputZ) * _speed;
    m_playerRigidbody.velocity = input;
  }

  private void _PlayerPlaceInMap() {
    
  }
}
