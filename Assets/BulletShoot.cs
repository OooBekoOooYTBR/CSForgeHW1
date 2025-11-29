using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject b = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
            b.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
        }
    }
}