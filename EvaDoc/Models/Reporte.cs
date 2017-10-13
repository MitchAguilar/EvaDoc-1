using EvaDoc.AccesoDato.Conexion;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace EvaDoc.Models
{
    public class Reporte
    {

        public string CrearPDF(string Usuario)
        {
            string nombre = "Reporte de Evaluación Documento";

            //Dirección del proyecto donde se va a guardar
            string file = nombre + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".pdf";
            //string file = "report1.pdf";
            string FilePath = HttpRuntime.AppDomainAppPath + @"\Documento\" + file;


            Document document = new Document(PageSize.LETTER, 80, 80, 80, 80);
            MemoryStream m = new MemoryStream();

            //********************** Encabezado *******************************
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(FilePath, FileMode.OpenOrCreate));
            writer.PageEvent = new HeaderFooter("Evaluación de Documentos".ToUpper());

            Paragraph texto = new Paragraph();
            texto.Alignment = Element.ALIGN_CENTER;
            texto.Font = FontFactory.GetFont("Verdana", 12);
            texto.Add("Reporte sobre los".ToUpper());

            Paragraph info = new Paragraph();
            info.Alignment = 1;
            info.Font = FontFactory.GetFont("Verdana", 12, Font.BOLD);
            //*********************** Encabezado *************************

            //******* abrir documento
            document.Open();



            //********* inicio portada**************
            for (int i = 0; i < 25; i++)
            {
                if (i == 0)
                {
                    document.Add(texto);
                    texto.RemoveAt(0);
                }
                else if (i == 1)
                {
                    texto.Add("Resultado de la evaluación de los documentos".ToUpper());
                    texto.Alignment = 1;
                    document.Add(texto);
                    texto.RemoveAt(0);
                }
                else if (i == 11)
                {
                    info.Add("Presentado Por:".ToUpper());
                    info.Alignment = 1;
                    document.Add(info);
                    document.Add(new Paragraph(" "));
                    info.RemoveAt(0);
                    texto.Add("Aplicación EvaDoc".ToUpper());
                    document.Add(texto);
                    texto.RemoveAt(0);
                }
                else if (i == 18)
                {
                    info.Add("Presentado Para:".ToUpper());
                    document.Add(new Paragraph(info));
                    info.RemoveAt(0);
                }
                else if (i == 19)
                {
                    texto.Add(Usuario.ToUpper());
                    document.Add(texto);
                    texto.RemoveAt(0);
                }
                else if (i == 24)
                {
                    info.Add(DateTime.Now.Year.ToString());
                    document.Add(info);
                }
                else
                {
                    document.Add(new Paragraph(" "));
                }
            }
            //********************** Cerrar Portada ********************
            Paragraph Nota = new Paragraph();
            Nota.Alignment = Element.ALIGN_RIGHT;
            Nota.Font = FontFactory.GetFont("Verdana", 18);

            document.NewPage();
            //********página de objetivos*********
            info.RemoveAt(0);
            info.Add("Resultados");
            document.Add(info);
            info.RemoveAt(0);
            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(" "));

            DataTable Consulta = new Documento().ConsultarDocumento();

            for (int i = 0; i < Consulta.Rows.Count; i++)
            {
                info.Add(("Titulo: " + Consulta.Rows[i]["DOC_TITULO"].ToString()).ToUpper());
                document.Add(info);
                info.RemoveAt(0);
                document.Add(new Paragraph(" "));
                texto.Add(("Actor: " + autor(Consulta.Rows[i]["DOC_AUTOR_1"].ToString())).ToUpper());
                texto.Alignment = 0;
                document.Add(texto);
                texto.RemoveAt(0);
                document.Add(new Paragraph(" "));
                texto.Add(("Actor: " + autor(Consulta.Rows[i]["DOC_AUTOR_2"].ToString())).ToUpper());
                texto.Alignment = 0;
                document.Add(texto);
                texto.RemoveAt(0);
                document.Add(new Paragraph(" "));
                string nota;
                if (new Datos().ConsultarDatos("select EVA_IDDOCUMENTO,avg(EVA_CALIFICACION) AS NOTA from evaluar group by EVA_IDDOCUMENTO having EVA_IDDOCUMENTO='" + Consulta.Rows[i]["IDDOCUMENTO"].ToString() + "';").Rows.Count>0)
                {
                    nota = new Datos().ConsultarDatos("select EVA_IDDOCUMENTO,avg(EVA_CALIFICACION) AS NOTA from evaluar group by EVA_IDDOCUMENTO having EVA_IDDOCUMENTO='" + Consulta.Rows[i]["IDDOCUMENTO"].ToString() + "';").Rows[0]["NOTA"].ToString();
                }
                else
                {
                    nota = "0";
                }
                
                Nota.Add("Nota: " +nota);
                document.Add(Nota);
                Nota.RemoveAt(0);
                document.Add(new Paragraph(" "));
               
                document.Add(Tablas(Consulta.Rows[i]["IDDOCUMENTO"].ToString()));
                document.Add(new Paragraph(" "));
                DataTable Consulta_evaluadores = new Datos().ConsultarDatos("select IDEVALUAR, EVA_CALIFICACION,CONCAT(PER_NOMBRE,' ',PER_APELLIDO) AS NOMBRE from evaluar inner join usuario on IDUSUARIO = EVA_EVALUADOR inner join persona on IDPERSONA = USU_IDPERSONA where EVA_IDDOCUMENTO = '" + Consulta.Rows[i]["IDDOCUMENTO"].ToString() + "'; ");
                for (int j = 0; j <Consulta_evaluadores.Rows.Count; j++)
                {
                    texto.Add("Evaluador: " + Consulta_evaluadores.Rows[j]["NOMBRE"].ToString());
                    texto.Alignment = 0;
                    document.Add(texto);
                    texto.RemoveAt(0);
                    document.Add(new Paragraph(" "));
                    document.Add(TablaDetalle(Consulta_evaluadores.Rows[j]["IDEVALUAR"].ToString()));
                    document.Add(new Paragraph(" "));
                }
                document.Add(new Paragraph(" "));
                document.NewPage();
            }
            //********fin página de req. información*********

            document.Close();

            //**********fin documento**************

             return file;
        }

        public PdfPTable Tablas(string documento)
        {
            DataTable Cons = new Datos().ConsultarDatos("select EVA_CALIFICACION,CONCAT(PER_NOMBRE,' ',PER_APELLIDO) AS NOMBRE from evaluar inner join usuario on IDUSUARIO = EVA_EVALUADOR inner join persona on IDPERSONA = USU_IDPERSONA where EVA_IDDOCUMENTO = '"+documento+"'; "); 
         

            PdfPTable objetivo = new PdfPTable(2);

            Phrase frase;
            PdfPCell celda = new PdfPCell();
            celda.Rowspan = 1;
            celda.Colspan = 1;
            celda.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell celda2 = new PdfPCell();
            celda2.Rowspan = 1;
            celda2.Colspan = 1;
            celda2.VerticalAlignment = Element.ALIGN_MIDDLE;


            //*****llenar plantilla********

            frase = new Phrase();
            frase.Font = FontFactory.GetFont("Verdana", 14, new BaseColor(0,0,225));
            frase.Add("Evaluaddor");
            celda.Phrase = frase;
            objetivo.AddCell(celda);

            frase = new Phrase();
            frase.Font = FontFactory.GetFont("Verdana", 14, new BaseColor(0, 0, 225));
            frase.Add("Calificación");
            celda2.Phrase = frase;
            objetivo.AddCell(celda2);

            for (int i = 0; i < Cons.Rows.Count; i++)
            {
                frase = new Phrase();
                frase.Font = FontFactory.GetFont("Verdana", 10);
                frase.Add(Cons.Rows[i]["NOMBRE"].ToString());
                celda.Phrase = frase;
                objetivo.AddCell(celda);

                frase = new Phrase();
                frase.Font = FontFactory.GetFont("Verdana", 10);
                frase.Add(Cons.Rows[i]["EVA_CALIFICACION"].ToString());
                celda2.Phrase = frase;
                objetivo.AddCell(celda2);
            }

            objetivo.WidthPercentage = 100;
            return objetivo;
        }

        public PdfPTable TablaDetalle(string idevaluar)
        {
            DataTable Cons = new Datos().ConsultarDatos("select IDCRITERIOS, CRI_DETALLE, EVADET_JUSIFICACION,EVADET_PUNTAJE from evaluardetalle inner join criterios on IDCRITERIOS=EVADET_IDCRITERIOS where EVADET_IDEVALUAR='"+idevaluar+ "' order by IDCRITERIOS;");

            PdfPTable objetivo = new PdfPTable(4);

            Phrase frase;
            PdfPCell celda = new PdfPCell();
            celda.Rowspan = 1;
            celda.Colspan = 1;
            celda.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell celda2 = new PdfPCell();
            celda2.Rowspan = 1;
            celda2.Colspan = 1;
            celda2.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell celda3 = new PdfPCell();
            celda3.Rowspan = 1;
            celda3.Colspan = 1;
            celda3.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell celda4 = new PdfPCell();
            celda4.Rowspan = 1;
            celda4.Colspan = 1;
            celda4.VerticalAlignment = Element.ALIGN_MIDDLE;
            //*****llenar plantilla********

            frase = new Phrase();
            frase.Font = FontFactory.GetFont("Verdana", 14, new BaseColor(0, 0, 225));
            frase.Add("N° Criterio");
            celda.Phrase = frase;
            objetivo.AddCell(celda);

            frase = new Phrase();
            frase.Font = FontFactory.GetFont("Verdana", 14, new BaseColor(0, 0, 225));
            frase.Add("Criterio");
            celda2.Phrase = frase;
            objetivo.AddCell(celda2);

            frase = new Phrase();
            frase.Font = FontFactory.GetFont("Verdana", 14, new BaseColor(0, 0, 225));
            frase.Add("Justificación");
            celda3.Phrase = frase;
            objetivo.AddCell(celda3);

            frase = new Phrase();
            frase.Font = FontFactory.GetFont("Verdana", 14, new BaseColor(0, 0, 225));
            frase.Add("Calificación");
            celda4.Phrase = frase;
            objetivo.AddCell(celda4);

            for (int i = 0; i < Cons.Rows.Count; i++)
            {
                frase = new Phrase();
                frase.Font = FontFactory.GetFont("Verdana", 10);
                frase.Add(Cons.Rows[i]["IDCRITERIOS"].ToString());
                celda.Phrase = frase;
                objetivo.AddCell(celda);

                frase = new Phrase();
                frase.Font = FontFactory.GetFont("Verdana", 10);
                frase.Add(Cons.Rows[i]["CRI_DETALLE"].ToString());
                celda2.Phrase = frase;
                objetivo.AddCell(celda2);

                frase = new Phrase();
                frase.Font = FontFactory.GetFont("Verdana", 10);
                frase.Add(Cons.Rows[i]["EVADET_JUSIFICACION"].ToString());
                celda3.Phrase = frase;
                objetivo.AddCell(celda3);

                frase = new Phrase();
                frase.Font = FontFactory.GetFont("Verdana", 10);
                frase.Add(Cons.Rows[i]["EVADET_PUNTAJE"].ToString());
                celda4.Phrase = frase;
                objetivo.AddCell(celda4);
            }

            objetivo.WidthPercentage = 100;
            return objetivo;
        }

        public string autor(string autor)
        {
            try
            {
                return new Usuario().ConsultarUsuarioId(autor).IDPERSONA.PER_NOMBRE + " " + new Usuario().ConsultarUsuarioId(autor).IDPERSONA.PER_APELLIDO;
            }
            catch 
            {
                return "Ninguno";
            }
        }
    }

    class HeaderFooter : IPdfPageEvent


    {
        PdfContentByte pdfContent;
        private string v;

        public HeaderFooter(string v)
        {
            this.v = v;
        }

        public void OnChapter(PdfWriter writer, Document document, float paragraphPosition, Paragraph title)
        {
        }

        public void OnChapterEnd(PdfWriter writer, Document document, float paragraphPosition)
        {
        }

        public void OnCloseDocument(PdfWriter writer, Document document)
        {
        }

        public void OnEndPage(PdfWriter writer, Document document)
        {
            //We are going to add two strings in header. Create separate Phrase object with font setting and string to be included
            Phrase p1Header = new Phrase("", FontFactory.GetFont("verdana", 8));
            Phrase p2Header = new Phrase(v, FontFactory.GetFont("verdana", 8));
            //create iTextSharp.text Image object using local image path
            iTextSharp.text.Image imgPDF = iTextSharp.text.Image.GetInstance(HttpRuntime.AppDomainAppPath + @"\Estilo\giecom.png");
            //imgPDF.Width = 10;
            imgPDF.ScaleAbsolute(55, 25);
            //Create PdfTable object
            PdfPTable pdfTab = new PdfPTable(3);
            //We will have to create separate cells to include image logo and 2 separate strings
            PdfPCell pdfCell1 = new PdfPCell(imgPDF);
            PdfPCell pdfCell2 = new PdfPCell(p1Header);
            PdfPCell pdfCell3 = new PdfPCell(p2Header);
            //set the alignment of all three cells and set border to 0
            pdfCell1.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell2.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell3.HorizontalAlignment = Element.ALIGN_RIGHT;
            pdfCell1.VerticalAlignment = Element.ALIGN_CENTER;
            pdfCell2.VerticalAlignment = Element.ALIGN_BOTTOM;

            pdfCell3.VerticalAlignment = Element.ALIGN_CENTER;

            pdfCell1.Border = 0;
            pdfCell2.Border = 0;
            pdfCell3.Border = 0;
            //add all three cells into PdfTable
            pdfTab.AddCell(pdfCell1);
            pdfTab.AddCell(pdfCell2);
            pdfTab.AddCell(pdfCell3);
            pdfTab.TotalWidth = document.PageSize.Width - 20;
            //call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
            //first param is start row. -1 indicates there is no end row and all the rows to be included to write
            //Third and fourth param is x and y position to start writing
            pdfTab.WriteSelectedRows(0, -1, 10, document.PageSize.Height - 15, writer.DirectContent);
            //set pdfContent value
            pdfContent = writer.DirectContent;
            //Move the pointer and draw line to separate header section from rest of page
            pdfContent.MoveTo(30, document.PageSize.Height - 40);
            pdfContent.LineTo(document.PageSize.Width - 20, document.PageSize.Height - 40);
            //We are going to add two strings in header. Create separate Phrase object with font setting and string to be included
            Phrase pie = new Phrase("Documento generado por EvaDoc", FontFactory.GetFont("verdana", 8));
            Phrase pie2 = new Phrase("Pagina  " + writer.PageNumber, FontFactory.GetFont("verdana", 8));
            //create iTextSharp.text Image object using local image path
            //imgPDF.Width = 10;
            //Create PdfTable object
            PdfPTable pdffo = new PdfPTable(2);
            //We will have to create separate cells to include image logo and 2 separate strings
            PdfPCell pdfCel2 = new PdfPCell(pie);
            PdfPCell pdfCel3 = new PdfPCell(pie2);
            //set the alignment of all three cells and set border to 0
            pdfCel2.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCel3.HorizontalAlignment = Element.ALIGN_RIGHT;
            pdfCel2.VerticalAlignment = Element.ALIGN_BOTTOM;

            pdfCel3.VerticalAlignment = Element.ALIGN_CENTER;

            pdfCel2.Border = 0;
            pdfCel3.Border = 0;
            //add all three cells into PdfTable
            pdffo.AddCell(pdfCel2);
            pdffo.AddCell(pdfCel3);
            pdffo.TotalWidth = document.PageSize.Width - 20;
            //call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
            //first param is start row. -1 indicates there is no end row and all the rows to be included to write
            //Third and fourth param is x and y position to start writing
            pdffo.WriteSelectedRows(0, -1, 10, (document.PageSize.Height - document.PageSize.Height) + 30, writer.DirectContent);
            //set pdfContent value
            pdfContent = writer.DirectContent;
            //Move the pointer and draw line to separate header section from rest of page
            //   pdfContent.MoveTo(30, document.PageSize.Height - 35);
            // pdfContent.LineTo(document.PageSize.Width - 20, document.PageSize.Height - 35);
            pdfContent.Stroke();

        }

        public void OnGenericTag(PdfWriter writer, Document document, Rectangle rect, string text)
        {
        }

        public void OnOpenDocument(PdfWriter writer, Document document)
        {
        }

        public void OnParagraph(PdfWriter writer, Document document, float paragraphPosition)
        {
        }

        public void OnParagraphEnd(PdfWriter writer, Document document, float paragraphPosition)
        {
        }

        public void OnSection(PdfWriter writer, Document document, float paragraphPosition, int depth, Paragraph title)
        {
        }

        public void OnSectionEnd(PdfWriter writer, Document document, float paragraphPosition)
        {
        }

        public void OnStartPage(PdfWriter writer, Document document)
        {
        }
    }
}