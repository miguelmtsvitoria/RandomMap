using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public Slider difficulty;

    public void LoadSceneSmallMap()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadSceneMediumMap()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadSceneBigMap()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
 
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
           PlayerPrefs.SetFloat("Transitions", difficulty.value);
        }
    }

}
