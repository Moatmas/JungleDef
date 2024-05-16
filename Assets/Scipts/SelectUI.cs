using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SelectUI : MonoBehaviour
{
    public TextMeshProUGUI upgradeCost;
    public Button upgradeButton;
    public GameObject ui;
    private Bloc target;
    
    public void SetTarget(Bloc t)
    {
        target = t;

        transform.position = target.getBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = target.turretBlueprint.upgradeCost + "$";
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "MAX";
            upgradeButton.interactable = false; 
        }

        ui.SetActive(true);
    }
    
    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectBloc();
    }
}
