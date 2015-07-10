using UnityEngine;
using System.Collections;

public class LibraryUI : MonoBehaviour {

	bool isVisible;
	public GUISkin UISkin;

	void Start () {
	
		isVisible = false;

	}
	
	void Update () {
	
		isVisible = UIStatusBank.LibraryUI;

	}

	void OnGUI(){

		GUI.skin = UISkin;

		if(isVisible){

			Rect libraryBoxRect = new Rect(170, 20, Screen.width - 190, Screen.height - 40);

			GUI.Box(libraryBoxRect, "Library");

		}

	}
}
