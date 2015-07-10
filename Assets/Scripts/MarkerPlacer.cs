using UnityEngine;
using System.Collections;

public class MarkerPlacer : MonoBehaviour {

	RaycastHit rcHit;
	public GameObject[] markerList = new GameObject[1];
	public int selectedMarker = 0;
	public bool enabled = true;

	private GameObject currentMarker;

	public enum Marker{

		PlayerStart = 0,
		GameEnd = 1

	}

	GameInfo gi;

	void Start () {

		setCurrentMarker (Marker.PlayerStart);

		gi = GetComponent<GameInfo> ();

	}
	
	void Update () {
		
		Ray ray = this.GetComponent<Camera> ().ScreenPointToRay (Input.mousePosition);
		
		if (Physics.Raycast (ray, out rcHit, Mathf.Infinity) && enabled && Input.GetMouseButtonDown(0)){

			currentMarker.SetActive(true);
			GameObject TMP = Instantiate(currentMarker, new Vector3(rcHit.point.x, 1.0f, rcHit.point.z), Quaternion.identity) as GameObject;
			TMP.transform.RotateAround(TMP.transform.position, new Vector3(1,0,0), -90.0f);

			if(TMP.tag == "SpawnPoint"){

				Debug.Log("Added a spawn point @" + TMP.transform.position.ToString());
				gi.AddSpawnPoint(TMP.transform.position);

			}
			
		} else {

			currentMarker.SetActive(false);

		}
		
	}

	public void setCurrentMarker(Marker markerToPlace){

		if (markerToPlace == Marker.PlayerStart) {

			currentMarker = markerList[0];

		}

	}


}
