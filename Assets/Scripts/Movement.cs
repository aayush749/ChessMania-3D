using System.Collections;
using UnityEngine;

public static class Movement
{
    public static IEnumerator MoveCoroutine(Vector2 location, Transform transform, float incrementValPercent)
    {
        Vector3 finalPosVec3 = new Vector3(
            location.x,
            transform.position.y,
            location.y
        );

        float initialDist = 0.0f;
        while(true)
        {
            Vector3 curDestVector = finalPosVec3 - transform.position;
            float curDist = curDestVector.magnitude;
            initialDist = Mathf.Max(initialDist, curDist);

            if (curDist < 0.01f)
                break;
            
            Vector3 dirVec = curDestVector.normalized;
            float incrementVal = incrementValPercent;
            
            if (curDist > 2 * initialDist / 3 || curDist < initialDist / 3)
            {
                incrementVal = 2 * incrementValPercent;
            }
            else
            {
                incrementVal = incrementValPercent;             
            }

            float increment = incrementVal * curDist;
            Vector3 newPos = transform.position + dirVec * increment;
            transform.position = newPos;
            yield return new WaitForSeconds(0.01f);
            curDist = (transform.position - finalPosVec3).magnitude;
        }
    }
}