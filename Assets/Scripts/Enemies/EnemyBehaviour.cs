using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] internal EnemyData data;
    
    private GameObject target;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D enemyRB;
    private float attackTimer = 0f;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyRB = GetComponent<Rigidbody2D>();

        spriteRenderer.sprite = data.enemySprite;

        target = data.GetTarget();
    }

    void Update()
    {
        MoveToTarget(target, data.speed);
        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0)
        {
            AttackPlayer(target, data.enemyType);
        }
    }

    private void MoveToTarget(GameObject target, float speed)
    {
        speed /= 10;
        enemyRB.linearVelocity = Vector2.zero;

        Vector2 direction = target.transform.position - transform.position;
        direction.Normalize();
        Vector2 targetPosition = (Vector2)transform.position + (direction * speed);

        enemyRB.MovePosition(targetPosition);
    }

    private void AttackPlayer(GameObject player, EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Meelee:
                if (Vector2.Distance(player.transform.position, transform.position) < data.attackDistance) {
                    player.GetComponent<PlayerBehaviour>().UpdateHealth(data.damage);
                    attackTimer = data.attackCooldown;
                }
                break;
        }
    }
}
