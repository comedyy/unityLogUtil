/*
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements. See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership. The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License. You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied. See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */

using System;
using System.Collections.Generic;
using Thrift.Server;
using Thrift.Transport;
using System.Collections;
using System.Collections.Concurrent;

public class CalculatorHandler : SendLog.Iface
{
    List<LogInfo> lstStore = new List<LogInfo>();

    public CalculatorHandler()
    {
    }

    public void log(List<LogInfo> lstLogInfo)
    {
        DataMgr.Instance.AddLog(lstLogInfo);
    }
}

public class CSharpServer
{
    static TServer server = null;

    public static void StartSocket(int nPort, Action<string> debugAction)
    {
        try
        {
            CalculatorHandler handler = new CalculatorHandler();
            SendLog.Processor processor = new SendLog.Processor(handler);
            TServerTransport serverTransport = new TServerSocket(nPort);
            server = new TSimpleServer(processor, serverTransport);

           debugAction("开始监听端口：" + nPort);
            server.Serve();
        }
        catch (Exception x)
        {
            debugAction(x.StackTrace);
        }

        debugAction("停止监听, port:" + nPort);
    }

    public static void StopSocket()
    {
        if (server != null)
        {
            server.Stop();
        }
    }
}
