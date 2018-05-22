using UnityEngine;

public class buildManager : MonoBehaviour {

    public static buildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Multiple Build Managers");
            return;
        }
        instance = this;
    }
      
    public GameObject standardTurretPrefab;
    public GameObject missileTurretPrefab;

    private TurretBlueprint turretToBuild;

    public bool CanBuild {  get { return turretToBuild != null;  } }

    public bool CanAfford { get { return PlayerStats.Money >= turretToBuild.turretCost; } }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.turretCost)
        {
            Debug.Log("INSUFFICIENT FUNDS");
            return;
        }
        else
        {
            PlayerStats.Money -= turretToBuild.turretCost;
            GameObject turret = (GameObject)Instantiate(turretToBuild.turretPrefab, node.GetBuildPosition(), Quaternion.identity);
            node.turret = turret;

            Debug.Log("Turret Built. Money left: " + PlayerStats.Money);
        }
    }
 
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public bool TurretSelected()
    {
        return (turretToBuild != null);
    }

    public void DeselectTurret()
    {
        turretToBuild = null;
    }
}
