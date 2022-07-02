using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]private Transform myTransform;
    [SerializeField]private Transform target;
    public float offsetZ = -15f;
    public float offsetX = -5f;
    public float constantY = 5f;
    public float cameraLerpTime = 0.01f;
   


    void FixedUpdate()
    {
        if (target)
        {
            Vector3 targetPosition = new Vector3(target.position.x + offsetX, constantY, target.position.z + offsetZ);
            transform.position = Vector3.Lerp(transform.position, targetPosition, cameraLerpTime);
        }
    }
}
