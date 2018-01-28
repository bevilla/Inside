using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveThroughOrgans : MonoBehaviour
{
    OrgansInfos.Organ currentPosition;
    Transform destination;

    NavMeshAgent nma;
    delegate OrgansInfos.Organ GetLinkedPointFunc();
    Dictionary<OrgansInfos.Organ, GetLinkedPointFunc> linkedPoints = new Dictionary<OrgansInfos.Organ, GetLinkedPointFunc>()
    {
        { OrgansInfos.Organ.LiverLeft, () => OrgansInfos.Organ.IntestinesRight },
        { OrgansInfos.Organ.IntestinesRight, () => OrgansInfos.Organ.LiverLeft },

        { OrgansInfos.Organ.LiverRight, () => OrgansInfos.Organ.HeartLeft },
        { OrgansInfos.Organ.HeartLeft, () => OrgansInfos.Organ.LiverRight },

        { OrgansInfos.Organ.HeartRight, () => OrgansInfos.Organ.LungsLeft },
        { OrgansInfos.Organ.LungsLeft, () => OrgansInfos.Organ.HeartRight },

        { OrgansInfos.Organ.LungsRight, () => OrgansInfos.Organ.IntestinesLeft },
        { OrgansInfos.Organ.IntestinesLeft, () => OrgansInfos.Organ.LungsRight },

        // Brain
        { OrgansInfos.Organ.LiverToBrain, () => OrgansInfos.Organ.BrainToLiver },
        { OrgansInfos.Organ.BrainToLiver, () => OrgansInfos.Organ.LiverToBrain },

        { OrgansInfos.Organ.LungsToBrain, () => OrgansInfos.Organ.BrainToLungs },
        { OrgansInfos.Organ.BrainToLungs, () => OrgansInfos.Organ.LungsToBrain },

        { OrgansInfos.Organ.IntestinesToBrain, () => OrgansInfos.Organ.BrainToIntestines },
        { OrgansInfos.Organ.BrainToIntestines, () => OrgansInfos.Organ.IntestinesToBrain },

        { OrgansInfos.Organ.HeartToBrain, () => OrgansInfos.Organ.BrainToHeart },
        { OrgansInfos.Organ.BrainToHeart, () => OrgansInfos.Organ.HeartToBrain },
    };

    // Use this for initialization
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        currentPosition = OrgansInfos.Organ.IntestinesRight;
        destination = OrgansInfos.instance.positions[currentPosition];
        MoveToNext();
    }

    void Update()
    {
        //nma.Move(destination.position);
    }

    public void MoveToNext()
    {
        currentPosition = linkedPoints[currentPosition]();
        destination = OrgansInfos.instance.positions[currentPosition];
        nma.destination = destination.position;
    }
}
