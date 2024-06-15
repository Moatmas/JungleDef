using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void BoutonPlay()
    {
        if (GameSettings.Map == 0)
        {
            SceneManager.LoadSceneAsync("Map1");
        }
        else if (GameSettings.Map == 1)
        {
            SceneManager.LoadSceneAsync("Map2");
        }
    }

    public void deconnection()
    {
        SceneManager.LoadSceneAsync("Menu");
    }

    public void Quitter()
    {
        Debug.Log("Quitter le jeu!");
        Application.Quit();  
    }
}
