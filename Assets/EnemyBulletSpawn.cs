using UnityEngine;
using UnityEngine.UI;

public class EnemyBulletSpawn : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public AudioSource audioSrc;
    private void Start()
    {
        if (bulletSpawn == null)
        {
            bulletSpawn = transform.Find("enmyblt");
        } 
        if (bulletSpawn == null)
        {
            bulletSpawn = this.transform;
        }   
        if (audioSrc == null)
        {
            audioSrc = GetComponent<AudioSource>();
        }
    }

    public void EnBS()
    {
        
        if (bulletPrefab != null && bulletSpawn != null)
        {   
            GameObject b = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
            Rigidbody rb = b.GetComponent<Rigidbody>();
            audioSrc.Play();
            if(rb != null)
            {
                rb.AddForce(transform.forward * 500);
            }
        }
    }
}
