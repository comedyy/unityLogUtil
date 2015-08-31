
enum LogType {
  COMMON = 1,
  WARNING = 2,
  ERROR = 4,
  EXCEPTION = 8
}

struct LogInfo {
  1: LogType logType,
  2: i32 time,
  3: string DeviceName,
  4: string category,
  5: string content,
}

service SendLog {
   oneway void log(1:list<LogInfo> lstLogInfo)
}

