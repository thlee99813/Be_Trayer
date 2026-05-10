using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class CampUIController : MonoBehaviour
{
    [Header("Root References")]
    [SerializeField] private List<CampAllyDisplay> _allyRoots;

    [Header("Text display")]
    [SerializeField] private TMP_Text _conversationText;


    private void Refresh()
    {
        
    }
}
