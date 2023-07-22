using System.Collections;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint 
{
    public GameObject prefab;
    public int cost;
    public GameObject upgradedPrefab;
    public int upgradeCost;
    public GameObject buildEffect;
    public GameObject destroyEffect;
    public GameObject upgradeEffect;
    public int GetSellAmount(){
        return cost/2;
    }
}
