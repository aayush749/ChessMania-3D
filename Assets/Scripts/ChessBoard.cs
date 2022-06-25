using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChessDotNet;
using System;

public class ChessBoard : MonoBehaviour
{
    // Start is called before the first frame update
    private ChessGame game;
    
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
        AssertPiecesAvailability();
        game = new ChessGame();
        Debug.Log($"Turn of color: {game.WhoseTurn}");
        ResetBoard();
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


    private void ResetBoard()
    {
        Debug.Log("Resetting Chess board pieces");
    }
}
