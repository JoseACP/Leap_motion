using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float groundFriction = 5f;

    private Rigidbody rb;
    private bool isJumping = false;

    // Start is called before the first frame update
   void Start()
    {
         rb = GetComponent<Rigidbody>();
    
    }

    // Update is called once per frame
    void Update()
    {
       // Obtener las entradas de teclado para el movimiento horizontal y vertical
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular el vector de movimiento
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed;

        // Aplicar la fuerza al Rigidbody para el movimiento
        rb.AddForce(movement);

        // Aplicar fricción horizontal cuando no se presionan las teclas de movimiento
        if (Mathf.Approximately(horizontalInput, 0f))
        {
            ApplyGroundFriction();
        }

        // Verificar si se presionó la tecla de salto y no está en el aire
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Jump();
        }
    }

    private void Jump()
    {
        // Aplicar una fuerza vertical al Rigidbody para el salto
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isJumping = true;
    }

    private void ApplyGroundFriction()
    {
        // Calcular la fricción opuesta al movimiento horizontal
        Vector3 friction = -rb.velocity.normalized * groundFriction;

        // Aplicar la fricción al Rigidbody
        rb.AddForce(friction, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si ha aterrizado en el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }


}
