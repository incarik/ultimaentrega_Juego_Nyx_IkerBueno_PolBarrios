using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerTrasnform;
    public Vector3 offset;
    public Vector2 minCameraPosition;
    public Vector2 maxCameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTrasnform != null)
        {
             Vector3 desiredPosition = playerTrasnform.position + offset;

        float clampX = Mathf.Clamp(desiredPosition.x, minCameraPosition.x, maxCameraPosition.x);
        float clampY = Mathf.Clamp(desiredPosition.y, minCameraPosition.y, maxCameraPosition.y);
        // Sirve para poner limites para la camara
        Vector3 clampedPosition = new Vector3 (clampX, clampY, desiredPosition.z);
        transform.position = clampedPosition;

        }
    }
}
