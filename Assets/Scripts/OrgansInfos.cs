﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrgansInfos : MonoBehaviour
{
    public enum Organ
    {
        LiverLeft,
        LiverRight,
        LiverToBrain,
        HeartLeft,
        HeartRight,
        HeartToBrain,
        IntestinesLeft,
        IntestinesRight,
        IntestinesToBrain,
        LungsLeft,
        LungsRight,
        LungsToBrain,
        BrainToLiver,
        BrainToHeart,
        BrainToLungs,
        BrainToIntestines,
    };
    [System.Serializable]
    public struct OrganPositionsElem
    {
        public Organ key;
        public Transform value;
    };
    public Dictionary<Organ, Transform> positions = new Dictionary<Organ, Transform>();

    [SerializeField]
    OrganPositionsElem[] elems;
    [HideInInspector]
    static public OrgansInfos instance;

    public bool isHeartAlive = true;
    public bool isLungsAlive = true;
    public bool isIntestinesAlive = true;
    public bool isLiverAlive = true;
    public bool isBrainAlive = true;

    void Awake()
    {
        OrgansInfos.instance = this;

        foreach (var elem in elems)
        {
            positions[elem.key] = elem.value;
        }
    }
}
