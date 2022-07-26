using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AddNewBuilding : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {

	[SerializeField]
	private GameObject building;
	[SerializeField]
	private FacingCamera facingCamera;
	[SerializeField]
	private GameObject uiText;

  private List<GameObject> buildings = new List<GameObject>();
	private int buildingsNum = 0;
	private bool ifCreating = false;
	// Use this for initialization
	void Start () {
		buildings = new List<GameObject>();
	}

	public void OnPointerDown(PointerEventData eventData) {
		buildingsNum++;
		buildings.Add(Instantiate(building, building.transform.position, Camera.main.transform.rotation, facingCamera.transform));
		ifCreating = true;
	}

	public void OnPointerEnter(PointerEventData eventData) {
		uiText.SetActive(true);
	}

	public void OnPointerExit(PointerEventData eventData) {
		uiText.SetActive(false);
	}


	// Update is called once per frame
	void Update () {
		if (ifCreating) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				buildings[buildingsNum - 1].transform.position = hit.point;
			}
		}
		if (Input.GetMouseButtonUp(0)) {
			ifCreating = false;
			facingCamera.AddChild();
		}
	}
}
