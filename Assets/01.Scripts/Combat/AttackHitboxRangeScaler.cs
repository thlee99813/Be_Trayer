using UnityEngine;

public class AttackHitboxRangeScaler : MonoBehaviour
{
    private enum RangeAxis
    {
        X,
        Y,
        Z,
    }

    [SerializeField] private Transform _hitboxRoot;
    [SerializeField] private RangeAxis _rangeAxis = RangeAxis.Z;
    [SerializeField] private float _defaultRange = 1f;

    private Vector3 _baseLocalScale = Vector3.one;
    private Vector3 _baseLocalPosition = Vector3.zero;
    private bool _isBaseTransformCached;

    private void OnValidate()
    {
        CacheReferences();
        _isBaseTransformCached = false;
    }

    private void Awake()
    {
        CacheReferences();
        CacheBaseTransform();
    }

    public void ApplyRange(float range)
    {
        CacheReferences();
        CacheBaseTransform();

        if (_hitboxRoot == null)
        {
            return;
        }

        float safeDefaultRange = Mathf.Max(0.01f, _defaultRange);
        float safeRange = Mathf.Max(0.01f, range);
        float scaleMultiplier = safeRange / safeDefaultRange;

        Vector3 localScale = _baseLocalScale;
        Vector3 localPosition = _baseLocalPosition;
        Vector3 axisDirection = ResolveAxisDirection();
        int axisIndex = (int)_rangeAxis;

        localScale[axisIndex] = _baseLocalScale[axisIndex] * scaleMultiplier;
        localPosition += axisDirection * ((safeRange - safeDefaultRange) * 0.5f);

        _hitboxRoot.localScale = localScale;
        _hitboxRoot.localPosition = localPosition;
    }

    private void CacheReferences()
    {
        _hitboxRoot ??= transform;
    }

    private void CacheBaseTransform()
    {
        if (_hitboxRoot == null || _isBaseTransformCached)
        {
            return;
        }

        _baseLocalScale = _hitboxRoot.localScale;
        _baseLocalPosition = _hitboxRoot.localPosition;
        _isBaseTransformCached = true;
    }

    private Vector3 ResolveAxisDirection()
    {
        switch (_rangeAxis)
        {
            case RangeAxis.X:
                return Vector3.right;
            case RangeAxis.Y:
                return Vector3.up;
            default:
                return Vector3.forward;
        }
    }
}
