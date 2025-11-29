using UnityEngine;

internal enum EnemyType
{
    Meelee,
    Ranged
}

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    // Info
    [Header("Info")]
    [SerializeField] internal string enemyName = "Name";
    [SerializeField] internal Sprite enemySprite;
    [SerializeField] internal EnemyType enemyType;
    [SerializeField] internal Sprite weaponSprite;

    // Stats
    [Header("Stats")]
    [SerializeField] internal float hitPoints = 5f;
    [SerializeField] internal float speed = 1f;

    [Header("Attack Stats")]
    [SerializeField] internal float damage = 5f;
    [SerializeField] internal float attackCooldown = 1f;
    [SerializeField] internal float attackDistance = 1f;


    internal virtual GameObject GetTarget()
    {
        switch (enemyType)
        {
            case EnemyType.Meelee:
                return GameObject.FindGameObjectWithTag("Player");
            case EnemyType.Ranged:
                return GameObject.FindGameObjectWithTag("Player");
        }

        return GameObject.FindGameObjectWithTag("Player");
    }
}
