using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject enemyPrefab;
    public GameObject chara;
    public int health = 100;
    private float trg = 0f;
    private int speed = 2;
    private UIM uiManager;
    private EnemyBulletSpawn ebs;
    private void Start()
    {
        chara = GameObject.FindWithTag("Player");
        ebs = GetComponent<EnemyBulletSpawn>();
        Debug.Log("ebs initialize: " + (ebs != null));
        
        //uiManager = FindAnyObjectByType<UIManager>();
        //Instantiate(bulletPrefab, transform.position + Vector3.up * 3, Quaternion.identity);
    }

    private void LateUpdate()
    {
        /*if(chara != null && Vector3.Distance(transform.position, chara.transform.position) > 10f)
        {
            if (ebs != null)
            if(trg < Time.time)
                {
                    trg = Time.time + 2f;
                    transform.LookAt(chara.transform);
                    ebs.EnBS();
                } 
        } else if (chara != null && Vector3.Distance(transform.position, chara.transform.position) > 0.5f)
        {
            transform.LookAt(chara.transform);
            transform.position += transform.forward * Time.deltaTime * speed;
        }*/
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            EnemyM.instance.RemoveEnemy();
            UIM.instance.AddScore(1);
            Destroy(gameObject);
        }
    }
    public void OnTriggerStay(Collider other)
    {
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