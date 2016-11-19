using Cohen.TCC.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Cohen.TCC.Web.Models
{
    public class Utils
    {

        #region CodificarSenha
        public string CodificarSenha(string cd_Senha)
        {
            TripleDESCryptoServiceProvider tripledescryptoserviceprovider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider md5cryptoserviceprovider = new MD5CryptoServiceProvider();

            try
            {
                if (cd_Senha.Trim() != "")
                {
                    string myKey = "@#$%¨&*()ASDF";  //Aqui você inclui uma chave qualquer para servir de base para cifrar, que deve ser a mesma no método Decodificar
                    tripledescryptoserviceprovider.Key = md5cryptoserviceprovider.ComputeHash(ASCIIEncoding.ASCII.GetBytes(myKey));
                    tripledescryptoserviceprovider.Mode = CipherMode.ECB;
                    ICryptoTransform desdencrypt = tripledescryptoserviceprovider.CreateEncryptor();
                    ASCIIEncoding MyASCIIEncoding = new ASCIIEncoding();

                    byte[] buff = Encoding.ASCII.GetBytes(cd_Senha);

                    return Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));

                }
                else
                {
                    return "";
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                tripledescryptoserviceprovider = null;
                md5cryptoserviceprovider = null;
            }

        }
        #endregion

        
        #region CriaSenha
        private const string SenhaCaracteresValidos = "abcdefghijklmnopqrstuvwxyz1234567890@#!?";

        public string CriaSenha()
        {
            int valormaximo = SenhaCaracteresValidos.Length;
            Random random = new Random(DateTime.Now.Millisecond);
            StringBuilder senha = new StringBuilder(10);
            for (int indice = 0; indice < 10; indice++)
                senha.Append(SenhaCaracteresValidos[random.Next(0, valormaximo)]);
            return senha.ToString();
        }
        #endregion


        #region enviaEmailSenha
        public string enviaEmailSenha(Cliente cliente, string nm_senha)
        {
            string retorno = "";
            try
            {


                string emailRemetente = "contato@wemoveu.com.br";
                string emailRemetenteSenha = "Ifg200?j";
                //string emailResposta = resposta;
                string emailDestinatario = cliente.nm_email;
                //string emailOculto = credencial[0].ToString();

                //crio objeto responsável pela mensagem de email

                MailMessage objEmail = new MailMessage();

                //rementente do email

                objEmail.From = new MailAddress(emailRemetente);

                //email para resposta(quando o destinatário receber e clicar em responder, vai para:)

                //objEmail.ReplyTo = new MailAddress(emailResposta);

                //destinatário(s) do email(s). Obs. pode ser mais de um, pra isso basta repetir a linha

                // objEmail.CC.Add(credencial[0].ToString());
                //abaixo com outro endereço

                objEmail.To.Add(emailDestinatario);
                objEmail.To.Add("contato@wemoveu.com.br");

                //se quiser enviar uma cópia oculta pra alguém, utilize a linha abaixo:

                //objEmail.Bcc.Add(emailOculto);

                //prioridade do email

                objEmail.Priority = MailPriority.Normal;

                //utilize true pra ativar html no conteúdo do email, ou false, para somente texto

                objEmail.IsBodyHtml = true;

                //Assunto do email

                objEmail.Subject = "Contato EstaciCar";

                //corpo do email a ser enviado

                objEmail.Body = "<html><body>Obrigado pelo cadastro<br><br> " +
                "<b>nome: " + cliente.nm_cliente + "<br>" +
                "<b>login: </b>" + cliente.nm_email + "<br>" +
                "<b>senha: </b>" + nm_senha+ "<br>";

                //codificação do assunto do email para que os caracteres acentuados serem reconhecidos.

                objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");

                //codificação do corpo do emailpara que os caracteres acentuados serem reconhecidos.

                objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

                //cria o objeto responsável pelo envio do email

                SmtpClient objSmtp = new SmtpClient();

                //endereço do servidor SMTP(para mais detalhes leia abaixo do código)

                // string[] variavel = credencial[0].Split('@');

                //string smtpHost = variavel[1].ToString();

                objSmtp.Host = "wemoveu.com.br";
                objSmtp.EnableSsl = false;
                objSmtp.Port = 587;

                //objSmtp.UseDefaultCredentials = true;

                //para envio de email autenticado, coloque login e senha de seu servidor de email

                //para detalhes leia abaixo do código

                objSmtp.Credentials = new NetworkCredential(emailRemetente, emailRemetenteSenha);

                try
                {
                    objSmtp.Send(objEmail);
                    retorno = "OK";

                }
                catch (Exception ex)
                {
                    retorno = ex.Message;
                }
                finally
                {
                    //excluímos o objeto de e-mail da memória
                    objEmail.Dispose();
                    //anexo.Dispose();
                }
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }

            return retorno;
        }
        #endregion




    }
}