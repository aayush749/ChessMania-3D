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

        float initialDist = (transform.position - finalPosVec3).magnitude;
        float curDist = initialDist;
        while(curDist >= 0.01f)
        {
            Vector3 dirVec = (finalPosVec3 - transform.position).normalized;
            float incrementVal;
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