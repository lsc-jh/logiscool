using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    private Transform unit;
    
    public float Health { get; set; }
    public float Damage { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        Health = 500;
        Damage = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (MySelectable.allMySelectables.Count > 0)
        {
            if (unit != null && Vector3.Distance(transform.position, unit.position) < 15)
            {
                transform.LookAt(unit);
                if (Vector3.Distance(transform.position, unit.position) > 1.5f)
                {
                    transform.position += transform.forward * agent.speed * Time.deltaTime;
                }
                anim.SetFloat("Running", agent.speed);
            }
            else
            {
                unit = MySelectable.allMySelectables[Random.Range(0, MySelectable.allMySelectables.Count)].transform;
            }
        }
        else
        {
            anim.SetFloat("Running", 0f);
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
        while (coll != null && coll.GetComponent<UnitController>().Health > 0) // UNITCONTOLLER
        {
            transform.LookAt(coll.transform);
            coll.GetComponent<UnitController>().Health -= Damage; // UNITCONTROLLER
            yield return new WaitForSeconds(UnitController.Delay * 3f);
        }

        anim.SetBool("Attack", false);
        if (coll != null)
        {
            Destroy(coll.gameObject, UnitController.Delay);
            for (var i = 0; i < MySelectable.allMySelectables.Count; i++)
            {
                if (Vector3.Distance(transform.position, coll.transform.position) < 5)
                {
                    MySelectable.allMySelectables.Remove(coll.gameObject.GetComponent<MySelectable>());
                    MySelectable.currentlySelected.Remove(coll.gameObject.GetComponent<MySelectable>());
                }
            }
        }
    }
}
