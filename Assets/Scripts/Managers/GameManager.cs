using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : Singleton<GameManager>
{
    public GameObject[] SystemPrefabs;

    private List<GameObject> _instancedSystemPrefabs;
    private string _currentLevelName = string.Empty;
    private List<AsyncOperation> _loadOperations;


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

            // dispatch message
            //transition scene
        }
        Debug.Log("Load Complete.");
    }

    private void OnUnLoadOperationComplete(AsyncOperation ao)
    {
        Debug.Log("UnLoad Complete.");
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
}
