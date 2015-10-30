using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DataMgr
{
    public static DataMgr Instance = new DataMgr();

    // log集合
    List<LogInfo> lstData = new List<LogInfo>();

    // 是否暂停
    public bool IsPause { get; set; }

    public bool isReset = false;

    // 网络层添加的log
    public void AddLog(List<LogInfo> lstLogInfo)
    {
        if (IsPause)
        {
            return;
        }

        lock (lstData)
        {
            foreach (LogInfo item in lstLogInfo)
            {
                if (item.Category == "ResetLogMirror")
                {
                    lstData = new List<LogInfo>();
                    isReset = true;
                }

                lstData.Add(item);
            }
        }
    }

    public void PopFirst()
    {
        lock (lstData)
        {
            if (lstData.Count >0)
            {
                lstData.RemoveAt(0);
            }
        }
    }

    // 取得未显示的log
    public List<LogInfo> GetUnReadLog(ref int nBeginIndex, int maxCount = 99999999) 
    {
        if (isReset)
        {
            nBeginIndex = 0;
            isReset = false;
        }

        List<LogInfo> lstLogInfo = new List<LogInfo>() ;
        lock (lstData)
        {
            int nLogCount = lstData.Count;
            int nCount = 0;
            for (int i = nBeginIndex; i < nLogCount && nCount < maxCount; i++ )
            {
                if (Filter.Instatnce.IsFilterOK(lstData[i]))
                {
                    lstLogInfo.Add(lstData[i]);
                    nCount++;
                }

                nBeginIndex++;
            }
        }

        return lstLogInfo;
    }

    // 清空
    public void Clear() {
        lock (lstData)
        {
            lstData = new List<LogInfo>();
        }
    }
}
