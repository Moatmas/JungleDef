using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint slowTurret;
    public TurretBlueprint trap1;
    public Turret Tour_slow;


    public GameObject PanelstandardTurret;
    public TextMeshProUGUI Descriptionstandart;
    public TextMeshProUGUI NomStandart;

    public GameObject PanelMissileTurretItem;
    public TextMeshProUGUI DescriptionMissile;
    public TextMeshProUGUI NomMissile;

    public GameObject PanelSlowTurretItem;
    public TextMeshProUGUI DescriptionSlow;
    public TextMeshProUGUI NomSlow;

    public GameObject PanelTrapTurretItem;
    public TextMeshProUGUI DescriptionTrap;
    public TextMeshProUGUI NomTrap;


    BuildManager buildManager;

    public void Start ()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Tour Standard selectionnee");
        buildManager.SelectTurretToBuild(standardTurret);

        PanelstandardTurret.SetActive(true);
        NomStandart.text = "Gorille à Sarbacane";
        Descriptionstandart.text = "Prix : "+ standardTurret.cost + "\nEffet : inflige des dégats à une troupe unique\nDégat : " + standardTurret.bullet.damage;
        PanelMissileTurretItem.SetActive(false);
        PanelSlowTurretItem.SetActive(false);
        PanelTrapTurretItem.SetActive(false);

    }

    public void SelectMissileTurret()
    {
        Debug.Log("Tour Missile selectionnee");
        buildManager.SelectTurretToBuild(missileLauncher);

        PanelMissileTurretItem.SetActive(true);
        NomMissile.text = "Tigre de Combat";
        DescriptionMissile.text = "Prix : " + missileLauncher.cost + "\nEffet : inflige des dégats zone grâce à une explosion\nDégat : " + missileLauncher.bullet.damage;
        PanelSlowTurretItem.SetActive(false);
        PanelstandardTurret.SetActive(false);
        PanelTrapTurretItem.SetActive(false);
    }

    public void SelectSlowTurret()
    {
        Debug.Log("Tour ralentissante selectionnee");
        buildManager.SelectTurretToBuild(slowTurret);

        
        PanelSlowTurretItem.SetActive(true);
        NomSlow.text = "Vipère Cracheuse";
        DescriptionSlow.text = "Prix : " + slowTurret.cost + "\nEffet : Ralentit un enemie en lui infligeant de faibles dégats\nDégat : " + Tour_slow.damageOverTime + " par seconde";
        PanelMissileTurretItem.SetActive(false);
        PanelstandardTurret.SetActive(false);
        PanelTrapTurretItem.SetActive(false);
    }

    public void SelectTrap1Turret()
    {
        Debug.Log("Pi�ge scie tournante selectionnee");
        buildManager.SelectTurretToBuild(trap1);

        PanelTrapTurretItem.SetActive(true);
        NomTrap.text = "Scie";
        DescriptionTrap.text = "\nPrix : " + trap1.cost + "\nEffet : Met des dégats aux ennemis qu'elle touche mais en subit en retour\nDégat : 40";
        PanelMissileTurretItem.SetActive(false);
        PanelstandardTurret.SetActive(false);
        PanelSlowTurretItem.SetActive(false);

    }
}
