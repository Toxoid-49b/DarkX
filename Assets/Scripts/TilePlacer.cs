using UnityEngine;
using System.Collections;

public class TilePlacer : MonoBehaviour {

	public RaycastHit rcHit;
	private Tile currentTile;
	public bool enabled;

	private GameInfo gameInfo;
	private AssetManager assetMan;

	void Start () {
	
		gameInfo = GetComponent<GameInfo>();
		assetMan = GetComponent<AssetManager>();

	}

	void Update () {

		Ray ray = this.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast (ray, out rcHit, Mathf.Infinity) && Input.GetMouseButtonDown(0) && enabled){

			Vector3 tempHitPos = rcHit.point;
			float roundedHitX = (Mathf.Floor(tempHitPos.x / 2) * 2) / 2;
			float roundedHitZ = (Mathf.Floor(tempHitPos.z / 2) * 2) / 2;

			if(!gameInfo.isTileAtLoc(new Vector3((float)roundedHitX, 0.0f, (float)roundedHitZ))){

				Debug.Log("No Tile @ X:" +  roundedHitX + " Z:" + roundedHitZ);
				Instantiate(currentTile.gameObject, new Vector3(((float)roundedHitX * 2.0f) + 1.0f, 0.0f, ((float)roundedHitZ * 2.0f) + 1.0f), currentTile.transform.rotation);
				gameInfo.registerTileAtLoc(new Vector3(roundedHitX, 0, roundedHitZ));

			} else {

				Debug.Log("Tile @ X:" +  roundedHitX + " Z:" + roundedHitZ);
				
			}
			
			
		}


	}

	public void SetCurrentTile(string tileKey){

		currentTile = assetMan.GetTileByKey(tileKey);

	}
}
