///<summary>
///定义机器人运动跳跃等
/// </summary>
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
  [SerializeField]
  private float _rushSpeedMin = -6f;

  private const float m_groundedRadius = 0.2f;
  private bool m_ifGround;
  private bool m_ifRushGround = true;
  private bool m_afterWorldFlip = false;
  private bool m_faceToRight = true;
  private Transform m_groundTransform;
  private Rigidbody2D m_rigidbody;

  /// <summary>
  /// 跟随世界进行翻转
  /// </summary>
  public void FollowWorldFlip() {
    this.transform.Rotate(180f, 0, 0);
    m_afterWorldFlip=true;
  }

  private void _Jump() {
    m_rigidbody.AddForce(new Vector2(0, _jumpForce));
    m_ifGround = false;
  }

  private void _Flip() {
    this.transform.localScale = new Vector3(-transform.localScale.x , transform.localScale.y, transform.localScale.z);
    m_faceToRight = !m_faceToRight;
  }

  /// <summary>
  /// 判断是否人物滞空后是否落到地上，以及是否把地板冲了
  /// </summary>
  private void _IfOnGround() {
    m_ifGround = false;
    Collider2D[] colliders = Physics2D.OverlapCircleAll(m_groundTransform.position, m_groundedRadius);
    for (int i = 0; i < colliders.Length; i++) {
      if (colliders[i].gameObject != gameObject) {
        m_ifGround = true;
        if (m_ifRushGround && m_rigidbody.velocity.y < _rushSpeedMin && colliders[i].gameObject.name.Equals("Plane")) {
          m_ifRushGround = false;
          if (!m_afterWorldFlip) {
            colliders[i].gameObject.GetComponent<PlaneController>().BeRushed();
          } else {
            m_afterWorldFlip = false;
          }
        }
      }
    }
  }

  void Start() {
    m_groundTransform = transform.Find("GroundCheck");
    m_rigidbody = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate() {

    //判断人物是否在地面上
    if (m_rigidbody.velocity.y < 0) {
      _IfOnGround();
    }

    //判断人物有没有资格去冲地板
    //用来防止连续冲地板
    if (m_rigidbody.velocity.y == 0) {
      m_ifRushGround = true;
    }

    // jump
    if ( ( (_playerID == 1 && (Input.GetAxis("jump_k1") != 0 ) ) ||
           (_playerID == 2 && (Input.GetAxis("jump_k2") != 0 ) ) )  &&
          m_ifGround) {
      _Jump();
    }

    //move
    if (m_ifGround) {
      if (_playerID == 1) {
        float _move = Input.GetAxisRaw("Horizontal");
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
        float _move = Input.GetAxisRaw("Horizontal2");
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
