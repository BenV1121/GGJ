using UnityEngine;

public class BulletAttack : EnemyAttack
{
    override protected void Attack()
    {
        // Reset the timer.
        timer = 0f;

        // If the player has health to lose...
        if (playerHealth.lives > 0)
        {
            //IMPACT ANIMATION
            // ... damage the player.
            //TODO: playerHealth.TakeDamage(attackDamage);
        }
    }
}