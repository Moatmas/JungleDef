using UnityEngine;

public class Bloc : MonoBehaviour
{

    public Color overColor;
    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;


    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.materials[1].color;
    }

    void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Impossible de construire ici");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset,transform.rotation);
    }

    void OnMouseOver()
    {
        rend.materials[1].color = overColor;
    }

    void OnMouseExit()
    {
        rend.materials[1].color = startColor;
    }

}
