using UnityEngine;

public class HealthLock : MonoBehaviour
{
    void Update()
    {
        Vector3 v = Camera.main.transform.position - transform.GetChild(0).position;
        v.x = v.z = 0.0f;
        transform.GetChild(0).LookAt(Camera.main.transform.position);
    }
}
