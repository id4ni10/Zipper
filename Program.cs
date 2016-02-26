using System.IO;

public class Program
{
    static int Main(string[] args)
    {
        var zip = ZipFiles(_pack);

        File.WriteAllBytes(@"..\file.rar", zip);

        return 0;
    }

    public byte[] ZipFiles(Dictionary<string, byte[]> arquivos)
    {
        try
        {
            using (var zip = new ZipFile())
            {
                foreach (var filename in arquivos.Keys)
                {
                    zip.AddEntry(filename, arquivos[filename]);
                }

                zip.Comment = String.Format("Este arquivo foi gerado por: 'Person'\n'{0}'",
                   System.Net.Dns.GetHostName());

                var ms = new MemoryStream();
                zip.Save(ms);

                return ms.ToArray();
            }
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
    }
}