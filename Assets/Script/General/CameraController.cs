// ----------------------------------------------------//

//      Riego Maria Mercedes //

//--------------------------------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Vector2 StartAngle = new Vector2(90 * Mathf.Deg2Rad, 0);

    private new Camera camera;
    private Vector2 nearPlaneSize;

    public Transform follow;

    [SerializeField]
    private float maxDistance;

    private float sensitivity;

    [SerializeField]
    private OptionsCanvas _options;

    public Transform player;

    private void Awake()
    {
        _options.changeSens += ChangeSensitivity;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDestroy()
    {
        _options.changeSens -= ChangeSensitivity;
    }

    void Start()
    {
        ChangeSensitivity();
        
        camera = GetComponent<Camera>();

        CalculateNearPlaneSize();
    }

    private void ChangeSensitivity()
    {
        sensitivity = PlayerPrefs.GetFloat("sensitivity");
        if (sensitivity <= 0)
            sensitivity = 1;
    }

    public void SetAngle(int newAngle)
    {
        StartAngle = new Vector2(newAngle * Mathf.Deg2Rad, 0);
    }

    void Update()
    {
        float horizontalCam = Input.GetAxis("Mouse X");

        if (horizontalCam != 0)
        {
            StartAngle.x += horizontalCam * Mathf.Deg2Rad * sensitivity;

            player.forward = transform.forward;
            player.localRotation = Quaternion.Euler(0, player.localEulerAngles.y, 0);
        }

        float verticalCam = Input.GetAxis("Mouse Y"); 

        if (verticalCam != 0)
        {
            StartAngle.y += verticalCam * Mathf.Deg2Rad * sensitivity;
            StartAngle.y = Mathf.Clamp(StartAngle.y, -80 * Mathf.Deg2Rad, 80 * Mathf.Deg2Rad); 
        }
    }
    
    void LateUpdate()
    {
        Vector3 direction = new Vector3(
            Mathf.Cos(StartAngle.x) * Mathf.Cos(StartAngle.y),
            -Mathf.Sin(StartAngle.y),
            -Mathf.Sin(StartAngle.x) * Mathf.Cos(StartAngle.y));

        RaycastHit hit;
        float distance = maxDistance; 
        Vector3[] points = GetCameraCollisionPoints(direction);

        foreach (Vector3 point in points)
        {
            if (Physics.Raycast(point, direction, out hit, maxDistance))   
            {  
                distance = Mathf.Min((hit.point - follow.position).magnitude, distance);
            }
        }

        transform.position = follow.position + direction * distance;
        transform.rotation = Quaternion.LookRotation(follow.position - transform.position);
    }                           
    #region
    // EN CALCULATENEAR PLANE SIZE : calculamos lo que mide en total la camara, porque si no, el raycast sale del centro de la camara y se meteria la mitad dentro de objetos.
    //SU DEFINICION ES NEAR CLIPPING PLANE.
    // 2) ALTO, field of view es un angulo, y calculamos el alto haciendo un trangulo con el angulo de la field of view y la distancia que hay entre la camara y el clipping plane
    #endregion

    private void CalculateNearPlaneSize() 
    {                                          
        float height = Mathf.Tan(camera.fieldOfView * Mathf.Deg2Rad / 2) * camera.nearClipPlane;  
        float width = height * camera.aspect; 

        nearPlaneSize = new Vector2(width, height);
    }

    private Vector3[] GetCameraCollisionPoints(Vector3 direction)
    {
        Vector3 position = follow.position;
        Vector3 center = position + direction * (camera.nearClipPlane + 0.2f); 

        Vector3 right = transform.right * nearPlaneSize.x;
        Vector3 up = transform.up * nearPlaneSize.y;

        return new Vector3[] 
        {
            center - right + up,
            center + right + up,
            center - right - up,
            center + right - up
        };
    }
}