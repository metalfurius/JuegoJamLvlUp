using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileTurret;
    BuildManager buildManager;
    private void Start() {
        buildManager=BuildManager.instance;
    }
    public void PurchaseStandardTurret(){
        Debug.Log("Standard turret purchased");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }
    public void PurchaseAnotherTurret(){
        Debug.Log("Another turret purchased");
        buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
    }
}
