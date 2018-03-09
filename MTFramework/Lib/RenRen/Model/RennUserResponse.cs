using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
"{\"response\":{
 * \"name\":\"我爱开发\",
 * \"id\":519980557,
 * \"avatar\":[
 *          {\"size\":\"TINY\",\"url\":\"http://hdn.xnimg.cn/photos/hdn321/20130718/1500/h_tiny_dqLH_a93500000cb2113e.jpg\"},
 *          {\"size\":\"HEAD\",\"url\":\"http://hdn.xnimg.cn/photos/hdn321/20130718/1500/h_head_pbRT_a93500000cb2113e.jpg\"},
 *          {\"size\":\"MAIN\",\"url\":\"http://hdn.xnimg.cn/photos/hdn321/20130718/1500/h_main_YpNa_a93500000cb2113e.jpg\"},
 *          {\"size\":\"LARGE\",\"url\":\"http://hdn.xnimg.cn/photos/hdn321/20130718/1500/h_large_VAHg_a93500000cb2113e.jpg\"}
 * ],
 * \"star\":0,
 * \"basicInformation\":{
 *          \"sex\":\"MALE\",
 *          \"birthday\":\"1990-6-6\",
 *          \"homeTown\":null},
 *          \"education\":[
 *                      {\"name\":\"清华大学\",\"year\":\"2001\",\"educationBackground\":\"MASTER\",\"department\":\"信息学院\"}
 *          ],
 *          \"work\":[
 *                      {\"name\":\"人人网\",\"time\":\"\",\"industry\":null,\"job\":null}
 *          ],
 *          \"like\":null,
 *          \"emotionalState\":null
 * }
}"
*/
namespace RennDotSDK.Model
{
    [Serializable]
    public class RennUserResponse
    {
        public RennUser response { get; set; }
    }

    [Serializable]
    public class RennUser
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<RennAvatar> avatar { get; set; }
    }

    [Serializable]
    public class RennAvatar
    {
        public string size { get; set; }
        public string url { get; set; }
    }
}
