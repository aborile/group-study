using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour {

    string gameSceneOverIn;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickButtonMain()
    {
        Debug.Log("Clicked in Main Scene!");
        GameFlow.isFirst = true;
        GameFlow.state = "selectStage";
        Debug.Log("all have been changed in UIMagager");

    }

    public void OnClickButtonSelect(Button b)
    {
        Debug.Log("Clicked in Select Scene!");
        GameFlow.isFirst = true;
        if (b.gameObject.name == "stage1")
        {
            GameFlow.state = "inGameStage1";
            Debug.Log("Start Stage 1");
        }
        else if (b.gameObject.name == "stage2")
        {
            GameFlow.state = "inGameStage2";
            Debug.Log("Start Stage 2");
        }
        else if (b.gameObject.name == "stage3")
        {
            GameFlow.state = "inGameStage3";
            Debug.Log("Start Stage 3");
        }
    }

    public void OnClickButtonInGame(Button b)
    {
        Debug.Log("Clicked in Game Scene!");
        GameFlow.isFirst = true;
        if (b.gameObject.name == "over")
        {
            Debug.Log("Game Over!");
            gameSceneOverIn = SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 1);
            GameFlow.state = "gameOver";
        }
        else if (b.gameObject.name == "clear")
        {
            Debug.Log("Game Clear!");
            gameSceneOverIn = SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 1);
            GameFlow.LastScene(gameSceneOverIn);
            GameFlow.state = "gameClear";
        }
    }

    public void OnClickButtonGameOver()
    {
        Debug.Log("Clicked in GameOver Scene!");
        GameFlow.isFirst = true;
        GameFlow.state = "inGameStage" + GameFlow.gameScenePlayedLast;
    }

    public void OnClickButtonGameClear()
    {
        Debug.Log("Clicked in GameClear Scene!");
        GameFlow.isFirst = true;
        GameFlow.state = "result";
    }

    public void OnClickButtonResult()
    {
        Debug.Log("Clicked in Result Scene!");
        GameFlow.isFirst = true;
        GameFlow.state = "selectStage";
    }

    public void OnClickButtonRestart()
    {
        Debug.Log("Restart the game!");
        GameFlow.isFirst = true;
        gameSceneOverIn = SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 1);
        GameFlow.state = "gameOver";
    }

    public void OnClickButtonQuit()
    {
        Debug.Log("Quit the game!");
        GameFlow.isFirst = true;
        gameSceneOverIn = SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 1);
        GameFlow.state = "selectStage";
    }
}
