using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panMargins = 20f;
    public float scrollSpeed = 5000f;
    public float minY=10f;
    public float maxY=80f;
    private void Update()
    {
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panMargins)
        {

            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panMargins)
        {

            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panMargins)
        {

            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panMargins)
        {

            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * scrollSpeed * Time.deltaTime;
        pos.y=Mathf.Clamp(pos.y,minY,maxY);
        transform.position=pos;
    }
}
