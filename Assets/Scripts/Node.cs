using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 posOffset;
    [HideInInspector]
    public GameObject turret;
    [HideInInspector] 
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded=false;
    private Color startColor;
    private Renderer rend;
    BuildManager buildManager;
    public Color notEnoughMoneyColor;

    private void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject()){
            return;
        }
        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        BuildTurret(buildManager.GetTurretToBuild());
    }
    public Vector3 GetBuildPosition(){
        return transform.position+posOffset;
    }
    void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject()){
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        if(buildManager.HasMoney){
            rend.material.color = hoverColor;  
        }
        else
        {
            rend.material.color=notEnoughMoneyColor;
        }
        
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    void BuildTurret(TurretBlueprint blueprint){
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("no money");
            return;
        }
        PlayerStats.Money -= blueprint.cost;
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        GameObject effect = (GameObject)Instantiate(blueprint.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);

    }
    public void UpgradeTurret(){
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("no money");
            return;
        }
        PlayerStats.Money -= turretBlueprint.upgradeCost;
        Destroy(turret);
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        GameObject effect = (GameObject)Instantiate(turretBlueprint.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);
        isUpgraded=true;
    }
}
