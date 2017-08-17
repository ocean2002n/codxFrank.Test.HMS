namespace codxFrank.Test.HMS
{
    public class HmsBaseRq
    {
        /// <summary>
        /// HMS認證Token
        /// </summary>
        public string ssoid { get; set; }
    }

    public enum HmsDataFormateEnum
    {
        utf8, hex, base64
    }

    /// <summary>
    /// 金鑰加密類型列舉
    /// </summary>
    public enum HmsEncryptModeEnum
    {
        DES_ECB = 1,
        DES2_ECB = 2,
        DES3_ECB = 3,
        AES_ECB = 4,

        DES_CBC = 5,
        DES2_CBC = 6,
        DES3_CBC = 7,
        AES_CBC = 8,

        DES_CBC_PAD = 9,
        DES2_CBC_PAD = 10,
        DES3_CBC_PAD = 11,
        AES_CBC_PAD = 12,
        CKM_RSA_PKCS = 13,
        CKM_ECDSA = 14
    }

    /// <summary>
    /// 金鑰類型列舉
    /// </summary>
    public enum HmsKeyTypeEnum
    {
        DES = 1,
        DES2 = 2,
        DES3 = 3,
        AES = 4
    }

    /// <summary>
    /// 金鑰HASH類型列舉
    /// </summary>
    public enum HmsHashTypeEnum
    {
        SHA1 = 1,
        SHA256 = 2,
        SHA384 = 3,
        SHA512 = 4
    }

    /// <summary>
    /// 非對稱式簽章演算法類型列舉
    /// </summary>
    public enum HmsSignTypeEnum
    {
        CKM_RSA_PKCS = 1,
        CKM_ECDSA = 2
    }

}
