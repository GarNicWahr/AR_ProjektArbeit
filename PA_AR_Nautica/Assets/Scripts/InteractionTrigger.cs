using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{

    public Transform PlayerPosition;
    private GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Player"))
        {
            _player.GetComponent<AR_PlayerController>().MovementRestriction(false);
            _player.transform.position = PlayerPosition.position;
        }
    }
}
