using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform Target;
    float Offest = 1.7f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(transform.position + cam.rotation * Vector3.forward, cam.rotation * Vector3.up);
        this.transform.position = Target.position + new Vector3(0, Offest, 0);
        transform.LookAt(Camera.main.transform);
    }
}
