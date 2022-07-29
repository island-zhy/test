using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float _speed = 3f;

	private bool m_ifUpFloor = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputZ = Input.GetAxis("Vertical");
		this.GetComponent<Rigidbody>().velocity = new Vector3(inputX, 0, inputZ) * _speed;
	}

	void OnTriggerStay(Collider collision) {
		if (Input.GetKeyDown(KeyCode.U)) {
			if (collision.gameObject.tag.Equals("Floor")) {
				if (!m_ifUpFloor) {
					this.transform.position = this.transform.position + new Vector3(0, 1.5f, 0);
					m_ifUpFloor = true;
				} else {
					this.transform.position = this.transform.position + new Vector3(0, -1.5f, 0);
					m_ifUpFloor = false;
				}
			}
		}
	}
}
