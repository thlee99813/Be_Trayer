using UnityEngine;
using Unity.Cinemachine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class CameraController : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] private int _currentVCamIndex = 0;

    [Header("VCam Settings")]
    [SerializeField] private List<CinemachineCamera> _vCamList;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private int _startVCamIndex = 0;

    [Header("Transition Settings")]
    [SerializeField] private float _transitionDuration = 0.5f;
    [SerializeField] private int _lenseValue = 0;

    [Header("Priority Settings")]
    [SerializeField] private int _activePriority = 10;
    [SerializeField] private int _defaultPriority = 0;



    private void Start()
    {
        if (_vCamList == null || _vCamList.Count == 0)
        {
            Debug.LogWarning("CameraController: No virtual cameras assigned.");
        }

        if (mainCamera == null)
        {
            Debug.LogWarning("CameraController: Main camera is not assigned.");
        }

        SetStartVCam();

        // Display starting camera index in the console for debugging
        _currentVCamIndex = _startVCamIndex;
    }

    private void SetStartVCam()
    {
        if (_vCamList.Count > 0)
        {
            SwitchToCamera(_startVCamIndex); // Start with the camera at the specified index
        }
    }


    public void SwitchToCamera(int index)
    {
        if (index < 0 || index >= _vCamList.Count)
        {
            Debug.LogWarning("CameraController: Invalid camera index.");
            return;
        }

        // Deactivate all first
        foreach (var vCam in _vCamList)
            vCam.Priority = _defaultPriority; // all → 0

        // Then activate only the one you want
        _vCamList[index].Priority = _activePriority; // target → 20
        _currentVCamIndex = index;
    }
}
