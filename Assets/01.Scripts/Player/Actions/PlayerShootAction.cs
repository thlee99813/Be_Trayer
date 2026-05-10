using System;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerShootAction : MonoBehaviour
{
    [SerializeField] private PlayerAttackHitbox _attackHitbox;

    private Player _player;

    public event Action<PlayerAttackCommand> AttackCommandCreated;

    public PlayerAttackCommand LastAttackCommand { get; private set; }
    public float CooldownRemaining { get; private set; }
    public float CooldownDuration => _player != null ? _player.Stats.AttackCooldown : 0f;
    public bool IsOnCooldown => CooldownRemaining > 0f;

    private void OnValidate()
    {
        _player ??= GetComponent<Player>();
        _attackHitbox ??= GetComponentInChildren<PlayerAttackHitbox>();
    }

    private void Awake()
    {
        _player ??= GetComponent<Player>();
        _attackHitbox ??= GetComponentInChildren<PlayerAttackHitbox>();
    }

    private void Update()
    {
        if (CooldownRemaining <= 0f)
        {
            CooldownRemaining = 0f;
            return;
        }

        CooldownRemaining = Mathf.Max(0f, CooldownRemaining - Time.deltaTime);
    }

    public bool TryCreateAttackCommand(Vector3 origin, Vector3 aimDirection, Vector3 targetPoint, out PlayerAttackCommand attackCommand)
    {
        attackCommand = null;

        if (_player == null || IsOnCooldown)
        {
            return false;
        }

        if (aimDirection.sqrMagnitude <= 0.0001f)
        {
            return false;
        }

        attackCommand = new PlayerAttackCommand(origin, aimDirection, targetPoint);
        LastAttackCommand = attackCommand;
        CooldownRemaining = _player.Stats.AttackCooldown;

        if (_attackHitbox != null)
        {
            _attackHitbox.Activate(_player.Stats.AttackRange);
        }

        AttackCommandCreated?.Invoke(attackCommand);
        return true;
    }
}
