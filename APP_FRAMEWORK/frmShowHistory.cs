using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace APP_FRAMEWORK;

internal class frmShowHistory : Form
{
	private DataGridViewTextBoxColumn B0AAA;

	private DataGridViewTextBoxColumn C0AA0;

	private IDisposable idisposable_0;

	private Button ClearBtn;

	private Button button1;

	private ComboBox BAAAA;

	private Label CAAA0;

	private Panel pnlHeader;

	private Label label2;

	private Panel pnlloader;

	private PictureBox pictureBox1;

	private Label lblMsg;

	internal GroupBox grpOpen;

	private DataGridView HistoryDataGrid;

	private DataGridViewTextBoxColumn Column1;

	private DataGridViewTextBoxColumn Column2;

	private DataGridViewTextBoxColumn Column3;

	private DataGridViewTextBoxColumn Column6;

	private DataGridViewTextBoxColumn Column7;

	private DataGridViewTextBoxColumn Column8;

	private DataGridViewTextBoxColumn Column9;

	private DataGridViewTextBoxColumn Column10;

	private DataGridViewTextBoxColumn Column4;

	private BunifuImageButton btnClose;

	private DataGridViewTextBoxColumn Column5;

	public frmShowHistory()
	{
		InitializeComponent();
		pnlHeader.MouseDown += StatClass.Header_MouseDown;
		pnlHeader.MouseMove += StatClass.Header_MouseMove;
		pnlHeader.MouseUp += StatClass.Header_MouseUp;
		HistoryDataGrid.BackgroundColor = BackColor;
		DataGridViewCellStyle alternatingRowsDefaultCellStyle = HistoryDataGrid.AlternatingRowsDefaultCellStyle;
		string htmlColor = "#d0dafd";
		alternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml(htmlColor);
		DataGridViewCellStyle defaultCellStyle = HistoryDataGrid.DefaultCellStyle;
		string htmlColor2 = "#EBF1FF";
		defaultCellStyle.BackColor = ColorTranslator.FromHtml(htmlColor2);
	}

	private void frmShowHistory_Load(object sender, EventArgs e)
	{
		BAAAA.Text = Program.mySettings_0.KeepHistory;
		method_0(0);
	}

	private void ClearBtn_Click(object sender, EventArgs e)
	{
		Form owner = new Form
		{
			TopMost = true
		};
		string text = "Do You Really Want to Delete all Old history data now!";
		string caption = "Clear History";
		if (MessageBox.Show(owner, text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
		{
			try
			{
				SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
				sQLiteConnection.Open();
				SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
				string commandText = "DELETE FROM TBL_HISTORY;";
				sQLiteCommand.CommandText = commandText;
				sQLiteCommand.ExecuteNonQuery();
			}
			catch
			{
			}
			ThreadPool.QueueUserWorkItem(method_0, null);
		}
	}

	private void method_0(object object_0)
	{
		int num = int.Parse(Program.mySettings_0.KeepHistory);
		try
		{
			DataTable dataTable = new DataTable();
			string commandText = "SELECT * FROM TBL_HISTORY";
			new SQLiteDataAdapter(commandText, Class34.string_Database).Fill(dataTable);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				foreach (DataRow row in dataTable.Rows)
				{
					string columnName = "TCNTRL_NAME";
					string text = row[columnName].ToString();
					string columnName2 = "Create_Date";
					string s = row[columnName2].ToString();
					string format = "yyyy-MM-dd";
					DateTime dateTime = DateTime.ParseExact(s, format, CultureInfo.InvariantCulture);
					DateTime date = DateTime.Now.Date;
					string columnName3 = "Create_Date";
					string s2 = row[columnName3].ToString();
					string format2 = "yyyy-MM-dd";
					if ((date - DateTime.ParseExact(s2, format2, CultureInfo.InvariantCulture)).TotalDays > 0.0 && (DateTime.Now.Date - dateTime).TotalDays > (double)num)
					{
						string text2 = "DELETE FROM TBL_HISTORY where TCNTRL_NAME LIKE '";
						string text3 = "'";
						Staticm.smethod_UpdateFieldValue(text2 + text + text3);
					}
				}
			}
		}
		catch
		{
		}
		try
		{
			string commandText2 = "Select TKT_NAME as 'Ticket Name',IRCTC_ID as 'ID', stnFrom as 'From', stnTo as 'To', Journey_Date, BANK_NAME as 'Bank Name', PNR, AMT as 'Fare', date(Create_Date) as 'Date', Remarks from TBL_HISTORY";
			SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(commandText2, Class34.string_Database);
			DataTable dataTable2 = new DataTable();
			sQLiteDataAdapter.Fill(dataTable2);
			HistoryDataGrid.DataSource = dataTable2;
			if (dataTable2.Rows.Count <= 0)
			{
				Label label = lblMsg;
				string text4 = "No Saved history found!";
				label.Text = text4;
				lblMsg.Visible = true;
			}
		}
		catch
		{
		}
		lblMsg.Visible = false;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Program.mySettings_0.KeepHistory = BAAAA.Text;
		string text = "Keep History Only For a Days will Successfully Saved.";
		MessageBox.Show(text);
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && idisposable_0 != null)
		{
			idisposable_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APP_FRAMEWORK.frmShowHistory));
		this.button1 = new System.Windows.Forms.Button();
		this.BAAAA = new System.Windows.Forms.ComboBox();
		this.CAAA0 = new System.Windows.Forms.Label();
		this.ClearBtn = new System.Windows.Forms.Button();
		this.pnlloader = new System.Windows.Forms.Panel();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.lblMsg = new System.Windows.Forms.Label();
		this.grpOpen = new System.Windows.Forms.GroupBox();
		this.HistoryDataGrid = new System.Windows.Forms.DataGridView();
		this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.pnlHeader = new System.Windows.Forms.Panel();
		this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
		this.label2 = new System.Windows.Forms.Label();
		this.pnlloader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		this.grpOpen.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.HistoryDataGrid).BeginInit();
		this.pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).BeginInit();
		base.SuspendLayout();
		this.button1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button1.Location = new System.Drawing.Point(542, 12);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(79, 27);
		this.button1.TabIndex = 1173;
		this.button1.Text = "Save";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.BAAAA.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.BAAAA.FormattingEnabled = true;
		this.BAAAA.Location = new System.Drawing.Point(473, 14);
		this.BAAAA.Name = "BAAAA";
		this.BAAAA.Size = new System.Drawing.Size(63, 22);
		this.BAAAA.TabIndex = 1172;
		this.CAAA0.AutoSize = true;
		this.CAAA0.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.CAAA0.ForeColor = System.Drawing.Color.White;
		this.CAAA0.Location = new System.Drawing.Point(312, 18);
		this.CAAA0.Name = "CAAA0";
		this.CAAA0.Size = new System.Drawing.Size(144, 15);
		this.CAAA0.TabIndex = 1171;
		this.CAAA0.Text = "Keep Only Days History :";
		this.ClearBtn.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.ClearBtn.Location = new System.Drawing.Point(627, 11);
		this.ClearBtn.Name = "ClearBtn";
		this.ClearBtn.Size = new System.Drawing.Size(165, 28);
		this.ClearBtn.TabIndex = 1089;
		this.ClearBtn.Text = "Clear All History";
		this.ClearBtn.UseVisualStyleBackColor = true;
		this.ClearBtn.Click += new System.EventHandler(ClearBtn_Click);
		this.pnlloader.BackColor = System.Drawing.SystemColors.Control;
		this.pnlloader.Controls.Add(this.pictureBox1);
		this.pnlloader.Controls.Add(this.lblMsg);
		this.pnlloader.Location = new System.Drawing.Point(170, 215);
		this.pnlloader.Name = "pnlloader";
		this.pnlloader.Size = new System.Drawing.Size(433, 65);
		this.pnlloader.TabIndex = 1209;
		this.pnlloader.Visible = false;
		this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
		this.pictureBox1.Location = new System.Drawing.Point(3, 3);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(426, 36);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox1.TabIndex = 24;
		this.pictureBox1.TabStop = false;
		this.pictureBox1.Visible = false;
		this.lblMsg.AutoSize = true;
		this.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblMsg.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblMsg.Location = new System.Drawing.Point(270, 42);
		this.lblMsg.Name = "lblMsg";
		this.lblMsg.Size = new System.Drawing.Size(157, 16);
		this.lblMsg.TabIndex = 25;
		this.lblMsg.Text = "Updating Id Records 2 of 10";
		this.lblMsg.Visible = false;
		this.grpOpen.BackColor = System.Drawing.Color.Gray;
		this.grpOpen.Controls.Add(this.ClearBtn);
		this.grpOpen.Controls.Add(this.CAAA0);
		this.grpOpen.Controls.Add(this.button1);
		this.grpOpen.Controls.Add(this.BAAAA);
		this.grpOpen.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.grpOpen.Location = new System.Drawing.Point(0, 405);
		this.grpOpen.Name = "grpOpen";
		this.grpOpen.Size = new System.Drawing.Size(799, 44);
		this.grpOpen.TabIndex = 1210;
		this.grpOpen.TabStop = false;
		this.HistoryDataGrid.AllowUserToAddRows = false;
		this.HistoryDataGrid.AllowUserToDeleteRows = false;
		dataGridViewCellStyle.BackColor = System.Drawing.Color.PowderBlue;
		dataGridViewCellStyle.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = System.Drawing.Color.Black;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.Color.Honeydew;
		this.HistoryDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
		this.HistoryDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
		this.HistoryDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.HistoryDataGrid.ColumnHeadersHeight = 25;
		this.HistoryDataGrid.Columns.AddRange(this.Column1, this.Column2, this.Column3, this.Column4, this.Column5, this.Column6, this.Column7, this.Column8, this.Column9, this.Column10);
		this.HistoryDataGrid.EnableHeadersVisualStyles = false;
		this.HistoryDataGrid.GridColor = System.Drawing.Color.GhostWhite;
		this.HistoryDataGrid.Location = new System.Drawing.Point(-37, 29);
		this.HistoryDataGrid.MultiSelect = false;
		this.HistoryDataGrid.Name = "HistoryDataGrid";
		this.HistoryDataGrid.ReadOnly = true;
		this.HistoryDataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = System.Drawing.Color.Azure;
		dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
		dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
		dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Honeydew;
		dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.HistoryDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
		this.HistoryDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
		this.HistoryDataGrid.Size = new System.Drawing.Size(836, 382);
		this.HistoryDataGrid.TabIndex = 1211;
		this.HistoryDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(HistoryDataGrid_CellContentClick);
		this.Column1.DataPropertyName = "Ticket Name";
		this.Column1.FillWeight = 50f;
		this.Column1.HeaderText = "Ticket Name";
		this.Column1.Name = "Column1";
		this.Column1.ReadOnly = true;
		this.Column1.Width = 93;
		this.Column2.DataPropertyName = "ID";
		this.Column2.FillWeight = 30f;
		this.Column2.HeaderText = "ID";
		this.Column2.Name = "Column2";
		this.Column2.ReadOnly = true;
		this.Column2.Width = 43;
		this.Column3.DataPropertyName = "From";
		this.Column3.FillWeight = 20f;
		this.Column3.HeaderText = "From";
		this.Column3.Name = "Column3";
		this.Column3.ReadOnly = true;
		this.Column3.Width = 55;
		this.Column4.DataPropertyName = "To";
		this.Column4.FillWeight = 20f;
		this.Column4.HeaderText = "To";
		this.Column4.Name = "Column4";
		this.Column4.ReadOnly = true;
		this.Column4.Width = 45;
		this.Column5.DataPropertyName = "Journey_Date";
		this.Column5.FillWeight = 50f;
		this.Column5.HeaderText = "Journey_Date";
		this.Column5.Name = "Column5";
		this.Column5.ReadOnly = true;
		this.Column5.Width = 98;
		this.Column6.DataPropertyName = "Bank Name";
		this.Column6.FillWeight = 90f;
		this.Column6.HeaderText = "Bank_Name";
		this.Column6.Name = "Column6";
		this.Column6.ReadOnly = true;
		this.Column6.Width = 91;
		this.Column7.DataPropertyName = "PNR";
		this.Column7.HeaderText = "PNR";
		this.Column7.Name = "Column7";
		this.Column7.ReadOnly = true;
		this.Column7.Width = 55;
		this.Column8.DataPropertyName = "Fare";
		this.Column8.FillWeight = 40f;
		this.Column8.HeaderText = "Fare";
		this.Column8.Name = "Column8";
		this.Column8.ReadOnly = true;
		this.Column8.Width = 53;
		this.Column9.DataPropertyName = "Date";
		this.Column9.FillWeight = 50f;
		this.Column9.HeaderText = "Date";
		this.Column9.Name = "Column9";
		this.Column9.ReadOnly = true;
		this.Column9.Width = 55;
		this.Column10.DataPropertyName = "Remarks";
		this.Column10.FillWeight = 50f;
		this.Column10.HeaderText = "Remarks";
		this.Column10.Name = "Column10";
		this.Column10.ReadOnly = true;
		this.Column10.Width = 74;
		this.pnlHeader.BackColor = System.Drawing.Color.MediumSlateBlue;
		this.pnlHeader.Controls.Add(this.btnClose);
		this.pnlHeader.Controls.Add(this.label2);
		this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
		this.pnlHeader.ForeColor = System.Drawing.Color.FromArgb(17, 17, 18);
		this.pnlHeader.Location = new System.Drawing.Point(0, 0);
		this.pnlHeader.Name = "pnlHeader";
		this.pnlHeader.Size = new System.Drawing.Size(799, 29);
		this.pnlHeader.TabIndex = 1208;
		this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.btnClose.BackColor = System.Drawing.Color.Transparent;
		this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
		this.btnClose.ImageActive = null;
		this.btnClose.Location = new System.Drawing.Point(776, 2);
		this.btnClose.Margin = new System.Windows.Forms.Padding(2);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(23, 23);
		this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.btnClose.TabIndex = 2;
		this.btnClose.TabStop = false;
		this.btnClose.Zoom = 10;
		this.btnClose.Click += new System.EventHandler(btnClose_Click_1);
		this.label2.AutoSize = true;
		this.label2.BackColor = System.Drawing.Color.Transparent;
		this.label2.Font = new System.Drawing.Font("Verdana", 13.8f);
		this.label2.ForeColor = System.Drawing.Color.White;
		this.label2.Location = new System.Drawing.Point(2, 2);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(97, 23);
		this.label2.TabIndex = 0;
		this.label2.Text = "HISTORY";
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.SystemColors.Control;
		base.ClientSize = new System.Drawing.Size(799, 453);
		base.Controls.Add(this.pnlloader);
		base.Controls.Add(this.HistoryDataGrid);
		base.Controls.Add(this.grpOpen);
		base.Controls.Add(this.pnlHeader);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "frmShowHistory";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		base.Load += new System.EventHandler(frmShowHistory_Load);
		this.pnlloader.ResumeLayout(false);
		this.pnlloader.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		this.grpOpen.ResumeLayout(false);
		this.grpOpen.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.HistoryDataGrid).EndInit();
		this.pnlHeader.ResumeLayout(false);
		this.pnlHeader.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).EndInit();
		base.ResumeLayout(false);
	}

	private void btnClose_Click_1(object sender, EventArgs e)
	{
		Close();
	}

	private void HistoryDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}
}
