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
        rend.material.color = hoverColor;
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
