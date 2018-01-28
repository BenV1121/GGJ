using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunScript : MonoBehaviour
{

    //Shoot
    public abstract void Shoot(float timer, PlayerShooting shootingControl);

    //Effect end
    public abstract void DisableEffects();

    //Switch (needs to be called before shoot)
    public abstract void SwitchIn();

    public abstract void SwitchOut();
}
