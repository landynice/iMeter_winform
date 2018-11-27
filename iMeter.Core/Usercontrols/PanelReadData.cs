using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Protocol.Core;

namespace iMeter
{
    public partial class PanelReadData : UserControl
    {
        public PanelReadData()
        {
            InitializeComponent();
            treeView1.ExpandAll();
        }


        bool needSetRelateCheck = true;
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            {
                if (!needSetRelateCheck)
                {
                    return;
                }

                //1、判断当前操作节点勾还是不勾
                //如果勾，当前节点下所有子节点都要勾上
                //如果不勾，下面子节点全部不勾
                TreeNode node = e.Node;
                if (node.Checked)
                {
                    node.Nodes.OfType<TreeNode>().ToList().ForEach(x => x.Checked = true);
                }
                else
                {
                    node.Nodes.OfType<TreeNode>().ToList().ForEach(x => x.Checked = false);
                }

                //2、如果当前节点被勾选，如果当前节点被勾选，则其上溯所有祖先节点都要勾
                //否则判断当前节点所有兄弟节点是否有勾，有则父节点要勾，没有则父节点不勾
                needSetRelateCheck = false; //为本方法上锁，确保连带影响不会运行本事件中代码
                if (node.Checked)
                {
                    while (node.Parent != null)
                    {
                        node = node.Parent;
                        node.Checked = true;
                    }
                }
                else
                {
                    while (node.Parent != null)
                    {
                        node = node.Parent;
                        bool hasCheckedChild = false;
                        foreach (TreeNode child in node.Nodes)
                        {
                            if (child.GetHashCode() == e.Node.GetHashCode())
                            {
                                continue;
                            }
                            if (child.Checked)
                            {
                                hasCheckedChild = true;
                                break;
                            }
                        }
                        if (!hasCheckedChild)
                        {
                            node.Checked = false;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                needSetRelateCheck = true; //为本方法解锁
            }
        }

        List<string> dataId = new List<string>();
        List<string> dataName = new List<string>();
        private const int dataid = 0;
        private const int dataname = 1;
        private const int datavalue = 2;
        private const int databackup = 3;
        private void btnRead_Click(object sender, EventArgs e)
        {
            dataId.Clear();
            dataName.Clear();
            dgvReadData.Rows.Clear();
            foreach (TreeNode n in treeView1.Nodes)
            {
                GetChildNodeValue(n);
            }
            for (int i = 0; i < dataId.Count; i++)
            {
                dgvReadData.Rows.Add();
                dgvReadData[dataid, i].Value = dataId[i].Substring(2);
                dgvReadData[dataname, i].Value = dataName[i];
                if (!cbIsReadIdOnly.Checked)
                {
                    string result = null;
                    Protocol645 p645 = new Protocol645();
                    if (p645.ReadData(dataId[i].Substring(2), out result))
                        dgvReadData[datavalue, i].Value = result;
                }
                dgvReadData.Update();
            }
        }
        /// <summary>
        /// 遍历treeview，返回最后子节点的name/text
        /// </summary>
        /// <param name="tn">输入节点</param>
        /// <returns>无返回</returns>
        private void GetChildNodeValue(TreeNode tn)
        {
            if (tn.Nodes.Count > 0)
            {
                foreach (TreeNode n in tn.Nodes)
                {
                    GetChildNodeValue(n);
                }
            }
            else
            {
                if (tn.Checked)
                {
                    dataId.Add(tn.Name);
                    dataName.Add(tn.Text);
                }
            }
        }


    }
}
