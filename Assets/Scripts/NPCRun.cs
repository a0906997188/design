using UnityEngine;
using Unity.AI;
using UnityEngine.AI;
public class NPCRun : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public Transform target;
    public float distination = 0;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        distination = Vector3.Distance(target.position, transform.position);

        if (target != null && distination >= 10)
        {
            agent.SetDestination(target.position);
        }
        
        if(distination >=2)
        {
            anim.SetBool("isWalk", true);
        }
        else
        {
            anim.SetBool("isWalk", false);
        }


    }
}
