using System.IO;

namespace Folder_Editor_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadDrivesAndFolders(treeView1);
            LoadDrivesAndFolders(treeView2);
        }

        private void LoadDrivesAndFolders(TreeView treeView)
        {
            treeView.Nodes.Clear();
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    TreeNode driveNode = new TreeNode(drive.Name) { Tag = drive.Name };
                    treeView.Nodes.Add(driveNode);
                    LoadSubFoldersAndFiles(drive.Name, driveNode);
                }
            }
        }

        private void LoadSubFoldersAndFiles(string path, TreeNode node)
        {
            try
            {
                foreach (string dir in Directory.GetDirectories(path))
                {
                    TreeNode folderNode = new TreeNode(Path.GetFileName(dir)) { Tag = dir };
                    node.Nodes.Add(folderNode);
                    folderNode.Nodes.Add(new TreeNode("Loading..."));
                }

                foreach (string file in Directory.GetFiles(path))
                {
                    TreeNode fileNode = new TreeNode(Path.GetFileName(file)) { Tag = file };
                    node.Nodes.Add(fileNode);
                }
            }
            catch (UnauthorizedAccessException) { }
        }


        private void DeletePath(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                else if (Directory.Exists(path))
                {
                    // Directory.Delete(path, true);
                }
                else
                {
                    MessageBox.Show("Path not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DialogResult result = MessageBox.Show($"Are you sure you want to delete:\n{textBox1.Text}?",
                                       "Confirm Deletion",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeletePath(textBox1.Text);
                    RefreshTreeView(treeView1);
                }
                textBox1.Text = "";
            }

            if (textBox2.Text != "")
            {
                DialogResult result = MessageBox.Show($"Are you sure you want to delete:\n{textBox2.Text}?",
                                       "Confirm Deletion",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeletePath(textBox2.Text);
                    RefreshTreeView(treeView2);
                }
                textBox2.Text = "";
            }
        }


        private void RefreshTreeView(TreeView treeView)
        {
            HashSet<string> expandedNodes = new HashSet<string>();
            foreach (TreeNode node in treeView.Nodes)
            {
                StoreExpandedNodes(node, expandedNodes);
            }

            LoadDrivesAndFolders(treeView);

            foreach (TreeNode node in treeView.Nodes)
            {
                RestoreExpandedNodes(node, expandedNodes);
            }
        }
        private void StoreExpandedNodes(TreeNode node, HashSet<string> expandedNodes)
        {
            if (node.IsExpanded)
            {
                expandedNodes.Add(node.FullPath);
            }

            foreach (TreeNode child in node.Nodes)
            {
                StoreExpandedNodes(child, expandedNodes);
            }
        }

        private void RestoreExpandedNodes(TreeNode node, HashSet<string> expandedNodes)
        {
            if (expandedNodes.Contains(node.FullPath))
            {
                node.Expand();
            }

            foreach (TreeNode child in node.Nodes)
            {
                RestoreExpandedNodes(child, expandedNodes);
            }
        }


        private void CopyPath(string fromPath, string toPath)
        {
            try
            {
                if (File.Exists(fromPath))
                {
                    string destFile = Path.Combine(toPath, Path.GetFileName(fromPath));
                    File.Copy(fromPath, destFile, true);
                }
                else if (Directory.Exists(fromPath))
                {
                    string destFolder = Path.Combine(toPath, Path.GetFileName(fromPath));
                    CopyDirectory(fromPath, destFolder);
                }
                else
                {
                    MessageBox.Show("The source path does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Copy Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CopyDirectory(string sourceDir, string destDir)
        {
            Directory.CreateDirectory(destDir);

            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string destFile = Path.Combine(destDir, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }

            foreach (string subDir in Directory.GetDirectories(sourceDir))
            {
                string newDestDir = Path.Combine(destDir, Path.GetFileName(subDir));
                CopyDirectory(subDir, newDestDir);
            }
        }


        private void MovePath(string fromPath, string toPath)
        {
            try
            {
                if (File.Exists(fromPath))
                {
                    string destFile = Path.Combine(toPath, Path.GetFileName(fromPath));
                    File.Move(fromPath, destFile);
                }
                else if (Directory.Exists(fromPath))
                {
                    string destFolder = Path.Combine(toPath, Path.GetFileName(fromPath));
                    Directory.Move(fromPath, destFolder);
                }
                else
                {
                    MessageBox.Show("The source path does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Move Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string MoveOneLevelUp(string path)
        {
            try
            {
                DirectoryInfo parentDir = Directory.GetParent(path);
                if (parentDir != null)
                {
                    return parentDir.FullName;
                }
                else
                {
                    MessageBox.Show("Already at the root directory.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return path;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Navigation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return path; 
            }
        }
        private void ExpandTreeViewToPath(TreeView treeView, string path)
        {
            string[] parts = path.Split(Path.DirectorySeparatorChar);
            TreeNode currentNode = null;

            foreach (string part in parts)
            {
                if (string.IsNullOrEmpty(part)) continue;

                TreeNodeCollection nodes = currentNode == null ? treeView.Nodes : currentNode.Nodes;
                currentNode = nodes.Cast<TreeNode>().FirstOrDefault(n => n.Text.Equals(part, StringComparison.OrdinalIgnoreCase));

                if (currentNode == null) return; 

                currentNode.Expand();
            }

            if (currentNode != null)
            {
                treeView.SelectedNode = currentNode;
                treeView.SelectedNode.EnsureVisible(); 
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            RefreshTreeView(treeView1);
            RefreshTreeView(treeView2);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            textBox1.Text = e.Node.Tag.ToString();
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "Loading...")
            {
                e.Node.Nodes.Clear();
                LoadSubFoldersAndFiles(e.Node.Tag.ToString(), e.Node);
            }
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            textBox2.Text = e.Node.Tag.ToString();
        }

        private void treeView2_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "Loading...")
            {
                e.Node.Nodes.Clear();
                LoadSubFoldersAndFiles(e.Node.Tag.ToString(), e.Node);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CopyPath(textBox1.Text, textBox2.Text);
            RefreshTreeView(treeView1);
            RefreshTreeView(treeView2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MovePath(textBox1.Text, textBox2.Text);
            RefreshTreeView(treeView1);
            RefreshTreeView(treeView2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MovePath(textBox2.Text, textBox1.Text);
            RefreshTreeView(treeView1);
            RefreshTreeView(treeView2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CollapseOneLevel(treeView1);
            CollapseOneLevel(treeView2);
        }

        private void CollapseOneLevel(TreeView treeView)
        {
            List<TreeNode> nodesToCollapse = new List<TreeNode>();
            foreach (TreeNode node in treeView.Nodes)
            {
                FindDeepestExpandedNodes(node, nodesToCollapse);
            }
            foreach (TreeNode node in nodesToCollapse)
            {
                node.Collapse();
            }
        }

        private void FindDeepestExpandedNodes(TreeNode node, List<TreeNode> nodesToCollapse)
        {
            bool hasExpandedChild = false;

            foreach (TreeNode child in node.Nodes)
            {
                if (child.IsExpanded)
                {
                    hasExpandedChild = true;
                    FindDeepestExpandedNodes(child, nodesToCollapse);
                }
            }
            if (node.IsExpanded && !hasExpandedChild)
            {
                nodesToCollapse.Add(node);
            }
        }


    }

}
