using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTowerAnim : MonoBehaviour {

    public float animTime = 8f;

    Vector3 originalScale;
    float elapsedTime = 0f;

	// Use this for initialization
	void Start () {
        originalScale = transform.localScale;
        transform.localScale = Vector3.zero;
        GetComponent<EnemyAudioManager>().PlaySpawn();
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;
        transform.localScale = Vector3.Lerp(transform.localScale, originalScale, elapsedTime / animTime);
        if (elapsedTime > animTime)
        {
            enabled = false;
        }
    }
}
