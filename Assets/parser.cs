using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class parser : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StreamReader input = new StreamReader("map.txt");
        Debug.Log(input.ReadLine());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
