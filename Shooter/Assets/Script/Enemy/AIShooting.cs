using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShooting : Shooting
{
    


    // Update is called once per frame
    private void Update()
    {
        DrawReflectionPattern(transform.position + transform.up * 0.5f, transform.up, maxReflectionCount);
    }

    private void DrawReflectionPattern(Vector3 position, Vector3 direction, int reflectionsRemaining)
    {
        if (reflectionsRemaining == 0)
        {
            return;
        }

        Vector3 startingPosition = position;

        
        RaycastHit2D hit = Physics2D.Raycast(position, direction, maxStepDistance, _layerMask);
        if (hit.collider != null && hit.collider.tag != "Player")
        {
            direction = Vector3.Reflect(direction, hit.normal);
            position = hit.point;
        }
        else if(hit.collider != null && hit.collider.tag == "Player" && _isFire)
        {
            _isFire = false;
            StartCoroutine(Shoot());
        }
        else
        {
            position += direction * maxStepDistance;
        }

        DrawReflectionPattern(position, direction, reflectionsRemaining - 1);

    }
}
