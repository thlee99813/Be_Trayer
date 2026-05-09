using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// DEV/TEST ONLY — Remove or disable before shipping.
/// Press 1-5 to switch camera views via StageViewController.
/// </summary>
public class StageViewDebugInput : MonoBehaviour
{
    [SerializeField] private StageViewController stageViewController;

    private void Update()
    {
#if UNITY_EDITOR
        HandleDebugInput();
#endif
    }

    private void HandleDebugInput()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            Debug.Log("[DEBUG] Key 1 → CameraViewState.Main");
            stageViewController.SwitchCamera(CameraViewState.Main);
        }
        else if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            Debug.Log("[DEBUG] Key 2 → CameraViewState.FightWave");
            stageViewController.SwitchCamera(CameraViewState.FightWave);
        }
        else if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            Debug.Log("[DEBUG] Key 3 → CameraViewState.Camping");
            stageViewController.SwitchCamera(CameraViewState.Camping);
        }
        else if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            Debug.Log("[DEBUG] Key 4 → CameraViewState.Store");
            stageViewController.SwitchCamera(CameraViewState.Store);
        }
    }
}