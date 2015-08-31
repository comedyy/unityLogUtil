using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogFrame
{
    public partial class Form1 : Form
    {
        Thread socketThread = null;
        int nDefaultPort = 9090;
        bool isStop = false;
        Dictionary<LogType, Color> _dicColor = new Dictionary<LogType, Color>();
        Dictionary<LogType, CheckBox> _dicCheckBox = new Dictionary<LogType, CheckBox>();
        Dictionary<LogType, Label> _dicCountLabel = new Dictionary<LogType, Label>();
        bool defalutPause = false;
        bool defaultSearchUp = false;
        string strDefaultPath = "C://MYLOG.txt";

        public Form1()
        {
            InitializeComponent();

            _dicColor[LogType.COMMON] = Color.Gray;
            _dicColor[LogType.WARNING] = Color.Orange;
            _dicColor[LogType.ERROR] = Color.Red;
            _dicColor[LogType.EXCEPTION] = Color.DeepPink;

            _dicCheckBox[LogType.COMMON] = checkBoxCommon;
            _dicCheckBox[LogType.WARNING] = checkBoxWarning;
            _dicCheckBox[LogType.ERROR] = checkBoxError;
            _dicCheckBox[LogType.EXCEPTION] = checkBoxException;

            _dicCountLabel[LogType.COMMON] = labelCommonCount;
            _dicCountLabel[LogType.WARNING] = labelWarningCount;
            _dicCountLabel[LogType.ERROR] = labelErrorCount;
            _dicCountLabel[LogType.EXCEPTION] = labelExceptionCount;

            DataMgr.Instance.OnLogCome = new Action<LogInfo>(AddToUI);
            DataMgr.Instance.IsPause = defalutPause;
            
            this.richTextBox1.BackColor = Color.Black;
            this.textBoxPort.Text = "" + nDefaultPort;

            foreach (LogType type in Enum.GetValues(typeof(LogType)))
            {
                _dicCheckBox[type].Checked = true;
                _dicCheckBox[type].ForeColor = _dicColor[type];
                _dicCountLabel[type].ForeColor = _dicColor[type];
            }

            checkBoxUp.Checked = defaultSearchUp;
            textBoxFilePath.Text = strDefaultPath;

            StartSocketThread(nDefaultPort);
        }

        // 重新载入数据
        private void ReLoadData()
        {
            // 界面重置
            lock (this)
            {
                this.richTextBox1.Text = "";
                foreach (LogType type in Enum.GetValues(typeof(LogType)))
                {
                    _dicCountLabel[type].Text = "0";
                }
            }

            // 开始往界面添加元素
            lock (DataMgr.Instance.LstData)
            {
                DataMgr.Instance.LstData.ForEach(m =>
                {
                    AddToUI(m);
                });
            }
        }

        // 添加一条到uI
        private void AddToUI(LogInfo log) 
        {
            AddLogCount(log.LogType, 1);
            if (Filter.Instatnce.IsFilterOK(log))
            {
                Color color = GetSelectionColor(log);
                string strContent = GetSelectionInfo(log);
                AddInfo(strContent, color);
            }
        }

        private void AddLogCount(LogType type, int nCount)
        {
            lock (this)
            {
                _dicCountLabel[type].Text = (int.Parse(_dicCountLabel[type].Text) + nCount) + "";
            }
        }

        // 设置画笔颜色
        private Color GetSelectionColor(LogInfo log)
        {
            return _dicColor[log.LogType];
        }

        // 返回log内容
        private string GetSelectionInfo(LogInfo log) 
        {
            return "[" + log.Category + "][" + log.Time + "][" + log.LogType.ToString() +"]:" + log.Content + "\n";
        }

        // 启动socket监听
        private void StartSocketThread(int nPort)
        {
            // 启动socket
            ThreadStart start = new ThreadStart(() =>
            {
                CSharpServer.StartSocket(nPort, AddAppInfo);
            });

            socketThread = new Thread(start);
            socketThread.Start();
        }

        // 停止socket
        private void StopSocketThread() 
        {
            CSharpServer.StopSocket();
        }

        // 监听
        private void buttonListen_Click(object sender, EventArgs e)
        {
            int nPort = 0;
            if (int.TryParse(this.textBoxPort.Text, out nPort) && nPort > 0)
            {
                StopSocketThread();
                StartSocketThread(nPort);
            }
        }

        // 打印应用程序信息
        public void AddAppInfo(string strInfo) 
        {
            AddInfo(strInfo, Color.White);
        }

        // 输出到窗口
        public void AddInfo(string strInfo, Color color)
        {
            if (this.richTextBox1 != null && !isStop)
            {
                lock (this.richTextBox1)
                {
                    this.richTextBox1.SelectionColor = color;
                    this.richTextBox1.AppendText(strInfo + "\n");
                }
            }
        }

        // t停止
        private void buttonPause_Click(object sender, EventArgs e)
        {
            DataMgr.Instance.IsPause = !DataMgr.Instance.IsPause;
            if (DataMgr.Instance.IsPause)
            {
                this.buttonPause.Text = "继续接收";
            }
            else
            {
                this.buttonPause.Text = "暂停接收";
                AddAppInfo("暂停接收消息");
            }
        }

        // 筛选各种异常
        private void OnCheckChange() 
        {
            int logType = (this.checkBoxCommon.Checked ? 1 : 0) * (int)LogType.COMMON
                              + (this.checkBoxWarning.Checked ? 1 : 0) * (int)LogType.WARNING
                              + (this.checkBoxError.Checked ? 1 : 0) * (int)LogType.ERROR
                              + (this.checkBoxException.Checked ? 1 : 0) * (int)LogType.EXCEPTION;

            AddAppInfo("当前过滤器logType：" + logType);
            Filter.Instatnce.SetLogType(logType);
            ReLoadData();
        }

        private void checkBoxCommon_CheckedChanged(object sender, EventArgs e)
        {
            OnCheckChange();
        }

        private void checkBoxWarning_CheckedChanged(object sender, EventArgs e)
        {
            OnCheckChange();
        }

        private void checkBoxError_CheckedChanged(object sender, EventArgs e)
        {
            OnCheckChange();
        }

        private void checkBoxException_CheckedChanged(object sender, EventArgs e)
        {
            OnCheckChange();
        }

        // 筛选
        private void buttonCategory_Click(object sender, EventArgs e)
        {
            List<string> lstCategory = richTextBox2.Text.Split(new char[]{'\n'}, StringSplitOptions.RemoveEmptyEntries).ToList();
            Filter.Instatnce.SetCategory(lstCategory);

            lstCategory.ForEach(m =>
            {
                AddAppInfo("添加筛选"+m);
            });

            if (lstCategory.Count == 0)
            {
                AddAppInfo("取消所有筛选");
            }

            ReLoadData();
        }

        // 清空
        private void buttonClear_Click(object sender, EventArgs e)
        {
            lock (DataMgr.Instance.LstData)
            {
                DataMgr.Instance.LstData = new List<LogInfo>();
            }

            ReLoadData();
            AddAppInfo("清空消息缓冲, 剩余数量" + DataMgr.Instance.LstData.Count);
        }


        // 查找操作
        int _lastPos = 0;
        int _lastLen = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            // 查找的字符串不存在
            string strFind = textBoxFind.Text;
            if (string.IsNullOrEmpty(strFind))
            {
                return;
            }

            // 取消选中状态
            if (richTextBox1.TextLength >= _lastPos + _lastLen)
            {
                richTextBox1.Select(_lastPos, _lastLen);
                richTextBox1.SelectionBackColor = Color.Black;
            }

            // 方向
            bool bSearchUp = checkBoxUp.Checked;
            int posBegin = 0;
            int posEnd = 0;

            if (bSearchUp)
            {
                posBegin = 0;
                posEnd = richTextBox1.SelectionStart;
            }
            else
            {
                posBegin = richTextBox1.SelectionStart + richTextBox1.SelectionLength;
                posEnd = richTextBox1.TextLength;
            }

            // 查找文字
            RichTextBoxFinds options = (checkBoxUp.Checked ? RichTextBoxFinds.Reverse : RichTextBoxFinds.None)
                                                      | (checkBoxWhole.Checked ? RichTextBoxFinds.WholeWord : RichTextBoxFinds.None);
            int pos = richTextBox1.Find(strFind, posBegin, posEnd, options);

            // 找到了设置高亮并且滚动到那里
            if (pos != -1)
            {
                richTextBox1.Select(pos, strFind.Length);
                richTextBox1.SelectionBackColor = Color.LightSkyBlue;
                richTextBox1.ScrollToCaret();

                _lastPos = pos;
                _lastLen = strFind.Length;
            }
        }

        private void buttonWriteFile_Click(object sender, EventArgs e)
        {
            string strPath = textBoxFilePath.Text;
            lock (DataMgr.Instance.LstData)
            {
                using (FileStream fs = new FileStream(strPath, FileMode.Create))
                {
                    byte[] data = new UTF8Encoding().GetBytes(richTextBox1.Text);
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                    fs.Close();
                }
            }
        }
    }
}
