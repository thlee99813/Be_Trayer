using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CampAllyDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text _allyNameText;
    [SerializeField] Image _allyPortraitImage;

    public void SetAllyName(string name, Color color = default(Color))
    {
        _allyNameText.text = name;
        _allyNameText.color = color;
    }

    public void SetAllyColor(Color color)
    {
        _allyPortraitImage.color = color;
    }

    public void SetAllyPortrait(Sprite portrait)
    {
        _allyPortraitImage.sprite = portrait;
    }
}
