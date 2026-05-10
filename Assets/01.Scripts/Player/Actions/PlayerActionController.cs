using UnityEngine;

[RequireComponent(typeof(PlayerInputReader))]
[RequireComponent(typeof(PlayerAimController))]
[RequireComponent(typeof(PlayerShootAction))]
[RequireComponent(typeof(PlayerMovementController))]
public class PlayerActionController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInputReader _inputReader;
    [SerializeField] private PlayerAimController _aimController;
    [SerializeField] private PlayerShootAction _shootAction;
    [SerializeField] private PlayerProjectileSpawnPoint _projectileSpawnPoint;

    private readonly PlayerActionContext _context = new();

    public PlayerActionContext Context => _context;

    private void OnValidate()
    {
        _player ??= GetComponent<Player>();
        _inputReader ??= GetComponent<PlayerInputReader>();
        _aimController ??= GetComponent<PlayerAimController>();
        _shootAction ??= GetComponent<PlayerShootAction>();
        _projectileSpawnPoint ??= GetComponentInChildren<PlayerProjectileSpawnPoint>();
    }

    private void Awake()
    {
        _player ??= GetComponent<Player>();
        _inputReader ??= GetComponent<PlayerInputReader>();
        _aimController ??= GetComponent<PlayerAimController>();
        _shootAction ??= GetComponent<PlayerShootAction>();
        _projectileSpawnPoint ??= GetComponentInChildren<PlayerProjectileSpawnPoint>();
    }

    private void Update()
    {
        _context.MoveInput = _inputReader.ReadMoveInput();
        _context.CurrentState = _context.MoveInput == Vector2.zero
            ? PlayerActionState.Idle
            : PlayerActionState.Move;

        _context.PointerScreenPosition = _inputReader.ReadPointerScreenPosition();

        Vector3 origin = _projectileSpawnPoint != null
            ? _projectileSpawnPoint.Position
            : transform.position;

        _context.TargetPoint = _aimController.ResolveTargetPoint(origin, _context.PointerScreenPosition);
        _context.AimDirection = _aimController.ResolveAimDirection(origin, _context.TargetPoint);
        _aimController.FaceDirection(_context.AimDirection);

        if (_inputReader.ReadShootPressedThisFrame() &&
            _shootAction.TryCreateAttackCommand(origin, _context.AimDirection, _context.TargetPoint, out PlayerAttackCommand attackCommand))
        {
            _context.LastAttackCommand = attackCommand;
            _context.CurrentState = PlayerActionState.Shoot;
        }

        // TODO: 생성된 공격 명령을 시스템에 연결할 것
        // TODO: 현재 상태에 따라 이동, 상호작용 함수 연결할 것
    }
}
