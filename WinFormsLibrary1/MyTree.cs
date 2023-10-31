using System;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsLibrary1
{
    public partial class MyTree : UserControl
    {
        public MyTree()
        {
            InitializeComponent();
            treeView1.AfterSelect += (sender, e) => _event?.Invoke(sender, e);

        }

        private event EventHandler _event;

        public event EventHandler SelectedNodeChanged
        {
            add
            {
                _event += value;
            }
            remove
            {
                _event -= value;
            }
        }

        public int SelectedIndex
        {
            get
            {
                if (treeView1.SelectedNode != null)
                {
                    return treeView1.SelectedNode.Index;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                if (treeView1.Nodes.Count > 0)
                {
                    if (value < treeView1.Nodes.Count && value > -1)
                    {
                        treeView1.SelectedNode = treeView1.Nodes[value];
                        treeView1.Focus();
                        return;
                    }
                }
            }
        }

        private List<string> config;
        public void SetConfig(List<string> config)
        {
            if (config == null)
                throw new NullReferenceException("Add not null config");
            this.config = config;
        }

        public void CreateTree<T>(T obj) where T : class, new()
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Object");
            }

            if (config == null)
            {
                throw new Exception("config must be initialized");
            }

            TreeNodeCollection nodes = treeView1.Nodes;
            foreach (string item in config)
            {
                bool flag = false;
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (obj.GetType().GetProperty(item)!.GetValue(obj)!.ToString() == nodes[i].Text)
                    {
                        nodes = nodes[i].Nodes;
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    TreeNode treeNode = nodes.Add(obj.GetType().GetProperty(item)!.GetValue(obj)!.ToString());
                    nodes = treeNode.Nodes;
                }
            }
        }

        public T GetSelectedNode<T>() where T : class, new()
        {
            TreeNode selNode = treeView1.SelectedNode;
            if (selNode?.FirstNode != null)
            {
                throw new Exception("Not a last level node");
            }
            if (treeView1.SelectedNode == null)
            {
                return null;
            }

            Stack<string> stack = new Stack<string>();
            for (TreeNode treeNode = treeView1.SelectedNode; treeNode != null; treeNode = treeNode.Parent)
            {
                stack.Push(treeNode.Text);
            }

            if (stack.Count != config.Count)
            {
                return null;
            }

            T val = new();
            foreach (string propertyName in config)
            {
                PropertyInfo prop = val.GetType().GetProperty(propertyName);
                string value = stack.Pop();

                var underlyingType = Nullable.GetUnderlyingType(prop.PropertyType);

                if (underlyingType != null)
                    prop?.SetValue(val, null);
                else
                    prop?.SetValue(val, Convert.ChangeType(value, prop?.PropertyType));
            }

            return val;
        }

        public void Clear()
        {
            treeView1.Nodes.Clear();
        }
    }
}