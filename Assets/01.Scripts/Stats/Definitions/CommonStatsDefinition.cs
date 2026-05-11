using UnityEngine;

public abstract class CommonStatsDefinition : ScriptableObject, ICommonStats
{
    [SerializeField] private int attackPower;
    [SerializeField] private int maxHp;
    [SerializeField] private float moveSpeed = 5f;

    public int AttackPower => attackPower;
    public int MaxHP => maxHp;
    public float MoveSpeed => moveSpeed;
}
