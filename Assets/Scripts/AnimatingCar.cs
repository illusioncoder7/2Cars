using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatingCar : MonoBehaviour {
	public float lenGap; 
	public Vector3 target;
	public bool dirnLeft;
	Animator carController;
	// Use this for initialization
	void Start () {
		carController = GetComponent<Animator> ();
	}
	public void moveCar(){
		if (dirnLeft) {
			//need to go to left
			dirnLeft = false;
			moveLeft ();

		} else {
		//need to go right
			dirnLeft=true;
			moveRight ();
		}
	}
	void moveLeft(){
		carController.SetTrigger ("left");
	}
	void moveRight(){
		carController.SetTrigger ("right");
	}
}
