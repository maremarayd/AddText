using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace AddText
{
    internal class Addtext
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("実行するには何かキーを押してください。");
            //Console.ReadLine();

            var config = ConfigurationManager.AppSettings;

            string filepath = config.Get("FilePath");

            // 入力されていないなら処理をしない
            if (filepath == null || filepath == "")
            {
                Console.WriteLine("ファイルパスが入力されていません。");
                return;
            }

            // ファイルの存在チェック
            if(!File.Exists(filepath))
            {
                Console.WriteLine("ファイルが存在しません。");
                return;
            }
            try
            {
                // ファイルの読み込み
                List<string> list = new List<string>();
                using (StreamReader sr = new StreamReader(filepath))
                {
                    while (sr.Peek() != -1)
                    {
                        list.Add(sr.ReadLine());
                    }
                }

                // ファイル書き込み
                using (StreamWriter sw = new StreamWriter(filepath))
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        sw.WriteLine(config.Get("AddFoward") + list[i] + config.Get("AddEnd"));
                    }
                }
                Console.WriteLine("正常終了しました。");
                //Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("エラーが出ました。" + ex.Message);
            }
        }
    }
}
