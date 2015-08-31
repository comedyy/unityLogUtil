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
using Thrift;
using Thrift.Protocol;
using Thrift.Server;
using Thrift.Transport;

namespace CSharpTutorial
{
    public class CSharpClient
    {
        public static void Main()
        {
            try
            {
                TTransport transport = new TSocket("localhost", 9090);
                TProtocol protocol = new TBinaryProtocol(transport);
                SendLog.Client client = new SendLog.Client(protocol);

                transport.Open();
                try
                {
                    Random ran = new Random();
                    string strContent = "";
                    List<LogInfo> lstLogInfo = new List<LogInfo>();
                    for (int i = 0; i < 1000; i++ )
                    {
                        LogInfo info = new LogInfo();
                        info.Content = strContent;
                        strContent += i;
                        info.DeviceName = i.ToString();
                        info.LogType = (LogType)(2 << ran.Next(4));
                        info.Time = (int)DateTime.UtcNow.Ticks;
                        info.Category = "category" + i;
                        lstLogInfo.Add(info);
                    }

                    client.send_log(lstLogInfo);
                }
                finally
                {
                    transport.Close();
                }
            }
            catch (TApplicationException x)
            {
                Console.WriteLine(x.StackTrace);
            }

        }
    }
}
