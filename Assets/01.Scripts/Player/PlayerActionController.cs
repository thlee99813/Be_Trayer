using UnityEngine;

[RequireComponent(typeof(PlayerInputReader))]
public class PlayerActionController : MonoBehaviour
{
    [SerializeField] private PlayerInputReader _inputReader;

    private readonly PlayerActionContext _context = new();

    public PlayerActionContext Context => _context;

    private void Awake()
    {
        if (_inputReader == null)
        {
            _inputReader = GetComponent<PlayerInputReader>();
        }
    }

    private void Update()
    {
        _context.MoveInput = _inputReader.ReadMoveInput();
        _context.CurrentState = _context.MoveInput == Vector2.zero
            ? PlayerActionState.Idle
            : PlayerActionState.Move;

        // TODO: 현재 상태에 따라 이동, 사격, 상호작용 함수 연결할 것
    }
}
