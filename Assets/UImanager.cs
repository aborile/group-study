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
        GameFlow.LoadScene("selectStage");
        Debug.Log("all have been changed in UIMagager");

    }

    public void OnClickButtonSelect(Button b)
    {
        Debug.Log("Clicked in Select Scene!");
        if (b.gameObject.name == "stage1")
        {
            GameFlow.LoadScene("inGameStage1");
            Debug.Log("Start Stage 1");
        }
        else if (b.gameObject.name == "stage2")
        {
            GameFlow.LoadScene("inGameStage2");
            Debug.Log("Start Stage 2");
        }
        else if (b.gameObject.name == "stage3")
        {
            GameFlow.LoadScene("inGameStage3");
            Debug.Log("Start Stage 3");
        }
    }

    public void OnClickButtonInGame(Button b)
    {
        Debug.Log("Clicked in Game Scene!");
        if (b.gameObject.name == "over")
        {
            Debug.Log("Game Over!");
            gameSceneOverIn = SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 1);
            GameFlow.LoadScene("gameOver");
        }
        else if (b.gameObject.name == "clear")
        {
            Debug.Log("Game Clear!");
            gameSceneOverIn = SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 1);
            GameFlow.LastScene(gameSceneOverIn);
            GameFlow.LoadScene("gameClear");
        }
    }

    public void OnClickButtonGameOver()
    {
        Debug.Log("Clicked in GameOver Scene!");
        GameFlow.LoadScene("inGameStage" + GameFlow.gameScenePlayedLast);
    }

    public void OnClickButtonGameClear()
    {
        Debug.Log("Clicked in GameClear Scene!");
        GameFlow.LoadScene("result");
    }

    public void OnClickButtonResult()
    {
        Debug.Log("Clicked in Result Scene!");
        GameFlow.LoadScene("selectStage");
    }

    public void OnClickButtonRestart()
    {
        Debug.Log("Restart the game!");
        gameSceneOverIn = SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 1);
        GameFlow.LoadScene("gameOver");
    }

    public void OnClickButtonQuit()
    {
        Debug.Log("Quit the game!");
        gameSceneOverIn = SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 1);
        GameFlow.LoadScene("selectStage");
    }
}
