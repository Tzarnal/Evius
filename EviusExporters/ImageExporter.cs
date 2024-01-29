using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing.Processing;
using EviusChess.Board;

namespace EviusExporters;

public static class ImageExporter
{
    public static void SaveImage(GameBoard board, string path, int squareSize = 64, int pieceSize = 48)
    {
        var image = BaseImage(board, squareSize);
        image = DrawPieces(image, board, squareSize, pieceSize);

        image.Save(path);
    }

    public static Image DrawPieces(Image image, GameBoard board, int squareSize, int pieceSize)
    {
        int pieceOffset = (squareSize - pieceSize) / 2;

        var totalWidth = board.BoardWidth * squareSize;
        var totalHeight = board.BoardHeight * squareSize;

        for (int x = 1; x <= board.BoardWidth; x++)
        {
            for (int y = 1; y <= board.BoardHeight; y++)
            {
                if (board[x, y] == null)
                {
                    continue;
                }

                var piece = board[x, y];

                var pieceImage = GetPieceImage(piece, pieceSize);

                image.Mutate(i => i.DrawImage(pieceImage, new Point(
                    totalWidth - (x * squareSize) + pieceOffset,
                    totalHeight - (y * squareSize) + pieceOffset),
                    1f));
            }
        }

        return image;
    }

    private static Image GetPieceImage(Piece piece, int pieceSize)
    {
        var color = piece.IsWhite ? "White" : "Black";
        var name = Pieces.Find(piece).Name;
        var imagePath = $"Assets/Classic Pieces/{color} {name}.png";

        var image = Image.Load(imagePath);
        image.Mutate(i => i.Resize(pieceSize, pieceSize));

        return image;
    }

    private static Image BaseImage(GameBoard board, int squareSize)
    {
        var colorA = Color.ParseHex("E9EDCC");
        var colorB = Color.ParseHex("779954");

        var alternateColor = true;

        Image<Rgba32> Image = new(board.BoardWidth * squareSize, board.BoardWidth * squareSize);

        for (int x = 0; x < board.BoardWidth; x++)
        {
            for (int y = 0; y < board.BoardHeight; y++)
            {
                Rectangle rect = new(x * squareSize, y * squareSize, squareSize, squareSize);
                var color = alternateColor ? colorA : colorB;
                Image.Mutate(i =>
                    i.Fill(color, rect)
                );
                alternateColor = !alternateColor;
            }
            alternateColor = !alternateColor;
        }

        return Image;
    }
}