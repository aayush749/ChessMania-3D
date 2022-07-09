using System.Collections;
using UnityEngine;

class PlayerInputManager : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChessPiece prevSelectedPiece = PieceSelector.currentPiece;
            ChessPiece newPiece = PieceSelector.GetPiece();
            if (newPiece != null)
            {
               
                if (prevSelectedPiece != null && 
                    newPiece.name != prevSelectedPiece.name)
                {
                    prevSelectedPiece.StopHighlighting();
                }

                Debug.Log($"Selected piece: {newPiece.name}");
                newPiece.StartHighlighting(1.0f);
            }
            else if (prevSelectedPiece != null)
            {
                prevSelectedPiece.StopHighlighting();
            }
        }
    }
}