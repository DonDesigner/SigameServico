using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositorios
{
    public class ImagensRepositorios
    {
        public void SalvarImagens(Stream strem, string file_name)
        {
            byte[] content;
           
            using (BinaryReader br = new BinaryReader(strem))
            {
                content = br.ReadBytes(500000);
                br.Close();
            }

            FileStream fs = new FileStream(file_name, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);

            try
            {
                bw.Write(content);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                fs.Close();
                bw.Close();
            }
        }
    }
}
