using UnityEngine;

public class BulletAttack : EnemyAttack
{
    void OnEnable()
    {
        Invoke("Destroy", 2f);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(0, 1 * Time.deltaTime, 0);
    }

    override protected void Attack()
    {
        // Reset the timer.
        timer = 0f;

        // If the player has health to lose...
        if (playerHealth.lives > 0)
        {
            playerHealth.TakeDamage();
        }
    }
}