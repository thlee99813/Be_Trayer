using System.Collections;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    [SerializeField] private Collider _hitboxCollider;
    [SerializeField] private AttackHitboxRangeScaler _rangeScaler;
    [SerializeField] private float _activeDuration = 0.1f;

    private Coroutine _disableRoutine;

    public bool IsActive => _hitboxCollider != null && _hitboxCollider.enabled;

    private void OnValidate()
    {
        CacheReferences();
    }

    private void Awake()
    {
        CacheReferences();
        DisableHitbox();
    }

    private void OnEnable()
    {
        CacheReferences();
        DisableHitbox();
    }

    public void Activate()
    {
        CacheReferences();

        if (_hitboxCollider == null)
        {
            return;
        }

        _hitboxCollider.enabled = true;

        if (_disableRoutine != null)
        {
            StopCoroutine(_disableRoutine);
        }

        _disableRoutine = StartCoroutine(DisableAfterDelay());
    }

    public void Activate(float range)
    {
        CacheReferences();
        _rangeScaler?.ApplyRange(range);
        Activate();
    }

    public void DisableHitbox()
    {
        if (_disableRoutine != null)
        {
            StopCoroutine(_disableRoutine);
            _disableRoutine = null;
        }

        if (_hitboxCollider != null)
        {
            _hitboxCollider.enabled = false;
        }
    }

    private void CacheReferences()
    {
        _hitboxCollider ??= GetComponent<Collider>();
        _rangeScaler ??= GetComponent<AttackHitboxRangeScaler>();
    }

    private IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(_activeDuration);
        DisableHitbox();
    }
}
