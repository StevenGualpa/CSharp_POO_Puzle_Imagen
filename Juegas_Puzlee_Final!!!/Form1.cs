using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Juegas_Puzlee_Final___
{
    public partial class Form1 : Form
    {
        int f = 0;
        int c = 0;
        int num_fila = 0;
        int num_columnas = 0;
        Image[,] Trozos;
        Image Blanco;
        Image[,] Aletorio;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            picorigen.SizeMode = PictureBoxSizeMode.StretchImage;
            picorigen.BorderStyle = BorderStyle.FixedSingle;
            string ruta = @"Blanco.jpg";
            Blanco = Image.FromFile(ruta);
        }
        //Procedimiento que mostrara la Solucion
        void Mostrar_Solucion()
        {
            int tam_filas =Trozos[0,0].Height;
            int tam_columnas = Trozos[0, 0].Width;
            for (int i = 0; i < num_fila; i++)
            {
                for (int j = 0; j < num_columnas; j++)
                {
                    dgv_puzlee[j, i].Value = Trozos[i, j];
                    dgv_puzlee.Rows[i].Height = Trozos[0, 0].Height;
                    dgv_puzlee.Columns[j].Width = Trozos[0, 0].Width;
                    if (i == num_fila - 1 && j == num_columnas - 1)
                    {
                        dgv_puzlee[j, i].Value = Blanco;
                    }
                }
            }
            dgv_puzlee.Width = (Trozos[0, 0].Width * num_fila) + 5;
            dgv_puzlee.Height = (Trozos[0, 0].Height * num_columnas) + 5;
        }
        //Procedimiento Para Obtener Imagen
        void Obtner_Imagen()
        {

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string ruta = openFileDialog1.FileName;
                    picorigen.Image = Image.FromFile(ruta);
                }
            }
            catch
            {
                MessageBox.Show("Solo Imagenes");
            }
        }
        //Procedimento Para Cortar Imagen
        void Cortar_Imagen()
        {
            try
            {
                // Trocear una imagen en trozos más pequeños
                int columnas = num_columnas;
                int filas = num_fila;
                //
                // El tamaño proporcional del ancho y alto
                // correspondientes a los trozos a usar
                int tamW = (this.picorigen.ClientSize.Width / (columnas));
                int tamH = (picorigen.ClientSize.Height / (filas));
                // El tamaño de cada trozo
                int tamTrozoW = this.picorigen.Image.Width / columnas;
                int tamTrozoH = this.picorigen.Image.Height / filas;
                // El rectángulo que ocupará cada nuevo trozo
                Rectangle rectDest = new Rectangle(0, 0, tamW, tamH);
                // Estas variables se usan en el bucle
                Bitmap bmpDest;
                Graphics g;
                Rectangle rectOrig;
                //
                // Array con los pictures que hay en el formulario
                Image[] Partes = new Image[columnas * filas];
                // Para contar cada columna
                int c = 0;
                // La posición X e Y en la imagen original
                int pX = 0, pY = 0;
                for (int i = 0; i < Partes.Length; i++)
                {
                    // El trozo de la imagen original
                    rectOrig = new Rectangle(pX, pY, tamTrozoW, tamTrozoH);
                    // La imagen de destino
                    bmpDest = new Bitmap(tamW, tamH);
                    g = Graphics.FromImage(bmpDest);
                    // Obtenemos un trozo de la imagen original
                    // y lo dibujamos en la imagen de destino
                    g.DrawImage(picorigen.Image, rectDest, rectOrig, GraphicsUnit.Pixel);
                    // Asignamos la nueva imagen al picture correspondiente
                    Partes[i] = bmpDest;
                    c += 1;
                    pX += tamTrozoW;
                    // Cuando hayamos recorrido las columnas,
                    // pasamos a la siguiente fila
                    if (c >= columnas)
                    {
                        c = 0;
                        pX = 0;
                        pY += tamTrozoH;
                    }
                }
                int n = 0;
                Trozos = new Image[filas, columnas];
                Aletorio = new Image[filas, columnas];
                for (int i = 0; i < filas; i++)
                {
                    for (int j = 0; j < columnas; j++)
                    {
                        Trozos[i, j] = Partes[n];
                        n++;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Escoga un Imagen");
            }
        }


        //Procedimiento Para Crear Columnas y Filas en el Dgv
        void Generar_Columnas_Filas_Imagenes()
        {
            DataGridViewImageColumn colimag = new DataGridViewImageColumn();
            string nam = "C";
            if (dgv_puzlee.ColumnCount == 0)
            {
                dgv_puzlee.RowCount = num_fila;
                    for (int i = 0; i < num_columnas; i++)
                {
                    colimag = new DataGridViewImageColumn();
                    colimag.Name = (nam + i.ToString());
                    dgv_puzlee.Columns.Add(colimag);
                }
            }
            else
            {
                Limpiar_Dgv();
                dgv_puzlee.RowCount = num_fila;
                for (int i = 0; i < num_columnas; i++)
                {
                    colimag = new DataGridViewImageColumn();
                    colimag.Name = (nam + i.ToString());
                    dgv_puzlee.Columns.Add(colimag);
                }
            }
            dgv_puzlee.Columns.RemoveAt(0);
            dgv_puzlee.ColumnHeadersVisible = false;
            dgv_puzlee.RowHeadersVisible = false;
        }
        //Procedimiento Para Generar El Puzlle
        void Generar_Puzlee()
        {
            Random aleto = new Random();
            Image[] res_vec = new Image[num_fila * num_columnas];
            int n = 0;
            //Matriz a Vector
            for (int i = 0; i < num_fila; i++)
            {
                for (int j = 0; j < num_columnas; j++)
                {
                    res_vec[n] = Trozos[i, j]; n++;
                }
            }
            //Vector Aleatorio
            Image ultimo = res_vec[res_vec.Length - 1];
            Image[] vec_ale = new Image[num_fila * num_columnas];
            n = 0;
            int ele = 0;
            int banderita = 0;
            while (n < res_vec.Length - 1)
            {
                banderita = 0;
                ele = aleto.Next(0, vec_ale.Length - 1);
                vec_ale[n] = res_vec[ele];
                for (int k = 0; k <= n; k++)
                {
                    if (vec_ale[n] == vec_ale[k])
                    {
                        banderita++;
                    }
                }
                if (banderita > 1)
                {
                    n--;
                }
                else
                {
                    n++;
                }
            }
            n = 0;
            vec_ale[res_vec.Length - 1] = ultimo;//Ultimo elemento en Blanco
            for (int i = 0; i < num_fila; i++)
            {
                for (int j = 0; j < num_columnas; j++)
                {
                    Aletorio[i, j] = vec_ale[n];
                    n++;
                }
            }
        }
        //Procedimiento Para Mostrar Puzlee
        void Mostar_Puzlee()
        {
            int tam_filas = Trozos[0, 0].Height;
            int tam_columnas = Trozos[0, 0].Width;
            for (int i = 0; i < num_fila; i++)
            {
                for (int j = 0; j < num_columnas; j++)
                {
                    dgv_puzlee[j, i].Value = Aletorio[i, j];
                    dgv_puzlee.Rows[i].Height = Aletorio[0, 0].Height;
                    dgv_puzlee.Columns[j].Width = Aletorio[0, 0].Width;
                    if (i == num_fila - 1 && j == num_columnas - 1)
                    {
                        dgv_puzlee[j, i].Value = Blanco;
                    }
                }
            }
            dgv_puzlee.Width = (tam_columnas * num_columnas) + 5;
            dgv_puzlee.Height = (tam_filas * num_fila) + 5;
        }
        //Procedimiento Para Limpiar Dgv
        void Limpiar_Dgv()
        {
            int numcl = num_columnas;
            for (int i = 0; i <numcl; i++)
            {
                dgv_puzlee.Columns.RemoveAt(0);
            }
            dgv_puzlee.Rows.Clear();
        }
        bool Gano()
        {
            bool retorno = false;
            int ban = 0;
            for (int i = 0; i < num_fila; i++)
            {
                for (int j = 0; j < num_columnas; j++)
                {
                    if (dgv_puzlee[j, i].Value == Trozos[i, j])
                    {

                    }
                    else
                    {
                        ban++;
                    }
                }
            }
            if (ban == 1)
            {
                retorno = true;
            }
            else
            {
                retorno = false;
            }
            return retorno; 
        }

        //Botones
        private void btn_jugar_Click(object sender, EventArgs e)
        {
            bool ban = false;
            num_fila = Convert.ToInt32(numupdow_filas.Value);
            num_columnas = Convert.ToInt32(numupdow_columnas.Value);
            f = num_fila - 1;
            c = num_columnas - 1;
            try
            {
                Generar_Columnas_Filas_Imagenes();
                Cortar_Imagen();
               //Mostrar_Solucion();
                Generar_Puzlee();
               // Gano();
            }
            catch
            {
                ban = true;
            }
            if (!ban)
            {
               Mostar_Puzlee();

            }

        }
        private void btncarimgen_Click(object sender, EventArgs e)
        {
            Obtner_Imagen();   
        }
        //Evento Click Para Dgv
        private void dgv_puzlee_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Gano())
                {
                    int filadvg = dgv_puzlee.CurrentCell.RowIndex;
                    int columnadvg = dgv_puzlee.CurrentCell.ColumnIndex;
                    Image respaldo;
                    if (filadvg < num_fila - 1)//Blanco Arriba===>Pieza Abajo
                    {
                        if (dgv_puzlee[columnadvg, filadvg + 1].Value == Blanco)
                        {
                            respaldo = (Image)dgv_puzlee[columnadvg, filadvg].Value;
                            dgv_puzlee[columnadvg, filadvg].Value = Blanco;
                            dgv_puzlee[columnadvg, filadvg + 1].Value = respaldo;
                            f--;
                            // MessageBox.Show("( ͡° ͜ʖ ͡°)");
                        }
                    }
                    if (filadvg > 0)//Blanco Abajo===>Pieza Arriba
                    {
                        if (dgv_puzlee[columnadvg, filadvg - 1].Value == Blanco)
                        {
                            respaldo = (Image)dgv_puzlee[columnadvg, filadvg].Value;
                            dgv_puzlee[columnadvg, filadvg].Value = Blanco;
                            dgv_puzlee[columnadvg, filadvg - 1].Value = respaldo;
                            f++;
                        }
                    }
                    if (columnadvg < num_columnas - 1)//Derecha Blanco===>Izquierda Pieza
                    {
                        if (dgv_puzlee[columnadvg + 1, filadvg].Value == Blanco)
                        {
                            respaldo = (Image)dgv_puzlee[columnadvg, filadvg].Value;
                            dgv_puzlee[columnadvg, filadvg].Value = Blanco;
                            dgv_puzlee[columnadvg + 1, filadvg].Value = respaldo;
                            c--;
                        }
                    }
                    if (columnadvg > 0)//Izquieda Blanco===>Derecha Pieza
                    {
                        if (dgv_puzlee[columnadvg - 1, filadvg].Value == Blanco)
                        {
                            respaldo = (Image)dgv_puzlee[columnadvg, filadvg].Value;
                            dgv_puzlee[columnadvg, filadvg].Value = Blanco;
                            dgv_puzlee[columnadvg - 1, filadvg].Value = respaldo;
                            c++;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Gano ( ͡° ͜ʖ ͡°)", "Felicidades");
                }
            }
            catch
            {


            }

        }

        private void btnResultado_Click(object sender, EventArgs e)
        {
            try
            {
                Mostrar_Solucion();
            }
            catch
            {
               
            }
        }

        //Evento Para Teclas
        private void dgv_puzlee_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!Gano())
                {
                    Image respaldo;
                    if (e.KeyCode == Keys.Up)//Tecla Arriba===>Blanco Arriba===>Pieza Abajo
                    {
                        if (f > 0)
                        {
                            if (dgv_puzlee[c, f].Value == Blanco)
                            {
                                respaldo = (Image)dgv_puzlee[c, f - 1].Value;
                                dgv_puzlee[c, f].Value = respaldo;
                                dgv_puzlee[c, --f].Value = Blanco;
                            }
                        }
                    }
                    if (e.KeyCode == Keys.Down)//Tecla Abajo===>Abajo Blanco===>Pieza Arriba
                    {
                        if (f < num_fila - 1)
                        {
                            if (dgv_puzlee[c, f].Value == Blanco)
                            {
                                respaldo = (Image)dgv_puzlee[c, f + 1].Value;
                                dgv_puzlee[c, f].Value = respaldo;
                                dgv_puzlee[c, ++f].Value = Blanco;
                            }
                        }
                    }
                    if (e.KeyCode == Keys.Left)//Tecla Izquierda===>Izquierda Blanco===>Pieza Derecha
                    {
                        if (c > 0)
                        {
                            if (dgv_puzlee[c, f].Value == Blanco)
                            {
                                respaldo = (Image)dgv_puzlee[c - 1, f].Value;
                                dgv_puzlee[c, f].Value = respaldo;
                                dgv_puzlee[--c, f].Value = Blanco;
                            }
                        }
                    }
                    if (e.KeyCode == Keys.Right)//Tecla Derecha===>Derecha Blanco===>Izquierda Pieza
                    {
                        if (c < num_columnas - 1)
                        {
                            if (dgv_puzlee[c, f].Value == Blanco)
                            {
                                respaldo = (Image)dgv_puzlee[c + 1, f].Value;
                                dgv_puzlee[c, f].Value = respaldo;
                                dgv_puzlee[++c, f].Value = Blanco;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Gano ( ͡° ͜ʖ ͡°)","Felicidades");
                }
            }
            catch
            {

            }
        }

       
    }
}
