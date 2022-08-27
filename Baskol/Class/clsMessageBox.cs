class clsMessageBox
{
    private string save, edit, load;

    /// <summary>
    /// اطلاعات ذخیره شود؟
    /// </summary>
    public static string QustionSave
    {
        get { return "اطلاعات ذخیره شود؟"; }

    }

    /// <summary>
    /// اطلاعات ثبت شود؟
    /// </summary>
    public static string QustionSabt
    {
        get { return "اطلاعات ثبت شود؟"; }

    }

    /// <summary>
    /// در لیست سیاه ذخیره شود؟
    /// </summary>
    public static string QustionBlacList
    {
        get { return "در لیست سیاه ارسال شود؟"; }

    }

    /// <summary>
    /// در لیست سیاه ذخیره شود؟
    /// </summary>
    public static string BlacList
    {
        get { return "در حال ارسال در لیست سیاه می باشد لطفا شکیبا باشید"; }

    }

    /// <summary>
    /// در لیست سیاه ذخیره شود؟
    /// </summary>
    public static string SucssesfullBlacList
    {
        get { return "در لیست سیاه ارسال شد"; }

    }

    /// <summary>
    /// چاپ گرفته شود؟
    /// </summary>
    public static string QustionPrint
    {
        get { return "چاپ گرفته شود؟"; }

    }
    public static string QustionPrintGhabz
    {
        get { return "قبض،چاپ گرقته شود؟ "; }

    }
    /// <summary>
    /// درحال چاپ اطلاعات  می باشد لطفا شکیبا باشید
    /// </summary>
    public static string Print
    {
        get { return "درحال چاپ اطلاعات  می باشد لطفا شکیبا باشید"; }

    }

    /// <summary>
    /// درحال بروزرسانی اطلاعات می باشد لطفا شکیبا باشید
    /// </summary>
    public static string Update
    {
        get { return "درحال بروزرسانی اطلاعات می باشد لطفا شکیبا باشید"; }

    }
    /// <summary>
    /// اطلاعات با موفقیت بروزرسانی شد
    /// </summary>
    public static string SucssesfullUpdate
    {
        get { return "اطلاعات با موفقیت بروزرسانی شد"; }

    }

    /// <summary>
    /// بروزرسانی انجام شود؟
    /// </summary>
    public static string QustionUpdate
    {
        get { return "بروزرسانی انجام شود؟"; }

    }

    /// <summary>
    /// موردی انتخاب نشده است
    /// </summary>
    public static string NotSelected
    {
        get { return "موردی انتخاب نشده است"; }

    }

    /// <summary>
    /// هیچ موردی ثبت نشده است
    /// </summary>
    public static string Nothing
    {
        get { return "هیچ موردی ثبت نشده است"; }

    }

    /// <summary>
    /// اطلاعات ویرایش شود؟
    /// </summary>
    public static string QustionEdit
    {
        get { return "اطلاعات ویرایش شود؟"; }

    }

    /// <summary>
    /// تعطیل شود؟
    /// </summary>
    public static string QustionHolyday
    {
        get { return "تعطیل شود؟"; }

    }

    /// <summary>
    /// تعطیل نشود؟
    /// </summary>
    public static string QustionUnHolyday
    {
        get { return "تعطیل نشود؟"; }
    }

    /// <summary>
    /// تعطیل شد
    /// </summary>
    public static string SucssesfullHolyday
    {
        get { return "تعطیل شد"; }

    }

    /// <summary>
    /// درحال ذخیره اطلاعات می باشد لطفا شکیبا باشید
    /// </summary>
    public static string Save
    {
        get { return "درحال ذخیره اطلاعات می باشد لطفا شکیبا باشید"; }

    }


    /// <summary>
    /// درحال ثبت اطلاعات می باشد لطفا شکیبا باشید
    /// </summary>
    public static string Sabt
    {
        get { return "درحال ثبت اطلاعات می باشد لطفا شکیبا باشید"; }

    }

    /// <summary>
    /// درحال ذخیره اطلاعات می باشد لطفا شکیبا باشید
    /// </summary>
    public static string Edit
    {
        get { return "درحال ذخیره اطلاعات می باشد لطفا شکیبا باشید"; }

    }

    /// <summary>
    /// درحال بارگزاری اطلاعات می باشد لطفا شکیبا باشید
    /// </summary>
    public static string Load
    {
        get { return "درحال بارگزاری اطلاعات می باشد لطفا شکیبا باشید"; }

    }


    /// <summary>
    /// اطلاعات با موفقیت ذخیره شد
    /// </summary>
    public static string SucssesfullSave
    {
        get { return "اطلاعات با موفقیت ذخیره شد"; }

    }

    /// <summary>
    /// اطلاعات با موفقیت ثبت شد
    /// </summary>
    public static string SucssesfullSabt
    {
        get { return "اطلاعات با موفقیت ثبت شد"; }

    }

    /// <summary>
    /// تاریخ وارد نشده است
    /// </summary>
    public static string EmptyDate
    {
        get { return "تاریخ وارد نشده است"; }

    }

    /// <summary>
    /// تاریخ شروع وارد نشده است"
    /// </summary>
    public static string EmptyStartDate
    {
        get { return "از تاریخ وارد نشده است"; }

    }

    /// <summary>
    /// تاریخ پایان وارد نشده است
    /// </summary>
    public static string EmptyEndDate
    {
        get { return "تا تاریخ وارد نشده است"; }

    }

    /// <summary>
    /// تاریخ شروع وارد نشده است"
    /// </summary>
    public static string WarrningStartDate
    {
        get { return "از تاریخ وارد اشتباه وارد شده است"; }

    }

    /// <summary>
    /// تاریخ پایان وارد نشده است
    /// </summary>
    public static string WarrningEndDate
    {
        get { return "تا تاریخ اشتباه وارد شده است"; }

    }

    /// <summary>
    /// اشتباه وارد شده است
    /// </summary>
    public static string WarrningWrite
    {
        get { return "اشتباه وارد شده است"; }

    }

    /// <summary>
    /// اطلاعات با موفقیت ویرایش شد
    /// </summary>
    public static string SucssesfullEdit
    {
        get { return "اطلاعات با موفقیت ویرایش شد"; }

    }

    /// <summary>
    /// اطلاعات با موفقیت حذف شد
    /// </summary>
    public static string SucssesfullDelete
    {
        get { return "اطلاعات با موفقیت حذف شد"; }

    }

    /// <summary>
    /// درحال حذف اطلاعات می باشد لطفا شکیبا باشید
    /// </summary>
    public static string Delete
    {
        get { return "درحال حذف اطلاعات می باشد لطفا شکیبا باشید"; }

    }

    /// <summary>
    /// قادر به حذف نمی باشد
    /// </summary>
    public static string NotDelete
    {
        get { return "قادر به حذف نمی باشد"; }

    }

    /// <summary>
    /// آیا از حذف اطلاعات مطمئنید؟
    /// </summary>
    public static string QustionDelete
    {
        get { return "آیا از حذف اطلاعات مطمئنید؟"; }

    }

    /// <summary>
    /// اطلاعات با موفقیت ابطال شد
    /// </summary>
    public static string SucssesfullEbtal
    {
        get { return "اطلاعات با موفقیت ابطال شد"; }

    }

    /// <summary>
    /// اطلاعات با موفقیت ابطال شد
    /// </summary>
    public static string QustionEbtal
    {
        get { return "آیا از ابطال اطلاعات مطمئنید؟"; }

    }

    /// <summary>
    /// در حال اتصال به سرور
    /// </summary>
    public static string Connection
    {
        get { return "در حال اتصال به سرور"; }

    }

    /// <summary>
    /// اطلاعات با موفقیت حذف شد
    /// </summary>
    public static string Ebtal
    {
        get { return "درحال ابطال اطلاعات می باشد لطفا شکیبا باشید"; }

    }

    /// <summary>
    /// اتصال به سرور شایگان برقرار است
    /// </summary>
    public static string ConnectedToCyber
    {
        get { return "اتصال به سرور شایگان برقرار است"; }
    }


    /// <summary>
    /// خطا در اتصال به سرور شایگان
    /// </summary>
    public static string ErroConnectToCyber
    {
        get { return "خطا در اتصال به سرور شایگان"; }
    }

    /// <summary>
    /// اتصال به سرور باسکول برقرار است
    /// </summary>
    public static string ConnectedToBaskol
    {
        get { return "اتصال به سرور باسکول برقرار است"; }
    }


    /// <summary>
    /// خطا در اتصال به سرور باسکول
    /// </summary>
    public static string ErroConnectToBaskol
    {
        get { return "خطا در اتصال به سرور باسکول"; }
    }

    public static string MessageBoxTitle
    { get; set; }


    public static string MessageBoxSubject
    { get; set; }

    public static bool Ok
    { get; set; }
    public static double Height { get; set; }
}
