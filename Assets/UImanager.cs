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
            Debug.Log("Start Stage 1");
        }
        else if (b.gameObject.name == "stage2")
        {
            Debug.Log("Start Stage 2");
        }
        else if (b.gameObject.name == "stage3")
        {
            Debug.Log("Start Stage 3");
        }
        GameFlow.state = "inGame";
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
}
