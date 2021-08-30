using System;
using IO = System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Words;
using System.Text;

namespace ServerDiplom.BusinessLogic
{
    public class ReadWriteDocs
    {
        public async Task<string> DocumentFormatReading(string documentName, string documentPath)
        {
            if (documentName.EndsWith(".txt"))
            {
                return await ReadTXT(documentPath);
            }
            else
            {
                return await Task.Run(() => ReadOther(documentPath));
            }
        }

        public async Task DocumentFormatReWriting(string documetnName, string documentPath, string documentContent)
        {
            if (documetnName.EndsWith(".txt"))
            {
                await IO.File.WriteAllTextAsync(documentPath, documentContent);
            }
            else
            {
                await Task.Run(() => ReWriteOther(documentPath, documentContent));
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
            string text = null;
            bool couldBeUtf8 = true;

            await Task.Run(() =>
            {
                byte[] bytes = IO.File.ReadAllBytes(documentPath);

                // Test UTF8 with BOM. This check can easily be copied and adapted
                // to detect many other encodings that use BOMs.
                UTF8Encoding encUtf8Bom = new UTF8Encoding(true, true);

                byte[] preamble = encUtf8Bom.GetPreamble();
                int prLen = preamble.Length;
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
                // fall back to windows-1251 encoding.
                if (encoding == null)
                {
                    encoding = Encoding.GetEncoding(1251);
                    text = encoding.GetString(bytes);
                }
            });

            return text;
        }

        //write doc, docx, rtf
        private void ReWriteOther(string documentPath, string documentContent)
        {
            Document doc = new Document(documentPath);

            foreach (var item in doc.GetChildNodes(NodeType.Paragraph, true))
            {
                item.Remove();
            }

            DocumentBuilder builder = new DocumentBuilder(doc);

            builder.Write(documentContent);

            doc.Save(documentPath);
        }
    }
}
