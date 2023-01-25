using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace SeedCmdChecker
{
    [Serializable]
    public class Settings
    {
        #region フィールド
        private static readonly string fileName = "settings.xml";
        #endregion

        #region コンストラクタ
        public Settings()
        {
            this.SendCmdHistoryList = new List<string>();
        }
        #endregion

        #region プロパティ
        /// <summary>
        /// ポート番号
        /// </summary>
        public string Port
        {
            set;
            get;
        }

        /// <summary>
        ///  コマンドを送信するSEED ID
        /// </summary>
        public string SeedId
        {
            set;
            get;
        }

        /// <summary>
        /// 送信コマンド履歴
        /// </summary>
        public List<string> SendCmdHistoryList
        {
            set;
            get;
        }
        #endregion

        /// <summary>
        /// 設定値をファイルに保存します。
        /// </summary>
        public static void Save(Settings obj)
        {
            var serializer = new XmlSerializer(typeof(Settings));

            //書き込むファイルを開
            using (StreamWriter sw = new StreamWriter(fileName, false, new System.Text.UTF8Encoding(false)))
            {
                //シリアル化し、XMLファイルに保存する
                serializer.Serialize(sw, obj);
            }
        }

        /// <summary>
        /// 設定ファイルを読込ます。
        /// </summary>
        /// <returns></returns>
        public static Settings Load()
        {
            var serializer = new XmlSerializer(typeof(Settings));
            Settings obj = null;

            try
            {
                // ファイルからオブジェクトの読み込み（デシリアライズ）
                using (var fs = new FileStream(fileName, FileMode.Open))
                {
                    obj = serializer.Deserialize(fs) as Settings;
                }
            }
            catch
            {
                obj = new Settings();
            }

            return obj;
        }
    }
}
