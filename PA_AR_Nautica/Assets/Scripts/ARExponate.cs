using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARExponate : MonoBehaviour
{
    public Transform targetPosition;
    public float moveDuration = 3.0f;
    public GameObject ItemUI;
    public  Transform startPosition;

    private Vector3 _initialScale = new Vector3(0.3f, 0.3f, 0.3f);
    private Vector3 _targetScale = new Vector3(1, 1, 1);
    private bool _isMoving = false;

    private void Start()
    {
        _initialScale = transform.localScale;
    }

   

    private IEnumerator MoveAndScale(Vector3 targetPos, Vector3 targetScl)
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
        _isMoving = false;
    }


    public void StartMoving()
    {
      if(!_isMoving)
        {
            StartCoroutine(MoveAndScale(targetPosition.position, _targetScale));
            ItemUI.SetActive(true);
        }
    }

    public void ResetPosition()
    {
      StartCoroutine(MoveAndScale(startPosition.position,_initialScale));
    }
}
