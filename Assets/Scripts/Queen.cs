using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : MonoBehaviour
{
    [SerializeField]
    private float incrementValPercent = 2.5f;

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
    /// Repositions the queen on the board based on the color of the queen (checked from the name of the GameObject)
    /// </summary>
    public void RepositionOnBoard(bool moveSmoothly = false)
    {
        Vector3 newPos = new Vector3();
        if (color.Equals("White"))
        {
            newPos = new Vector3(
                ChessBoard.GetBoardPos(ChessDotNet.File.D, 1).x,
                transform.position.y,
                ChessBoard.GetBoardPos(ChessDotNet.File.D, 1).y
            );
        }
        else
        {
            newPos = new Vector3(
                ChessBoard.GetBoardPos(ChessDotNet.File.D, 8).x,
                transform.position.y,
                ChessBoard.GetBoardPos(ChessDotNet.File.D, 8).y
            );
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
