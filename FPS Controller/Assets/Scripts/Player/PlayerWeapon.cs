using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] MachineGunItem weapon;

    // Update is called once per frame
    void Update()
    {
        //Check if player is pressing fire button
        if(Input.GetMouseButtonDown(0)) {
            //If true, try to fire weapon
            IWeapon canShoot = weapon.GetComponent<IWeapon>();
            if (canShoot != null) {
                if (weapon.currentAmmo > 0){
                weapon.Fire();
                }
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            weapon.StopFiring();
        }    
    }
}
