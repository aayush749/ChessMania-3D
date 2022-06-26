using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : MonoBehaviour
{
    string color;

    void OnEnable()
    {
        color = name.Contains("White") ? "White" : "Black";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Repositions the queen on the board based on the color of the king (checked from the name of the GameObject)
    /// </summary>
    public void RepositionOnBoard()
    {
        if (color.Equals("White"))
        {
            transform.position = new Vector3(
                ChessBoard.GetBoardPos(ChessDotNet.File.D, 1).x,
                transform.position.y,
                ChessBoard.GetBoardPos(ChessDotNet.File.D, 1).y
            );
        }
        else
        {
            transform.position = new Vector3(
                ChessBoard.GetBoardPos(ChessDotNet.File.D, 8).x,
                transform.position.y,
                ChessBoard.GetBoardPos(ChessDotNet.File.D, 8).y
            );

        }
    }
}
