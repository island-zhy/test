using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {

	public void BeRushed() {
		this.transform.position -= new Vector3(0, 1, 0);
	}

}
