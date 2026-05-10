using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerActionController))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private PlayerActionController _actionController;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _moveSpeed = 5f;

    public Vector3 Velocity => _rigidbody.linearVelocity;

    private void OnValidate()
    {
        CacheReferences();
    }

    private void Awake()
    {
        CacheReferences();
    }

    private void CacheReferences()
    {
        _actionController ??= GetComponent<PlayerActionController>();
        _rigidbody ??= GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move(_actionController.Context.MoveInput);
    }

    public void Move(Vector2 moveInput)
    {
        // TODO: 카메라 기준 이동으로 바꿀지 결정 필요함
        Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y).normalized;
        _rigidbody.linearVelocity = moveDirection * _moveSpeed;
    }

    public void Stop()
    {
        _rigidbody.linearVelocity = Vector3.zero;
    }
}
