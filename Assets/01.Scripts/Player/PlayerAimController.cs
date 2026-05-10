using UnityEngine;

public class PlayerAimController : MonoBehaviour
{
    [SerializeField] private Camera _aimCamera;

    public Vector3 ResolveTargetPoint(Vector3 origin, Vector2 pointerScreenPosition)
    {
        // TODO: 조준 카메라 기준 타겟 지점 계산할 것
        return origin + transform.forward;
    }

    public Vector3 ResolveAimDirection(Vector3 origin, Vector3 targetPoint)
    {
        // TODO: origin에서 targetPoint로 향하는 조준 방향 계산할 것
        return transform.forward;
    }
}
