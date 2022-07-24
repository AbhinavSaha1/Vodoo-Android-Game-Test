using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    public LevelDataHolder LevelReference;
    public Text LevelTxt;

    private void Start()
    {
        LevelReference = GameObject.FindObjectOfType<LevelDataHolder>();
        LevelTxt = GetComponent<Text>();

        LevelTxt.text = "Level: " + LevelReference.CurrentLevel.ToString();
    }
}
