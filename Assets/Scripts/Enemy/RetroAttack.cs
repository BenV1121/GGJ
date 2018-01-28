using UnityEngine;

public class RetroAttack : EnemyAttack
{
    public Transform bullet;

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