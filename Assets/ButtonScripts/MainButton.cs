using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        //Debug.Log(gameObject.name);
        //Debug.Log("Clicked!");
        GameFlow.state = "selectStage";
    }
}
