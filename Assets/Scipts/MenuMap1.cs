using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class MenuMap1 : MonoBehaviour
{

    void Start()
    {
        
    }

    public void Quitter()
    {
      Debug.Log("Quitter le jeu!");
      Application.Quit();  
    }

    public void deconnection()
    {
        SceneManager.LoadSceneAsync("Menu");
    }

    public void Menu ()
    {
        SceneManager.LoadScene("Menu");
    }



}
