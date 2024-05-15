using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;

    BuildManager buildManager;

    public void Start ()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Tour Standard s�lectionn�e");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileTurret()
    {
        Debug.Log("Tour Missile s�lectionn�e");
        buildManager.SelectTurretToBuild(missileLauncher);
    }
}
