using UnityEngine;

public class EnemyBulletSpawn : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    private void Start()
    {
        if (bulletSpawn == null)
        {
            bulletSpawn = transform.Find("enmyblt");
            Debug.Log("enmyblt bulundu: " + (bulletSpawn != null));
        } 
        if (bulletSpawn == null)
        {
            bulletSpawn = this.transform;
            Debug.Log("Kendi transform kullanılıyor");
        }   
    }

    public void EnBS()
    {
        Debug.Log("EnBS() çağrıldı!");
        Debug.Log("bulletPrefab: " + bulletPrefab);
        Debug.Log("bulletSpawn: " + bulletSpawn);
        
        if (bulletPrefab != null && bulletSpawn != null)
        {   
            GameObject b = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
            Rigidbody rb = b.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddForce(transform.forward * 500);
                Debug.Log("Bullet fırlatıldı!");
            }
            else
            {
                Debug.LogError("Bullet prefab'ında Rigidbody yok!");
            }
        }
        else
        {
            Debug.LogError("bulletPrefab veya bulletSpawn null!");
        }
    }
}
