
using Docnet.Core;
using Docnet.Core.Models;

namespace MyVideoResume.Documents;

public interface IDocumentProcessor
{

    string PdfToString(System.IO.Stream stream);
    string JSONToString(System.IO.Stream stream);
}

public class DocumentProcessor : IDocumentProcessor
{
    public string JSONToString(Stream stream)
    {
        var result = string.Empty;
        using (StreamReader reader = new StreamReader(stream))
        {
            result = reader.ReadToEnd();
        }
        return result;
    }

    public string PdfToString(Stream stream)
    {
        var result = string.Empty;
        using (IDocLib lib = DocLib.Instance)
        {
            byte[] bytes;
            List<byte> totalStream = new();
            byte[] buffer = new byte[32];
            int read;
            while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                totalStream.AddRange(buffer.Take(read));
            }
            bytes = totalStream.ToArray();
            using var docReader = lib.GetDocReader(bytes, new PageDimensions());
            for (var i = 0; i < docReader.GetPageCount(); i++)
            {
                using (var pageReader = docReader.GetPageReader(i))
                {
                    result += pageReader.GetText();
                }
            }
        }

        return result;
    }
}
