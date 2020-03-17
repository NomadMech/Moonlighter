using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private MainMenu _menu;
    [SerializeField] private Camera _camera;

    private void Update()
    {
        if(GameManager.Instance.CurrentGameState != GameManager.GameState.PREGAME)
        {
            return;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.StartGame();
        }
    }

    public void SetCameraActive(bool active)
    {
        _camera.gameObject.SetActive(active);
    }
}
