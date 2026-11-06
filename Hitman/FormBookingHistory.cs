using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using APP_FRAMEWORK;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace Hitman;

public class FormBookingHistory : Form
{
	private BookingRoot bookingRoot;

	private string _jsonResponse;

	private IContainer components = null;

	private Panel panelTop;

	private Label lblTitle;

	private TextBox txtSearch;

	private Button btnRefresh;

	private Button btnBooked;

	private Button btnAll;

	private Label lblTotal;

	private FlowLayoutPanel flowLayoutPanel1;

	private TextBox txtJson;

	public FormBookingHistory(string response)
	{
		InitializeComponent();
		_jsonResponse = response;
	}

	private void FormBookingHistory_Load(object sender, EventArgs e)
	{
		flowLayoutPanel1.AutoScroll = true;
		flowLayoutPanel1.WrapContents = false;
		flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
		LoadBookingHistory();
	}

	private void LoadBookingHistory()
	{
		try
		{
			bookingRoot = JsonConvert.DeserializeObject<BookingRoot>(_jsonResponse);
			if (bookingRoot == null || bookingRoot.bookingResponseList == null)
			{
				return;
			}
			flowLayoutPanel1.Controls.Clear();
			foreach (Booking bookingResponse in bookingRoot.bookingResponseList)
			{
				BookingCard bookingCard = new BookingCard();
				bookingCard.SetData(bookingResponse);
				bookingCard.PrintClicked += Card_PrintClicked;
				bookingCard.CancelClicked += Card_CancelClicked;
				bookingCard.DetailClicked += Card_DetailClicked;
				flowLayoutPanel1.Controls.Add(bookingCard);
			}
			string text = "PrintTicket";
			lblTotal.Text = $"Total Booking : {bookingRoot.bookingResponseList.Count}";
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private async void Card_PrintClicked(object sender, Booking booking)
	{
		string errMessage = "Histry_PassengerTicket";
		Program.mcommInstance_.isLV("", booking.pnrNumber, ref errMessage);
	}

	private void Card_CancelClicked(object sender, Booking booking)
	{
		DialogResult dialogResult = MessageBox.Show("Cancel Ticket ?", "Confirm", MessageBoxButtons.YesNo);
		if (dialogResult == DialogResult.Yes)
		{
			string errMessage = "Histry_CancellTicket";
			string text = Program.mcommInstance_.isLV("", booking.transactionId, ref errMessage);
		}
	}

	private void Card_DetailClicked(object sender, Booking booking)
	{
		string prompt = "Enter Boarding Station Code For Change Boarding.";
		string title = "Enter BoardingPoint Station Code";
		string userID = Interaction.InputBox(prompt, title);
		string errMessage = "Histry_ChangeBoardingPoint";
		string text = Program.mcommInstance_.isLV(userID, booking.pnrNumber, ref errMessage);
	}

	private void btnRefresh_Click(object sender, EventArgs e)
	{
		LoadBookingHistory();
	}

	private void txtSearch_TextChanged(object sender, EventArgs e)
	{
		SearchPNR(txtSearch.Text);
	}

	private void SearchPNR(string searchText)
	{
		if (bookingRoot == null)
		{
			return;
		}
		searchText = (searchText ?? "").Trim().ToLower();
		flowLayoutPanel1.SuspendLayout();
		flowLayoutPanel1.Controls.Clear();
		IEnumerable<Booking> enumerable = bookingRoot.bookingResponseList.Where((Booking b) => string.IsNullOrEmpty(searchText) || b.pnrNumber.Contains(searchText) || b.trainNumber.Contains(searchText) || b.trainName.ToLower().Contains(searchText) || b.fromStn.ToLower().Contains(searchText) || b.destStn.ToLower().Contains(searchText));
		foreach (Booking item in enumerable)
		{
			BookingCard bookingCard = new BookingCard();
			bookingCard.Width = flowLayoutPanel1.ClientSize.Width - 25;
			bookingCard.SetData(item);
			bookingCard.PrintClicked += Card_PrintClicked;
			bookingCard.CancelClicked += Card_CancelClicked;
			bookingCard.DetailClicked += Card_DetailClicked;
			flowLayoutPanel1.Controls.Add(bookingCard);
		}
		lblTotal.Text = $"Total Booking : {flowLayoutPanel1.Controls.Count}";
		flowLayoutPanel1.ResumeLayout();
	}

	private void btnBooked_Click(object sender, EventArgs e)
	{
		FilterStatus("Booked");
	}

	private void btnAll_Click(object sender, EventArgs e)
	{
		LoadBookingHistory();
	}

	private void FilterStatus(string status)
	{
		flowLayoutPanel1.Controls.Clear();
		foreach (Booking bookingResponse in bookingRoot.bookingResponseList)
		{
			if (!bookingResponse.reservationStatus.Equals(status, StringComparison.OrdinalIgnoreCase))
			{
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.panelTop = new System.Windows.Forms.Panel();
		this.lblTitle = new System.Windows.Forms.Label();
		this.txtSearch = new System.Windows.Forms.TextBox();
		this.btnRefresh = new System.Windows.Forms.Button();
		this.btnBooked = new System.Windows.Forms.Button();
		this.btnAll = new System.Windows.Forms.Button();
		this.lblTotal = new System.Windows.Forms.Label();
		this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
		this.txtJson = new System.Windows.Forms.TextBox();
		this.panelTop.SuspendLayout();
		base.SuspendLayout();
		this.panelTop.BackColor = System.Drawing.Color.RoyalBlue;
		this.panelTop.Controls.Add(this.lblTitle);
		this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.panelTop.Location = new System.Drawing.Point(0, 0);
		this.panelTop.Margin = new System.Windows.Forms.Padding(2);
		this.panelTop.Name = "panelTop";
		this.panelTop.Size = new System.Drawing.Size(777, 46);
		this.panelTop.TabIndex = 6;
		this.lblTitle.AutoSize = true;
		this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold);
		this.lblTitle.ForeColor = System.Drawing.Color.White;
		this.lblTitle.Location = new System.Drawing.Point(15, 13);
		this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.lblTitle.Name = "lblTitle";
		this.lblTitle.Size = new System.Drawing.Size(248, 30);
		this.lblTitle.TabIndex = 0;
		this.lblTitle.Text = "IRCTC Booking History";
		this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10f);
		this.txtSearch.Location = new System.Drawing.Point(15, 55);
		this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
		this.txtSearch.Name = "txtSearch";
		this.txtSearch.Size = new System.Drawing.Size(188, 25);
		this.txtSearch.TabIndex = 5;
		this.txtSearch.TextChanged += new System.EventHandler(txtSearch_TextChanged);
		this.btnRefresh.Location = new System.Drawing.Point(218, 54);
		this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
		this.btnRefresh.Name = "btnRefresh";
		this.btnRefresh.Size = new System.Drawing.Size(75, 21);
		this.btnRefresh.TabIndex = 4;
		this.btnRefresh.Text = "Refresh";
		this.btnRefresh.Click += new System.EventHandler(btnRefresh_Click);
		this.btnBooked.Location = new System.Drawing.Point(300, 54);
		this.btnBooked.Margin = new System.Windows.Forms.Padding(2);
		this.btnBooked.Name = "btnBooked";
		this.btnBooked.Size = new System.Drawing.Size(75, 21);
		this.btnBooked.TabIndex = 3;
		this.btnBooked.Text = "Booked";
		this.btnBooked.Click += new System.EventHandler(btnBooked_Click);
		this.btnAll.Location = new System.Drawing.Point(382, 54);
		this.btnAll.Margin = new System.Windows.Forms.Padding(2);
		this.btnAll.Name = "btnAll";
		this.btnAll.Size = new System.Drawing.Size(75, 21);
		this.btnAll.TabIndex = 2;
		this.btnAll.Text = "All";
		this.btnAll.Click += new System.EventHandler(btnAll_Click);
		this.lblTotal.AutoSize = true;
		this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
		this.lblTotal.Location = new System.Drawing.Point(488, 58);
		this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.lblTotal.Name = "lblTotal";
		this.lblTotal.Size = new System.Drawing.Size(62, 19);
		this.lblTotal.TabIndex = 1;
		this.lblTotal.Text = "Total : 0";
		this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.flowLayoutPanel1.AutoScroll = true;
		this.flowLayoutPanel1.BackColor = System.Drawing.Color.Gainsboro;
		this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
		this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 81);
		this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
		this.flowLayoutPanel1.Name = "flowLayoutPanel1";
		this.flowLayoutPanel1.Size = new System.Drawing.Size(777, 364);
		this.flowLayoutPanel1.TabIndex = 0;
		this.flowLayoutPanel1.WrapContents = false;
		this.txtJson.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.txtJson.Location = new System.Drawing.Point(0, 453);
		this.txtJson.Margin = new System.Windows.Forms.Padding(2);
		this.txtJson.Multiline = true;
		this.txtJson.Name = "txtJson";
		this.txtJson.Size = new System.Drawing.Size(777, 34);
		this.txtJson.TabIndex = 7;
		this.txtJson.Visible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(777, 487);
		base.Controls.Add(this.flowLayoutPanel1);
		base.Controls.Add(this.lblTotal);
		base.Controls.Add(this.btnAll);
		base.Controls.Add(this.btnBooked);
		base.Controls.Add(this.btnRefresh);
		base.Controls.Add(this.txtSearch);
		base.Controls.Add(this.panelTop);
		base.Controls.Add(this.txtJson);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
		base.Margin = new System.Windows.Forms.Padding(2);
		base.Name = "FormBookingHistory";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "IRCTC Booking History";
		base.Load += new System.EventHandler(FormBookingHistory_Load);
		this.panelTop.ResumeLayout(false);
		this.panelTop.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
