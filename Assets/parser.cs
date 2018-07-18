using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class parser : MonoBehaviour {
    public bool[] isCleared;
    public List<List<string[]>> mapData;

	// Use this for initialization
	void Start () {
        /* 0: 빈 타일, 1: 일반 타일, 2: 특수 타일 */
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public List<List<string[]>> makeData(string txt)
    {
        StreamReader input = new StreamReader(txt);
        Reader(input);
        return mapData;
    }

    public void Reader (StreamReader t)
    {
        mapData = new List<List<string[]>>();
        int stageNum = Convert.ToInt16(t.ReadLine());
        isCleared = new bool[stageNum];
        for (int i = 0; i < stageNum; i++)
        {
            string[] nums = t.ReadLine().Split(' ');
            //Debug.Log("nums: " + nums[0] + "," + nums[1]);
            List<string[]> mapArr = new List<string[]>();
            for (int j = 0; j < Convert.ToInt16(nums[0]); j++)
            {
                string text;
                string[] sp;
                text = t.ReadLine();
                sp = text.Split(' ');      //공백 단위로 배열에 저장
                mapArr.Add(sp);            //List arr 안에 배열 저장
            }
            mapData.Add(mapArr);
            if (Convert.ToInt16(nums[1]) == 1)
            {
                isCleared[i] = true;
            }
            else
            {
                isCleared[i] = false;
            }
        }
    }
}