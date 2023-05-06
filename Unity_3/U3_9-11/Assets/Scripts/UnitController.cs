using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    private RaycastHit hit;
    private MySelectable ms;
    
    public float Health { get; set; }
    public float Damage { get; set; }
    
    public static float Delay = 0.5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        ms = GetComponent<MySelectable>();

        Health = 500;
        Damage = 100;
    }

    void Update()
    {
        Moving();
    }

    private void Moving()
    {
        foreach (var item in MySelectable.allMySelectables)
        {
            if (ms.selected)
            {
                anim.SetFloat("Running", agent.remainingDistance);
                if (Input.GetMouseButtonDown(0))
                {
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                    {
                        agent.destination = hit.point;
                    }
                }
            }
            else
            {
                anim.SetFloat("Running", 0f);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            agent.destination = collision.gameObject.transform.position;
            anim.SetBool("Attack", true);
            StartCoroutine(Attack(collision));
        }
    }

    IEnumerator Attack(Collider coll)
    {
        while (coll != null && coll.GetComponent<EnemyController>().Health > 0)
        {
            transform.LookAt(coll.transform);
            coll.GetComponent<EnemyController>().Health -= Damage;
            yield return new WaitForSeconds(Delay * 3f);
        }

        anim.SetBool("Attack", false);
        if (coll != null)
        {
            Destroy(coll.gameObject, Delay);
        }
    }
}
