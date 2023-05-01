using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class UnitController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;
    private RaycastHit _hit;
    private MySelectable _mySelectable;
    
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        _mySelectable = GetComponent<MySelectable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Moving()
    {
        foreach (var item in MySelectable.allMySelectables)
        {
            if (_mySelectable.selected)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hit, 100))
                    {
                        _agent.destination = _hit.point;
                    }
                }
            }
            
        }
    }
}
