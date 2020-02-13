using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using UnityEngine;

public static class ReadExcelOnline
{
    private static string appName = "Unity";
    static string CLIENT_ID = "14638793229-otqfa8q3jt1lv43dkl5moihu4huqs2er.apps.googleusercontent.com";
    static string CLIENT_SECRET = "Z5a7IcBiiY5oSGDaxnbn0SVb";
    static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
    private static SheetsService service;

    public static void Connect()
    {
        service = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = GetCredential(),
            ApplicationName = appName,
        });
    }

    private static void Retrieving(string id, string sheetName, Action<IDictionary<int, Dictionary<int, string>>> callBack)
    {
        Spreadsheet spreadSheetData = service.Spreadsheets.Get(id).Execute();
        IList<Sheet> sheets = spreadSheetData.Sheets;
        if ((sheets == null) || (sheets.Count <= 0))
        {
            Debug.LogError("Not found any data!");
            return;
        }

        List<string> ranges = new List<string>();
        ranges.Add(sheetName);

        SpreadsheetsResource.ValuesResource.BatchGetRequest request = service.Spreadsheets.Values.BatchGet(id);
        request.Ranges = ranges;
        BatchGetValuesResponse response = request.Execute();

        foreach (ValueRange valueRange in response.ValueRanges)
        {
            string n = valueRange.Range.Split('!')[0];

            if (n[0] == "'"[0])
            {
                n = n.Remove(0, 1);
                n = n.Remove(n.Length - 1);
            }
            //Debug.Log(n);
            //Create json file
            if(n.Equals(sheetName))
                GetValue(valueRange, callBack);
        }

    }

    static UserCredential GetCredential()
    {       
        string scriptFilePath = "Assets/Resources/";
        FileInfo fi = new FileInfo(scriptFilePath);
        string scriptFolder = fi.Directory.ToString();
        scriptFolder.Replace('\\', '/');
        Debug.Log("Save Credential to: " + scriptFolder);

        UserCredential credential = null;
        ClientSecrets clientSecrets = new ClientSecrets();
        clientSecrets.ClientId = CLIENT_ID;
        clientSecrets.ClientSecret = CLIENT_SECRET;
        //try
        //{
        //    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
        //        clientSecrets,
        //        Scopes,
        //        "user",
        //        CancellationToken.None,
        //        new FileDataStore(scriptFolder, true)).Result;
        //}
        //catch (Exception e)
        //{
        //    Debug.LogError(e.ToString());
        //}

        return credential;
    }

    static void GetValue(ValueRange valueRange, Action<IDictionary<int, Dictionary<int, string>>> callBack)
    {
        //IDictionary<int, string> propertyNames = new Dictionary<int, string>(); //Dictionary of (column index, property name of that column)
        //IDictionary<int, string> dataTypes = new Dictionary<int, string>();     //Dictionary of (column index, data type of that column)
        IDictionary<int, Dictionary<int, string>> values = new Dictionary<int, Dictionary<int, string>>();  //Dictionary of (row index, dictionary of (column index, value in cell))
        int rowIndex = 0;
        foreach (IList<object> row in valueRange.Values)
        {
            int columnIndex = 0;
            foreach (string cellValue in row)
            {
                string value = cellValue;             
                if (!values.ContainsKey(rowIndex))
                {
                    values.Add(rowIndex, new Dictionary<int, string>());
                }
                values[rowIndex].Add(columnIndex, value);

                columnIndex++;
            }
            rowIndex++;
        }

        callBack(values);

    }

    public static void GetTable(string id, string sheetName, Action<IDictionary<int, Dictionary<int, string>>> callBack)
    {
        Retrieving(id, sheetName, callBack);
    }

    /// <summary>
    ///     Row and Col Start with 0
    /// </summary>
    /// <param name="id">Sheet Id</param>
    /// <param name="sheetName">Sheet Name</param>
    /// <param name="row">Row</param>
    /// <param name="col">Col</param>
    /// <returns>Value</returns>
    public static string GetValueAtRowAndCol(string id, string sheetName, int row, int col)
    {
        var s = "";
        GetTable(id, sheetName, (param) => { s = param[row][col]; });
        return s;
    }
}
