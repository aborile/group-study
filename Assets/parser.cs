using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class parser : MonoBehaviour {
    public bool[] isCleared;
    public List<List<string[]>> mapData;
    public List<List<double[][]>> colorData;

	// Use this for initialization
	void Start () {
        /* 0: 빈 타일, 1: 일반 타일, 2: 특수 타일 */
        StreamReader input = new StreamReader("map.txt");
        Reader(input);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public List<List<string[]>> makeData()
    {
        return mapData;
    }

    public List<List<double[][]>> makeColor()
    {
        return colorData;
    }

    public void Reader (StreamReader t)
    {
        mapData = new List<List<string[]>>();
        colorData = new List<List<double[][]>>();
        int stageNum = Convert.ToInt16(t.ReadLine());
        Debug.Log("stageNum inited: " + stageNum);
        isCleared = new bool[stageNum];
        for (int i = 0; i < stageNum; i++)
        {
            string n = t.ReadLine();
            n = n.Split(' ')[0];
            if (n == "" || n == " " || n == "\n")
            {
                n = t.ReadLine();
            }
            Debug.Log(n);
            int nums = Convert.ToInt16(n);
            Debug.Log("line nums inited: " + i + "th line - " + nums);
            //Debug.Log("nums: " + nums[0] + "," + nums[1]);
            List<string[]> mapList = new List<string[]>();
            List<double[][]> colorList = new List<double[][]>();
            for (int j = 0; j < nums; j++)
            {
                string text = t.ReadLine();
                if (text == "" || text == " " || text == "\n")
                {
                    text = t.ReadLine();
                }
                Debug.Log(text);
                string[] tile = text.Split(' ');      //공백 단위로 배열에 저장
                string[] sp = new string[tile.Length];
                double[][] cp = new double[tile.Length][];
                for (int k = 0; k < tile.Length; k++)
                {
                    sp[k] = tile[k][0].ToString();
                    string[] colors = tile[k].Substring(1).Split(new char[] { ',', '(', ')' });
                    double[] temp = new double[3];
                    for (int l = 1; l < colors.Length - 1; l++)
                    {
                        temp[l - 1] = Convert.ToDouble(colors[l]);
                    }
                    cp[k] = temp;
                }
                mapList.Add(sp);            //List arr 안에 배열 저장
                colorList.Add(cp);
            }
            mapData.Add(mapList);
            colorData.Add(colorList);
            Debug.Log(i + "th map data read");
            string clear = t.ReadLine();
            if (clear == "" || clear == " " || clear == "\n")
            {
                clear = t.ReadLine();
            }
            if (Convert.ToInt16(clear) == 1)
            {
                isCleared[i] = true;
            }
            else
            {
                isCleared[i] = false;
            }
        }
    }

    public void Edit(int sceneNum)
    {
        /*
        // change the value of each stage if the stage have been cleared
        string[] data = File.ReadAllText(@"map.txt").Split('\n');
        Debug.Log(data.Length);
        using (StreamWriter outputFile = new StreamWriter(@"map.txt", false))
        {
            int line = 0;
            switch (sceneNum)
            {
                case 1:
                    line = 6;
                    break;
                case 2:
                    line = 13;
                    break;
                case 3:
                    line = 20;
                    break;
            }
            data[line] = "1";
            for (int i = 0; i < data.Length - 1; i++)
            {
                outputFile.WriteLine(data[i]);
            }
            outputFile.Write(data[data.Length - 1]);
        }
        */
    }
}