using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour {

    Tile[] tile = new Tile[7];
    public float len;
    public Tile makeTile;
    public Vector3 nowV;
    public Vector3[] pos;
    public string[] typeArr = new string[7];

    public void setTileType(string[] arr) //tile type 저장
    {
        for (int i=0; i<typeArr.Length; i++)
        {
            typeArr[i] = arr[i];
        }
    }

	// Use this for initialization
	void Start ()
    {
        nowV = GameObject.Find("area").transform.position;
        pos = new Vector3[7] { nowV,
                               nowV + new Vector3(0, 0, len),
                               nowV + new Vector3(9, 0, len/2),
                               nowV + new Vector3(9, 0, (-1)*len/2),
                               nowV + new Vector3(0, 0, (-1)*len),
                               nowV + new Vector3(-9, 0, (-1)*len/2),
                               nowV + new Vector3(-9, 0, len/2) };
        len = (float)6 * Mathf.Sqrt(3);

        //위치별로 타일 생성
        
        tile[0] = Instantiate(makeTile, nowV, transform.rotation);
        tile[1] = Instantiate(makeTile, nowV + new Vector3(0, 0, len), transform.rotation);
        tile[2] = Instantiate(makeTile, nowV + new Vector3(9, 0, len/2), transform.rotation);
        tile[3] = Instantiate(makeTile, nowV + new Vector3(9, 0, (-1)*len/2), transform.rotation);
        tile[4] = Instantiate(makeTile, nowV + new Vector3(0, 0, (-1)*len), transform.rotation);
        tile[5] = Instantiate(makeTile, nowV + new Vector3(-9, 0, (-1)*len/2), transform.rotation);
        tile[6] = Instantiate(makeTile, nowV + new Vector3(-9, 0, len/2), transform.rotation);
        
        // 타일 타입 저장하려다가 장렬히 망한 흔적
        /*
        for (int i = 0; i < tile.Length; i++)
        {
            if (typeArr[i] != "")
            {
                tile[i].setType(typeArr[i]);
                Debug.Log(typeArr[i]);
                Debug.Log(tile[i].tileType);
                if (tile[i].tileType != Tile.Type.empty)
                {
                    tile[i] = Instantiate(makeTile, pos[i], transform.rotation);
                    tile[i].GetComponent<Tile>();
                }
            }
        }
        */
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
