using System;

namespace bucketFill
{
    class Program
    {
        /// <summary>
        /// Press Run in visual studio!
        /// </summary>
        static void Main()
        {
            int[,] canvas = {{1, 1, 1, 1, 2, 1, 1, 1},
                            {2, 1, 1, 1, 2, 1, 1, 1},
                            {1, 2, 1, 1, 2, 1, 1, 2},
                            {1, 1, 2, 1, 2, 1, 2, 1},
                            {1, 1, 1, 2, 2, 2, 1, 1},
                            {1, 1, 1, 2, 1, 2, 1, 1},
                            {2, 2, 2, 1, 1, 1, 2, 2}};

            int floodXposition = 0;
            int floodYposition = 4;
            int newColorNumber = 0;

            int prevColor = canvas[floodXposition, floodYposition];
            if (newColorNumber == prevColor)
                return;
            FillCanvas(canvas, floodXposition, floodYposition, prevColor, newColorNumber);

            for (int i = 0; i < canvas.GetUpperBound(0)+1; i++)
            {
                for (int j = 0; j < canvas.GetUpperBound(1)+1; j++)
                    Console.Write(canvas[i, j] + " ");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Function that calls itsef recursively to fill all neighbor "points"
        /// on vertical, horizontal and diogonal axis with the same colorValue as initial point had,
        /// but replacing all these "nodes" with new value.
        /// Initial "if" is preventing to sumbit x, y location values that would be out of arrays bounds
        /// and returning from recursion if x and y location already holds newColorValue, preventing to run it forever potentionaly.
        /// </summary>
        private static void FillCanvas(int[,] canvas, int paintLocationX, int paintLocationY, int prevColor, int newColor)
        {
            if (paintLocationX < 0 ||
                paintLocationY < 0 ||
                paintLocationX >= canvas.GetUpperBound(0) + 1 ||
                paintLocationY >= canvas.GetUpperBound(1) + 1 ||
                canvas[paintLocationX, paintLocationY] != prevColor)
                return;
            canvas[paintLocationX, paintLocationY] = newColor;

            //horizontal,vertical axis
            FillCanvas(canvas, paintLocationX + 1, paintLocationY, prevColor, newColor);
            FillCanvas(canvas, paintLocationX - 1, paintLocationY, prevColor, newColor);
            FillCanvas(canvas, paintLocationX, paintLocationY + 1, prevColor, newColor);
            FillCanvas(canvas, paintLocationX, paintLocationY - 1, prevColor, newColor);

            //diagonal axis
            FillCanvas(canvas, paintLocationX + 1, paintLocationY - 1, prevColor, newColor);
            FillCanvas(canvas, paintLocationX + 1, paintLocationY + 1, prevColor, newColor);
            FillCanvas(canvas, paintLocationX - 1, paintLocationY + 1, prevColor, newColor);
            FillCanvas(canvas, paintLocationX - 1, paintLocationY - 1, prevColor, newColor);
        }
    }
}