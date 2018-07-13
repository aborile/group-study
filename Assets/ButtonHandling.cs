using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandling : MonoBehaviour {

    int layerMask = 1 << 8;
    UImanager um;

	// Use this for initialization
	void Start () {
        um = GameObject.Find("GameObject").GetComponent<UImanager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Debug.Log(hit.collider.name);
                um.OnClickButtonMain();
            }
        }
	}
}
