using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float speedH;
    public float speedV;

    float  yaw;
    float pitch;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedH = Input.GetAxis("Mouse X");// Obtener el desplazamiento del mouse
        pitch -= speedV = Input.GetAxis("Mouse Y");// Obtener el desplazamiento del mouse

        transform.eulerAngles = new Vector3(pitch, yaw, 0.8f);
        
    }
}
