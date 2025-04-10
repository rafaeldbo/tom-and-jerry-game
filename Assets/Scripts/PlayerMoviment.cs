using UnityEngine;

public class PlayerMoviment : MonoBehaviour {
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        animator.SetBool("walking", movement.magnitude != 0);
        rb.MovePosition(rb.position + speed * movement.normalized * Time.fixedDeltaTime);


        if (moveHorizontal < 0) spriteRenderer.flipX = false; 
        else if (moveHorizontal > 0) spriteRenderer.flipX = true;
    }
}
