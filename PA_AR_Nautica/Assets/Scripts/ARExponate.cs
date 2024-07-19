using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARExponate : MonoBehaviour
{
    public Transform targetPosition;
    public float moveDuration = 3.0f;
    public GameObject ItemUI;

    private Vector3 _startPosition;
    private Vector3 _initialScale = new Vector3(0.3f, 0.3f, 0.3f);
    private Vector3 _targetScale = new Vector3(1, 1, 1);
    private Transform _originalParent;
    private bool _isMoving = false;

    private void Start()
    {
        _startPosition = transform.position;
        _initialScale = transform.localScale;
        _originalParent = transform.parent;
    }

   

    private IEnumerator MoveAndScale(Vector3 targetPos, Vector3 targetScl, Transform newParent)
    {
        _isMoving = true;
        float elapsedTime = 0;
        Vector3 startingPos = transform.position;
        Vector3 startingScale = transform.localScale;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startingPos, targetPos, (elapsedTime / moveDuration));
            transform.localScale = Vector3.Lerp(startingScale, targetScl, (elapsedTime / moveDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        transform.localScale = targetScl;
        transform.parent = newParent;
        _isMoving = false;
    }


    public void StartMoving()
    {
      if(!_isMoving)
        {
            StartCoroutine(MoveAndScale(targetPosition.position, _targetScale, targetPosition));
            ItemUI.SetActive(true);
        }
    }

    public void ResetPosition()
    {
      StartCoroutine(MoveAndScale(_startPosition,_initialScale, _originalParent));
    }
}
