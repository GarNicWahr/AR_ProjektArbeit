using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AR_PlayerController : MonoBehaviour
{
    public Transform Target;
    public LayerMask LayerMask;
    public bool CanMove;

    private NavMeshAgent _agent;
    private Camera _rayCamera;
    private Animator _animator;

    private bool _wasMoving;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        MovementRestriction(true);
        _wasMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Set Destination for Player and play animation
        if (Input.touchCount == 1 && CanMove)
        {
            _rayCamera = Camera.main;
            Touch touch = Input.GetTouch(0);
            Ray ray = _rayCamera.ScreenPointToRay(touch.position);
            if(Physics.Raycast(ray, out RaycastHit raycastHit,LayerMask))
            {
                Target.position = raycastHit.point;
                _agent.SetDestination(Target.position);
            }
            _animator.SetBool("isWalking", true);
            _wasMoving = true;
        }

        // Check if Player stopped Movement and go back to idle animation
        if(_agent.isStopped && _wasMoving)
        {
            _animator.SetBool("isWalking", false);
            _wasMoving = false;
        }
    }

    // Restict Player movement for animation and interaction
    public void MovementRestriction(bool movementRes)
    {
        if(movementRes)
        {
            CanMove = true;
        }
        else
        {
            CanMove = false;
        }
    }
}
