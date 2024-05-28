using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {   
        if (instance != null)
        {
            Debug.Log("Il y a deja un menu de construction");
            return;
        }
        instance = this;
    }


    
    public GameObject sellEffect;


    private TurretBlueprint turretToBuild;
    private Bloc selectedBloc;
    public SelectUI selectUI;

    public bool CanBuild { get { return turretToBuild != null; } }
  
    public void SelectBloc(Bloc bloc)
    {
        if(selectedBloc == bloc)
        {
            DeselectBloc();
            return;
        }
        selectedBloc = bloc;
        turretToBuild = null;

        selectUI.SetTarget(bloc);
    }

    public void DeselectBloc()
    {
        selectedBloc = null;
        selectUI.Hide();
    }


    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectBloc();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
