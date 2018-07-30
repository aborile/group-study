using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour {

    public static string state;
    public static GameFlow instance = null;
    public static int gameScenePlayedLast;
    public static bool isFirst;
    public static int gameScore;

    public parser p;
    GameObject text1, text2, text3, complete, clear, fail;

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
        isFirst = true;
    }
    // Update is called once per frame
    void Update () {
        //if (isFirst) {
            Debug.Log("message from GameFlow.cs Update()");
            switch (state)
            {
                case "main":
                    //Debug.Log("message from GameFlow.cs case main");
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
        //}
	}

    private void LateUpdate()
    {
        //if (isFirst) Debug.Log(isFirst + "from LateUpdate()");
        //isFirst = false;
    }

    void onStateMain()
    {
        if (SceneManager.GetActiveScene().name != "Main") {
            //init. load the stage info
            Debug.Log("loading . . .");
            SceneManager.LoadScene("Main");
        }
        //Debug.Log(SceneManager.GetActiveScene().name);

        isFirst = false;
    }

    void onStateSelectStage()
    {
        if (SceneManager.GetActiveScene().name != "SelectStage")
        {
            Debug.Log("Game Scene Changed");
            SceneManager.LoadScene("SelectStage");
        }
        //init stage data
        Debug.Log("init stage data");
        text1 = GameObject.Find("Text1");
        text2 = GameObject.Find("Text2");
        text3 = GameObject.Find("Text3");
        //text1.SetActive(false);
        //text2.SetActive(false);
        //text3.SetActive(false);
        p = GameObject.Find("GameObject").GetComponent<parser>();
        if (p.isCleared != null && (text1 != null && text2 != null && text3 != null))
        {
            Debug.Log("text active");
            text1.SetActive(p.isCleared[0]);
            text2.SetActive(p.isCleared[1]);
            text3.SetActive(p.isCleared[2]);
        }
        //Debug.Log(SceneManager.GetActiveScene().name);

        Debug.Log("change isFirst");
        isFirst = false;
    }
    
    void onStateInGame1() {
        if (SceneManager.GetActiveScene().name != "InGameStage1")
        {
            SceneManager.LoadScene("InGameStage1");
            LastScene("1");
        }
        //update UI of player color
        //click menu button to move to Menu Scene
        //or GameOver
        //Debug.Log(SceneManager.GetActiveScene().name);

        isFirst = false;
    }
    void onStateInGame2()
    {
        if (SceneManager.GetActiveScene().name != "InGameStage2")
        {
            SceneManager.LoadScene("InGameStage2");
            LastScene("2");
        }
        //update UI of player color
        //click menu button to move to Menu Scene
        //or GameOver
        
        isFirst = false;
    }
    void onStateInGame3()
    {
        if (SceneManager.GetActiveScene().name != "InGameStage3")
        {
            SceneManager.LoadScene("InGameStage3");
            LastScene("3");
        }
        //update UI of player color
        //click menu button to move to Menu Scene
        //or GameOver

        isFirst = false;
    }

    void onStateGameOver() {
        if (SceneManager.GetActiveScene().name != "GameOver")
        {
            SceneManager.LoadScene("GameOver");
        }
        Debug.Log("You Died: Stage" + gameScenePlayedLast);
        //Fade-out
        //unable to move player

        isFirst = false;
    }

    void onStateGameClear() {
        if (SceneManager.GetActiveScene().name != "GameClear")
        {
            SceneManager.LoadScene("GameClear");
        }
        //unable to move player
        //save data of cleared stage
        //LastScene(SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 1));
        //Debug.Log("Clear stage " + gameScenePlayedLast);
        p.isCleared[gameScenePlayedLast - 1] = true;
        p.Edit(gameScenePlayedLast);

        state = "result";
    }

    void onStateResult() {
        if (SceneManager.GetActiveScene().name != "Result")
        {
            SceneManager.LoadScene("Result");
        }
        //show result
        complete = GameObject.Find("complete");
        clear = GameObject.Find("clear");
        fail = GameObject.Find("failed");
        if (complete != null && clear != null && fail != null)
        {
            if (gameScore == 100)
            {
                complete.SetActive(true);
                clear.SetActive(false);
                fail.SetActive(false);
            }
            else if (gameScore >= 70)
            {
                complete.SetActive(false);
                clear.SetActive(true);
                fail.SetActive(false);
            }
            else
            {
                complete.SetActive(false);
                clear.SetActive(false);
                fail.SetActive(true);
            }
        }

        isFirst = false;
    }

    public static void LastScene(string sceneNum)
    {
        gameScenePlayedLast = sceneNum[0] - '0';
    }
}
