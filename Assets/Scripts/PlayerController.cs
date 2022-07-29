using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed = 3f;

	private bool m_IfUpFloor = false;

  // 是否处于移动状态
  private bool isMoving;
  // 移动音效素材
  public AudioSource sfx_move;

  // Use this for initialization
  void Start () {
    sfx_move = GetComponent<AudioSource>();
    sfx_move.loop = true;
  }

  // Update is called once per frame
  void Update()
  {
    float inputX = Input.GetAxis("Horizontal");
    float inputZ = Input.GetAxis("Vertical");
    Vector3 move = new Vector3(inputX, 0, inputZ);
    GetComponent<Rigidbody>().velocity = move * speed;

    if (move != Vector3.zero && !isMoving)
    {
      isMoving = true;
      if (!sfx_move.isPlaying) { sfx_move.Play(); }
    }
    else if (move == Vector3.zero && isMoving)
    {
      isMoving = false;
      if (sfx_move.isPlaying) { sfx_move.Stop(); }
    }
  }

}
