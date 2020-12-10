using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] Button[] levels;
   
    const string Key = "unlockLevel";

    private void Start()
    {      
        int getLevels = PlayerPrefs.GetInt(Key, 1);
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].interactable = false;
        }
        for (int i = 0; i < getLevels; i++)
        {
            levels[i].interactable = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
        }
    }
    public void LoadLevel(int i)
    {
        SceneManager.LoadScene(i);
    }

}
