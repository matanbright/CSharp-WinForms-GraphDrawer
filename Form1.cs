using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph_Drawer
{
	public partial class Form1 : Form
	{
		// Constants ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		const int MOUSE_WHEEL_ZOOM_AMOUNT = 10;
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



		// Variables ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		Equation equation;
		Size currentFormSize;
		PointF axisOrigin;
		double graphResolution = 0.1D; // Lower = better zoom quality but slower processing
		double xAxisZoom = 1.0D, yAxisZoom = 1.0D;
		bool xAxisZoomLock = false, yAxisZoomLock = false;
		bool isDragging = false;
		PointF currentMouseLocationWhenDragging;
		bool useDegreesInsteadOfRadians = true;
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



		// Constructors ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		public Form1()
		{
			InitializeComponent();
			currentFormSize = this.Size;
			axisOrigin = new PointF(panel_graphDrawingArea.Size.Width / 2.0F, panel_graphDrawingArea.Size.Height / 2.0F);
		}
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



		// Events //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		private void OnFormResizeEvent(object sender, EventArgs e)
		{
			int formWidthDelta = this.Width - currentFormSize.Width, formHeightDelta = this.Height - currentFormSize.Height;
			panel_graphDrawingArea.Size = new Size(panel_graphDrawingArea.Width + formWidthDelta, panel_graphDrawingArea.Height + formHeightDelta);
			label_equationYEqual.Location = new Point(label_equationYEqual.Location.X, label_equationYEqual.Location.Y + formHeightDelta);
			textBox_graphEquation.Location = new Point(textBox_graphEquation.Location.X, textBox_graphEquation.Location.Y + formHeightDelta);
			button_drawGraph.Location = new Point(button_drawGraph.Location.X, button_drawGraph.Location.Y + formHeightDelta);
			currentFormSize = this.Size;
			axisOrigin = new PointF(axisOrigin.X + formWidthDelta / 2.0F, axisOrigin.Y + formHeightDelta / 2.0F);
			this.Refresh();
		}
		private void OnButtonClickEvent(object sender, EventArgs e)
		{
			equation = new Equation(textBox_graphEquation.Text);
			this.Refresh();
		}
		private void OnTextBoxKeyDownEvent(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				equation = new Equation(textBox_graphEquation.Text);
				this.Refresh();
			}
		}
		private void OnPanelPaintEvent(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawLine(Pens.Black, new PointF(axisOrigin.X, 0F), new PointF(axisOrigin.X, panel_graphDrawingArea.Size.Height));
			e.Graphics.DrawLine(Pens.Black, new PointF(0F, axisOrigin.Y), new PointF(panel_graphDrawingArea.Size.Width, axisOrigin.Y));
			
			if (equation != null)
			{
				for (double i = -axisOrigin.X; i < panel_graphDrawingArea.Width - axisOrigin.X; i += graphResolution)
				{
					try
					{
						PointF p1 = new PointF((float)(axisOrigin.X + i * xAxisZoom), (float)(axisOrigin.Y - equation.Solve(i, useDegreesInsteadOfRadians) * yAxisZoom));
						if (p1.Y >= -panel_graphDrawingArea.Height && p1.Y < panel_graphDrawingArea.Height * 2)
						{
							PointF p2 = new PointF((float)(axisOrigin.X + (i + graphResolution) * xAxisZoom), (float)(axisOrigin.Y - equation.Solve(i + graphResolution, useDegreesInsteadOfRadians) * yAxisZoom));
							if (p2.Y < -panel_graphDrawingArea.Height)
								p2 = new PointF(p2.X, -panel_graphDrawingArea.Height);
							else if (p2.Y >= panel_graphDrawingArea.Height * 2)
								p2 = new PointF(p2.X, panel_graphDrawingArea.Height * 2 - 1);
							e.Graphics.DrawLine(Pens.Red, p1, p2);
						}
					}
					catch
					{
						
					}
				}
			}
		}
		private void OnPanelMouseEnterEvent(object sender, EventArgs e)
		{
			panel_graphDrawingArea.Focus();
		}
		private void OnPanelMouseDownEvent(object sender, MouseEventArgs e)
		{
			panel_graphDrawingArea.Focus();
			currentMouseLocationWhenDragging = e.Location;
			isDragging = true;
			this.Refresh();
		}
		private void OnPanelMouseMoveEvent(object sender, MouseEventArgs e)
		{
			panel_graphDrawingArea.Focus();
			if (isDragging)
			{
				axisOrigin = new PointF(axisOrigin.X + (e.Location.X - currentMouseLocationWhenDragging.X), axisOrigin.Y + (e.Location.Y - currentMouseLocationWhenDragging.Y));
				currentMouseLocationWhenDragging = e.Location;
				this.Refresh();
			}
		}
		private void OnPanelMouseUpEvent(object sender, MouseEventArgs e)
		{
			panel_graphDrawingArea.Focus();
			isDragging = false;
			this.Refresh();
		}
		private void OnPanelMouseWheelEvent(object sender, MouseEventArgs e)
		{
			if (e.Delta > 0)
			{
				if (!xAxisZoomLock)
					xAxisZoom += MOUSE_WHEEL_ZOOM_AMOUNT;
				if (!yAxisZoomLock)
					yAxisZoom += MOUSE_WHEEL_ZOOM_AMOUNT;
				this.Refresh();
			}
			else if (e.Delta < 0)
			{
				if (!xAxisZoomLock)
					xAxisZoom -= MOUSE_WHEEL_ZOOM_AMOUNT;
				if (!yAxisZoomLock)
					yAxisZoom -= MOUSE_WHEEL_ZOOM_AMOUNT;
				if (xAxisZoom < 1)
					xAxisZoom = 1;
				if (yAxisZoom < 1)
					yAxisZoom = 1;
				this.Refresh();
			}
		}
		private void OnPanelKeyDownEvent(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.X:
					yAxisZoomLock = true;
					break;
				case Keys.Y:
					xAxisZoomLock = true;
					break;
			}
		}
		private void OnPanelKeyUpEvent(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.X:
					yAxisZoomLock = false;
					break;
				case Keys.Y:
					xAxisZoomLock = false;
					break;
			}
		}
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	}
}
