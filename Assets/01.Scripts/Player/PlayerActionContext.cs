using UnityEngine;

public class PlayerActionContext
{
    public Vector2 MoveInput { get; set; }
    public PlayerActionState CurrentState { get; set; } = PlayerActionState.Idle;
}
