using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Messaging;
using System.Net;


/// <summary>
/// Summary description for MSMQHelper.
/// </summary>
public class MSMQHelper : System.Windows.Forms.Form
{
	private System.Windows.Forms.GroupBox groupBox1;
	private System.Windows.Forms.GroupBox groupBox3;
	private System.Windows.Forms.GroupBox gpTimeToReach;
	private System.Windows.Forms.TextBox txtTimeToReach;
	private System.Windows.Forms.GroupBox gbTimeToRead;
	private System.Windows.Forms.TextBox txtTimeToBeReceived;
	private System.Windows.Forms.GroupBox groupBox5;
	private System.Windows.Forms.CheckBox cbAttrib01;
	private System.Windows.Forms.CheckBox cbAttrib02;
	private System.Windows.Forms.CheckBox cbAttrib03;
	private System.Windows.Forms.CheckBox cbAttrib04;
	private System.Windows.Forms.CheckBox cbAttrib05;
	private System.Windows.Forms.CheckBox cbAttrib06;
	private System.Windows.Forms.CheckBox cbAttrib07;
	private System.Windows.Forms.TextBox txtSrvQueueName;
	private System.Windows.Forms.TextBox txtCliAdminQueueName;
	private System.Windows.Forms.Button cmdSendMessage;

	// Container para a lista de combobox
	private CheckBox [] _acklist = null;
	private AcknowledgeTypes [] _ackValueList = null;
	private AcknowledgeTypes _ackMask = 0;

	private System.Windows.Forms.GroupBox gbAckResult;
	private System.Windows.Forms.GroupBox groupBox4;
	private System.Windows.Forms.TextBox txtCliQueueName;
	private System.Windows.Forms.Button cmdAnswerMessage;
	private System.Windows.Forms.TextBox txtSrvAdminQueueName;
	private System.Windows.Forms.GroupBox groupBox7;
	private System.Windows.Forms.GroupBox groupBox8;
	private System.Windows.Forms.TextBox txtTimeToReachClient;
	private System.Windows.Forms.GroupBox groupBox9;
	private System.Windows.Forms.TextBox txtTimeToBeReceivedClient;
	private System.Windows.Forms.GroupBox groupBox10;
	private System.Windows.Forms.TextBox txtSrvName;
	private System.Windows.Forms.GroupBox groupBox6;
	private System.Windows.Forms.GroupBox groupBox2;
	private System.Windows.Forms.GroupBox groupBox11;
	private System.Windows.Forms.RadioButton radioButton1;
	private System.Windows.Forms.RadioButton radioButton2;
	private System.Windows.Forms.Button cmdCriaFilas;
	private System.Windows.Forms.GroupBox groupBox12;
	private System.Windows.Forms.TextBox txtQtdMsgs;
    private GroupBox groupBox13;
    private TextBox txtMsgsxs;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new MSMQHelper());
	}

	public MSMQHelper()
	{
		InitializeComponent();

		// Indexa a lista de opções de combobox
		_acklist = (CheckBox[])Array.CreateInstance( typeof(CheckBox), 7 ) ;
		_acklist[0] = cbAttrib01;
		_acklist[1] = cbAttrib02;
		_acklist[2] = cbAttrib03;
		_acklist[3] = cbAttrib04;
		_acklist[4] = cbAttrib05;
		_acklist[5] = cbAttrib06;
		_acklist[6] = cbAttrib07;

		for( int i=0; i< _acklist.Length; i++ )
			_acklist[i].CheckedChanged += new System.EventHandler(this.cbAttrib_CheckedChanged);

		_ackValueList = new AcknowledgeTypes[7] {	AcknowledgeTypes.FullReachQueue,
									   AcknowledgeTypes.FullReceive,
									   AcknowledgeTypes.NegativeReceive,
									   AcknowledgeTypes.NotAcknowledgeReachQueue,
									   AcknowledgeTypes.NotAcknowledgeReceive,
									   AcknowledgeTypes.PositiveArrival,
									   AcknowledgeTypes.PositiveReceive };
	
		SetResultAck();
	}

	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
	protected override void Dispose( bool disposing )
	{
		if( disposing )
		{
			if (components != null) 
			{
				components.Dispose();
			}
		}
		base.Dispose( disposing );
	}

	#region Windows Form Designer generated code
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.txtSrvName = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtTimeToReachClient = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtTimeToBeReceivedClient = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtSrvAdminQueueName = new System.Windows.Forms.TextBox();
            this.cmdAnswerMessage = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtCliQueueName = new System.Windows.Forms.TextBox();
            this.cmdSendMessage = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.gpTimeToReach = new System.Windows.Forms.GroupBox();
            this.txtTimeToReach = new System.Windows.Forms.TextBox();
            this.gbTimeToRead = new System.Windows.Forms.GroupBox();
            this.txtTimeToBeReceived = new System.Windows.Forms.TextBox();
            this.gbAckResult = new System.Windows.Forms.GroupBox();
            this.cbAttrib07 = new System.Windows.Forms.CheckBox();
            this.cbAttrib06 = new System.Windows.Forms.CheckBox();
            this.cbAttrib05 = new System.Windows.Forms.CheckBox();
            this.cbAttrib04 = new System.Windows.Forms.CheckBox();
            this.cbAttrib03 = new System.Windows.Forms.CheckBox();
            this.cbAttrib02 = new System.Windows.Forms.CheckBox();
            this.cbAttrib01 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSrvQueueName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCliAdminQueueName = new System.Windows.Forms.TextBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.cmdCriaFilas = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.txtQtdMsgs = new System.Windows.Forms.TextBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.txtMsgsxs = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gpTimeToReach.SuspendLayout();
            this.gbTimeToRead.SuspendLayout();
            this.gbAckResult.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox10);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.cmdAnswerMessage);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.cmdSendMessage);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.gbAckResult);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(10, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 517);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.txtSrvName);
            this.groupBox10.Location = new System.Drawing.Point(19, 9);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(135, 46);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Srv Name";
            // 
            // txtSrvName
            // 
            this.txtSrvName.Location = new System.Drawing.Point(10, 18);
            this.txtSrvName.Name = "txtSrvName";
            this.txtSrvName.Size = new System.Drawing.Size(115, 22);
            this.txtSrvName.TabIndex = 0;
            this.txtSrvName.Text = "localhost";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.groupBox8);
            this.groupBox7.Controls.Add(this.groupBox9);
            this.groupBox7.Location = new System.Drawing.Point(18, 430);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(317, 74);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Timers";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtTimeToReachClient);
            this.groupBox8.Location = new System.Drawing.Point(10, 18);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(134, 47);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Time to Reach";
            // 
            // txtTimeToReachClient
            // 
            this.txtTimeToReachClient.Location = new System.Drawing.Point(10, 18);
            this.txtTimeToReachClient.Name = "txtTimeToReachClient";
            this.txtTimeToReachClient.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTimeToReachClient.Size = new System.Drawing.Size(115, 22);
            this.txtTimeToReachClient.TabIndex = 0;
            this.txtTimeToReachClient.Text = "0";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.txtTimeToBeReceivedClient);
            this.groupBox9.Location = new System.Drawing.Point(163, 18);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(135, 47);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Time to Read";
            // 
            // txtTimeToBeReceivedClient
            // 
            this.txtTimeToBeReceivedClient.Location = new System.Drawing.Point(10, 18);
            this.txtTimeToBeReceivedClient.Name = "txtTimeToBeReceivedClient";
            this.txtTimeToBeReceivedClient.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTimeToBeReceivedClient.Size = new System.Drawing.Size(115, 22);
            this.txtTimeToBeReceivedClient.TabIndex = 0;
            this.txtTimeToBeReceivedClient.Text = "60000";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtSrvAdminQueueName);
            this.groupBox6.Location = new System.Drawing.Point(320, 9);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(170, 46);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Srv Admin Queue";
            // 
            // txtSrvAdminQueueName
            // 
            this.txtSrvAdminQueueName.Location = new System.Drawing.Point(10, 18);
            this.txtSrvAdminQueueName.Name = "txtSrvAdminQueueName";
            this.txtSrvAdminQueueName.Size = new System.Drawing.Size(153, 22);
            this.txtSrvAdminQueueName.TabIndex = 0;
            this.txtSrvAdminQueueName.Text = "private$\\adminserver";
            // 
            // cmdAnswerMessage
            // 
            this.cmdAnswerMessage.Location = new System.Drawing.Point(344, 449);
            this.cmdAnswerMessage.Name = "cmdAnswerMessage";
            this.cmdAnswerMessage.Size = new System.Drawing.Size(135, 46);
            this.cmdAnswerMessage.TabIndex = 9;
            this.cmdAnswerMessage.Text = "srv answer";
            this.cmdAnswerMessage.Click += new System.EventHandler(this.cmdAnswerMessage_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtCliQueueName);
            this.groupBox4.Location = new System.Drawing.Point(18, 61);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(230, 56);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cli Queue";
            // 
            // txtCliQueueName
            // 
            this.txtCliQueueName.Location = new System.Drawing.Point(10, 18);
            this.txtCliQueueName.Name = "txtCliQueueName";
            this.txtCliQueueName.Size = new System.Drawing.Size(211, 22);
            this.txtCliQueueName.TabIndex = 0;
            this.txtCliQueueName.Text = "private$\\clientqueue";
            // 
            // cmdSendMessage
            // 
            this.cmdSendMessage.Location = new System.Drawing.Point(344, 375);
            this.cmdSendMessage.Name = "cmdSendMessage";
            this.cmdSendMessage.Size = new System.Drawing.Size(135, 47);
            this.cmdSendMessage.TabIndex = 7;
            this.cmdSendMessage.Text = "cli send";
            this.cmdSendMessage.Click += new System.EventHandler(this.cmdSendMessage_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.gpTimeToReach);
            this.groupBox5.Controls.Add(this.gbTimeToRead);
            this.groupBox5.Location = new System.Drawing.Point(18, 357);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(317, 73);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Timers";
            // 
            // gpTimeToReach
            // 
            this.gpTimeToReach.Controls.Add(this.txtTimeToReach);
            this.gpTimeToReach.Location = new System.Drawing.Point(10, 18);
            this.gpTimeToReach.Name = "gpTimeToReach";
            this.gpTimeToReach.Size = new System.Drawing.Size(134, 47);
            this.gpTimeToReach.TabIndex = 0;
            this.gpTimeToReach.TabStop = false;
            this.gpTimeToReach.Text = "Time to Reach";
            // 
            // txtTimeToReach
            // 
            this.txtTimeToReach.Location = new System.Drawing.Point(10, 18);
            this.txtTimeToReach.Name = "txtTimeToReach";
            this.txtTimeToReach.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTimeToReach.Size = new System.Drawing.Size(115, 22);
            this.txtTimeToReach.TabIndex = 0;
            this.txtTimeToReach.Text = "0";
            // 
            // gbTimeToRead
            // 
            this.gbTimeToRead.Controls.Add(this.txtTimeToBeReceived);
            this.gbTimeToRead.Location = new System.Drawing.Point(163, 18);
            this.gbTimeToRead.Name = "gbTimeToRead";
            this.gbTimeToRead.Size = new System.Drawing.Size(135, 47);
            this.gbTimeToRead.TabIndex = 1;
            this.gbTimeToRead.TabStop = false;
            this.gbTimeToRead.Text = "Time to Read";
            // 
            // txtTimeToBeReceived
            // 
            this.txtTimeToBeReceived.Location = new System.Drawing.Point(10, 18);
            this.txtTimeToBeReceived.Name = "txtTimeToBeReceived";
            this.txtTimeToBeReceived.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTimeToBeReceived.Size = new System.Drawing.Size(115, 22);
            this.txtTimeToBeReceived.TabIndex = 0;
            this.txtTimeToBeReceived.Text = "60000";
            // 
            // gbAckResult
            // 
            this.gbAckResult.Controls.Add(this.cbAttrib07);
            this.gbAckResult.Controls.Add(this.cbAttrib06);
            this.gbAckResult.Controls.Add(this.cbAttrib05);
            this.gbAckResult.Controls.Add(this.cbAttrib04);
            this.gbAckResult.Controls.Add(this.cbAttrib03);
            this.gbAckResult.Controls.Add(this.cbAttrib02);
            this.gbAckResult.Controls.Add(this.cbAttrib01);
            this.gbAckResult.Location = new System.Drawing.Point(18, 126);
            this.gbAckResult.Name = "gbAckResult";
            this.gbAckResult.Size = new System.Drawing.Size(470, 221);
            this.gbAckResult.TabIndex = 5;
            this.gbAckResult.TabStop = false;
            this.gbAckResult.Text = "AcknowledgeTypes = None";
            // 
            // cbAttrib07
            // 
            this.cbAttrib07.Location = new System.Drawing.Point(10, 185);
            this.cbAttrib07.Name = "cbAttrib07";
            this.cbAttrib07.Size = new System.Drawing.Size(432, 27);
            this.cbAttrib07.TabIndex = 6;
            this.cbAttrib07.Tag = "ack";
            this.cbAttrib07.Text = "PositiveReceive (successful receive) ";
            // 
            // cbAttrib06
            // 
            this.cbAttrib06.Location = new System.Drawing.Point(10, 157);
            this.cbAttrib06.Name = "cbAttrib06";
            this.cbAttrib06.Size = new System.Drawing.Size(432, 28);
            this.cbAttrib06.TabIndex = 5;
            this.cbAttrib06.Tag = "ack";
            this.cbAttrib06.Text = "PositiveArrival (successful delivery) ";
            // 
            // cbAttrib05
            // 
            this.cbAttrib05.Checked = true;
            this.cbAttrib05.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAttrib05.Location = new System.Drawing.Point(10, 129);
            this.cbAttrib05.Name = "cbAttrib05";
            this.cbAttrib05.Size = new System.Drawing.Size(432, 28);
            this.cbAttrib05.TabIndex = 4;
            this.cbAttrib05.Tag = "ack";
            this.cbAttrib05.Text = "NotAcknowledgeReceive (failure to be received) ";
            // 
            // cbAttrib04
            // 
            this.cbAttrib04.Location = new System.Drawing.Point(10, 102);
            this.cbAttrib04.Name = "cbAttrib04";
            this.cbAttrib04.Size = new System.Drawing.Size(432, 27);
            this.cbAttrib04.TabIndex = 3;
            this.cbAttrib04.Tag = "ack";
            this.cbAttrib04.Text = "NotAcknowledgeReachQueue (failure to be delivered) ";
            // 
            // cbAttrib03
            // 
            this.cbAttrib03.Location = new System.Drawing.Point(10, 74);
            this.cbAttrib03.Name = "cbAttrib03";
            this.cbAttrib03.Size = new System.Drawing.Size(432, 28);
            this.cbAttrib03.TabIndex = 2;
            this.cbAttrib03.Tag = "ack";
            this.cbAttrib03.Text = "NegativeReceive (failure to be received)";
            // 
            // cbAttrib02
            // 
            this.cbAttrib02.Location = new System.Drawing.Point(10, 46);
            this.cbAttrib02.Name = "cbAttrib02";
            this.cbAttrib02.Size = new System.Drawing.Size(432, 28);
            this.cbAttrib02.TabIndex = 1;
            this.cbAttrib02.Tag = "ack";
            this.cbAttrib02.Text = "FullReceive (success and failure to be received) ";
            // 
            // cbAttrib01
            // 
            this.cbAttrib01.Location = new System.Drawing.Point(10, 18);
            this.cbAttrib01.Name = "cbAttrib01";
            this.cbAttrib01.Size = new System.Drawing.Size(432, 28);
            this.cbAttrib01.TabIndex = 0;
            this.cbAttrib01.Tag = "ack";
            this.cbAttrib01.Text = "FullReachQueue (success and failure to be delivered to the queue)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSrvQueueName);
            this.groupBox2.Location = new System.Drawing.Point(156, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 48);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Srv Queue";
            // 
            // txtSrvQueueName
            // 
            this.txtSrvQueueName.Location = new System.Drawing.Point(10, 18);
            this.txtSrvQueueName.Name = "txtSrvQueueName";
            this.txtSrvQueueName.Size = new System.Drawing.Size(144, 22);
            this.txtSrvQueueName.TabIndex = 0;
            this.txtSrvQueueName.Text = "private$\\serverqueue";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCliAdminQueueName);
            this.groupBox3.Location = new System.Drawing.Point(258, 61);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(230, 56);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cli Admin Queue";
            // 
            // txtCliAdminQueueName
            // 
            this.txtCliAdminQueueName.Location = new System.Drawing.Point(10, 18);
            this.txtCliAdminQueueName.Name = "txtCliAdminQueueName";
            this.txtCliAdminQueueName.Size = new System.Drawing.Size(201, 22);
            this.txtCliAdminQueueName.TabIndex = 0;
            this.txtCliAdminQueueName.Text = "private$\\adminclient";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.cmdCriaFilas);
            this.groupBox11.Controls.Add(this.radioButton2);
            this.groupBox11.Controls.Add(this.radioButton1);
            this.groupBox11.Location = new System.Drawing.Point(10, 535);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(259, 56);
            this.groupBox11.TabIndex = 1;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Criar filas para teste";
            // 
            // cmdCriaFilas
            // 
            this.cmdCriaFilas.Location = new System.Drawing.Point(163, 18);
            this.cmdCriaFilas.Name = "cmdCriaFilas";
            this.cmdCriaFilas.Size = new System.Drawing.Size(87, 28);
            this.cmdCriaFilas.TabIndex = 2;
            this.cmdCriaFilas.Text = "Criar";
            this.cmdCriaFilas.Click += new System.EventHandler(this.cmdCriaFilas_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(96, 18);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(77, 28);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Tag = "criafilas";
            this.radioButton2.Text = "Client";
            // 
            // radioButton1
            // 
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(10, 18);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(76, 28);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "criafilas";
            this.radioButton1.Text = "Server";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.txtQtdMsgs);
            this.groupBox12.Location = new System.Drawing.Point(413, 535);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(105, 56);
            this.groupBox12.TabIndex = 2;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Qtd de Msgs";
            // 
            // txtQtdMsgs
            // 
            this.txtQtdMsgs.Location = new System.Drawing.Point(9, 21);
            this.txtQtdMsgs.Name = "txtQtdMsgs";
            this.txtQtdMsgs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtQtdMsgs.Size = new System.Drawing.Size(58, 22);
            this.txtQtdMsgs.TabIndex = 1;
            this.txtQtdMsgs.Text = "1";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.txtMsgsxs);
            this.groupBox13.Location = new System.Drawing.Point(290, 535);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(105, 56);
            this.groupBox13.TabIndex = 3;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Msgs/s";
            // 
            // txtMsgsxs
            // 
            this.txtMsgsxs.Location = new System.Drawing.Point(9, 21);
            this.txtMsgsxs.Name = "txtMsgsxs";
            this.txtMsgsxs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMsgsxs.Size = new System.Drawing.Size(58, 22);
            this.txtMsgsxs.TabIndex = 1;
            this.txtMsgsxs.Text = "0";
            // 
            // MSMQHelper
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(528, 599);
            this.Controls.Add(this.groupBox13);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.groupBox1);
            this.Name = "MSMQHelper";
            this.Text = "MSMQ Helper";
            this.groupBox1.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.gpTimeToReach.ResumeLayout(false);
            this.gpTimeToReach.PerformLayout();
            this.gbTimeToRead.ResumeLayout(false);
            this.gbTimeToRead.PerformLayout();
            this.gbAckResult.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.ResumeLayout(false);

	}
	#endregion

	private void cmdSendMessage_Click(object sender, System.EventArgs e)
	{
		string  szSrvName = txtSrvName.Text.Trim();
		string	szSrvDstQueue = txtSrvQueueName.Text.Trim();
		string	szCliAdminQueue = txtCliAdminQueueName.Text.Trim();
		string	szClieQueue = txtCliQueueName.Text.Trim();
		int		iTimeToReach;
		int		iTimeToBeReceived;
		int		iQtdMsgs;
        int     iQtdMsgsxs;

        MessageQueue queue = null;
		SetResultAck();

        int.TryParse(txtTimeToReach.Text, out iTimeToReach);
        int.TryParse(txtTimeToBeReceived.Text, out iTimeToBeReceived);
        int.TryParse(txtQtdMsgs.Text, out iQtdMsgs);
        int.TryParse(txtMsgsxs.Text, out iQtdMsgsxs);

        ThrottleHelper throttler = null;

        try
        {
			// Verifica se especificada o nome do servidor de destino 
			if( szSrvName.Length == 0 )
			{
				MessageBox.Show( "Preciso do nome do servidor de destino" );
				return;
			}

			// Verifica se especificada fila de destino 
			if( szSrvDstQueue.Length == 0 )
			{
				MessageBox.Show( "Preciso do nome da fila de destino" );
				return;
			}

			// Verifica se especificado algum Ack.
			// Caso exista, deve existir uma fila administrativa
			if( ( szCliAdminQueue.Length == 0 ) && ( false == _ackMask.Equals(AcknowledgeTypes.None) ) )
			{
				MessageBox.Show( "Quando especificado Acknowledges, preciso da fila admin." );
				return;
			}

			// Cria um ponteiro para a fila de destino
			queue = new MessageQueue( "FORMATNAME:DIRECT=OS:" + szSrvName + "\\" + szSrvDstQueue, false );

			System.Messaging.Message msg = new System.Messaging.Message(
                "<?xml version=\"1.0\"?><string>Message test</string>"
                );

			// Se informada fila administrativa,
			// Cria referencia para a mesma
			if( szCliAdminQueue.Length > 0 )
			{
				CreateQueue(".\\" + szCliAdminQueue);
				msg.AdministrationQueue = new MessageQueue( "FORMATNAME:DIRECT=OS:" + Dns.GetHostName() + "\\" + szCliAdminQueue, false );
			}

			CreateQueue(".\\" + szClieQueue);
			msg.ResponseQueue = new MessageQueue( "FORMATNAME:DIRECT=OS:" + Dns.GetHostName() + "\\" + szClieQueue, false );

			// Nao Adiciona o GUID do emissor da mensagem
			// para que o msmq nao tente usar o AD para identificar o emissor no destino
			msg.AttachSenderId = false;

            msg.AcknowledgeType = _ackMask;

            if (iTimeToReach > 0 )
				msg.TimeToReachQueue = new System.TimeSpan(0,0,0,0,iTimeToReach);
			
			if(iTimeToBeReceived > 0 )
				msg.TimeToBeReceived = new System.TimeSpan(0,0,0,0,iTimeToBeReceived);

			if( iQtdMsgs < 1 )
				iQtdMsgs = 1;

			try
			{
                if (iQtdMsgsxs > 0)
                    throttler = new ThrottleHelper(iQtdMsgsxs);

                for (int i = 0; i < iQtdMsgs; i++)
                {
                    queue.Send(msg, "Mensagem teste 0x" + i.ToString("X").PadLeft(4, '0'));

                    if (throttler != null)
                        throttler.VerifyLaps();
                }
			}
            catch (MessageQueueException ex)
            {
				// A fila nao existe no destinatario
				if( ex.ErrorCode == -2147467259 )
				{
					MessageBox.Show( "A fila [" + szSrvName + "\\" + szSrvDstQueue + "] não existe." );
				}
				
			}

			queue.Close();
		}
		catch ( Exception ex )
		{
			MessageBox.Show( String.Format( "Exception no envio da mensagem: {0}", ex ) );
		}

	}


	private void SetResultAck()
	{
		_ackMask = AcknowledgeTypes.None;

		for( int i=0; i<_acklist.Length; i++ )
		{
			if( _acklist[i].Checked )
				_ackMask |= _ackValueList[i];
		}

		gbAckResult.Text = "AcknowledgeTypes = " + _ackMask.ToString();
	}

	private void cbAttrib_CheckedChanged(object sender, System.EventArgs e)
	{
		SetResultAck();
	}

	public static void CreateQueue(string queuePath)
	{
		try    
		{
			if(!MessageQueue.Exists(queuePath))
			{
				MessageQueue.Create(queuePath);
			}
		}
		catch (MessageQueueException ex)
		{
			MessageBox.Show( String.Format( "Exception na criacao da queue {1}: {0}", ex, queuePath ) );
		}
            
	}

	private void cmdAnswerMessage_Click(object sender, System.EventArgs e)
	{
		string	szSrvQueue = txtSrvQueueName.Text.Trim();
		string	szResponseQueue = null;
		string	szSrvAdminQueue = txtSrvAdminQueueName.Text.Trim();
        MessageQueue queue = null, queueAnswer = null;
		System.Messaging.Message ReceivedMsg = null;
		System.Messaging.Message AnswerMsg = null;
		int		iTimeToReach;
		int		iTimeToBeReceived;
        int     iQtdMsgsxs;

        int.TryParse(txtTimeToReachClient.Text, out iTimeToReach);
        int.TryParse(txtTimeToBeReceivedClient.Text, out iTimeToBeReceived);
        int.TryParse(txtMsgsxs.Text, out iQtdMsgsxs);

        ThrottleHelper throttler = null;

        try
        {
            // Verifica se especificada fila de leitura
            if (szSrvQueue.Length == 0)
            {
                MessageBox.Show("Preciso do nome da fila local");
                return;
            }

            CreateQueue(".\\" + szSrvQueue);
            queue = new MessageQueue(".\\" + szSrvQueue, true);

            bool bAllMessages = true;
            string szResponseQueueCache = string.Empty;

            if (iQtdMsgsxs > 0)
                throttler = new ThrottleHelper(iQtdMsgsxs);

            do
            {
                try
                {
                    ReceivedMsg = queue.Receive(new System.TimeSpan(0, 0, 0, 0, 1), MessageQueueTransactionType.None);
                    szResponseQueue = ReceivedMsg.ResponseQueue.FormatName;
                    AnswerMsg = new System.Messaging.Message("bodybodybodybodybodybodybodybodybodybodybody");

                    if (queueAnswer == null || szResponseQueueCache != szResponseQueue)
                    {
                        if( queueAnswer != null )
                        {
                            queueAnswer.Close();
                            queueAnswer = null;
                        }
                        queueAnswer = new MessageQueue("FORMATNAME:" + szResponseQueue, false);
                        szResponseQueueCache = szResponseQueue;
                    }

                    // Verifica se especificado algum Ack.
                    // Caso exista, deve existir uma fila administrativa
                    if ((szSrvAdminQueue.Length == 0) && (false == _ackMask.Equals(AcknowledgeTypes.None)))
                    {
                        MessageBox.Show("Quando especificado Acknowledges, preciso da fila admin.");
                        return;
                    }

                    // Se informada fila administrativa,
                    // Cria referencia para a mesma
                    if (szSrvAdminQueue.Length > 0)
                        AnswerMsg.AdministrationQueue = new MessageQueue("FORMATNAME:DIRECT=OS:" + Dns.GetHostName() + "\\" + szSrvAdminQueue, false);

                    // Nao Adiciona o GUID do emissor da mensagem
                    // para que o msmq nao tente usar o AD para identificar o emissor no destino
                    AnswerMsg.AttachSenderId = false;

                    if (iTimeToReach > 0)
                        AnswerMsg.TimeToReachQueue = new System.TimeSpan(0, 0, 0, 0, iTimeToReach);

                    if (iTimeToBeReceived > 0)
                        AnswerMsg.TimeToBeReceived = new System.TimeSpan(0, 0, 0, 0, iTimeToBeReceived);

                    AnswerMsg.AcknowledgeType = _ackMask;

                    queueAnswer.Send(AnswerMsg, "Answer");

                    if (throttler != null)
                        throttler.VerifyLaps();
                    
                    //MessageBox.Show( String.Format( "Enviada resposta para:{0}", szResponseQueue ), "Queues" );
                }
                catch (MessageQueueException ex)
                {
                    //if (ex.MessageQueueErrorCode == MessageQueueErrorCode.IOTimeout)
                    bAllMessages = false;
                }
                
            } while (bAllMessages);
        }
        catch (Exception ex)
        {
            MessageBox.Show(String.Format("Exception no envio da resposta: {0}", ex));
        }
        finally
        {
            if (queue != null)
            {
                queue.Close();
                queue = null;
            }

            if (queueAnswer != null)
            {
                queueAnswer.Close();
                queueAnswer = null;
            }
        }
    }

	private void cmdCriaFilas_Click(object sender, System.EventArgs e)
	{
		string	szSrvQueue = txtSrvQueueName.Text.Trim();
		string	szCliQueue = txtCliQueueName.Text.Trim();
		string	szCliAdminQueue = txtCliAdminQueueName.Text.Trim();
		string	szSrvAdminQueue = txtSrvAdminQueueName.Text.Trim();

		// Cria filas do server
		if( radioButton1.Checked )
		{
			if( szSrvQueue.Length == 0 )
			{
				MessageBox.Show( "O nome da fila server deve ser informada." );
				return;
			}

			CreateQueue(".\\" + szSrvQueue);

			if( szSrvAdminQueue.Length > 0 )
				CreateQueue(".\\" + szSrvAdminQueue);
		}
		else
		{
			if( szCliQueue.Length == 0 )
			{
				MessageBox.Show( "O nome da fila cliente deve ser informada." );
				return;
			}

			CreateQueue(".\\" + szCliQueue);

			if( szCliAdminQueue.Length > 0 )
				CreateQueue(".\\" + szCliAdminQueue);
		}
	}
}

