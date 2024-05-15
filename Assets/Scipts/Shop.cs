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
        Debug.Log("Tour Standard sélectionnée");
        buildManager.SetTurretToBuild(buildManager.standardTurretAsset);
    }

    public void PurchaseMissileTurret()
    {
        Debug.Log("Tour Missile sélectionnée");
        buildManager.SetTurretToBuild(buildManager.missileTurretAsset);
    }
}
