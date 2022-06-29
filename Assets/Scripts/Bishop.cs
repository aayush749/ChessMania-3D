﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : MonoBehaviour
{
    [SerializeField]
    private float incrementValPercent = 2.5f;

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
    /// Repositions the bishop on the board based on the color of the bishop (checked from the name of the GameObject)
    /// </summary>
    public void RepositionOnBoard(bool moveSmoothly = false)
    {
        Vector3 newPos = new Vector3();
        switch(id)
        {
            case 1:
            {
                switch(color)
                {
                    case "White":
                    {
                        newPos = new Vector3(
                            ChessBoard.GetBoardPos(ChessDotNet.File.C, 1).x,
                            transform.position.y,
                            ChessBoard.GetBoardPos(ChessDotNet.File.C, 1).y
                        );
                        break;
                    }
                    case "Black":
                    {
                        newPos = new Vector3(
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
                        newPos = new Vector3(
                            ChessBoard.GetBoardPos(ChessDotNet.File.F, 1).x,
                            transform.position.y,
                            ChessBoard.GetBoardPos(ChessDotNet.File.F, 1).y
                        );
                        break;
                    }
                    case "Black":
                    {
                        newPos = new Vector3(
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