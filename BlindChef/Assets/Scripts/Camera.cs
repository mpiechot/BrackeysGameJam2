using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform Target;
    public float DampingRate;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (Target == null)
            return;

        transform.position = Vector3.Lerp(transform.position, Target.position + Vector3.back, DampingRate);

    }
}
