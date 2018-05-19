using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour {

    public static string state;
    public static GameFlow instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        state = "main";
    }
    // Update is called once per frame
    void Update () {
		switch (state)
        {
            case "main":
                onStateMain();
                break;
            case "selectStage":
                onStateSelectStage();
                break;
            case "inGame":
                onStateInGame();
                break;
            case "gameOver":
                onStateGameOver();
                break;
            case "gameClear":
                onStateGameClear();
                break;
            case "result":
                onStateResult();
                break;
        }
	}
    
    void onStateMain()
    {
        if (SceneManager.GetActiveScene().name != "Main") {
            //init. load the stage info
            Debug.Log("loading . . .");
            SceneManager.LoadScene("Main");
        }
    }

    void onStateSelectStage()
    {
        if (SceneManager.GetActiveScene().name != "SelectStage")
        {
            SceneManager.LoadScene("SelectStage");
        }
        //init stage data
    }
    
    void onStateInGame() {
        if (SceneManager.GetActiveScene().name != "InGame")
        {
            SceneManager.LoadScene("InGame");
        }
        //update UI of player color
        //click menu button to move to Menu Scene
        //or GameOver
    }

    void onStateGameOver() {
        if (SceneManager.GetActiveScene().name != "GameOver")
        {
            SceneManager.LoadScene("GameOver");
        }
        //Fade-out
        //unable to move player
    }

    void onStateGameClear() {
        if (SceneManager.GetActiveScene().name != "GameClear")
        {
            SceneManager.LoadScene("GameClear");
        }
        //unable to move player
        //save data of cleared stage
    }

    void onStateResult() {
        if (SceneManager.GetActiveScene().name != "Result")
        {
            SceneManager.LoadScene("Result");
        }
        //show result
    }
}
