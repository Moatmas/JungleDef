using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class MenuMap1 : MonoBehaviour
{

    public SauvegardeScene sauvegardeScene;
    public PauseManager pauseManager;
    void Start()
    {
        
    }

    public void Quitter()
    {
        pauseManager.Resume();
        sauvegardeScene.SaveScene();
        Debug.Log("Quitter le jeu!");
        Application.Quit();  
    }

    public void deconnection()
    {
        pauseManager.Resume();
        sauvegardeScene.SaveScene();
        SceneManager.LoadSceneAsync("Menu");
    }

    public void Menu ()
    {
        pauseManager.Resume();
        sauvegardeScene.SaveScene();
        SceneManager.LoadScene("MenuPreGame");
    }



}
