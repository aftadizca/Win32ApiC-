using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FileExplorer
{

    public partial class Form1 : Form
    {
		private string _fileSelectedPath;
        private string _fileSelectedName;
        private const char PathSeparator = '\\';
		private static SHFILEOPSTRUCT _shFile;
        private static List<UndoAction> _undoActions = new List<UndoAction>();

        private class ContextMenuIndex
        {
            public static readonly int copy = 0;
            public static readonly int move = 1;
            public static readonly int paste = 2;
            public static readonly int delete = 3;
            public static readonly int undo = 4;
        };

        private class UndoAction
        {
            private string _fromPath;
            private string _toPath;
            private string _action;

            public UndoAction(string from, string to, string action)
            {
                _fromPath = from;
                _toPath = to;
                _action = action;
            }

            public string GetAction()
            {
                return _action;
            }

            public string GetTo()
            {
                return _toPath;
            }

            public void Undo()
            {
                switch (_action)
                {
                    case "Copy":
                        DeleteFile(_toPath,true);
                        break;
                    case "Move":
                        MoveFile(_toPath,_fromPath,false);
                        break;
                }
            }
        }



        private string RenameOnCollision(string path,int count)
        {
            count++;
            
            if (Directory.Exists(path) || File.Exists(path))
            {
                string prefix = Path.GetFileNameWithoutExtension(path)?.Split('(')[0]+"(";
                path = Path.GetDirectoryName(path)  + prefix + count + ")" + Path.GetExtension(path);
                return RenameOnCollision(path,count);
            }
            else
            {
                return path;
            }

            
        }

        private void ImageIndexChanger(TreeNode e)
		{
           
            if (e.Level!=0) //Jika node root(level 0) maka jangan ubah icon
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
		}

		private void CopyFile(string from, string to)
		{
		    to = RenameOnCollision(to,0);
            _shFile = new SHFILEOPSTRUCT
            {
                hwnd = IntPtr.Zero,
                wFunc = FileFuncFlags.FO_COPY,
                fFlags = FILEOP_FLAGS.FOF_RENAMEONCOLLISION,
                pFrom = from + '\0' + '\0',
                pTo = to + '\0' + '\0',
                fAnyOperationsAborted = false,
                hNameMappings = IntPtr.Zero,
                lpszProgressTitle = ""
            };
            FileOperation.SHFileOperation(ref _shFile);
            _undoActions.Add(new UndoAction(from,to,"Copy"));
		}
        private static void MoveFile(string from, string to,bool undo)
        {
            _shFile = new SHFILEOPSTRUCT
            {
                hwnd = IntPtr.Zero,
                wFunc = FileFuncFlags.FO_MOVE,
                fFlags = FILEOP_FLAGS.FOF_RENAMEONCOLLISION,
                pFrom = from + '\0' + '\0',
                pTo = to + '\0' + '\0',
                fAnyOperationsAborted = false,
                hNameMappings = IntPtr.Zero,
                lpszProgressTitle = ""
            };
            FileOperation.SHFileOperation(ref _shFile);

            if (undo)
            {
                _undoActions.Add(new UndoAction(from, to, "Move")); 
            }
        }

        private static void DeleteFile(string from, bool permanent)
		{
            _shFile = new SHFILEOPSTRUCT
            {
                hwnd = IntPtr.Zero,
                wFunc = FileFuncFlags.FO_DELETE,
                fFlags = FILEOP_FLAGS.FOF_ALLOWUNDO | FILEOP_FLAGS.FOF_SIMPLEPROGRESS,
                pFrom = from + '\0' + '\0',
                //this._ShFile.pTo = to;
                fAnyOperationsAborted = false,
                hNameMappings = IntPtr.Zero,
                lpszProgressTitle = ""
            };
		    if (permanent)
		    {
		        _shFile.fFlags = FILEOP_FLAGS.FOF_NOCONFIRMATION;
		    }

            FileOperation.SHFileOperation(ref _shFile);
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
				DirectoryInfo info = new DirectoryInfo(path + PathSeparator);

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
				MessageBox.Show(this, @"Tidak boleh diakses", @"WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				
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
				PopulateTreeView(drive.Name.Replace(PathSeparator.ToString(), ""));
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
			    int topItemIndex = 0;
			    try
			    {
			        topItemIndex = listView1.TopItem.Index;
			    }
			    catch (Exception)
			    {
			        // ignored
                }
                listView1.BeginUpdate();

				listView1.Items.Clear();
				
				DirectoryInfo dir = new DirectoryInfo(path);

			    foreach(var folder in dir.GetDirectories())

			    {
                    var folderItem = new ListViewItem(folder.Name, 0);
			        folderItem.Name = path + folder.Name;
			        folderItem.SubItems.Add("Folder");
                    listView1.Items.Add(folderItem);
			    }

                foreach (var file in dir.GetFiles())
				{
				    var item = new ListViewItem(file.Name, 2);
				    item.Name = path + file.Name;
				    item.SubItems.Add("File");
				    item.SubItems.Add($"{file.Length/1024} KB");
                    listView1.Items.Add(item);
                }

                listView1.EndUpdate();
			    try
			    {
			        listView1.TopItem = listView1.Items[topItemIndex];
			    }
			    catch (Exception)
			    {
			        // ignored
			    }

			    contextMenuStrip1.Items[ContextMenuIndex.copy].Enabled = false;
			    contextMenuStrip1.Items[ContextMenuIndex.delete].Enabled = false;
			    contextMenuStrip1.Items[ContextMenuIndex.move].Enabled = false;
            }
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show(this, @"Tidak boleh diakses", @"WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			
		}

		/// <summary>
		/// Build treeview of folder
		/// </summary>
		/// <param name="path"></param>
		private void PopulateTreeView(string path)
		{
			TreeNode[] nodes = treeView1.Nodes.Find(path, true);
			if(nodes.Length != 0)
			{
				if (nodes[0].Nodes.Count != FolderList(path).Count)
				{
                    treeView1.BeginUpdate();
					nodes[0].Nodes.Clear();
					foreach (string folder in FolderList(path))
					{
						nodes[0].Nodes.Add(path+PathSeparator+folder, folder);
					    if (nodes[0].Level != 0)
					    {
					        nodes[0].ImageIndex = 1;
                        }
						nodes[0].Expand();
					}
                    treeView1.EndUpdate();
				}
			}
			else
			{
				var node = treeView1.Nodes.Add(path, path.Split(PathSeparator)[path.Split(PathSeparator).Length-1]);
			    node.ImageIndex = 3;
			    node.SelectedImageIndex = 3;
            }
		}



        public Form1()
        {
            InitializeComponent();
			treeView1.ImageList = imageList1;
			contextMenuStrip1.Items[ContextMenuIndex.copy].Enabled = false; 
            contextMenuStrip1.Items[ContextMenuIndex.delete].Enabled = false;
            contextMenuStrip1.Items[ContextMenuIndex.move].Enabled = false;
            contextMenuStrip1.Items[ContextMenuIndex.undo].Enabled = false;
        }
		private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
		    {
		        var fullpaths = e.Node.FullPath;
		        PopulateTreeView(fullpaths);
		    }

		    ImageIndexChanger(e.Node);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			PopulateDrives();
			treeView1.SelectedNode = treeView1.Nodes[0];
			//Console.WriteLine(treeView1.Nodes.Find("C:", true).Count());
		}

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
            currentFolder.Text = e.Node.FullPath+PathSeparator;
            PopulateListView(currentFolder.Text);
        }

		private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{

			ImageIndexChanger(e.Node);
		}

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_fileSelectedPath = listView1.SelectedItems[0].Name;
			_fileSelectedName = listView1.SelectedItems[0].Text;
			contextMenuStrip1.Items[ContextMenuIndex.paste].Enabled = true;
            contextMenuStrip1.Items[ContextMenuIndex.paste].Tag = "copy";
        }

        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fileSelectedPath = listView1.SelectedItems[0].Name;
            _fileSelectedName = listView1.SelectedItems[0].Text;
            contextMenuStrip1.Items[ContextMenuIndex.paste].Enabled = true;
            contextMenuStrip1.Items[ContextMenuIndex.paste].Tag = "move";
        }

		private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
            if((string)contextMenuStrip1.Items[ContextMenuIndex.paste].Tag == "copy")
            {
                CopyFile(_fileSelectedPath, currentFolder.Text + _fileSelectedName);
                //Microsoft.VisualBasic.FileIO.FileSystem.CopyFile(FileSelectedPath,treeView1.SelectedNode.FullPath+pathSeparator+FileSelectedName);
                contextMenuStrip1.Items[ContextMenuIndex.paste].Enabled = false;
                contextMenuStrip1.Items[ContextMenuIndex.undo].Enabled = true;
                contextMenuStrip1.Items[ContextMenuIndex.undo].Text = $@"Undo {_undoActions[_undoActions.Count - 1].GetAction()}";
                PopulateListView(currentFolder.Text);
                
                listView1.Items.Find(_undoActions[_undoActions.Count-1].GetTo(), false)[0].Selected = true; // select copyed file
            }
            else
            {
                MoveFile(_fileSelectedPath, currentFolder.Text + _fileSelectedName,true);
                contextMenuStrip1.Items[ContextMenuIndex.paste].Enabled = false;
                listView1.Items.Add(currentFolder.Text + _fileSelectedName, _fileSelectedName);
                contextMenuStrip1.Items[ContextMenuIndex.undo].Enabled = true;
                contextMenuStrip1.Items[ContextMenuIndex.undo].Text = $@"Undo {_undoActions[_undoActions.Count - 1].GetAction()}";
                PopulateListView(currentFolder.Text);

                listView1.Items.Find(_undoActions[_undoActions.Count - 1].GetTo(), false)[0].Selected = true;
            }
			
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
            var result = MessageBox.Show(this, @"Delete file/folder to Recycle Bin?", @"DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result == DialogResult.Yes)
            {
                var filePath = listView1.SelectedItems[0].Name;
                DeleteFile(filePath,false);
                PopulateListView(currentFolder.Text);
            }
		}

        private void listView1_MouseDown(object sender, MouseEventArgs e)
		{
		    if (sender is ListView item && (e.Button == MouseButtons.Right && item.SelectedItems.Count != 0))
			{
				Console.WriteLine(item.SelectedItems[0].Name);
			}
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (listView1.SelectedItems.Count != 0)
            {
                contextMenuStrip1.Items[ContextMenuIndex.copy].Enabled = true;
                contextMenuStrip1.Items[ContextMenuIndex.move].Enabled = true;
                contextMenuStrip1.Items[ContextMenuIndex.delete].Enabled = true;
            }
            else
            {
                contextMenuStrip1.Items[ContextMenuIndex.copy].Enabled = false;
                contextMenuStrip1.Items[ContextMenuIndex.delete].Enabled = false;
                contextMenuStrip1.Items[ContextMenuIndex.move].Enabled = false;
            }
            
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                contextMenuStrip1.Items[ContextMenuIndex.copy].Enabled = true;
                contextMenuStrip1.Items[ContextMenuIndex.move].Enabled = true;
                contextMenuStrip1.Items[ContextMenuIndex.delete].Enabled = true;
            }
            else
            {
                contextMenuStrip1.Items[ContextMenuIndex.copy].Enabled = false;
                contextMenuStrip1.Items[ContextMenuIndex.delete].Enabled = false;
                contextMenuStrip1.Items[ContextMenuIndex.move].Enabled = false;
            }
        }

        private void ListView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                contextMenuStrip1.Items[ContextMenuIndex.copy].Enabled = true;
                contextMenuStrip1.Items[ContextMenuIndex.move].Enabled = true;
                contextMenuStrip1.Items[ContextMenuIndex.delete].Enabled = true;
            }
            else
            {
                contextMenuStrip1.Items[ContextMenuIndex.copy].Enabled = false;
                contextMenuStrip1.Items[ContextMenuIndex.delete].Enabled = false;
                contextMenuStrip1.Items[ContextMenuIndex.move].Enabled = false;
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_undoActions.Count >=1)
            {
                _undoActions[_undoActions.Count - 1].Undo();
                _undoActions.RemoveAt(_undoActions.Count - 1);
                PopulateListView(currentFolder.Text);
                if (_undoActions.Count == 0)
                {
                    contextMenuStrip1.Items[ContextMenuIndex.undo].Text = $@"Undo";
                    contextMenuStrip1.Items[ContextMenuIndex.undo].Enabled = false;
                }
                else
                {
                    contextMenuStrip1.Items[ContextMenuIndex.undo].Text = $@"Undo {_undoActions[_undoActions.Count - 1].GetAction()}";
                }
            }
        }
    }
}
