using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class parser : MonoBehaviour {
    public List<string []> arr;

	// Use this for initialization
	void Start () {
        /* 0: 빈 타일, 1: 일반 타일, 2: 특수 타일 */
        StreamReader input = new StreamReader("map.txt.");
        //Debug.Log(input.ReadLine());
        Reader(input);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Reader (StreamReader t)
    {
        string text;
        string[] sp;
        arr = new List<string []>();
        while (t.Peek() >= 0)
        {
            text = t.ReadLine();
            sp = text.Split(' ');      //공백 단위로 배열에 저장
            arr.Add(sp);               //List arr 안에 배열 저장
        }
        /*
        for (int i = 0; i < arr.Count; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                Debug.Log(arr[i][j]);
            }
        }
        */
        //return arr;
    }

    public List<string []> getArr()
    {
        return arr;
    }
}
