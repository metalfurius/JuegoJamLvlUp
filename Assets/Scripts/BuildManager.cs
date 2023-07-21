using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one Buildmanager");
            return;
        }
        instance = this;
    }
    public GameObject buildEffect;
    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money>=turretToBuild.cost; } }
    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money<turretToBuild.cost)
        {
            Debug.Log("no money");
            return;
        }
        PlayerStats.Money-=turretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        GameObject effect=(GameObject)Instantiate(buildEffect,node.GetBuildPosition(),Quaternion.identity);
        Destroy(effect,5f);
        Debug.Log("Money left"+PlayerStats.Money);
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

}
