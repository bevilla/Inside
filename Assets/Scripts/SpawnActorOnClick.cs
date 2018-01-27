using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_Spawn
{
    NONE,
    TOWER,
    MINION
};

public class SpawnActorOnClick : MonoBehaviour
{
    public static SpawnActorOnClick instance;

    public  GameObject toInstantiate;
    public E_Spawn currentSelectedSpawnable = E_Spawn.NONE;
    bool canSpawn = true;

	// Use this for initialization
	void Start ()
    {
        SpawnActorOnClick.instance = this;
	}

    public void Update()
    {
        if (Input.GetButtonDown("Fire1") && canSpawn)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayInfo;

            if (currentSelectedSpawnable == E_Spawn.TOWER)
            {
                if (Physics.Raycast(ray, out rayInfo, 9999, LayerMask.GetMask("SpawnTower")))
                    Instantiate(toInstantiate, rayInfo.point, Quaternion.identity);
            }
            else if (currentSelectedSpawnable == E_Spawn.MINION)
            {
                if (Physics.Raycast(ray, out rayInfo, 9999, LayerMask.GetMask("SpawnMinion")))
                    Instantiate(toInstantiate, rayInfo.point, Quaternion.identity);
            }
        }
    }

    public void changeObject(GameObject newObject)
    {
        toInstantiate = newObject;
    }

    public void changeObjectType(int type)
    {
        currentSelectedSpawnable = (E_Spawn)type;
    }

    public void canInstantiate(bool canOrCannotXd)
    {
        canSpawn = canOrCannotXd;
    }
}
