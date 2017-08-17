namespace codxFrank.Test.HMS
{
    internal class HmsDelAllKeyRq : HmsBaseRq
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