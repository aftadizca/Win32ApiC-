using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileExplorer
{
    public partial class Form1 : Form
    {

        char pathSeparator = '\\';

        public Form1()
        {
            InitializeComponent();
			
        }

        private List<string> FolderList(string path)
        {
			List<string> list = new List<string>();
			try
			{
				DirectoryInfo info = new DirectoryInfo(path + treeView1.PathSeparator);

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

		private void PopulateDrives()
		{
			foreach (var drive in DriveInfo.GetDrives())
			{
				PopulateTreeView(drive.Name.Replace(pathSeparator.ToString(), ""));
			}
		}

		private void PopulateFile(string path)
		{
			listView1.Items.Clear();
			DirectoryInfo dir = new DirectoryInfo(path);
			foreach(var file in dir.GetFiles())
			{
				listView1.Items.Add(path + pathSeparator + file.Name, file.Name, 2);
			}
		}

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

			Console.WriteLine(path);

			TreeNode[] nodes = treeView1.Nodes.Find(path, true);
			Console.WriteLine("nodes" + nodes.Length);
			if(nodes.Length != 0)
			{
				if (nodes[0].Nodes.Count != FolderList(path).Count)
				{
					nodes[0].Nodes.Clear();
					foreach (var folder in FolderList(path))
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

		private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (treeView1.Nodes != null)
			{
				var fullpath = e.Node.FullPath;
				Console.WriteLine("ini full path "+fullpath);

				PopulateTreeView(fullpath);
				
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			PopulateDrives();
			treeView1.SelectedNode = treeView1.Nodes[0];
			Console.WriteLine(treeView1.Nodes.Find("C:", true).Count());
		}

		private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
		{
			e.Node.ImageIndex = 0;
		}

		private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
		{
			e.Node.ImageIndex = 1;
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node.IsExpanded)
			{
				e.Node.ImageIndex = 1;
			}
			else
			{
				e.Node.ImageIndex = 0;
			}

			PopulateFile(e.Node.FullPath);
		}

		private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			Console.WriteLine("Selection Path " + e.Node.FullPath);
			
		}

		private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			Console.WriteLine("File Path " + e.Item.Name);
		}
	}
}
