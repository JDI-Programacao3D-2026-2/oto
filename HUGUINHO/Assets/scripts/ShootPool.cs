using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.InputSystem;

public class ShootPool : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public int poolSize = 10;
    public int currentAmmo;
    public int activeProjectiles = 0;
    private ObjectPool<GameObject> pool;

    private void Awake()
    {
        currentAmmo = poolSize;

        pool = new ObjectPool<GameObject>(
            () => Instantiate(projectilePrefab), projectile => projectile.SetActive(true),
            projectile => projectile.SetActive(false),
            projectile => Destroy(projectile),
            false,
            poolSize,
            poolSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        if (currentAmmo <= 0 || activeProjectiles >= poolSize) return;

        GameObject projectile = pool.Get();

        currentAmmo--;
        activeProjectiles++;
        projectile.transform.SetLocalPositionAndRotation(firePoint.position, firePoint.rotation);
        projectile.GetComponent<Projectile>().StartProjectile(firePoint.forward, this);

    }
    public void ReturnProjectile(GameObject projectile)
    {
        activeProjectiles--;
        pool.Release(projectile);
    }

}


