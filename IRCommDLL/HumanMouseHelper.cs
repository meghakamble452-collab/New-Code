using System;
using System.Collections;
using System.Threading;
using System.Web.Script.Serialization;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace IRCommDLL;

internal class HumanMouseHelper
{
	private readonly IWebDriver _driver;

	private readonly IJavaScriptExecutor _js;

	private static int _rotationIndex = 0;

	private static readonly Random _rnd = new Random();

	internal HumanMouseHelper(IWebDriver driver)
	{
		if (driver == null)
		{
			string paramName = "driver";
			throw new ArgumentNullException(paramName);
		}
		_driver = driver;
		_js = (IJavaScriptExecutor)_driver;
	}

	internal double FastSyncMoveAndClickSafe()
	{
		try
		{
			string text = "\r\n(function(){\r\n    try {\r\n        var t0 = performance.now();\r\n        var w = window.innerWidth, h = window.innerHeight;\r\n        var cx = Math.round(w/2), cy = Math.round(h/2);\r\n        function rnd(min,max){ return Math.floor(Math.random()*(max-min+1)) + min; }\r\n        var targetX = Math.max(5, Math.min(w-5, cx + rnd(-80,80)));\r\n        var targetY = Math.max(5, Math.min(h-5, cy + rnd(-80,80)));\r\n        function dispatch(type, x, y, button){\r\n            var ev = new MouseEvent(type, {\r\n                bubbles: true, cancelable: true, view: window,\r\n                clientX: x, clientY: y, screenX: window.screenX + x, screenY: window.screenY + y,\r\n                button: button || 0\r\n            });\r\n            (document.elementFromPoint(x,y) || document.body).dispatchEvent(ev);\r\n        }\r\n        dispatch('mousemove', Math.round((cx + targetX)/2), Math.round((cy + targetY)/2), 0);\r\n        dispatch('mousemove', targetX, targetY, 0);\r\n        dispatch('mousedown', targetX, targetY, 0);\r\n        dispatch('mouseup', targetX, targetY, 0);\r\n        dispatch('click', targetX, targetY, 0);\r\n        var t1 = performance.now();\r\n        return JSON.stringify({ status:'ok', duration: Math.round(t1 - t0), x: targetX, y: targetY });\r\n    } catch (e) {\r\n        return JSON.stringify({ status:'error', message: String(e) });\r\n    }\r\n})();";
			string script = text;
			object obj = null;
			try
			{
				obj = ((IJavaScriptExecutor)_driver).ExecuteScript(script);
			}
			catch (Exception ex)
			{
				string text2 = "ExecuteScript threw: ";
				Console.WriteLine(text2 + ex.Message);
			}
			if (obj == null)
			{
				string value = "ExecuteScript returned null. Possible causes: JS threw before returning, page navigation, or cross-origin/frame issue.";
				Console.WriteLine(value);
				try
				{
					obj = ((IJavaScriptExecutor)_driver).ExecuteScript(script);
				}
				catch (Exception ex2)
				{
					string text3 = "Retry ExecuteScript also failed: ";
					Console.WriteLine(text3 + ex2.Message);
				}
				if (obj == null)
				{
					return -1.0;
				}
			}
			string text4 = (obj as string) ?? obj.ToString() ?? string.Empty;
			try
			{
				if (new JavaScriptSerializer().DeserializeObject(text4) is IDictionary dictionary)
				{
					string key = "status";
					if (dictionary.Contains(key))
					{
						string key2 = "status";
						string text5 = dictionary[key2].ToString();
						string text6 = "ok";
						if (text5 == text6)
						{
							string key3 = "duration";
							double num = Convert.ToDouble(dictionary[key3]);
							string format = "FastSyncMoveAndClick: duration={0} ms, coord=({1},{2})";
							object arg = num;
							string key4 = "x";
							object arg2 = dictionary[key4];
							string key5 = "y";
							Console.WriteLine(string.Format(format, arg, arg2, dictionary[key5]));
							return num;
						}
					}
				}
				string text7 = "JS returned error or unexpected payload: ";
				Console.WriteLine(text7 + text4);
				return -1.0;
			}
			catch (Exception ex3)
			{
				string text8 = "Failed to parse JS result: ";
				string message = ex3.Message;
				string text9 = " raw:";
				Console.WriteLine(text8 + message + text9 + text4);
				return -1.0;
			}
		}
		catch (Exception ex4)
		{
			string text10 = "FastSyncMoveAndClickSafe outer exception: ";
			Console.WriteLine(text10 + ex4.Message);
			return -1.0;
		}
	}

	internal bool ClickNextField(int waitSeconds = 20)
	{
		int num = Interlocked.Increment(ref _rotationIndex) - 1;
		num %= 3;
		if (num < 0)
		{
			num += 3;
		}
		By selector;
		switch (num)
		{
		default:
		{
			string cssSelectorToFind3 = "p-dropdown[formcontrolname='journeyQuota'] .ui-dropdown, p-dropdown#journeyQuota .ui-dropdown, p-dropdown[formcontrolname='journeyQuota'] .ui-dropdown-trigger";
			selector = By.CssSelector(cssSelectorToFind3);
			break;
		}
		case 1:
		{
			string cssSelectorToFind2 = "p-autocomplete[formcontrolname='destination'] input";
			selector = By.CssSelector(cssSelectorToFind2);
			break;
		}
		case 0:
		{
			string cssSelectorToFind = "p-autocomplete[formcontrolname='origin'] input";
			selector = By.CssSelector(cssSelectorToFind);
			break;
		}
		}
		try
		{
			IWebElement webElement2 = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitSeconds)).Until(delegate(IWebDriver driver)
			{
				try
				{
					IWebElement webElement = driver.FindElement(selector);
					if (webElement != null && webElement.Displayed && webElement.Enabled)
					{
						return webElement;
					}
				}
				catch
				{
				}
				return (IWebElement?)null;
			});
			if (webElement2 == null)
			{
				return false;
			}
			try
			{
				IJavaScriptExecutor js = _js;
				string script = "arguments[0].scrollIntoView({behavior:'auto', block:'center', inline:'center'});";
				js.ExecuteScript(script, webElement2);
			}
			catch
			{
			}
			Thread.Sleep(_rnd.Next(120, 360));
			string text = "\r\n(function(el, minSteps, maxSteps, randSeed){\r\n    try{\r\n        function rnd(min,max){ return Math.floor(Math.random()*(max-min+1))+min; }\r\n        // element rect\r\n        var rect = el.getBoundingClientRect();\r\n        var endX = Math.round(rect.left + rect.width * (0.25 + Math.random()*0.5)); // 25%..75%\r\n        var endY = Math.round(rect.top + rect.height * (0.25 + Math.random()*0.5));  // 25%..75%\r\n\r\n        // start somewhere random on viewport (but prefer edges)\r\n        var startX = Math.floor(Math.random() * window.innerWidth);\r\n        var startY = Math.floor(Math.random() * window.innerHeight);\r\n\r\n        // control point for curve\r\n        var cx = Math.round((startX + endX)/2 + (Math.random()*80 - 40));\r\n        var cy = Math.round((startY + endY)/2 + (Math.random()*80 - 40));\r\n\r\n        var steps = rnd(minSteps, maxSteps);\r\n        for(var i=0;i<=steps;i++){\r\n            var t = i/steps;\r\n            var x = Math.round(Math.pow(1-t,2)*startX + 2*(1-t)*t*cx + Math.pow(t,2)*endX);\r\n            var y = Math.round(Math.pow(1-t,2)*startY + 2*(1-t)*t*cy + Math.pow(t,2)*endY);\r\n            var mv = new MouseEvent('mousemove', {bubbles:true, cancelable:true, view:window, clientX:x, clientY:y, screenX: window.screenX + x, screenY: window.screenY + y, button:0});\r\n            (document.elementFromPoint(x,y) || document.body).dispatchEvent(mv);\r\n        }\r\n\r\n        // small randomized pause before down\r\n        var preDown = rnd(40, 160);\r\n        var down = new MouseEvent('mousedown', {bubbles:true, cancelable:true, view:window, clientX:endX, clientY:endY, screenX:window.screenX + endX, screenY:window.screenY + endY, button:0});\r\n        setTimeout(function(){\r\n            (document.elementFromPoint(endX,endY) || el).dispatchEvent(down);\r\n            // small pause then mouseup+click\r\n            var upDelay = rnd(60, 180);\r\n            setTimeout(function(){\r\n                var up = new MouseEvent('mouseup', {bubbles:true, cancelable:true, view:window, clientX:endX, clientY:endY, screenX:window.screenX + endX, screenY:window.screenY + endY, button:0});\r\n                (document.elementFromPoint(endX,endY) || el).dispatchEvent(up);\r\n                var clk = new MouseEvent('click', {bubbles:true, cancelable:true, view:window, clientX:endX, clientY:endY, screenX:window.screenX + endX, screenY:window.screenY + endY, button:0});\r\n                (document.elementFromPoint(endX,endY) || el).dispatchEvent(clk);\r\n            }, upDelay);\r\n        }, preDown);\r\n\r\n        return { status: 'ok', steps: steps, x: endX, y: endY };\r\n    }catch(e){\r\n        return { status: 'error', message: String(e) };\r\n    }\r\n})(arguments[0], arguments[1]||10, arguments[2]||28, arguments[3]||0);\r\n";
			string script2 = text;
			try
			{
				_js.ExecuteScript(script2, webElement2, 12, 26, 0);
			}
			catch (Exception ex)
			{
				try
				{
					webElement2.Click();
					return true;
				}
				catch
				{
					string text2 = "Fallback click failed: ";
					Console.WriteLine(text2 + ex.Message);
					return false;
				}
			}
			Thread.Sleep(_rnd.Next(200, 520));
			return true;
		}
		catch (WebDriverTimeoutException)
		{
			string value = "ClickNextField: element not visible/clickable for selector.";
			Console.WriteLine(value);
			return false;
		}
		catch (Exception ex3)
		{
			string text3 = "ClickNextField error: ";
			Console.WriteLine(text3 + ex3.Message);
			return false;
		}
	}
}
