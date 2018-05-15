using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Model
{
    public class LagouInfo
    {
        public string code;
        public Ccontent content;
        public string msg;
        public string requestId;
        public string resubmitToken;
        public string success;
    }

    public class Ccontent
    {
        public string currentPageNo;
        public string hasNextPage;
        public string hasPreviousPage;
        public string pageNo;
        public string pageSize;
        public List<Cresult> result;
        public string start;
        public string totalCount;
        public string totalPageCount;
    }

    public class Cresult
    {
        public string adWord;
        public string adjustScore;
        public string city;
        public string companyId;
        public List<string> companyLabelList;
        public string companyLogo;
        public string companyName;
        public string companyShortName;
        public string companySize;
        public string countAdjusted;
        public string createTime;
        public string createTimeSort;
        public string education;
        public string financeStage;
        public string formatCreateTime;
        public string haveDeliver;
        public string industryField;
        public string jobNature;
        public string leaderName;
        public string orderBy;
        public string positionAdvantage;
        public string positionFirstType;
        public string positionId;
        public string positionName;
        public string positionType;
        public string positonTypesMap;
        public string randomScore;
        public string relScore;
        public string salary;
        public string score;
        public string searchScore;
        public string showOrder;
        public string totalCount;
        public string workYear;
    }
}
