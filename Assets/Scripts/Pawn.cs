using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    [SerializeField]
    private float incrementValPercent = 2.5f;

    int id;
    
    void OnEnable()
    {
        int.TryParse($"{name[name.Length -1]}", out id);
        // increment the id by 1 for 1 based indexing
        ++id;

        color = name.Contains("White") ? "White" : "Black";

        GetCorrectPositionOnBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetCorrectPositionOnBoard()
    {
        ChessDotNet.File colLetter;
        int row;

        // Determine the appropriate column to place the pawn   
        switch (id)
       {
        case 1:
            colLetter = ChessDotNet.File.A;
            break;
        
        case 2:
            colLetter = ChessDotNet.File.B;
            break;
        
        case 3:
            colLetter = ChessDotNet.File.C;
            break;
        
        case 4:
            colLetter = ChessDotNet.File.D;
            break;
        
        case 5:
            colLetter = ChessDotNet.File.E;
            break;
        
        case 6:
            colLetter = ChessDotNet.File.F;
            break;
        
        case 7:
            colLetter = ChessDotNet.File.G;
            break;
        
        case 8:
            colLetter = ChessDotNet.File.H;
            break;

        default:
            throw new System.Exception($"Could not find a proper column to place the pawn : [ID: {id}, Color: {color}]");
       } 
        
        // Determine the appropriate row to place the pawn
        switch (color)
        {
            case "White":
                row = 2;
                break;
            
            case "Black":
                row = 7;
                break;
            
            default:
                throw new System.Exception($"Could not find a proper row to place the pawn : [ID: {id}, Color: {color}]");
        }

        col = colLetter;
        this.row = row;
    }

    /// <summary>
    /// Repositions the pawn on the board based on the color of the pawn (checked from the name of the GameObject)
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