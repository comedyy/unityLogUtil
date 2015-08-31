using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Filter
    {
        public static Filter Instatnce = new Filter();

        private int _logType = (int)LogType.COMMON | (int)LogType.ERROR | (int)LogType.EXCEPTION | (int)LogType.WARNING;
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
            if (((int)info.LogType & _logType ) == 0)
            {
                return false;
            }

            if (_lstLogCategory.Count != 0 &&  !_lstLogCategory.Contains(info.Category))
            {
                return false;
            }

            return true;
        }
}
