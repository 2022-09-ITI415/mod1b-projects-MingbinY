using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GunController : MonoBehaviour
{
    public Gun startingGun;
    public Transform weaponHoldTransform;
    bool shootInput;
    public Player inputActions;
    Gun equippedGun;

    public List<Gun> gunList;
    public Gun prevGun;
    public Gun nextGun;

    bool nextGunInput;
    bool prevGunInput;
    public int currentWeaponIndex;

    private void Start()
    {
        inputActions = FindObjectOfType<PlayerController>().inputActions;
        currentWeaponIndex = 0;
        if (gunList[currentWeaponIndex] != null)
        {
            EquipGun(gunList[currentWeaponIndex]);
        }
    }

    private void Update()
    {
        HandleShoot();
    }

    public void HandleShoot()
    {
        //inputActions.Action.Shoot.performed += i => shootInput = true;
        shootInput = inputActions.Action.Shoot.IsPressed();
        if (shootInput)
        {
            equippedGun.Shoot();
            shootInput = false;
        }
    }

    public void HandleChangeWeapon()
    {
        inputActions.Action.NextGun.performed += i => nextGunInput = true;
        inputActions.Action.PrevGun.performed += i => prevGunInput = true;

        if (nextGunInput)
        {
            EquipGun(nextGun);
            return;
        }

        if (prevGunInput)
        {
            EquipGun(prevGun);
            return;
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
        UpdateGunUI();
    }

    void UpdateGunUI()
    {
        int currentGunIndex = gunList.IndexOf(equippedGun);
        int nextGunIndex = currentGunIndex;
        int prevGunIndex = currentGunIndex;

        //Set next gun index
        if (currentGunIndex == gunList.Count - 1)
        {
            nextGunIndex = 0;
        }
        else
        {
            nextGunIndex = currentGunIndex + 1;
        }

        //Set prev gun index
        if (currentGunIndex == 0)
        {
            prevGunIndex = gunList.Count - 1;
        }
        else
        {
            prevGunIndex = currentGunIndex - 1;
        }

        Debug.Log(currentGunIndex);
        Debug.Log(nextGunIndex);
        Debug.Log(prevGunIndex);
        //Set gun obj
        nextGun = gunList[nextGunIndex];
        prevGun = gunList[prevGunIndex];


    }
}
