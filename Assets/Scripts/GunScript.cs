using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 20f;
    public float range = 100f;

    public float impactForce = 30f;
    public GameObject muzzleFlash;
    public Transform muzzleFlashPosition;

    public GameObject impactEffect;

    public Camera fpsCam;

    void Update()
    {
         if (Time.timeScale == 0f) return; 

            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
    }

    void Shoot()
    {
        // Muzzle flash
       GameObject flash = Instantiate(muzzleFlash, muzzleFlashPosition.position, muzzleFlashPosition.rotation);
        Destroy(flash, 0.05f);

        // Raycast for hit detection
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out RaycastHit hit, range))
        {
            Debug.Log(hit.transform.name);

            Target_script target = hit.transform.GetComponent<Target_script>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            if (hit.rigidbody != null){
                Debug.Log("hit rigid body");
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
