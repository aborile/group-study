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
        onStateInitGame();
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
            case "initStage":
                onStateInitStage();
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
                break;
        }
	}

    void onStateInitGame() {
        //init. load the stage info
        Debug.Log("loading . . .");
        state = "main";
    }

    void onStateMain() {
        if (SceneManager.GetActiveScene().name != "Main") {
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

    void onStateInitStage()
    {
        if (SceneManager.GetActiveScene().name != "InitStage")
        {
            SceneManager.LoadScene("InitStage");
        }
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

    public void OnClick(Button b)
    {
        if (b.gameObject.name == "MainButton")
        {
            Debug.Log("Clicked in Main Scene!");
            state = "selectStage";
        }
        else if (b.gameObject.name == "SelectButton")
        {
            Debug.Log("Clicked in Select Scene!");
            state = "initStage";
        }
        else if (b.gameObject.name == "StageButton")
        {
            Debug.Log("Clicked in InitStage Scene!");
            state = "inGame";
        }
        else if (b.gameObject.name == "OverButton")
        {
            Debug.Log("Clicked in Game Scene!");
            state = "gameOver";
        }
        else if (b.gameObject.name == "ClearButton")
        {
            Debug.Log("Clicked in Game Scene!");
            state = "gameClear";
        }
        else if (b.gameObject.name == "AgainButton")
        {
            Debug.Log("Clicked in GameOver Scene!");
            state = "initStage";
        }
        else if (b.gameObject.name == "ResultButton")
        {
            Debug.Log("Clicked in GameClear Scene!");
            state = "result";
        }
        else if (b.gameObject.name == "PlayButton")
        {
            Debug.Log("Clicked in Result Scene!");
            state = "selectStage";
        }
    }
}
