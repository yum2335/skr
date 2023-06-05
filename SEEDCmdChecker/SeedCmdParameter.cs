using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedCmdChecker
{
    public class SeedCmdParameter
    {
        public List<SeedCmdData> CmdDataList = new List<SeedCmdData>
        {
            new SeedCmdData( "現在位置取得"        , 0x42 , new List<int>{ { 1 } } ),
            new SeedCmdData( "モータON/OFF"        , 0x50 , new List<int>{ { 1 }, { 1 } } ),
            new SeedCmdData( "モータ停止"          , 0x51 , new List<int>{ { 1 } } ),
            new SeedCmdData( "強制停止"            , 0x53 , new List<int>{ { 1 }, { 1 } } ),
            new SeedCmdData( "エラーリセット"      , 0x54 , new List<int>{ { 1 } } ),
            new SeedCmdData( "ポイントGo"          , 0x5D , new List<int>{ { 1 }, { 1 } , { 3 } } ),
            new SeedCmdData( "スクリプト実行"      , 0x5F , new List<int>{ { 1 }, { 1 } , { 3 } } ), 

            // Motor移動コマンド
            new SeedCmdData( "時間・相対位置移動"  , 0x61 , new List<int>{ { 2 }, { 3 } } ),
            new SeedCmdData( "電流・相対位置移動"  , 0x62 , new List<int>{ { 2 }, { 3 } } ),
            new SeedCmdData( "速度・相対位置移動"  , 0x63 , new List<int>{ { 2 }, { 3 } } ),
            new SeedCmdData( "時間・絶対位置移動" , 0x64 , new List<int>{ { 2 }, { 3 } } ),
            new SeedCmdData( "位置完了待ち" , 0x60 , new List<int>{ { 1 }, { 1 } } ),
        };

        public SeedCmdParameter()
        {
            
        }
    }
}
