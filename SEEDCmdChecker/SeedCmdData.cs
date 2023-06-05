using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedCmdChecker
{
    public class SeedCmdData
    {
        #region コンストラクタ
        public SeedCmdData(string name, int cmd, List<int> arg)
        {
            this.Name = name;
            this.Cmd = cmd;
            this.Args = arg;
        }
        #endregion

        #region プロパティ
        /// <summary>
        /// コマンド名称
        /// </summary>
        public string Name
        {
            set;
            get;
        }

        /// <summary>
        /// コマンドID(16進)
        /// </summary>
        public int Cmd
        {
            set;
            get;
        }

        /// <summary>
        /// 引数サイズ
        /// コマンドに付加するデータサイズのリスト
        /// データ１が1byte,データ２が2byteの場合 List[0]=1,List[1]=2と入れる
        /// </summary>
        public List<int> Args
        {
            set;
            get;
        }
        #endregion
    }
}                                               
