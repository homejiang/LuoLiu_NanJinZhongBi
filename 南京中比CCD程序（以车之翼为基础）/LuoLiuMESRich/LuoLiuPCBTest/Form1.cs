using ErrorService;
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
using System.Xml;

namespace LuoLiuPCBTest
{
    public partial class Form1 : Common.frmProduceBase
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\Administrator.WIN7-1605312040\Desktop\结果文件\保护板测试\20190706\ZT-20190705-13-CF-P00012_[10].xml");

            XmlElement root = null;
            root = doc.DocumentElement;
            XmlNodeList listNodes = null;
            XmlNodeList listNodes1 = null;
            //listNodes = root.SelectNodes("//@Begin | //@LotNumber | //@Model | //@Result | @End | /MPT_Data/Record/CellCount | /MPT_Data/Record/Barcode");
            listNodes = root.SelectNodes("//Balance/*");
            foreach (XmlElement element in listNodes)
            {
                //解析只有Cons个特性节点
                richTextBox1.Text += element.ParentNode.Name + "\n";
                richTextBox1.Text += element.Name + "\n"; 
                richTextBox1.Text += element.ParentNode.Attributes[0].InnerText + "\n";
                
                richTextBox1.Text += element.FirstChild.Attributes[0].InnerText + "\n";
                richTextBox1.Text += element.FirstChild.Attributes[1].InnerText + "\n";
                richTextBox1.Text += element.FirstChild.InnerText + "\n";

            }
            listNodes = doc.GetElementsByTagName("BLV");
            foreach (XmlElement element in listNodes)
            {
                //解析只有Cons个特性节点
                richTextBox2.Text += element.ParentNode.ParentNode.Name + " ";
                richTextBox2.Text += element.ParentNode.ParentNode.Attributes[0].InnerText + " ";
                richTextBox2.Text += element.ParentNode.Name + " ";
                richTextBox2.Text += element.Attributes[0].InnerText + " ";
                richTextBox2.Text += element.Attributes[1].InnerText + " ";
                richTextBox2.Text += element.InnerText+ "\n";
               // richTextBox1.Text += element.Attributes[0].InnerText + "\n";


            }
            //
            //this.dataGridView1.DataSource= ConvertXmlNodeListToDataTable(listNodes) as DataTable;
            //foreach (XmlNode node in listNodes)
            //{

            //    //this.textBox1.Text = node.InnerText;

            //    richTextBox1.Text += node.InnerText + "\n";
            //}
            //listNodes = root.SelectNodes("/MPT_Data/Record/ALLOCD");
            //foreach (XmlNode node in listNodes)
            //foreach (XmlElement element in listNodes)
            //// for (int i = 0; i < listNodes.Count; i++)
            //{
            //    //if (element.Attributes.Count == 2 && element.Name != "Balance")
            //    //{
            //    if(element.Name== "Balance")
            //    {

            //            richTextBox2.Text += element.Name + "\n";
            //            richTextBox2.Text += element.Attributes[0].InnerText + "\n";
            //            richTextBox2.Text += element.Attributes[1].InnerText + "\n";
            //            richTextBox2.Text += element.InnerText + "\n";



            //    //    

            //    }



            //    //richTextBox1.Text += element.Name + "\n";
            //    //richTextBox1.Text += element.Attributes[0].InnerText + "\n";
            //    //richTextBox1.Text += element.Attributes[1].InnerText + "\n";
            //    //richTextBox1.Text += element.InnerText + "\n";
            //    // }

            //}
            //{
            //    switch (node.Name)
            //    {
            //        case "Record":
            //            if (node.HasAttributes)
            //            {
            //                this.textBox1.Text = node.Attributes[0].InnerText;
            //                this.textBox2.Text = node.Attributes[1].InnerText;
            //                this.textBox3.Text = node.Attributes[2].InnerText;
            //                this.textBox4.Text = node.Attributes[3].InnerText;
            //            }
            //            break;
            //        //case "性别":
            //        //    this.textBox2.Text = node.InnerText;
            //        //    break;
            //        //case "年龄":
            //        //    this.textBox3.Text = node.InnerText;
            //        //    if (node.HasAttributes)
            //        //    {
            //        //        txtAgeType.Text = node.Attributes[0].InnerText;
            //        //    }
            //        //    break;
            //    }
            //    //this.textBox1.Text = node.ChildNodes.Item(0).ToString();
            //    //this.textBox2.Text = node.ChildNodes.Item(2).ToString();
            //    //this.textBox3.Text = node.ChildNodes.Item(3).ToString();
            //    //this.textBox4.Text = node.ChildNodes.Item(4).ToString();
            //}


        }

        public static DataTable ConvertXmlNodeListToDataTable(XmlNodeList xnl)
        {
            DataTable dt = new DataTable();
            int TempColumn = 0;

            foreach (XmlNode node in xnl.Item(0).ChildNodes)
            {
                TempColumn++;
                DataColumn dc = new DataColumn("31", System.Type.GetType("System.String"));
                DataColumn dc1 = new DataColumn("21", System.Type.GetType("System.String"));
                DataColumn dc2 = new DataColumn("22", System.Type.GetType("System.String"));
                DataColumn dc3 = new DataColumn("23", System.Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dt.Columns.Add(dc1);
                dt.Columns.Add(dc2);
                dt.Columns.Add(dc3);
                //if (dt.Columns.Contains(node.Attributes[0].InnerText))
                //{
                //    dt.Columns.Add(dc1.ColumnName = dc1.ColumnName + TempColumn.ToString());
                //}
                //else
                //{
                //    dt.Columns.Add(dc1);
                //}
            }
            foreach (XmlElement element in xnl)
            {
                DataRow dr = dt.NewRow();
                dr["23"] = element.ParentNode.Name;
                dr["31"] = decimal.Parse(element.InnerText.Replace("uA", "").Trim());
                dr["21"] = element.Attributes[0].InnerText;
                dr["22"] = element.Attributes[1].InnerText;
                dt.Rows.Add(dr);

            }    //  int ColumnsCount = dt.Columns.Count;
             
            return dt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
           string strPath = @"C:\Users\Administrator.WIN7-1605312040\Desktop\G_COM6___222_YF098_20190621163800#001_1";
            FileInfo fileInfo = new FileInfo(strPath);
            //string[] files = Directory.GetDirectories(strPath, "*");
            //DateTime det = DateTime.Parse("1900-1-1 00:00");
            //string strLastFileName = fileInfo.Name;
            //TimeSpan ts;
            //FileInfo fileInfoTemp;
            //foreach (string str in files)
            //{
            //    fileInfoTemp = new FileInfo(str);
            //    ts = fileInfoTemp.LastWriteTime - det;

            //    //获取最后的时间和文件
            //    if (ts.TotalSeconds > 0)
            //    {
            //        det = fileInfoTemp.LastWriteTime;
            //        strLastFileName = fileInfoTemp.Name;
            //    }

            //}
            //if (!strPath.EndsWith("\\"))
            //    strPath += "\\";
            // strPath = strPath + strLastFileName;
            //this.ShowMsg(strPath);
            string strLastFileName = fileInfo.Name;
            string[] files = Directory.GetFiles(strPath, "*.B2M");
            FileInfo fileInfos = new FileInfo(strPath);
            DateTime det = DateTime.Parse("1900-1-1 00:00");
            strLastFileName = fileInfos.Name;
            TimeSpan ts1;
            FileInfo fileInfoTemp1;
            foreach (string str in files)
            {

                fileInfoTemp1 = new FileInfo(str);
                ts1 = fileInfoTemp1.LastWriteTime - det;

                //获取最后的时间和文件
                if (ts1.TotalSeconds > 0)
                {
                    det = fileInfoTemp1.LastWriteTime;
                    strLastFileName = fileInfoTemp1.Name;
                }

            }
            if (!strPath.EndsWith("\\"))
                strPath += "\\";
            //strPath = strPath + strLastFileName;
            string[] filess = Directory.GetFiles(strPath, strLastFileName);
            this.ReadData(filess[0]);
        }
        private void ReadData(string sFile)
        {
            // _blRead = true;
            StreamReader sr = new StreamReader(sFile,System.Text.Encoding.Default);
            if (sr == null)
            {
                this.ShowMsg("文件\"" + sFile + "\"读取失败。");
                return;
            }
            StringBuilder sbPmdInfo = new StringBuilder();
            string strLineText;
            //for (int i = 0; i < 19; i++)
            //{
              
            //}
            while(!sr.EndOfStream)
            {
                strLineText = sr.ReadLine();
                sbPmdInfo.Append(strLineText);
                sbPmdInfo.Append("\r\n");
                richTextBox1.Text += strLineText + "\n";
            }

        }
        public DataView GetData()
        {
            string strPath = @"D:\Persons.xml";
            XmlDocument xmlDoc = new XmlDocument();
            DataSet ds = new DataSet();
            StringReader read = new StringReader(xmlDoc.SelectSingleNode(strPath).OuterXml);
            ds.ReadXml(read);
            return ds.Tables[0].DefaultView;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = true;
        }
        #region 获取XML文件的根元素
        /// <summary>
        /// 获取XML文件的根元素
        /// </summary>
        public XmlNode GetXmlRoot()
        {
            return  xmlDoc.DocumentElement;
        }
        #endregion

        private XmlDocument xmlDoc = new XmlDocument();
        XmlNode xmlnode;
        XmlElement xmlelem;
        #region 获取XML节点值
        /// <summary>
        /// 获取XML节点值
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public string GetNodeValue(string nodeName)
        {
            string strPath = @"D:\Persons.xml";
            xmlDoc = new XmlDocument();
            xmlDoc.Load(strPath);

            XmlNodeList xnl = xmlDoc.ChildNodes;
            foreach (XmlNode xnf in xnl)
            {
                XmlElement xe = (XmlElement)xnf;
                XmlNodeList xnf1 = xe.ChildNodes;
                foreach (XmlNode xn2 in xnf1)
                {
                    if (xn2.InnerText == nodeName)
                    {
                        XmlElement xe2 = (XmlElement)xn2;
                        return xe2.GetAttribute("value");
                    }
                }
            }
            return null;
        }
        #endregion
    }
}
