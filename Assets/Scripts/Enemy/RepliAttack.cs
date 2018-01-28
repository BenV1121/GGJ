﻿using UnityEngine;

public class RepliAttack : EnemyAttack
{
    public Transform bullet;

    override protected void Attack()
    {
        // Reset the timer.
        timer = 0f;

        // If the player has health to lose...
        if (playerHealth.lives > 0)
        {
            var angle = this.transform.rotation;
            Vector3 dir = (this.transform.position - player.transform.position).normalized;
            var shot = Instantiate(bullet, GetComponent<Transform>().position, angle);
            shot.GetComponent<Rigidbody>().velocity = angle * new Vector3(0, 0, 30);
        }
    }
}