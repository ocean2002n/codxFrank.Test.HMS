using codxFrank.Test.HMS;

namespace codxFrank.Test.HMS
{
    public class HmsDecryptRq : HmsBaseRq
    {
        /// <summary>
        /// ICV(非必填)
        /// </summary>
        public string keyIV { get; set; }
        /// <summary>
        /// 金鑰名稱
        /// </summary>
        public string keyName { get; set; }
        /// <summary>
        /// 解密演算法
        /// </summary>
        public HmsEncryptModeEnum decryptMode { get; set; }
        /// <summary>
        /// 輸入資料格式
        /// </summary>
        public string dataFormat { get; set; }
        /// <summary>
        /// 輸入資料
        /// </summary>
        public string data { get; set; }
        /// <summary>
        /// 輸出資料格式
        /// </summary>
        public string responseFormat { get; set; }
    }
}
