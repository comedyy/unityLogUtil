enum UtilLogType {
  COMMON = 1,
  WARNING = 2,
  ERROR = 4,
  EXCEPTION = 8
}

struct LogInfo {
  1: i32 id,
  2: UtilLogType logType,
  3: i32 time,
  4: string DeviceName,
  5: string category,
  6: string content,
}

service SendLog {
   oneway void log(1:list<LogInfo> lstLogInfo)
}

