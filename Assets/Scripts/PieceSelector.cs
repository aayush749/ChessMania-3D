using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PieceSelector
{
    public static ChessPiece currentPiece { get; private set; }
    private static Coroutine flashCoroutine;

    // Updates currentPiece to be the piece currently being pointed at by the mouse
    public static ChessPiece GetPiece()
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
                    currentPiece = GameObject.Find(hit.collider.gameObject.name).GetComponent<ChessPiece>();
                    return currentPiece;
                }
            }

        }
        return null;
    }
}