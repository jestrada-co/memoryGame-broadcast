using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace memoryGame_broadcast
{
    public partial class frmMain : Form
    {
        Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        Thread hiloReceiveData;
        string strCommand = "";
        string dirIp;
        string dirIpOponente;
        bool swReceiveData = true;
        bool starter = false;
        Image[,] matImages = new Image[6, 6];
        Button[,] matButtons = new Button[6, 6];
        int[,] matMatch = new int[6, 6];
        int num = 0;
        List<int> rango1 = new List<int>();
        List<int> rango2 = new List<int>();
        string tablero = "";
        int intPuertoDestino;
        int intIndice = 0;
        int x = 6;
        int y = 6;
        int puntajeYo = 0;
        int puntajeTu = 0;
        bool token;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                int intPuertoLocal;
                DialogResult TipoGame = MessageBox.Show("Desea realizar una simulación local del juego?", "Seleccinar tipo de Juego", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (TipoGame == DialogResult.Yes)
                {
                    string strPuerto = Microsoft.VisualBasic.Interaction.InputBox("Digite el No del Puerto Local...", "Configurar simulacón...", "9000");
                    intPuertoLocal = Convert.ToInt16(strPuerto);
                    strPuerto = Microsoft.VisualBasic.Interaction.InputBox("Digite el No del Puerto Destino...", "Configurar simulacón...", "9000");
                    intPuertoDestino = Convert.ToInt16(strPuerto);
                }
                else
                {
                    intPuertoLocal = 9000;
                    intPuertoDestino = 8000;
                }

                construirTablero();
                OcultarImages();
                sock.Bind(new IPEndPoint(obtenerIPLocal(), intPuertoLocal));
                sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
                hiloReceiveData = new Thread(receiveData);
                hiloReceiveData.Start();
            }
            catch (Exception error)
            {

            }
        }

        private IPAddress obtenerIPLocal()
        {
            IPHostEntry host;
            IPAddress localIP = null;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip;
                }
            }
            return localIP;
        }

        private void receiveData()
        {
            try
            {
                while (swReceiveData)
                {
                    IPEndPoint ipRemota = new IPEndPoint(IPAddress.Any, 0);
                    EndPoint ipRecibida = (EndPoint)ipRemota;
                    byte[] bytesRecibidos = new byte[256];
                    sock.ReceiveFrom(bytesRecibidos, bytesRecibidos.Length, SocketFlags.None, ref ipRecibida);
                    strCommand = Encoding.Default.GetString(bytesRecibidos);
                    dirIp = ((IPEndPoint)ipRecibida).Address.ToString();
                    ejecutor();
                }
            }
            catch (Exception error)
            {

            }
        }

        private void ejecutor()
        {
            int intCommand = Convert.ToInt16(strCommand.Substring(0, 1));

            if (intCommand == 0)
            {
                if (starter)
                {
                    strCommand = "1";
                }
                else
                {
                    DialogResult aceptarGame = MessageBox.Show("El jugador con IP " + dirIp + " te ha invitado a un Game. Deseas Aceptar?", "Invitación a un Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (aceptarGame == DialogResult.Yes)
                    {
                        token = false;
                        lblToken.Invoke(new EventHandler(establecerToken));
                        strCommand = "2";
                        dirIpOponente = dirIp;
                        starter = true;
                        randomImages();
                        strCommand = strCommand + tablero;
                    }
                    else
                    {
                        strCommand = "1";
                    }
                }
                enviarCommand();
            }
            else
            {
                if (intCommand == 1)
                {
                    MessageBox.Show("El jugador con IP " + dirIpOponente + " no aceptó la invitación o ya se encuentra jugando!", "Invitación a un Game",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (intCommand == 2)
                    {
                        starter = true;
                        dirIpOponente = dirIp;
                        MessageBox.Show("El jugador con IP " + dirIpOponente + " aceptó la invitación. Ahora es tu turno!", "Juego en curso...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        replicarRandomImages();
                        token = true;
                        lblToken.Invoke(new EventHandler(establecerToken));
                    }
                    else
                    {
                        if (intCommand == 3)
                        {
                            MessageBox.Show("El jugador "+ dirIpOponente + " canceló la partida. Tu ganas!","Game Over",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            starter = false;
                            strCommand = "3";
                            enviarCommand();
                            terminarApp();
                            Application.Exit();
                        }
                        else
                        {
                            if (intCommand == 4)
                            {
                                if(dirIpOponente.CompareTo(dirIp)== 0)
                                {
                                    jugada();
                                }
                            }
                            else
                            {
                                if (intCommand == 5)
                                {
                                    puntajeTu++;
                                    ganador();
                                    txtPlayers.Invoke(new EventHandler(imprimirEstadisticas));
                                    token = false;
                                    lblToken.Invoke(new EventHandler(establecerToken));
                                }
                                else
                                {
                                    if (intCommand == 6)
                                    {
                                        token = true;
                                        lblToken.Invoke(new EventHandler(establecerToken));
                                        matButtons[Convert.ToInt16(strCommand.Substring(1, 1)), Convert.ToInt16(strCommand.Substring(2, 1))].Image = imgListNone.Images[0];
                                        matButtons[Convert.ToInt16(strCommand.Substring(3, 1)), Convert.ToInt16(strCommand.Substring(4, 1))].Image = imgListNone.Images[0];
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void imprimirEstadisticas(object sender, EventArgs e)
        {
            txtPlayers.Text = "Mi Puntaje: " + puntajeYo.ToString();
            txtPlayers.Text = txtPlayers.Text + "\r\n" + "Oponente : " + puntajeTu.ToString();
        }

        private void establecerToken(object sender, EventArgs e)
        {
            if (token)
            {
                lblToken.BackColor = Color.Green;
                lblToken.Text = "Tu Turno";
            }
            else
            {
                lblToken.Text = "Espera...";
                lblToken.BackColor = Color.Red;
            }
        }

        private void jugada()
        {
            int i = Convert.ToInt16(strCommand.Substring(1, 1));
            int j = Convert.ToInt16(strCommand.Substring(2, 1));
            matButtons[i, j].Image = matImages[i, j];
        }


        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (starter)
            {
                DialogResult gameOver = MessageBox.Show("¿Desea terminar el juego y perder?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (gameOver == DialogResult.Yes)
                {
                    strCommand = "3";
                    enviarCommand();
                    terminarApp();
                    Application.Exit();
                }
            }
            else
            {
                terminarApp();
                Application.Exit();
            }
        }

        private void terminarApp()
        {
            swReceiveData = false;
            sock.Close();
            hiloReceiveData.Abort();
        }

        private void construirTablero()
        {
                int tabIndex = 1;
                int top = 13;
                int left = 0;

                for (int i = 0; i <= 5; i++)
                {
                    left = 13;
                    for (int j = 0; j <= 5; j++)
                    {
                        matButtons[i, j] = new Button();
                        matButtons[i, j].BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                        matButtons[i, j].Cursor = System.Windows.Forms.Cursors.Hand;
                        matButtons[i, j].FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
                        matButtons[i, j].FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                        matButtons[i, j].FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                        matButtons[i, j].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        matButtons[i, j].Location = new System.Drawing.Point(top, left);
                        matButtons[i, j].Name = i.ToString() + j.ToString();
                        matButtons[i, j].Size = new System.Drawing.Size(74, 74);
                        matButtons[i, j].TabIndex = tabIndex;
                        matButtons[i, j].UseVisualStyleBackColor = true;
                        matButtons[i, j].Click += new System.EventHandler(matButtons_Click);

                        panel1.Controls.Add(matButtons[i, j]);
                        tabIndex++;
                        left = left + 90;
                    }
                    top = top + 90;
                }
        }

        public void replicarRandomImages()
        {
            for (int i = 0; i <= 5; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    int numTemp = obtenerIndice();
                    matImages[i, j] = imgListGame1.Images[numTemp];
                    matMatch[i, j] = numTemp;
                }
            }
        }

        private int obtenerIndice()
        {
            intIndice++;
            string strTemp = strCommand.Substring(intIndice, 1);
            intIndice++;
            if (strCommand.Substring(intIndice,1).CompareTo("@") != 0)
            {
                strTemp=strTemp+ strCommand.Substring(intIndice, 1);
                intIndice++;
            }
            return (Convert.ToInt16(strTemp));
        }

        private void matButtons_Click(object sender, EventArgs e)
        {
            if (token)
            {
                Button b = (Button)sender;
                strCommand = "4" + b.Name;
                int i = Convert.ToInt16(b.Name.Substring(0, 1));
                int j = Convert.ToInt16(b.Name.Substring(1, 1));
                matButtons[i, j].Image = matImages[i, j];
                matButtons[i, j].Refresh();
                enviarCommand();

                if ((x != 6) && (y != 6))
                {
                    bool sw = true;
                    if ((x == i) && (y == j))
                    {
                        sw = false;
                    }
                    if ((matMatch[i, j] == matMatch[x, y]) && (sw))
                    {
                        token = true;
                        lblToken.Invoke(new EventHandler(establecerToken));
                        strCommand = "5";
                        puntajeYo++;
                        ganador();
                        txtPlayers.Invoke(new EventHandler(imprimirEstadisticas));

                    }
                    else
                    {
                        Thread.Sleep(1000);
                        matButtons[x, y].Image = imgListNone.Images[0];
                        matButtons[i, j].Image = imgListNone.Images[0];
                        strCommand = "6" + i.ToString() + j.ToString() + x.ToString() + y.ToString();
                        token = false;
                        lblToken.Invoke(new EventHandler(establecerToken));
                    }
                    enviarCommand();
                    x = 6;
                    y = 6;
                }
                else
                {
                    x = i;
                    y = j;
                }
            }
        }

        private void ganador()
        {
            int totalPuntos = puntajeTu + puntajeYo;
            if (totalPuntos == 18)
            {
                starter = false;
                if (puntajeYo > puntajeTu)
                {
                    MessageBox.Show("Eres el Ganador!"+"\r\n" + "Tu Puntaje: " + puntajeYo.ToString() + "\r\n" + "Tu Oponente: " + puntajeTu.ToString(),"Game Over",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (puntajeYo > puntajeTu)
                    {
                        MessageBox.Show("Eres el Perdedor!" + "\r\n" + "Tu Puntaje: " + puntajeYo.ToString() + "\r\n" + "Tu Oponente: " + puntajeTu.ToString(), "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Empate!" + "\r\n" + "Tu Puntaje: " + puntajeYo.ToString() + "\r\n" + "Tu Oponente: " + puntajeTu.ToString(), "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
                terminarApp();
            }
        }

        private void randomImages()
        {
            for (int i = 0; i<= 5; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    Random r = new Random();
                    if (rango1.Count >= 18)
                    {
                        num = 2;
                    }
                    else
                    {
                        if (rango2.Count >= 18)
                        {
                            num = 1;
                        }
                        else
                        {
                            num = r.Next(1, 3);
                        }
                    }

                    if (num == 1)
                    {
                        num = r.Next(0, 18);
                        while (rango1.Contains(num))// verificamos números repetidos
                        {
                            num = r.Next(0, 18);
                        }
                        rango1.Add(num);
                        matImages[i, j] = imgListGame1.Images[num];
                        matMatch[i, j] = num;
                        tablero = tablero + num.ToString() + "@";
                    }
                    else
                    {
                        if (num == 2)
                        {
                            num = r.Next(0, 18);
                            while (rango2.Contains(num))// verificamos números repetidos
                            {
                                num = r.Next(0, 18);
                            }
                            rango2.Add(num);
                            matImages[i, j] = imgListGame2.Images[num];
                            matMatch[i, j] = num;
                            tablero = tablero + num.ToString() + "@";
                        }
                    }
                }
            }
        }

        private void OcultarImages()
        {
            for (int i = 0; i <= 5; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    matButtons[i, j].Image = imgListNone.Images[0];
                }
            }
        }

        private void MostrarImages()
        {
            for (int i = 0; i <= 5; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    matButtons[i, j].Image = matImages[i, j];
                }
            }
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            if (!starter)
            {
                strCommand = "0";
                enviarCommand();
            }
        }

        private void enviarCommand()
        {
            try
            {
                IPEndPoint ipDestino = new IPEndPoint(IPAddress.Broadcast, intPuertoDestino);
                byte[] bytesEnviar = Encoding.Default.GetBytes(strCommand);
                sock.SendTo(bytesEnviar, bytesEnviar.Length, SocketFlags.None, ipDestino);
            }
            catch (Exception error)
            {

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (starter)
            {
                DialogResult gameOver = MessageBox.Show("¿Desea terminar el juego y perder?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (gameOver == DialogResult.Yes)
                {
                    strCommand = "3";
                    enviarCommand();
                    terminarApp();
                    Application.Exit();
                }
            }
            else
            {
                terminarApp();
                Application.Exit();
            }
        }
    }
}
