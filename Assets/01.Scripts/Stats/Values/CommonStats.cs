using System;
using UnityEngine;

[Serializable]
public class CommonStats : ICommonStats
{
    [SerializeField] protected int attackPower;
    [SerializeField] protected int maxHp;
    [SerializeField] protected float moveSpeed = 5f;

    public int AttackPower => attackPower;
    public int MaxHP => maxHp;
    public float MoveSpeed => moveSpeed;

    public void ApplyDefinition(ICommonStats definition)
    {
        if (definition == null)
        {
            return;
        }

        attackPower = definition.AttackPower;
        maxHp = definition.MaxHP;
        moveSpeed = definition.MoveSpeed;
    }
}
