using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickButtonMain()
    {
        Debug.Log("Clicked in Main Scene!");
        GameFlow.state = "selectStage";

    }

    public void OnClickButtonSelect(Button b)
    {
        Debug.Log("Clicked in Select Scene!");
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
        if (b.gameObject.name == "over")
        {
            Debug.Log("Game Over!");
            GameFlow.state = "gameOver";
        }
        else if (b.gameObject.name == "clear")
        {
            Debug.Log("Game Clear!");
            GameFlow.state = "gameClear";
        }
    }

    public void OnClickButtonGameOver()
    {
        Debug.Log("Clicked in GameOver Scene!");
        GameFlow.state = "inGame";
    }

    public void OnClickButtonGameClear()
    {
        Debug.Log("Clicked in GameClear Scene!");
        GameFlow.state = "result";
    }

    public void OnClickButtonResult()
    {
        Debug.Log("Clicked in Result Scene!");
        GameFlow.state = "selectStage";
    }

    public void OnClickButtonRestart()
    {
        Debug.Log("Restart the game!");
        GameFlow.state = "gameOver";
    }

    public void OnClickButtonQuit()
    {
        Debug.Log("Quit the game!");
        GameFlow.state = "selectStage";
    }
}
