using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace BorderLessForm
{
	public partial class InivisibleForm : Form
	{
		[DllImport("user32.dll")]
			static extern int SetWindowLong(IntPtr hwnd, int index, int newLong);

		[DllImport("user32.dll", SetLastError = true)]
			static extern int GetWindowLong(IntPtr hwnd, int index);

		public InivisibleForm()
		{
			InitLayout();
		}

		protected override void OnLoad(EventArgs e)
		{
			
			this.TransparencyKey = Color.Wheat;
			this.BackColor = Color.Wheat;
			this.TopMost = true;
			this.FormBorderStyle = FormBorderStyle.None;
			int initialStyle = GetWindowLong(this.Handle, -20);
			SetWindowLong(this.Handle, -20, initialStyle | 0x80000 | 0x20);
		}
	}
}
