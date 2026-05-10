using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIDebugTestController : MonoBehaviour
{
    [SerializeField] private FadeView _fadeviewUI;
    [SerializeField] private CampUIView _campUIView;

    Keyboard keyboard = Keyboard.current;
    void Start()
    {
        keyboard = Keyboard.current;
    }

    private void Update()
    {
        FadeInOutTest();
        CampUIViewTest();
    }

    void FadeInOutTest()
    {
        if (keyboard.digit1Key.wasPressedThisFrame)
        {
            _fadeviewUI.FadeIn();
        }
        else if (keyboard.digit2Key.wasPressedThisFrame)
        {
            _fadeviewUI.FadeOut();
        }
        else if (keyboard.digit3Key.wasPressedThisFrame)
        {
            _fadeviewUI.FadeInThenOut();
        }
    }

    void CampUIViewTest()
    {
        if (keyboard.eKey.wasPressedThisFrame)
        {
            _campUIView.Show();
        }
        else if (keyboard.qKey.wasPressedThisFrame)
        {
            _campUIView.Hide();
        }
    }
}
