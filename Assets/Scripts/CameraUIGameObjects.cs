using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUIGameObjects : MonoBehaviour {

    public GameObject[] uiElements;
	
	void LateUpdate()
    {
        foreach (var elem in uiElements)
        {
            elem.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        }
    }
}
