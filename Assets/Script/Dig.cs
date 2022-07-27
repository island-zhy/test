using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dig : MonoBehaviour {

	[SerializeField]
	private Sprite sprite1;
	[SerializeField]
	private Sprite sprite2;
	[SerializeField]
	private Sprite sprite3;

	private int growLevel = 0;

	private SpriteRenderer spriteRenderer;

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	

	public void OnMouseDown () {
		if (growLevel == 0) {
			spriteRenderer.sprite = sprite1;
			growLevel++;
		}else if (growLevel == 1) {
			spriteRenderer.sprite = sprite2;
			growLevel++;
		} else if (growLevel == 2) {
			spriteRenderer.sprite = sprite3;
			growLevel++;
		}
	}
}
