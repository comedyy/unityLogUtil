using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Filter
    {
        public static Filter Instatnce = new Filter();

        private int _logType = (int)UtilLogType.COMMON | (int)UtilLogType.ERROR | (int)UtilLogType.EXCEPTION | (int)UtilLogType.WARNING;
        public void SetLogType(int logType)
        {
            if (_logType != logType)
            {
                _logType = logType;
            }
        }

        private List<string> _lstLogCategory = new List<string>();
        public void SetCategory(List<string> lstCategory) 
        {
            _lstLogCategory = lstCategory;
        }

        // 过滤器
        public bool IsFilterOK(LogInfo info)
        {
            if (info.Category == "ResetLogMirror")
            {
                return true;
            }

            if (((int)info.LogType & _logType ) == 0)
            {
                return false;
            }

            if (_lstLogCategory.Count != 0)
            {
                bool bFind = false;
                _lstLogCategory.ForEach((m) =>
                {
                    if (null == info || info.Category == null)
                    {
                        return;
                    }

                    if (info.Category.StartsWith(m))
                    {
                        bFind = true;
                    }
                });

                return bFind;
            }

            return true;
        }
}
