using System;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Cw1
{
    public class Program
    {
        public static async System.Threading.Tasks.Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //int? tmp = 5;   //zmienna może przyjąć wartość null

            //string tmp1 = "str";    //string z małej

            //var tmp2 = "aaaaaa";
            //var tmp3 = 1;

            //Console.WriteLine($"{tmp1} {tmp2} {tmp}");

            //var path = @"Z:\APBD\Cw1";

            //var newPerson = new Person { FirstName = "Oskar"};

            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var htmlContent = await response.Content.ReadAsStringAsync();

                        var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]", RegexOptions.IgnoreCase);

                        var matches = regex.Matches(htmlContent);

                        foreach (var match in matches)
                        {
                            Console.WriteLine(match.ToString());
                        }
                    }
                }
            }            
        }
    }
}
