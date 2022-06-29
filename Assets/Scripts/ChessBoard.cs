using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChessDotNet;
using System;

public class ChessBoard : MonoBehaviour
{
    // Start is called before the first frame update
    private ChessGame game;
    private static Vector2[][] positionMat;
         
    [SerializeField]
    private King[] kingPieces;

    [SerializeField]
    private Queen[] queenPieces;

    [SerializeField]
    private Bishop[] bishopPieces;

    [SerializeField]
    private Knight[] knightPieces;

    [SerializeField]
    private Rook[] rookPieces;

    [SerializeField]
    private Pawn[] pawnPieces;

    void Start()
    {
        FillPositionMat();

        AssertPiecesAvailability();
        game = new ChessGame();
        Debug.Log($"Turn of color: {game.WhoseTurn}");
        try
        {
            ResetBoard();
            Debug.Log("Sucessfully performed action: Board Reset");
        } catch(Exception e)
        {
            Debug.LogError($"Exception thrown while resetting the board's pieces: {e}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AssertPiecesAvailability()
    {
        Debug.Assert(kingPieces.Length   == 1 * 2, "Not all king present!");
        Debug.Assert(queenPieces.Length  == 1 * 2, "Not all queen present!");
        Debug.Assert(bishopPieces.Length == 2 * 2, "Not all bishop present!");
        Debug.Assert(knightPieces.Length == 2 * 2, "Not all knight present!");
        Debug.Assert(rookPieces.Length   == 2 * 2, "Not all rook present!");
        Debug.Assert(pawnPieces.Length   == 8 * 2, "Not all pawn present!");
    }

    public static Vector2 GetBoardPos(ChessDotNet.File colLetter, int rowNum)
    {
        return positionMat[(int) colLetter][rowNum -1];
    }

    private void FillPositionMat()
    {
        // initialize matrix
        positionMat = new Vector2[8][];
        for(int rowNum = 0; rowNum < 8; rowNum++)
        {
           positionMat[rowNum] = new Vector2[8]; 
        }

        // Fill column A
        positionMat[(int) ChessDotNet.File.A][1 -1] = new Vector2(-0.2135874f, -0.2120121f);
        positionMat[(int) ChessDotNet.File.A][2 -1] = new Vector2(-0.2135874f, -0.15f);
        positionMat[(int) ChessDotNet.File.A][3 -1] = new Vector2(-0.2135874f, -0.08576425f);
        positionMat[(int) ChessDotNet.File.A][4 -1] = new Vector2(-0.2135874f, -0.03776723f);
        positionMat[(int) ChessDotNet.File.A][5 -1] = new Vector2(-0.2135874f, 0.02999789f);
        positionMat[(int) ChessDotNet.File.A][6 -1] = new Vector2(-0.2135874f, 0.09103367f);
        positionMat[(int) ChessDotNet.File.A][7 -1] = new Vector2(-0.2135874f, 0.1418725f);
        positionMat[(int) ChessDotNet.File.A][8 -1] = new Vector2(-0.2135874f, 0.2152513f);

        // Fill column B
        positionMat[(int) ChessDotNet.File.B][1 -1] = new Vector2(-0.15f, -0.2120121f);
        positionMat[(int) ChessDotNet.File.B][2 -1] = new Vector2(-0.15f, -0.15f);
        positionMat[(int) ChessDotNet.File.B][3 -1] = new Vector2(-0.15f, -0.08576425f);
        positionMat[(int) ChessDotNet.File.B][4 -1] = new Vector2(-0.15f, -0.03776723f);
        positionMat[(int) ChessDotNet.File.B][5 -1] = new Vector2(-0.15f, 0.02999789f);
        positionMat[(int) ChessDotNet.File.B][6 -1] = new Vector2(-0.15f, 0.09103367f);
        positionMat[(int) ChessDotNet.File.B][7 -1] = new Vector2(-0.15f, 0.1418725f);
        positionMat[(int) ChessDotNet.File.B][8 -1] = new Vector2(-0.15f, 0.2152513f);

        // Fill column C
        positionMat[(int) ChessDotNet.File.C][1 -1] = new Vector2(-0.09f, -0.2120121f);
        positionMat[(int) ChessDotNet.File.C][2 -1] = new Vector2(-0.09f, -0.15f);
        positionMat[(int) ChessDotNet.File.C][3 -1] = new Vector2(-0.09f, -0.08576425f);
        positionMat[(int) ChessDotNet.File.C][4 -1] = new Vector2(-0.09f, -0.03776723f);
        positionMat[(int) ChessDotNet.File.C][5 -1] = new Vector2(-0.09f, 0.02999789f);
        positionMat[(int) ChessDotNet.File.C][6 -1] = new Vector2(-0.09f, 0.09103367f);
        positionMat[(int) ChessDotNet.File.C][7 -1] = new Vector2(-0.09f, 0.1418725f);
        positionMat[(int) ChessDotNet.File.C][8 -1] = new Vector2(-0.09f, 0.2152513f);

        // Fill column D
        positionMat[(int) ChessDotNet.File.D][1 -1] = new Vector2(-0.02980685f, -0.2120121f);
        positionMat[(int) ChessDotNet.File.D][2 -1] = new Vector2(-0.02980685f, -0.15f);
        positionMat[(int) ChessDotNet.File.D][3 -1] = new Vector2(-0.02980685f, -0.08576425f);
        positionMat[(int) ChessDotNet.File.D][4 -1] = new Vector2(-0.02980685f, -0.03776723f);
        positionMat[(int) ChessDotNet.File.D][5 -1] = new Vector2(-0.02980685f, 0.02999789f);
        positionMat[(int) ChessDotNet.File.D][6 -1] = new Vector2(-0.02980685f, 0.09103367f);
        positionMat[(int) ChessDotNet.File.D][7 -1] = new Vector2(-0.02980685f, 0.1418725f);
        positionMat[(int) ChessDotNet.File.D][8 -1] = new Vector2(-0.02980685f, 0.2152513f);

        // Fill column E
        positionMat[(int) ChessDotNet.File.E][1 -1] = new Vector2(0.02895423f, -0.2120121f);
        positionMat[(int) ChessDotNet.File.E][2 -1] = new Vector2(0.02895423f, -0.15f);
        positionMat[(int) ChessDotNet.File.E][3 -1] = new Vector2(0.02895423f, -0.08576425f);
        positionMat[(int) ChessDotNet.File.E][4 -1] = new Vector2(0.02895423f, -0.03776723f);
        positionMat[(int) ChessDotNet.File.E][5 -1] = new Vector2(0.02895423f, 0.02999789f);
        positionMat[(int) ChessDotNet.File.E][6 -1] = new Vector2(0.02895423f, 0.09103367f);
        positionMat[(int) ChessDotNet.File.E][7 -1] = new Vector2(0.02895423f, 0.1418725f);
        positionMat[(int) ChessDotNet.File.E][8 -1] = new Vector2(0.02895423f, 0.2152513f);
        
        // Fill column F
        positionMat[(int) ChessDotNet.File.F][1 -1] = new Vector2(0.09f, -0.2120121f);
        positionMat[(int) ChessDotNet.File.F][2 -1] = new Vector2(0.09f, -0.15f);
        positionMat[(int) ChessDotNet.File.F][3 -1] = new Vector2(0.09f, -0.08576425f);
        positionMat[(int) ChessDotNet.File.F][4 -1] = new Vector2(0.09f, -0.03776723f);
        positionMat[(int) ChessDotNet.File.F][5 -1] = new Vector2(0.09f, 0.02999789f);
        positionMat[(int) ChessDotNet.File.F][6 -1] = new Vector2(0.09f, 0.09103367f);
        positionMat[(int) ChessDotNet.File.F][7 -1] = new Vector2(0.09f, 0.1418725f);
        positionMat[(int) ChessDotNet.File.F][8 -1] = new Vector2(0.09f, 0.2152513f);
        
        // Fill column G
        positionMat[(int) ChessDotNet.File.G][1 -1] = new Vector2(0.1478937f, -0.2120121f);
        positionMat[(int) ChessDotNet.File.G][2 -1] = new Vector2(0.1478937f, -0.15f);
        positionMat[(int) ChessDotNet.File.G][3 -1] = new Vector2(0.1478937f, -0.08576425f);
        positionMat[(int) ChessDotNet.File.G][4 -1] = new Vector2(0.1478937f, -0.03776723f);
        positionMat[(int) ChessDotNet.File.G][5 -1] = new Vector2(0.1478937f, 0.02999789f);
        positionMat[(int) ChessDotNet.File.G][6 -1] = new Vector2(0.1478937f, 0.09103367f);
        positionMat[(int) ChessDotNet.File.G][7 -1] = new Vector2(0.1478937f, 0.1418725f);
        positionMat[(int) ChessDotNet.File.G][8 -1] = new Vector2(0.1478937f, 0.2152513f);
        
        // Fill column H
        positionMat[(int) ChessDotNet.File.H][1 -1] = new Vector2(0.2078561f, -0.2120121f);
        positionMat[(int) ChessDotNet.File.H][2 -1] = new Vector2(0.2078561f, -0.15f);
        positionMat[(int) ChessDotNet.File.H][3 -1] = new Vector2(0.2078561f, -0.08576425f);
        positionMat[(int) ChessDotNet.File.H][4 -1] = new Vector2(0.2078561f, -0.03776723f);
        positionMat[(int) ChessDotNet.File.H][5 -1] = new Vector2(0.2078561f, 0.02999789f);
        positionMat[(int) ChessDotNet.File.H][6 -1] = new Vector2(0.2078561f, 0.09103367f);
        positionMat[(int) ChessDotNet.File.H][7 -1] = new Vector2(0.2078561f, 0.1418725f);
        positionMat[(int) ChessDotNet.File.H][8 -1] = new Vector2(0.2078561f, 0.2152513f);
    }

    public void ResetBoard()
    {
        Debug.Log("Resetting Chess board pieces");

        // Reposition Kings
        RepositionKings();
    
        // Reposition Queens
        RepositionQueens();

        // Reposition Bishops
        RepositionBishops();
        
        // Reposition Knight
        RepositionKnight();
        
        // Reposition Rooks
        RepositionRooks();

        // Reposition Pawns
        RepositionPawns();
    }
    private void RepositionPawns()
    {
        foreach(Pawn pawn in pawnPieces)
        {
            pawn.RepositionOnBoard();
        }
    }
    private void RepositionRooks()
    {
        foreach(Rook rook in rookPieces)
        {
            rook.RepositionOnBoard(true);
        }
    }
    private void RepositionKnight()
    {
        foreach(Knight knight in knightPieces)
        {
            knight.RepositionOnBoard(true);
        }
    }
    private void RepositionBishops()
    {
        foreach(Bishop bishop in bishopPieces)
        {
            bishop.RepositionOnBoard(true);
        }
    }
    private void RepositionKings()
    {
        foreach(King king in kingPieces)
        {
            king.RepositionOnBoard(true);
        }
    }
    private void RepositionQueens()
    {
        foreach(Queen queen in queenPieces)
        {
            queen.RepositionOnBoard(true);
        }
    }
}
