using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Nom de la scène à charger
    public string sceneToLoad;

    // Méthode pour charger la nouvelle scène
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}