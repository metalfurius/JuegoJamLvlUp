using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 posOffset;
    [Header("Optional")]
    public GameObject turret;
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
        if (!buildManager.CanBuild)
        {
            return;
        }
        if (turret != null)
        {
            Debug.Log("Already built!");
            return;
        }
        buildManager.BuildTurretOn(this);
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
}
