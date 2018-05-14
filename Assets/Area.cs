using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour {

    Tile[] tile = new Tile[7];
    public float len;
    public Tile makeTile;
    public string[] typeArr = new string[7];

    public void setTileType(string[] arr)
    {
        for (int i=0; i<typeArr.Length; i++)
        {
            typeArr[i] = arr[i];
            Debug.Log(typeArr[i]);
        }
    }

	// Use this for initialization
	void Start ()
    {
        len = (float)3 * Mathf.Sqrt(3);
        for (int i = 0; i < 7; i++)
        {
            tile[i] = Instantiate(makeTile, transform.position, transform.rotation);
            tile[i].GetComponent<Tile>();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
