namespace DadePardazi
{
    class TypeOrder
    {
        public enum Order
        {
            تایید_سفارشات, ابطال_سفارشات, کاردکس,
            //کاردکس_باسکول, کاردکس_باسکول_تاریخ, کاردکس_تاریخ, ویرایش_کاردکس
        }
    }
    class TypeControl
    {
        public enum UserControl
        {
            مشتریان, رانندگان,پشتیبان_گیری,نمایش_مشتری,نمایش_راننده
        }
        public static UserControl Type { get; set; }
    }

    class TypeProgram
    {
    }
}
