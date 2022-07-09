using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    [SerializeField]
    private float incrementValPercent = 2.5f;

    void OnEnable()
    {
        // convert percent to float
        incrementValPercent = incrementValPercent > 1.0f ?
                                incrementValPercent / 100.0f : incrementValPercent;

        color = name.Contains("White") ? "White" : "Black";

        GetCorrectPositionOnBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetCorrectPositionOnBoard()
    {
        if (color.Equals("White"))
        {
            col = ChessDotNet.File.E;
            row = 1;
        }
        else
        {
            col = ChessDotNet.File.E;
            row = 8;
        }
    }

    /// <summary>
    /// Repositions the king on the board based on the color of the king (checked from the name of the GameObject)
    /// </summary>
    public void RepositionOnBoard(bool moveSmoothly = false)
    {
        Vector3 newPos = new Vector3(
            ChessBoard.GetBoardPos(col, row).x,
            transform.position.y,
            ChessBoard.GetBoardPos(col, row).y
        );
        if (moveSmoothly)
        {
            MoveToPos(newPos);
        }
        else
        {
            transform.position = newPos;
        }
    }

    public void MoveToPos(Vector2 location)
    {
        StartCoroutine(Movement.MoveCoroutine(location, transform, incrementValPercent));
    }

    public void MoveToPos(Vector3 location)
    {
        MoveToPos(new Vector2(location.x, location.z));
    }

}
