using System;
using System.IO;
using System.Windows.Forms;

namespace Timbrado_Diverza
{
    public partial class Interface : Form
    {
        String seleccion="timbrar";
        public Interface()
        {
            InitializeComponent();
           
        }

        private void BuscarBtn_Click(object sender, EventArgs e)
        {
            //Muestra el dialogo para que seleccione el directorio
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //Pone el directorio dentro de la interface
                DirectorioSeleccionadoTxt.Text = folderBrowserDialog1.SelectedPath;
                /* Se forzo el orden en que selecciona los directorios,
                 * cuando selecciona un directorio para buscar entonces
                 * se habilita el boton que permite seleccionar el directorio 
                 * donde se almacenara el resultado*/
                SeleccionarBtn.Enabled = true;
            }
        }
        private bool GuardaArchivo(String nombre,String contenido)
        {
            var resultado = true;
            var directorio = DirectorioRegresoTxt.Text;
            try
            {
                //revisa si es error
                if (contenido.Length < 5)
                {
                    //comprueba si existe el subdirectorio de errores
                    if (Directory.Exists(directorio + "\\errores\\"))
                    {
                        File.WriteAllText(directorio + "\\errores\\" + nombre, contenido);
                    }
                    else
                    {
                        Directory.CreateDirectory(directorio + "\\errores\\");
                        File.WriteAllText(directorio + "\\errores\\"+ nombre, contenido);
                    }
                }
                else
                {
                    //si no es error escribe en el directorio especificado
                    File.WriteAllText(directorio + nombre, contenido);
                }
            }
            catch
            {
                //en caso de no poder escribir regresa error
                return false;
            }
            return resultado;
        }
        private bool GuardaArchivoInicial(String nombre, String contenido)
        {
            var resultado = true;
            var directorio = DirectorioSeleccionadoTxt.Text;
            try
            {
                
                    //si no es error escribe en el directorio especificado
                    File.WriteAllText(directorio + nombre, contenido);
            }
            catch
            {
                //en caso de no poder escribir regresa error
                return false;
            }
            return resultado;
        }

        private void SeleccionarBtn_Click(object sender, EventArgs e)
        {
            ProgresoTxt.Text = "";
            //Muestra el dialogo para que seleccione el directorio
            DialogResult result = folderBrowserDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                
                // El usuario selecciono el directorio.
                DirectorioRegresoTxt.Text = folderBrowserDialog2.SelectedPath;
                string[] archivosEnDirectorio = Directory.GetFiles(DirectorioSeleccionadoTxt.Text);
                int totalDeXML = Directory.GetFiles(DirectorioSeleccionadoTxt.Text.ToLower(), "*.xml").Length;
                
                //Revisa que existan archivos en el directorio seleccionado y que sean de tipo XML
                if (archivosEnDirectorio.Length > 0 && totalDeXML > 0 ){

                //Muestra mensaje de confirmación para continuar 
                DialogResult confirmacion = MessageBox.Show("¿Esta seguro de que quiere "+seleccion+" " + archivosEnDirectorio.Length.ToString() + " archivo(s)?", "Confirmación", MessageBoxButtons.YesNo);
                //Si el usuario confirma la operación
                    if (confirmacion == DialogResult.Yes)
                    {
                        //Usa todos los XML dentro del directorio seleccionado
                        foreach (String nombreArchivo in archivosEnDirectorio)
                        {
                            /* Busca el nombre del archivo sin 
                             * el camino al directorio donde se encuentra
                            */
                            var ultimoApartado = nombreArchivo.LastIndexOf('\\');
                            var nombreSoloArchivo = nombreArchivo.Substring(ultimoApartado);

                            //Mostrar progreso
                            ProgresoTxt.Text = ProgresoTxt.Text+"Procesando: " + nombreSoloArchivo + "\n " ;
                            //Variable que almacena lo que va a regresar el PAC
                            var respuesta="";
                            // Llama a la función implementada en el codigo del programa,
                            // dependiendo de la selección que se hizo en la interface.
                            if (seleccion ==  "timbrar")
                            {
                                //Parche para esquema de nomina
                                String archivo = Program.injectarEsquemaNomina(nombreArchivo);
                                GuardaArchivoInicial(nombreSoloArchivo, archivo);
                                //Timbrar un CFDi
                                respuesta = Program.Timbrar(nombreArchivo);
                                //Program.buzonFiscalTimbrado(nombreArchivo);
                            }
                            else
                            {//Cancelar un CFDi
                                respuesta = Program.Cancelar(nombreArchivo);
                                //Program.buzonFiscalCancelacion(nombreArchivo);
                            }
                            
                            //Revisa la respuesta
                            /* Si es de una longitud mayor de 5 caracteres
                             * significa que el servicio respondio correctamente
                             * y se tiene en la varibale del resultado el XML completo, si no
                             * el servicio marco un error y no se pudo realizar la 
                             * operación*/
                            if (respuesta.Length > 5 && ((seleccion == "timbrar" && !(respuesta.Contains("badgateway"))) || (seleccion == "cancelar")))
                            {
                                //Guarda el archivo ya timbrado
                                ProgresoTxt.Text =ProgresoTxt.Text+ "Guardando... \n " ;
                                //Busca el nombre actual del archivo

                                //Intenta guardar el archivo recibido con timbre con el mismo nombre
                                if (GuardaArchivo(nombreSoloArchivo, respuesta))
                                {
                                    //Reporta que el archivo si se pudo guardar
                                    ProgresoTxt.Text = ProgresoTxt.Text+"Exito! \n " ;
                                }
                                else
                                {
                                    //Marca que hubo error y no se pudo guardar el archivo
                                    ProgresoTxt.Text = ProgresoTxt.Text+"ERROR: No se pudo guardar el archivo "+nombreSoloArchivo+". \n " ;
                                }
                            }
                            else
                            {
                                //Informa de error
                                ProgresoTxt.Text = ProgresoTxt.Text+"ERROR: No se pudo "+seleccion+" el comprobante, revisar carpeta de errores.\n " ;
                                //Guarda archivo que tuvo error en una subcarpeta
                                GuardaArchivo(nombreSoloArchivo, respuesta);
                            }

                        }
                    }
                                  
                    ProgresoTxt.Text = ProgresoTxt.Text+"Proceso Terminado. \n " ;
                }else
                {
                    MessageBox.Show("No se encontraron archivos XML.\n Intente con otro directorio de busqueda.", "Error");
                }
            }
            
        }

        private void AyudaLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:ana.arellano@ixco.com.mx");
        }

        private void OperacionComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Define operaciones a usar en el servicio
            object opcionSeleccionada = OperacionComBox.SelectedItem;
            if(opcionSeleccionada.ToString().Equals("Timbrar")){
                seleccion = "timbrar";
            }else{
                seleccion = "cancelar";

            }
        }

        
    }
}
