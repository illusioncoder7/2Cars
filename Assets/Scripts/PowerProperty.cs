using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerProperty : MonoBehaviour {
	string side;
	void OnEnable(){
		side = checkSideOfObject ();
	}
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.CompareTag("Player")){
		//Debug.Log ("powwer");
        GameManager.Instance.Score++;
			Debug.Log (""+ GameManager.Instance.Score);
		gameObject.SetActive (false);
		GameManager.Instance.respawnObjects(side);
		}
    }
	string checkSideOfObject(){
		if (transform.position.x < 0) {
			//left side
			return "left";
		} else {
			return "right";
		}
	}
}
