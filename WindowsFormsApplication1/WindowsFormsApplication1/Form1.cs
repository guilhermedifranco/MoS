﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO.Compression;
using System.Globalization;
using System.Collections.Specialized;
using System.Web;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        WebBrowser wb = new WebBrowser();
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void Navigate(string url)
        {
            wb.Navigate(url);
            while (wb.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile("http://www.gpro.net/gb/GetMarketFile.asp?market=drivers&type=json", "driversmarket.json.gz");

                string path = AppDomain.CurrentDomain.BaseDirectory;
                FileInfo fi = new FileInfo(path + "\\driversmarket.json.gz");
                Decompress(fi);

                LoadJson_drivers(path + "\\driversmarket.json");
            }
        }
        public static void Decompress(FileInfo fileToDecompress)
        {
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                        Console.WriteLine("Decompressed: {0}", fileToDecompress.Name);
                    }
                }
            }
        }


        public void LoadJson_drivers(string caminho_arquivo)
        {
            using (Entities db = new Entities())
            {
                db.Drivers.ToList().ForEach(f => f.Ativo = false);
                db.SaveChanges();
            }

            JObject o1 = JObject.Parse(File.ReadAllText(caminho_arquivo));

            //  var model = JsonConvert.DeserializeObject<List<Drivers>>(o1);

            bool add = false;

            //JToken jUser = o1["base"];

            JArray array = (JArray)o1["drivers"];
            foreach (var jUser in array)
            {
                using (Entities db = new Entities())
                {
                    int id = (int)jUser["ID"];
                    var d = db.Drivers.AsQueryable().Where(x => x.ID == id).FirstOrDefault();

                    // Drivers d = new Drivers();

                    if ((d) == null)
                    {
                        d = new Drivers();
                        d.ID = id;
                        add = true;
                    }

                    d.NAME = (string)jUser["NAME"];
                    d.NAT = (string)jUser["NAT"];
                    d.OA = (int)jUser["OA"];
                    d.CON = (int)jUser["CON"];
                    d.TAL = (int)jUser["TAL"];
                    d.EXP = (int)jUser["EXP"];
                    d.AGG = (int)jUser["AGG"];
                    d.TEI = (int)jUser["TEI"];
                    d.STA = (int)jUser["STA"];
                    d.CHA = (int)jUser["CHA"];
                    d.MOT = (int)jUser["MOT"];
                    d.REP = (int)jUser["REP"];
                    d.AGE = (int)jUser["AGE"];
                    d.WEI = (int)jUser["WEI"];
                    d.RET = (int)jUser["RET"];
                    d.SAL = (int)jUser["SAL"];
                    d.FEE = (int)jUser["FEE"];
                    d.OFF = (int)jUser["OFF"];
                    d.Last_updated = (DateTime)o1["Last updated"];
                    d.Ativo = true;
                    if (add)
                    {
                        db.Drivers.AddObject(d);
                        add = false;
                    }
                    db.SaveChanges();
                }
            }
        }

        public void LoadJson_TD(string caminho_arquivo)
        {
            using (Entities db = new Entities())
            {
                db.TD.ToList().ForEach(f => f.Ativo = false);
                db.SaveChanges();
            }
            JObject o1 = JObject.Parse(File.ReadAllText(caminho_arquivo));

            //  var model = JsonConvert.DeserializeObject<List<Drivers>>(o1);

            bool add = false;

            //JToken jUser = o1["base"];

            JArray array = (JArray)o1["tds"];
            foreach (var jUser in array)
            {
                using (Entities db = new Entities())
                {
                    int id = (int)jUser["ID"];
                    var d = db.TD.AsQueryable().Where(x => x.ID == id).FirstOrDefault();

                    // Drivers d = new Drivers();

                    if ((d) == null)
                    {
                        d = new TD();
                        d.ID = id;
                        add = true;
                    }

                    d.NAME = (string)jUser["NAME"];
                    d.NAT = (string)jUser["NAT"];
                    d.OA = (int)jUser["OA"];
                    d.LEA = (int)jUser["LEA"];
                    d.MEC = (int)jUser["MEC"];
                    d.ELE = (int)jUser["ELE"];
                    d.AER = (int)jUser["AER"];
                    d.EXP = (int)jUser["EXP"];
                    d.PIT = (int)jUser["PIT"];
                    d.MOT = (int)jUser["MOT"];
                    d.AGE = (int)jUser["AGE"];
                    d.RET = (int)jUser["RET"];
                    d.SAL = (int)jUser["SAL"];
                    d.FEE = (int)jUser["FEE"];
                    d.OFF = (int)jUser["OFF"];
                    d.Last_updated = (DateTime)o1["Last updated"];
                    d.Ativo = true;
                    if (add)
                    {
                        db.TD.AddObject(d);
                        add = false;
                    }
                    db.SaveChanges();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile("http://gpro.net/gb/GetMarketFile.asp?market=tds&type=json", "TDMarket.json.gz");

                string path = AppDomain.CurrentDomain.BaseDirectory;
                FileInfo fi = new FileInfo(path + "\\TDMarket.json.gz");
                Decompress(fi);

                LoadJson_TD(path + "\\TDMarket.json");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string LOGIN_URL = "http://gpro.net/gb/gpro.asp";
            string strUserId = "bage";
            string strPassword = "102030";
            string url2 = "http://gpro.net/gb/Qualify.asp";

            Navigate(LOGIN_URL);
            wb.Document.GetElementById("Text1").InnerText = strUserId;
            wb.Document.GetElementById("Password2").InnerText = strPassword;
            wb.Document.GetElementById("Submit2").InvokeMember("click");
            Navigate(url2);

            string conteudo = wb.DocumentText;
            int posicao = conteudo.IndexOf("WeatherQ");
            string cod = conteudo.Substring(posicao + 14).TrimStart();
            int posicaotemp = conteudo.IndexOf("Temp");
            string codtemp = conteudo.Substring(posicaotemp + 5).TrimStart();
            String tempQ1 = codtemp.Split(new string[] { "&deg" }, StringSplitOptions.None)[0];
            int posicaoumid = codtemp.IndexOf("Humidity");
            string codumid = codtemp.Substring(posicaoumid + 9).TrimStart();
            String umidadeQ1 = codumid.Split('%')[0];



            int posicaoR = conteudo.IndexOf("WeatherR");
            string codR = conteudo.Substring(posicaoR + 14).TrimStart();

            String tempQ2 = codtemp.Split('%')[0];

        }


    }


}
