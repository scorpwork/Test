using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms;

namespace Test
{
    class PDFWork
    {        
        /// <summary>
        /// Создание документа
        /// </summary>
        /// <param name="game">Игра</param>
        /// <param name="gameTable">Таблица игры</param>
        public void CreatePDF(Game game, DataGridView gameTable)
        {
            using (Document doc = new Document())
            {
                PdfWriter writer;
                try
                {
                    writer = PdfWriter.GetInstance(doc, new FileStream("Reports\\"+game.name+".pdf", FileMode.Create));
                }
                catch
                {
                    Msg.Show(MainForm.Get(), "Ошибка", 
                        "Невозможно создать документ\nВозможно он используется в другой программе");
                    return;
                }
                doc.Open();
                PdfContentByte content = writer.DirectContent;
                SetPDFPage(doc);
                doc.Add(GetHeader(game));
                doc.Add(GetSeparator());
                doc.Add(GetTable(game, gameTable));
                doc.Add(GetSeparator());
                AddProgressors(game, content,doc,writer);
                doc.Close();
            }
            Msg.Show(MainForm.Get(), "Документ сформирован", game.name+".pdf");
        }

        /// <summary>
        /// Установка параметров страниц
        /// </summary>
        /// <param name="doc">документ</param>
        private void SetPDFPage(Document doc)
        {            
            Rectangle rec = new Rectangle(PageSize.A4.Rotate());
            rec.BackgroundColor = new BaseColor(37, 168, 81);
            doc.SetMargins(0, 0, 0, 0);
        }

        /// <summary>
        /// Формирование заголовка
        /// </summary>
        /// <param name="game">Игра</param>
        /// <returns></returns>
        private IElement GetHeader(Game game)
        {
            Font headerFont = new Font(GetBaseFont(), 14, Font.BOLD);
            Phrase header = new Phrase(game.name+" "+game.date, headerFont);
            return header;
        }

        /// <summary>
        /// Формирование разделителя
        /// </summary>
        /// <returns></returns>
        private IElement GetSeparator()
        {
            Phrase separator = new Phrase("\n");
            return separator;
        }

        /// <summary>
        /// Формирование таблицы
        /// </summary>
        /// <param name="game">Игра</param>
        /// <param name="dataTable">Таблица игры</param>
        /// <returns></returns>
        private IElement GetTable(Game game, DataGridView dataTable)
        {
            Font tableHeaderFont = new Font(GetBaseFont(), 10, Font.BOLD);
            Font tableCellFont = new Font(GetBaseFont(), 10, 0);
            Font tableCommandCellFont = new Font(GetBaseFont(), 12, Font.BOLD);
            PdfPTable table = new PdfPTable(4);
            PdfPCell cell;
            cell = new PdfPCell(new Phrase(new Chunk(dataTable.Columns[0].HeaderText, tableHeaderFont)));
            cell.Border = 0;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(new Chunk(dataTable.Columns[1].HeaderText, tableHeaderFont)));
            cell.Border = 0;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(new Chunk(dataTable.Columns[2].HeaderText, tableHeaderFont)));
            cell.Border = 0;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(new Chunk(dataTable.Columns[3].HeaderText, tableHeaderFont)));
            cell.Border = 0;
            table.AddCell(cell);
            for (int iRow = 0; iRow < dataTable.Rows.Count; iRow++)
            {
                for (int iCol = 0; iCol < dataTable.Columns.Count; iCol++)
                {
                    object value = dataTable.Rows[iRow].Cells[iCol].Value;
                    if (value != null)
                    { 
                        if (dataTable.Rows[iRow].Tag != null)
                        {
                            cell = new PdfPCell(new Phrase(new Chunk(value.ToString(), tableCellFont)));
                            cell.Border = Rectangle.BOTTOM_BORDER;
                            cell.MinimumHeight = 30;
                            cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                            cell.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;
                            cell.BorderColorBottom = BaseColor.GRAY;
                        }
                        else
                        {
                            cell = new PdfPCell(new Phrase(new Chunk(value.ToString(), tableCommandCellFont)));
                            cell.Border = 0;
                            cell.MinimumHeight = 50;
                            cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                            cell.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;
                        }
                    }
                    else
                    {
                        cell = new PdfPCell(new Phrase(new Chunk("", tableCellFont)));
                        cell.Border = 0;
                        cell.MinimumHeight = 50;
                    }
                    table.AddCell(cell);
                }
            }
            return table;
        }

        /// <summary>
        /// Формирование стандартного стиля
        /// </summary>
        /// <returns></returns>
        private BaseFont GetBaseFont()
        {
            return BaseFont.CreateFont(@"c:\Windows\Fonts\arial.ttf",
                            BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        }

        /// <summary>
        /// Формирование прогрессоров
        /// </summary>
        /// <param name="game">Игра</param>
        /// <param name="content">Контент</param>
        /// <param name="doc">документ</param>
        /// <param name="writer">writer</param>
        private void AddProgressors(Game game, PdfContentByte content, Document doc, PdfWriter writer)
        {
            int iterator = 0;
            Font textFont = new Font(GetBaseFont(), 10, Font.BOLD);
            Font teamFont = new Font(GetBaseFont(), 12, Font.BOLD);
            float progressSize = (doc.PageSize.Width / 2 - 15) - 50;
            float YOffset = writer.GetVerticalPosition(true) - 50;
            int sumRating = GetSumRating(game);
            int maxRating = GetMaxRating(game);
            double maxAccuracy = GetMaxAccuracy(game);
            bool columnOffset = false;
            foreach (Team team in game.teams)
            {
                float XOffset = 50;
                if ((iterator % 2)  != 0)
                {
                    XOffset = doc.PageSize.Width / 2 + 15;
                    columnOffset = true;
                }
                else
                {
                    columnOffset = false;
                }
                DrawProgressors(team, maxRating, maxAccuracy, content, XOffset, YOffset, progressSize);
                iterator++;
                if (columnOffset)
                {
                    YOffset -= 130;
                }
            }
        }

        /// <summary>
        /// Рисование прогрессоров для рейтинга и точности
        /// </summary>
        private void DrawProgressors(Team team, int maxRating, double maxAccuracy, PdfContentByte content, float XOffset, float YOffset, float progressSize)
        {
            DrawRatingProgressor(team, maxRating, content, XOffset, YOffset, progressSize);
            DrawAccuracyProgressor(team, maxAccuracy, content, XOffset, YOffset, progressSize);
        }

        /// <summary>
        /// Рисование прогрессора рейтинга
        /// </summary>
        private void DrawRatingProgressor(Team team, int maxRating, PdfContentByte content,     
                                          float XOffset, float YOffset, float progressSize)
        {
            content.SetColorStroke(BaseColor.BLUE);
            content.SetColorFill(BaseColor.BLUE);
            content.MoveTo(XOffset, YOffset);
            content.LineTo(progressSize + XOffset, YOffset);
            content.LineTo(progressSize + XOffset, YOffset - 10);
            content.LineTo(XOffset, YOffset - 10);
            content.LineTo(XOffset, YOffset);
            content.Stroke();

            double teamRatingProc = GetTeamRatingProc(team, maxRating);
            double currentRatingProgress = GetCurrentProgressSize(progressSize, teamRatingProc);
            content.MoveTo(XOffset, YOffset);
            content.LineTo(currentRatingProgress + XOffset, YOffset);
            content.LineTo(currentRatingProgress + XOffset, YOffset - 10);
            content.LineTo(XOffset, YOffset - 10);
            content.LineTo(XOffset, YOffset);
            content.Fill();
            content.Stroke();

            content.ClosePathStroke();
            content.ClosePathFillStroke();

            content.SetColorStroke(BaseColor.BLACK);
            content.SetColorFill(BaseColor.BLACK);
            content.BeginText();
            content.SetTextMatrix(XOffset, YOffset + 30);
            content.SetFontAndSize(GetBaseFont(), 14);
            content.ShowText(team.name);
            content.SetTextMatrix(XOffset, YOffset + 5);
            content.SetFontAndSize(GetBaseFont(), 10);
            content.ShowText("Рейтинг");
            content.EndText();

            content.BeginText();
            string teamRatingStr = GetTeamRating(team, maxRating).ToString("0.0");
            int length = teamRatingStr.Count();
            content.SetTextMatrix(XOffset + progressSize - 5 * length, YOffset + 5);
            content.SetFontAndSize(GetBaseFont(), 10);
            content.ShowText(teamRatingStr);
            content.EndText();

            content.ClosePathStroke();
            content.ClosePathFillStroke();
        }

        /// <summary>
        /// Рисование прогрессора точности
        /// </summary>
        private void DrawAccuracyProgressor(Team team, double maxAccuracy, PdfContentByte content, 
                                            float XOffset, float YOffset, float progressSize)
        {
            content.SetColorStroke(BaseColor.BLUE);
            content.SetColorFill(BaseColor.BLUE);
            YOffset -= 40;
            content.MoveTo(XOffset, YOffset);
            content.LineTo(progressSize + XOffset, YOffset);
            content.LineTo(progressSize + XOffset, YOffset - 10);
            content.LineTo(XOffset, YOffset - 10);
            content.LineTo(XOffset, YOffset);
            content.Stroke();

            double teamAccuracyProc = GetTeamAccuracyProc(team);
            double currentAccuracyProgress = GetCurrentProgressSize(progressSize, teamAccuracyProc);
            content.MoveTo(XOffset, YOffset);
            content.LineTo(currentAccuracyProgress + XOffset, YOffset);
            content.LineTo(currentAccuracyProgress + XOffset, YOffset - 10);
            content.LineTo(XOffset, YOffset - 10);
            content.LineTo(XOffset, YOffset);
            content.Fill();
            content.Stroke();

            content.ClosePathStroke();
            content.ClosePathFillStroke();

            content.SetColorStroke(BaseColor.BLACK);
            content.SetColorFill(BaseColor.BLACK);
            content.BeginText();
            content.SetTextMatrix(XOffset, YOffset + 5);
            content.SetFontAndSize(GetBaseFont(), 10);
            content.ShowText("Точность");
            content.EndText();

            content.BeginText();
            string teamAccuracyStr = (GetTeamAccuracy(team) * 100).ToString("0")+"%";
            int length = teamAccuracyStr.Count();
            content.SetTextMatrix(XOffset + progressSize - 6 * length, YOffset + 5);
            content.SetFontAndSize(GetBaseFont(), 10);
            content.ShowText(teamAccuracyStr);
            content.EndText();

            content.ClosePathStroke();
            content.ClosePathFillStroke();
        }

        /// <summary>
        /// Получение суммарного рейтинга по игре
        /// </summary>
        /// <param name="game">Игра</param>
        /// <returns>Суммарный рейтинг</returns>
        private int GetSumRating(Game game)
        {
            int rating = 0;
            foreach (Team team in game.teams)
            {
                foreach (Player player in team.players)
                {
                    rating += player.rating;
                }
            }
            return rating;
        }

        /// <summary>
        /// Получение среднего арифметического максимального рейтинга по командам
        /// </summary>
        /// <param name="game">игра</param>
        /// <returns>ср арифм. макс рейтинга</returns>
        private int GetMaxRating(Game game)
        {
            int maxRating = 0;
            foreach (Team team in game.teams)
            {
                int rating = 0;
                foreach (Player player in team.players)
                {
                    rating += player.rating;
                }
                rating /= team.players.Count();
                if (rating > maxRating)
                {
                    maxRating = rating;
                }
            }
            return maxRating;
        }

        /// <summary>
        /// Получение среднего арифметического максимальной точности по командам
        /// </summary>
        /// <param name="game">игра</param>
        /// <returns>ср арифм. макс точности</returns>
        private double GetMaxAccuracy(Game game)
        {
            double maxAccuracy = 0;
            foreach (Team team in game.teams)
            {
                double accuracy = 0;
                foreach (Player player in team.players)
                {
                    accuracy += player.accuracy;
                }
                accuracy /= team.players.Count();
                if (accuracy > maxAccuracy)
                {
                    maxAccuracy = accuracy;
                }
            }
            return maxAccuracy;
        }

        /// <summary>
        /// Получение рейтинга команды в процентах
        /// </summary>
        /// <param name="team">Команда</param>
        /// <param name="gameRating">Игровой максимальный рейтинг</param>
        /// <returns></returns>
        private float GetTeamRatingProc(Team team, int gameRating)
        {
            float rating = 0;
            foreach (Player player in team.players)
            {
                rating += player.rating;
            }
            rating /= team.players.Count();
            float ratingProc = (rating * 100) / gameRating;
            return ratingProc;
        }

        /// <summary>
        /// Получение точности команды в процентах
        /// </summary>
        /// <param name="team">Команда</param>
        /// <returns>Точность команды в процентах</returns>
        private double GetTeamAccuracyProc(Team team)
        {
            double accuracy = 0;
            foreach (Player player in team.players)
            {
                accuracy += player.accuracy;
            }
            accuracy /= team.players.Count();
            return accuracy * 100;
        }

        /// <summary>
        /// Получение рейтинга команды
        /// </summary>
        /// <param name="team">Команда</param>
        /// <param name="gameRating">Максимальный рейтинг</param>
        /// <returns>рейтинг команды</returns>
        private float GetTeamRating(Team team, int gameRating)
        {
            float rating = 0;
            foreach (Player player in team.players)
            {
                rating += player.rating;
            }
            return rating/team.players.Count();
        }

        /// <summary>
        /// Получение точности команды
        /// </summary>
        /// <param name="team">Команда</param>
        /// <returns>Точность команды</returns>
        private double GetTeamAccuracy(Team team)
        {
            double accuracy = 0;
            foreach (Player player in team.players)
            {
                accuracy += player.accuracy;
            }
            return accuracy / team.players.Count();
        }

        /// <summary>
        /// Получение величины заполнения прогрессора
        /// </summary>
        /// <param name="progressSize">Размер прогрессора</param>
        /// <param name="value">значение</param>
        /// <returns>величина заполнения</returns>
        private double GetCurrentProgressSize(float progressSize, double value)
        {
            double size = 0;
            size = (value * progressSize) / 100;
            return size;
        }

    }
}
