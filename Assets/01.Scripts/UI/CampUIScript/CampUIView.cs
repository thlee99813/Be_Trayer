using UnityEngine;

public class CampUIView : MonoBehaviour
{
    [SerializeField] GameObject _campUIViewRoot;

    private void Awake()
    {
        if (_campUIViewRoot == null)
        {
            Debug.LogWarning("CampUIView: Camp UIView Root reference is not assigned.");
            return;
        }
        _campUIViewRoot.SetActive(false);
    }

    public void Show()
    {
        _campUIViewRoot.SetActive(true);
    }

    public void Hide()
    {
        _campUIViewRoot.SetActive(false);
    }
}
