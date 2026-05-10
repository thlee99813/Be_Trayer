using UnityEngine;

public abstract class CommonStatsDefinition : ScriptableObject, ICommonStats
{
    [SerializeField] private int attackPower;
    [SerializeField] private int maxHp;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private float attackCooldown = 0.5f;

    public int AttackPower => attackPower;
    public int MaxHP => maxHp;
    public float MoveSpeed => moveSpeed;
    public float AttackRange => attackRange;
    public float AttackCooldown => attackCooldown;
}
