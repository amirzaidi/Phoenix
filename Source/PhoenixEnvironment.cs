using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading;
using Phoenix.Core;
using Phoenix.Storage;
namespace Phoenix
{
	internal sealed class PhoenixEnvironment
	{
		private static Dictionary<string, string> External_Texts;
		public PhoenixEnvironment()
		{
			PhoenixEnvironment.External_Texts = new Dictionary<string, string>();
		}

		public static void smethod_0(DatabaseClient DBClient)
		{
            Logging.Write("Loading external texts...");
			PhoenixEnvironment.EmptyExternalTexts();

			DataTable dataTable = DBClient.ReadDataTable("SELECT identifier, display_text FROM texts ORDER BY identifier ASC;");
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					PhoenixEnvironment.External_Texts.Add(dataRow["identifier"].ToString(), dataRow["display_text"].ToString());
				}
			}

			Logging.WriteLine("completed!");
		}

		public static string GetExternalText(string Name)
		{
			string result;

            try
            {
                if (PhoenixEnvironment.External_Texts != null && PhoenixEnvironment.External_Texts.Count > 0)
                {
                    result = PhoenixEnvironment.External_Texts[Name];
                }
                else
                {
                    result = Name;
                }
            }
            catch
            {
                result = Name;
            }

			return result;
		}

		public static void EmptyExternalTexts()
		{
			PhoenixEnvironment.External_Texts.Clear();
		}
	}
}