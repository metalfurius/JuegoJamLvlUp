using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 posOffset;
    private GameObject turret;
    private Color startColor;
    private Renderer rend;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Already built!");
            return;
        }
        else
        {
            GameObject turretToBuild=BuildManager.instance.GetTurretToBuild();
            turret=(GameObject)Instantiate(turretToBuild,transform.position+posOffset,transform.rotation);
        }
    }
    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
