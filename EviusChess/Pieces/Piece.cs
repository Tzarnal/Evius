﻿namespace EviusChess.Pieces;

public abstract class Piece
{
    public string Name { get; }
    public string Letter { get; }

    public bool IsWhite { get; set; }

    public bool IsBlack
    {
        get => !IsWhite;
        set => IsWhite = !value;
    }
}