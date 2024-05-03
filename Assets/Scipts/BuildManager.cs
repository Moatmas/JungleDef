using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {   
        if (instance != null)
        {
            Debug.Log("Il y a déjà un menu de construction");
            return;
        }
        instance = this;
    }


    public GameObject standardTurretAsset;

    void Start()
    {
        turretToBuild = standardTurretAsset;
    }

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
