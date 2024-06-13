using System.IO;
using UnityEngine;

public class LoadSavedScenes : MonoBehaviour
{
    public SauvegardeScene sauvegardeScene;
    public GameObject panel;

    private void Start()
    {
        // Vérifie s'il y a des données à sauvegarder au démarrage
        CheckSaveData();
    }

    private void CheckSaveData()
    {
        // Si un fichier de sauvegarde existe, affiche le panneau
        string savePath = Application.persistentDataPath + "/SaveSlot1_" + sauvegardeScene.saveFileName;
        if (File.Exists(savePath))
        {
            ShowPanel();
        }
        else
        {
            HidePanel();
        }
    }

    private void ShowPanel()
    {
        // Affiche le panneau
        panel.SetActive(true);
    }

    private void HidePanel()
    {
        // Masque le panneau
        panel.SetActive(false);
    }

    public void OnClickYes()
    {
        // Cache le panneau et lance la dernière sauvegarde
        sauvegardeScene.LoadScene();
        HidePanel();
    }

    public void OnClickNo()
    {
        // Cache simplement le panneau
        HidePanel();
    }
}
