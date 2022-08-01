using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: 考虑抽象地命名为 Movable
public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed = 3f;

	private bool m_IfUpFloor = false;

  // 是否处于移动状态
  private bool isMoving;

  void Start () {

  }

  void Update()
  {
    float inputX = Input.GetAxis("Horizontal");
    float inputZ = Input.GetAxis("Vertical");
    Vector3 move = new Vector3(inputX, 0, inputZ);
    GetComponent<Rigidbody>().velocity = move * speed;

    if (move != Vector3.zero && !isMoving)
    {
      isMoving = true;
      AudioManager.Play(AudioName.PlayerMove);
    }
    else if (move == Vector3.zero && isMoving)
    {
      isMoving = false;
      AudioManager.Stop(AudioName.PlayerMove);
    }
  }

}
