using codxFrank.Test.HMS;

namespace codxFrank.Test.HMS
{
    public class HmsRandomRq : HmsBaseRq
    {
        /// <summary>
        /// 亂數長度
        /// </summary>
        public int randomValueBytesLength { get; set; }
        /// <summary>
        /// 輸出資料格式
        /// </summary>
        public string responseFormat { get; set; }
    }
}
