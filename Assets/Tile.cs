using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tile : MonoBehaviour {
    public enum Type { empty, normal, initial };
    public Type tileType;

	// Use this for initialization
	void Start () {

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
	
	// Update is called once per frame
	void Update () {
		
	}
}
