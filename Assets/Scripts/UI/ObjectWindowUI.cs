using UnityEngine;
using System.Collections;

public class ObjectWindowUI : MonoBehaviour {

	private int selGridInt = 0;
	public string[] selStrings = new string[] {"Entities", "Markers", "Tiles", "Prefabs"};

	private Vector2 markerMenuScrollPosition = Vector2.zero;
	private Vector2 tileMenuScrollPosition = Vector2.zero;

	MarkerPlacer mp;
	TilePlacer tp;
	AssetManager am;

	public bool enabled;

	int menuNumTop = 3;
	int menuNumBottom = 0;

	public GUISkin UISkin;

	void Start () {

		mp = GetComponent<MarkerPlacer> ();
		tp = GetComponent<TilePlacer> ();
		am = GetComponent<AssetManager>();

		mp.enabled = false;
		tp.enabled = true;

		tp.SetCurrentTile("com.antimatterinc.darkxtiles.default:default_floor");

	}
	
	void Update () {
	
	}

	void OnGUI(){

		GUI.skin = UISkin;

		GUI.Box (new Rect(0,0, 150, Screen.height), "");
		selGridInt = GUI.SelectionGrid(new Rect(0, 0, 150, 50), selGridInt, selStrings, 2);

		if(selGridInt == 0){

		} else if(selGridInt == 1){

			markerMenu();

		} else if(selGridInt == 2){

			tileMenu();
	
		}


	}

	void tileMenu(){

		if(GUI.Button(new Rect(10, 60, 130, 40), "Import")){

			UIStatusBank.LibraryUI = true;

		}

		GUI.Box(new Rect(0, 115, 150, Screen.height - 115), "");
		markerMenuScrollPosition = GUI.BeginScrollView(new Rect(0, 115, 150, Screen.height - 115), this.markerMenuScrollPosition, new Rect(0, 60, 130, ((am.GetNumberOfTilesInProject() * 120) + (10 * (am.GetNumberOfTilesInProject() + 1)))));

		int I = 0;

			foreach(Tile t in am.GetAllTilesInProject()){
				
				if(GUI.Button(new Rect(10, 75 + ((120 * I) + (10 * I)), 120, 120), t.tileName)){
					
					tp.SetCurrentTile(t.tileKey);
					mp.enabled = false;
					tp.enabled = true;

				}

				I++;

			}

		GUI.EndScrollView();


	}

	void markerMenu(){

		GUI.Box(new Rect(0, 60, 150, Screen.height - 60), "");
		markerMenuScrollPosition = GUI.BeginScrollView(new Rect(0, 60, 150, Screen.height - 60), this.markerMenuScrollPosition, new Rect(0, 60, 130, Screen.height));

		if (GUI.Button (new Rect (10, 70, 120, 120), "Player Start")) {

			mp.setCurrentMarker(MarkerPlacer.Marker.PlayerStart);
			mp.enabled = true;
			tp.enabled = false;

		}

		GUI.EndScrollView();

	}
}
