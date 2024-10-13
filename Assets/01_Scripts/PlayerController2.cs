using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed = 4f; // Velocidad de movimiento de Nova
    public float jumpForce = 7f; // Fuerza de salto
    public Rigidbody2D rb; // Referencia al Rigidbody2D para aplicar físicas
    public Animator animator; // Referencia al Animator para controlar las animaciones
    public bool canJump = true; // Controla si puede saltar


    private void Start()
    {
        animator.SetBool("Grounded", true);
    }

    void Update()
    {
        Movement();
        Mirror();
        Jump2();
        Attack();
        animator.SetFloat("FallingSpeed", rb.velocity.y);
    }

    void Movement()
    {
        float x = Input.GetAxis("Horizontal2"); // Usando un eje personalizado "Horizontal2" para el segundo jugador
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(x));
    }

    void Mirror()
    {
        if (rb.velocity.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (rb.velocity.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void Jump2()
    {
        if (canJump)
        {
            if (Input.GetKeyDown(KeyCode.I)) // Usando la tecla de flecha hacia arriba para saltar
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                canJump = false;
                animator.SetBool("Grounded", false);
            }
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            animator.SetTrigger("Attack");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            animator.SetBool("Grounded", true);
        }
    }
}
