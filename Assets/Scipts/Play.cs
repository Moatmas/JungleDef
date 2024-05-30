using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BoutonPlay()
    {
        SceneManager.LoadSceneAsync("Map1");
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
