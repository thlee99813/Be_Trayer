using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class CampUIController : MonoBehaviour
{
    [Header("Root References")]
    [SerializeField] private List<GameObject> _allyRoots;

    [Header("Text display")]
    [SerializeField] private TMP_Text _conversationText;
    [SerializeField] private TMP_Text _allyNameText;


    private void Refresh()
    {
        
    }
}
