using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;
    public float zoom;
    public float farZoom;
    public float nearZoom;
    
    void Start ()
    {

	}
	
	void Update ()
    {
        MoveCamera();
        ZoomCamera();

        if (Input.GetKeyDown(KeyCode.F))
        {
            FocusOnPlayer();
        }
	}

    //TODO: write this function
    void FocusOnPlayer()
    {
        Debug.LogWarning("FUNCTION NOT IMPLEMENTED");
    }

    void MoveCamera()
    {
        Vector3 pos = transform.position;

        //vertical movement
        if (Input.mousePosition.y >= Screen.height)
        {
            pos.z += speed * Time.deltaTime;
        }
        else if (Input.mousePosition.y <= 0)
        {
            pos.z -= speed * Time.deltaTime;
        }

        //horizontal movement
        if (Input.mousePosition.x <= 0)
        {
            pos.x -= speed * Time.deltaTime;
        }
        else if (Input.mousePosition.x >= Screen.width)
        {
            pos.x += speed * Time.deltaTime;
        }
        
        transform.position = pos;
    }

    void ZoomCamera()
    {
        zoom += Input.mouseScrollDelta.y;

        //if (zoom < minZoom)
        //    zoom = minZoom;
        //else if (zoom > maxZoom)
        //    zoom = maxZoom;
        //is same as this code:
        zoom = Mathf.Clamp(zoom, farZoom, nearZoom);

        Vector3 pos = Camera.main.transform.localPosition;
        pos.z = zoom;
        Camera.main.transform.localPosition = pos;
    }
}
