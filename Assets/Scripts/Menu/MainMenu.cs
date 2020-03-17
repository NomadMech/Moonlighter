using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animation _mainMenuAnimator;
    [SerializeField] private AnimationClip _fadeOutAnimation;
    [SerializeField] private AnimationClip _fadeInAnimation;

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }
    public void OnFadeOutComplete()
    {
        Debug.LogWarning("FadeOut Complete");
    }
    public void OnFadeInComplete()
    {
        Debug.LogWarning("FadeIn Complete");
        UIManager.Instance.SetCameraActive(false);
    }

    public void FadeIn()
    {
        _mainMenuAnimator.Stop();
        _mainMenuAnimator.clip = _fadeInAnimation;
        _mainMenuAnimator.Play();
    }

    public void FadeOut()
    {
        UIManager.Instance.SetCameraActive(false);

        _mainMenuAnimator.Stop();
        _mainMenuAnimator.clip = _fadeOutAnimation;
        _mainMenuAnimator.Play();
    }

    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if(previousState == GameManager.GameState.PREGAME && currentState == GameManager.GameState.RUNNING)
        {
            FadeOut();
        }
    }
}
