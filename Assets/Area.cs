using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour {

    Tile[] tile = new Tile[7];
    public float len;
    public Tile makeTile;
    public GameObject thisArea;
    public string[] typeArr = new string[7];

    public void setTileType(string[] arr)
    {
        thisArea = GameObject.Find("area");
        for (int i=0; i<typeArr.Length; i++)
        {
            typeArr[i] = arr[i];
            //Debug.Log(typeArr[i]);
        }
    }

	// Use this for initialization
	void Start ()
    {
        len = (float)6 * Mathf.Sqrt(3);
        Vector3 nowV = thisArea.transform.position;
        tile[0] = Instantiate(makeTile, nowV, transform.rotation);
        tile[1] = Instantiate(makeTile, nowV + new Vector3(0, 0, len), transform.rotation);
        tile[2] = Instantiate(makeTile, nowV + new Vector3(9, 0, len/2), transform.rotation);
        tile[3] = Instantiate(makeTile, nowV + new Vector3(9, 0, (-1)*len/2), transform.rotation);
        tile[4] = Instantiate(makeTile, nowV + new Vector3(0, 0, (-1)*len), transform.rotation);
        tile[5] = Instantiate(makeTile, nowV + new Vector3(-9, 0, (-1)*len/2), transform.rotation);
        tile[6] = Instantiate(makeTile, nowV + new Vector3(-9, 0, len/2), transform.rotation);
        for (int i = 0; i < 7; i++)
        {
            tile[i].GetComponent<Tile>();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
