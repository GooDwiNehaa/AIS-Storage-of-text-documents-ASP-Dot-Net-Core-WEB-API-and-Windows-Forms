using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Words;

namespace ClientDiplom.ClientLogic
{
    public class DocumentReader
    {
        public async Task<string> DocumentFormatReading(string documentName, string documentPath)
{
            if (documentName.EndsWith(DocumentFormats.TXT))
            {
                return await ReadTXT(documentPath);
            }
            else
            {
                return await Task.Run(() => ReadOther(documentPath));
            }
        }

        //read doc, docx, rtf
        private string ReadOther(string filePath)
        {
            Document doc = new Document(filePath);

            string text = doc.Document.GetText();

            return text;
        }

        //read txt
        private async Task<string> ReadTXT(string documentPath)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Encoding encoding = null;
            String text = null;
            Boolean couldBeUtf8 = true;

            await Task.Run(() =>
            {
                Byte[] bytes = File.ReadAllBytes(documentPath);

                // Test UTF8 with BOM. This check can easily be copied and adapted
                // to detect many other encodings that use BOMs.
                UTF8Encoding encUtf8Bom = new UTF8Encoding(true, true);

                Byte[] preamble = encUtf8Bom.GetPreamble();
                Int32 prLen = preamble.Length;
                if (bytes.Length >= prLen && preamble.SequenceEqual(bytes.Take(prLen)))
                {
                    // UTF8 BOM found; use encUtf8Bom to decode.
                    try
                    {
                        // Seems that despite being an encoding with preamble,
                        // it doesn't actually skip said preamble when decoding...
                        text = encUtf8Bom.GetString(bytes, prLen, bytes.Length - prLen);
                        encoding = encUtf8Bom;
                    }
                    catch (ArgumentException)
                    {
                        // Confirmed as not UTF-8!
                        couldBeUtf8 = false;
                    }
                }
                // use boolean to skip this if it's already confirmed as incorrect UTF-8 decoding.
                if (couldBeUtf8 && encoding == null)
                {
                    // test UTF-8 on strict encoding rules. Note that on pure ASCII this will
                    // succeed as well, since valid ASCII is automatically valid UTF-8.
                    UTF8Encoding encUtf8NoBom = new UTF8Encoding(false, true);
                    try
                    {
                        text = encUtf8NoBom.GetString(bytes);
                        encoding = encUtf8NoBom;
                    }
                    catch (ArgumentException)
                    {
                        // Confirmed as not UTF-8!
                    }
                }
                // fall back to default ANSI encoding.
                if (encoding == null)
                {
                    encoding = Encoding.GetEncoding(1251);
                    text = encoding.GetString(bytes);
                }
            });

            return text;
        }
    }
}
