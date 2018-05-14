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
