using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace SpellCreator
{
    class Utils
    {
        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[()]", "", RegexOptions.CultureInvariant);
        }

        public static string ToOrdinal(int number)
        {
            if (number < 0) return number.ToString();
            long rem = number % 100;
            if (rem >= 11 && rem <= 13) return number + "th";

            switch (number % 10)
            {
                case 1:
                    return number + "st";
                case 2:
                    return number + "nd";
                case 3:
                    return number + "rd";
                default:
                    return number + "th";
            }
        }

        public static string GetTextFromRichTextBox(RichTextBox box)
        {
            return new TextRange(box.Document.ContentStart, box.Document.ContentEnd).Text;
        }

        public static void SetTextToRichTextBox(ref RichTextBox box, string text, bool clear = true)
        {
            if(clear)
                box.Document.Blocks.Clear();
            box.Document.Blocks.Add(new Paragraph(new Run(text)));
        }

        //public static void PrintText(RichTextBox richTB)
        //{
        //    PrintDialog pd = new PrintDialog();
        //    if ((pd.ShowDialog() == true))
        //    {
        //        //use either one of the below
        //        //pd.PrintVisual(richTB as Visual, "printing as visual");
        //        pd.PrintDocument((((IDocumentPaginatorSource)richTB.Document).DocumentPaginator), "printing as paginator");
        //    }
        //}

        public static string ExtractText(RichTextBox box)
        {
            // Create a FlowDocument to contain content for the RichTextBox.
            FlowDocument myFlowDoc = new FlowDocument();

            // Add initial content to the RichTextBox.
            box.Document = myFlowDoc;

            // Let's pretend the RichTextBox gets content magically ... 

            TextRange textRange = new TextRange(
                // TextPointer to the start of content in the RichTextBox.
                box.Document.ContentStart,
                // TextPointer to the end of content in the RichTextBox.
                box.Document.ContentEnd
            );

            // The Text property on a TextRange object returns a string
            // representing the plain text content of the TextRange.
            return textRange.Text;
        }
    }
}
