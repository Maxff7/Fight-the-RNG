using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D playerRB;

    [SerializeField] private float playerSpeed = 1.2f;

    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        MovePlayer(playerSpeed);
    }

    private void MovePlayer(float speed)
    {
        speed /= 10;
        Vector2 direction = Vector2.zero;
        playerRB.linearVelocity = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction.y -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction.x += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction.x -= 1;
        }

        direction.Normalize();
        Vector2 targetPosition = (Vector2)transform.position + (direction * speed);
        playerRB.MovePosition(targetPosition);
    }

    internal void UpdateHealth(float amount, bool damage = true)
    {
        currentHealth -= (damage ? 1 : -1) * amount;
        Debug.Log(currentHealth);
    }
}
