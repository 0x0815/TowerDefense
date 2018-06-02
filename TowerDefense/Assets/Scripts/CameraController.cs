using UnityEngine;

public class CameraController : MonoBehaviour {

    public float panSPeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    public bool disableBorderMovement = true;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            disableBorderMovement = !disableBorderMovement;

        if (Input.GetKey("w") || (Input.mousePosition.y >= Screen.height - panBorderThickness && !disableBorderMovement))
        {
            transform.Translate(Vector3.forward * panSPeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || (Input.mousePosition.y <= panBorderThickness && !disableBorderMovement))
        {
            transform.Translate(Vector3.back * panSPeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || (Input.mousePosition.x >= Screen.width - panBorderThickness && !disableBorderMovement))
        {
            transform.Translate(Vector3.right * panSPeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || (Input.mousePosition.x <= panBorderThickness && !disableBorderMovement))
        {
            transform.Translate(Vector3.left * panSPeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}
