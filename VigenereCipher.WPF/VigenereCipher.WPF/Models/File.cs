using System.Text.RegularExpressions;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace VigenereCipher.WPF.Models.File
{
    public class File
    {
        private string text;
        public string Path { get; set; }
        public string SavePath { get; set; }
        public bool IsSaved { get; private set; }
        public string Text
        {
            get
            {
                if (text == null)
                {
                    text = string.Empty;
                }
                return text;
            }
            set
            {
                text = value;
                IsSaved = false;
            }
        }
        /// <summary>
        /// Метод, выполняющий сохранение файла
        /// </summary>
        /// <returns>Возвращает true, если файл сохранен успешно, false - неуспешно</returns>
        public bool Save()
        {
            try
            {
                if(Regex.IsMatch(this.SavePath, @".docx$"))
                {
                    using (var document = WordprocessingDocument.Create(this.SavePath, WordprocessingDocumentType.Document))
                    {
                        document.AddMainDocumentPart();
                        document.MainDocumentPart.Document = new Document(
                            new Body(new Paragraph(new Run(new Text(this.Text)))));
                    }
                    IsSaved = true;
                    return true;
                }
                else if(Regex.IsMatch(this.SavePath, @".txt$"))
                {
                    System.IO.File.WriteAllText(SavePath, Text);
                    IsSaved = true;
                    return true;
                }
                else
                {
                    IsSaved = false;
                    return false;
                }
            }
            catch
            {
                IsSaved = false;
                return false;
            }

        }
        /// <summary>
        /// Метод, выполняющий чтение файла
        /// </summary>
        /// <returns>Возвращает true, если файл прочитан успешно, false - неуспешно</returns>
        public bool Read()
        {
            try
            {
                if(Regex.IsMatch(this.Path, @".docx$"))
                {
                    using (var document = WordprocessingDocument.Open(this.Path, false))
                    {
                        Text = document.MainDocumentPart.Document.InnerText;
                    }
                    SavePath = Path;
                    IsSaved = true;
                    return true;
                }
                else if (Regex.IsMatch(this.Path, @".txt$"))
                {
                    Text = System.IO.File.ReadAllText(Path, System.Text.Encoding.UTF8);
                    SavePath = Path;
                    IsSaved = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
