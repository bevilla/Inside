using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoot : MonoBehaviour {

    [SerializeField]
    PlayerRessources playerRessourceManager;

    public bool canLoot = true;

    [SerializeField]
    float vitaminLoot, calciumLoot, proteinLoot;

    private void OnDestroy()
    {
        if (PlayerRessources.instance && canLoot)
            PlayerRessources.instance.addRessource(vitaminLoot, proteinLoot, calciumLoot);
    }
}
