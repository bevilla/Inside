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
    public float gridStep;

	// Use this for initialization
	void Start ()
    {
        SpawnActorOnClick.instance = this;
	}

    public void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayInfo;
        Vector3 hitPos = new Vector3(0,0,0);

        // Show preview
        if (Physics.Raycast(ray, out rayInfo, Mathf.Infinity, LayerMask.GetMask("SpawnTower") | LayerMask.GetMask("SpawnMinion") | LayerMask.GetMask("SpawnNothing")) && canSpawn && preview)
        {
            // round to the nearest 10 to make square boxes
            hitPos = rayInfo.point;
            hitPos.x = Mathf.Round(hitPos.x / gridStep) * gridStep;
            hitPos.z = Mathf.Round(hitPos.z / gridStep) * gridStep;

            preview.SetActive(true);
            preview.transform.position = hitPos;
            if ((rayInfo.transform.gameObject.layer == LayerMask.NameToLayer("SpawnTower") && currentSelectedSpawnable == E_Spawn.TOWER)
                || (rayInfo.transform.gameObject.layer == LayerMask.NameToLayer("SpawnMinion") && currentSelectedSpawnable == E_Spawn.MINION))
                spawnGreen = true;
            else
                spawnGreen = false;
            foreach (var mesh in preview.GetComponentsInChildren<MeshRenderer>())
            {
               mesh.material.SetColor("_Color", (spawnGreen ? new Color(0, 0, 0, 0.5f) : new Color(1, 0, 0, 0.5f)));
            }
        }
        else
        {
            if (preview)
                preview.SetActive(false);
        }

        // Spawn an actor on click
        if (Input.GetButtonDown("Fire1") && canSpawn && toInstantiate)
        {
            //Debug.DrawRay(ray.origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction, Color.green,10);
            var spawnPrice = toInstantiate.GetComponentInChildren<SpawnPrice>();
            Vector3 prices = new Vector3(spawnPrice.vitaminPrice,
                spawnPrice.proteinPrice,
                spawnPrice.CalciumPrice);

            if (spawnGreen && PlayerRessources.instance.payRessources(prices.x, prices.y, prices.z))
            {
                GameObject freshlyCreated = Instantiate(toInstantiate, hitPos, Quaternion.identity);
                freshlyCreated.GetComponentInChildren<TowerAttack>().isReady = true;
            }
        }

        if (Input.GetButtonDown("Fire2") && toInstantiate)
        {
            currentSelectedSpawnable = E_Spawn.NONE;
            toInstantiate = null;
            Destroy(preview);
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
