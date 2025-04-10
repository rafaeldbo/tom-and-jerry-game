using UnityEngine;

public class EnemyMoviment : MonoBehaviour {
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Transform player;
    public float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (player.position.x < transform.position.x) spriteRenderer.flipX = true;  
        else spriteRenderer.flipX = false;
    }
}
