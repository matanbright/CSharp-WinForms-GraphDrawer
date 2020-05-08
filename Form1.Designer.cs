namespace Graph_Drawer
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
			this.panel_graphDrawingArea = new System.Windows.Forms.Panel();
			this.label_equationYEqual = new System.Windows.Forms.Label();
			this.textBox_graphEquation = new System.Windows.Forms.TextBox();
			this.button_drawGraph = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// panel_graphDrawingArea
			// 
			this.panel_graphDrawingArea.BackColor = System.Drawing.Color.White;
			this.panel_graphDrawingArea.Location = new System.Drawing.Point(13, 13);
			this.panel_graphDrawingArea.Name = "panel_graphDrawingArea";
			this.panel_graphDrawingArea.Size = new System.Drawing.Size(946, 693);
			this.panel_graphDrawingArea.TabIndex = 0;
			this.panel_graphDrawingArea.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnPanelKeyUpEvent);
			this.panel_graphDrawingArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnPanelKeyDownEvent);
			this.panel_graphDrawingArea.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPanelPaintEvent);
			this.panel_graphDrawingArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnPanelMouseDownEvent);
			this.panel_graphDrawingArea.MouseEnter += new System.EventHandler(this.OnPanelMouseEnterEvent);
			this.panel_graphDrawingArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnPanelMouseMoveEvent);
			this.panel_graphDrawingArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnPanelMouseUpEvent);
			this.panel_graphDrawingArea.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.OnPanelMouseWheelEvent);
			// 
			// label_equationYEqual
			// 
			this.label_equationYEqual.AutoSize = true;
			this.label_equationYEqual.Location = new System.Drawing.Point(12, 717);
			this.label_equationYEqual.Name = "label_equationYEqual";
			this.label_equationYEqual.Size = new System.Drawing.Size(18, 13);
			this.label_equationYEqual.TabIndex = 1;
			this.label_equationYEqual.Text = "y=";
			// 
			// textBox_graphEquation
			// 
			this.textBox_graphEquation.Location = new System.Drawing.Point(36, 714);
			this.textBox_graphEquation.Name = "textBox_graphEquation";
			this.textBox_graphEquation.Size = new System.Drawing.Size(315, 20);
			this.textBox_graphEquation.TabIndex = 2;
			this.textBox_graphEquation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTextBoxKeyDownEvent);
			// 
			// button_drawGraph
			// 
			this.button_drawGraph.Location = new System.Drawing.Point(357, 712);
			this.button_drawGraph.Name = "button_drawGraph";
			this.button_drawGraph.Size = new System.Drawing.Size(84, 23);
			this.button_drawGraph.TabIndex = 3;
			this.button_drawGraph.Text = "Draw graph";
			this.button_drawGraph.UseVisualStyleBackColor = true;
			this.button_drawGraph.Click += new System.EventHandler(this.OnButtonClickEvent);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(971, 747);
			this.Controls.Add(this.button_drawGraph);
			this.Controls.Add(this.textBox_graphEquation);
			this.Controls.Add(this.label_equationYEqual);
			this.Controls.Add(this.panel_graphDrawingArea);
			this.Name = "Form1";
			this.Text = "Graph Drawer";
			this.Resize += new System.EventHandler(this.OnFormResizeEvent);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel_graphDrawingArea;
		private System.Windows.Forms.Label label_equationYEqual;
		private System.Windows.Forms.TextBox textBox_graphEquation;
		private System.Windows.Forms.Button button_drawGraph;
	}
}

