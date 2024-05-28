using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint slowTurret;
    public TurretBlueprint trap1;

    BuildManager buildManager;

    public void Start ()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Tour Standard selectionnee");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileTurret()
    {
        Debug.Log("Tour Missile selectionnee");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectSlowTurret()
    {
        Debug.Log("Tour ralentissante selectionnee");
        buildManager.SelectTurretToBuild(slowTurret);
    }

    public void SelectTrap1Turret()
    {
        Debug.Log("Tour ralentissante selectionnee");
        buildManager.SelectTurretToBuild(trap1);

    }
}
