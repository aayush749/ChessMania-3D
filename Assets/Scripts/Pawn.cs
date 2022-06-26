using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    int id;
    string color;
    void OnEnable()
    {
        int.TryParse($"{name[name.Length -1]}", out id);
        // increment the id by 1 for 1 based indexing
        ++id;

        color = name.Contains("White") ? "White" : "Black";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Repositions the pawn on the board based on the color of the pawn (checked from the name of the GameObject)
    /// </summary>
    public void RepositionOnBoard()
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

        // Now reposition on the board
        transform.position = new Vector3(
            ChessBoard.GetBoardPos(colLetter, row).x,
            transform.position.y,
            ChessBoard.GetBoardPos(colLetter, row).y
        );
    }
}
