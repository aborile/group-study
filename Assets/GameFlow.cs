using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour {

    public static string state;
    public static GameFlow instance = null;
    public static int gameScenePlayedLast;
    public static bool isFirst, haveToInitText;
    public static int gameScore;

    public static HSV playerCol, destCol;

    public static string nextState = null;
    
    public parser p;
    public GameObject text1, text2, text3, text4;
    GameObject complete, clear, fail;

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
        //if (isFirst)
        {
            Debug.Log("message from GameFlow.cs Update()" + state);
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
        }
            //Debug.Log("Update ends;");
    }

    private void LateUpdate()
    {
        //if (isFirst) Debug.Log(isFirst + "from LateUpdate()");
        //if (isFirst)
            //isFirst = false;
        if (nextState != null)
        {
            state = nextState;
            isFirst = true;
            nextState = null;
        }
    }

    public static void LoadScene(string s)
    {

        Debug.Log("Called GameFlow.LoadScene function;");
        //Debug.Log("Text objects are now " + text1 + ", " + text2 + ", " + text3);
        nextState = s;
        isFirst = true;

        switch (s)
        {
            case "main":
                SceneManager.LoadScene("Main");
                break;
            case "selectStage":
                SceneManager.LoadScene("SelectStage");
                break;
            case "inGameStage1":
                SceneManager.LoadScene("InGameStage1");
                break;
            case "inGameStage2":
                SceneManager.LoadScene("InGameStage2");
                break;
            case "inGameStage3":
                SceneManager.LoadScene("InGameStage3");
                break;
            case "inGameStage4":
                SceneManager.LoadScene("InGameStage4");
                break;
            case "gameOver":
                SceneManager.LoadScene("GameOver");
                break;
            case "gameClear":
                SceneManager.LoadScene("GameClear");
                break;
            case "result":
                SceneManager.LoadScene("Result");
                break;
        }

        Debug.Log("set GameFlow.isFirst true;");

    }

    void onStateMain()
    {
        //Debug.Log(SceneManager.GetActiveScene().name);
        haveToInitText = true;
        isFirst = false;
    }

    void onStateSelectStage()
    {
        if (isFirst)
        {
            //init stage data
            //if (haveToInitText) {
            /* if (text1 == null || text2 == null || text3 == null) { 
                Debug.Log("initiate text objects");
                text1 = GameObject.Find("Text1");
                text2 = GameObject.Find("Text2");
                text3 = GameObject.Find("Text3");
                haveToInitText = false;
            }*/
            text1 = GameObject.Find("TextObject").GetComponent<TextManager>().text1;
            text2 = GameObject.Find("TextObject").GetComponent<TextManager>().text2;
            text3 = GameObject.Find("TextObject").GetComponent<TextManager>().text3;
            text4 = GameObject.Find("TextObject").GetComponent<TextManager>().text4;
            //text1.SetActive(false);
            //text2.SetActive(false);
            //text3.SetActive(false);
            p = GameObject.Find("GameObject").GetComponent<parser>();
            if (p.isCleared != null && (text1 != null && text2 != null && text3 != null))
            {
                text1.SetActive(p.isCleared[0]);
                text2.SetActive(p.isCleared[1]);
                text3.SetActive(p.isCleared[2]);
                text4.SetActive(p.isCleared[3]);
            }
            //Debug.Log(SceneManager.GetActiveScene().name);
            isFirst = false;
        }
    }
    
    void onStateInGame1()
    {
        LastScene("1");
        //update UI of player color
        //click menu button to move to Menu Scene
        //or GameOver
        //Debug.Log(SceneManager.GetActiveScene().name);
        isFirst = false;

    }
    void onStateInGame2()
    {
        LastScene("2");
        //update UI of player color
        //click menu button to move to Menu Scene
        //or GameOver
        isFirst = false;
    }
    void onStateInGame3()
    {
        LastScene("3");
        //update UI of player color
        //click menu button to move to Menu Scene
        //or GameOver
        isFirst = false;
    }

    void onStateInGame4()
    {
        LastScene("4");
        isFirst = false;
    }

    void onStateGameOver()
    {
        Debug.Log("You Died: Stage" + gameScenePlayedLast);
        //Fade-out
        //unable to move player
        isFirst = false;
    }

    void onStateGameClear() {
        //unable to move player
        //save data of cleared stage
        //LastScene(SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 1));
        //Debug.Log("Clear stage " + gameScenePlayedLast);
        if (gameScore >= 70)
        {
            p.isCleared[gameScenePlayedLast - 1] = true;
            p.Edit(gameScenePlayedLast);
        }
        state = "result";
        LoadScene("result");
    }

    void onStateResult() {
        //show result
        complete = GameObject.Find("complete");
        clear = GameObject.Find("clear");
        fail = GameObject.Find("failed");

        GameObject playC = GameObject.Find("player dot");
        GameObject destC = GameObject.Find("dest dot");
        
        Debug.Log("p: " + playerCol.h + "," + playerCol.s + "," + playerCol.v);
        Debug.Log("d: " + destCol.h + "," + destCol.s + "," + destCol.v);
        
        playC.gameObject.transform.position = new Vector3(1024 + (100 + 100 * (1 - playerCol.v)) * Mathf.Cos(Mathf.Deg2Rad * playerCol.h), 768 + (100 + 100 * (1 - playerCol.v)) * Mathf.Sin(Mathf.Deg2Rad * playerCol.h) - 200, 0);
        destC.gameObject.transform.position = new Vector3(1024 + (100 + 100 * (1 - destCol.v)) * Mathf.Cos(Mathf.Deg2Rad * destCol.h), 768 + (100 + 100 * (1 - destCol.v)) * Mathf.Sin(Mathf.Deg2Rad * destCol.h) - 200, 0);

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
