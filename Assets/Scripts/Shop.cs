using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    buildManager buildManager;

    private void Start()
    {
        buildManager = buildManager.instance;
    }

    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseMissileTurret()
    {
        Debug.Log("Missle Turret Selected");
        buildManager.SetTurretToBuild(buildManager.missileTurretPrefab);
    }
}
