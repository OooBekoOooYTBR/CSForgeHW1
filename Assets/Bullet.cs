using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float trg = 0f;
    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(10);
        }
        Destroy(gameObject);
        if(other.CompareTag("Player"))
        {
            if(trg < Time.time)
            {
                trg = Time.time + 1f;
                UIM.instance.hpdwn(5);
            }
        }
    }
}