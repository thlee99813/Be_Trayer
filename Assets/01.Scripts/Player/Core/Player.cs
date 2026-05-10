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

    public Rigidbody Rigidbody => _rigidbody;
    public Collider BodyCollider => _bodyCollider;
    public PlayerActionController ActionController => _actionController;
    public PlayerMovementController MovementController => _movementController;
    public PlayerAimController AimController => _aimController;
    public PlayerShootAction ShootAction => _shootAction;
    public PlayerProjectileSpawnPoint ProjectileSpawnPoint => _projectileSpawnPoint;

    private void OnValidate()
    {
        CacheComponents();
    }

    private void Awake()
    {
        CacheComponents();
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
    }

    // TODO: 상호작용 컴포넌트 추가할 것
    // TODO: 피격 처리 컴포넌트 추가할 것
}
