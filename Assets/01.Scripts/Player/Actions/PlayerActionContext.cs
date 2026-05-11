using UnityEngine;

public class PlayerActionContext
{
    public Vector2 MoveInput { get; set; }
    public Vector2 PointerScreenPosition { get; set; }
    public Vector3 AimDirection { get; set; }
    public Vector3 TargetPoint { get; set; }
    public PlayerAttackCommand LastAttackCommand { get; set; }
    public PlayerActionState CurrentState { get; set; } = PlayerActionState.Idle;
}
