using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour {

    public static string state;
    public static GameFlow instance = null;

    public parser p;
    GameObject text1, text2, text3;


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
    void Start ()
    {
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
            case "inGameStage1":
                onStateInGame1();
                break;
            case "inGameStage2":
                onStateInGame2();
                break;
            case "inGameStage3":
                onStateInGame3();
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
        text1 = GameObject.Find("Text1");
        text2 = GameObject.Find("Text2");
        text3 = GameObject.Find("Text3");
        p = GameObject.Find("GameObject").GetComponent<parser>();
        p.makeData();
        if (p.isCleared != null && (text1 != null && text2 != null && text3 != null))
        {
            text1.SetActive(p.isCleared[0]);
            text2.SetActive(p.isCleared[1]);
            text3.SetActive(p.isCleared[2]);
        }
    }
    
    void onStateInGame1() {
        if (SceneManager.GetActiveScene().name != "InGameStage1")
        {
            SceneManager.LoadScene("InGameStage1");
        }
        //update UI of player color
        //click menu button to move to Menu Scene
        //or GameOver
    }
    void onStateInGame2()
    {
        if (SceneManager.GetActiveScene().name != "InGameStage2")
        {
            SceneManager.LoadScene("InGameStage2");
        }
        //update UI of player color
        //click menu button to move to Menu Scene
        //or GameOver
    }
    void onStateInGame3()
    {
        if (SceneManager.GetActiveScene().name != "InGameStage3")
        {
            SceneManager.LoadScene("InGameStage3");
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
