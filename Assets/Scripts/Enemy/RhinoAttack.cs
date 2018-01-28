using UnityEngine;

public class RhinoAttack : EnemyAttack
{
    override protected void Attack()
    {
        // Reset the timer.
        timer = 0f;

        // If the player has health to lose...
        if (playerHealth.lives > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage();
        }
    }
}