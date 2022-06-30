using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : MonoBehaviour
{
    [SerializeField]
    private float incrementValPercent = 2.5f;

    string color;

    public ChessDotNet.File col { get; private set; }
    public int row { get; private set; }
    void OnEnable()
    {
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
            col = ChessDotNet.File.D;
            row = 1;
        }
        else
        {
            col = ChessDotNet.File.D;
            row = 8;
        }
    }

    /// <summary>
    /// Repositions the queen on the board based on the color of the queen (checked from the name of the GameObject)
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
