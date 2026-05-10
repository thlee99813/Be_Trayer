using UnityEngine;

public sealed class PlayerAttackCommand
{
    public PlayerAttackCommand(Vector3 origin, Vector3 direction, Vector3 targetPoint)
    {
        Origin = origin;
        Direction = direction;
        TargetPoint = targetPoint;
    }

    public Vector3 Origin { get; }
    public Vector3 Direction { get; }
    public Vector3 TargetPoint { get; }
}
