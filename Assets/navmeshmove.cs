using TreeEditor;
using UnityEngine;
using UnityEngine.AI;

public class navmeshmove : MonoBehaviour
{
    public Transform target;
    public float btdistance = 10.0f;
    private NavMeshAgent agent;
    private float dist;
    private EnemyBulletSpawn ebs;
    private float trg = 0f, speed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
        target = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        ebs = GetComponent<EnemyBulletSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(agent.transform.position, target.position);
        if(dist < btdistance)
        {
            agent.isStopped = true;
        } else 
        {
            agent.isStopped = false;
            agent.destination = target.position;
        }
    }
    void LateUpdate()
    {
        if(!agent.isStopped)
        {
            if(target != null && Vector3.Distance(transform.position, target.position) >= 10f)
            {
                if (ebs != null) {
                    if(trg < Time.time)
                    {
                        trg = Time.time + 1f;
                        transform.LookAt(target.transform);
                        ebs.EnBS();
                    } 
                }
            } else if (target != null && Vector3.Distance(transform.position, target.position) > 0.5f)
            {
            transform.LookAt(target.transform);
            transform.position += transform.forward * Time.deltaTime * speed;
            }
        }

    }
}
