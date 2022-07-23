using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private int _minLevelPrefabs;
    [SerializeField]
    private int _maxLevelPrefabs;
    [SerializeField]
    private int _selectedNoOfLevelPrefabs;
    [SerializeField]
    private GameObject _firstLevelPrefab;
    [SerializeField]
    private GameObject _lastLevelPrefab;
    [SerializeField]
    private List<GameObject> _levelPrefabs = new List<GameObject>(); 
    [SerializeField]
    private float _prefabSpawnOffset;
    private GameObject _spawnedLevelPrefab                ;
    private GameObject _previousLevelPrefab;

    private void Awake()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        _selectedNoOfLevelPrefabs = Random.Range(_minLevelPrefabs, _maxLevelPrefabs);
        _firstLevelPrefab = Instantiate(_levelPrefabs[0], new Vector3(0, 0, 0), Quaternion.Euler(0f, 90f, 0f));

        _previousLevelPrefab = _firstLevelPrefab;
        for (int i = 1; i < _selectedNoOfLevelPrefabs; i++)
        {
            Debug.Log("Spawning object" + (i + 1));
            int _selectedPrefabIndex = Random.Range(0, _levelPrefabs.Count);
            var _selectedPrefabSpawnPos = new Vector3(_firstLevelPrefab.transform.position.x, _firstLevelPrefab.transform.position.y, _previousLevelPrefab.transform.position.z + (_levelPrefabs[_selectedPrefabIndex].transform.localScale.x) / 2 + (_previousLevelPrefab.transform.localScale.x) / 2 + _prefabSpawnOffset);
            _spawnedLevelPrefab =  Instantiate(_levelPrefabs[_selectedPrefabIndex],_selectedPrefabSpawnPos , Quaternion.Euler(0f, 90f, 0f));
            //so that the level prefabs dont repeat themselves
            _levelPrefabs.RemoveAt(_selectedPrefabIndex);
            _previousLevelPrefab = _spawnedLevelPrefab;
        }
        //Spawning last prefab at the end
        Instantiate(_lastLevelPrefab, new Vector3(_firstLevelPrefab.transform.position.x, _firstLevelPrefab.transform.position.y, _previousLevelPrefab.transform.position.z + (_spawnedLevelPrefab.transform.localScale.x) / 2 + (_previousLevelPrefab.transform.localScale.x) / 2), Quaternion.Euler(0f, 90f, 0f));
    }

}
