using System;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Collections.Generic;
using System.IO;

namespace TesteFramework1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream Fs = new FileStream("c://pdf/Relatório.pdf", FileMode.Create);
            Document doc = new Document(PageSize.A4);
            doc.SetMargins(1, 2, 3, 2);
            PdfWriter writer = PdfWriter.GetInstance(doc, Fs);
            doc.Open();
            PdfPTable table = new PdfPTable(8);

            Font fonte = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 12);

            Paragraph coluna1 = new Paragraph("Cod", fonte);
            Paragraph coluna2 = new Paragraph("Nome", fonte);
            Paragraph coluna3 = new Paragraph("Descrição", fonte);
            Paragraph coluna4 = new Paragraph("Qtd.", fonte);
            Paragraph coluna5 = new Paragraph("Marca", fonte);
            Paragraph coluna6 = new Paragraph("Custo Med.", fonte);
            Paragraph coluna7 = new Paragraph("Valor Total", fonte);
            Paragraph coluna8 = new Paragraph("Fornecedor", fonte);

            var cell1 = new PdfPCell();
            var cell2 = new PdfPCell();
            var cell3 = new PdfPCell();
            var cell4 = new PdfPCell();
            var cell5 = new PdfPCell();
            var cell6 = new PdfPCell();
            var cell7 = new PdfPCell();
            var cell8 = new PdfPCell();

            cell1.AddElement(coluna1);
            cell2.AddElement(coluna2);
            cell3.AddElement(coluna3);
            cell4.AddElement(coluna4);
            cell5.AddElement(coluna5);
            cell6.AddElement(coluna6);
            cell7.AddElement(coluna7);
            cell8.AddElement(coluna8);

            table.AddCell(cell1);
            table.AddCell(cell2);
            table.AddCell(cell3);
            table.AddCell(cell4);
            table.AddCell(cell5);
            table.AddCell(cell6);
            table.AddCell(cell7);
            table.AddCell(cell8);

            List<Relatorio> produtos = new List<Relatorio>();

            Relatorio produto1 = new Relatorio();
            produto1.Cod = 1;
            produto1.Nome = "Laptop";
            produto1.Descricao = "61";
            produto1.Qtd = 300;
            produto1.Marca = "Microsoft";
            produto1.CustoMedio = 5.16;
            produto1.ValorTotal = 1550.00;
            produto1.Fornecedor = "João";

            produtos.Add(produto1);

            foreach (var produto in produtos)
            {
                Phrase cod = new Phrase(produto.Cod.ToString());
                var cell = new PdfPCell(cod);
                table.AddCell(cell);

                Phrase nome = new Phrase(produto.Nome);
                cell = new PdfPCell(nome);
                table.AddCell(cell);

                Phrase descricao = new Phrase(produto.Descricao);
                cell = new PdfPCell(descricao);
                table.AddCell(cell);

                Phrase qtd = new Phrase(produto.Qtd.ToString());
                cell = new PdfPCell(qtd);
                table.AddCell(cell);

                Phrase marca = new Phrase(produto.Marca);
                cell = new PdfPCell(marca);
                table.AddCell(cell);

                Phrase ctmd = new Phrase(produto.CustoMedio.ToString());
                cell = new PdfPCell(ctmd);
                table.AddCell(cell);

                Phrase vtotal = new Phrase(produto.ValorTotal.ToString());
                cell = new PdfPCell(vtotal);
                table.AddCell(cell);

                Phrase fornecedor = new Phrase(produto.Fornecedor);
                cell = new PdfPCell(fornecedor);
                table.AddCell(cell);

                doc.Add(table);
                doc.Close();
            }
        }
    }
    public class Relatorio
    {
        public int Cod;
        public string Nome;
        public string Descricao;
        public int Qtd;
        public string Marca;
        public double CustoMedio;
        public double ValorTotal;
        public string Fornecedor;
    }
}
