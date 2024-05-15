using UnityEngine;

public class Bloc : MonoBehaviour
{

    public Color overColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;

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
        if (!buildManager.CanBuild)
            return;

        if (turret != null)
        {
            Debug.Log("Impossible de construire ici");
            return;
        }

        buildManager.BuildTurretOn(this);
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
