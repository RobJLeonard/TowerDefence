using UnityEngine;

public class buildManager : MonoBehaviour {

    public static buildManager instance;
    
    public GameObject standardTurretPrefab;
    public GameObject missileTurretPrefab;

    private GameObject turretToBuild;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Multiple Build Managers");
            return;
        }
        instance = this;
    }

    

    

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
	
    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
