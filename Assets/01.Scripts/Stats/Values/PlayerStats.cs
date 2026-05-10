using System;
using UnityEngine;

[Serializable]
public class PlayerStats : CommonStats, IPlayerStats
{
    [SerializeField] private int chaos;

    public int Chaos => chaos;
}
