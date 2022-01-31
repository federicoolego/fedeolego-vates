using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.MultiTouch;

namespace Core
{
    public static class DriverMobileExtensions
    {        
        public static void PressAndSwipe(this AppiumDriver<AppiumWebElement> mobileDriver, IWebElement element, double porcent, int loop = 0)
        {
            //String[] args = input.split(ESCAPED_INPUT_PARAMETER_DELIMITER);
            //Point objectCenter = getObjectCenterCoordinate(element.Location.);
            //int loop = Integer.parseInt(args[2]);
            int anchorX = element.Location.X;
            int startY = element.Location.Y;
            int moveY = (int)(startY * porcent / 100);
            //if (args[0].toLowerCase().equals("down"))
            //{
            //    moveY = moveY * -1;
            //}
            TouchAction touchAction = new TouchAction(mobileDriver);

            if (loop != 0)
            {
                for (int i = 0; i < loop; i++)
                {
                    touchAction.Press(anchorX, startY).Wait()
                            .MoveTo(anchorX, startY + moveY).Perform();
                } 
            }
            else
            {
                touchAction.Press(anchorX, startY).Wait()
                            .MoveTo(anchorX, startY + moveY).Perform();
            }
        }

        public static void Tap(this AppiumDriver<AppiumWebElement> mobileDriver, IWebElement element)
        {
            TouchAction touchAction = new TouchAction(mobileDriver);
            touchAction.Tap(element).Perform();
        }

        public static void LongPress(this AppiumDriver<AppiumWebElement> mobileDriver, IWebElement element)
        {
            TouchAction touchAction = new TouchAction(mobileDriver);
            touchAction.LongPress(element).Perform();
        }

        public static void MoveTo(this AppiumDriver<AppiumWebElement> mobileDriver, IWebElement element)
        {
            TouchAction touchAction = new TouchAction(mobileDriver);
            touchAction.MoveTo(element).Perform();
        }
    }
}
