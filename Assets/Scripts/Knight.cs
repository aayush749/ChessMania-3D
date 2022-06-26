using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
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
                            ChessBoard.GetBoardPos(ChessDotNet.File.B, 1).x,
                            transform.position.y,
                            ChessBoard.GetBoardPos(ChessDotNet.File.B, 1).y
                        );
                        break;
                    }
                    case "Black":
                    {
                        transform.position = new Vector3(
                            ChessBoard.GetBoardPos(ChessDotNet.File.B, 8).x,
                            transform.position.y,
                            ChessBoard.GetBoardPos(ChessDotNet.File.B, 8).y
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
                            ChessBoard.GetBoardPos(ChessDotNet.File.G, 1).x,
                            transform.position.y,
                            ChessBoard.GetBoardPos(ChessDotNet.File.G, 1).y
                        );
                        break;
                    }
                    case "Black":
                    {
                        transform.position = new Vector3(
                            ChessBoard.GetBoardPos(ChessDotNet.File.G, 8).x,
                            transform.position.y,
                            ChessBoard.GetBoardPos(ChessDotNet.File.G, 8).y
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
