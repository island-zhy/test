using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class RobotBoyMove : MonoBehaviour {

  [SerializeField]
  private float _jumpForce = 400f;
  [SerializeField]
  private int _playerID;
  [SerializeField]
  private float _moveSpeed = 4f;

  private const float m_groundedRadius = 0.2f;
  private bool m_ifGround;
  private Transform m_groundTransform;
  private bool m_faceToRight = true;
  private Rigidbody2D m_rigidbody;

  private void _Jump() {
    m_rigidbody.AddForce(new Vector2(0, _jumpForce));
    m_ifGround = false;
  }

  private void _Flip() {
    this.transform.localScale = new Vector3(-transform.localScale.x , transform.localScale.y, transform.localScale.z);
    m_faceToRight = !m_faceToRight;
  }

  void Start() {
    m_groundTransform = transform.Find("GroundCheck");
    m_rigidbody = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate() {

    //判断人物是否在地面上
    m_ifGround = false;
    Collider2D[] colliders = Physics2D.OverlapCircleAll(m_groundTransform.position, m_groundedRadius);
    for (int i = 0; i < colliders.Length; i++) {
      if (colliders[i].gameObject != gameObject) {
        m_ifGround = true;
      }
    }

    // 判断人物id是player1还是player2进行跳跃
    if ( ( (_playerID == 1 && (Input.GetAxis("jump_k1") != 0 || Input.GetAxis("jump_j1") != 0)) ||
           (_playerID == 2 && (Input.GetAxis("jump_k2") != 0 || Input.GetAxis("jump_j2") != 0)) )  &&
          m_ifGround) {
      _Jump();
    }

    if (m_ifGround) {
      if (_playerID == 1) {
        float _move = Input.GetAxisRaw("Horizontal_joy1") + Input.GetAxisRaw("Horizontal_k1");
        if (_move > 0.4) {
          m_rigidbody.velocity = new Vector2(_moveSpeed, m_rigidbody.velocity.y);
        } else if (_move < -0.4) {
          m_rigidbody.velocity = new Vector2(-_moveSpeed, m_rigidbody.velocity.y);
        } else {
          m_rigidbody.velocity = new Vector2(0, m_rigidbody.velocity.y);
        }
        if (_move > 0.4 && !m_faceToRight) {
          _Flip();
        } else if (_move < -0.4 && m_faceToRight) {
          _Flip();
        }
      } else if (_playerID == 2) {
        float _move = Input.GetAxisRaw("Horizontal_joy2") + Input.GetAxisRaw("Horizontal_k2");
        if (_move > 0.4) {
          m_rigidbody.velocity = new Vector2(_moveSpeed, m_rigidbody.velocity.y);
        } else if (_move < -0.4) {
          m_rigidbody.velocity = new Vector2(-_moveSpeed, m_rigidbody.velocity.y);
        } else {
          m_rigidbody.velocity = new Vector2(0, m_rigidbody.velocity.y);
        }
        if (_move > 0.4 && !m_faceToRight) {
          _Flip();
        } else if (_move < -0.4 && m_faceToRight) {
          _Flip();
        }
      }
    }
  }
  

}
