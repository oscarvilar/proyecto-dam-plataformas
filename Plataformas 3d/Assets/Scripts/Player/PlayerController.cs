using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float runSpeed = 6;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    Animator animator;
    Transform cameraT;
    Rigidbody rb;
    public float jumpHeigth;
    public bool isGrounded;
    private const int JUMPS = 2;
    private int current_jumps;
    bool can_dash;
  
    void Start()
    {
        animator = GetComponent<Animator>();
        cameraT = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
        can_dash = true;
        //animator.SetBool("Grounded", true);
    }

    void Update()
    {
        /*---------------- CALCULAR DIRECCION ---------------------*/
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); // input (x,y)

        Vector2 inputDir = input.normalized; // el vector tiene la misma direccion pero la magnitude(distancia) es de 1
        
        if (inputDir != Vector2.zero)// para que no vuelva a mirar en la posicion inicial
        {
            // target rotation = devuelve angulo input x,y en rad ,se convierte a grados + rotacion Y de la camara
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        }
        /*FIN CALCULAR DIRECCION */



        /*--------------MOVIENTO------------------------------------*/
        float speed = runSpeed * inputDir.magnitude;
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

        /*FIN MOVIMIENTO*/


        /*----------------ANIMACIONES--------------------------------*/
        if (speed > 0.1)
        {
            animator.SetBool("move", true);
        }

       if(speed == 0)
        {
            animator.SetBool("move", false);
        }
        /*FIN ANIMACIONES*/




        /*********************** SALTO ***********************************/

        if (Input.GetButtonDown("A") && (isGrounded == true || current_jumps<JUMPS))
        {
            rb.AddForce(0, jumpHeigth, 0);
            current_jumps++;
            isGrounded = false;
            animator.SetTrigger("Jump");

        }

        if (Input.GetButtonDown("B") && isGrounded == false && can_dash == true)
        {
            can_dash = false;
            Debug.Log("b");
            runSpeed = 15f;
        }



    }//FIN UPDATE
    


    private void OnCollisionEnter()
    {
        isGrounded = true;
        current_jumps = 0;
        runSpeed = 6f;
        can_dash = true;
        //animator.SetBool("Grounded", true);
    }
}

