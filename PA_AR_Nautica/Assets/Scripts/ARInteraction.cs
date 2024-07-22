using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARInteraction : MonoBehaviour
{
    public GameObject uiPanel; // Das UI-Panel, das geöffnet werden soll
    public GameObject uiOverlay;

    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        // Stelle sicher, dass das UI-Panel zu Beginn inaktiv ist
        if (uiPanel != null)
        {
            uiPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform == transform)
                    {
                        // Wenn das Objekt berührt wird, aktiviere das UI-Panel
                        if (uiPanel != null)
                        {
                            _animator.SetTrigger("onClick");
                            uiPanel.SetActive(true);
                            uiOverlay.SetActive(false);
                        }
                    }
                }
            }
        }
    }
}

