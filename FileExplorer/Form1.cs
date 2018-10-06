using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileExplorer
{

    public partial class Form1 : Form
    {
		private string fileSelectedPath = null;
		private string fileSelectedName = null;
		private char pathSeparator = '\\';
		private SHFILEOPSTRUCT _ShFile;
		private FILEOP_FLAGS fFlags;

        private class contextMenuIndex
        {
            public static readonly int copy = 0;
            public static readonly int move = 1;
            public static readonly int paste = 2;
            public static readonly int delete = 3;
        };
        private void ImageIndexChanger(TreeNode e)
		        {
			        if (e.IsExpanded)
			        {
				        e.SelectedImageIndex = 1;
				        e.ImageIndex = 1;
			        }
			        else
			        {
				        e.SelectedImageIndex = 0;
				        e.ImageIndex = 0;
			        }
		        }
		private int CopyFile(string from, string to)
		{
			this._ShFile = new SHFILEOPSTRUCT();
			this._ShFile.hwnd = IntPtr.Zero;
			this._ShFile.wFunc = FileFuncFlags.FO_COPY;
            this._ShFile.fFlags = FILEOP_FLAGS.FOF_RENAMEONCOLLISION;
            this._ShFile.pFrom = from + '\0' + '\0';
			this._ShFile.pTo = to + '\0' + '\0';
			this._ShFile.fAnyOperationsAborted = false;
			this._ShFile.hNameMappings = IntPtr.Zero;
			this._ShFile.lpszProgressTitle = "";
			return FileOperation.SHFileOperation(ref this._ShFile);
		}
        private int MoveFile(string from, string to)
        {
            this._ShFile = new SHFILEOPSTRUCT();
            this._ShFile.hwnd = IntPtr.Zero;
            this._ShFile.wFunc = FileFuncFlags.FO_MOVE;
            this._ShFile.fFlags = FILEOP_FLAGS.FOF_RENAMEONCOLLISION;
            this._ShFile.pFrom = from + '\0' + '\0';
            this._ShFile.pTo = to + '\0' + '\0';
            this._ShFile.fAnyOperationsAborted = false;
            this._ShFile.hNameMappings = IntPtr.Zero;
            this._ShFile.lpszProgressTitle = "";
            return FileOperation.SHFileOperation(ref this._ShFile);
        }
        private int DeleteFile(string from)
		{
			this._ShFile = new SHFILEOPSTRUCT();
			this._ShFile.hwnd = IntPtr.Zero;
			this._ShFile.wFunc = FileFuncFlags.FO_DELETE;
			this._ShFile.fFlags = FILEOP_FLAGS.FOF_ALLOWUNDO | FILEOP_FLAGS.FOF_SIMPLEPROGRESS;
			this._ShFile.pFrom = from + '\0' + '\0';
			//this._ShFile.pTo = to;
			this._ShFile.fAnyOperationsAborted = false;
			this._ShFile.hNameMappings = IntPtr.Zero;
			this._ShFile.lpszProgressTitle = "";
			return FileOperation.SHFileOperation(ref this._ShFile);
		}

		/// <summary>
		/// Gets list of folder
		/// </summary>
		/// <param name="path">Path to the folder</param>
		/// <returns>List nama folder</returns>
		private List<string> FolderList(string path)
        {
			List<string> list = new List<string>();
			try
			{
				DirectoryInfo info = new DirectoryInfo(path + pathSeparator);

				foreach (var folder in info.GetDirectories())
				{
					if (info.Exists)
					{
						list.Add(folder.Name);
					}
				}
				
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show(this, "Tidak boleh diakses", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				
			}
			return list;
		}

		/// <summary>
		/// Get drive path and call PopulateTreeView(drive path)
		/// </summary>
		private void PopulateDrives()
		{
			foreach (var drive in DriveInfo.GetDrives())
			{
				PopulateTreeView(drive.Name.Replace(pathSeparator.ToString(), ""));
			}
		}

		/// <summary>
		/// Add file in folder to ListView
		/// </summary>
		/// <param name="path">folder path</param>
		private void PopulateListView(string path)
		{
			try
			{
				listView1.Items.Clear();
				
				DirectoryInfo dir = new DirectoryInfo(path);
				Console.WriteLine(dir.GetFiles().Count());
				foreach (var file in dir.GetFiles())
				{
					listView1.Items.Add(path+file.Name, file.Name, 2);
				}
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show(this, "Tidak boleh diakses", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			
		}

		/// <summary>
		/// Build treeview of folder
		/// </summary>
		/// <param name="path"></param>
		private void PopulateTreeView(string path)
		{
			#region Alternative

			//string subPathAgg;
			//TreeNode lastNode = null;
			//subPathAgg = string.Empty;
			//foreach (string subPath in path.Split(pathSeparator))
			//{

			//	if (subPath != "")
			//	{
			//		subPathAgg += subPath + pathSeparator;
			//		TreeNode[] nodes = treeView1.Nodes.Find(subPathAgg, false);

			//		Console.WriteLine("subPathAgg " + subPathAgg);
			//		Console.WriteLine("nodes.Length " + nodes.Length);
			//		if (nodes.Length == 0)
			//		{
			//			if (lastNode == null)
			//			{
			//				//TreeNode anode = new TreeNode(subPath);
			//				lastNode = treeView1.Nodes.Add(subPathAgg, subPath);
			//				//lastNode.ImageIndex = 1;
			//			}
			//			else
			//			{
			//				lastNode = lastNode.Nodes.Add(subPathAgg, subPath);
			//				//lastNode.ImageIndex = 1;
			//			}
			//		}
			//		else
			//		{
			//			lastNode = nodes[0];
			//		}
			//		//lastNode = null;
			//	}
			//} 
			#endregion
			//Console.WriteLine(path);
			TreeNode[] nodes = treeView1.Nodes.Find(path, true);
			//Console.WriteLine("nodes" + nodes.Length);
			if(nodes.Length != 0)
			{
				if (nodes[0].Nodes.Count != FolderList(path).Count)
				{
					nodes[0].Nodes.Clear();
					foreach (string folder in FolderList(path))
					{
						nodes[0].Nodes.Add(path+pathSeparator+folder, folder);
						nodes[0].ImageIndex = 1;
						nodes[0].Expand();
					}
				}
			}
			else
			{
				treeView1.Nodes.Add(path, path.Split(pathSeparator)[path.Split(pathSeparator).Length-1]);
			}

			

			
		}





        public Form1()
                {
                    InitializeComponent();
			        treeView1.ImageList = imageList1;
			        contextMenuStrip1.Items[contextMenuIndex.copy].Enabled = false; 
                    contextMenuStrip1.Items[contextMenuIndex.delete].Enabled = false;
                    contextMenuStrip1.Items[contextMenuIndex.move].Enabled = false;

        }
		private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (treeView1.Nodes != null)
			{
				var fullpath = e.Node.FullPath;
				//Console.WriteLine("ini full path "+fullpath);

				PopulateTreeView(fullpath);
			}

			ImageIndexChanger(e.Node);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			PopulateDrives();
			treeView1.SelectedNode = treeView1.Nodes[0];
			//Console.WriteLine(treeView1.Nodes.Find("C:", true).Count());
		}

		private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
		{
			ImageIndexChanger(e.Node);
		}

		private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
		{
			ImageIndexChanger(e.Node);
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
            currentFolder.Text = e.Node.FullPath+pathSeparator;
            PopulateListView(currentFolder.Text);
        }

		private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{

			ImageIndexChanger(e.Node);

			//Console.WriteLine("Selection Path " + e.Node.FullPath);
			
		}

		private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
		{
			ImageIndexChanger(e.Node);
		}

		private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			ImageIndexChanger(e.Node);
		}

		private void treeView1_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
		{
			ImageIndexChanger(e.Node);
		}

		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			fileSelectedPath = listView1.SelectedItems[0].Name;
			fileSelectedName = listView1.SelectedItems[0].Text;
			contextMenuStrip1.Items[contextMenuIndex.paste].Enabled = true;
            contextMenuStrip1.Items[contextMenuIndex.paste].Tag = "copy";
        }
        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileSelectedPath = listView1.SelectedItems[0].Name;
            fileSelectedName = listView1.SelectedItems[0].Text;
            contextMenuStrip1.Items[contextMenuIndex.paste].Enabled = true;
            contextMenuStrip1.Items[contextMenuIndex.paste].Tag = "move";
        }

		private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
            if((string)contextMenuStrip1.Items[contextMenuIndex.paste].Tag == "copy")
            {
                Console.WriteLine(fileSelectedPath + " COPY TO " + currentFolder.Text + fileSelectedName);
                CopyFile(fileSelectedPath, currentFolder.Text + fileSelectedName);
                //Microsoft.VisualBasic.FileIO.FileSystem.CopyFile(FileSelectedPath,treeView1.SelectedNode.FullPath+pathSeparator+FileSelectedName);
                contextMenuStrip1.Items[contextMenuIndex.paste].Enabled = false;
                PopulateListView(currentFolder.Text);
            }
            else
            {
                Console.WriteLine(fileSelectedPath + " MOVE TO " + currentFolder.Text + fileSelectedName);
                MoveFile(fileSelectedPath, currentFolder.Text + fileSelectedName);
                contextMenuStrip1.Items[contextMenuIndex.paste].Enabled = false;
                PopulateListView(currentFolder.Text);
            }
			
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
            var result = MessageBox.Show(this, "Delete file/folder?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result == DialogResult.Yes)
            {
                var filePath = listView1.SelectedItems[0].Name;
                DeleteFile(filePath);
                PopulateListView(currentFolder.Text);
            }
		}

        private void listView1_MouseDown(object sender, MouseEventArgs e)
		{
			var item = sender as ListView;

			if (e.Button == MouseButtons.Right && item.SelectedItems.Count != 0)
			{
				Console.WriteLine(item.SelectedItems[0].Name);
			}
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (listView1.SelectedItems.Count != 0)
            {
                contextMenuStrip1.Items[contextMenuIndex.copy].Enabled = true;
                contextMenuStrip1.Items[contextMenuIndex.move].Enabled = true;
                contextMenuStrip1.Items[contextMenuIndex.delete].Enabled = true;
            }
            else
            {
                contextMenuStrip1.Items[contextMenuIndex.copy].Enabled = false;
                contextMenuStrip1.Items[contextMenuIndex.delete].Enabled = false;
                contextMenuStrip1.Items[contextMenuIndex.move].Enabled = false;
            }

        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                contextMenuStrip1.Items[contextMenuIndex.copy].Enabled = true;
                contextMenuStrip1.Items[contextMenuIndex.move].Enabled = true;
                contextMenuStrip1.Items[contextMenuIndex.delete].Enabled = true;
            }
            else
            {
                contextMenuStrip1.Items[contextMenuIndex.copy].Enabled = false;
                contextMenuStrip1.Items[contextMenuIndex.delete].Enabled = false;
                contextMenuStrip1.Items[contextMenuIndex.move].Enabled = false;
            }
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                contextMenuStrip1.Items[contextMenuIndex.copy].Enabled = true;
                contextMenuStrip1.Items[contextMenuIndex.move].Enabled = true;
                contextMenuStrip1.Items[contextMenuIndex.delete].Enabled = true;
            }
            else
            {
                contextMenuStrip1.Items[contextMenuIndex.copy].Enabled = false;
                contextMenuStrip1.Items[contextMenuIndex.delete].Enabled = false;
                contextMenuStrip1.Items[contextMenuIndex.move].Enabled = false;
            }
        }
    }
}
