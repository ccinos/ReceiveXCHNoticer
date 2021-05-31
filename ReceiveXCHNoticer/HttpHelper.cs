using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ReceiveXCHNoticer {
  public class HttpHelper {
    /// <summary>
    /// 处理http GET请求
    /// </summary>
    /// <param name="url">请求的url地址</param>
    /// <returns></returns>
    public static string Get(string url) {
      System.GC.Collect();//垃圾回收，回收没有正常关闭的http链接
      string result = "";
      HttpWebRequest request = null;
      HttpWebResponse response = null;
      try {
        //设置最大链接数
        ServicePointManager.DefaultConnectionLimit = 200;
        //设置https验证方式
        if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase)) {
          ServicePointManager.ServerCertificateValidationCallback =
              new RemoteCertificateValidationCallback(CertificateValidation);
        }
        request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.UserAgent= "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0; QQWubi 133; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; CIBA; InfoPath.2)";

        //返回数据
        response = (HttpWebResponse)request.GetResponse();
        StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
        result = sr.ReadToEnd().Trim();
        sr.Close();
      }
      //处理多线程模式下线程中止
      //catch (System.Threading.ThreadAbortException e)
      //{
      //    System.Threading.Thread.ResetAbort();
      //}
      catch (Exception e) {
        throw new Exception(e.ToString());
      } finally {
        //关闭连接和流
        if (response != null) {
          response.Close();
        }
        if (request != null) {
          request.Abort();
        }
      }
      return result;
    }

    private static bool CertificateValidation(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) {
      // 认证正常，没有错误   
      return true;
    }
  }
}
