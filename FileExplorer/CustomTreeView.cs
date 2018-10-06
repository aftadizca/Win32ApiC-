using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileExplorer
{
	public partial class CostumTreeView : System.Windows.Forms.TreeView
	{
		[DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
		private extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName,
											string pszSubIdList);
		/// <summary>
		/// Test
		/// </summary>
		protected override void CreateHandle()
		{
			base.CreateHandle();
			SetWindowTheme(this.Handle, "explorer", null);
		}
	}
}
