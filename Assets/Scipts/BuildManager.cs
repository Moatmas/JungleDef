using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {   
        if (instance != null)
        {
            Debug.Log("Il y a d�j� un menu de construction");
            return;
        }
        instance = this;
    }


    public GameObject standardTurretAsset;
    public GameObject missileTurretAsset;

   

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }

    public void BuildTurretOn (Bloc bloc) 
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log ("Pas assez d'argent pour acheter ceci!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, bloc.getBuildPosition(), Quaternion.identity);
        bloc.turret = turret;

        Debug.Log ("Tour construite, argent restant : " + PlayerStats.Money);
    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
