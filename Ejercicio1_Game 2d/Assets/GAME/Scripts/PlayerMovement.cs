using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float moveX;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        moveX = ReadHorizontal();

        // Voltear el sprite según la dirección
        if (moveX > 0) sr.flipX = false;
        else if (moveX < 0) sr.flipX = true;
    }

    void FixedUpdate()
    {
        // Solo se mueve en el eje X; la velocidad en Y la maneja la gravedad
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);
    }

    float ReadHorizontal()
    {
#if ENABLE_INPUT_SYSTEM
        var kb = Keyboard.current;
        if (kb == null) return 0f;
        float x = 0f;
        if (kb.aKey.isPressed || kb.leftArrowKey.isPressed) x -= 1f;
        if (kb.dKey.isPressed || kb.rightArrowKey.isPressed) x += 1f;
        return x;
#else
        return Input.GetAxisRaw("Horizontal");
#endif
    }
}
