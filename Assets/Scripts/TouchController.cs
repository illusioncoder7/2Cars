using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

	public GameObject LeftCar;
	public GameObject RightCar;

	AnimatingCar leftCarController,rightCarController;
	private float screenCenterX;

	private void Start()
	{
		// save the horizontal center of the screen
		screenCenterX = Screen.width * 0.5f;
		leftCarController = LeftCar.GetComponent<AnimatingCar> ();
		rightCarController = RightCar.GetComponent<AnimatingCar> ();
	}

	private void Update()
	{
		// if there are any touches currently
		if(Input.touchCount > 0)
		{
			// get the first one
			Touch firstTouch = Input.GetTouch(0);

			// if it began this frame
			if(firstTouch.phase == TouchPhase.Began)
			{
				if(firstTouch.position.x > screenCenterX)
				{
					//Debug.Log ("right car side");
					rightCarController.moveCar ();
					// if the touch position is to the right of center
					// move right
				}
				else if(firstTouch.position.x < screenCenterX)
				{
				//	Debug.Log ("left car side");
					leftCarController.moveCar ();
					// if the touch position is to the left of center
					// move left
				}
			}
		}
	}
}