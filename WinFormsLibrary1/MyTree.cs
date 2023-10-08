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
            if (config == null)
                throw new NullReferenceException("Add not null config");
            if (obj == null)
                throw new NullReferenceException("Add not null list of objects");

            var elementType = obj.GetType();

            var currentLevelNodes = treeView1.Nodes;
            int curlvl = 1;
            foreach (var nodeName in config)
            {
                var propertyInfo = elementType.GetProperty(nodeName);
                if (propertyInfo != null)
                {
                    var propertyValue = propertyInfo.GetValue(obj).ToString();
                    if (!currentLevelNodes.ContainsKey(propertyValue))
                    {
                        if (curlvl == config.Count)
                        {
                            currentLevelNodes.Add(propertyValue);
                        }
                        else
                            currentLevelNodes.Add(propertyValue, propertyValue);
                    }
                    if (curlvl != config.Count)
                        currentLevelNodes = currentLevelNodes.Find(propertyValue, false)[0].Nodes;
                }
                else
                {
                    var fieldInfo = elementType.GetField(nodeName);
                    if (fieldInfo != null)
                    {
                        var fieldValue = fieldInfo.GetValue(obj).ToString();
                        if (!currentLevelNodes.ContainsKey(fieldValue))
                        {
                            if (curlvl == config.Count)
                            {
                                currentLevelNodes.Add(fieldValue);
                            }
                            else
                                currentLevelNodes.Add(fieldValue, fieldValue);
                        }
                        if (curlvl != config.Count)
                            currentLevelNodes = currentLevelNodes.Find(fieldValue, false)[0].Nodes;
                    }
                }
                curlvl++;
            }
        }
        public T GetSelectedNode<T>() where T : class, new()
        {
            if (treeView1.SelectedNode == null)
                return null;
            var curNode = treeView1.SelectedNode;
            if (curNode.Nodes.Count > 0)
                throw new Exception("Choose last node of tree (leaf)");
            var item = new T();
            for (int i = config.Count - 1; i >= 0; i--)
            {
                var pinfo = item.GetType().GetProperty(config[i]);
                if (pinfo != null)
                {
                    pinfo.SetValue(item, Convert.ChangeType(curNode.Text, pinfo.PropertyType));
                    curNode = curNode.Parent;
                }
            }
            return item;
        }
        public void Clear()
        {
            treeView1.Nodes.Clear();
        }
    }
}