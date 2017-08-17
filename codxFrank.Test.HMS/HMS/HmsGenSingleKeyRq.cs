using codxFrank.Test.HMS;

namespace codxFrank.Test.HMS
{
    public class HmsGenSingleKeyRq : HmsBaseRq
    {
        /// <summary>
        /// 金鑰名稱
        /// </summary>
        public string keyName { get; set; }
        /// <summary>
        /// 金鑰型態
        /// </summary>
        public HmsKeyTypeEnum keyType { get; set; }
        /// <summary>
        /// 金鑰內容
        /// </summary>
        public string keyValue { get; set; }
        /// <summary>
        /// 金鑰內容資料格式
        /// </summary>
        public string keyValueFormat { get; set; }
    }
}
