using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
public class Projectile : MonoBehaviour
{

    
    public float speed = 10f;
    private Vector3 direction;
    private ShootPool Shootpool; 

    void OnEnable()
    {
        Invoke("spawnTime", 4f);
    }

    public void StartProjectile(Vector3 direction, ShootPool shooter)
    {
        this.direction = direction;
        this.Shootpool = shooter;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    void OnCollisionEnter(Collision colision)
    {
        CancelInvoke("spawnTime");
    
    Shootpool.ReturnProjectile(gameObject);
    }
    void spawnTime()
    {
        Shootpool.ReturnProjectile(gameObject);
    }
}
