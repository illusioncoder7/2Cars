using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstracleProperty : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D collider){
      //  Debug.Log("obstacle");
		if (collider.gameObject.CompareTag ("Player")) {
			GameManager.Instance.overGame++;
			GameManager.Instance.gameOver ();
		}
	}

}
