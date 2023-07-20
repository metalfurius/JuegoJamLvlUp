using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileTurret;
    BuildManager buildManager;
    private void Start() {
        buildManager=BuildManager.instance;
    }
    public void SelectStandardTurret(){
        Debug.Log("Standard turret purchased");
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectAnotherTurret(){
        Debug.Log("Another turret purchased");
        buildManager.SelectTurretToBuild(missileTurret);
    }
}
