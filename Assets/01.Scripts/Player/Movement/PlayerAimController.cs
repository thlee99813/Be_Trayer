using UnityEngine;

public class PlayerAimController : MonoBehaviour
{
    [SerializeField] private Camera _aimCamera;

    public Vector3 ResolveTargetPoint(Vector3 origin, Vector2 pointerScreenPosition)
    {
        Camera aimCamera = _aimCamera != null ? _aimCamera : Camera.main;
        if (aimCamera == null)
        {
            return origin + transform.forward;
        }

        Ray pointerRay = aimCamera.ScreenPointToRay(pointerScreenPosition);
        Plane groundPlane = new Plane(Vector3.up, origin);

        if (!groundPlane.Raycast(pointerRay, out float enter))
        {
            return origin + transform.forward;
        }

        return pointerRay.GetPoint(enter);
    }

    public Vector3 ResolveAimDirection(Vector3 origin, Vector3 targetPoint)
    {
        Vector3 aimDirection = targetPoint - origin;
        aimDirection.y = 0f;

        if (aimDirection.sqrMagnitude <= 0.0001f)
        {
            return transform.forward;
        }

        return aimDirection.normalized;
    }

    public void FaceDirection(Vector3 aimDirection)
    {
        if (aimDirection.sqrMagnitude <= 0.0001f)
        {
            return;
        }

        transform.forward = aimDirection;
    }
}
