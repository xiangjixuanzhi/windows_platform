using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;

namespace BojayCommon
{

    public partial class BojayClass : Form
    {


        private List<string[]> csvList = new List<string[]>();
        private List<string[]> iniList = new List<string[]>();

        private string ProjectName = "";
        private string TimerInitial = "0s";
        private string strErrorMsg = "";
        //private string LoadFullListviewFileName = "template.csv";
        private string LoadFullListviewFilePath = "";
        //private string LoadResultFileName = "myResult.csv";
        private string LoadResultFilePath = "";

        private int bPass = 0;

        //加载配置文件
        string TemplateSectionName = "TemplateFilePath";
        string ResultSectionName = "ResultFilePath";
        string ProjectSectionName = "ProjectName";
        string DefaultKeyName = "key";
        //.ini必须放在可执行文件路径下
        string ConfigurefilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configure.ini");
        private ClassControl BojayControl = new ClassControl();

        /*****************************************************/

        /*****************************************************/
        public void myTimer()
        {
            //新建一个Timer对象
            System.Windows.Forms.Timer showTextBoxTimer = new System.Windows.Forms.Timer();
            //设定多少秒后行动，单位是毫秒
            showTextBoxTimer.Interval = 1000;
            //到时所有执行的动作
            showTextBoxTimer.Tick += new EventHandler(ShowTimerTextBox);
            //启动计时
            showTextBoxTimer.Start();
        }
        public void ShowTimerTextBox(object Sender, EventArgs e)
        {

            if (ClassGlobal.bStartMeasureStatue == true)
            {
                ClassGlobal.count += 1;
                textBox_times.Text = ClassGlobal.count.ToString() + "s";
            }
            else
            {
            
                if (ClassGlobal.bFinishAllaction == true && ClassGlobal.bFinishPaintListview == false)
                {
                    PaintListview();
                    richTextBox_ShowErrorMessage.AppendText(strErrorMsg);
                    button_start.Enabled = true;
                    ClassGlobal.bFinishPaintListview = true;
                    ClassGlobal.count = 0;

                }
                else if (ClassGlobal.bFinishAllaction == true && ClassGlobal.bFinishPaintListview == true)
                {
                    
                }
            }

        }
        public void TearDown()
        {
            while(true)
            {
                // bStartMeasureStatue:false-->start按钮还没按下    true-->start按钮按下
                // bFinishAllaction:false-->测试中     true-->测试完成
                // bFinishPaintListview:false-->还没绘画完成      true-->绘画完成
                if (ClassGlobal.bStartMeasureStatue == false)
                {
                    continue;
                }
                BojayEntryClass.BojayEntryFunction();
                //Thread.Sleep(5000);
                ClassGlobal.bFinishAllaction = true;
                ClassGlobal.bStartMeasureStatue = false;
                break;
            }

        }
        /*****************************************************/

        /*****************************************************/
        // create main client
        public void CreateClient()
        {
            for (int index_col = 0; index_col < 5; index_col++)
            {
                ColumnHeader ch = new ColumnHeader();
                switch (index_col)
                {
                    case 0:
                        ch.Text = "Phase";
                        ch.TextAlign = HorizontalAlignment.Center;// just when OwnerDraw properties was setted as true
                        break;
                    case 1:
                        ch.Text = "Measurement";
                        ch.TextAlign = HorizontalAlignment.Left;
                        break;
                    case 2:
                        ch.Text = "Result";
                        ch.TextAlign = HorizontalAlignment.Center;
                        break;
                    case 3:
                        ch.Text = "Value";
                        ch.TextAlign = HorizontalAlignment.Center;
                        break;
                    case 4:
                        ch.Text = "Validator";
                        ch.TextAlign = HorizontalAlignment.Center;
                        break;
                    default:
                        break;
                }
                listView1.Columns.Add(ch);
            }

            foreach (ColumnHeader item in listView1.Columns)
            {
                switch (item.Text)
                {
                    case "Phase":
                        item.Width = (listView1.Width / 100) * 15;
                        break;
                    case "Measurement":
                        item.Width = (listView1.Width / 100) * 28;
                        break;
                    case "Result":
                        item.Width = (listView1.Width / 100) * 10;
                        break;
                    case "Value":
                        item.Width = (listView1.Width / 100) * 17;
                        break;
                    case "Validator":
                        item.Width = (listView1.Width / 100) * 30;
                        break;
                    default:
                        item.Width = -2;
                        break;
                }
            }
            // full client screen
            listView1.Columns[0].Width = listView1.ClientSize.Width
                                         - listView1.Columns[1].Width
                                         - listView1.Columns[2].Width
                                         - listView1.Columns[3].Width
                                         - listView1.Columns[4].Width;
        }
        /*****************************************************/

        /*****************************************************/
        // initial ui
        public void Auto_ChangeSize()
        {
            foreach (ColumnHeader item in listView1.Columns)
            {
                switch (item.Text)
                {
                    case "Phase":
                        item.Width = (listView1.Width / 100) * 15;
                        break;
                    case "Measurement":
                        item.Width = (listView1.Width / 100) * 28;
                        break;
                    case "Result":
                        item.Width = (listView1.Width / 100) * 10;
                        break;
                    case "Value":
                        item.Width = (listView1.Width / 100) * 17;
                        break;
                    case "Validator":
                        item.Width = (listView1.Width / 100) * 30;
                        break;
                    default:
                        item.Width = -2;
                        break;
                }
            }
            // full client screen
            listView1.Columns[0].Width = listView1.ClientSize.Width 
                                         - listView1.Columns[1].Width 
                                         - listView1.Columns[2].Width 
                                         - listView1.Columns[3].Width 
                                         - listView1.Columns[4].Width;

        }
        /*****************************************************/

        /*****************************************************/
        // read dataTable and save to csv file
        public void SaveCSV(DataTable dt, string fullPath)//table数据写入csv
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(fullPath);
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }
            System.IO.FileStream fs = new System.IO.FileStream(fullPath, System.IO.FileMode.Create,
                System.IO.FileAccess.Write);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, System.Text.Encoding.UTF8);
            string data = "";

            for (int i = 0; i < dt.Columns.Count; i++)//写入列名
            {
                data += dt.Columns[i].ColumnName.ToString();
                if (i < dt.Columns.Count - 1)
                {
                    data += ",";
                }
            }
            sw.WriteLine(data);

            for (int i = 0; i < dt.Rows.Count; i++) //写入各行数据
            {
                data = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string str = dt.Rows[i][j].ToString();
                    str = str.Replace("\"", "\"\"");//替换英文冒号 英文冒号需要换成两个冒号
                    if (str.Contains(',') || str.Contains('"')
                        || str.Contains('\r') || str.Contains('\n')) //含逗号 冒号 换行符的需要放到引号中
                    {
                        str = string.Format("\"{0}\"", str);
                    }

                    data += str;
                    if (j < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
            }
            sw.Close();
            fs.Close();
        }
        /*****************************************************/

        /*****************************************************/
        // read csv file and save to dataTable
        public DataTable OpenCSV(string filePath)//从csv读取数据返回table
        {
            System.Text.Encoding encoding = GetType(filePath); //Encoding.ASCII;//
            DataTable dt = new DataTable();
            System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open,
                System.IO.FileAccess.Read);

            System.IO.StreamReader sr = new System.IO.StreamReader(fs,encoding);

            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine = null;
            string[] tableHead = null;
            //标示列数
            int columnCount = 0;
            //标示是否是读取的第一行
            bool IsFirst = true;
            //逐行读取CSV中的数据
            while ((strLine = sr.ReadLine()) != null)
            {
                if (IsFirst == true)
                {
                    tableHead = strLine.Split(',');
                    IsFirst = false;
                    columnCount = tableHead.Length;
                    //创建列
                    for (int i = 0; i < columnCount; i++)
                    {
                        DataColumn dc = new DataColumn(tableHead[i]);
                        dt.Columns.Add(dc);
                    }
                }
                else
                {
                    aryLine = strLine.Split(',');
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < columnCount; j++)
                    {
                        dr[j] = aryLine[j];
                    }
                    dt.Rows.Add(dr);
                }
            }
            if (aryLine != null && aryLine.Length > 0)
            {
                dt.DefaultView.Sort = tableHead[0] + " " + "asc";
            }

            sr.Close();
            fs.Close();
            return dt;
        }
        /// 给定文件的路径，读取文件的二进制数据，判断文件的编码类型
        /// <param name="FILE_NAME">文件路径</param>
        /// <returns>文件的编码类型</returns>

        public System.Text.Encoding GetType(string FILE_NAME)
        {
            System.IO.FileStream fs = new System.IO.FileStream(FILE_NAME, System.IO.FileMode.Open,
                System.IO.FileAccess.Read);
            System.Text.Encoding r = GetType(fs);
            fs.Close();
            return r;
        }
        /// 通过给定的文件流，判断文件的编码类型
        /// <param name="fs">文件流</param>
        /// <returns>文件的编码类型</returns>
        public System.Text.Encoding GetType(System.IO.FileStream fs)
        {
            byte[] Unicode = new byte[] { 0xFF, 0xFE, 0x41 };
            byte[] UnicodeBIG = new byte[] { 0xFE, 0xFF, 0x00 };
            byte[] UTF8 = new byte[] { 0xEF, 0xBB, 0xBF }; //带BOM
            System.Text.Encoding reVal = System.Text.Encoding.Default;

            System.IO.BinaryReader r = new System.IO.BinaryReader(fs, System.Text.Encoding.Default);
            int i;
            int.TryParse(fs.Length.ToString(), out i);
            byte[] ss = r.ReadBytes(i);
            if (IsUTF8Bytes(ss) || (ss[0] == 0xEF && ss[1] == 0xBB && ss[2] == 0xBF))
            {
                reVal = System.Text.Encoding.UTF8;
            }
            else if (ss[0] == 0xFE && ss[1] == 0xFF && ss[2] == 0x00)
            {
                reVal = System.Text.Encoding.BigEndianUnicode;
            }
            else if (ss[0] == 0xFF && ss[1] == 0xFE && ss[2] == 0x41)
            {
                reVal = System.Text.Encoding.Unicode;
            }
            r.Close();
            return reVal;
        }
        /// 判断是否是不带 BOM 的 UTF8 格式
        /// <param name="data"></param>
        /// <returns></returns>
        private bool IsUTF8Bytes(byte[] data)
        {
            int charByteCounter = 1;  //计算当前正分析的字符应还有的字节数
            byte curByte; //当前分析的字节.
            for (int i = 0; i < data.Length; i++)
            {
                curByte = data[i];
                if (charByteCounter == 1)
                {
                    if (curByte >= 0x80)
                    {
                        //判断当前
                        while (((curByte <<= 1) & 0x80) != 0)
                        {
                            charByteCounter++;
                        }
                        //标记位首位若为非0 则至少以2个1开始 如:110XXXXX...........1111110X　
                        if (charByteCounter == 1 || charByteCounter > 6)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    //若是UTF-8 此时第一位必须为1
                    if ((curByte & 0xC0) != 0x80)
                    {
                        return false;
                    }
                    charByteCounter--;
                }
            }
            if (charByteCounter > 1)
            {
                throw new Exception("非预期的byte格式");
            }
            return true;
        }
        /*****************************************************/

        /*****************************************************/
        // load dataTable to listview
        private void LoadTableToListview(DataTable dt)
        {            
            for (int i = 0; i < dt.Rows.Count; i++) 
            {
                ListViewItem lvi_content = new ListViewItem();
                string str = "";
                for (int j = 0; j < dt.Columns.Count - 1; j++)
                {
                    str = dt.Rows[i][j].ToString();
                    if (j == 0)
                    {
                        lvi_content.SubItems[0].Text = str;
                    }
                    else if (j == dt.Columns.Count - 2)
                    {
                        lvi_content.SubItems.Add("");
                    }
                    else
                    {
                        lvi_content.SubItems.Add(str);
                    }

                }
                listView1.Items.Add(lvi_content);

            }
        }
        /*****************************************************/

        /*****************************************************/
        // fill the specified cell for text
        private void FillOneCell(int row, int column, string content)
        {
            listView1.Items[row].SubItems[column].Text = content;
            //string str = listView1.Items[row].SubItems[column].Text;
            //listView1.Items[row+1].SubItems[column].Text = str;
        }

        // fill the specified cell for color: 0->green;1->red
        private void FillOneCell(int row, int column, int color)
        {
            listView1.Items[row].UseItemStyleForSubItems = false;
            switch (color)
            {
                case 0:
                    listView1.Items[row].SubItems[column].BackColor = Color.Green;
                    break;
                case 1:
                    listView1.Items[row].SubItems[column].BackColor = Color.Red;
                    break;
                default:
                    break;
            }
            
        }
        /*****************************************************/

        /*****************************************************/
        // generate result csv file
        private bool GenerateResultFile(string fullPath, string[] resultList, string[] valueList)
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(fullPath);
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }
            System.IO.FileStream fs = new System.IO.FileStream(fullPath, System.IO.FileMode.Create,
                System.IO.FileAccess.Write);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, System.Text.Encoding.UTF8);


            // get listview measurement item header
            string data = "";
            DataTable Mesurement = OpenCSV(LoadFullListviewFilePath);

            for (int i = 0; i < Mesurement.Columns.Count; i++)
            {
                data += Mesurement.Columns[i].ColumnName.ToString();
                if (i < Mesurement.Columns.Count - 1)
                {
                    data += ",";
                }
            }
            sw.WriteLine(data);

            // judge the result and value list length
            if ((valueList.Length != Mesurement.Rows.Count) || (resultList.Length != Mesurement.Rows.Count))
            {
                return false;
            }

            
            for (int i = 0; i < Mesurement.Rows.Count; i++) //写入各行数据
            {
                data = "";
                data = Mesurement.Rows[i][0].ToString() + "," + Mesurement.Rows[i][1].ToString() + "," + resultList[i] + "," + valueList[i] + "," + Mesurement.Rows[i][4].ToString();
                sw.WriteLine(data);
            }
            sw.Close();
            fs.Close();
            return true;
        }
        /*****************************************************/

        /*****************************************************/
        // get value list
        private string[] GetColumnValueItem(string filePath)
        {
            //filePath = LoadResultFilePath;
            DataTable Mesurement = OpenCSV(filePath);
            string[] valueList = new String[Mesurement.Rows.Count];
            for (int i = 0; i<Mesurement.Rows.Count; i++)
            {
                //add your code, this is an example
                valueList[i] = i.ToString();
                
            }
            return valueList;
        }
        /*****************************************************/

        /*****************************************************/
        // rough parse value and limits
        private string[] ParseColumnValidatorItem(string filePath, string[] valueList)
        {
            DataTable Mesurement = OpenCSV(filePath);
            String[] resultList = new string[Mesurement.Rows.Count];
            for (int i = 0; i < Mesurement.Rows.Count; i++)
            {
                if (Mesurement.Rows[i][4].ToString() == "always pass")
                {
                    resultList[i] = "pass";
                }
                else
                {
                    bool err = DetailParseValidator(valueList[i], Mesurement.Rows[i][4].ToString());
                    if (err != true)
                    {
                        resultList[i] = "fail";
                    }
                    else
                    {
                        resultList[i] = "pass";
                    }
                    
                }
            }
            return resultList;
        }
        /*****************************************************/

        /*****************************************************/
        // detail parse value and limits
        private bool DetailParseValidator(string value, string validator)
        {
            float myValue = int.Parse(value);
            List<string> LimitsList = new List<string>();
            List<string> ValidatorList = new List<string>();
            string pattern = @"\d{1,}|\.";
            foreach (Match match in Regex.Matches(validator, pattern))
                LimitsList.Add(match.Value);
            for (int i = 0; i < LimitsList.ToArray().Length; i++)
            {
                if (LimitsList[i] == "." && i == LimitsList.ToArray().Length - 2)
                {
                    ValidatorList.Add(LimitsList[i - 1] + LimitsList[i] + LimitsList[i + 1]);
                    break;
                }
                else if (LimitsList[i] == "." && i == 1)
                {
                    ValidatorList.Add(LimitsList[i - 1] + LimitsList[i] + LimitsList[i + 1]);
                }
                else if ((i >= 1 && LimitsList[i - 1] != ".") || i == 0)
                {
                    if (i < LimitsList.ToArray().Length - 1 && LimitsList[i + 1] != "." && i != 0)
                    {
                        ValidatorList.Add(LimitsList[i - 1]);
                    }
                    else if (i == LimitsList.ToArray().Length - 1 || (i == 0 && LimitsList[i + 1] != "."))
                    {
                        ValidatorList.Add(LimitsList[i]);
                    }
                }
            }

            if (float.Parse(ValidatorList[0]) <= myValue && float.Parse(ValidatorList[1]) >= myValue)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        /*****************************************************/

        /*****************************************************/
        // release data on listview
        private bool PaintListview()
        {
            DataTable dt = OpenCSV(LoadResultFilePath);
            for (int i = 0; i < dt.Rows.Count; i++) 
            {
                
                for (int j = 2; j < dt.Columns.Count - 1; j++)
                {
                    string str = dt.Rows[i][j].ToString();
                    FillOneCell(i, j , str);
                    if (j == 2)
                    {
                        if (str == "fail")
                        {
                            FillOneCell(i, j , 1);
                            strErrorMsg += dt.Rows[i][1].ToString() + ":" + dt.Rows[i][5].ToString() + "\n";
                            bPass = 1;
                        }
                        else
                        {
                            FillOneCell(i, j , 0);
                        }
                        
                    }
                    
                }
            }
            if (bPass == 0)
            {
                label_show.Text = "PASS";
                richTextBox_ShowErrorMessage.BackColor = Color.Green;
                label_show.BackColor = Color.Green;
            }
            else
            {
                label_show.Text = "FAIL";
                richTextBox_ShowErrorMessage.BackColor = Color.Red;
                label_show.BackColor = Color.Red;
            }
            return true;
        }
        /*****************************************************/

        /*****************************************************/
        private void Form1_Load(object sender, EventArgs e)
        {
            #region load configure file
            // 1.project name
            ProjectName = INIHelper.Read(ProjectSectionName, DefaultKeyName, "", ConfigurefilePath);
            textBox_project.Text = ProjectName;

            // 2.full listview path
            LoadFullListviewFilePath = INIHelper.Read(TemplateSectionName, DefaultKeyName, "", ConfigurefilePath);

            // 3.result file path
            LoadResultFilePath = INIHelper.Read(ResultSectionName, DefaultKeyName, "", ConfigurefilePath);
            #endregion

            #region initial timer
            // initial timer 
            textBox_times.Text = TimerInitial;
            #endregion

            #region create and load dataTable to full client screen
            // create and load dataTable to full client screen
            CreateClient();
            DataTable dt = OpenCSV(LoadFullListviewFilePath);
            LoadTableToListview(dt);
            #endregion

            #region Simulate and generate result by author
            //// Simulate and generate result by author
            //string[] valueList = GetColumnValueItem(LoadFullListviewFilePath);
            //string[] resultList = ParseColumnValidatorItem(LoadFullListviewFilePath, valueList);
            //GenerateResultFile(LoadResultFilePath, resultList, valueList);
            #endregion

            #region start up myTimer
            // start up myTimer
            myTimer();
            #endregion
        }
        /*****************************************************/

        /*****************************************************/
        private void Start_Click(object sender, EventArgs e)
        {
            #region upload client screen
            // upload client screen
            ClassGlobal.ClickTimes += 1;
            if (ClassGlobal.ClickTimes >= 2)
            {
                listView1.Items.Clear();
                richTextBox_ShowErrorMessage.Text = "";
                richTextBox_ShowErrorMessage.BackColor = Color.White;
                label_show.Text = "";
                label_show.BackColor = Color.White;
                DataTable dt = OpenCSV(LoadFullListviewFilePath);
                LoadTableToListview(dt);
            }
            #endregion

            #region new thread to use C Plus Plus Dynamic link library
            // new thread
            Thread RunBojayDLLThread = new Thread(TearDown);
            RunBojayDLLThread.Start();
            #endregion

            #region set necessary variable
            // set variable
            strErrorMsg = "";
            button_start.Enabled = false;
            ClassGlobal.bFinishAllaction = false;
            ClassGlobal.bStartMeasureStatue = true;
            ClassGlobal.bFinishPaintListview = false;
            #endregion
            //strErrorMsg = "pass\npass\npass\npass\n\npass\npass\npass\n\npass\npass\n";
        }

        #region InitializeComponent and SizeChanged
        /*****************************************************/

        /*****************************************************/
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Auto_ChangeSize();
        }
        /*****************************************************/

        /*****************************************************/
        public BojayClass()
        {
            InitializeComponent();
        }
        /*****************************************************/

        /*****************************************************/
        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Orange, e.Bounds);
            e.DrawText();
        }
        /*****************************************************/

        /*****************************************************/
        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }
        /*****************************************************/

        /*****************************************************/
        #endregion

        /*****************************************************/

        /*****************************************************/
    }
}
