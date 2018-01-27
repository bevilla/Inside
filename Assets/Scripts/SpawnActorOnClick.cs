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

    public GameObject toInstantiate;
    GameObject preview;
    public E_Spawn currentSelectedSpawnable = E_Spawn.NONE;
    bool canSpawn = true;
    bool spawnGreen = true;

	// Use this for initialization
	void Start ()
    {
        SpawnActorOnClick.instance = this;
	}

    public void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayInfo;


        // Show preview
        if (Physics.Raycast(ray, out rayInfo, 9999, LayerMask.GetMask("SpawnTower") | LayerMask.GetMask("SpawnMinion") | LayerMask.GetMask("SpawnNothing")) && canSpawn && preview)
        {
            preview.SetActive(true);
            preview.transform.position = rayInfo.point;
            if ((rayInfo.transform.gameObject.layer == LayerMask.NameToLayer("SpawnTower") && currentSelectedSpawnable == E_Spawn.TOWER)
                || (rayInfo.transform.gameObject.layer == LayerMask.NameToLayer("SpawnMinion") && currentSelectedSpawnable == E_Spawn.MINION))
                spawnGreen = true;
            else
                spawnGreen = false;
            preview.GetComponent<MeshRenderer>().material.SetColor("_Color", (spawnGreen ? new Color(0, 0, 0, 0.5f) : new Color(1, 0, 0, 0.5f)));
        }
        else
        {
            if (preview)
                preview.SetActive(false);
        }

        // Spawn an actor on click
        if (Input.GetButtonDown("Fire1") && canSpawn && toInstantiate)
        {
            if (spawnGreen)
                Instantiate(toInstantiate, rayInfo.point, Quaternion.identity);
        }
    }

    public void changeObject(GameObject newObject)
    {
        Destroy(preview);
        toInstantiate = newObject;
        preview = Instantiate(newObject);
        preview.layer = LayerMask.NameToLayer("Default");
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
