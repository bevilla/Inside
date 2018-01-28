using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToOrganTrigger : MonoBehaviour
{
    public E_OrganType organType;
    public Transform destination;
    public Transform brainDestination;
    public OrgansInfos.Organ toBrainTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            var enemyMovement = other.gameObject.GetComponentInChildren<EnemyMovement>();

            if (IsOrganAlive())
            {
                enemyMovement.isMovingToOrgan = true;
                enemyMovement.destination = destination.position;
            }
            else
            {
                enemyMovement.mto.Stop();
                enemyMovement.isMovingToOrgan = false;
                enemyMovement.isMovingToTube = true;
                enemyMovement.organDestination = toBrainTrigger;
                enemyMovement.destination = brainDestination.position;
            }
        }
    }

    bool IsOrganAlive()
    {
        bool ret = false;

        switch (organType)
        {
            case E_OrganType.HEART:
                ret = OrgansInfos.instance.isHeartAlive;
                break;
            case E_OrganType.INTESTINE:
                ret = OrgansInfos.instance.isIntestinesAlive;
                break;
            case E_OrganType.LIVER:
                ret = OrgansInfos.instance.isLiverAlive;
                break;
            case E_OrganType.LUNGS:
                ret = OrgansInfos.instance.isLungsAlive;
                break;
            case E_OrganType.BRAIN:
                ret = OrgansInfos.instance.isBrainAlive;
                break;
            default: break;
        }
        return ret;
    }
}
