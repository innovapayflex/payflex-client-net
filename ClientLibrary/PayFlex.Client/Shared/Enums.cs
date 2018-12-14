using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayFlex.Client
{
    public enum VposPaymentSupplier
    {
        VPos,
        CommonPayment,
    }

    public enum PaymentType
    {
        VPos,       
        CommonPayment,
        VPosQuery,
        SaveToken,
        UpdatePan,
        DeleteToken,
        GetToken
    }

    public enum PaymentStatus
    {   
        Success,
        UnSuccess
    }

    public enum PaymentTransactionType
    {
        Sale,
        SaveCard,
        CardTest,
        Auth,
        AuthCancel,
        Capture,
        SaleCancel,
        SaleRefund,
        LoyaltyQuery,        
        Reversal
    } 

    public enum Currency
    {
        TRY = 949,
        USD = 840,
        EUR = 978,
        JPY = 392,
        GBP = 826,
    } 

    public enum Bank
    {
        Garanti = 1,
        IsBank = 2,
        Akbank = 3,
        Finans = 4,
        Hsbc = 5,
        Vakifbank = 6,
        TEB = 7,
        TurkiyeFinans = 8,
        KuveytTurk = 10,
        YapiKredi = 11,
        IsBank_Innova = 12,
        Ziraat = 20,
        HalkBank = 21
    }
}
