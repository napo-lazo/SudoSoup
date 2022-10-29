using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SudoSoup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudoSoup
{
    public class SudokuPDF : IDocument
    {

        private SudokuModel model;
        private Tuple<int, int> currentCell;
        private string title;
        private string[,] grid;

        public SudokuPDF(SudokuModel model)
        {
            this.model = model;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    this.title = "Sudoku";
                    this.grid = model.puzzle;

                    page.Margin(50);

                    page.Header().Element(ComposeHeader);
                    page.Content().Element(ComposeContent);
                    page.Footer().Element(ComposeFooter);

                })
                .Page(page =>
                {
                    this.title = "Solution";
                    this.grid = model.solution;

                    page.Margin(50);

                    page.Header().Element(ComposeHeader);
                    page.Content().Element(ComposeContent);
                    page.Footer().Element(ComposeFooter);

                });
        }

        private void ComposeHeader(IContainer container)
        {
            container.Inlined(inlined => 
            {
                TextStyle style = TextStyle.Default.FontSize(32);
                
                inlined.AlignCenter();

                inlined.Item().Text(this.title).Style(style);
            });
        } 

        private void ComposeFooter(IContainer container)
        {
            container.Inlined(inlined =>
            {
                TextStyle style = TextStyle.Default;

                inlined.AlignJustify();

                inlined.Item().Text($"Seed: {this.model.randomSeed}").Style(style);
                inlined.Item().Text("Sudoku generated with SudoSoup").Style(style);
            });
        }

        private void ComposeContent(IContainer container)
        {
            container
                .Element(ComposeTable);
        }

        private void ComposeTable(IContainer container)
        {
            container
                .AlignCenter()
                .AlignMiddle()
                .AspectRatio(1)
                .Table(table => 
                {
                    table.ColumnsDefinition(columns =>
                    {
                        for (int i = 0; i < 9; i++)
                            columns.RelativeColumn();
                    });

                    TextStyle style = TextStyle.Default.FontSize(24);

                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            this.currentCell = new Tuple<int, int>(i, j);
                            table.Cell().Row((uint)i + 1).Column((uint)j + 1).Element(CellStyle).Text(this.grid[i, j]).Style(style);
                        }
                    }
                });
        }

        private IContainer CellStyle(IContainer container)
        {
            bool verticalCondition = this.currentCell.Item2 % 3 == 0 && this.currentCell.Item2 != 0;
            bool horizontalCondition = this.currentCell.Item1 != 0 && this.currentCell.Item1 % 3 == 0;

            if (horizontalCondition && verticalCondition)
            {
                return container
                    .Border(1)
                    .BorderTop(3)
                    .BorderLeft(3)
                    .AspectRatio(1)
                    .AlignCenter()
                    .AlignMiddle();
            }
            else if (horizontalCondition)
            {
                return container
                    .Border(1)
                    .BorderTop(3)
                    .AspectRatio(1)
                    .AlignCenter()
                    .AlignMiddle();
            }
            else if (verticalCondition)
            {
                return container
                    .Border(1)
                    .BorderLeft(3)
                    .AspectRatio(1)
                    .AlignCenter()
                    .AlignMiddle();
            }

            return container
                    .Border(1)
                    .AspectRatio(1)
                    .AlignCenter()
                    .AlignMiddle();
        }

    }
}
