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
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer() { };

        int _nDefaultPort = 9090;
        bool _defalutPause = false;
        bool _defaultSearchUp = false;
        string _strDefaultPath = "C://MYLOG.txt";

        bool _isStop = false;
        int _readIndex = 0;     // 界面显示到了第几个log
       
        // log类型和颜色，控件
        Dictionary<UtilLogType, Color> _dicColor = new Dictionary<UtilLogType, Color>();
        Dictionary<UtilLogType, CheckBox> _dicCheckBox = new Dictionary<UtilLogType, CheckBox>();
        Dictionary<UtilLogType, Label> _dicCountLabel = new Dictionary<UtilLogType, Label>();

        public Form1()
        {
            InitializeComponent();

            _dicColor[UtilLogType.COMMON] = Color.Gray;
            _dicColor[UtilLogType.WARNING] = Color.Orange;
            _dicColor[UtilLogType.ERROR] = Color.Red;
            _dicColor[UtilLogType.EXCEPTION] = Color.DeepPink;

            _dicCheckBox[UtilLogType.COMMON] = checkBoxCommon;
            _dicCheckBox[UtilLogType.WARNING] = checkBoxWarning;
            _dicCheckBox[UtilLogType.ERROR] = checkBoxError;
            _dicCheckBox[UtilLogType.EXCEPTION] = checkBoxException;

            _dicCountLabel[UtilLogType.COMMON] = labelCommonCount;
            _dicCountLabel[UtilLogType.WARNING] = labelWarningCount;
            _dicCountLabel[UtilLogType.ERROR] = labelErrorCount;
            _dicCountLabel[UtilLogType.EXCEPTION] = labelExceptionCount;

            DataMgr.Instance.IsPause = _defalutPause;
            
            this.richTextBox1.BackColor = Color.Black;
            this.textBoxPort.Text = "" + _nDefaultPort;

            foreach (UtilLogType type in Enum.GetValues(typeof(UtilLogType)))
            {
                _dicCheckBox[type].Checked = true;
                _dicCheckBox[type].ForeColor = _dicColor[type];
                _dicCountLabel[type].ForeColor = _dicColor[type];
            }

            checkBoxUp.Checked = _defaultSearchUp;
            textBoxFilePath.Text = _strDefaultPath;

            StartSocketThread(_nDefaultPort);

            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            bool isReset = false;
            List<LogInfo> lstLogInfo = DataMgr.Instance.GetUnReadLog(ref _readIndex, 88);
            for (int i = 0; i < lstLogInfo.Count; i++ )
            {
                LogInfo m = lstLogInfo[i];
                if (m.Category == "ResetLogMirror")
                {
                    isReset = true;
                    DataMgr.Instance.PopFirst();
                    break;
                }
                else
                {
                    AddToUI(m);
                }
            }

            if (isReset) 
            {
                ReLoadData();
            }
        }

        // 重新载入数据
        private void ReLoadData()
        {
            // 界面重置
                this.richTextBox1.Text = "";
                foreach (UtilLogType type in Enum.GetValues(typeof(UtilLogType)))
                {
                    _dicCountLabel[type].Text = "0";
                }

            _readIndex = 0;
        }

        // 添加一条到uI
        private void AddToUI(LogInfo log) 
        {
            AddLogCount(log.LogType, 1);
            Color color = GetSelectionColor(log);
            string strContent = GetSelectionInfo(log);
            AddInfo(strContent, color);
        }

        private void AddLogCount(UtilLogType type, int nCount)
        {
            _dicCountLabel[type].Text = (int.Parse(_dicCountLabel[type].Text) + nCount) + "";
        }

        // 设置画笔颜色
        private Color GetSelectionColor(LogInfo log)
        {
            return _dicColor[log.LogType];
        }

        // 返回log内容
        private string GetSelectionInfo(LogInfo log) 
        {
            return "[" + log.Id+ "][" + log.Category + "][" + GetTime(log.Time) + "][" + log.LogType.ToString() + "]:" + log.Content + "\n";
        }

        private string GetTime(int microSecond) 
        {
            return string.Format("{0:D2}:{1:D2}:{2:D2}.{3:D3}"
                , microSecond / 1000 / 3600, (microSecond / 1000 / 60) % 60, (microSecond / 1000) % 60, microSecond % 1000);
        }

        // 启动socket监听
        private void StartSocketThread(int nPort)
        {
            // 启动socket
            ThreadStart start = new ThreadStart(() =>
            {
                CSharpServer.StartSocket(nPort, AddAppInfo);
            });

            Thread socketThread = new Thread(start);
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
            if (!_isStop)
            {
                this.richTextBox1.SelectionColor = color;
                this.richTextBox1.AppendText(strInfo + "\n");
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
            int logType = (this.checkBoxCommon.Checked ? 1 : 0) * (int)UtilLogType.COMMON
                              + (this.checkBoxWarning.Checked ? 1 : 0) * (int)UtilLogType.WARNING
                              + (this.checkBoxError.Checked ? 1 : 0) * (int)UtilLogType.ERROR
                              + (this.checkBoxException.Checked ? 1 : 0) * (int)UtilLogType.EXCEPTION;

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
            DataMgr.Instance.Clear();

            ReLoadData();
            AddAppInfo("清空了消息缓冲");
        }


        // 查找操作
        int _lastPos = 0;
        int _lastLen = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            // 查找的字符串不存在
            string strFind = textBoxFind.Text;
            if (string.IsNullOrEmpty(strFind) || richTextBox1.TextLength <= 0)
            {
                return;
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

            // 取消选中状态
            if (richTextBox1.TextLength >= _lastPos + _lastLen)
            {
                richTextBox1.Select(_lastPos, _lastLen);
                richTextBox1.SelectionBackColor = Color.Black;
            }

            // 找到了设置高亮并且滚动到那里
            if (pos != -1)
            {
                richTextBox1.Select(pos, strFind.Length);
                richTextBox1.SelectionBackColor = Color.LightSkyBlue;
                richTextBox1.ScrollToCaret();

                _lastPos = pos;
                _lastLen = strFind.Length;
            }
            else 
            {
                if (checkBoxUp.Checked)
                {
                    richTextBox1.SelectionStart = richTextBox1.TextLength;
                    richTextBox1.SelectionLength = 0;
                }
                else 
                {
                    richTextBox1.SelectionStart = 0;
                    richTextBox1.SelectionLength = 0;
                }
            }
        }

        private void buttonWriteFile_Click(object sender, EventArgs e)
        {
            string strPath = textBoxFilePath.Text;
            int logIndex = 0;
            List<LogInfo> lstLogInfo = DataMgr.Instance.GetUnReadLog(ref logIndex);
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
