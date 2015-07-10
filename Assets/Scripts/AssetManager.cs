using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AssetManager : MonoBehaviour {

	private Dictionary<string, Tile> tilesInLibrary = new Dictionary<string, Tile>();
	private Dictionary<string, Tile> tilesInProject = new Dictionary<string, Tile>();

	public Tile[] preloadedTiles = new Tile[3];

	public Tile defaultTile;

	void Awake(){

		AddTileToLibrary(defaultTile);
		ImportTileToProject(defaultTile.tileKey);

		AddTileToLibrary(preloadedTiles[0]);
		ImportTileToProject(preloadedTiles[0].tileKey);

	}

	public void AddTileToLibrary(Tile tileObject){

		tilesInLibrary.Add(tileObject.tileKey, tileObject);

	}

	public bool ImportTileToProject(string tileKey){

		if(tilesInLibrary.ContainsKey(tileKey)){

			Tile TMP = tilesInLibrary[tileKey];
			tilesInProject.Add (tileKey, TMP);
			return true;

		}

		return false;

	}

	public Tile GetTileByKey(string tileKey){

		return tilesInProject[tileKey];

	}

	public int GetNumberOfTilesInProject(){

		return tilesInProject.Count;

	}

	public List<Tile> GetAllTilesInProject(){

		List<Tile> allTiles = new List<Tile>();

		foreach(Tile t in tilesInProject.Values){

			allTiles.Add(t);

		}

		return allTiles;

	}
}
