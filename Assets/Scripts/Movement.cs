using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	Transform myTransform;
	string side;
	// Use this for initialization
	void Awake () {
		myTransform = GetComponent<Transform> ();
	}
	void OnEnable(){
		side = checkSideOfObject ();
	}
	
	// Update is called once per frame
	void Update () {
		myTransform.position += Vector3.down * GameManager.Instance.speed*Time.deltaTime;
		if (GameManager.Instance.endPoint.position.y > myTransform.position.y) {
		//outside the camera
			gameObject.SetActive(false);
			GameManager.Instance.respawnObjects(side);
			//Debug.Log("out the camera");
		}
	}
	string checkSideOfObject(){
		if (myTransform.position.x < 0) {
			//left side
			return "left";
		} else {
			return "right";
		}
	}
}
