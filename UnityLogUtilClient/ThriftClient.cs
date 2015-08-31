using UnityEngine;
using System.Collections;
using Thrift.Transport;
using Thrift.Protocol;
using System.Collections.Generic;
using Thrift;
using System;
using System.Threading;

public class ThriftClient
{
    public static ThriftClient Instance = new ThriftClient();

    TTransport transport;
    SendLog.Client client;
    string strIp;
    int nPort;
    List<LogInfo> _lstInfo = new List<LogInfo>();
    bool _isStop = false;
    int _maxPerFrame = 888;         // 每次不能发送太多，反正卡住
    int _id = 1;
  
    public void Init(string strIp = "localhost", int port = 9090)
    {
        this.strIp = strIp;
        this.nPort = port;

        try
        {
            transport = new TSocket(strIp, port);
            TProtocol protocol = new TBinaryProtocol(transport);
            client = new SendLog.Client(protocol);
            transport.Open();

            ThreadStart start = new ThreadStart(() =>
            {
                while (!_isStop)
                {
                    Update();
                    Thread.Sleep(100);
                }
            });
            Thread thread = new Thread(start);
            thread.Start();
        }
        catch (Exception x)
        {
            Debug.LogError("日志服务器连接失败！");
        }
    }

    // 接收参数为unity的logType
    public void SendLog(string content, string category, UnityEngine.LogType logType) 
    {
        UtilLogType logMessageType = UtilLogType.COMMON;
        switch (logType)
        {
            case UnityEngine.LogType.Assert:
                logMessageType = UtilLogType.ERROR;
                break;
            case UnityEngine.LogType.Error:
                logMessageType = UtilLogType.ERROR;
                break;
            case UnityEngine.LogType.Exception:
                logMessageType = UtilLogType.EXCEPTION;
                break;
            case UnityEngine.LogType.Log:
                logMessageType = UtilLogType.COMMON;
                break;
            case UnityEngine.LogType.Warning:
                logMessageType = UtilLogType.WARNING;
                break;
            default:
                break;
        }

        SendLog(content, category, logMessageType);
    }

    public void SendLog(string content = "测试Log", string category = "default", UtilLogType type = UtilLogType.COMMON) 
    {
        if (!transport.IsOpen)
        {
            return;
        }

        LogInfo info = new LogInfo();
        info.Id = _id++;
        info.Content = content;
        info.DeviceName = "";
        info.LogType = type;
        info.Time = (int)System.DateTime.Now.TimeOfDay.TotalMilliseconds;
        info.Category = category;

        lock (_lstInfo)
        {
            _lstInfo.Add(info);
        }
    }

    public void Update() 
    {
        if (!transport.IsOpen)
        {
            return;
        }

        List<LogInfo> lstInfo = null;
        lock (_lstInfo)
        {
            int maxIndex = Math.Min(_lstInfo.Count, _maxPerFrame);
            lstInfo = _lstInfo.GetRange(0, maxIndex);
            _lstInfo.RemoveRange(0, maxIndex);
        }
        
        if (lstInfo.Count <= 0)
        {
            return;
        }

        try
        {
            Debug.Log("发送了LOG个数" + lstInfo.Count);
            client.send_log(lstInfo);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("发送失败！");
            Debug.LogError(ex.Message);
        }
    }

    public void Close() 
    {
        transport.Close();
        _isStop = true;
        Debug.Log("关闭log网络");
    }
}
