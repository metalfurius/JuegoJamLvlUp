using UnityEngine;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject ui;
    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition() + Vector3.down * 5;
        ui.SetActive(true);
    }
    public void Hide()
    {
        ui.SetActive(false);
    }
    public void Upgrade(){
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
}
