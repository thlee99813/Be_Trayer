using System;
using UnityEngine;

[Serializable]
public class CommonStats : ICommonStats
{
    [SerializeField] protected int attackPower;
    [SerializeField] protected int maxHp;
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected float attackRange = 1f;
    [SerializeField] protected float attackCooldown = 0.5f;

    public int AttackPower => attackPower;
    public int MaxHP => maxHp;
    public float MoveSpeed => moveSpeed;
    public float AttackRange => attackRange;
    public float AttackCooldown => attackCooldown;

    public void ApplyDefinition(ICommonStats definition)
    {
        if (definition == null)
        {
            return;
        }

        attackPower = definition.AttackPower;
        maxHp = definition.MaxHP;
        moveSpeed = definition.MoveSpeed;
        attackRange = definition.AttackRange;
        attackCooldown = definition.AttackCooldown;
    }
}
