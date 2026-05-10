using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// DEBUG ONLY — Remove or disable this GameObject in a shipping build.
/// Press 1–5 to switch to the corresponding vCam index.
/// </summary>
public class CameraDebugController : MonoBehaviour
{
    // ── Inspector ─────────────────────────────────────────────────────────────
    [Header("Reference")]
    [SerializeField] private CameraController _cameraController;

    [Header("Debug")]
    [SerializeField] private bool _enableDebugInput = true;

    // ── Cached Keys ───────────────────────────────────────────────────────────
    private static readonly Key[] _indexKeys =
    {
        Key.Digit1,
        Key.Digit2,
        Key.Digit3,
        Key.Digit4,
        Key.Digit5,
    };

    // ── Unity Lifecycle ───────────────────────────────────────────────────────
    private void Awake()
    {
        if (_cameraController == null)
            Debug.LogWarning("CameraDebugController: CameraController reference is not assigned.");
    }

    private void Update()
    {
        if (!_enableDebugInput)        return;
        if (_cameraController == null) return;

        for (int i = 0; i < _indexKeys.Length; i++)
        {
            if (Keyboard.current[_indexKeys[i]].wasPressedThisFrame)
            {
                Debug.Log($"[CameraDebug] Switching to camera index {i}");
                _cameraController.SwitchToCamera(i);
            }
        }
    }
}