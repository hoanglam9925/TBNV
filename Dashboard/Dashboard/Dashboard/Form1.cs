using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Dashboard
{
    public partial class Form1 : Form
    {
        DateTime dateTime = DateTime.UtcNow.Date;
        string[] allPort;
        int modeSlave2 = 0;

        string usernname = "hoanglam";
        string password = "hoanglam123";

        string Slave1name = "A1";
        string Slave2name = "A2";
        string RFname = "R1";

        string rx = "";
        string prefix = "";
        string suffix = "";
        string device = "";
        string typeofdata = "";

        string[] A1LM35data = new string[2];
        string temperature = "";

        string tx = "";
        string A1data = "";
        string MAdata = "";


        int[] state = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] stateSlave2 = new int[2] { 0, 0 };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Get Port Name from PC add to portCBB
            allPort = SerialPort.GetPortNames();
            for (int i = 0; i < allPort.Length; i++)
            {
                portCBB.Items.Add(allPort[i]);
            }
            SetupTxData("R1", "AU1");
            
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)
            {
                if (this.portCBB.SelectedItem == null || this.baudCBB.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn Port và Baudrate", "Warning");
                }
                else
                {
                    /*Connect UART + Display*/
                    serialPort1.PortName = this.portCBB.SelectedItem.ToString();
                    serialPort1.BaudRate = Convert.ToInt32(this.baudCBB.SelectedItem.ToString());
                    serialPort1.Open();
                    connectBtn.BackColor = Color.FromArgb(255, 0, 0);
                    connectBtn.Text = "Disconnect";
                    Noti.Visible = true;
                    Noti.Text = "Vui lòng xác thực để mở bảng điều khiển!";
                    grBoxLogin.Location = new Point(400, 350);
                    grBoxLogin.Visible = true;
                    //Noti.Visible = false;
                    Noti.Location = new Point(115, 36);
                    //Gửi tín hiệu cho phép hoạt động đi
                    serialPort1.Write(tx);
                    label3.Visible = true;
                    label5.Visible = true;
                    Nhietdo.Visible = true;
                    tempProcessBar.Visible = true;
                    //grBoxControl.Visible = true;
                }
            }
            else
            {
                SetupTxData("R1", "AU3");
                serialPort1.Write(tx);
                serialPort1.Close();
                SetupTxData("R1", "AU1");
                connectBtn.BackColor = Color.FromArgb(0, 192, 0);
                connectBtn.Text = "Connect";
                Noti.Visible = true;
                Noti.Text = "Bạn chưa kết nối";
                Noti.Location = new Point(215, 36);
                grBoxControl.Visible = false;
                grBoxLogin.Visible = false;
                //Tín hiệu cho phép NFC hoạt động khi Connect sẽ được gửi đi
                label3.Visible = false;
                label5.Visible = false;
                Nhietdo.Visible = false;
                tempProcessBar.Visible = false;
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            rx = "";
            prefix = "";
            suffix = "";
            device = "";
            typeofdata = "";
            try
            {
                rx = serialPort1.ReadTo("\n");
            }
            catch(Exception)
            {

            }
            
            //Hàm nối thêm để tác động EventArgs (google)
            this.Invoke(new EventHandler(DoUpDate));
        }
        private void DoUpDate(object s, EventArgs e)
        {
            try
            {
                prefix = rx.Substring(0, 1);
                suffix = rx.Substring(rx.Length - 1, 1);
                device = rx.Substring(1, 2);
                typeofdata = rx.Substring(3, 2);  
            }
            catch (Exception)
            {
                
            }
            if ((string.Compare(prefix, "*") == 0) && (string.Compare(suffix, "#") == 0))
            {
                if (string.Compare(device, Slave1name) == 0)
                {
                    if (string.Compare(typeofdata, "LM") == 0)
                    {
                        A1LM35data[0] = rx.Substring(5, 2);
                        A1LM35data[1] = rx.Substring(7, 2);
                        temperature = "";
                        temperature = A1LM35data[0] + "." + A1LM35data[1];
                        Nhietdo.Text = temperature;
                        tempProcessBar.Text = temperature;
                        try
                        {
                            tempProcessBar.Value = Int32.Parse(A1LM35data[0]);
                        }
                        catch(Exception)
                        {
                            tempProcessBar.Value = 0;
                        }
                    }
                }
                else if (string.Compare(device, RFname) == 0)
                {
                    A1data = rx.Substring(5, 1);
                    if (string.Compare(typeofdata, "RF") == 0)
                    {
                        if (string.Compare(A1data, "1") == 0)
                        {
                            grBoxLogin.Visible = false;
                            grBoxControl.Visible = true;
                            Noti.Location = new Point(220, 36);
                            Noti.Text = "Hello Hoàng Lâm";
                            grBoxSlave1.Visible = true;
                            grBoxSlave2.Visible = true;
                            SetupTxData("R1", "AU0");
                            serialPort1.Write(tx);
                        }
                        else if(string.Compare(A1data, "2") == 0)
                        {
                            grBoxLogin.Visible = false;
                            grBoxControl.Visible = true;
                            Noti.Location = new Point(220, 36);
                            Noti.Text = "Hello Hoàng Lâm";
                            grBoxSlave1.Visible = true;
                            grBoxSlave2.Visible = false;
                            SetupTxData("R1", "AU0");
                            serialPort1.Write(tx);
                        }
                        else if(string.Compare(A1data, "3") == 0)
                        {
                            grBoxLogin.Visible = false;
                            grBoxControl.Visible = true;
                            Noti.Location = new Point(220, 36);
                            Noti.Text = "Hello Hoàng Lâm";
                            grBoxSlave1.Visible = false;
                            grBoxSlave2.Visible = true;
                            SetupTxData("R1", "AU0");
                            serialPort1.Write(tx);
                        }
                        else
                        {
                            grBoxControl.Visible = false;
                            grBoxSlave1.Visible = false;
                            grBoxSlave2.Visible = false;
                        }
                    }
                }
                else if (string.Compare(device, "MA") == 0)
                {
                    MAdata = rx.Substring(5, 1);
                    if (string.Compare(typeofdata, "DL") == 0)
                    {
                        if (string.Compare(MAdata, "1") == 0)
                        {
                            //grBoxSlave1.Visible = false;
                        }
                        else
                        {
                            //grBoxSlave1.Visible = true;
                           /* if(modeSlave2 == 0)
                            {
                                SetupTxData("A2", "L00");
                                serialPort1.Write(tx);
                            }    
                            else
                            {
                                SetupTxData(Slave2name, trackBar1.Value.ToString());
                                serialPort1.Write(tx);
                            }*/
                        }
                    }
                }
            }


        }
        private void SetupTxData(string Slave, string mode)
        {
            //*A1SWL11#
            int dataParse;
            tx = "";
            tx += "*";
            tx += Slave;
            if (string.Compare(Slave, RFname) == 0)
            {
                tx += "RF";
                tx += mode;
            }
            else if (string.Compare(Slave, Slave2name) == 0)
            {
                if (modeSlave2 == 1)
                {
                    dataParse = Int32.Parse(mode);
                    tx += "PW";
                    tx += (dataParse / 100).ToString();
                    tx += ((dataParse / 10) % 10).ToString();
                    tx += (dataParse % 10).ToString();
                }
                    
                else
                {
                    tx += "SW";
                    tx += mode;
                }
                    
            }
            else
            {
                tx += "SW";
                tx += mode;
            }

            tx += "#";
            
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btn1Slave1_Click(object sender, EventArgs e)
        {
            if (state[0] == 0)
            {
                SetupTxData(Slave1name, "L11");
                serialPort1.Write(tx);
                state[0] = 1;
                btn1Slave1.BackColor = Color.FromArgb(255, 128, 128);
            }
            else
            {
                SetupTxData(Slave1name, "L10");
                serialPort1.Write(tx);
                state[0] = 0;
                btn1Slave1.BackColor = Color.MediumSlateBlue;
            }
        }

        private void btn2Slave1_Click(object sender, EventArgs e)
        {
            if (state[1] == 0)
            {
                SetupTxData(Slave1name, "L21");
                serialPort1.Write(tx);
                state[1] = 1;
                btn2Slave1.BackColor = Color.FromArgb(255, 128, 128);
            }
            else
            {
                SetupTxData(Slave1name, "L20");
                serialPort1.Write(tx);
                state[1] = 0;
                btn2Slave1.BackColor = Color.MediumSlateBlue;
            }
        }

        private void btn3Slave1_Click(object sender, EventArgs e)
        {
            if (state[2] == 0)
            {
                SetupTxData(Slave1name, "L31");
                serialPort1.Write(tx);
                state[2] = 1;
                btn3Slave1.BackColor = Color.FromArgb(255, 128, 128);
            }
            else
            {
                SetupTxData(Slave1name, "L30");
                serialPort1.Write(tx);
                state[2] = 0;
                btn3Slave1.BackColor = Color.MediumSlateBlue;
            }
        }

        private void btn4Slave1_Click(object sender, EventArgs e)
        {
            if (state[3] == 0)
            {
                SetupTxData(Slave1name, "L41");
                serialPort1.Write(tx);
                state[3] = 1;
                btn4Slave1.BackColor = Color.FromArgb(255, 128, 128);
            }
            else
            {
                SetupTxData(Slave1name, "L40");
                serialPort1.Write(tx);
                state[3] = 0;
                btn4Slave1.BackColor = Color.MediumSlateBlue;
            }
        }

        private void btn1Slave2_Click(object sender, EventArgs e)
        {
            if(stateSlave2[0] == 0)
            {
                SetupTxData(Slave2name, "L11");
                serialPort1.Write(tx);
                //serialPort1.Write(tx);
                stateSlave2[0] = 1;
                btn1Slave2.BackColor = Color.Lime;
            }
            else
            {
                SetupTxData(Slave2name, "L10");
                serialPort1.Write(tx);
               // serialPort1.Write(tx);
                stateSlave2[0] = 0;
                btn1Slave2.BackColor = Color.MediumSlateBlue;
            }
           
        }

        private void btn2Slave2_Click(object sender, EventArgs e)
        {
            if (stateSlave2[1] == 0)
            {
                SetupTxData(Slave2name, "L21");
                serialPort1.Write(tx);
               // serialPort1.Write(tx);
                stateSlave2[1] = 1;
                btn2Slave2.BackColor = Color.Lime;
            }
            else
            {
                SetupTxData(Slave2name, "L20");
                serialPort1.Write(tx);
                //serialPort1.Write(tx);
                stateSlave2[1] = 0;
                btn2Slave2.BackColor = Color.MediumSlateBlue;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(modeSlave2 == 0)
            {
                swPicture.Image = Dashboard.Properties.Resources.swR;
                trackBar1.Visible = true;
                btn1Slave2.Visible = false;
                btn2Slave2.Visible = false;
                modeSlave2 = 1;
            }
            else
            {
                swPicture.Image = Dashboard.Properties.Resources.swL;
                trackBar1.Visible = false;
                btn1Slave2.Visible = true;
                btn2Slave2.Visible = true;
                modeSlave2 = 0;
                stateSlave2[0] = 1;
                stateSlave2[1] = 1;
                btn1Slave2.BackColor = Color.Lime;
                btn2Slave2.BackColor = Color.Lime;
                SetupTxData(Slave2name, "L00");
                serialPort1.Write(tx);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //int value = Convert.ToInt32(trackBar1.Value.ToString());
            SetupTxData(Slave2name, trackBar1.Value.ToString());
            serialPort1.Write(tx);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Timelabel.Text = DateTime.Now.ToString("T");
            Datelabel.Text = DateTime.Now.ToString("D");
        }

        private void btn5Slave1_Click(object sender, EventArgs e)
        {
            if (state[4] == 0)
            {
                SetupTxData(Slave1name, "L51");
                serialPort1.Write(tx);
                state[4] = 1;
                btn5Slave1.BackColor = Color.FromArgb(255, 128, 128);
            }
            else
            {
                SetupTxData(Slave1name, "L50");
                serialPort1.Write(tx);
                state[4] = 0;
                btn5Slave1.BackColor = Color.MediumSlateBlue;
            }
        }

        private void btn6Slave1_Click(object sender, EventArgs e)
        {
            if (state[5] == 0)
            {
                SetupTxData(Slave1name, "L61");
                serialPort1.Write(tx);
                state[5] = 1;
                btn6Slave1.BackColor = Color.FromArgb(255, 128, 128);
            }
            else
            {
                SetupTxData(Slave1name, "L60");
                serialPort1.Write(tx);
                state[5] = 0;
                btn6Slave1.BackColor = Color.MediumSlateBlue;
            }
        }

        private void btn7Slave1_Click(object sender, EventArgs e)
        {
            if (state[6] == 0)
            {
                SetupTxData(Slave1name, "L71");
                serialPort1.Write(tx);
                state[6] = 1;
                btn7Slave1.BackColor = Color.FromArgb(255, 128, 128);
            }
            else
            {
                SetupTxData(Slave1name, "L70");
                serialPort1.Write(tx);
                state[6] = 0;
                btn7Slave1.BackColor = Color.MediumSlateBlue;
            }
        }

        private void btn8Slave1_Click(object sender, EventArgs e)
        {
            if (state[7] == 0)
            {
                SetupTxData(Slave1name, "L81");
                serialPort1.Write(tx);
                state[7] = 1;
                btn8Slave1.BackColor = Color.FromArgb(255, 128, 128);
            }
            else
            {
                SetupTxData(Slave1name, "L80");
                serialPort1.Write(tx);
                state[7] = 0;
                btn8Slave1.BackColor = Color.MediumSlateBlue;
            }
        }

        private void fblogo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://facebook.com/shoanglams");
        }

        private void zalologo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://zalo.me/934062998");
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://hcm.ptit.edu.vn/");
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if(string.Compare(userNameTextBox.Text, usernname) == 0 && string.Compare(passwordTextBox.Text, password) == 0)
            {
                grBoxLogin.Visible = false;
                grBoxControl.Visible = true;
                userNameTextBox.Text = "";
                passwordTextBox.Text = "";
                Noti.Location = new Point(220, 36);
                Noti.Text = "Hello Hoàng Lâm";
                grBoxSlave1.Visible = true;
                grBoxSlave2.Visible = true;
                SetupTxData("R1", "AU2");
                serialPort1.Write(tx);
            }
            else
            {
                userNameTextBox.Text = "";
                passwordTextBox.Text = "";
                Noti.Text = "Bạn nhập sai thông tin đăng nhập";
            } 
                
        }
    }
}
