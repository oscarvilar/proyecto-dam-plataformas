using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    public bool lockCursor;

    float yaw;
    float pitch;

    public float sensibility = 10;          //sensibilidad camara
    public Transform target;                //objetivo de la camara
    public float distanceFromTarget = 2;    //distancia de la camara al objetivo
    public float pitchMin = -40;            //max y min de la rotacion vertical de la camara
    public float pitchMax = 85;

    public float rotationSmoothTime = 0.1f; //suavizar la rotacion
    Vector3 rotationSmoothVelocity;         
    Vector3 currentRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   //bloquear raton
        Cursor.visible = false;                     //esconder raton
    }

    void LateUpdate () {
        //MANDO
        //yaw += Input.GetAxis("RightStickHorizontal")* sensibility;//eje horizontal
        //pitch -= Input.GetAxis("RightStickVertical") * sensibility;//eje vertical(invertido)

        //RATON
        yaw += Input.GetAxis("Mouse X") * sensibility;//eje horizontal
        pitch -= Input.GetAxis("Mouse Y") * sensibility;//eje vertical(invertido)


        pitch = Mathf.Clamp(pitch,pitchMin, pitchMax);             //ponerle a un valor un max y un min

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;

        transform.position = target.position - transform.forward * distanceFromTarget; // posicion de la camara
    }
}
