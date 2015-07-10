using UnityEngine;
using System.Collections;

public class MainToolbar : MonoBehaviour {

	private int selectedToolButton = 4;

	public string[] toolbarStrings = new string[] {"Test", "Build", "Debug"};
	public GameObject[] ObjectsToDisableOnTest = new GameObject[2];
	public GameObject FPSPlayerGameObject;
	public GameInfo gameInfo;
	public GUISkin UISkin;

	void Awake(){

		gameInfo = GetComponent<GameInfo>();

	}

	void OnGUI(){

		GUI.skin = UISkin;
		selectedToolButton = GUI.Toolbar(new Rect(160, 0, Screen.width - 170, 25), selectedToolButton, toolbarStrings);

	}

	void Update(){

		if(selectedToolButton != toolbarStrings.Length + 1){

			Debug.Log ("TBItem " + selectedToolButton + " was clicked!");

			if(selectedToolButton == 0){

				foreach(GameObject g in ObjectsToDisableOnTest){

					g.SetActive(false);

				}

				Instantiate(FPSPlayerGameObject, gameInfo.GetRandomSpawnPoint(), Quaternion.identity);

			}


		}

		selectedToolButton = toolbarStrings.Length + 1;

	}
}
