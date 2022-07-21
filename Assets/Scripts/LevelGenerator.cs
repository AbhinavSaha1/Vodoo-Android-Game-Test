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
    private GameObject[] _levelPrefabs;
    [SerializeField]
    private float _prefabSpawnOffset;
    private GameObject _previousLevelPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
    }
 
    void Update()
    {
        //if(_isLevelCreated == false)
        //{
        //    for (int i = 0; i <= _selectedNoOfLevelPrefabs; i++)
        //    {
        //        Debug.Log("Spawning object" + (i + 1));
        //    }
        //    _isLevelCreated = true;
        //}
    }
    private void GenerateLevel()
    {
        _selectedNoOfLevelPrefabs = Random.Range(_minLevelPrefabs, _maxLevelPrefabs);
        _firstLevelPrefab = Instantiate(_levelPrefabs[0], new Vector3(0, 0, 0), Quaternion.Euler(0f, 90f, 0f));

        _previousLevelPrefab = _firstLevelPrefab;
        
        for (int i = 1; i < _selectedNoOfLevelPrefabs; i++)
        {
            Debug.Log("Spawning object" + (i + 1));
            int _selectedPrefabIndex = Random.Range(0, _levelPrefabs.Length);
            var _selectedPrefabSpawnPos = new Vector3(_firstLevelPrefab.transform.position.x, _firstLevelPrefab.transform.position.y, _previousLevelPrefab.transform.position.z + _previousLevelPrefab.transform.localScale.x + _prefabSpawnOffset);
            GameObject _currentLevelPrefab =  Instantiate(_levelPrefabs[_selectedPrefabIndex],_selectedPrefabSpawnPos , Quaternion.Euler(0f, 90f, 0f));
            _previousLevelPrefab = _currentLevelPrefab;
        }

        Instantiate(_lastLevelPrefab, new Vector3(_firstLevelPrefab.transform.position.x, _firstLevelPrefab.transform.position.y, _previousLevelPrefab.transform.position.z + _previousLevelPrefab.transform.localScale.x + _prefabSpawnOffset), Quaternion.Euler(0f, 90f, 0f));
    }

}
