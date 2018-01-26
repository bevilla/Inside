using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnActorOnClick : MonoBehaviour {

   public  GameObject toInstantiate;

	// Use this for initialization
	void Start () {
		
	}

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayInfo;
            if (Physics.Raycast(ray, out rayInfo))
                Instantiate(toInstantiate, rayInfo.point, Quaternion.identity);
        }
    }
}
