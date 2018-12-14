# PayFlex Vpos C# .Net 

# Kullanım

### Ortak Ödeme Satış İşlemi

Ortak Ödeme Sistemine İşlem Kayıt Etme.Ortak Ödeme sayfasında satış işlemine başlamadan önce işlem kaydedilmelidir. 
İşlemi kaydetmek için Ortak Ödeme API Adresi belirtilen CommonPaymentRequest ile kullanılmaktadır.

#### Request

```C#
string serviceUrl = "https://sanalpos.innova.com.tr/VposClient/CpWeb/api/RegisterTransaction";

 var paymentManager = new PayFlex.Client.PaymentManager();

 var commonPaymentRequest = new PayFlex.Client.CommonPaymentRequest()
 {
     ServiceUrl = serviceUrl,
     TransactionId = Guid.NewGuid().ToString(),
     ClientMerchantCode = "1B18B80EF00A41C2BC4AF2628EA88xxx",
     Password = "xxxx",
     CreditCard = new CreditCard
     {
         CardHolderIp = "127.0.0.1",
         CardHolderEmail = "xx@xx.com",
         CardHolderName = "xxx"
     },
     Apply3DS = true,
     SupportHalfSecure = true,
     ReturnUrl = "https://www.innova.com.tr",
     Amount = (decimal)2.99,
     AmountCode = Currency.TRY,
     PaymentTransactionType = PaymentTransactionType.Sale,
     IsSaveCard = true,
     IsHideSaveCard = false
 };

 var result = paymentManager.PostProcess(commonPaymentRequest);

 var registerTransactionResponse = JsonConvert.DeserializeObject(result.Response, typeof(RegisterTransactionResponse));

```


```
### VPos Peşin Veya Taksitli Satış İşlemi


#### Request

```C#
string serviceUrl = "https://sanalpos.innova.com.tr/VposClient/VposClientWebApi/api/VposClient";

var paymentManager = new PayFlex.Client.PaymentManager();

//Peşin Satış
var vposSaleRequest = new PayFlex.Client.VposRequest()
{
    ServiceUrl = serviceUrl,
    TransactionType = PaymentTransactionType.Sale,
    ClientMerchantCode = "1B18B80EF00A41C2BC4AF2628EA88600",
    Password = "*****",
    TranscationId = Guid.NewGuid().ToString(),
    Bank = Bank.Garanti,
    CreditCard = new CreditCard()
    {
        Pan = "4938410160702981",
        ExpireMonth = "03",
        ExpireYear = "2024",
        CVV = "243",
        CardHolderIp = "127.0.0.1"
    },
    CurrencyAmount = (decimal)4.00,
    CurrencyCode = Currency.TRY,

};

//Taksitli Satış
var vposSaleInstallmentRequest = new PayFlex.Client.VposRequest()
{
    ServiceUrl = serviceUrl,
    ClientMerchantCode = "1B18B80EF00A41C2BC4AF2628EA88600",
    Password = "*****",
    TransactionType = PaymentTransactionType.Sale,
    TranscationId = Guid.NewGuid().ToString(),
    Bank = Bank.IsBank,
                CreditCard = new CreditCard()
    {
        Pan = "4938410160702981",
        ExpireMonth = "03",
        ExpireYear = "2024",
        CVV = "243",
        CardHolderIp = "127.0.0.1",
        InstallmentCount = 2
    },
    CurrencyAmount = (decimal)4.00,
    CurrencyCode = Currency.TRY
};

//Token ile Satış
var vposTokenRequest = new PayFlex.Client.VposRequest()
{
    ServiceUrl = serviceUrl,
    ClientMerchantCode = "1B18B80EF00A41C2BC4AF2628EA88600",
    Password = "*****",
    TransactionType = PaymentTransactionType.Sale,
    TranscationId = Guid.NewGuid().ToString(),
    Bank = Bank.IsBank,
    Token = "0dabdcb7ebf04059979fa89300xxxxxx",
    CurrencyAmount = (decimal)4.00,
    CurrencyCode = Currency.TRY
};

var vposSaleResponse = paymentManager.PostProcess(vposSaleRequest);
var vposSaleInstallmentResponse = paymentManager.PostProcess(vposSaleInstallmentRequest);
var vposTokenResponse = paymentManager.PostProcess(vposTokenRequest);

```

```

### VPos Kart kayıt İşlemi

#### Request

```C#
string serviceUrl = "https://sanalpos.innova.com.tr/VposClient/VposClientWebApi/api/VposClient";

var paymentManager = new PaymentManager();

var vposSaveCardRequest = new PayFlex.Client.VposRequest()
{
    ServiceUrl = serviceUrl,
    ClientMerchantCode = "1B18B80EF00A41C2BC4AF2628EA88600",
    Password = "1q2w3eASD",
    PaymentTransactionType = PaymentTransactionType.SaveCard,                
    TranscationId = Guid.NewGuid().ToString(),
    CreditCard = new CreditCard()
    {
        Pan = "4506347011448053",
        ExpireMonth = "02",
        ExpireYear = "2020",
        CVV = "000",
        CardHolderIp = "127.0.0.1",
        CardHolderEmail = "xxx@xx.com"
    },
    CurrencyAmount = (decimal)0.01,
    CurrencyCode = Currency.TRY,
    CustomerId = "platform11"
};

var vposSaveCardResponse = paymentManager.PostProcess(vposSaveCardRequest);

```


