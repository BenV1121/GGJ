using UnityEngine;

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

            Vector3 dir = player.transform.position - transform.position;
            dir = player.transform.InverseTransformDirection(dir);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            var rot = Quaternion.AngleAxis(angle, Vector3.up);

            /*
var shot = Instantiate(bullet, GetComponent<Transform>().position, Vector3.forward);
shot.rotation = rot;
shot.GetComponent<Rigidbody>().velocity = angle * new Vector3(0, 0, 30);

*/
            var shot = Instantiate(bullet, new Vector3(transform.position.x, 0.5f, transform.position.z-3), new Quaternion());
            shot.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -15);
        }
    }
}