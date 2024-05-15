using UnityEngine;

public class Bloc : MonoBehaviour
{

    public Color overColor;
    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.materials[1].color;

        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (buildManager.GetTurretToBuild() == null)
            return;

        if (turret != null)
        {
            Debug.Log("Impossible de construire ici");
            return;
        }

        GameObject turretToBuild = buildManager.GetTurretToBuild();

        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset,transform.rotation);
    }

    void OnMouseOver()
    {
        if (buildManager.GetTurretToBuild() == null)
            return;

        rend.materials[1].color = overColor;
    }

    void OnMouseExit()
    {
        rend.materials[1].color = startColor;
    }

}
