using UnityEngine;

[RequireComponent(typeof(PlayerInputReader))]
[RequireComponent(typeof(PlayerAimController))]
[RequireComponent(typeof(PlayerShootAction))]
[RequireComponent(typeof(PlayerMovementController))]
public class PlayerActionController : MonoBehaviour
{
    [SerializeField] private PlayerInputReader _inputReader;
    [SerializeField] private PlayerAimController _aimController;
    [SerializeField] private PlayerShootAction _shootAction;
    [SerializeField] private PlayerProjectileSpawnPoint _projectileSpawnPoint;

    private readonly PlayerActionContext _context = new();

    public PlayerActionContext Context => _context;

    private void OnValidate()
    {
        _inputReader ??= GetComponent<PlayerInputReader>();
        _aimController ??= GetComponent<PlayerAimController>();
        _shootAction ??= GetComponent<PlayerShootAction>();
        _projectileSpawnPoint ??= GetComponentInChildren<PlayerProjectileSpawnPoint>();
    }

    private void Awake()
    {
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

        Vector3 origin = _projectileSpawnPoint != null
            ? _projectileSpawnPoint.Position
            : transform.position;

        // TODO: 포인터 좌표 읽고 Context에 저장할 것
        // TODO: origin 기준 조준점 계산하고 Context에 저장할 것
        // TODO: 조준 방향 계산하고 Context에 저장할 것
        // TODO: 좌클릭 입력 시 공격 명령 생성 요청할 것
        // TODO: 생성된 공격 명령을 시스템에 연결할 것
        // TODO: 현재 상태에 따라 이동, 상호작용 함수 연결할 것
    }
}
