using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace APP_FRAMEWORK;

internal class tabHistory : UserControl
{
	private string id_;

	private DataTable dataTable_0;

	internal string string_0;

	internal string string_1;

	internal string string_2;

	private IDisposable idisposable_0;

	private ToolTip toolTip_0;

	private IContainer BAAAA;

	private DataGridView dgv;

	private Panel pnlloader;

	private PictureBox pictureBox1;

	private Label lblMsg;

	private IContainer components;

	private Label label1;

	private Label label16;

	private BackgroundWorker backgroundWorker_0;

	public tabHistory()
	{
		InitializeComponent();
	}

	private void tabHistory_Load(object sender, EventArgs e)
	{
	}

	internal void method_IrctcId3(string Query, string id_, string pass)
	{
		this.id_ = id_;
		string_1 = pass;
		string tableName = "Tbl_Trans";
		dataTable_0 = new DataTable(tableName);
		DataColumnCollection columns = dataTable_0.Columns;
		string columnName = "S.NO";
		columns.Add(new DataColumn(columnName));
		DataColumnCollection columns2 = dataTable_0.Columns;
		string columnName2 = "PNR";
		columns2.Add(new DataColumn(columnName2));
		DataColumnCollection columns3 = dataTable_0.Columns;
		string columnName3 = "From";
		columns3.Add(new DataColumn(columnName3));
		DataColumnCollection columns4 = dataTable_0.Columns;
		string columnName4 = "To";
		columns4.Add(new DataColumn(columnName4));
		DataColumnCollection columns5 = dataTable_0.Columns;
		string columnName5 = "Train NO.";
		columns5.Add(new DataColumn(columnName5));
		DataColumnCollection columns6 = dataTable_0.Columns;
		string columnName6 = "Ticket Journey Date";
		columns6.Add(new DataColumn(columnName6));
		DataColumnCollection columns7 = dataTable_0.Columns;
		string columnName7 = "Ticket Booking Date";
		columns7.Add(new DataColumn(columnName7));
		DataColumnCollection columns8 = dataTable_0.Columns;
		string columnName8 = "Print Ticket";
		columns8.Add(new DataColumn(columnName8));
		DataColumnCollection columns9 = dataTable_0.Columns;
		string columnName9 = "Send SMS";
		columns9.Add(new DataColumn(columnName9));
		string text = "";
		string text2 = "";
		DataTable dataTable = new DataTable();
		new SQLiteDataAdapter(Query, Class34.string_Database).Fill(dataTable);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow row in dataTable.Rows)
			{
				string columnName10 = "UserName";
				text2 = row[columnName10].ToString();
				string columnName11 = "History";
				text = row[columnName11].ToString();
			}
		}
		int num = 0;
		try
		{
			string[] array = text.Split(new char[1] { '#' }, StringSplitOptions.RemoveEmptyEntries)[0].Split(new char[1] { '@' }, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < array.Length; i++)
			{
				try
				{
					string[] array2 = array[i].Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
					DataRow dataRow2 = dataTable_0.NewRow();
					dataRow2[0] = i + 1;
					dataRow2[1] = array2[4];
					dataRow2[2] = array2[2];
					dataRow2[3] = array2[3];
					dataRow2[4] = array2[5];
					dataRow2[5] = array2[0];
					dataRow2[6] = array2[1];
					string value = "Print";
					dataRow2[7] = value;
					string value2 = "Get SMS";
					dataRow2[8] = value2;
					dataTable_0.Rows.Add(dataRow2);
					string text3 = array2[0];
					string value3 = "T";
					string s = text3.Substring(0, text3.IndexOf(value3));
					string format = "yyyy-MM-dd";
					if ((DateTime.ParseExact(s, format, CultureInfo.InvariantCulture) - DateTime.Now.Date).TotalDays >= 0.0)
					{
						num++;
					}
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
		Label label = label1;
		string text4 = "{ User ID:-     ";
		string text5 = text2;
		string text6 = " }";
		label.Text = text4 + text5 + text6;
		dataTable_0.AcceptChanges();
		dgv.DataSource = dataTable_0;
		dgv.AutoResizeColumns();
		dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
	}

	private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
		int rowIndex = e.RowIndex;
		switch (e.ColumnIndex)
		{
		case 8:
		{
			string text10 = "This Facility WE LAunch Soon. Tnaks for Support";
			MessageBox.Show(text10);
			break;
		}
		case 7:
		{
			string text = "Print";
			string text2 = text;
			string text3 = id_;
			string text4 = "";
			try
			{
				text4 = Program.dictionary_01[text3];
			}
			catch
			{
				string text5 = "Active";
				string value = "Invalid";
				if (text5.Contains(value))
				{
					string text6 = "The Selected User Id Is Deactivated";
					MessageBox.Show(text6);
					break;
				}
			}
			DataRow dataRow = dataTable_0.Rows[rowIndex];
			string columnName = "PNR";
			string text7 = dataRow[columnName].ToString();
			string text8 = ":";
			string text9 = text2 + text8 + text7;
			string_0 = text3.Trim();
			string_1 = text4.Trim();
			string_2 = text9;
			backgroundWorker_0.RunWorkerAsync();
			break;
		}
		}
	}

	private void method_0(object object_0)
	{
		if (pnlloader.InvokeRequired)
		{
			pnlloader.Invoke(new ParameterizedThreadStart(method_0), object_0);
		}
		else
		{
			pnlloader.Visible = bool.Parse(object_0.ToString());
		}
		Application.DoEvents();
		Thread.Sleep(500);
	}

	private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
	{
		method_0(true);
		try
		{
			if (bool.Parse(Program.mcommInstance_.isLV(string_0, string_1, ref string_2)))
			{
				Form owner = new Form
				{
					TopMost = true
				};
				string text = "Sucessfully Print Your Ticket, Check on Desktop (Pint) Folder";
				string caption = "Print Sucess";
				MessageBox.Show(owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		catch
		{
		}
		method_0(false);
	}

	private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
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
		this.components = new System.ComponentModel.Container();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		this.toolTip_0 = new System.Windows.Forms.ToolTip(this.components);
		this.dgv = new System.Windows.Forms.DataGridView();
		this.pnlloader = new System.Windows.Forms.Panel();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.lblMsg = new System.Windows.Forms.Label();
		this.backgroundWorker_0 = new System.ComponentModel.BackgroundWorker();
		this.label1 = new System.Windows.Forms.Label();
		this.label16 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.dgv).BeginInit();
		this.pnlloader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		base.SuspendLayout();
		this.dgv.AllowUserToAddRows = false;
		this.dgv.AllowUserToDeleteRows = false;
		this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.dgv.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
		this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
		dataGridViewCellStyle.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = System.Drawing.Color.White;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(128, 128, 255);
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.Color.White;
		dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		this.dgv.ColumnHeadersHeight = 25;
		this.dgv.EnableHeadersVisualStyles = false;
		this.dgv.GridColor = System.Drawing.Color.GhostWhite;
		this.dgv.Location = new System.Drawing.Point(3, 29);
		this.dgv.MultiSelect = false;
		this.dgv.Name = "dgv";
		this.dgv.ReadOnly = true;
		this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		this.dgv.RowHeadersVisible = false;
		this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
		this.dgv.Size = new System.Drawing.Size(752, 326);
		this.dgv.TabIndex = 131;
		this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgv_CellContentClick);
		this.pnlloader.BackColor = System.Drawing.SystemColors.ControlLight;
		this.pnlloader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pnlloader.Controls.Add(this.pictureBox1);
		this.pnlloader.Controls.Add(this.lblMsg);
		this.pnlloader.Location = new System.Drawing.Point(259, 141);
		this.pnlloader.Name = "pnlloader";
		this.pnlloader.Size = new System.Drawing.Size(197, 76);
		this.pnlloader.TabIndex = 134;
		this.pnlloader.Visible = false;
		this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
		this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
		this.pictureBox1.Location = new System.Drawing.Point(0, 0);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(195, 32);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox1.TabIndex = 24;
		this.pictureBox1.TabStop = false;
		this.lblMsg.AutoSize = true;
		this.lblMsg.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblMsg.Location = new System.Drawing.Point(14, 44);
		this.lblMsg.Name = "lblMsg";
		this.lblMsg.Size = new System.Drawing.Size(164, 19);
		this.lblMsg.TabIndex = 25;
		this.lblMsg.Text = "Please Waiting...........";
		this.backgroundWorker_0.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker_0_DoWork);
		this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
		this.label1.Location = new System.Drawing.Point(3, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(752, 26);
		this.label1.TabIndex = 0;
		this.label1.Text = "label1";
		this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label16.AutoSize = true;
		this.label16.Location = new System.Drawing.Point(811, 7);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(41, 13);
		this.label16.TabIndex = 135;
		this.label16.Text = "label16";
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.SystemColors.ActiveCaption;
		base.Controls.Add(this.label16);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.pnlloader);
		base.Controls.Add(this.dgv);
		base.Name = "tabHistory";
		base.Size = new System.Drawing.Size(758, 358);
		((System.ComponentModel.ISupportInitialize)this.dgv).EndInit();
		this.pnlloader.ResumeLayout(false);
		this.pnlloader.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
