using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;

public class INIParser
{
    private static string path = Path.Combine(Application.dataPath, "Dialogue.ini");
    private static Dictionary<string, Dictionary<string, string>> IniDictionary = new Dictionary<string, Dictionary<string, string>>();
    private static bool Initialized = false;


    private static bool FirstRead()
    {
        if (File.Exists(path))
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                string theSection = "";
                string theKey = "";
                string theValue = "";
                while (!string.IsNullOrEmpty(line = sr.ReadLine()))
                {
                    line.Trim();
                    if (line.StartsWith("[") && line.EndsWith("]"))
                    {
                        theSection = line.Substring(1, line.Length - 2);
                    }
                    else
                    {
                        string[] ln = line.Split(new char[] { '=' });
                        theKey = ln[0].Trim();
                        theValue = ln[1].Trim();
                    }
                    if (theSection == "" || theKey == "" || theValue == "")
                        continue;
                    PopulateIni(theSection, theKey, theValue);
                }
            }
        }
        else
        {
            Debug.Log(path + " could not be found.");
        }
        return true;
    }

    private static void PopulateIni(string _Section, string _Key, string _Value)
    {
        if (IniDictionary.ContainsKey(_Section))
        {
            if (IniDictionary[_Section].ContainsKey(_Key))
                IniDictionary[_Section][_Key] = _Value;
            else
                IniDictionary[_Section].Add(_Key, _Value);
        }
        else
        {
            Dictionary<string, string> neuVal = new Dictionary<string, string>();
            neuVal.Add(_Key.ToString(), _Value);
            IniDictionary.Add(_Section.ToString(), neuVal);
        }
    }




    /// <summary>
    /// Read data from INI file. Section and Key no in enum.
    /// </summary>
    /// <param name="_Section"></param>
    /// <param name="_Key"></param>
    /// <returns></returns>
    public static string IniReadValue(string _Section, string _Key)
    {
        if (!Initialized)
            FirstRead();
        if (IniDictionary.ContainsKey(_Section))
            if (IniDictionary[_Section].ContainsKey(_Key))
                return IniDictionary[_Section][_Key];
        return null;
    }

    public static int IniSectionCount(string _Section)
    {
        if (!Initialized)
            FirstRead();
        if (IniDictionary.ContainsKey(_Section))
        {
            return IniDictionary[_Section].Keys.Count;
        }
        return -1;
    }

    public static string[] IniSectionKeys(string _Section)
    {
        if (!Initialized)
            FirstRead();
        if(IniDictionary.ContainsKey(_Section))
        {
            string[] keys = new string[IniDictionary[_Section].Keys.Count];
            int i = 0;
            foreach(string s in IniDictionary[_Section].Keys)
            {
                keys[i++] = s;
            }
            return keys;
        }
        return new string[] { };
    }
}
