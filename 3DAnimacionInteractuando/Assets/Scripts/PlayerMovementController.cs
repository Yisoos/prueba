using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    // Variables para el movimiento del jugador
    [Header("Movimiento")]
    [Range(0, 10)] public float speed = 5.0f; // Velocidad de movimiento del jugador
    [Range(0, 100)] public int pushSpeedDecrease; // Reducción de velocidad al empujar objetos
    [Range(0, 200)] public float rotationSpeed = 100.0f; // Velocidad de rotación
    [Range(0, 100)] public float jumpForce = 40; // Fuerza del salto

    // Variables para la interacción con el mundo
    [Header("Interacción con el mundo")]
    public Transform pushCheck; // Posición donde se verifican los objetos (asignable en el Inspector)
    [Range(0, 5)] public float radius = 5f; // Radio de interacción con objetos
    public Transform FloorCheck;

    private Animator animator; // Referencia al componente Animator para controlar las animaciones

    private float spin, x, z; // Variables para controlar la rotación y el movimiento en los ejes
    [HideInInspector] public bool isPushing; // Bandera que indica si el jugador está empujando un objeto
    [HideInInspector] public bool isJumping = false;

    private Rigidbody rb; // Referencia al componente Rigidbody para aplicar la física

    // Método de inicialización
    private void Start()
    {
        // Obtener las referencias a los componentes de Animator y Rigidbody
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Método que se ejecuta cada frame
    void Update()
    {
        Walking(); // Controla el movimiento del jugador
        StartCoroutine(Jumping()); // Controla el salto del jugador
        Pushing(); // Controla la acción de empujar objetos
    }

    // Método que se ejecuta en cada FixedUpdate (frame físico)
    private void FixedUpdate()
    {
        // Desactivar la animación de salto cuando el salto ha terminado
        animator.SetBool("Jumping", false);
    }

    // Método para controlar el movimiento del jugador
    public void Walking()
    {
        // Obtener la entrada del usuario para la rotación y el movimiento
        spin = Input.GetAxis("Spin"); // Rotación del jugador
        x = Input.GetAxis("Horizontal"); // Movimiento en el eje X (izquierda/derecha)
        z = Input.GetAxis("Vertical"); // Movimiento en el eje Z (adelante/atrás)

        // Actualizar los valores en el Animator para controlar las animaciones
        animator.SetFloat("SpeedX", !isPushing ? x : 0); // Si está empujando, no mueve en X
        animator.SetFloat("SpeedZ", z); // Movimiento en el eje Z

        // Rotar el jugador
        transform.Rotate(0, spin * Time.deltaTime * rotationSpeed, 0);

        // Mover el jugador
        transform.Translate((!isPushing ? x : 0) * Time.deltaTime * speed, 0, z * Time.deltaTime * (!isPushing ? speed : speed * (1 - pushSpeedDecrease / 100.0f)));
    }

    // Método para controlar el salto del jugador
    public IEnumerator Jumping()
    {
        // Verificar si se ha presionado el botón de salto y si no está empujando
        if (Input.GetButtonDown("Jump") && Mathf.Approximately(rb.velocity.y, 0) && !isJumping && !isPushing)
        {
            isJumping = true;
            animator.SetBool("Jumping", true);
            yield return new WaitForSeconds(.2f);
            rb.AddForce(Vector3.up * (jumpForce/5), ForceMode.Impulse);
            Debug.Log("Jump force applied! Y velocity before jump: " + rb.velocity.y);
            isJumping = false;
        }

        else
        {
            Debug.Log("No se encontraron colliders dentro del rango."); // Imprimir si no hay objetos para interactuar
        }
    }

    // Método para controlar la acción de empujar objetos
    public void Pushing()
    {
        // Detectar interacción con los objetos frente al jugador
        DetectInteractionFormFront();

        // Terminar de empujar cuando se suelta el botón de empuje
        if (Input.GetButtonUp("Push"))
        {
            animator.SetBool("Pushing", false); // Desactivar animación de empuje
            isPushing = false; // Dejar de empujar
        }
    }

    // Método para detectar objetos frente al jugador
    public void DetectInteractionFormFront()
    {
        // Realizar la comprobación de OverlapSphere para detectar objetos dentro del radio de interacción
        Collider[] hitColliders = Physics.OverlapSphere(pushCheck.position, radius);

        // Si hay objetos dentro del rango, los imprimimos en la consola
        if (hitColliders.Length > 0)
        {
            foreach (Collider hitCollider in hitColliders)
            {
                Debug.Log("Objeto detectado: " + hitCollider.gameObject.name); // Imprimir el nombre del objeto detectado

                // Obtener componentes de empuje de los objetos detectados
                PushingObject pushingObject = hitCollider.transform.GetComponent<PushingObject>();
                PushingParent pushingParent = hitCollider.transform.GetComponent<PushingParent>();

                // Si el objeto tiene un componente PushingParent, interactuar con él
                if (pushingParent != null)
                {
                    pushingParent.PushObject(this, pushCheck);
                }

                // Si el objeto tiene un componente de empuje o PushingParent, permitir empujarlo
                if (pushingObject != null || pushingParent != null)
                {
                    if (Input.GetButtonDown("Push"))
                    {
                        animator.SetBool("Pushing", true); // Activar animación de empuje
                        isPushing = true; // El jugador está empujando
                        // animator.SetTrigger("InteruptEmote"); // Puede descomentar si se desea interrumpir la animación de emoción
                    }
                }
            }
        }
        else
        {
            Debug.Log("No se encontraron colliders dentro del rango."); // Imprimir si no hay objetos para interactuar
        }
    }
}
