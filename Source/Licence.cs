/*using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using Phoenix.Util;
namespace Phoenix
{
	internal sealed class Licence
	{
		public static string Local
		{
			get
			{
				return "localhost";
			}
		}

		public static bool CheckHostsFile(bool StartLicenseEncryptionHash)
		{
			string environmentVariable = Environment.GetEnvironmentVariable("windir");
			string text = File.ReadAllText(environmentVariable + "\\system32\\drivers\\etc\\hosts");
			if (text == null || text.Contains("habboon") || text.Contains("otaku"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Phoenix.Destroy("Unable to contact licence server! Try again later", false);
                return true;
            }
			else
			{
				if (StartLicenseEncryptionHash)
				{
                    //Phoenix.string_5 = Licence.smethod_2(Phoenix.string_4, true);
				}
				return false;
			}
		}
		public static string smethod_1(string string_0, string string_1)
		{
			string text = "";
			string result;
			try
			{
				RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
				registryKey.SetValue("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", 0);
				registryKey.Flush();
				registryKey.Close();
				registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
				int num = (int)registryKey.GetValue("ProxyEnable");
				if (num != 0)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Phoenix.Destroy("Proxy detected - Phoenix is unable to connect to Otaku to verify your account details.", false);
					result = text;
					return result;
				}
				if (string_0 == "")
				{
					if (Licence.CheckHostsFile(false))
					{
						result = text;
						return result;
					}
					if (string_1.Contains(Convert.ToChar(46).ToString() + "php" + Convert.ToChar(63).ToString()))
					{
						text = Licence.smethod_2(string_1, true);
					}
				}
			}
			catch
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Phoenix.Destroy("Proxy detected - Phoenix is unable to connect to Otaku to verify your account details.", false);
				result = text;
				return result;
			}
			result = text;
			return result;
		}
		public static string smethod_2(string string_0, bool bool_0)
		{
			Phoenix @class = new Phoenix();
			Uri uri = new Uri(string_0);
			if (bool_0)
			{
				string host = uri.Host;
				//if (host == null || !(host == "localhost"))
				//{
				//	Console.ForegroundColor = ConsoleColor.Red;
				//	Phoenix.Destroy("Invalid Licence details found #0004", false);
				//	Phoenix.smethod_18();
				//}
			}
			WebProxy webProxy = new WebProxy(uri, true);
			webProxy.Address = WebRequest.DefaultWebProxy.GetProxy(uri);
			webProxy.BypassProxyOnLocal = WebRequest.DefaultWebProxy.IsBypassed(webProxy.Address);
			webProxy.Credentials = CredentialCache.DefaultCredentials;
			WebRequest webRequest = WebRequest.Create(uri);
			webRequest.Proxy = null;
			webRequest.Headers.Add("AuthName", Phoenix.string_6);
			webRequest.Headers.Add("AuthPass", Phoenix.string_7);
			webRequest.Headers.Add("AuthBuild", Phoenix.build.ToString());
			webRequest.Headers.Add("AuthMachine", Environment.MachineName);
			webRequest.Headers.Add("AuthServer", "Phoenix");
			WebResponse response = webRequest.GetResponse();
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (string text in response.Headers)
			{
				dictionary.Add(text, response.Headers[text]);
			}
			string result;
			if (string_0 == @class.string_3)
			{
				if (dictionary["AuthU"] != Phoenix.string_6.Length.ToString())
				{
					result = null;
					return result;
				}
				if (dictionary.ContainsKey("MinBuild"))
				{
					Phoenix.int_2 = (int)Convert.ToInt16(dictionary["MinBuild"]);
					Phoenix.int_1 = (int)Convert.ToInt16(dictionary["CurBuild"]);
					if (dictionary["ExtraData"].Length <= 2)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine();
						Console.WriteLine("Please update your profile settings on Otaku");
						result = null;
						return result;
					}
					Class13.bool_17 = Convert.ToBoolean(dictionary["dce"]);
					Class13.string_33 = dictionary["ExtraData"].Split(new char[]
					{
						':'
					})[0];
					Class13.int_12 = (int)Convert.ToInt16(dictionary["ExtraData"].Split(new char[]
					{
						':'
					})[1]);
					Class13.int_13 = (int)Convert.ToInt16(dictionary["ExtraData"].Split(new char[]
					{
						':'
					})[2]);
					if (Phoenix.int_2 <= 14986)
					{
						Phoenix.bool_0 = true;
					}
					else
					{
						if (Phoenix.int_2 > 14986)
						{
							Phoenix.bool_0 = false;
						}
					}
				}
				if (dictionary.ContainsKey("AuthGen"))
				{
					result = dictionary["AuthGen"];
					return result;
				}
			}
			Stream responseStream = response.GetResponseStream();
			StreamReader streamReader = new StreamReader(responseStream);
			return streamReader.ReadToEnd();
		}
	}
}
*/