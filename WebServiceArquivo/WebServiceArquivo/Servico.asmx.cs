using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServiceArquivo
{    
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Servico : System.Web.Services.WebService
    {

        [WebMethod]
        public string UploadArquivo(String nomeDoArquivo, byte[] arquivoByte)
        {

            try
            {

                String arquivo = Server.MapPath("~/Arquivos/") + nomeDoArquivo;

                /*CRIANDO UM NOVO ARQUIVO E SALVANDO NO DIRETÓRIO ARQUIVOS*/
                System.IO.File.WriteAllBytes(arquivo, arquivoByte);


            }
            catch (Exception ex)
            {

                return "Erro ao realizar o Upload! (" + ex.Message + ")";

            }

            return "Upload realizado com sucesso!";





        }

        [WebMethod]
        public byte[] DownloadArquivo(String nomeDoArquivo)
        {

            /*PEGA O CAMINHO DO ARQUIVO*/
            String arquivo = Server.MapPath("~/Arquivos/") + nomeDoArquivo;

            /*ACESSANDO O ARQUIVO*/
            System.IO.FileStream fileStream = System.IO.File.Open(arquivo, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            /*CRIANDO E DEFININDO O TAMANHO DO OBJETO QUE VAMOS RETORNAR*/
            byte[] arquivoByte = new byte[fileStream.Length];

            /*LENDO O OBJETO STREAM E ADICIONANDO EM arquivoByte */
            fileStream.Read(arquivoByte, 0, Convert.ToInt32(fileStream.Length));

            /*FECHANDO O ARQUIVO*/
            fileStream.Close();


            return arquivoByte;

        }
    }
}
