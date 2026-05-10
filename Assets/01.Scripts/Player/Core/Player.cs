using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerActionController))]
[RequireComponent(typeof(PlayerMovementController))]
[RequireComponent(typeof(PlayerAimController))]
[RequireComponent(typeof(PlayerShootAction))]
public class Player : MonoBehaviour
{
    [Header("Physics")]
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collider _bodyCollider;

    [Header("Actions")]
    [SerializeField] private PlayerActionController _actionController;
    [SerializeField] private PlayerMovementController _movementController;
    [SerializeField] private PlayerAimController _aimController;
    [SerializeField] private PlayerShootAction _shootAction;
    [SerializeField] private PlayerProjectileSpawnPoint _projectileSpawnPoint;

    [Header("Stats Definition")]
    [SerializeField] private PlayerStatsDefinition _statsDefinition;

    [Header("Runtime Stats")]
    [SerializeField] private PlayerStats _runtimeStats = new();

    public Rigidbody Rigidbody => _rigidbody;
    public Collider BodyCollider => _bodyCollider;
    public PlayerActionController ActionController => _actionController;
    public PlayerMovementController MovementController => _movementController;
    public PlayerAimController AimController => _aimController;
    public PlayerShootAction ShootAction => _shootAction;
    public PlayerProjectileSpawnPoint ProjectileSpawnPoint => _projectileSpawnPoint;
    public PlayerStatsDefinition StatsDefinition => _statsDefinition;
    public PlayerStats RuntimeStats => _runtimeStats;
    public IPlayerStats Stats => _runtimeStats;
    public float AttackCooldownRemaining => _shootAction != null ? _shootAction.CooldownRemaining : 0f;
    public float AttackCooldownDuration => _shootAction != null ? _shootAction.CooldownDuration : 0f;
    public bool CanAttack => _shootAction != null && !_shootAction.IsOnCooldown;

    private void OnValidate()
    {
        CacheComponents();
        ApplyStatsDefinition();
    }

    private void Awake()
    {
        CacheComponents();
        ApplyStatsDefinition();
    }

    private void CacheComponents()
    {
        _rigidbody ??= GetComponent<Rigidbody>();
        _bodyCollider ??= GetComponent<Collider>();
        _actionController ??= GetComponent<PlayerActionController>();
        _movementController ??= GetComponent<PlayerMovementController>();
        _aimController ??= GetComponent<PlayerAimController>();
        _shootAction ??= GetComponent<PlayerShootAction>();
        _projectileSpawnPoint ??= GetComponentInChildren<PlayerProjectileSpawnPoint>();
        _runtimeStats ??= new PlayerStats();
    }

    private void ApplyStatsDefinition()
    {
        if (_statsDefinition == null || _runtimeStats == null)
        {
            return;
        }

        _runtimeStats.ApplyDefinition(_statsDefinition);
    }
}
