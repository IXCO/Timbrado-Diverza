using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using ServicioTralix;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Timbrado_Diverza
{
    static class Program
    {
        /// <summary>
        /// Realiza el proceso de conectarse con el servicio de Diverza
        /// para solicitar timbre o cancelación oficial para los cfdi de nominas.
        /// </summary>
        
        private static byte[] Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return plainTextBytes;
        }
        public static Comprobante ObtenerComprobantes(String direccionFisica)
        {

            Comprobante comprobante = new Comprobante();

            try
            {

                XElement xelement = XElement.Load(direccionFisica);
                IEnumerable<XElement> elementos = xelement.Elements();
                String esSub;
                foreach (XElement Emisor in elementos)
                {
                    String esEmi;
                    esEmi = Emisor.Name.ToString();
                    if (esEmi.Contains("Emisor"))
                    {
                        comprobante.RFC = Emisor.Attribute("rfc").Value;
                    }
                    else if (esEmi.Contains("Receptor"))
                    {
                        comprobante.RFCRECEPTOR = Emisor.Attribute("rfc").Value;
                    }
                    else if (esEmi.Contains("Complemento"))
                    {
                        IEnumerable<XElement> subelem = Emisor.Elements();
                        foreach (XElement subElemento in subelem)
                        {
                            esSub = subElemento.Name.ToString();
                            if (esSub.Contains("TimbreFiscalDigital"))
                            {
                                comprobante.UUID = subElemento.Attribute("UUID").Value;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("ERROR: No se pudo leer el XML: " + direccionFisica);
            }

            return comprobante;
        }
        public static String injectarEsquemaNomina(String cfdi)
        {
            string cfd = File.ReadAllText(cfdi);
            int iniciaComprobante = cfd.IndexOf("cfdi:Comprobante");
            string primeraParte = cfd.Substring(0, iniciaComprobante + 16);
            string segundaParte = " xmlns:nomina=\"http://www.sat.gob.mx/nomina\" " + cfd.Substring(iniciaComprobante + 16, cfd.Length - (iniciaComprobante + 16));

            return primeraParte+segundaParte;
        }
        public static String Timbrar(String cfdi)
        {

            /* Lee el archivo que actualmente se esta procesando
             */
            string cfd = File.ReadAllText(cfdi);

            
            try
            {
                // Creamos una nueva instancia del objeto Webclient que utilizaremos para realizar la petición
                WebClient webClient = new WebClient();

                                
                webClient.Headers.Add("x-auth-token", token);
                webClient.Encoding = System.Text.Encoding.GetEncoding("UTF-8");
                // HTTP en este caso POST y el CFD como cuerpo del mensaje */
                
                string stamp = webClient.UploadString(urlTimbrado, "POST", cfd);
                //Regresa el resultado
                return stamp;
            }
            catch (WebException e)
            {
                /* En caso de error podemos obtener el codigo de estatus de la petición consultando la excepción que
                // arrojada por la instancia del web client. */
                HttpWebResponse httpWebResponse = ((HttpWebResponse)e.Response);
                return httpWebResponse.StatusCode.ToString();
            }



        }
        public static String Cancelar(String cfdi)
        {

            /* Lee el archivo que actualmente se esta procesando
             */
            Comprobante cfd = ObtenerComprobantes(cfdi);


            try
            {
                // Creamos una nueva instancia del objeto Webclient que utilizaremos para realizar la petición
                WebClient webClient = new WebClient();

                

                webClient.Headers.Add("x-auth-token", token);

                // HTTP en este caso POST y el CFD como cuerpo del mensaje */
               
                string stamp = webClient.UploadString(urlCancelacion+cfd.RFC+"/"+cfd.UUID, "POST");
                //Regresa el resultado
                return stamp;
            }
            catch (WebException e)
            {
                /* En caso de error podemos obtener el codigo de estatus de la petición consultando la excepción que
                // arrojada por la instancia del web client. */
                HttpWebResponse httpWebResponse = ((HttpWebResponse)e.Response);
                return httpWebResponse.StatusCode.ToString();
            }



        }
        /*
         * Servicio para buzon
         * no funcionales.
         */
        public static void buzonFiscalTimbrado(String cfdi)
        {
            string cfd = File.ReadAllText(cfdi);
            
            TimbradoDiverza.TimbradoCFDIClient cliente = new TimbradoDiverza.TimbradoCFDIClient("DIVERZA_TIMBRAR");
            cliente.ClientCredentials.UserName.UserName = " ";
            cliente.ClientCredentials.UserName.Password = " ";

            //cliente.ClientCredentials.ClientCertificate.Certificate.Import("C:\\Users\\ana\\Desktop\\Ana IXCO\\SAP\\DVZ_KIT Timbre Fiscal 3.2\\CERTIFICADO PAC DEMO\\20001000000100003992.cer", " ", X509KeyStorageFlags.DefaultKeySet); 
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
            cliente.Open();
               if(cliente.State == System.ServiceModel.CommunicationState.Opened ){
                   TimbradoDiverza.RequestTimbradoCFDType request = new TimbradoDiverza.RequestTimbradoCFDType();
                   TimbradoDiverza.DocumentoType documento = new TimbradoDiverza.DocumentoType();
                   documento.Archivo = Base64Encode(cfd);
                   documento.NombreArchivo = cfdi;
                    TimbradoDiverza.DocumentoTypeTipo tipo = new TimbradoDiverza.DocumentoTypeTipo();
                    
                   documento.Tipo = tipo;
                   documento.Version = "3.2";
                   TimbradoDiverza.InfoBasicaType basica = new TimbradoDiverza.InfoBasicaType();
                   basica.RfcEmisor = "AAA010101AAA";
                   basica.RfcReceptor = "DIA031002LZ2";
                   
                   request.Documento = documento;
                   request.InfoBasica = basica;
                   try
                   {
                       cliente.timbradoCFD(request);
                   }
                   catch (Exception EX)
                   {
                      
                       Console.WriteLine(EX.InnerException);
                   }


               }
               cliente.Close();
        }
        public static void buzonFiscalCancelacion(String cfdi)
        {
            string cfd = File.ReadAllText(cfdi);

            CancelacionDiverza.BuzonFiscalCorporativoPortClient cliente = new CancelacionDiverza.BuzonFiscalCorporativoPortClient("BuzonFiscalCorporativoPort");
            cliente.ClientCredentials.UserName.UserName = " ";
            cliente.ClientCredentials.UserName.Password = " ";

            //cliente.ClientCredentials.ClientCertificate.Certificate.Import("C:\\Users\\ana\\Desktop\\Ana IXCO\\SAP\\DVZ_KIT Timbre Fiscal 3.2\\CERTIFICADO PAC DEMO\\20001000000100003992.cer", " ", X509KeyStorageFlags.DefaultKeySet); 
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
            cliente.Open();
            if (cliente.State == System.ServiceModel.CommunicationState.Opened)
            {
                Comprobante cfdiACancelar = ObtenerComprobantes(cfdi);
                CancelacionDiverza.RequestCancelaCFDiType request = new CancelacionDiverza.RequestCancelaCFDiType();
                request.rfcEmisor = cfdiACancelar.RFC;
                request.rfcReceptor = cfdiACancelar.RFCRECEPTOR;
                request.uuid = cfdiACancelar.UUID;
                try
                {
                    
                   CancelacionDiverza.ResponseCancelaCFDiType response= cliente.cancelaCFDi(request);
                    
                }
                catch (Exception EX)
                {

                    Console.WriteLine(EX.InnerException);
                }


            }
            cliente.Close();
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Interface());
        }

    }
}
