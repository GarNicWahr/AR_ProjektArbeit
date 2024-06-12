using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AR_PlayerController : MonoBehaviour
{
    public Transform Target;
    public LayerMask LayerMask;

    private NavMeshAgent _agent;
    private Camera _rayCamera;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            _rayCamera = Camera.main;
            Touch touch = Input.GetTouch(0);
            Ray ray = _rayCamera.ScreenPointToRay(touch.position);
            if(Physics.Raycast(ray, out RaycastHit raycastHit,LayerMask))
            {
                Target.position = raycastHit.point;
                _agent.SetDestination(Target.position);
            }

        }
    }
}
