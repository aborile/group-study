using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tile : MonoBehaviour {
    public enum Type { empty, normal, initial };
    public Type tileType;
    public Color tileColor;
    //public Dictionary<int[], int> dic;

    // Use this for initialization
    void Start() {
        //dic = new Dictionary<int, Dictionary<int, int>();

        /*dic = new Dictionary<int[], int>();
        dic[new int[] { 0, 1 }] = 0;
        dic[new int[] { 0, 2 }] = 1;
        dic[new int[] { 0, 3 }] = 2;
        dic[new int[] { 0, 4 }] = 3;
        dic[new int[] { 0, 5 }] = 4;
        dic[new int[] { 0, 6 }] = 5;
        dic[new int[] { 1, 0 }] = 3;
        dic[new int[] { 1, 2 }] = 2;
        dic[new int[] { 1, 5 }] = 1;
        dic[new int[] { 1, 6 }] = 4;
        dic[new int[] { 2, 0 }] = 4;
        dic[new int[] { 2, 1 }] = 5;
        dic[new int[] { 2, 3 }] = 3;
        dic[new int[] { 2, 4 }] = 1;
        dic[new int[] { 2, 5 }] = 0;
        dic[new int[] { 3, 0 }] = 5;
        dic[new int[] { 3, 2 }] = 0;
        dic[new int[] { 3, 4 }] = 4;
        dic[new int[] { 4, 0 }] = 0;
        dic[new int[] { 4, 2 }] = 4;
        dic[new int[] { 4, 3 }] = 1;
        dic[new int[] { 4, 5 }] = 5;
        dic[new int[] { 5, 0 }] = 1;
        dic[new int[] { 5, 1 }] = 4;
        dic[new int[] { 5, 2 }] = 3;
        dic[new int[] { 5, 4 }] = 2;
        dic[new int[] { 5, 6 }] = 0;
        dic[new int[] { 6, 0 }] = 2;
        dic[new int[] { 6, 1 }] = 1;
        dic[new int[] { 6, 5 }] = 3;
        Debug.Log(dic[new int[] { 0, 1 }]);*/

    }

    public void setType(string s)
    {
        //받은 string 값에 따라 타일 타입 지정
        //을 했는데 생각해보니 이러면 enum 쓴 의미 없나요
        switch (s)
        {
            case "0":
                tileType = Type.empty;
                break;
            case "1":
                tileType = Type.normal;
                break;
            case "2":
                tileType = Type.initial;
                break;
        }

    }

    public void setColor(double[] c)
    {
        tileColor.r = (float)c[0];
        tileColor.g = (float)c[1];
        tileColor.b = (float)c[2];
    }
    /*
    private int RemoveWall(string other) {
        int thisTile = this.gameObject.name.ToCharArray()[4] - '0';
        int otherTile = other.ToCharArray()[4] - '0';
        //Debug.Log(thisTile);
        //Debug.Log(otherTile);
        int[] input = new int[] { 0, 1 };

        if (dic.ContainsKey(input))
        {
            return dic[input];
        }
        else
        {
            return -1;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("갸아아악");
        Destroy(this.GetComponent<Rigidbody>());
        int wallNum = RemoveWall(other.gameObject.name);

        if (wallNum != -1)
        {
            Destroy(GameObject.Find("wall" + wallNum));

        }
        Debug.Log(wallNum);
    }
    */

    // Update is called once per frame
    void Update () {
		
	}
}
