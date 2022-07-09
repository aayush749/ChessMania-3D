using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessPiece
{
    [SerializeField]
    private float incrementValPercent = 2.5f;

    int id;
    
    void OnEnable()
    {
        id = name.Contains("0") ? 1 : 2;
        color = name.Contains("White") ? "White" : "Black";        

        GetCorrectPositionOnBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetCorrectPositionOnBoard()
    {
        switch(id)
        {
            case 1:
            {
                switch(color)
                {
                    case "White":
                    {
                        row = 1;
                        col = ChessDotNet.File.A;
                        break;
                    }
                    case "Black":
                    {
                        row = 8;
                        col = ChessDotNet.File.A;
                        break;
                    }
                    default:
                        break;
                }
                break;
            }
            case 2:
            {
                switch(color)
                {
                    case "White":
                    {
                        row = 1;
                        col = ChessDotNet.File.H;
                        break;
                    }
                    case "Black":
                    {
                        row = 8;
                        col = ChessDotNet.File.H;
                        break;
                    }
                    default:
                        break;
                }
                break;
            }

            default:
                break;
        }
    }
    /// <summary>
    /// Repositions the rook on the board based on the color of the rook (checked from the name of the GameObject)
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

    public void MoveToPos(Vector3 location)
    {
        MoveToPos(new Vector2(location.x, location.z));
    }

    public void MoveToPos(Vector2 location)
    {
        StartCoroutine(Movement.MoveCoroutine(location, transform, incrementValPercent));
    }

}
