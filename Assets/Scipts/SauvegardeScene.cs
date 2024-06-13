using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SauvegardeScene : MonoBehaviour
{
    public PauseManager pauseManager;
    public MenuMap1 menuMap1;
    public string saveFileName = "sceneData.json";

    public List<GameObject> objectPrefabs; // Liste de préfabs d'objets que vous pourriez recréer
    private Dictionary<string, GameObject> prefabDictionary;
    private SceneData sceneData;

    [System.Serializable]
    public class ObjectData
    {
        public string name;
        public Vector3 position;
        public Quaternion rotation;
        public bool isActive;
    }

    [System.Serializable]
    public class PauseManagerData
    {
        public bool isPaused;
    }

    [System.Serializable]
    public class MenuMap1Data
    {
        public string currentSceneName;
    }

    [System.Serializable]
    public class SceneData
    {
        public List<ObjectData> objects = new List<ObjectData>();
        public PauseManagerData pauseManagerData;
        public MenuMap1Data menuMap1Data;
    }

    private void Awake()
    {
        // Initialiser le dictionnaire de préfabs
        prefabDictionary = new Dictionary<string, GameObject>();
        foreach (GameObject prefab in objectPrefabs)
        {
            prefabDictionary[prefab.name] = prefab;
        }
    }

    public void SaveScene(int saveSlot)
    {
        SceneData sceneData = new SceneData();
        GameObject[] allObjects = SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (GameObject obj in allObjects)
        {
            ObjectData data = new ObjectData();
            data.name = obj.name.Replace("(Clone)", ""); // Retirer "(Clone)" du nom de l'objet
            data.position = obj.transform.position;
            data.rotation = obj.transform.rotation;
            data.isActive = obj.activeSelf;

            sceneData.objects.Add(data);
        }

        sceneData.pauseManagerData = new PauseManagerData
        {
            isPaused = pauseManager.isPaused
        };

        sceneData.menuMap1Data = new MenuMap1Data
        {
            currentSceneName = SceneManager.GetActiveScene().name
        };

        string json = JsonUtility.ToJson(sceneData, true);
        string savePath = Application.persistentDataPath + "/SaveSlot" + saveSlot.ToString() + "_" + saveFileName;

        if (File.Exists(savePath))
        {
            File.Delete(savePath);
        }

        File.WriteAllText(savePath, json);
        Debug.Log("Scene saved to " + savePath);
    }

    public void SaveScene()
    {
        SaveScene(1);
    }

    public void LoadScene()
    {
        string savePath = Application.persistentDataPath + "/SaveSlot1_" + saveFileName;
        if (File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            sceneData = JsonUtility.FromJson<SceneData>(jsonData);

            // Abonnez-vous à l'événement sceneLoaded
            SceneManager.sceneLoaded += OnSceneLoaded;

            // Charger la scène Map1
            SceneManager.LoadScene("Map1");

            Debug.Log("Scene loaded from " + savePath);
        }
        else
        {
            Debug.LogWarning("No save file found at " + savePath);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Map1")
        {
            // Restaurer l'état de la scène
            foreach (ObjectData objData in sceneData.objects)
            {
                GameObject obj = GameObject.Find(objData.name);
                if (obj != null)
                {
                    obj.transform.position = objData.position;
                    obj.transform.rotation = objData.rotation;
                    obj.SetActive(objData.isActive);
                }
                else
                {
                    // Si l'objet n'est pas trouvé, essayez de le recréer à partir du prefab
                    if (prefabDictionary.ContainsKey(objData.name))
                    {
                        GameObject prefab = prefabDictionary[objData.name];
                        GameObject newObj = Instantiate(prefab, objData.position, objData.rotation);
                        newObj.name = objData.name; // Assurez-vous que le nom est correct
                        newObj.SetActive(objData.isActive);
                    }
                    else
                    {
                        Debug.LogWarning("Object " + objData.name + " not found and no prefab available.");
                    }
                }
            }

            // Restaurer l'état du gestionnaire de pause
            pauseManager.isPaused = sceneData.pauseManagerData.isPaused;

            // Désabonnez-vous de l'événement sceneLoaded après restauration
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
