using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDataHolder : MonoBehaviour
{
    public static LevelDataHolder Instance;
    public int CurrentLevel;
    public List<GameObject> LevelData = new List<GameObject>();
    
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

}
