using UnityEngine;

public class RaycastGun : MonoBehaviour
{
    [Header("Gun Settings")]
    public float fireRate = 5f;
    public float range = 100f;
    public float damage = 10f;

    [Header("Effects")]
    public GameObject impactEffect;
    public LayerMask hitLayers;

    private float nextTimeToFire = 0f;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        if (Physics.Raycast(ray, out RaycastHit hit, range, hitLayers))
        {
            Debug.Log("Hit: " + hit.collider.name);

            if (impactEffect != null)
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            if (hit.collider.TryGetComponent<IDamageable>(out var target))
            {
                target.TakeDamage(damage);
            }
        }
    }
}
