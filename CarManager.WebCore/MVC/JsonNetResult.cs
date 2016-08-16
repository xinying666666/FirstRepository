using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json.Serialization;


namespace CarManager.WebCore.MVC
{
    public class JsonNetResult : System.Web.Mvc.JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            var response = context.HttpContext.Response;
            //格式 是不是json
            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
            //编码
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
            var jsonSerializeSetting = new JsonSerializerSettings();
            //jsonSerializeSetting.ContractResolver = new CamelCasePropertyNamesContractResolver();//契约设置首字母小写
            jsonSerializeSetting.DateFormatString = "yyyy-MM-dd HH:mm:ss";

            var json = JsonConvert.SerializeObject(Data, Formatting.None, jsonSerializeSetting);

            response.Write(json);

        }
    }
}
