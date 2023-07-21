using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileTurret;
    public TurretBlueprint laserTurret;
    BuildManager buildManager;
    private void Start() {
        buildManager=BuildManager.instance;
    }
    public void SelectStandardTurret(){
        Debug.Log("Standard turret selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectMissileTurret(){
        Debug.Log("Missile turret selected");
        buildManager.SelectTurretToBuild(missileTurret);
    }
    public void SelectLaserTurret(){
        Debug.Log("Laser turret selected");
        buildManager.SelectTurretToBuild(laserTurret);
    }
}
