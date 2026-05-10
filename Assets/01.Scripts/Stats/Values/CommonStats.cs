using System;
using UnityEngine;

[Serializable]
public class CommonStats : ICommonStats
{
    [SerializeField] private int strength;
    [SerializeField] private int maxHp;

    public int STR => strength;
    public int MaxHP => maxHp;
}
