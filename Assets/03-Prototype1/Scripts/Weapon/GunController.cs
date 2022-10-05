using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Gun startingGun;
    public Transform weaponHoldTransform;
    bool shootInput;
    public Player inputActions;
    Gun equippedGun;

    private void Start()
    {
        inputActions = FindObjectOfType<PlayerController>().inputActions;
        if (startingGun != null)
        {
            EquipGun(startingGun);
        }
    }

    private void Update()
    {
        HandleShoot();
    }

    public void HandleShoot()
    {
        inputActions.Movement.Jump.performed += i => shootInput = true;
        if (shootInput)
        {
            equippedGun.Shoot();
            shootInput = false;
        }
    }

    public void EquipGun(Gun gunToEquip)
    {
        if (equippedGun)
        {
            Destroy(equippedGun.gameObject);
        }

        equippedGun = Instantiate(gunToEquip, weaponHoldTransform.position, weaponHoldTransform.rotation) as Gun;
        equippedGun.transform.parent = weaponHoldTransform;
    }
}
