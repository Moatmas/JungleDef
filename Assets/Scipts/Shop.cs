using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    public void Start ()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret()
    {
        Debug.Log("Tour Standard s�lectionn�e");
        buildManager.SetTurretToBuild(buildManager.standardTurretAsset);
    }

    public void PurchaseMissileTurret()
    {
        Debug.Log("Tour Missile s�lectionn�e");
        buildManager.SetTurretToBuild(buildManager.missileTurretAsset);
    }
}
