using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMouserOver : MonoBehaviour
{
    public GameObject tower;
    [HideInInspector]
    public bool isSelected = false;

    Material mat;
    bool isGlowing = false;

    void Awake()
    {
        isSelected = false;
        mat = tower.gameObject.GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        bool shouldGlow = false;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.transform.name == tower.name)
            {
                isGlowing = true;
                shouldGlow = true;
                if (!isSelected)
                {
                    isSelected = Input.GetMouseButtonDown(0);
                }
                mat.SetFloat("_Outline", 0.2f);
            }
        }
        isSelected = Input.GetMouseButtonDown(0) && !shouldGlow ? false : isSelected;
        if (!isSelected && isGlowing && !shouldGlow)
        {
            mat.SetFloat("_Outline", 0f);
        }
    }
}
