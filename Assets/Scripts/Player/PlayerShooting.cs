﻿using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;


namespace CompleteProject
{

    public class PlayerShooting : MonoBehaviour
    {

        public int gun = 1;
        private GunScript script;
        private float timer = 0f;                                    // A timer to determine when to fire.


        // Use this for initialization
        void Start()
        {
            script = GetComponent("Gun" + gun + "Script") as GunScript;
            script.SwitchIn();
        }

        void Update()
        {
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;

#if !MOBILE_INPUT
            // If the Fire1 button is being press and it's time to fire...
            if (Input.GetButton("Fire1"))
            {
                // ... shoot the gun.
                script.Shoot(timer, this);
                // Reset the timer.

            }
#else
            // If there is input on the shoot direction stick and it's time to fire...
            if ((CrossPlatformInputManager.GetAxisRaw("Mouse X") != 0 || CrossPlatformInputManager.GetAxisRaw("Mouse Y") != 0) && timer >= timeBetweenBullets)
            {
                // ... shoot the gun
                Shoot();
            }
#endif
            //Switch gun
            if (Input.GetKeyDown("1"))
            {
                Switch(1);
            }
            if (Input.GetKeyDown("2"))
            {
                Switch(2);
            }
            if (Input.GetKeyDown("3"))
            {
                Switch(3);
            }
            if (Input.GetKeyDown("4"))
            {
                Switch(4);
            }
        }

        public void DisableEffects()
        {
            script.DisableEffects();
        }

        public void ResetTimer()
        {
            timer = 0f;
        }

        private void Switch(int newgun)
        {

            script.SwitchOut();
            script = GetComponent("Gun" + newgun + "Script") as GunScript;
            script.SwitchIn();
        }
    }

}