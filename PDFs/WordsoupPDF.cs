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

namespace SudoSoup.PDFs
{
    class WordsoupPDF : IDocument
    {
        private WordsoupModel model;
        private string title;
        private string[,] grid;

        public WordsoupPDF(WordsoupModel model)
        {
            this.model = model;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    this.title = "Wordsoup";
                    this.grid = this.model.puzzle;

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
            container.Column(column =>
            {
                column.Spacing(20);
                column.Item().Element(ComposeTable);
                column.Item().PaddingHorizontal(10).Element(ComposeWordList);
            }); 
        }

        private void ComposeWordList(IContainer container)
        {
            container
                .AlignCenter()
                .AlignMiddle()
                .MinHeight(100)
                .Padding(10)
                .Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        for (int i = 0; i < 3; i++)
                            columns.RelativeColumn();
                    });

                    TextStyle style = TextStyle.Default.FontSize(18);

                    foreach(string word in this.model.wordList)
                    {
                        table.Cell().Text(word).Style(style);
                    }
                });
        }

        private void ComposeTable(IContainer container)
        {
            container
                .AlignCenter()
                .AlignMiddle()
                .Border(1)
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
                            table.Cell().Row((uint)i + 1).Column((uint)j + 1).Element(CellStyle).Text(this.grid[i, j]).Style(style);
                        }
                    }
                });
        }

        private IContainer CellStyle(IContainer container)
        {
            return container
                    .AspectRatio(1)
                    .AlignCenter()
                    .AlignMiddle();
        }
    }
}
