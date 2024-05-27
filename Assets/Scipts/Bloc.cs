using UnityEngine;


public class Bloc : MonoBehaviour
{

    public Color overColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.materials[1].color;

        buildManager = BuildManager.instance;
    }

    public Vector3 getBuildPosition (){
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        
        if (turret != null)
        {
            buildManager.SelectBloc(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }
    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Pas assez d'argent pour acheter ceci!");
            return;
        }

        PlayerStats.Money -= blueprint.cost;
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, getBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        Debug.Log("Tour construite, argent restant : " + PlayerStats.Money);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Pas assez d'argent pour amérioler ceci!");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;
        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedTurret, getBuildPosition(), Quaternion.identity);
        turret = _turret;
        
        isUpgraded = true;

        Debug.Log("Tour ameliorée, argent restant : " + PlayerStats.Money);
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, getBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        turretBlueprint = null;

        Debug.Log("Tour vendue, argent restant : " + PlayerStats.Money);
    }

    void OnMouseOver()
    {
        if (!buildManager.CanBuild)
            return;

        rend.materials[1].color = overColor;
    }

    void OnMouseExit()
    {
        rend.materials[1].color = startColor;
    }

}
