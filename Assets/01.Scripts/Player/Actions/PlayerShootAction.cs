using System;
using UnityEngine;

public class PlayerShootAction : MonoBehaviour
{
    public event Action<PlayerAttackCommand> AttackCommandCreated;

    public PlayerAttackCommand LastAttackCommand { get; private set; }

    public bool TryCreateAttackCommand(Vector3 origin, Vector3 aimDirection, Vector3 targetPoint, out PlayerAttackCommand attackCommand)
    {
        // TODO: origin, aimDirection, targetPoint로 공격 명령 생성할 것
        attackCommand = null;
        return false;
    }
}
