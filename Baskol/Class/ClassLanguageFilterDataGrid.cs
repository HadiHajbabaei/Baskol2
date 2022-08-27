using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

class ClassLanguageFilterDataGrid : LocalizationManager
{
    public override string GetStringOverride(string key)
    {
        switch (key)
        {
            case "GridViewGroupPanelText":
                return "متن پنل گروه";
            //---------------------- RadGridView Filter Dropdown items texts: 
            case "GridViewClearFilter":
                return "پاک کردن فیلتر";
            case "GridViewFilterShowRowsWithValueThat":
                return "نمایش ردیف با ارزش که:";
            case "GridViewFilterSelectAll":
                return "انتخاب همه";
            case "GridViewFilterContains":
                return "شامل";
            case "GridViewFilterEndsWith":
                return "به پایان می رسد با";
            case "GridViewFilterIsContainedIn":
                return "در آن قرار دارد";
            case "GridViewFilterIsEqualTo":
                return "برابر است با";
            case "GridViewFilterIsGreaterThan":
                return "بزرگتر است از";
            case "GridViewFilterIsGreaterThanOrEqualTo":
                return "بزرگتر از آن است یا برابر است";
            case "GridViewFilterIsLessThan":
                return "کمتر است از";
            case "GridViewFilterIsLessThanOrEqualTo":
                return "کمتر از آن است یا برابر است";
            case "GridViewFilterIsNotEqualTo":
                return "برابر نیست با";
            case "GridViewFilterStartsWith":
                return "شروع می شود با";
            case "GridViewFilterAnd":
                return "و";
            case "GridViewFilter":
                return "فیلتر";
            case "GridViewFilterMatchCase":
                return "مسابقات";
            case "GridViewGroupPanelTopText":
                return "متن بالا گروه پنل";
            case "GridViewGroupPanelTopTextGrouped":
                return "متن پنل بالا گروه بندی شده";
            case "MyGroupByContent":
                return "محتوا گروه من";
            case "GridViewFilterOr":
                return "یا";
            case "GridViewFilterDoesNotContain":
                return "شامل نمی شود";
            case "GridViewFilterIsEmpty":
                return "خالی است";
            case "GridViewFilterIsNotEmpty":
                return "خالی نیست";
            case "GridViewFilterIsNull":
                return "خالی است";
            case "GridViewFilterIsNotNull":
                return "خالی نیست";
            case "GridViewFilterIsNotContainedIn":
                return "درج نشده است";
            case "GridViewAlwaysVisibleNewRow":
                return "اضافه کردن سطر جدید";
            case "Close":
                return "بستن";
            case "Cancel":
                return "لغو";
            case "Maximize":
                return "حداکثر اندازه";
            case "Minimize":
                return "حداقل اندازه";
            case "Yes":
                return "بله";
            case "No":
                return "خیر";
            case "Ok":
                return "تایید";
            case "PinOff":
                return "پین خاموش";
            case "PinOn":
                return "پین روشن";
            case "Reload":
                return "بارگیری مجدد";
            case "Restore":
                return "بازگرداندن";
        }
        return base.GetStringOverride(key);
    }
}
