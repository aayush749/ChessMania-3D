using System;
using UnityEngine;

class PieceSelector
{
    public static GameObject GetObject()
    {
        Camera camera = MonoBehaviour.FindObjectOfType<Camera>();
        if (camera.name.Equals("Main Camera"))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    GameObject objectHit = GameObject.Find(hit.collider.gameObject.name);
                    return objectHit;
                }
            }

        }
        return null;
    }
}