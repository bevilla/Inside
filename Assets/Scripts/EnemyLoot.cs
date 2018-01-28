using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoot : MonoBehaviour {

    [SerializeField]
    PlayerRessources playerRessourceManager;

    [SerializeField]
    float vitaminLoot, calciumLoot, proteinLoot;

    private void OnDestroy()
    {
        if (PlayerRessources.instance)
            PlayerRessources.instance.addRessource(vitaminLoot, proteinLoot, calciumLoot);
    }
}
