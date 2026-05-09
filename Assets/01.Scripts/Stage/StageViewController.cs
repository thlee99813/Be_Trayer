using UnityEngine;
using System.Collections.Generic;

public enum CameraViewState
{
    Main,
    FightWave,
    Camping,
    Store,
}

public class StageViewController : MonoBehaviour
{
    [SerializeField] private List<Camera> cameras;
    [SerializeField] private Camera mainCamera; // Assign your main camera here



    private Camera activeCamera;

    private void Start()
    {
        // Disable all cameras first
        foreach (Camera camera in cameras)
        {
            camera.gameObject.SetActive(false);
        }

        // Activate main camera at start
        if (mainCamera != null)
        {
            SwitchCamera(mainCamera);
        }
        else if (cameras.Count > 0)
        {
            // Fallback: use the first camera in the list
            SwitchCamera(cameras[0]);
        }
        else
        {
            Debug.LogWarning("StageController: No cameras assigned.");
        }
    }

    /// <summary>
    /// Switch to a camera by reference.
    /// </summary>
    public void SwitchCamera(Camera targetCamera)
    {
        if (targetCamera == null)
        {
            Debug.LogWarning("StageController: Target camera is null.");
            return;
        }

        // Deactivate current active camera
        if (activeCamera != null)
        {
            activeCamera.gameObject.SetActive(false);
        }

        // Activate the new camera
        targetCamera.gameObject.SetActive(true);
        activeCamera = targetCamera;

        Debug.Log($"StageController: Switched to camera '{targetCamera.name}'");
    }

    /// <summary>
    /// Switch to a camera by its index in the cameras list.
    /// </summary>
    public void SwitchCamera(int index)
    {
        if (index < 0 || index >= cameras.Count)
        {
            Debug.LogWarning($"StageController: Camera index {index} is out of range.");
            return;
        }

        SwitchCamera(cameras[index]);
    }

    /// <summary>
    /// Switch to a camera by its GameObject name.
    /// </summary>
    public void SwitchCamera(string cameraName)
    {
        Camera target = cameras.Find(c => c.name == cameraName);

        if (target == null)
        {
            Debug.LogWarning($"StageController: No camera found with name '{cameraName}'.");
            return;
        }

        SwitchCamera(target);
    }

    public void SwitchCamera(CameraViewState viewState)
    {
        // Example mapping of view states to cameras
        switch (viewState)
        {
            case CameraViewState.Main:
                SwitchToMainCamera();
                break;
            case CameraViewState.FightWave:
                SwitchCamera("FightWaveCamera"); // Ensure you have a camera named "FightWaveCamera"
                break;
            case CameraViewState.Camping:
                SwitchCamera("CampingCamera"); // Ensure you have a camera named "CampingCamera"
                break;
            case CameraViewState.Store:
                SwitchCamera("StoreCamera"); // Ensure you have a camera named "StoreCamera"
                break;
            default:
                Debug.LogWarning($"StageController: Unhandled view state '{viewState}'.");
                break;
        }
    }

    /// <summary>
    /// Switch back to the designated main camera.
    /// </summary>
    public void SwitchToMainCamera()
    {
        SwitchCamera(mainCamera);
    }

    /// <summary>
    /// Returns the currently active camera.
    /// </summary>
    public Camera GetActiveCamera() => activeCamera;
}
