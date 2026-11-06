using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Windows.Forms;

namespace APP_FRAMEWORK;

public class Form1 : Form
{
	private IContainer components;

	private Button button1;

	private Button button2;

	public Form1()
	{
		InitializeComponent();
	}

	private string RunScript(string script)
	{
		Runspace runspace = RunspaceFactory.CreateRunspace();
		runspace.Open();
		Pipeline pipeline = runspace.CreatePipeline();
		pipeline.Commands.AddScript(script);
		CommandCollection commands = pipeline.Commands;
		string command = "Out-String";
		commands.Add(command);
		Collection<PSObject> collection = pipeline.Invoke();
		runspace.Close();
		StringBuilder stringBuilder = new StringBuilder();
		foreach (PSObject item in collection)
		{
			stringBuilder.AppendLine(item.ToString());
		}
		return stringBuilder.ToString();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		string text = "Set-Date -Adjust $(New-Timespan -Second  +60)";
		string script = text;
		RunScript(script);
		button1.Hide();
		button2.Show();
	}

	private void button2_Click(object sender, EventArgs e)
	{
		string text = "Set-Date -Adjust $(New-Timespan -Second  -60)";
		string script = text;
		RunScript(script);
		button2.Hide();
		button1.Show();
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		button2.Hide();
		button1.Show();
	}

	private void Form1_FormClosing(object sender, FormClosingEventArgs e)
	{
		Application.Exit();
	}

	private void Form1_FormClosed(object sender, FormClosedEventArgs e)
	{
		Application.Exit();
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
		this.button1 = new System.Windows.Forms.Button();
		this.button2 = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.button1.BackColor = System.Drawing.Color.Lime;
		this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button1.Location = new System.Drawing.Point(-2, -1);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(364, 118);
		this.button1.TabIndex = 0;
		this.button1.Text = "START";
		this.button1.UseVisualStyleBackColor = false;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.button2.BackColor = System.Drawing.Color.Red;
		this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button2.Location = new System.Drawing.Point(-2, -1);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(364, 118);
		this.button2.TabIndex = 1;
		this.button2.Text = "STOP";
		this.button2.UseVisualStyleBackColor = false;
		this.button2.Click += new System.EventHandler(button2_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.Red;
		base.ClientSize = new System.Drawing.Size(358, 113);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.button1);
		base.MaximizeBox = false;
		this.MaximumSize = new System.Drawing.Size(374, 152);
		base.MinimizeBox = false;
		this.MinimumSize = new System.Drawing.Size(374, 152);
		base.Name = "Form1";
		this.Text = "BOOSTER BY Hitman";
		base.Load += new System.EventHandler(Form1_Load);
		base.ResumeLayout(false);
	}
}
