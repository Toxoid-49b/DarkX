using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameInfo : MonoBehaviour {

	private List<Vector3> spawnPoints = new List<Vector3>();
	private List<Vector3> tileLocDictionary = new List<Vector3>();

	public void AddSpawnPoint(Vector3 spawnPointToAdd){

		spawnPoints.Add(spawnPointToAdd);

	}

	public Vector3 GetRandomSpawnPoint(){

		return spawnPoints[Random.Range(0, spawnPoints.Count)];

	}
		
	public bool isTileAtLoc(Vector3 location){
		
		return tileLocDictionary.Contains(location);
		
	}
	
	public void registerTileAtLoc(Vector3 tile){
		
		tileLocDictionary.Add(tile);
		
	}

}
