using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : MonoBehaviour
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
                            ChessBoard.GetBoardPos(ChessDotNet.File.C, 1).x,
                            transform.position.y,
                            ChessBoard.GetBoardPos(ChessDotNet.File.C, 1).y
                        );
                        break;
                    }
                    case "Black":
                    {
                        transform.position = new Vector3(
                            ChessBoard.GetBoardPos(ChessDotNet.File.C, 8).x,
                            transform.position.y,
                            ChessBoard.GetBoardPos(ChessDotNet.File.C, 8).y
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
                            ChessBoard.GetBoardPos(ChessDotNet.File.F, 1).x,
                            transform.position.y,
                            ChessBoard.GetBoardPos(ChessDotNet.File.F, 1).y
                        );
                        break;
                    }
                    case "Black":
                    {
                        transform.position = new Vector3(
                            ChessBoard.GetBoardPos(ChessDotNet.File.F, 8).x,
                            transform.position.y,
                            ChessBoard.GetBoardPos(ChessDotNet.File.F, 8).y
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
