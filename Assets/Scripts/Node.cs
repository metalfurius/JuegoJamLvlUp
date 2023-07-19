using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 posOffset;
    private GameObject turret;
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
        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        if (turret != null)
        {
            Debug.Log("Already built!");
            return;
        }
        else
        {
            GameObject turretToBuild = buildManager.GetTurretToBuild();
            turret = (GameObject)Instantiate(turretToBuild, transform.position + posOffset, transform.rotation);
        }
    }
    void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject()){
            return;
        }
        if (buildManager.GetTurretToBuild() == null)
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
