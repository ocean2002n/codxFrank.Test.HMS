using codxFrank.Test.HMS;

namespace codxFrank.Test.HMS
{
    public class HmsHashRq : HmsBaseRq
    {
        /// <summary>
        /// 雜湊演算法
        /// </summary>
        public HmsHashTypeEnum hashType { get; set; }
        /// <summary>
        /// 輸入資料格式
        /// </summary>
        public string dataFormat { get; set; }
        /// <summary>
        /// 資料內容
        /// </summary>
        public string data { get; set; }
        /// <summary>
        /// 輸出資料格式
        /// </summary>
        public string responseFormat { get; set; }
        
    }
}
