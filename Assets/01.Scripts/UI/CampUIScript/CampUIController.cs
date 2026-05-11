using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class CampUIController : MonoBehaviour
{
    [Header("Root References")]
    [SerializeField] private List<CampAllyDisplay> _allyRoots;

    [Header("Text display")]
    [SerializeField] private TMP_Text _allyNameText;
    [SerializeField] private TMP_Text _conversationText;

    [Header("Button References")]
    [SerializeField] private List<Button> _interactionButtons;

    private List<TMP_Text> _interactionButtonTexts;

    private void Start()
    {
        Refresh();
        _interactionButtons.ForEach(button =>
        {
            _interactionButtonTexts.Add(button.GetComponentInChildren<TMP_Text>());
        });
    }



    private void Refresh()
    {
        
    }
}
