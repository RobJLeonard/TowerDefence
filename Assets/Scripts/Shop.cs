
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    buildManager buildManager;
    public TurretBlueprint standardTurret;
    public Text standardCost;
    public TurretBlueprint missileTurret;
    public Text missileCost;

    private void Start()
    {
        buildManager = buildManager.instance;
        standardCost.text = string.Format("${0}", standardTurret.turretCost);
        missileCost.text = string.Format("${0}", missileTurret.turretCost);
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
