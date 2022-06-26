using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : MonoBehaviour
{
    int id;
    string color;
    void OnEnable()
    {
        id = name.Contains("0") ? 1 : 2;
        color = name.Contains("White") ? "White" : "Black";        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Repositions the rook on the board based on the color of the rook (checked from the name of the GameObject)
    /// </summary>
    public void RepositionOnBoard()
    {
        switch(id)
        {
            case 1:
            {
                switch(color)
                {
                    case "White":
                    {
                        transform.position = new Vector3(
                            ChessBoard.GetBoardPos(ChessDotNet.File.A, 1).x,
                            transform.position.y,
                            ChessBoard.GetBoardPos(ChessDotNet.File.A, 1).y
                        );
                        break;
                    }
                    case "Black":
                    {
                        transform.position = new Vector3(
                            ChessBoard.GetBoardPos(ChessDotNet.File.A, 8).x,
                            transform.position.y,
                            ChessBoard.GetBoardPos(ChessDotNet.File.A, 8).y
                        );
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
                        transform.position = new Vector3(
                            ChessBoard.GetBoardPos(ChessDotNet.File.H, 1).x,
                            transform.position.y,
                            ChessBoard.GetBoardPos(ChessDotNet.File.H, 1).y
                        );
                        break;
                    }
                    case "Black":
                    {
                        transform.position = new Vector3(
                            ChessBoard.GetBoardPos(ChessDotNet.File.H, 8).x,
                            transform.position.y,
                            ChessBoard.GetBoardPos(ChessDotNet.File.H, 8).y
                        );
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
}
