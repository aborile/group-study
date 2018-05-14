using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour {

    Tile[] tile = new Tile[7];
    public float len;
    public Tile makeTile;

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
