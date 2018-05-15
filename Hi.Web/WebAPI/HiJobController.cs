using Job.Common;
using Job.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace Hi.Web.WebAPI
{
    public class HiJobController : ApiController
    {
        #region 获取job基本信息
        /// <summary>
        /// 获取job基本信息
        /// </summary>
        /// <param name="place">地区(如:北京 上海)</param>
        /// <param name="key">关键字(如:.net)</param>
        /// <param name="sources">数据源[前程_智联_拉勾_猎聘 注意以'_'分割]</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
       // [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        public object GetJobBasicInfo(string place, string key, string sources, int pageIndex)
        {
            #region 组装要请求的url
            var getDic = DataClass.GetDic_hi(place);
            var city_liepin = getDic[2];
            var city_qiancheng = getDic[1];
            var city_zhilian = getDic[0];
            string url_智联招聘 = string.Format("http://sou.zhaopin.com/jobs/searchresult.ashx?jl={0}&kw={1}&p={2}", city_zhilian, key, pageIndex);
            string url_猎聘网 = string.Format("http://www.liepin.com/zhaopin/?key={0}&dqs={1}&curPage={2}", key, city_liepin, pageIndex);
            string url_前程无忧 = string.Format("http://search.51job.com/jobsearch/search_result.php?jobarea={0}&keyword={1}&curr_page={2}&fromJs=1", city_qiancheng, key, pageIndex);
            string url_拉勾网 = string.Format("http://www.lagou.com/jobs/positionAjax.json?city={0}", city_zhilian);
            #endregion

            var sourceList = sources.Split('_');
            if (sourceList.Length <= 0)
                return new { state = 0, messg = "您输入的数据源有误" };

            List<JobInfo> zpInfoList = new List<JobInfo>();
            JobRequest client = new JobRequest();
            foreach (var sourceValue in sourceList)
            {
                switch (sourceValue)
                {
                    case "前程":
                        client.GetRequest(ref zpInfoList, url_前程无忧, DataType.前程无忧);
                        break;
                    case "智联":
                        client.GetRequest(ref zpInfoList, url_智联招聘, DataType.智联招聘);
                        break;
                    case "猎聘":
                        client.GetRequest(ref zpInfoList, url_猎聘网, DataType.猎聘网);
                        break;
                    case "拉勾":
                        client.GetRequest(ref zpInfoList, url_拉勾网, DataType.拉勾网, pageIndex, key);
                        break;
                }
            }
            return zpInfoList;
        } 
        #endregion

        #region  获取job详细信息
        /// <summary>
        ///  获取job详细信息
        /// </summary>
        /// <param name="url"></param>        
        /// <returns></returns>
        public object GetJobDetailsInfo(string url)
        {
            #region 设置数据源
            //猎聘网 = 1,智联招聘 = 2,前程无忧 = 3,拉勾网 = 4
            DataType dateType = new DataType();
            if (url.Contains("zhaopin.com/"))
                dateType = DataType.智联招聘;
            else if (url.Contains("liepin.com/"))
                dateType = DataType.猎聘网;
            else if (url.Contains("51job.com/"))
                dateType = DataType.前程无忧;
            else if (url.Contains("lagou.com/"))
                dateType = DataType.拉勾网;
            #endregion
            JobRequest client = new JobRequest();
            var data = client.GetUrlInfo(url, dateType);
            return new { data = data };
        }
        public object GetDefault()
        {
            return "3123";
        }
        #endregion
    }
}