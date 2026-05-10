using UnityEngine;
using System.Collections;

/// <summary>
/// Handles fade in / fade out on a CanvasGroup.
///
/// HOW YOUR TEAM USES THIS:
///   _fadeView.FadeIn();
///   _fadeView.FadeOut();
///   _fadeView.FadeInThenOut();  // Fade in, then fade out sequentially
/// </summary>
[RequireComponent(typeof(CanvasGroup))]
public class FadeView : MonoBehaviour
{
    // ── Inspector ─────────────────────────────────────────────────────────────
    [Header("Settings")]
    [SerializeField] private float _fadeDuration = 1f;

    [Header("Null Check")]
    [SerializeField] private bool _enableNullWarnings = true;

    // ── Runtime State ─────────────────────────────────────────────────────────
    [Header("Runtime State — Read Only")]
    [SerializeField] private string _currentState = "Idle";

    // ── Private ───────────────────────────────────────────────────────────────
    private CanvasGroup _canvasGroup;
    private Coroutine   _activeCoroutine;

    // ── Unity Lifecycle ───────────────────────────────────────────────────────
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    // ── Public API ────────────────────────────────────────────────────────────

    public void FadeIn()
    {
        StartFade(FadeCoroutine(0f, 1f, "FadeIn"));
    }

    public void FadeOut()
    {
        StartFade(FadeCoroutine(1f, 0f, "FadeOut"));
    }

    /// <summary>Fades in, then fades out sequentially.</summary>
    public void FadeInThenOut()
    {
        StartFade(FadeInThenOutCoroutine());
    }

    // ── Private ───────────────────────────────────────────────────────────────

    /// <summary>Stops any running fade before starting a new one.</summary>
    private void StartFade(IEnumerator coroutine)
    {
        if (_activeCoroutine != null)
            StopCoroutine(_activeCoroutine);

        _activeCoroutine = StartCoroutine(coroutine);
    }

    private IEnumerator FadeCoroutine(float from, float to, string stateName)
    {
        _currentState = stateName;

        float elapsedTime = 0f;

        while (elapsedTime < _fadeDuration)
        {
            _canvasGroup.alpha  = Mathf.Lerp(from, to, elapsedTime / _fadeDuration);
            elapsedTime        += Time.deltaTime;
            yield return null;
        }

        _canvasGroup.alpha = to;
        _currentState      = "Idle";
    }

    private IEnumerator FadeInThenOutCoroutine()
    {
        yield return FadeCoroutine(0f, 1f, "FadeIn");
        yield return FadeCoroutine(1f, 0f, "FadeOut");
    }
}