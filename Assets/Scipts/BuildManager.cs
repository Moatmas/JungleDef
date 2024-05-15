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
    public GameObject missileTurretAsset;

   

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
