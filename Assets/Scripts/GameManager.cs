using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
	private static GameManager instance=null;
	public GameObject obstracle, power;
	public List<GameObject> obstracleList = new List<GameObject> ();
	public List<GameObject>powerList = new List<GameObject> ();
	public int noOfObjects;
	public int objectGap;
	public int speed;
	int obstracleIndex;
	int powerIndex;
	public Transform endPoint;
	public RoadManager roadManagerL,roadManagerR;

    public  int Score;
    public int overGame;

    public Text scoreText;
    public Text gameOverText;
    public GameObject playButton,replayButton;
    public static GameManager Instance{
		get{
			if (instance == null) {
				instance = GameObject.FindGameObjectWithTag("Player").AddComponent<GameManager> ();
			}
			return instance;
		}

	}
	void Awake(){
		if ((instance) && instance.GetInstanceID () != GetInstanceID ()) {
			DestroyImmediate (instance);
		}
		else{
			instance = this;
			//DontDestroyOnLoad(gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		Score = 0;
        obstracleIndex = 0;
		powerIndex = 0;
		makeObstracle ();
		makePower ();
        playPause();
		//SceneManager.LoadScene ("game");

	}
	void makeObstracle(){
		for (int i = 0; i < noOfObjects; i++) {
			obstracleList.Add (Instantiate (obstracle));
			obstracleList [i].SetActive (false);
			//obstracleList [i].transform.SetParent (instance.gameObject.transform);
		}
	}
	void makePower(){
		for (int i = 0; i < noOfObjects; i++) {
			powerList.Add (Instantiate (power));
			powerList [i].SetActive (false);
			//powerList [i].transform.SetParent (instance.gameObject.transform);
		}
	}
	//need to set active
	public GameObject getObstracle(){
		GameObject temp = obstracleList [obstracleIndex];
		obstracleIndex++;
		checkBoundary ();
		return temp;

	}
	//need to set active
	public GameObject getPower(){
		GameObject temp = powerList [powerIndex];
		powerIndex++;
		checkBoundary ();
		return temp;
	}
	void checkBoundary(){
		obstracleIndex = obstracleIndex % noOfObjects;
		powerIndex = powerIndex % noOfObjects;
	}
	public void respawnObjects(string message){
		if (string.Compare("left", message)==0) {
			roadManagerL.addObjects ();
		}
			else if(string.Compare("right", message)==0) {
			roadManagerR.addObjects ();
		}

	}
    void Update()
    {
        //Score = obstracle.GetComponent<ObstracleProperty>().score;
       
        scoreText.text = "Score:" + Score;
    /*    if(overGame==1)
        {
            gameOverText.text = "GameOver";
            playPause();
        }*/
    }
    public void Gameplay()
    {
        Time.timeScale = 1;
        playButton.SetActive(false);
		replayButton.SetActive (false);
    }
    void playPause()
    {
		
        Time.timeScale = 0;
        
    }
	public void gameOver(){
		Score = 0;
		playPause();
		collectAllObjects ();
		replayButton.SetActive (true);
	}
	void collectAllObjects(){
		for (int i = 0; i < noOfObjects; i++) {
			obstracleList [i].SetActive (false);
			powerList [i].SetActive (false);
			powerIndex = 0;
			obstracleIndex = 0;
		}
		roadManagerL.makeScene ();
		roadManagerR.makeScene ();

	}
}
