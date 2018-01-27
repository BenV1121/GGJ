using UnityEngine;

namespace CompleteProject
{
    public class RetroAttack : EnemyAttack
    {
        public Transform bullet;

        override protected void Attack ()
        {
            // Reset the timer.
            timer = 0f;

            // If the player has health to lose...
            if(playerHealth.currentHealth > 0)
            {
                var angle = this.GetComponent<Transform>().rotation;
                var shot = Instantiate(bullet, GetComponent<Transform>().position, angle);
                shot.GetComponent<Rigidbody>().velocity = angle * new Vector3(0, 0, 30);
            }
        }
    }
}