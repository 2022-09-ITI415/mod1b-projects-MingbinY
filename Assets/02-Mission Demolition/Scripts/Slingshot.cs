using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject launchPoint;
    public GameObject prefabProjectile;

    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;

    public float velocityMultyplier = 8f;
    private Rigidbody projectileRb;

    private void Awake()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }

    private void Update()
    {
        if (!aimingMode)
            return;

        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 mouseDelta = mousePos3D - launchPos;

        float maxMagnitude = GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        Vector3 projectPos = launchPos + mouseDelta;
        projectile.transform.position = projectPos;

        if (Input.GetMouseButtonUp(0))
        {
            aimingMode = false;
            projectileRb.isKinematic = false;
            projectileRb.velocity = -mouseDelta * velocityMultyplier;
            projectile = null;
        }
    }

    private void OnMouseEnter()
    {
        Debug.Log("Slingshot.OnMouseEnter()");
        launchPoint.SetActive(true);
    }

    private void OnMouseExit()
    {
        Debug.Log("Slingshot.OnMouseExit()");
        launchPoint.SetActive(false);
    }

    private void OnMouseDown()
    {
        aimingMode = true;

        projectile = Instantiate(prefabProjectile);

        projectile.transform.position = launchPos;

        projectileRb = projectile.GetComponent<Rigidbody>();
        projectileRb.isKinematic = true;
    }

}
