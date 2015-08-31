using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DataMgr
{
    public static DataMgr Instance = new DataMgr();

    List<LogInfo> lstData = new List<LogInfo>();
    public List<LogInfo> LstData { get { return lstData; } set { lstData = value; } }

    public Action<LogInfo> OnLogCome { get; set; }
    public bool IsPause { get; set; }

    public void AddLog(LogInfo logInfo)
    {
        if (IsPause)
        {
            return;
        }

        lock (lstData)
        {
            lstData.Add(logInfo);
            OnLogCome(logInfo);
        }
    }
}
