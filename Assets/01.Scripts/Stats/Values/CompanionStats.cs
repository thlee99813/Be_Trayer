using System;
using UnityEngine;

[Serializable]
public class CompanionStats : CommonStats, ICompanionStats
{
    [SerializeField] private int greedy;
    [SerializeField] private int fear;

    public int Greedy => greedy;
    public int Fear => fear;
}
