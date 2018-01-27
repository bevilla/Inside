using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBallsTest : MonoBehaviour {

    public float speed = 2.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + Vector3.right * Time.deltaTime * speed;
	}
}
