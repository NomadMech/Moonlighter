using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

[System.Serializable]public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState>
{

}

public class GameManager : Singleton<GameManager>
{
    public enum GameState
    {
        PREGAME,
        RUNNING,
        PAUSED
    }


    public GameObject[] SystemPrefabs;
    public EventGameState OnGameStateChanged;

    private List<GameObject> _instancedSystemPrefabs;
    private string _currentLevelName = string.Empty;
    private List<AsyncOperation> _loadOperations;
    private GameState _currentGameState = GameState.PREGAME;
    public GameState CurrentGameState
    {
        get { return _currentGameState; }
        private set { _currentGameState = value; }
    }
    private void Start()
    {
      
        DontDestroyOnLoad(gameObject);
        _loadOperations = new List<AsyncOperation>();

        InstantiateSystemPrefabs();
    }


    private void OnLoadOperationComplete(AsyncOperation ao)
    {
        if (_loadOperations.Contains(ao))
        {
            _loadOperations.Remove(ao);

            if(_loadOperations.Count == 0)
            {
                UpdateState(GameState.RUNNING);
            }

        }
        Debug.Log("Load Complete.");
    }

    private void OnUnLoadOperationComplete(AsyncOperation ao)
    {
        Debug.Log("UnLoad Complete.");
    }

    private void UpdateState(GameState state)
    {
        var previousGameState = _currentGameState;
        _currentGameState = state;

        switch (_currentGameState)
        {
            case GameState.PREGAME:
                break;
            case GameState.RUNNING:
                break;
            case GameState.PAUSED:
                break;
            default:
                break;
        }

        // dispatch message scene has changed
        OnGameStateChanged.Invoke(_currentGameState, previousGameState);
    }

    private void InstantiateSystemPrefabs()
    {

        for (int i = 0; i < SystemPrefabs.Length; i++)
        {
            var prefabInstance = Instantiate(SystemPrefabs[i]);
            _instancedSystemPrefabs.Add(prefabInstance);
        }
    }

    public void LoadLevel(string levelName)
    {
       var ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if(ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level: " + levelName);
            return;
        }

        ao.completed += OnLoadOperationComplete;
        _loadOperations.Add(ao);
        _currentLevelName = levelName;
    }

    public void UnloadLevel(string levelName)
    {
        var ao = SceneManager.UnloadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level: " + levelName);
            return;
        }
        ao.completed += OnUnLoadOperationComplete;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        for (int i = 0; i < _instancedSystemPrefabs.Count; i++)
        {
            Destroy(_instancedSystemPrefabs[i]);
        }

        _instancedSystemPrefabs.Clear();
    }

    public void StartGame()
    {
        LoadLevel("Main");
    }
}
