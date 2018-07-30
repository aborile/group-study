﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour {

    Tile[] tile;
    public float len = (float)6 * Mathf.Sqrt(3);
    public Tile makeTile;
    public GameObject wall, makewall;
    public Vector3 nowV;
    public Vector3[] pos;
    public string[] typeArr = new string[7];
    public double[][] colorArr = new double[7][];

    public void setTileType(string[] arr) //tile type 저장
    {
        for (int i=0; i<typeArr.Length; i++)
        {
            typeArr[i] = arr[i];
        }
    }

    public void setTileColor(double[][] arr)
    {
        for (int i=0; i<colorArr.Length; i++)
        {
            colorArr[i] = arr[i];
        }
    }

	// Use this for initialization
	void Start ()
    {
        tile = new Tile[7];
        nowV = GetComponent<Area>().transform.position;
        pos = new Vector3[7] { nowV,
                               nowV + new Vector3(0, 0, len),
                               nowV + new Vector3(9, 0, len/2),
                               nowV + new Vector3(9, 0, (-1)*len/2),
                               nowV + new Vector3(0, 0, (-1)*len),
                               nowV + new Vector3(-9, 0, (-1)*len/2),
                               nowV + new Vector3(-9, 0, len/2) };
        //위치별로 타일 생성

        for (int i = 0; i < tile.Length; i++)
        {
            if (typeArr[i] != "")
            {
                tile[i] = Instantiate(makeTile, pos[i], transform.rotation);
                tile[i].gameObject.name = "tile" + i;
                tile[i].GetComponent<Tile>();
                tile[i].setType(typeArr[i]);
                tile[i].setColor(colorArr[i]);
                tile[i].GetComponent<Renderer>().material.SetColor("_Color", tile[i].tileColor);
                tile[i].transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", tile[i].tileColor);
                //Debug.Log(tile[i].GetComponentInChildren<MeshRenderer>().material.GetColor("_Color"));
                if (tile[i].tileType == Tile.Type.empty)
                {
                    Destroy(tile[i].gameObject);
                }
                else if (tile[i].tileType == Tile.Type.initial)
                {
                    //벽 생성
                    wall = Instantiate(makewall, pos[i], transform.rotation);
                    wall = Instantiate(makewall, pos[i], transform.rotation);
                    if (!(colorArr[i][0] == 1 && colorArr[i][1] == 1 && colorArr[i][2] == 1))
                    {
                        tile[i].gameObject.name = "dest tile";
                        tile[i].tag = "Respawn";
                    }
                }
            }
        }


        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
