using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    buildManager buildManager;
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileTurret;

    private void Start()
    {
        buildManager = buildManager.instance;
    }

    public void selectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void selectMissileTurret()
    {
        Debug.Log("Missle Turret Selected");
        buildManager.SelectTurretToBuild(missileTurret);
    }
}
