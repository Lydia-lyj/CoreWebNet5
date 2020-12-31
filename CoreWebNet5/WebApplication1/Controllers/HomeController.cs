using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            int a = 1;
            VerifyBreakpoint();
            VerifyEE();
            sum(5, 6);
           // Foo().Wait();
            InvokeFunc(); //set breakpoint1
            VerifyVisualize();
            VerifyCallStack();
            VerifyRecursion(10);

            try
            {
                string s1 = String.Format("{1}", "ab12");
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
            }

            if (a == 10)
            {
                VerifyException();
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        private static void VerifyVisualize()
        {
            string ht = "<html><body>hello world!</body><html>";
            string xml2 = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n<configuration>\r\n    <startup> \r\n        <supportedRuntime version=\"v4.0\" sku=\".NETFramework,Version=v4.6.1\" />\r\n    </startup>\r\n</configuration>";
            string json = "{\r\n    \"name\":\"中国\",\r\n    \"province\":[\r\n    {\r\n       \"名字\":\"黑龙江\",\r\n        \"城市\":{\r\n            \"城市\":[\"海冰\",\"长春\"]\r\n        }\r\n     },\r\n      {\r\n        \"名字\": \"广东\",\r\n        \"城市\": {\r\n          \"城市\": [ \"广州\", \"深圳\", \"厦门\" ]\r\n        }\r\n      },\r\n    {\r\n        \"名字\":\"陕西\",\r\n      \"城市\": {\r\n        \"城市\": [ \"西安\", \"延安\" ]\r\n      }\r\n    },\r\n    {\r\n        \"名字\":\"甘肃\",\r\n      \"城市\": {\r\n        \"城市\": [ \"兰州\" ]\r\n      }\r\n    }\r\n]\r\n}\r\n";

            DataTable dt = new DataTable("Table_AX");
            dt.Columns.Add("column0", System.Type.GetType("System.String"));
            DataColumn dc = new DataColumn("column1", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("column2", System.Type.GetType("System.Int32"));
            dt.Columns.Add("column3", System.Type.GetType("System.Guid"));
            dt.Columns.Add(dc);
            Guid guid = new Guid("00000000-0000-0000-0000-000000000000");
            for (int i = 0; i < 50; i++)
            {
                DataRow dr = dt.NewRow();
                dr["column0"] = "AX_" + i;
                dr["column1"] = true;
                dr["column2"] = i;
                dr["column3"] = guid;
                dt.Rows.Add(dr);
            }
            DataRow dr1 = dt.NewRow();
            dt.Rows.Add(dr1);
            int a = 10;  //add a breakpoint here

        }

        private static int sum(int v1, int v2)
        {
            return v1 + v2;
        }

        private async Task Foo()
        {
            await GenException();
        }

        static async void InvokeFunc()
        {
            Task theTask = ProcessAsync();
            int x = 2; // assignment
            await theTask; // set breakpoint2
        }

        static async Task ProcessAsync()
        {
            var result = await DoSomethingAsync();  // set breakpoint3 

            int y = 1;  // set breakpoint4
        }

        static async Task<int> DoSomethingAsync()
        {
            int z = 5;
            await Task.Delay(5000);  // set breakpoint5

            return z;
        }

        private async Task<string> GenException()
        {
            await Task.Delay(1000);
            return string.Format("{1}", "abc");
        }

        private void VerifyBreakpoint()
        {
            int iGlobal = 0;
            for (int i = 0; i < 50; i++)
            {
                iGlobal++; //set bp #1
                i++;
            }
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoOptimization)]
        private int VerifyEE()
        {
            List<string> fruits = new List<string> { "apple", "passionfruit", "banana", "mango", "orange", "blueberry", "grape", "strawberry" };
            IEnumerable<string> query = fruits.Where(fruit => fruit.Length < 6);
            foreach (string fruit in query)
            {
                Console.WriteLine(fruit);
            }

            object[] pList = new object[] { 1, "one", 2, "two", 3, "three" };
            var query1 = pList.OfType<string>();
            dynamic expObj = new ExpandoObject();
            expObj.FirstName = "Daffy";
            expObj.LastName = "Duck";

            Dictionary<string, string> mygroup = new Dictionary<string, string>() { { "Hannah","Zhang"},{ "Alex","Yao"},{ "Alisa","Zhang"}
                ,{ "Nelson","Yan"},{ "Richard","Zeng"},{ "Clarie","Kang"},{ "Qian","Wang"},{ "Serena","Wang"},{ "Maggie","Zhang"},{ "Cherry","Wu"}
                ,{ "Lynn","Zhang"},{ "Grace","Dong"} };

            return 0; //set bp #2
        }

        private int VerifyCallStack()
        {
            Worker e1 = new Worker(30000);
            Worker e2 = new Worker(500, 52);
            HourlyWorker e3 = new HourlyWorker(10000);

            return 0; //set bp #3
        }

        private void VerifyException()
        {
            while (true)
            {
                Thread.Sleep(100);

                try
                {
                    throw new InvalidOperationException();
                }
                catch (Exception ex)
                {
                }
            }
        }

        private int VerifyRecursion(int m)
        {
            if (m <= 1)
                return 1;
            return m * VerifyRecursion(m - 1);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
