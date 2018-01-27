using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBallsTest : MonoBehaviour {

    public GameObject enemyPrefab;
    public float cooldown = 3f;
    public float speed = 2.0f;

    float remainingTime = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        foreach (Transform unit in transform)
        {
            unit.gameObject.transform.position += Vector3.right * Time.deltaTime * speed;
        }
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0)
        {
            remainingTime = cooldown;
            Instantiate(enemyPrefab, transform);
        }
	}
}
