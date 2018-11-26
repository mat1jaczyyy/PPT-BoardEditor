﻿using System.Drawing;
using System.Windows.Forms;

namespace PPTBoardEditor {
    class UIHelper {
        public static Color getTetrominoColor(int x) {
            switch (x) {
                case 0:
                    return Color.FromArgb(0, 255, 0);

                case 1:
                    return Color.FromArgb(255, 0, 0);

                case 2:
                    return Color.FromArgb(0, 0, 255);

                case 3:
                    return Color.FromArgb(255, 63, 0);

                case 4:
                    return Color.FromArgb(63, 0, 255);

                case 5:
                    return Color.FromArgb(255, 255, 0);

                case 6:
                    return Color.FromArgb(0, 255, 255);

                case 7:
                    return Color.Goldenrod;

                case 9:
                    return Color.FromArgb(255, 255, 255);
            }

            return Color.Transparent;
        }

        public static void drawBoard(PictureBox canvas, int[,] board) {
            canvas.Image = new Bitmap(canvas.Width, canvas.Height);
            using (Graphics gfx = Graphics.FromImage(canvas.Image)) {
                for (int i = 0; i < 10; i++) {
                    for (int j = 0; j < 40; j++) {
                        gfx.FillRectangle(new SolidBrush(UIHelper.getTetrominoColor(board[i, j])), i * (canvas.Width / 10), (39 - j) * (canvas.Height / 40), canvas.Width / 10, canvas.Height / 40);
                    }
                }

                gfx.DrawLine(new Pen(Color.Red), 0, canvas.Height / 2, canvas.Width, canvas.Height / 2);
                gfx.Flush();
            }
        }

        public static void drawSelector(PictureBox canvas, int color) {
            if (color == 8) return;
            if (color == -1) color = 0;
            else if (color != 9) color++;

            canvas.Image = new Bitmap(canvas.Width, canvas.Height);
            using (Graphics gfx = Graphics.FromImage(canvas.Image)) {
                for (int i = 0; i < 10; i++) {
                    int j = i;
                    if (j == 0) j = -1;
                    else if (j != 9) j--;

                    gfx.FillRectangle(new SolidBrush(UIHelper.getTetrominoColor(j)), i * (canvas.Width / 10), 0, canvas.Width / 10, canvas.Height);
                }

                gfx.DrawRectangle(new Pen(Color.Black), color * (canvas.Width / 10), 0, canvas.Width / 10 - 1, canvas.Height - 1);
                gfx.Flush();
            }
        }
    }
}