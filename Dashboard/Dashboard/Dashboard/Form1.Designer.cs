
namespace Dashboard
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tempProcessBar = new CircularProgressBar.CircularProgressBar();
            this.Noti = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Nhietdo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Timelabel = new System.Windows.Forms.Label();
            this.grBoxControl = new System.Windows.Forms.GroupBox();
            this.grBoxSlave1 = new System.Windows.Forms.GroupBox();
            this.btn8Slave1 = new System.Windows.Forms.Button();
            this.btn7Slave1 = new System.Windows.Forms.Button();
            this.btn6Slave1 = new System.Windows.Forms.Button();
            this.btn5Slave1 = new System.Windows.Forms.Button();
            this.btn4Slave1 = new System.Windows.Forms.Button();
            this.btn3Slave1 = new System.Windows.Forms.Button();
            this.btn2Slave1 = new System.Windows.Forms.Button();
            this.btn1Slave1 = new System.Windows.Forms.Button();
            this.grBoxSlave2 = new System.Windows.Forms.GroupBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.btn2Slave2 = new System.Windows.Forms.Button();
            this.btn1Slave2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.baudCBB = new System.Windows.Forms.ComboBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.portCBB = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelInfo = new System.Windows.Forms.Panel();
            this.Datelabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.zalologo = new System.Windows.Forms.PictureBox();
            this.fblogo = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.swPicture = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.grBoxControl.SuspendLayout();
            this.grBoxSlave1.SuspendLayout();
            this.grBoxSlave2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panelInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zalologo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fblogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.swPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.tempProcessBar);
            this.groupBox1.Controls.Add(this.Noti);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Nhietdo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(298, 188);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(598, 120);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Display";
            // 
            // tempProcessBar
            // 
            this.tempProcessBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.tempProcessBar.AnimationSpeed = 500;
            this.tempProcessBar.BackColor = System.Drawing.Color.Transparent;
            this.tempProcessBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tempProcessBar.ForeColor = System.Drawing.Color.Tomato;
            this.tempProcessBar.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tempProcessBar.InnerMargin = 2;
            this.tempProcessBar.InnerWidth = -1;
            this.tempProcessBar.Location = new System.Drawing.Point(484, 15);
            this.tempProcessBar.MarqueeAnimationSpeed = 2000;
            this.tempProcessBar.Maximum = 50;
            this.tempProcessBar.Name = "tempProcessBar";
            this.tempProcessBar.OuterColor = System.Drawing.Color.Gray;
            this.tempProcessBar.OuterMargin = -25;
            this.tempProcessBar.OuterWidth = 26;
            this.tempProcessBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tempProcessBar.ProgressWidth = 15;
            this.tempProcessBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tempProcessBar.Size = new System.Drawing.Size(108, 105);
            this.tempProcessBar.StartAngle = 270;
            this.tempProcessBar.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.tempProcessBar.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.tempProcessBar.SubscriptText = "";
            this.tempProcessBar.SuperscriptColor = System.Drawing.Color.Tomato;
            this.tempProcessBar.SuperscriptMargin = new System.Windows.Forms.Padding(-25, 40, 0, 0);
            this.tempProcessBar.SuperscriptText = "°C";
            this.tempProcessBar.TabIndex = 4;
            this.tempProcessBar.Text = "0";
            this.tempProcessBar.TextMargin = new System.Windows.Forms.Padding(8, -5, 0, 0);
            this.tempProcessBar.Value = 5;
            // 
            // Noti
            // 
            this.Noti.AutoSize = true;
            this.Noti.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Noti.Location = new System.Drawing.Point(215, 36);
            this.Noti.Name = "Noti";
            this.Noti.Size = new System.Drawing.Size(157, 25);
            this.Noti.TabIndex = 3;
            this.Noti.Text = "Bạn chưa kết nối";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(363, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "°C";
            this.label5.Visible = false;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Nhietdo
            // 
            this.Nhietdo.AutoSize = true;
            this.Nhietdo.Location = new System.Drawing.Point(294, 73);
            this.Nhietdo.Name = "Nhietdo";
            this.Nhietdo.Size = new System.Drawing.Size(24, 25);
            this.Nhietdo.TabIndex = 1;
            this.Nhietdo.Text = "0";
            this.Nhietdo.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(192, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nhiệt độ:";
            this.label3.Visible = false;
            // 
            // Timelabel
            // 
            this.Timelabel.AutoSize = true;
            this.Timelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Timelabel.ForeColor = System.Drawing.Color.SpringGreen;
            this.Timelabel.Location = new System.Drawing.Point(70, 545);
            this.Timelabel.Name = "Timelabel";
            this.Timelabel.Size = new System.Drawing.Size(56, 25);
            this.Timelabel.TabIndex = 4;
            this.Timelabel.Text = "Time";
            // 
            // grBoxControl
            // 
            this.grBoxControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grBoxControl.Controls.Add(this.grBoxSlave1);
            this.grBoxControl.Controls.Add(this.grBoxSlave2);
            this.grBoxControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grBoxControl.Location = new System.Drawing.Point(298, 325);
            this.grBoxControl.Name = "grBoxControl";
            this.grBoxControl.Size = new System.Drawing.Size(598, 294);
            this.grBoxControl.TabIndex = 32;
            this.grBoxControl.TabStop = false;
            this.grBoxControl.Text = "Control";
            this.grBoxControl.Visible = false;
            // 
            // grBoxSlave1
            // 
            this.grBoxSlave1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grBoxSlave1.Controls.Add(this.btn8Slave1);
            this.grBoxSlave1.Controls.Add(this.btn7Slave1);
            this.grBoxSlave1.Controls.Add(this.btn6Slave1);
            this.grBoxSlave1.Controls.Add(this.btn5Slave1);
            this.grBoxSlave1.Controls.Add(this.btn4Slave1);
            this.grBoxSlave1.Controls.Add(this.btn3Slave1);
            this.grBoxSlave1.Controls.Add(this.btn2Slave1);
            this.grBoxSlave1.Controls.Add(this.btn1Slave1);
            this.grBoxSlave1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grBoxSlave1.Location = new System.Drawing.Point(40, 33);
            this.grBoxSlave1.Name = "grBoxSlave1";
            this.grBoxSlave1.Size = new System.Drawing.Size(230, 229);
            this.grBoxSlave1.TabIndex = 31;
            this.grBoxSlave1.TabStop = false;
            this.grBoxSlave1.Text = "Slave1";
            // 
            // btn8Slave1
            // 
            this.btn8Slave1.Location = new System.Drawing.Point(167, 125);
            this.btn8Slave1.Name = "btn8Slave1";
            this.btn8Slave1.Size = new System.Drawing.Size(41, 67);
            this.btn8Slave1.TabIndex = 7;
            this.btn8Slave1.UseVisualStyleBackColor = true;
            this.btn8Slave1.Click += new System.EventHandler(this.btn8Slave1_Click);
            // 
            // btn7Slave1
            // 
            this.btn7Slave1.Location = new System.Drawing.Point(122, 125);
            this.btn7Slave1.Name = "btn7Slave1";
            this.btn7Slave1.Size = new System.Drawing.Size(39, 67);
            this.btn7Slave1.TabIndex = 6;
            this.btn7Slave1.UseVisualStyleBackColor = true;
            this.btn7Slave1.Click += new System.EventHandler(this.btn7Slave1_Click);
            // 
            // btn6Slave1
            // 
            this.btn6Slave1.Location = new System.Drawing.Point(75, 125);
            this.btn6Slave1.Name = "btn6Slave1";
            this.btn6Slave1.Size = new System.Drawing.Size(41, 67);
            this.btn6Slave1.TabIndex = 5;
            this.btn6Slave1.UseVisualStyleBackColor = true;
            this.btn6Slave1.Click += new System.EventHandler(this.btn6Slave1_Click);
            // 
            // btn5Slave1
            // 
            this.btn5Slave1.Location = new System.Drawing.Point(30, 125);
            this.btn5Slave1.Name = "btn5Slave1";
            this.btn5Slave1.Size = new System.Drawing.Size(39, 67);
            this.btn5Slave1.TabIndex = 4;
            this.btn5Slave1.UseVisualStyleBackColor = true;
            this.btn5Slave1.Click += new System.EventHandler(this.btn5Slave1_Click);
            // 
            // btn4Slave1
            // 
            this.btn4Slave1.Location = new System.Drawing.Point(167, 40);
            this.btn4Slave1.Name = "btn4Slave1";
            this.btn4Slave1.Size = new System.Drawing.Size(41, 67);
            this.btn4Slave1.TabIndex = 3;
            this.btn4Slave1.UseVisualStyleBackColor = true;
            this.btn4Slave1.Click += new System.EventHandler(this.btn4Slave1_Click);
            // 
            // btn3Slave1
            // 
            this.btn3Slave1.Location = new System.Drawing.Point(122, 40);
            this.btn3Slave1.Name = "btn3Slave1";
            this.btn3Slave1.Size = new System.Drawing.Size(39, 67);
            this.btn3Slave1.TabIndex = 2;
            this.btn3Slave1.UseVisualStyleBackColor = true;
            this.btn3Slave1.Click += new System.EventHandler(this.btn3Slave1_Click);
            // 
            // btn2Slave1
            // 
            this.btn2Slave1.Location = new System.Drawing.Point(75, 40);
            this.btn2Slave1.Name = "btn2Slave1";
            this.btn2Slave1.Size = new System.Drawing.Size(41, 67);
            this.btn2Slave1.TabIndex = 1;
            this.btn2Slave1.UseVisualStyleBackColor = true;
            this.btn2Slave1.Click += new System.EventHandler(this.btn2Slave1_Click);
            // 
            // btn1Slave1
            // 
            this.btn1Slave1.Location = new System.Drawing.Point(30, 40);
            this.btn1Slave1.Name = "btn1Slave1";
            this.btn1Slave1.Size = new System.Drawing.Size(39, 67);
            this.btn1Slave1.TabIndex = 0;
            this.btn1Slave1.UseVisualStyleBackColor = true;
            this.btn1Slave1.Click += new System.EventHandler(this.btn1Slave1_Click);
            // 
            // grBoxSlave2
            // 
            this.grBoxSlave2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grBoxSlave2.Controls.Add(this.trackBar1);
            this.grBoxSlave2.Controls.Add(this.swPicture);
            this.grBoxSlave2.Controls.Add(this.btn2Slave2);
            this.grBoxSlave2.Controls.Add(this.btn1Slave2);
            this.grBoxSlave2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grBoxSlave2.Location = new System.Drawing.Point(342, 33);
            this.grBoxSlave2.Name = "grBoxSlave2";
            this.grBoxSlave2.Size = new System.Drawing.Size(233, 239);
            this.grBoxSlave2.TabIndex = 32;
            this.grBoxSlave2.TabStop = false;
            this.grBoxSlave2.Text = "Slave2";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(26, 157);
            this.trackBar1.Maximum = 9;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(184, 45);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.Visible = false;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // btn2Slave2
            // 
            this.btn2Slave2.Location = new System.Drawing.Point(136, 135);
            this.btn2Slave2.Name = "btn2Slave2";
            this.btn2Slave2.Size = new System.Drawing.Size(74, 67);
            this.btn2Slave2.TabIndex = 2;
            this.btn2Slave2.UseVisualStyleBackColor = true;
            this.btn2Slave2.Click += new System.EventHandler(this.btn2Slave2_Click);
            // 
            // btn1Slave2
            // 
            this.btn1Slave2.Location = new System.Drawing.Point(26, 135);
            this.btn1Slave2.Name = "btn1Slave2";
            this.btn1Slave2.Size = new System.Drawing.Size(74, 67);
            this.btn1Slave2.TabIndex = 1;
            this.btn1Slave2.UseVisualStyleBackColor = true;
            this.btn1Slave2.Click += new System.EventHandler(this.btn1Slave2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(562, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 24);
            this.label2.TabIndex = 37;
            this.label2.Text = "BAUD";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(270, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 24);
            this.label1.TabIndex = 36;
            this.label1.Text = "PORT";
            // 
            // baudCBB
            // 
            this.baudCBB.FormattingEnabled = true;
            this.baudCBB.Items.AddRange(new object[] {
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "74880",
            "115200"});
            this.baudCBB.Location = new System.Drawing.Point(629, 135);
            this.baudCBB.Name = "baudCBB";
            this.baudCBB.Size = new System.Drawing.Size(120, 21);
            this.baudCBB.TabIndex = 35;
            // 
            // connectBtn
            // 
            this.connectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.connectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectBtn.Location = new System.Drawing.Point(755, 125);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(141, 39);
            this.connectBtn.TabIndex = 34;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = false;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // portCBB
            // 
            this.portCBB.FormattingEnabled = true;
            this.portCBB.Location = new System.Drawing.Point(338, 135);
            this.portCBB.Name = "portCBB";
            this.portCBB.Size = new System.Drawing.Size(206, 21);
            this.portCBB.TabIndex = 33;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelInfo.Controls.Add(this.pictureBox2);
            this.panelInfo.Controls.Add(this.Timelabel);
            this.panelInfo.Controls.Add(this.Datelabel);
            this.panelInfo.Controls.Add(this.zalologo);
            this.panelInfo.Controls.Add(this.fblogo);
            this.panelInfo.Controls.Add(this.label12);
            this.panelInfo.Controls.Add(this.label11);
            this.panelInfo.Controls.Add(this.label10);
            this.panelInfo.Controls.Add(this.label9);
            this.panelInfo.Controls.Add(this.label8);
            this.panelInfo.Controls.Add(this.label7);
            this.panelInfo.Controls.Add(this.label6);
            this.panelInfo.Controls.Add(this.panel1);
            this.panelInfo.Location = new System.Drawing.Point(-3, -1);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(245, 647);
            this.panelInfo.TabIndex = 41;
            // 
            // Datelabel
            // 
            this.Datelabel.AutoSize = true;
            this.Datelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Datelabel.ForeColor = System.Drawing.Color.SpringGreen;
            this.Datelabel.Location = new System.Drawing.Point(32, 515);
            this.Datelabel.Name = "Datelabel";
            this.Datelabel.Size = new System.Drawing.Size(53, 25);
            this.Datelabel.TabIndex = 5;
            this.Datelabel.Text = "Date";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.SpringGreen;
            this.label12.Location = new System.Drawing.Point(46, 471);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(157, 25);
            this.label12.TabIndex = 49;
            this.label12.Text = "D17CQKD01-N";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.SpringGreen;
            this.label11.Location = new System.Drawing.Point(49, 446);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(145, 25);
            this.label11.TabIndex = 48;
            this.label11.Text = "N17DCDT042";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.SpringGreen;
            this.label10.Location = new System.Drawing.Point(8, 419);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(234, 25);
            this.label10.TabIndex = 47;
            this.label10.Text = "NGUYỄN HOÀNG LÂM";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.SpringGreen;
            this.label9.Location = new System.Drawing.Point(12, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(224, 25);
            this.label9.TabIndex = 45;
            this.label9.Text = "KỸ THUẬT GHÉP NỐI";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.SpringGreen;
            this.label8.Location = new System.Drawing.Point(96, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 25);
            this.label8.TabIndex = 44;
            this.label8.Text = "VÀ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.SpringGreen;
            this.label7.Location = new System.Drawing.Point(27, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(194, 25);
            this.label7.TabIndex = 43;
            this.label7.Text = "THIẾT BỊ NGOẠI VI";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label6.Location = new System.Drawing.Point(3, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(242, 29);
            this.label6.TabIndex = 42;
            this.label6.Text = "BÁO CÁO MÔN HỌC";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 123);
            this.panel1.TabIndex = 41;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel2.Controls.Add(this.label13);
            this.panel2.Location = new System.Drawing.Point(239, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(698, 120);
            this.panel2.TabIndex = 43;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label13.Location = new System.Drawing.Point(259, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(186, 39);
            this.label13.TabIndex = 38;
            this.label13.Text = "Dashboard";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Dashboard.Properties.Resources.TSV;
            this.pictureBox2.Location = new System.Drawing.Point(8, 262);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(228, 144);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // zalologo
            // 
            this.zalologo.Image = global::Dashboard.Properties.Resources.zalobwuse;
            this.zalologo.Location = new System.Drawing.Point(197, 590);
            this.zalologo.Name = "zalologo";
            this.zalologo.Size = new System.Drawing.Size(39, 40);
            this.zalologo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.zalologo.TabIndex = 51;
            this.zalologo.TabStop = false;
            this.zalologo.Click += new System.EventHandler(this.zalologo_Click);
            // 
            // fblogo
            // 
            this.fblogo.Image = global::Dashboard.Properties.Resources.fbwithoutfontuse;
            this.fblogo.Location = new System.Drawing.Point(146, 590);
            this.fblogo.Name = "fblogo";
            this.fblogo.Size = new System.Drawing.Size(39, 40);
            this.fblogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fblogo.TabIndex = 50;
            this.fblogo.TabStop = false;
            this.fblogo.Click += new System.EventHandler(this.fblogo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Dashboard.Properties.Resources.logoguse;
            this.pictureBox1.Location = new System.Drawing.Point(59, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(107, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // swPicture
            // 
            this.swPicture.Image = global::Dashboard.Properties.Resources.swL;
            this.swPicture.Location = new System.Drawing.Point(71, 40);
            this.swPicture.Name = "swPicture";
            this.swPicture.Size = new System.Drawing.Size(97, 54);
            this.swPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.swPicture.TabIndex = 3;
            this.swPicture.TabStop = false;
            this.swPicture.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(933, 641);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grBoxControl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.baudCBB);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.portCBB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grBoxControl.ResumeLayout(false);
            this.grBoxSlave1.ResumeLayout(false);
            this.grBoxSlave2.ResumeLayout(false);
            this.grBoxSlave2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zalologo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fblogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.swPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Noti;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Nhietdo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grBoxControl;
        private System.Windows.Forms.GroupBox grBoxSlave1;
        private System.Windows.Forms.Button btn4Slave1;
        private System.Windows.Forms.Button btn3Slave1;
        private System.Windows.Forms.Button btn2Slave1;
        private System.Windows.Forms.Button btn1Slave1;
        private System.Windows.Forms.GroupBox grBoxSlave2;
        private System.Windows.Forms.Button btn2Slave2;
        private System.Windows.Forms.Button btn1Slave2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox baudCBB;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.ComboBox portCBB;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.PictureBox swPicture;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label Timelabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn8Slave1;
        private System.Windows.Forms.Button btn7Slave1;
        private System.Windows.Forms.Button btn6Slave1;
        private System.Windows.Forms.Button btn5Slave1;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox zalologo;
        private System.Windows.Forms.PictureBox fblogo;
        private System.Windows.Forms.Label Datelabel;
        private CircularProgressBar.CircularProgressBar tempProcessBar;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

