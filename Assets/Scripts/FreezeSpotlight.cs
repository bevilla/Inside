using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeSpotlight : MonoBehaviour {

    float spotlightY;

	// Use this for initialization
	void Start () {
        spotlightY = transform.position.y;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 pos = transform.position;

        pos.y = spotlightY;
        transform.position = pos;
	}
}
