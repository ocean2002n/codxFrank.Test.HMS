using codxFrank.Test.HMS;

namespace codxFrank.Test.HMS
{
    public class HmsDelSingleKeyRq : HmsBaseRq
    {
        /// <summary>
        /// 金鑰名稱
        /// </summary>
        public string keyName { get; set; }
        /// <summary>
        /// 金鑰型態
        /// </summary>
        public HmsKeyTypeEnum keyType { get; set; }
    }
}
