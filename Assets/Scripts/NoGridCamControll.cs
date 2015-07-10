using UnityEngine;
using System.Collections;

public class NoGridCamControll : MonoBehaviour {

	private Camera thisCamera;

	void Awake(){

		thisCamera = this.GetComponent<Camera>();

	}

	void Update () {

		
		thisCamera.pixelRect = new Rect(Input.mousePosition.x - 100.0f, Input.mousePosition.y - 100.0f, thisCamera.pixelRect.width, thisCamera.pixelRect.height);
	
	}
}
