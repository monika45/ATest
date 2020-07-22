using System;
using XC.RSAUtil;
using System.Text;
using System.Web;
namespace ConsoleTest
{
    public class RsaTest
    {
        public RsaTest()
        {
        }

        public static void getSign()
        {

            //var extReserved = HttpUtility.UrlEncode("Here to fill in the Merchant reservation information", Encoding.UTF8);
            //var sysReserved = HttpUtility.UrlEncode("on2k0wSrVHUWcx-Bn66rGwlEp0pw", Encoding.UTF8);

            var extReserved = "Here to fill in the Merchant reservation information";
            var sysReserved = "on2k0wSrVHUWcx-Bn66rGwlEp0pw";

            string data = "accessMode=0&amount=0.01&bankId=&currency=&extReserved="+extReserved+"&notifyTime=1591930286051&orderId=WXd095362b5bb24bb4fa08239118c402&orderTime=2020-06-12 10:51:15&payType=17&productName=测试商品&requestId=dd957ade-c4d2-4c03-a2e1-abd800b2dad2&result=0&spending=0.00&sysReserved="+sysReserved+"&timeOffset=&tradeTime=2020-06-12 10:51:25&userName=890086000300106484";
            var rightSign = "c+0xqmQDApR3P6qn1wBhUP7dZ0mU+Nghmg9ddtI4V8Vd0QOvFGDItR2rEERbf00EjGONjhhCoEtSja6ezTbPjnKdDNfjgwbvTZ0ljneR1BrT3UjJvyilfRLxDPmu1I2ag5AYCfI5Bnb0TGgfFjDsLzNg+Mwpa8sJmddaF2xUynNA6o92IHeczr4WJwMtFFXKCtu2esmgNlyPfN5eT/8mZzKGiuR3QgZ7FHkcmHn0cFrv12pr7W1/LwnQW4gBJhm+mDXmWCGQpKGx5hYykX7VIwYoqtG1q4idTqHfUwh4zMYgLwnPb2xE1yDw0Pgj7fRbG45/3aKVFeALN3w5MjJrUQ==";
            var publicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAwqTS1Jw8CS4w2Mb9Dp1TmQjnYvYpqj6ExZ7R/xzFwwEJXXUdak9WgNd13nWK7IBfNjHNTYVVaeY4BRn9uak5L3UuCaSMdpQZ4QMPMqfNoHr5oh5qOc3v23x9UEUg0ZybehI7serCa2tVro34hRKgHNSQTucWUHA61L6NAKieUP7lmUMwnbG6Q/KLvfAXX919CgFWRLDj8UjbyyId5cpM7nHI3RPbmI7+0MphrepG/h2MHKM3HKX03zEFhdS/ZslocJINipwLyO8kbt4DWfzdOjFI7TUxaJcZGkKAzZ4/+zmiHa/snt5i10QcZwri8wMQxlNquRu1cmYiXxVVxGqugwIDAQAB";


            

            //rsa256
            var b = new RsaPkcs8Util(Encoding.UTF8, publicKey);
            var ok = b.VerifyData(data, rightSign, System.Security.Cryptography.HashAlgorithmName.SHA256, System.Security.Cryptography.RSASignaturePadding.Pkcs1);
            Console.WriteLine(ok.ToString());
        }
    }
}
