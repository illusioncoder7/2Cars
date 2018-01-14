using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour {
	public Transform spawnPointL,spawnPointR;
	int noOfObjects=5;
	Vector3 spawnPosition,tempSpawnPosL,tempSpawnPosR;
	// Use this for initialization

	//impelemnt zigzig way

	void Start () {
		makeScene ();
		//fix the spawnpoint for other time as it goes outside the camera
	}
	public void makeScene(){
		tempSpawnPosL = spawnPointL.position;
		tempSpawnPosR = spawnPointR.position;
		for (int i = 0; i < noOfObjects; i++) {

			findPorbabilityOfPosition ();
			findProbabilityAndSpawnObject ();
			updateSpawnPoint ();
		}
	}
	void findPorbabilityOfPosition(){
		float temp = Random.Range (0f, 1f);
		if (temp > .5f) {
		//choose left
		//	Debug.Log("left choosed");
			spawnPosition=tempSpawnPosL;

		} else {
			//choose right
			//Debug.Log("right choosed");
			spawnPosition = tempSpawnPosR;
		}
	}
	void findProbabilityAndSpawnObject(){
		float temp = Random.Range (0f, 1f);
		if (temp > .5f) {
			//choose obstracle
		//	Debug.Log("obstracle choosed");
			spawnObjects(GameManager.Instance.getObstracle());
		} else {
			//choose power
			//Debug.Log("power choosed");
			spawnObjects(GameManager.Instance.getPower());
		}
	}

	void updateSpawnPoint(){
		tempSpawnPosL = new Vector3 (tempSpawnPosL.x, tempSpawnPosL.y + GameManager.Instance.objectGap, tempSpawnPosL.z);
		tempSpawnPosR = new Vector3 (tempSpawnPosR.x, tempSpawnPosR.y + GameManager.Instance.objectGap, tempSpawnPosR.z);
	}
	void spawnObjects(GameObject toSpawn){
		toSpawn.transform.position = spawnPosition;
		toSpawn.SetActive (true);

	}
	public void addObjects(){
		findPorbabilityOfPosition ();
		findProbabilityAndSpawnObject ();
	}
}
