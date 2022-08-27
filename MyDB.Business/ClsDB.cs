using MyDB.BusinessLayer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MyDB.BusinessLayer.Models;

namespace MyDB.BusinessLayer
{
    public static class ClsDB<T> where T : class
    {
        public static readonly RepositoryBase<T> repository = new RepositoryBase<T>();
        #region Public Methods

        /// <summary>
        /// Insert new ClsChangeShift2
        /// </summary>
        /// <param name="businessObject">ClsChangeShift2 object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Insert(T businessObject)
        {

            repository.Add(businessObject);

            return repository.SaveChanges() != 0;

        }
        /// <summary>
        /// Update existing ClsChangeShift2
        /// </summary>
        /// <param name="businessObject">ClsChangeShift2 object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(T businessObject)
        {
            repository.Update(businessObject);

            return repository.SaveChanges() != 0;

        }

        public static bool BulkInsert(List<T> businessObject)
        {

            repository.AddBulk(businessObject);

            return repository.SaveChanges() != 0;

        }

        public static bool BulkUpdate(List<T> businessObject)
        {

            repository.UpdateBulk(businessObject);

            return repository.SaveChanges() != 0;

        }
        public static bool Delete(T ch)
        {
            repository.Delete(ch);
            repository.SaveChanges();
            return true;
        }
        public static string Delete(string FiledName, object Value)
        {
            try
            {
                repository.ExecuteSqlString("delete from " + repository.RetTableName() + " where " + FiledName + " = '" + Value + "'");
                return "با موفقیت حذف شد";
            }
            catch (Exception ex)
            { return ex.Message; }
        }

        public static string Delete(string FiledName, object Value, string FiledName1, object Value1)
        {
            try
            {
                repository.ExecuteSqlString("delete from " + repository.RetTableName() + " where " + FiledName + " = '" + Value + "' and " + FiledName1 + " = '" + Value1 + "'");
                return "با موفقیت حذف شد";
            }
            catch (Exception ex)
            { return ex.Message; }
        }
        public static bool Delete(List<T> ch)
        {
            repository.Delete(ch);
            //repository.SaveChanges();
            return true;
        } 

        public static DateTime ServerDate()
        {
            return repository.ServerDate("select GetDate()");
        }

        public static List<T> GetAll()
        {
            return repository.GetAll().ToList();
        }
        public static List<T> GetAllMenual()
        {
            return repository.GetAllQuery("select * from [" + repository.RetTableName() + "]").ToList();
        }

        public static List<T> GetAllBy(object fieldName, object value)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + fieldName + "='" + value + "'").ToList();
        }

        public static List<T> GetAllBy(string table, string fieldName, object value)
        {
            return repository.GetAllQuery("select * from [" + table + "] where " + fieldName + "='" + value + "'").ToList();
        }
        public static List<T> GetAllBy(object fieldName, object value, object fieldName2, object value2, object OP)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + fieldName + "='" + value + "' " +
                "" + OP + " " + fieldName2 + " ='" + value2 + "'").ToList();
        }
        public static List<T> GetAllBy(object fieldName, object value, object fieldName2, object value2)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + fieldName + "='" + value + "' " +
                "and " + fieldName2 + " ='" + value2 + "'").ToList();
        }
        public static List<T> GetAllBy(object fieldName, object value, object fieldName2, object value2, object fieldName3, object value3)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + fieldName + "='" + value + "' " +
                "and " + fieldName2 + " ='" + value2 + "' and " + fieldName3 + " ='" + value3 + "'").ToList();
        }

        public static List<T> GetAllByNotIn(object Where, object Wherevalue, object table)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + Where + " not in (select " + Wherevalue + " from " + table + ")").ToList();
        }

        public static List<T> GetAllByNotInValue(object Where, object Wherevalue, object table, object fieldName, object value)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + Where + " not in (select " + Wherevalue + " from " + table + ") ' and " + fieldName + " ='" + value + "'").ToList();
        }
        public static List<T> GetAllByNotIn(object Where, object Wherevalue, object fieldName, object value, object table)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + Where + " not in (select " + Wherevalue + " from " + table + ") and " + fieldName + "='" + value + "'").ToList();
        }
        public static List<T> GetAllByNotInDate(object Where, object Wherevalue, object fieldDate, object valueDate, object table)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + Where + " not in (select " + Wherevalue + " from " + table + ") and CAST(" + fieldDate + " as date)='" + valueDate + "'").ToList();
        }
        public static List<T> GetAllByNotInDate(object Where, object Wherevalue, object fieldDate, object valueStartDate, object valueEndDate, object table)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + Where + " not in (select " + Wherevalue + " from " + table + ") and CAST(" + fieldDate + " as date)>='" + valueStartDate + "' and " +
                "CAST(" + fieldDate + " as date)<='" + valueEndDate + "'").ToList();
        }
        public static List<T> GetAllByInDate(object fielName, object value, object Where, object Wherevalue, object table, object fieldTableDate, object valueTableDate)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + fielName + " = '" + value + "' and " + Where + " in (select " + Wherevalue + " from " + table + " where CAST(" + fieldTableDate + " as date)='" + valueTableDate + "')").ToList();
        }

        public static List<T> GetAllByInDate(object fielName, object value, object Where, object Wherevalue, object table, object fieldTableDate, object valueTableStartDate, object valueTableEndDate)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + fielName + " = '" + value + "' and " + Where + " in (select " + Wherevalue + " from " + table + " where CAST(" + fieldTableDate + " as date)>='" + valueTableEndDate + "' and CAST(" + fieldTableDate + " as date)<='" + valueTableEndDate + "')").ToList();
        }

        public static List<T> GetAllByIn(object Where, object Wherevalue, object table)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + Where + " in (select " + Wherevalue + " from " + table + ")").ToList();
        }

        public static List<T> GetAllByIn(object Where, object Wherevalue, object fieldName, object value, object fieldName2, object value2, object table)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + Where + " in (select " + Wherevalue + " from " + table + " where " + fieldName2 + "='" + value2 + "') and " + fieldName + "='" + value + "'").ToList();
        }
        public static long GetAllByMax(object fieldMax, object fieldName, object value)
        {
            return long.Parse(repository.ExecuteSqlString("select ISNULL(MAX(" + fieldMax + "),0) from " + repository.RetTableName() + " where " + fieldName + "='" + value + "'"));
        }
        public static long GetAllByOp(object OP, object fieldOp)
        {
            return long.Parse(repository.ExecuteSqlString("select ISNULL(" + OP + "(" + fieldOp + "),0) from " + repository.RetTableName() + "'"));
        }
        public static long GetAllByOp(object fieldOp, object fieldName, object value, object OP)
        {
            return long.Parse(repository.ExecuteSqlString("select ISNULL(" + OP + "(" + fieldOp + "),0) from " + repository.RetTableName() + " where " + fieldName + "='" + value + "'"));
        }
        public static long GetAllByOp(object fieldMax, object fieldName, object value, object fieldName2, object value2, object OP)
        {
            return long.Parse(repository.ExecuteSqlString("select ISNULL(" + OP + "(" + fieldMax + "),0) from " + repository.RetTableName() + " where " + fieldName + "='" + value + "' and " + fieldName2 + "='" + value2 + "'"));
        }
        public static int GetAllByMax(object fieldMax)
        {
            return int.Parse(repository.ExecuteSqlString("select ISNULL(MAX(" + fieldMax + "),0) from " + repository.RetTableName() + ""));
        }
        public static List<T> GetAllBy(object fieldName, object value, object fieldName2, object value2, object fieldName3, object value3,
            object fieldName4, object value4)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + fieldName + "='" + value + "' " +
                "and " + fieldName2 + " ='" + value2 + "' and " + fieldName3 + " ='" + value3 + "' and " + fieldName4 + " ='" + value4 + "'").ToList();
        }

        //public static DataTable GetAllByDate(string fieldName)
        //{
        //    return repository.GetAllQuery("select" +fieldName+ "from" +repository.RetTableName());
        //}
        public static List<T> GetAllByDate(string fieldNameDate, object valueDate)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where CAST(" + fieldNameDate + " as date)='" + valueDate + "'").ToList();
        } 

        public static List<T> GetAllByDate(string fieldName, object value, string fieldStartDate, object valueStartDate, string fieldEndDate, object valueEndDate)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + fieldName + " = '" + value + "' and CAST(" + fieldStartDate + " as date)>='" + valueStartDate + "' and CAST(" + fieldEndDate + " as date)<='" + valueEndDate + "'").ToList();
        }
        public static List<T> GetAllByDateValue(string fieldName, object value, string fieldNameDate, object valuetDate, object Where, object Wherevalue, object table)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + fieldName + " = '" + value + "' and CAST(" + fieldNameDate + " as date)>='" + valuetDate + "' and  " + Where + " not in (select " + Wherevalue + " from " + table + ")").ToList();
        }
        public static List<T> GetAllByDateValue(string fieldName, object value, string fieldNameDate, object valuetDate)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + fieldName + " = '" + value + "' and CAST(" + fieldNameDate + " as date)>='" + valuetDate + "'" ).ToList();
        }
        //public static List<T> GetAllByDate(string fieldName, object value, string fieldNameDate, object valueDate, string fieldNameDate2, object valueDate2)
        //{
        //    return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + fieldName + "='" + value + "' and CAST(" + fieldNameDate + " as date)>='" + valueDate + "' and " +
        //        "CAST(" + fieldNameDate2 + " as date)<='" + valueDate2 + "'").ToList();
        //}

        public static List<T> GetAllByDate(string fieldNameDate, object valueDate, object valueDate2)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where CAST(" + fieldNameDate + " as date)>='" + valueDate + "' and CAST(" + fieldNameDate + " as date)<='" + valueDate2 + "'").ToList();
        }


        public static List<T> GetAllByDate(object fieldStartDate, object valueStartDate, object fieldEndDate, object valueEndDate)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where CAST(" + fieldStartDate + " as date)>='" + valueStartDate + "' and CAST(" + fieldEndDate + " as date)<='" + valueEndDate + "'").ToList();
        }
        public static List<T> GetAllByDateValue(object fieldStartDate, object valueStartDate, object fieldEndDate, object valueEndDate, string fieldName, object value)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where CAST(" + fieldStartDate + " as date)>='" + valueStartDate + "' and CAST(" + fieldEndDate + " as date)<='" + valueEndDate + "" + fieldName + " = '" + value + "'").ToList();
        }
        public static long GetEvent(string fieldNameEvent, string ValueEvent, string fieldName, object Value)
        {
            return long.Parse(repository.ExecuteSqlString("select IsNULL(" + fieldNameEvent + "(cast(REPLACE(" + ValueEvent + ", '/','') as bigint)),0) from " + repository.RetTableName() + " " +
                "where " + fieldName + " like '" + Value + "%'"));
        }
        //public static List<T> GetAllByUser(string fieldName, object value)
        //{
        //    return repository.GetAllQuery("select * from [" + repository.RetTableName() + "] where " + fieldName + "='" + value.ToString() + "'").ToList();
        //}
        //public static List<T> GetAllByOR(string fieldName, object value, object value1)
        //{
        //    return repository.GetAllQuery("select * from [" + repository.RetTableName() + "] where " + fieldName + "='" + value.ToString() + "' OR " + fieldName + "='" + value1.ToString() + "'").ToList();
        //}
        //public static List<T> GetAllByShow(string fieldName)
        //{
        //    return repository.GetAllQuery(@"select * from " + repository.RetTableName() + " where  " + fieldName + " = (select max(cast(" + fieldName + " as int))from ListControlQuestion )").ToList();

        //}
        //public static List<T> GetAllByYear(string fieldName, string fieldName1)
        //{
        //    return repository.GetAllQuery("select top 1 * from " + repository.RetTableName() + " order by " + fieldName + " " + fieldName1).ToList();
        //}
        //public static List<T> GetAllByYear(string fieldName, string value, string fieldName1, string value1)
        //{
        //    return repository.GetAllQuery("select top 1 * from " + repository.RetTableName() + "  where " + fieldName + " = '" + value + "' order by " + fieldName1 + " " + value1).ToList();
        //}

        //public static List<T> GetAllByLike(string fieldName, object value, string fieldName1, object value1, string fieldName2, object value2)
        //{
        //    return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + fieldName + "='" + value.ToString() + "' and " + fieldName1 + "='" + value1.ToString() + "' and " + fieldName2 + "='" + value2.ToString() + "'").ToList();
        //}
        //public static List<T> GetAllByLike(string fieldName, object value, string fieldName1, object value1, string fieldName2, object value2, string fieldName3, object value3)
        //{
        //    return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + fieldName + "='" + value.ToString() + "' and " + fieldName1 + "='" + value1.ToString() + "' and " + fieldName2 + "='" + value2.ToString() + "'and " + fieldName3 + "='" + value3 + "'").ToList();
        //}
        //public static List<T> GetAllByLikeDateCheck(string fieldName, object value, string fieldName1, object value1, string fieldName2, object value2, string fieldNameDate, string DateCheck)
        //{
        //    return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + fieldName + "='" + value.ToString() + "' and " + fieldName1 + "='" + value1.ToString() + "' and " + fieldName2 + "='" + value2.ToString() + "'and cast(" + fieldNameDate + " as date) <= '" + DateCheck + "'").ToList();
        //}
        //public static List<T> GetAllByLikeDateCheck(string fieldName, object value, string fieldName1, object value1, string fieldNameDate, string DateCheck)
        //{
        //    return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + fieldName + "='" + value.ToString() + "' and " + fieldName1 + "='" + value1.ToString() + "' and cast(" + fieldNameDate + " as date) <= '" + DateCheck + "'").ToList();
        //}
        //public static List<T> GetAllByLike(string fieldName, object value, string fieldName1, object value1)
        //{
        //    return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + fieldName + "='" + value.ToString() + "' and " + fieldName1 + "='" + value1.ToString() + "'").ToList();
        //}
        //public static List<T> GetAllByLikeUser(string fieldName, object value, string fieldName1, object value1)
        //{
        //    return repository.GetAllQuery("select * from [" + repository.RetTableName() + "] where " + fieldName + "='" + value.ToString() + "' and " + fieldName1 + "='" + value1.ToString() + "'").ToList();
        //}
        //public static List<T> GetAllByLikeDate(string fieldNameDate, string StartDate, string EndDate, string fieldName, object value, string fieldName1, object value1, string fieldName2, object value2)
        //{
        //    return repository.GetAllQuery("select * from " + repository.RetTableName() + " where cast( " + fieldNameDate + " as date) >= '" + StartDate + "' and cast(" + fieldNameDate + " as date) <= '" + EndDate + "' and " + fieldName + " = '" + value + "' and " + fieldName1 + "  = '" + value1 + "' and " + fieldName2 + " = '" + value2 + "'").ToList();
        //}
        //public static List<T> GetAllByLikeDate(string fieldNameDate, string StartDate, string EndDate)
        //{
        //    return repository.GetAllQuery("select * from " + repository.RetTableName() + " where cast( " + fieldNameDate + " as date) >= '" + StartDate + "' and cast(" + fieldNameDate + " as date) <= '" + EndDate + "'").ToList();
        //}
        //public static List<T> GetAllByLikeDate(string fieldNameDate, string StartDate, string EndDate, string fieldName, object value, string fieldName1, object value1)
        //{
        //    return repository.GetAllQuery("select * from " + repository.RetTableName() + " where cast( " + fieldNameDate + " as date) >= '" + StartDate + "' and cast(" + fieldNameDate + " as date) <= '" + EndDate + "' and " + fieldName + " = '" + value + "' and " + fieldName1 + "  = '" + value1 + "'").ToList();
        //}
        //public static List<T> GetAllByLikeDate(string fieldNameDate, string StartDate, string EndDate, string fieldName, object value)
        //{
        //    return repository.GetAllQuery("select * from " + repository.RetTableName() + " where cast( " + fieldNameDate + " as date) >= '" + StartDate + "' and cast(" + fieldNameDate + " as date) <= '" + EndDate + "' and " + fieldName + " = '" + value + "'").ToList();
        //}
        //public static List<T> GetAllByLikeDate(string fieldNameDate, string StartDate, string EndDate, string fieldName, string fieldName1, string fieldName2, object value)
        //{
        //    return repository.GetAllQuery("select * from " + repository.RetTableName() + " where cast( " + fieldNameDate + " as date) >= '" + StartDate + "' and cast(" + fieldNameDate + " as date) <= '" + EndDate + "' and (" + fieldName + " = '" + value + "' or " + fieldName + " = '" + value + "' or " + fieldName + " = '" + value + "') ").ToList();
        //}
        //public static List<T> GetAllByLikeDate(string fieldNameDate, string StartDate, string EndDate, string fieldName, string fieldName1, string fieldName2, object value, string fieldName3, object value1)
        //{
        //    return repository.GetAllQuery("select * from " + repository.RetTableName() + " where cast( " + fieldNameDate + " as date) >= '" + StartDate + "' and cast(" + fieldNameDate + " as date) <= '" + EndDate + "' and (" + fieldName + " = '" + value + "' or " + fieldName + " = '" + value + "' or " + fieldName + " = '" + value + "') and " + fieldName3 + "='" + value1 + "' ").ToList();
        //}
        //public static List<T> GetAllByLikeDateSMS(string fieldNameDate, string StartDate, string EndDate, string fieldName, object value, string fieldName1, object value1)
        //{
        //    return repository.GetAllQuery("select * from " + repository.RetTableName() + " where cast( " + fieldNameDate + " as date) >= '" + StartDate + "' and cast(" + fieldNameDate + " as date) <= '" + EndDate + "' and " + fieldName + " = '" + value + "' and " + fieldName1 + "  = '" + value1 + "' and  ScoreFinal is not null and Darsad>=0 ").ToList();
        //}
        //public static long GetNumber(string Max, object Operations_Type, object PuID_Company, object year)
        //{
        //    return long.Parse(repository.ExecuteSqlString("select IsNULL(MAX(cast(REPLACE(" + Max + ", '/','') as bigint)),0) from " + repository.RetTableName() + " where Operations_Type='" + Operations_Type + "' and PuID_Company='" + PuID_Company + "' and " +
        //        " Number like '" + year + "%'"));
        //}
        //public static long GetNumberK(string Max, object Operations_Type, object PuID_Company, string CodeList, object year)
        //{
        //    return long.Parse(repository.ExecuteSqlString("select IsNULL(MAX(cast(REPLACE(" + Max + ", '/','') as bigint)),0) from " + repository.RetTableName() + " where Operations_Type='" + Operations_Type + "' and PuID_Company='" + PuID_Company + "' and CodeList = '" + CodeList + "' and " +
        //       " NumberK like '" + year + "%'"));
        //}
        //public static long GetNumberEblaghye(string Max, object Operations_Type, object year)
        //{
        //    return long.Parse(repository.ExecuteSqlString("select IsNULL(MAX(cast(REPLACE(" + Max + ", '/','') as bigint)),0) from " + repository.RetTableName() + " where Operations_Type='" + Operations_Type + "' and " +
        //        " Number like '" + year + "%'"));
        //}

        //public static long GetNumberFirstError(string Max, object Operations_Type, object PuID_Company, object year, string CodeList)
        //{
        //    return long.Parse(repository.ExecuteSqlString("select IsNULL(MAX(cast(REPLACE(" + Max + ", '/','') as bigint)),0) from " + repository.RetTableName() + " where Operations_Type='" + Operations_Type + "' and PuID_Company='" + PuID_Company + "' and " +
        //         " NumberATF like '" + year + "%' and CodeList= '" + CodeList + "'"));
        //}
        //public static long GetNumber(string Max, string fieldName, object value)
        //{
        //    return long.Parse(repository.ExecuteSqlString("select IsNULL(MAX(cast(" + Max + " as bigint)),0) from " + repository.RetTableName() + " where " + fieldName + "='" + value + "'"));
        //}
        //public static List<T> GetAllByQuery(string Query)
        //{
        //    return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + Query).ToList();
        //}
        public static DataTable GetByDataTable(string Query)
        {
            return repository.GetAllDataTable(Query);
        }
        public static void ExecuteQuery(string Query)
        {
            repository.ExecuteQuery(Query);
        }
        #endregion

        //        #region

        //        public static List<T> GetAllByRetWorkedMonth(int Year, int Month, int Pid)
        //        {
        //            return repository.GetAllQuery("select * from RetWorkedMonth(" + Pid + "," + Year + "," + Month + " )").ToList();
        //        }
        //        //public static PersianDateTime ReturnEndDateMounth(PersianDateTime StartDate)
        //        //{
        //        //    PersianDateTime st = PersianDateTime.ParsePersian(StartDate.ToDateString());
        //        //    while (st.Month <= StartDate.Month && st.Year <= StartDate.Year)
        //        //        st = PersianDateTime.ParseEnglish(st.ToDateTime().AddDays(1).ToString());
        //        //    return PersianDateTime.ParseEnglish(st.ToDateTime().Subtract(new TimeSpan(1, 0, 0, 0, 0)).ToString());
        //        //}


        //        //       public static List<T> GetActiveHkm(int Pid, DateTime Date)
        //        //       {
        //        //           DateTime EndDate = ReturnEndDateMounth(Date);
        //        //           return repository.GetAllQuery(@"select StatementPersonal.* from dbo.RetActivePersonalDateToDate('" + Date.ToString("yyyy-MM-dd") + "','" + EndDate.ToString("yyyy-MM-dd") + @"') as t,StatementPersonal where t.hkmcode=StatementPersonal.HkmCode
        //        //AND t.pid=" + Pid.ToString()).ToList();

        //        //       }
        //        public static string ExecuteSqlString(string Query)
        //        {
        //            return repository.ExecuteSqlString(Query);
        //        }
        //        public static DataTable RetTitleView(string Query)
        //        {
        //            return repository.GetAllDataTable(@"select distinct FormulType, MonthValueType,ID,EnName,FaName,ValueType  from viewMonthValue where " + Query);
        //        }
        //        public static T GetActive(string pid, DateTime date)
        //        {
        //            string id = repository.ExecuteSqlString("select dbo.RetActiveBimeh('" + date.ToString("yyyy-MM-dd") + "'," + pid + ", 1)");
        //            var q = repository.GetAllQuery("select * from SalBimehKargar where SalBimehKargarID='" + id.ToString() + "'");

        //            if (q.Count() != 0)
        //                return q.First();
        //            else
        //                return null;
        //        }
        //        public static List<T> GetAllSalTakhfifMaliat(int SaMade131ParentID)
        //        {
        //            return repository.GetAllQuery(@"SELECT SalTakhfifMaliat.*
        //  FROM  [SalTakhfifMaliatMade131],SalTakhfifMaliat
        //  where SalTakhfifMaliat.SalTakhfifMaliatID=SalTakhfifMaliatMade131.SalTakhfifMaliatID
        //  and SalTakhfifMaliatMade131.SaMade131ParentID=" + SaMade131ParentID.ToString()).ToList();

        //        }
        //        public static List<T> GetAllBySelect(string Query)
        //        {
        //            return repository.GetAllQuery(Query).ToList();

        //        }
        //        public static void UpdateGhestStatus(int pid, DateTime StartDate, DateTime EndDate)
        //        {
        //            repository.ExecuteQuery(string.Format(@"update SalVamGhest set SalVamGhestStatus=1 where SalVamGhestDate>='{0}'
        //and SalVamGhestDate<='{1}' and SalVamGirandeID in (select SalVamGirande.SalVamGirandeID from SalVamGirande where SalVamGirande.SalPerson_ID={2})
        //go
        //update SalMosaedeGhest set SalMosaedeGhestStatus=1 where SalMosaedeGhest.SalMosaedeGhestDate>='{0}'
        //and SalMosaedeGhest.SalMosaedeGhestDate<='{1}' and SalMosaedeGhest.SalMosaedeID in (select SalMosaede.SalMosaedeID from SalMosaede where SalPersonID={2})
        //go
        //update SalKasrKarfarmaGhest set SalKasrKarfarmaGhestStatus=1 where SalKasrKarfarmaGhest.SalKasrKarfarmaGhestDate>='{0}'
        //and SalKasrKarfarmaGhest.SalKasrKarfarmaGhestDate<='{1}' and SalKasrKarfarmaGhest.SalKasrKarfarmaID in (select SalKasrKarfarma.SalKasrKarfarmaID from SalKasrKarfarma where SalPersonID={2})
        //go
        //update SalKasrGhest set SalKasrGhestStatus=1 where SalKasrGhest.SalKasrGhestGhestDate>='{0}'
        //and SalKasrGhest.SalKasrGhestGhestDate<='{1}' and SalKasrGhest.SalKasrDastorID in (select SalKasrDastor.SalKasrDastorrID from SalKasrDastor where SalPersonID={2})", StartDate, EndDate, pid));
        //        }
        //        //public static float Get131Eydi(long Value, int pid, DateTime Date)
        //        //{
        //        //    SqlCommand sqlCommand = new SqlCommand();
        //        //    SqlCommand sqlCommand1 = new SqlCommand();
        //        //    SqlConnection con = new SqlConnection(ConnectionString.myConnection);
        //        //    sqlCommand.Connection = con;
        //        //    sqlCommand1.CommandText = "select PuBaseInfoValueInt from SalBaseInfo where PuBaseInfoTypeCode=7 and PuBaseInfoTypeValue=1 ";
        //        //    sqlCommand1.Connection = con;
        //        //    List<SalBimehKargar> ListBim = ClsDB<SalBimehKargar>.GetAllBy("SalPersonID", pid);

        //        //    try
        //        //    {



        //        //        con.Open();
        //        //        float ret1 = ListBim.Count(c => c.SalBimehKargarMoafiat82.HasValue) == 0 ?
        //        //             float.Parse(sqlCommand1.ExecuteScalar().ToString())
        //        //             : (float)ListBim.First(c => c.SalBimehKargarMoafiat82.HasValue).SalBimehKargarMoafiat82.Value;

        //        //        float ret;
        //        //        if (Value - (ret1 / 12) > 0)
        //        //        {
        //        //            sqlCommand.CommandText = "exec [dbo].[Made131] " + (Value - (ret1 / 12)).ToString() + "," + pid + ",'" + Date.ToString("yyyy-MM-dd") + "'";
        //        //            ret = float.Parse(sqlCommand.ExecuteScalar().ToString());
        //        //        }
        //        //        else
        //        //            ret = 0;

        //        //        return ret;

        //        //    }
        //        //    catch (Exception ex)
        //        //    {
        //        //        throw new Exception("ClsViewTadilMaliatSal::SelectByPrimaryKey::Error occured.", ex);
        //        //    }
        //        //    finally
        //        //    {
        //        //        con.Close();
        //        //        sqlCommand.Dispose();
        //        //    }
        //        //}
        //        public static T GetByPid(int Pid)
        //        {
        //            var q = repository.GetAllQuery("select * from GetBaseInfoSoft(" + Pid.ToString() + ")").ToList();
        //            if (q.Count() != 0)
        //                return q.First();
        //            return null;
        //        }
        //        public static DataTable GetVacUse(DateTime Date, int Year, string Query)
        //        {
        //            return repository.GetAllDataTable("exec dbo.procRetVacUse '" + Date.ToString("yyyy-MM-dd") + "'  ,'" + Year.ToString() + "','" + Query + "'");
        //        }
        //        public static List<T> GetAllValisdPersonal(DateTime StartDate)
        //        {


        //            return repository.GetAllQuery($"exec dbo.[RetValidPersonal] '{StartDate.ToString("yyyy-MM-dd")}'").ToList();
        //        }
        //        public static List<T> GetAllActivePersonal(DateTime Date, bool retall)
        //        {
        //            if (retall)
        //                return repository.GetAllQuery("select infopersonal.* from RetActivePersonal('" + Date.ToString("yyyy-MM-dd")
        //                 + "') as t1,infopersonal where t1.pid=infopersonal.pid order by t1.hkmcode desc,CAST(t1.id_personal as int) asc").ToList();
        //            else
        //            {
        //                string s = "select infopersonal.* from RetActivePersonal('" + Date.ToString("yyyy-MM-dd")
        //             + "') as t1,infopersonal where t1.hkmcode!=-1 and t1.pid=infopersonal.pid order by  t1.hkmcode desc,CAST(t1.id_personal as int) asc";
        //                return repository.GetAllQuery(s).ToList();
        //            }
        //        }
        //        public static List<T> GetAllActivePersonal(DateTime StartDate, DateTime EndDate)
        //        {
        //            string s = "select infopersonal.* from RetActivePersonalDateToDate('" + StartDate.ToString("yyyy-MM-dd")
        //                  + "','" + EndDate.ToString("yyyy-MM-dd") + "') as t1,infopersonal where t1.pid=infopersonal.pid order by t1.hkmcode desc,CAST(t1.id_personal as int) asc";
        //            return repository.GetAllQuery(s).ToList();

        //        }
        //        public static DataTable RetuenShiftDay(int PuIDShift, DateTime StartDate, DateTime EndDate)
        //        {
        //            return repository.GetAllDataTable("exec dbo.[ReturnShiftDay] " + PuIDShift.ToString()
        //                + ",'" + StartDate.ToString("yyyy-MM-dd") + "','" + EndDate.ToString("yyyy-MM-dd") + "'");
        //        }

        //        public static DataTable RetChangeDataTable(string filter)
        //        {
        //            return repository.GetAllDataTable(@"select ChangeValueDayDateStart=dbo.getShamsiDate(ChangeValueDayDateStart),ChangeValueDayDesc,
        //ChangeValueDayDateEnd=dbo.getShamsiDate(ChangeValueDayDateEnd) ,
        //ChangeValueDayTypeStr=(case ChangeValueDayType
        // when 0 then N'شیفت'
        // else N'مرکز هزینه'
        // end),
        // ChangeValueDayType ,
        // ChangeValueDayValueStr=(case ChangeValueDayType
        // when 0 then (select top 1 cast(TimeShift.TimeName as nvarchar(50)) COLLATE Latin1_General_CI_AI from TimeShift where puid=ChangeValueDay.ChangeValueDayValue)
        // else (select top 1  cast(ActivityCenter.ActivityCenterTitel  as nvarchar(50)) COLLATE Latin1_General_CI_AI from ActivityCenter where ActivityCenter.ActivityCenterCode=ChangeValueDay.ChangeValueDayValue)
        // end),NameFamily=Name+' '+family,Id_Personal,puid,InfoPersonal.Pid
        // from ChangeValueDay,InfoPersonal
        // where ChangeValueDay.Pid=InfoPersonal.Pid " + filter);
        //        }

        //        public static DataTable GetAllValisdPersonalStatementDetail(DateTime StartDate)
        //        {
        //            return repository.GetAllDataTable("select * from RetActivePersonalDetailStateMent('" + StartDate.ToString("yyyy-MM-dd") + "')");
        //            // return DB.Database.ex;
        //        }
        //        public static List<string> ListPeriodMali()
        //        {
        //            DataTable dt = repository.GetAllDataTable(@"SELECT name, database_id, create_date
        //FROM sys.databases ");
        //            DataSet ds = new DataSet();
        //            List<string> ret = new List<string>();
        //            try
        //            {


        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    if (dr["name"].ToString().IndexOf("DADGAR") >= 0)
        //                    {
        //                        string r = dr["name"].ToString();
        //                        ret.Add(r.Substring(r.Length - 2, 2));
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                throw new Exception("ClsUsers::SelectAll::Error occured.", ex);
        //            }

        //            return ret;
        //        }
        //        public static DataTable ReturnMountCalc()
        //        {
        //            return repository.GetAllDataTable("select distinct SalHoghoghStartDate,SalHoghoghEndDate from salhoghogh order by SalHoghoghStartDate");
        //        }
        //        public static T RetMinMount(string Query)
        //        {
        //            var q = repository.GetAllQuery(Query).ToList();
        //            if (q.Count() == 0)
        //                return null;
        //            return q.First();

        //        }
        //        public static DataTable GetAllRetActivePersonalDateToDateStatement(DateTime StartDate, DateTime EndDate)
        //        {
        //            return repository.GetAllDataTable("select distinct * from RetActivePersonalDateToDateStatement('"
        //                + StartDate.ToString("yyyy-MM-dd") + "','" + EndDate.ToString("yyyy-MM-dd") + "')");
        //            // return DB.Database.ex;
        //        }
        //        public static DataTable RetActiveBimehPersonalWithBimeh(DateTime StartDate)
        //        {
        //            return repository.GetAllDataTable("select * from RetActiveBimehPersonalWithBimeh('"
        //                + StartDate.ToString("yyyy-MM-dd") + "')");
        //            // return DB.Database.ex;
        //        }
        //        public static DataTable retCountM(string Query)
        //        {
        //            return repository.GetAllDataTable(Query);
        //        }
        //        public static DataTable RetTitleView()
        //        {
        //            return repository.GetAllDataTable
        //                (@"select FormulEnName as 'EnName',FormulFaName as 'FaName'  from formul
        //                   union 
        //                   select ParameterEnName,ParameterFaName  from Parameter");
        //        }
        //        public static DataTable GetAllByDatePid(DateTime startDate, DateTime endDate, int Pid)
        //        {
        //            return repository.GetAllDataTable(string.Format(@"select SalHoghoghBasiInfoKind,SalHoghoghBaseInfoID, SalHoghoghBaseInfoKind.Title as SalHoghoghBaseInfoKindTitle,SalHoghoghBaseInfo.SalHoghoghBaseInfoTitle,SalHoghogh.SalHoghoghPrice
        //,SalHoghogh.Person_ID, SalHoghoghStartDate, SalHoghoghEndDate,SalHoghogh.ActivityCenterCode,WorkLoaction.WorkLoactionCode  from SalHoghogh,SalHoghoghBaseInfo,SalHoghoghBaseInfoKind,ActivityCenter,WorkLoaction
        // where SalHoghogh.SalHoghoghBasiInfoID=SalHoghoghBaseInfo.SalHoghoghBaseInfoID
        // and SalHoghoghBaseInfoKind.ID=SalHoghogh.SalHoghoghBasiInfoKind
        // and SalHoghoghBasiInfoKind=2  and SalHoghogh.SalHoghoghStartDate>='{0}' and SalHoghogh.SalHoghoghEndDate<='{1}'  and SalHoghogh.ActivityCenterCode=ActivityCenter.ActivityCenterCode and WorkLoaction.WorkLoactionCode=ActivityCenter.WorkLoactionCode and SalHoghogh.Person_ID={2}
        // union ALL
        // select SalHoghoghBasiInfoKind,SalMazayaMovaghatTitle.SalMazayaMovaghatTitleID, SalHoghoghBaseInfoKind.Title as SalHoghoghBaseInfoKindTitle,SalMazayaMovaghatTitle.SalMazayaMovaghatTitleTitle,SalHoghogh.SalHoghoghPrice
        //,SalHoghogh.Person_ID, SalHoghoghStartDate, SalHoghoghEndDate,SalHoghogh.ActivityCenterCode,WorkLoaction.WorkLoactionCode  from SalHoghogh,SalMazayaMovaghatTitle,SalHoghoghBaseInfoKind,ActivityCenter,WorkLoaction
        // where SalHoghogh.SalHoghoghBasiInfoID=SalMazayaMovaghatTitle.SalMazayaMovaghatTitleID
        // and SalHoghoghBaseInfoKind.ID=SalHoghogh.SalHoghoghBasiInfoKind
        // and SalHoghoghBasiInfoKind=1    and SalHoghogh.SalHoghoghStartDate>='{0}' and SalHoghogh.SalHoghoghEndDate<='{1}'   and SalHoghogh.ActivityCenterCode=ActivityCenter.ActivityCenterCode and WorkLoaction.WorkLoactionCode=ActivityCenter.WorkLoactionCode and SalHoghogh.Person_ID={2}
        // union ALL
        //  select SalHoghoghBasiInfoKind,BenefitType.CodeBenefitType, SalHoghoghBaseInfoKind.Title as SalHoghoghBaseInfoKindTitle,BenefitType.name_mazaya,SalHoghogh.SalHoghoghPrice
        //,SalHoghogh.Person_ID, SalHoghoghStartDate, SalHoghoghEndDate ,SalHoghogh.ActivityCenterCode,WorkLoaction.WorkLoactionCode from SalHoghogh,BenefitType,SalHoghoghBaseInfoKind,ActivityCenter,WorkLoaction
        // where SalHoghogh.SalHoghoghBasiInfoID=BenefitType.CodeBenefitType
        // and SalHoghoghBaseInfoKind.ID=SalHoghogh.SalHoghoghBasiInfoKind
        // and SalHoghoghBasiInfoKind=3   and SalHoghogh.SalHoghoghStartDate>='{0}' and SalHoghogh.SalHoghoghEndDate<='{1}'  and SalHoghogh.ActivityCenterCode=ActivityCenter.ActivityCenterCode and WorkLoaction.WorkLoactionCode=ActivityCenter.WorkLoactionCode and SalHoghogh.Person_ID={2}
        //union ALL
        //SELECT        dbo.SalHoghogh.SalHoghoghBasiInfoKind, dbo.SalBaseInfo.PuBaseInfoCode, dbo.SalHoghoghBaseInfoKind.Title AS SalHoghoghBaseInfoKindTitle, dbo.SalBaseInfo.PuBaseInfoText, 
        //                         dbo.SalHoghogh.SalHoghoghPrice, dbo.SalHoghogh.Person_ID, dbo.SalHoghogh.SalHoghoghStartDate, dbo.SalHoghogh.SalHoghoghEndDate, dbo.SalHoghogh.ActivityCenterCode, 
        //                         dbo.WorkLoaction.WorkLoactionCode
        //FROM            dbo.SalKasrKarfarma INNER JOIN
        //                         dbo.SalBaseInfo ON dbo.SalKasrKarfarma.SalKasrKarfarmaTitle = dbo.SalBaseInfo.PuBaseInfoCode INNER JOIN
        //                         dbo.SalHoghogh INNER JOIN
        //                         dbo.SalHoghoghBaseInfoKind ON dbo.SalHoghogh.SalHoghoghBasiInfoKind = dbo.SalHoghoghBaseInfoKind.ID ON dbo.SalKasrKarfarma.SalKasrKarfarmaID = dbo.SalHoghogh.SalHoghoghBasiInfoID INNER JOIN
        //                         dbo.ActivityCenter ON dbo.SalHoghogh.ActivityCenterCode = dbo.ActivityCenter.ActivityCenterCode INNER JOIN
        //                         dbo.WorkLoaction ON dbo.ActivityCenter.WorkLoactionCode = dbo.WorkLoaction.WorkLoactionCode
        //WHERE        (dbo.SalHoghogh.SalHoghoghBasiInfoKind = 4) AND (dbo.SalBaseInfo.PuBaseInfoTypeCode = 1) AND (dbo.SalBaseInfo.PuBaseInfoTypeValue = 1) AND (dbo.SalHoghogh.SalHoghoghStartDate >= '{0}') 
        //                         AND (dbo.SalHoghogh.SalHoghoghEndDate <= '{1}') AND (dbo.SalHoghogh.ActivityCenterCode = dbo.ActivityCenter.ActivityCenterCode) AND 
        //                         (dbo.WorkLoaction.WorkLoactionCode = dbo.ActivityCenter.WorkLoactionCode) and SalHoghogh.Person_ID={2}
        //union ALL
        //SELECT        dbo.SalHoghogh.SalHoghoghBasiInfoKind, dbo.SalBaseInfo.PuBaseInfoCode, dbo.SalHoghoghBaseInfoKind.Title AS SalHoghoghBaseInfoKindTitle, dbo.SalBaseInfo.PuBaseInfoText, 
        //                         dbo.SalHoghogh.SalHoghoghPrice, dbo.SalHoghogh.Person_ID, dbo.SalHoghogh.SalHoghoghStartDate, dbo.SalHoghogh.SalHoghoghEndDate, dbo.SalHoghogh.ActivityCenterCode, 
        //                         dbo.WorkLoaction.WorkLoactionCode
        //FROM            dbo.SalKasrDastor INNER JOIN
        //                         dbo.SalHoghogh INNER JOIN
        //                         dbo.SalHoghoghBaseInfoKind ON dbo.SalHoghogh.SalHoghoghBasiInfoKind = dbo.SalHoghoghBaseInfoKind.ID ON dbo.SalKasrDastor.SalKasrDastorrID = dbo.SalHoghogh.SalHoghoghBasiInfoID INNER JOIN
        //                         dbo.SalBaseInfo ON dbo.SalKasrDastor.SalBaseInfoKasrDastorTitle = dbo.SalBaseInfo.PuBaseInfoCode INNER JOIN
        //                         dbo.ActivityCenter ON dbo.SalHoghogh.ActivityCenterCode = dbo.ActivityCenter.ActivityCenterCode INNER JOIN
        //                         dbo.WorkLoaction ON dbo.ActivityCenter.WorkLoactionCode = dbo.WorkLoaction.WorkLoactionCode
        //WHERE        (dbo.SalHoghogh.SalHoghoghBasiInfoKind = 5) AND (dbo.SalBaseInfo.PuBaseInfoTypeCode = 1) AND (dbo.SalBaseInfo.PuBaseInfoTypeValue = 2) AND (dbo.SalHoghogh.SalHoghoghStartDate >= '{0}') 
        //                         AND (dbo.SalHoghogh.SalHoghoghEndDate <= '{1}') AND (dbo.SalHoghogh.ActivityCenterCode = dbo.ActivityCenter.ActivityCenterCode) AND 
        //                         (dbo.WorkLoaction.WorkLoactionCode = dbo.ActivityCenter.WorkLoactionCode) and SalHoghogh.Person_ID={2}
        //union ALL
        //SELECT        dbo.SalHoghogh.SalHoghoghBasiInfoKind, dbo.SalBaseInfo.PuBaseInfoCode, dbo.SalHoghoghBaseInfoKind.Title AS SalHoghoghBaseInfoKindTitle, dbo.SalBaseInfo.PuBaseInfoText, 
        //                         dbo.SalHoghogh.SalHoghoghPrice, dbo.SalHoghogh.Person_ID, dbo.SalHoghogh.SalHoghoghStartDate, dbo.SalHoghogh.SalHoghoghEndDate, dbo.SalHoghogh.ActivityCenterCode, 
        //                         dbo.WorkLoaction.WorkLoactionCode
        //FROM            dbo.SalHoghogh INNER JOIN
        //                         dbo.SalHoghoghBaseInfoKind ON dbo.SalHoghogh.SalHoghoghBasiInfoKind = dbo.SalHoghoghBaseInfoKind.ID INNER JOIN
        //                         dbo.SalMosaede ON dbo.SalHoghogh.SalHoghoghBasiInfoID = dbo.SalMosaede.SalMosaedeID INNER JOIN
        //                         dbo.SalBaseInfo ON dbo.SalMosaede.SalMosaedeTitle = dbo.SalBaseInfo.PuBaseInfoCode INNER JOIN
        //                         dbo.ActivityCenter ON dbo.SalHoghogh.ActivityCenterCode = dbo.ActivityCenter.ActivityCenterCode INNER JOIN
        //                         dbo.WorkLoaction ON dbo.ActivityCenter.WorkLoactionCode = dbo.WorkLoaction.WorkLoactionCode
        //WHERE        (dbo.SalHoghogh.SalHoghoghBasiInfoKind = 6) AND (dbo.SalBaseInfo.PuBaseInfoTypeCode = 3) AND (dbo.SalBaseInfo.PuBaseInfoTypeValue = 1) AND (dbo.SalHoghogh.SalHoghoghStartDate >= '{0}') 
        //                         AND (dbo.SalHoghogh.SalHoghoghEndDate <= '{1}') AND (dbo.SalHoghogh.ActivityCenterCode = dbo.ActivityCenter.ActivityCenterCode) AND 
        //                         (dbo.WorkLoaction.WorkLoactionCode = dbo.ActivityCenter.WorkLoactionCode) and SalHoghogh.Person_ID={2}
        //union all
        //select SalHoghoghBasiInfoKind,SalVam.SalVamID, SalHoghoghBaseInfoKind.Title as SalHoghoghBaseInfoKindTitle,SalVam.SalVamTitle,SalHoghogh.SalHoghoghPrice
        // ,SalHoghogh.Person_ID, SalHoghoghStartDate, SalHoghoghEndDate,SalHoghogh.ActivityCenterCode ,dbo.WorkLoaction.WorkLoactionCode  from SalHoghogh,SalVam,SalHoghoghBaseInfoKind,ActivityCenter,WorkLoaction
        // where SalHoghogh.SalHoghoghBasiInfoID=SalVam.SalVamID
        // and SalHoghoghBaseInfoKind.ID=SalHoghogh.SalHoghoghBasiInfoKind  
        // and SalHoghoghBasiInfoKind=7   and SalHoghogh.SalHoghoghStartDate>='{0}' and SalHoghogh.SalHoghoghEndDate<='{1}'  and SalHoghogh.ActivityCenterCode=ActivityCenter.ActivityCenterCode and WorkLoaction.WorkLoactionCode=ActivityCenter.WorkLoactionCode  and SalHoghogh.Person_ID={2}
        // union all
        // select 8 as SalHoghoghBasiInfoKind,SalBimeh.SalBimehID,N'کسورات سهم کارگر بیمه' as Title,SalBimeh.SalBimehInsCompName,SalBimehMah.SalBimehMahSahmeBimeKargar,
        // SalBimehMah.SalBimehMahPersonID, SalBimehMahStartDate, SalBimehMahEndDate,SalBimehMah.ActivityCenterCode as ActivityCenterCode,WorkLoaction.WorkLoactionCode   from SalBimehMah,SalBimeh,dbo.ActivityCenter, dbo.WorkLoaction
        // where SalBimeh.SalBimehID=SalBimehMahBimehID   and SalBimehMah.SalBimehMahStartDate>='{0}' and SalBimehMah.SalBimehMahEndDate<='{1}' and SalBimehMah.ActivityCenterCode=ActivityCenter.ActivityCenterCode and WorkLoaction.WorkLoactionCode=ActivityCenter.WorkLoactionCode and SalBimehMah.SalBimehMahPersonID={2}
        // union all
        //  select 8 as SalHoghoghBasiInfoKind,-1,N'کسورات سهم کارگر مالیات' as Title,N'مالیات',SalMaliat.SalMaliatMaliat,
        // SalMaliat.SalMaliatPersonID,SalMaliatStartDate,SalMaliatEndDate,SalMaliat.ActivityCenterCode as ActivityCenterCode,WorkLoaction.WorkLoactionCode  from SalMaliat ,ActivityCenter,WorkLoaction
        // where     SalMaliat.SalMaliatStartDate>='{0}' and SalMaliat.SalMaliatEndDate<='{1}'  and SalMaliat.ActivityCenterCode=ActivityCenter.ActivityCenterCode and WorkLoaction.WorkLoactionCode=ActivityCenter.WorkLoactionCode  and SalMaliat.SalMaliatPersonID={2}
        // union  
        //  select 9 as SalHoghoghBasiInfoKind,SalBimeh.SalBimehID,N'کسورات سهم کارفرما بیمه' as Title,SalBimeh.SalBimehInsCompName,SalBimehMah.SalBimehMahSahmeBimeKarfarma+isnull(SalBimehMah.SalBimehMahBimeBikari,0),
        // SalBimehMah.SalBimehMahPersonID,SalBimehMahStartDate,SalBimehMahEndDate, SalBimehMah.ActivityCenterCode as ActivityCenterCode,WorkLoaction.WorkLoactionCode from SalBimehMah,SalBimeh,dbo.ActivityCenter, dbo.WorkLoaction
        // where SalBimeh.SalBimehID=SalBimehMahBimehID    and SalBimehMah.SalBimehMahStartDate>='{0}' and SalBimehMah.SalBimehMahEndDate<='{1}'  and SalBimehMah.ActivityCenterCode=ActivityCenter.ActivityCenterCode and WorkLoaction.WorkLoactionCode=ActivityCenter.WorkLoactionCode and SalBimehMah.SalBimehMahPersonID={2}
        //union all
        //  select 9 as SalHoghoghBasiInfoKind,-2,N'کسورات سهم کارفرما عیدی' as Title,N'عیدی',SalZakhireEydiMah.SalZakhireEydiMahPrice,
        // SalZakhireEydiMah.PersonID,SalZakhireEydiMahStartDate,SalZakhireEydiMahEndDate,SalZakhireEydiMah.ActivityCenterCode as ActivityCenterCode,WorkLoaction.WorkLoactionCode as WorkLoactionCode  from SalZakhireEydiMah ,ActivityCenter,WorkLoaction
        // where  SalZakhireEydiMah.SalZakhireEydiMahStartDate>='{0}' and SalZakhireEydiMah.SalZakhireEydiMahEndDate<='{1}'  and SalZakhireEydiMah.ActivityCenterCode=ActivityCenter.ActivityCenterCode and WorkLoaction.WorkLoactionCode=ActivityCenter.WorkLoactionCode  and SalZakhireEydiMah.PersonID={2}
        // union all
        //  select 9 as SalHoghoghBasiInfoKind,-3,N'کسورات سهم کارفرما سنوات' as Title,N'سنوات',[SalMonthSanavat].Price,
        // [SalMonthSanavat].SalMonthSanavatPID,[SalMonthSanavat].SalMonthSanavatFromDate,[SalMonthSanavat].SalMonthSanavatToDate,[SalMonthSanavat].activitycentercode as ActivityCenterCode,WorkLoaction.WorkLoactionCode  from [SalMonthSanavat] ,dbo.ActivityCenter, dbo.WorkLoaction
        // where  [SalMonthSanavat].SalMonthSanavatFromDate>='{0}' and [SalMonthSanavat].SalMonthSanavatToDate<='{1}'    and [SalMonthSanavat].ActivityCenterCode=ActivityCenter.ActivityCenterCode and WorkLoaction.WorkLoactionCode=ActivityCenter.WorkLoactionCode and  [SalMonthSanavat].SalMonthSanavatPID={2}
        // ", startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"), Pid));
        //        }
        //        public static DataTable ProcShowHoghooghNakhales(int pid, int kind, DateTime dts, DateTime dte)
        //        {

        //            return repository.GetAllDataTable($"exec dbo.[Hoghoghselect] {pid},{kind},'{dts.ToString("yyyy-MM-dd")}','{dte.ToString("yyyy-MM-dd")}'");

        //        }
        //        public static List<T> GetActivePersonal(DateTime date)
        //        {
        //            return repository.GetAllQuery("select * from dbo.RetActiveBimehPersonal('" + date.ToString("yyyy-MM-dd") + "')").ToList();
        //        }
        //        public static DataTable ProcVamSelect(int pid, DateTime dt1, DateTime dt2)
        //        {
        //            return repository.GetAllDataTable($"dbo.[VamsSelect] {pid},'{dt1.ToString("yyyy-MM-dd")}','{dt2.ToString("yyyy-MM-dd")}'");
        //        }
        //        public static void UpdateBimehKargar(int bid, DateTime date)
        //        {
        //            repository.ExecuteQuery("exec ChangeBimeKargar  " + bid + ",'" + date.ToString("yyyy-MM-dd") + "'");
        //        }
        //        public static DataTable RetTitle()
        //        {
        //            return repository.GetAllDataTable(@"select distinct FormulType as groupFP, MonthValueType,ID,EnName,FaName,ValueType  from
        //(SELECT      FormulType ,  t1.MonthValueType, t1.ID, t1.EnName, t1.FaName, t1.MonthValueValue, t1.MonthValueStartDate, t1.MonthValueEndDate, t1.MonthValuePid, InfoPersonal_1.Id_Personal, InfoPersonal_1.Pid, 
        //                         InfoPersonal_1.ActivityCenterCode, InfoPersonal_1.WorkLoactionCode, InfoPersonal_1.Family, InfoPersonal_1.Name, t1.ValueType, dbo.ActivityCenter.ActivityCenterTitel, 
        //                         dbo.WorkLoaction.WorkLoactionTitel,dbo.WorkLoaction.WorkLoactionID, dbo.ActivityCenter.ActivityCenterID
        //FROM            (SELECT   t5.FormulType,     t5.MonthValueType, t5.ID, t5.EnName, t5.FaName, t5.MonthValueValue AS ccc, t5.MonthValueValue / (CASE
        //                                                        (SELECT        SUM(w.WPRealDay)
        //                                                           FROM            WorkedMonth AS w
        //                                                           WHERE        t5.Pid = w.PID AND t5.MonthValueStartDate = w.DateStart AND t5.MonthValueEndDate = w.DateEnd) WHEN 0 THEN 1 ELSE
        //                                                        (SELECT        SUM(w.WPRealDay)
        //                                                           FROM            WorkedMonth AS w
        //                                                           WHERE        t5.Pid = w.PID AND t5.MonthValueStartDate = w.DateStart AND t5.MonthValueEndDate = w.DateEnd) END) * dbo.WorkedMonth.WPRealDay AS MonthValueValue, 
        //                                                    t5.MonthValueStartDate, t5.MonthValueEndDate, t5.MonthValuePid, t5.Id_Personal, t5.Pid, t5.Family, t5.Name, t5.ValueType, dbo.WorkedMonth.WPRealDay, 
        //                                                    dbo.WorkedMonth.ActivityCenterCode
        //                           FROM            (SELECT    t1.FormulType,    t1.MonthValueType, t1.ID, t1.EnName, t1.FaName, t1.MonthValueValue, t1.MonthValueStartDate, t1.MonthValueEndDate, t1.MonthValuePid, dbo.InfoPersonal.Id_Personal, 
        //                                                                               dbo.InfoPersonal.Pid, dbo.InfoPersonal.Family, dbo.InfoPersonal.Name, t1.ValueType
        //                                                      FROM            (SELECT    dbo.Formul.FormulType,    dbo.MonthValue.MonthValueType , dbo.MonthValue.MonthValueFPID AS ID, dbo.Formul.FormulEnName AS EnName, dbo.Formul.FormulFaName AS FaName, 
        //                                                                                                         convert(float,  MonthValueValue   )  as MonthValueValue, dbo.MonthValue.MonthValueStartDate, dbo.MonthValue.MonthValueEndDate, dbo.MonthValue.MonthValuePid, 1 AS ValueType
        //                                                                                 FROM           dbo.Formul INNER JOIN
        //                                                                                                          dbo.MonthValue ON dbo.Formul.PuID = dbo.MonthValue.MonthValueFPID
        //                                                                                 WHERE        (dbo.MonthValue.MonthValueType = 2)
        //                                                                                 UNION
        //                                                                                 SELECT  ParameterDaste ,     MonthValue_1.MonthValueType , MonthValue_1.MonthValueFPID AS ID, dbo.Parameter.ParameterEnName AS EnName, 
        //                                                                                                          dbo.Parameter.ParameterFaName COLLATE Persian_100_CI_AI AS FaName, convert(float,  MonthValueValue   )  as MonthValueValue, MonthValue_1.MonthValueStartDate, 
        //                                                                                                          MonthValue_1.MonthValueEndDate, MonthValue_1.MonthValuePid, dbo.Parameter.ParameterValueType
        //                                                                                 FROM            dbo.Parameter INNER JOIN
        //                                                                                                          dbo.MonthValue AS MonthValue_1 ON dbo.Parameter.PuID = MonthValue_1.MonthValueFPID
        //                                                                                 WHERE        (MonthValue_1.MonthValueType = 1)
        //                                                                                 UNION
        //                                                                                 SELECT    3,    3 AS Expr1,SalBaseInfo.PuBaseInfoCode, pubaseinfolatintext AS EnName, dbo.SalBaseInfo.PuBaseInfoText AS FaName, dbo.SalKasrGhest.SalKasrGhestGhestPrice, 
        //                                                                                                          dbo.RetStartMountMiladi(dbo.SalKasrGhest.SalKasrGhestGhestDate) AS startdate, dbo.RetEndMountMiladi(dbo.SalKasrGhest.SalKasrGhestGhestDate) AS enddate, 
        //                                                                                                          dbo.SalKasrDastor.SalPersonID, 1 AS Expr2
        //                                                                                 FROM            dbo.SalKasrDastor INNER JOIN
        //                                                                                                          dbo.SalKasrGhest ON dbo.SalKasrDastor.SalKasrDastorrID = dbo.SalKasrGhest.SalKasrDastorID INNER JOIN
        //                                                                                                          dbo.SalBaseInfo ON dbo.SalKasrDastor.SalBaseInfoKasrDastorTitle = dbo.SalBaseInfo.PuBaseInfoCode
        //                                                                                 UNION
        //                                                                                 SELECT      3,  4 AS Expr1  , SalBaseInfo_2.PuBaseInfoCode, pubaseinfolatintext AS EnName, SalBaseInfo_2.PuBaseInfoText AS FaName, dbo.SalKasrKarfarmaGhest.SalKasrKarfarmaGhestSumPrice, 
        //                                                                                                          dbo.RetStartMountMiladi(dbo.SalKasrKarfarmaGhest.SalKasrKarfarmaGhestDate) AS startdate, 
        //                                                                                                          dbo.RetEndMountMiladi(dbo.SalKasrKarfarmaGhest.SalKasrKarfarmaGhestDate) AS enddate, dbo.SalKasrKarfarma.SalPersonID, 1 AS Expr2
        //                                                                                 FROM            dbo.SalKasrKarfarma INNER JOIN
        //                                                                                                          dbo.SalKasrKarfarmaGhest ON dbo.SalKasrKarfarma.SalKasrKarfarmaID = dbo.SalKasrKarfarmaGhest.SalKasrKarfarmaID INNER JOIN
        //                                                                                                          dbo.SalBaseInfo AS SalBaseInfo_2 ON dbo.SalKasrKarfarma.SalKasrKarfarmaTitle = SalBaseInfo_2.PuBaseInfoCode
        //                                                                                 UNION
        //                                                                                 SELECT    3,    5 AS Expr1, SalBaseInfo_1.PuBaseInfoCode, pubaseinfolatintext AS EnName, SalBaseInfo_1.PuBaseInfoText AS FaName, dbo.SalMosaedeGhest.SalMosaedeGhestPrice, 
        //                                                                                                          dbo.RetStartMountMiladi(dbo.SalMosaedeGhest.SalMosaedeGhestDate) AS startdate, dbo.RetEndMountMiladi(dbo.SalMosaedeGhest.SalMosaedeGhestDate) AS enddate, 
        //                                                                                                          dbo.SalMosaede.SalPersonID, 1 AS Expr2
        //                                                                                 FROM            dbo.SalMosaede INNER JOIN
        //                                                                                                          dbo.SalMosaedeGhest ON dbo.SalMosaede.SalMosaedeID = dbo.SalMosaedeGhest.SalMosaedeID INNER JOIN
        //                                                                                                          dbo.SalBaseInfo AS SalBaseInfo_1 ON dbo.SalMosaede.SalMosaedeTitle = SalBaseInfo_1.PuBaseInfoCode
        //                                                                                 UNION
        //                                                                                 SELECT  3,      6 AS Expr1, dbo.SalVam.SalVamID, dbo.SalVam.SalVamLatinTitle AS Expr2, dbo.SalVam.SalVamTitle, dbo.SalVamGhest.SalVamGhestPrice, 
        //                                                                                                          dbo.RetStartMountMiladi(dbo.SalVamGhest.SalVamGhestDate) AS Expr5, dbo.RetEndMountMiladi(dbo.SalVamGhest.SalVamGhestDate) AS Expr3, 
        //                                                                                                          dbo.SalVamGirande.SalPerson_ID, 1 AS Expr4
        //                                                                                 FROM            dbo.SalVam INNER JOIN
        //                                                                                                          dbo.SalVamGirande ON dbo.SalVam.SalVamID = dbo.SalVamGirande.SalVamID INNER JOIN
        //                                                                                                          dbo.SalVamGhest ON dbo.SalVamGirande.SalVamGirandeID = dbo.SalVamGhest.SalVamGirandeID
        //                                                                                 UNION
        //                                                                                 SELECT  2,      7 AS Expr1, SalMazayaMovaghatTitleID, salMazayaMovaghatLatinTitle, SalMazayaMovaghatTitleTitle, 
        //                                                                                                          dbo.SalMazayaMovaghat.SalMazayaMovaghatPrice, dbo.RetStartMountMiladi(dbo.SalMazayaMovaghat.SalMazayaMovaghatAzDate) AS Expr5, 
        //                                                                                                          dbo.RetEndMountMiladi(dbo.SalMazayaMovaghat.SalMazayaMovaghatAzDate) AS Expr3, dbo.SalMazayaMovaghat.PersonID, 1 AS Expr4
        //                                                                                 FROM            dbo.SalMazayaMovaghatTitle INNER JOIN
        //                                                                                                          dbo.SalMazayaMovaghat ON dbo.SalMazayaMovaghatTitle.SalMazayaMovaghatTitleID = dbo.SalMazayaMovaghat.MazayaMovaghatID) AS t1 INNER JOIN
        //                                                                               dbo.InfoPersonal ON t1.MonthValuePid = dbo.InfoPersonal.Pid) AS t5 INNER JOIN
        //                                                    dbo.WorkedMonth ON t5.Pid = dbo.WorkedMonth.PID AND t5.MonthValueStartDate = dbo.WorkedMonth.DateStart AND t5.MonthValueEndDate = dbo.WorkedMonth.DateEnd) AS t1 INNER JOIN
        //                         dbo.InfoPersonal AS InfoPersonal_1 ON t1.MonthValuePid = InfoPersonal_1.Pid INNER JOIN
        //                         dbo.ActivityCenter ON t1.ActivityCenterCode = dbo.ActivityCenter.ActivityCenterCode INNER JOIN
        //                         dbo.WorkLoaction ON dbo.ActivityCenter.WorkLoactionCode = dbo.WorkLoaction.WorkLoactionCode  
        //) as t55  ");
        //        }
        //        public static DataTable RetValue(string Query)
        //        {
        //            return repository.GetAllDataTable(@"SELECT      FormulType ,  t1.MonthValueType, t1.ID, t1.EnName, t1.FaName, t1.MonthValueValue, t1.MonthValueStartDate, t1.MonthValueEndDate, t1.MonthValuePid, InfoPersonal_1.Id_Personal, InfoPersonal_1.Pid, 
        //                         InfoPersonal_1.ActivityCenterCode, InfoPersonal_1.WorkLoactionCode, InfoPersonal_1.Family, InfoPersonal_1.Name, t1.ValueType, dbo.ActivityCenter.ActivityCenterTitel, 
        //                         dbo.WorkLoaction.WorkLoactionTitel,dbo.WorkLoaction.WorkLoactionID, dbo.ActivityCenter.ActivityCenterID
        //FROM            (SELECT   t5.FormulType,     t5.MonthValueType, t5.ID, t5.EnName, t5.FaName, t5.MonthValueValue AS ccc, t5.MonthValueValue / (CASE
        //                                                        (SELECT        SUM(w.WPRealDay)
        //                                                           FROM            WorkedMonth AS w
        //                                                           WHERE        t5.Pid = w.PID AND t5.MonthValueStartDate = w.DateStart AND t5.MonthValueEndDate = w.DateEnd) WHEN 0 THEN 1 ELSE
        //                                                        (SELECT        SUM(w.WPRealDay)
        //                                                           FROM            WorkedMonth AS w
        //                                                           WHERE        t5.Pid = w.PID AND t5.MonthValueStartDate = w.DateStart AND t5.MonthValueEndDate = w.DateEnd) END) * dbo.WorkedMonth.WPRealDay AS MonthValueValue, 
        //                                                    t5.MonthValueStartDate, t5.MonthValueEndDate, t5.MonthValuePid, t5.Id_Personal, t5.Pid, t5.Family, t5.Name, t5.ValueType, dbo.WorkedMonth.WPRealDay, 
        //                                                    dbo.WorkedMonth.ActivityCenterCode
        //                           FROM            (SELECT    t1.FormulType,    t1.MonthValueType, t1.ID, t1.EnName, t1.FaName, t1.MonthValueValue, t1.MonthValueStartDate, t1.MonthValueEndDate, t1.MonthValuePid, dbo.InfoPersonal.Id_Personal, 
        //                                                                               dbo.InfoPersonal.Pid, dbo.InfoPersonal.Family, dbo.InfoPersonal.Name, t1.ValueType
        //                                                      FROM            (SELECT    dbo.Formul.FormulType,    dbo.MonthValue.MonthValueType , dbo.MonthValue.MonthValueFPID AS ID, dbo.Formul.FormulEnName AS EnName, dbo.Formul.FormulFaName AS FaName, 
        //                                                                                                         convert(float,  MonthValueValue   )  as MonthValueValue, dbo.MonthValue.MonthValueStartDate, dbo.MonthValue.MonthValueEndDate, dbo.MonthValue.MonthValuePid, 1 AS ValueType
        //                                                                                 FROM           dbo.Formul INNER JOIN
        //                                                                                                          dbo.MonthValue ON dbo.Formul.PuID = dbo.MonthValue.MonthValueFPID
        //                                                                                 WHERE        (dbo.MonthValue.MonthValueType = 2)
        //                                                                                 UNION
        //                                                                                 SELECT  ParameterDaste ,     MonthValue_1.MonthValueType , MonthValue_1.MonthValueFPID AS ID, dbo.Parameter.ParameterEnName AS EnName, 
        //                                                                                                          dbo.Parameter.ParameterFaName COLLATE Persian_100_CI_AI AS FaName, convert(float,  MonthValueValue   )  as MonthValueValue, MonthValue_1.MonthValueStartDate, 
        //                                                                                                          MonthValue_1.MonthValueEndDate, MonthValue_1.MonthValuePid, dbo.Parameter.ParameterValueType
        //                                                                                 FROM            dbo.Parameter INNER JOIN
        //                                                                                                          dbo.MonthValue AS MonthValue_1 ON dbo.Parameter.PuID = MonthValue_1.MonthValueFPID
        //                                                                                 WHERE        (MonthValue_1.MonthValueType = 1)
        //                                                                                 UNION
        //                                                                                 SELECT    3,    3 AS Expr1,SalBaseInfo.PuBaseInfoCode, pubaseinfolatintext AS EnName, dbo.SalBaseInfo.PuBaseInfoText AS FaName, dbo.SalKasrGhest.SalKasrGhestGhestPrice, 
        //                                                                                                          dbo.RetStartMountMiladi(dbo.SalKasrGhest.SalKasrGhestGhestDate) AS startdate, dbo.RetEndMountMiladi(dbo.SalKasrGhest.SalKasrGhestGhestDate) AS enddate, 
        //                                                                                                          dbo.SalKasrDastor.SalPersonID, 1 AS Expr2
        //                                                                                 FROM            dbo.SalKasrDastor INNER JOIN
        //                                                                                                          dbo.SalKasrGhest ON dbo.SalKasrDastor.SalKasrDastorrID = dbo.SalKasrGhest.SalKasrDastorID INNER JOIN
        //                                                                                                          dbo.SalBaseInfo ON dbo.SalKasrDastor.SalBaseInfoKasrDastorTitle = dbo.SalBaseInfo.PuBaseInfoCode
        //                                                                                 UNION
        //                                                                                 SELECT      3,  4 AS Expr1  , SalBaseInfo_2.PuBaseInfoCode, pubaseinfolatintext AS EnName, SalBaseInfo_2.PuBaseInfoText AS FaName, dbo.SalKasrKarfarmaGhest.SalKasrKarfarmaGhestSumPrice, 
        //                                                                                                          dbo.RetStartMountMiladi(dbo.SalKasrKarfarmaGhest.SalKasrKarfarmaGhestDate) AS startdate, 
        //                                                                                                          dbo.RetEndMountMiladi(dbo.SalKasrKarfarmaGhest.SalKasrKarfarmaGhestDate) AS enddate, dbo.SalKasrKarfarma.SalPersonID, 1 AS Expr2
        //                                                                                 FROM            dbo.SalKasrKarfarma INNER JOIN
        //                                                                                                          dbo.SalKasrKarfarmaGhest ON dbo.SalKasrKarfarma.SalKasrKarfarmaID = dbo.SalKasrKarfarmaGhest.SalKasrKarfarmaID INNER JOIN
        //                                                                                                          dbo.SalBaseInfo AS SalBaseInfo_2 ON dbo.SalKasrKarfarma.SalKasrKarfarmaTitle = SalBaseInfo_2.PuBaseInfoCode
        //                                                                                 UNION
        //                                                                                 SELECT    3,    5 AS Expr1, SalBaseInfo_1.PuBaseInfoCode, pubaseinfolatintext AS EnName, SalBaseInfo_1.PuBaseInfoText AS FaName, dbo.SalMosaedeGhest.SalMosaedeGhestPrice, 
        //                                                                                                          dbo.RetStartMountMiladi(dbo.SalMosaedeGhest.SalMosaedeGhestDate) AS startdate, dbo.RetEndMountMiladi(dbo.SalMosaedeGhest.SalMosaedeGhestDate) AS enddate, 
        //                                                                                                          dbo.SalMosaede.SalPersonID, 1 AS Expr2
        //                                                                                 FROM            dbo.SalMosaede INNER JOIN
        //                                                                                                          dbo.SalMosaedeGhest ON dbo.SalMosaede.SalMosaedeID = dbo.SalMosaedeGhest.SalMosaedeID INNER JOIN
        //                                                                                                          dbo.SalBaseInfo AS SalBaseInfo_1 ON dbo.SalMosaede.SalMosaedeTitle = SalBaseInfo_1.PuBaseInfoCode
        //                                                                                 UNION
        //                                                                                 SELECT  3,      6 AS Expr1, dbo.SalVam.SalVamID, dbo.SalVam.SalVamLatinTitle AS Expr2, dbo.SalVam.SalVamTitle, dbo.SalVamGhest.SalVamGhestPrice, 
        //                                                                                                          dbo.RetStartMountMiladi(dbo.SalVamGhest.SalVamGhestDate) AS Expr5, dbo.RetEndMountMiladi(dbo.SalVamGhest.SalVamGhestDate) AS Expr3, 
        //                                                                                                          dbo.SalVamGirande.SalPerson_ID, 1 AS Expr4
        //                                                                                 FROM            dbo.SalVam INNER JOIN
        //                                                                                                          dbo.SalVamGirande ON dbo.SalVam.SalVamID = dbo.SalVamGirande.SalVamID INNER JOIN
        //                                                                                                          dbo.SalVamGhest ON dbo.SalVamGirande.SalVamGirandeID = dbo.SalVamGhest.SalVamGirandeID
        //                                                                                 UNION
        //                                                                                 SELECT  2,      7 AS Expr1, SalMazayaMovaghatTitleID, salMazayaMovaghatLatinTitle, SalMazayaMovaghatTitleTitle, 
        //                                                                                                          dbo.SalMazayaMovaghat.SalMazayaMovaghatPrice, dbo.RetStartMountMiladi(dbo.SalMazayaMovaghat.SalMazayaMovaghatAzDate) AS Expr5, 
        //                                                                                                          dbo.RetEndMountMiladi(dbo.SalMazayaMovaghat.SalMazayaMovaghatAzDate) AS Expr3, dbo.SalMazayaMovaghat.PersonID, 1 AS Expr4
        //                                                                                 FROM            dbo.SalMazayaMovaghatTitle INNER JOIN
        //                                                                                                          dbo.SalMazayaMovaghat ON dbo.SalMazayaMovaghatTitle.SalMazayaMovaghatTitleID = dbo.SalMazayaMovaghat.MazayaMovaghatID) AS t1 INNER JOIN
        //                                                                               dbo.InfoPersonal ON t1.MonthValuePid = dbo.InfoPersonal.Pid) AS t5 INNER JOIN
        //                                                    dbo.WorkedMonth ON t5.Pid = dbo.WorkedMonth.PID AND t5.MonthValueStartDate = dbo.WorkedMonth.DateStart AND t5.MonthValueEndDate = dbo.WorkedMonth.DateEnd) AS t1 INNER JOIN
        //                         dbo.InfoPersonal AS InfoPersonal_1 ON t1.MonthValuePid = InfoPersonal_1.Pid INNER JOIN
        //                         dbo.ActivityCenter ON t1.ActivityCenterCode = dbo.ActivityCenter.ActivityCenterCode INNER JOIN
        //                         dbo.WorkLoaction ON dbo.ActivityCenter.WorkLoactionCode = dbo.WorkLoaction.WorkLoactionCode  
        //where " + Query);
        //        }
        //        public static DataTable GetBankShoab()
        //        {
        //            return repository.GetAllDataTable(@"select distinct Banks.BanksName+'_'+Shoab.ShoabName as name,Shoab.ShoabID from NumberAccountPersonal,Shoab,Banks
        // where NumberAccountPersonal.CodeBranchs=Shoab.ShoabID
        // and Shoab.BankID=Banks.BanksID");

        //        }
        //        public static DataTable GetAllByTitle()
        //        {
        //            return repository.GetAllDataTable(@"select distinct SalHoghoghBasiInfoKind,SalHoghoghBaseInfoID, SalHoghoghBaseInfoKindTitle, SalHoghoghBaseInfoTitle from
        // (select SalHoghoghBasiInfoKind,SalHoghoghBaseInfoID, SalHoghoghBaseInfoKind.Title as SalHoghoghBaseInfoKindTitle,SalHoghoghBaseInfo.SalHoghoghBaseInfoTitle  from SalHoghogh,SalHoghoghBaseInfo,SalHoghoghBaseInfoKind
        // where SalHoghogh.SalHoghoghBasiInfoID=SalHoghoghBaseInfo.SalHoghoghBaseInfoID
        // and SalHoghoghBaseInfoKind.ID=SalHoghogh.SalHoghoghBasiInfoKind
        // and SalHoghoghBasiInfoKind=2  
        // union ALL
        // select SalHoghoghBasiInfoKind,SalMazayaMovaghatTitle.SalMazayaMovaghatTitleID, SalHoghoghBaseInfoKind.Title as SalHoghoghBaseInfoKindTitle,SalMazayaMovaghatTitle.SalMazayaMovaghatTitleTitle   from SalHoghogh,SalMazayaMovaghatTitle,SalHoghoghBaseInfoKind
        // where SalHoghogh.SalHoghoghBasiInfoID=SalMazayaMovaghatTitle.SalMazayaMovaghatTitleID
        // and SalHoghoghBaseInfoKind.ID=SalHoghogh.SalHoghoghBasiInfoKind
        // and SalHoghoghBasiInfoKind=1  
        // union ALL
        //  select SalHoghoghBasiInfoKind,BenefitType.CodeBenefitType, SalHoghoghBaseInfoKind.Title as SalHoghoghBaseInfoKindTitle,BenefitType.name_mazaya from SalHoghogh,BenefitType,SalHoghoghBaseInfoKind
        // where SalHoghogh.SalHoghoghBasiInfoID=BenefitType.CodeBenefitType
        // and SalHoghoghBaseInfoKind.ID=SalHoghogh.SalHoghoghBasiInfoKind
        // and SalHoghoghBasiInfoKind=3 
        //union ALL
        //  SELECT        dbo.SalHoghogh.SalHoghoghBasiInfoKind, dbo.SalBaseInfo.PuBaseInfoCode, dbo.SalHoghoghBaseInfoKind.Title AS SalHoghoghBaseInfoKindTitle, dbo.SalBaseInfo.PuBaseInfoText

        //FROM            dbo.SalKasrKarfarma INNER JOIN
        //                         dbo.SalBaseInfo ON dbo.SalKasrKarfarma.SalKasrKarfarmaTitle = dbo.SalBaseInfo.PuBaseInfoCode INNER JOIN
        //                         dbo.SalHoghogh INNER JOIN
        //                         dbo.SalHoghoghBaseInfoKind ON dbo.SalHoghogh.SalHoghoghBasiInfoKind = dbo.SalHoghoghBaseInfoKind.ID ON dbo.SalKasrKarfarma.SalKasrKarfarmaID = dbo.SalHoghogh.SalHoghoghBasiInfoID
        //WHERE        (dbo.SalHoghogh.SalHoghoghBasiInfoKind = 4) AND (dbo.SalBaseInfo.PuBaseInfoTypeCode = 1) AND (dbo.SalBaseInfo.PuBaseInfoTypeValue = 1)

        // union ALL
        // SELECT        dbo.SalHoghogh.SalHoghoghBasiInfoKind, dbo.SalBaseInfo.PuBaseInfoCode, dbo.SalHoghoghBaseInfoKind.Title AS SalHoghoghBaseInfoKindTitle, dbo.SalBaseInfo.PuBaseInfoText 
        //FROM            dbo.SalKasrDastor INNER JOIN
        //                         dbo.SalHoghogh INNER JOIN
        //                         dbo.SalHoghoghBaseInfoKind ON dbo.SalHoghogh.SalHoghoghBasiInfoKind = dbo.SalHoghoghBaseInfoKind.ID ON dbo.SalKasrDastor.SalKasrDastorrID = dbo.SalHoghogh.SalHoghoghBasiInfoID INNER JOIN
        //                         dbo.SalBaseInfo ON dbo.SalKasrDastor.SalBaseInfoKasrDastorTitle = dbo.SalBaseInfo.PuBaseInfoCode
        //WHERE        (dbo.SalHoghogh.SalHoghoghBasiInfoKind = 5) AND (dbo.SalBaseInfo.PuBaseInfoTypeCode = 1) AND (dbo.SalBaseInfo.PuBaseInfoTypeValue = 2)
        // union ALL
        //SELECT        dbo.SalHoghogh.SalHoghoghBasiInfoKind, dbo.SalBaseInfo.PuBaseInfoCode, dbo.SalHoghoghBaseInfoKind.Title AS SalHoghoghBaseInfoKindTitle, dbo.SalBaseInfo.PuBaseInfoText 
        //FROM            dbo.SalHoghogh INNER JOIN
        //                         dbo.SalHoghoghBaseInfoKind ON dbo.SalHoghogh.SalHoghoghBasiInfoKind = dbo.SalHoghoghBaseInfoKind.ID INNER JOIN
        //                         dbo.SalMosaede ON dbo.SalHoghogh.SalHoghoghBasiInfoID = dbo.SalMosaede.SalMosaedeID INNER JOIN
        //                         dbo.SalBaseInfo ON dbo.SalMosaede.SalMosaedeTitle = dbo.SalBaseInfo.PuBaseInfoCode
        //WHERE        (dbo.SalHoghogh.SalHoghoghBasiInfoKind = 6) AND (dbo.SalBaseInfo.PuBaseInfoTypeCode = 3) AND (dbo.SalBaseInfo.PuBaseInfoTypeValue = 1)
        // union all
        //select SalHoghoghBasiInfoKind,SalVam.SalVamID, SalHoghoghBaseInfoKind.Title as SalHoghoghBaseInfoKindTitle,SalVam.SalVamTitle   from SalHoghogh,SalVam,SalHoghoghBaseInfoKind
        // where SalHoghogh.SalHoghoghBasiInfoID=SalVam.SalVamID
        // and SalHoghoghBaseInfoKind.ID=SalHoghogh.SalHoghoghBasiInfoKind  
        // and SalHoghoghBasiInfoKind=7
        // union all
        // select 8 as SalHoghoghBasiInfoKind,SalBimeh.SalBimehID,N'کسورات سهم کارگر بیمه' as Title,SalBimeh.SalBimehInsCompName   from SalBimehMah,SalBimeh
        // where SalBimeh.SalBimehID=SalBimehMahBimehID  
        // union all
        //  select 8 as SalHoghoghBasiInfoKind,-1,N'کسورات سهم کارگر مالیات' as Title,N'مالیات'   from SalMaliat 
        // union all
        //  select 9 as SalHoghoghBasiInfoKind,SalBimeh.SalBimehID,N'کسورات سهم کارفرما بیمه' as Title,SalBimeh.SalBimehInsCompName   from SalBimehMah,SalBimeh
        // where SalBimeh.SalBimehID=SalBimehMahBimehID  
        //union all
        //  select 9 as SalHoghoghBasiInfoKind,-2,N'کسورات سهم کارفرما عیدی' as Title,N'عیدی'   from SalZakhireEydiMah 
        //union all
        //select 9 as SalHoghoghBasiInfoKind,-3,N'کسورات سهم کارفرما سنوات' as Title,N'سنوات'  as ActivityCenterCode  from [SalMonthSanavat] 
        //  ) as t1");

        //        }
        //        //public static float Get131(long Value, int pid)
        //        //{
        //        //    float x = float.Parse(repository.ExecuteSqlString("select PuBaseInfoValueInt from SalBaseInfo where PuBaseInfoTypeCode=7 and PuBaseInfoTypeValue=1 "));
        //        //    List<SalBimehKargar> ListBim = ClsDB<SalBimehKargar>.GetAllBy("SalPersonID", pid);
        //        //    float ret1 = ListBim.Count(c => c.SalBimehKargarMoafiat82.HasValue) == 0 ?
        //        //             x : (float)ListBim.First(c => c.SalBimehKargarID == ListBim.Max(d => d.SalBimehKargarID)).SalBimehKargarMoafiat82.Value;

        //        //    float ret;
        //        //    if (Value - ret1 > 0)
        //        //    {
        //        //        ret = float.Parse(repository.ExecuteSqlString("exec [dbo].[Made131] " + (Value - ret1)));
        //        //    }
        //        //    else
        //        //        ret = 0;

        //        //    return ret;
        //        //}
        //        public static int GetSumZemanat(int PersonID, int Price, int ret)
        //        {
        //            return int.Parse(repository.ExecuteSqlString($"exec [dbo].[GetSumZemanat] {PersonID}, {Price}, {ret}"));
        //        }
        //        public static DataTable GetAllByDate(DateTime startDate, DateTime endDate)
        //        {
        //            return repository.GetAllDataTable(string.Format(@"select SalHoghoghBasiInfoKind,SalHoghoghBaseInfoID, SalHoghoghBaseInfoKind.Title as SalHoghoghBaseInfoKindTitle,SalHoghoghBaseInfo.SalHoghoghBaseInfoTitle,SalHoghogh.SalHoghoghPrice
        //,SalHoghogh.Person_ID, SalHoghoghStartDate, SalHoghoghEndDate,SalHoghogh.ActivityCenterCode,WorkLoaction.WorkLoactionCode  from SalHoghogh,SalHoghoghBaseInfo,SalHoghoghBaseInfoKind,ActivityCenter,WorkLoaction
        // where SalHoghogh.SalHoghoghBasiInfoID=SalHoghoghBaseInfo.SalHoghoghBaseInfoID
        // and SalHoghoghBaseInfoKind.ID=SalHoghogh.SalHoghoghBasiInfoKind
        // and SalHoghoghBasiInfoKind=2  and SalHoghogh.SalHoghoghStartDate>='{0}' and SalHoghogh.SalHoghoghEndDate<='{1}'  and SalHoghogh.ActivityCenterCode=ActivityCenter.ActivityCenterCode and WorkLoaction.WorkLoactionCode=ActivityCenter.WorkLoactionCode
        // union ALL
        // select SalHoghoghBasiInfoKind,SalMazayaMovaghatTitle.SalMazayaMovaghatTitleID, SalHoghoghBaseInfoKind.Title as SalHoghoghBaseInfoKindTitle,SalMazayaMovaghatTitle.SalMazayaMovaghatTitleTitle,SalHoghogh.SalHoghoghPrice
        //,SalHoghogh.Person_ID, SalHoghoghStartDate, SalHoghoghEndDate,SalHoghogh.ActivityCenterCode,WorkLoaction.WorkLoactionCode  from SalHoghogh,SalMazayaMovaghatTitle,SalHoghoghBaseInfoKind,ActivityCenter,WorkLoaction
        // where SalHoghogh.SalHoghoghBasiInfoID=SalMazayaMovaghatTitle.SalMazayaMovaghatTitleID
        // and SalHoghoghBaseInfoKind.ID=SalHoghogh.SalHoghoghBasiInfoKind
        // and SalHoghoghBasiInfoKind=1    and SalHoghogh.SalHoghoghStartDate>='{0}' and SalHoghogh.SalHoghoghEndDate<='{1}'   and SalHoghogh.ActivityCenterCode=ActivityCenter.ActivityCenterCode and WorkLoaction.WorkLoactionCode=ActivityCenter.WorkLoactionCode
        // union ALL
        //  select SalHoghoghBasiInfoKind,BenefitType.CodeBenefitType, SalHoghoghBaseInfoKind.Title as SalHoghoghBaseInfoKindTitle,BenefitType.name_mazaya,SalHoghogh.SalHoghoghPrice
        //,SalHoghogh.Person_ID, SalHoghoghStartDate, SalHoghoghEndDate ,SalHoghogh.ActivityCenterCode,WorkLoaction.WorkLoactionCode from SalHoghogh,BenefitType,SalHoghoghBaseInfoKind,ActivityCenter,WorkLoaction
        // where SalHoghogh.SalHoghoghBasiInfoID=BenefitType.CodeBenefitType
        // and SalHoghoghBaseInfoKind.ID=SalHoghogh.SalHoghoghBasiInfoKind
        // and SalHoghoghBasiInfoKind=3   and SalHoghogh.SalHoghoghStartDate>='{0}' and SalHoghogh.SalHoghoghEndDate<='{1}'  and SalHoghogh.ActivityCenterCode=ActivityCenter.ActivityCenterCode and WorkLoaction.WorkLoactionCode=ActivityCenter.WorkLoactionCode
        //union ALL
        //SELECT        dbo.SalHoghogh.SalHoghoghBasiInfoKind, dbo.SalBaseInfo.PuBaseInfoCode, dbo.SalHoghoghBaseInfoKind.Title AS SalHoghoghBaseInfoKindTitle, dbo.SalBaseInfo.PuBaseInfoText, 
        //                         dbo.SalHoghogh.SalHoghoghPrice, dbo.SalHoghogh.Person_ID, dbo.SalHoghogh.SalHoghoghStartDate, dbo.SalHoghogh.SalHoghoghEndDate, dbo.SalHoghogh.ActivityCenterCode, 
        //                         dbo.WorkLoaction.WorkLoactionCode
        //FROM            dbo.SalKasrKarfarma INNER JOIN
        //                         dbo.SalBaseInfo ON dbo.SalKasrKarfarma.SalKasrKarfarmaTitle = dbo.SalBaseInfo.PuBaseInfoCode INNER JOIN
        //                         dbo.SalHoghogh INNER JOIN
        //                         dbo.SalHoghoghBaseInfoKind ON dbo.SalHoghogh.SalHoghoghBasiInfoKind = dbo.SalHoghoghBaseInfoKind.ID ON dbo.SalKasrKarfarma.SalKasrKarfarmaID = dbo.SalHoghogh.SalHoghoghBasiInfoID INNER JOIN
        //                         dbo.ActivityCenter ON dbo.SalHoghogh.ActivityCenterCode = dbo.ActivityCenter.ActivityCenterCode INNER JOIN
        //                         dbo.WorkLoaction ON dbo.ActivityCenter.WorkLoactionCode = dbo.WorkLoaction.WorkLoactionCode
        //WHERE        (dbo.SalHoghogh.SalHoghoghBasiInfoKind = 4) AND (dbo.SalBaseInfo.PuBaseInfoTypeCode = 1) AND (dbo.SalBaseInfo.PuBaseInfoTypeValue = 1) AND (dbo.SalHoghogh.SalHoghoghStartDate >= '{0}') 
        //                         AND (dbo.SalHoghogh.SalHoghoghEndDate <= '{1}') AND (dbo.SalHoghogh.ActivityCenterCode = dbo.ActivityCenter.ActivityCenterCode) AND 
        //                         (dbo.WorkLoaction.WorkLoactionCode = dbo.ActivityCenter.WorkLoactionCode)
        //union ALL
        //SELECT        dbo.SalHoghogh.SalHoghoghBasiInfoKind, dbo.SalBaseInfo.PuBaseInfoCode, dbo.SalHoghoghBaseInfoKind.Title AS SalHoghoghBaseInfoKindTitle, dbo.SalBaseInfo.PuBaseInfoText, 
        //                         dbo.SalHoghogh.SalHoghoghPrice, dbo.SalHoghogh.Person_ID, dbo.SalHoghogh.SalHoghoghStartDate, dbo.SalHoghogh.SalHoghoghEndDate, dbo.SalHoghogh.ActivityCenterCode, 
        //                         dbo.WorkLoaction.WorkLoactionCode
        //FROM            dbo.SalKasrDastor INNER JOIN
        //                         dbo.SalHoghogh INNER JOIN
        //                         dbo.SalHoghoghBaseInfoKind ON dbo.SalHoghogh.SalHoghoghBasiInfoKind = dbo.SalHoghoghBaseInfoKind.ID ON dbo.SalKasrDastor.SalKasrDastorrID = dbo.SalHoghogh.SalHoghoghBasiInfoID INNER JOIN
        //                         dbo.SalBaseInfo ON dbo.SalKasrDastor.SalBaseInfoKasrDastorTitle = dbo.SalBaseInfo.PuBaseInfoCode INNER JOIN
        //                         dbo.ActivityCenter ON dbo.SalHoghogh.ActivityCenterCode = dbo.ActivityCenter.ActivityCenterCode INNER JOIN
        //                         dbo.WorkLoaction ON dbo.ActivityCenter.WorkLoactionCode = dbo.WorkLoaction.WorkLoactionCode
        //WHERE        (dbo.SalHoghogh.SalHoghoghBasiInfoKind = 5) AND (dbo.SalBaseInfo.PuBaseInfoTypeCode = 1) AND (dbo.SalBaseInfo.PuBaseInfoTypeValue = 2) AND (dbo.SalHoghogh.SalHoghoghStartDate >= '{0}') 
        //                         AND (dbo.SalHoghogh.SalHoghoghEndDate <= '{1}') AND (dbo.SalHoghogh.ActivityCenterCode = dbo.ActivityCenter.ActivityCenterCode) AND 
        //                         (dbo.WorkLoaction.WorkLoactionCode = dbo.ActivityCenter.WorkLoactionCode)
        //union ALL
        //SELECT        dbo.SalHoghogh.SalHoghoghBasiInfoKind, dbo.SalBaseInfo.PuBaseInfoCode, dbo.SalHoghoghBaseInfoKind.Title AS SalHoghoghBaseInfoKindTitle, dbo.SalBaseInfo.PuBaseInfoText, 
        //                         dbo.SalHoghogh.SalHoghoghPrice, dbo.SalHoghogh.Person_ID, dbo.SalHoghogh.SalHoghoghStartDate, dbo.SalHoghogh.SalHoghoghEndDate, dbo.SalHoghogh.ActivityCenterCode, 
        //                         dbo.WorkLoaction.WorkLoactionCode
        //FROM            dbo.SalHoghogh INNER JOIN
        //                         dbo.SalHoghoghBaseInfoKind ON dbo.SalHoghogh.SalHoghoghBasiInfoKind = dbo.SalHoghoghBaseInfoKind.ID INNER JOIN
        //                         dbo.SalMosaede ON dbo.SalHoghogh.SalHoghoghBasiInfoID = dbo.SalMosaede.SalMosaedeID INNER JOIN
        //                         dbo.SalBaseInfo ON dbo.SalMosaede.SalMosaedeTitle = dbo.SalBaseInfo.PuBaseInfoCode INNER JOIN
        //                         dbo.ActivityCenter ON dbo.SalHoghogh.ActivityCenterCode = dbo.ActivityCenter.ActivityCenterCode INNER JOIN
        //                         dbo.WorkLoaction ON dbo.ActivityCenter.WorkLoactionCode = dbo.WorkLoaction.WorkLoactionCode
        //WHERE        (dbo.SalHoghogh.SalHoghoghBasiInfoKind = 6) AND (dbo.SalBaseInfo.PuBaseInfoTypeCode = 3) AND (dbo.SalBaseInfo.PuBaseInfoTypeValue = 1) AND (dbo.SalHoghogh.SalHoghoghStartDate >= '{0}') 
        //                         AND (dbo.SalHoghogh.SalHoghoghEndDate <= '{1}') AND (dbo.SalHoghogh.ActivityCenterCode = dbo.ActivityCenter.ActivityCenterCode) AND 
        //                         (dbo.WorkLoaction.WorkLoactionCode = dbo.ActivityCenter.WorkLoactionCode)
        //union all
        //select SalHoghoghBasiInfoKind,SalVam.SalVamID, SalHoghoghBaseInfoKind.Title as SalHoghoghBaseInfoKindTitle,SalVam.SalVamTitle,SalHoghogh.SalHoghoghPrice
        // ,SalHoghogh.Person_ID, SalHoghoghStartDate, SalHoghoghEndDate,SalHoghogh.ActivityCenterCode ,dbo.WorkLoaction.WorkLoactionCode  from SalHoghogh,SalVam,SalHoghoghBaseInfoKind,ActivityCenter,WorkLoaction
        // where SalHoghogh.SalHoghoghBasiInfoID=SalVam.SalVamID
        // and SalHoghoghBaseInfoKind.ID=SalHoghogh.SalHoghoghBasiInfoKind  
        // and SalHoghoghBasiInfoKind=7   and SalHoghogh.SalHoghoghStartDate>='{0}' and SalHoghogh.SalHoghoghEndDate<='{1}'  and SalHoghogh.ActivityCenterCode=ActivityCenter.ActivityCenterCode and WorkLoaction.WorkLoactionCode=ActivityCenter.WorkLoactionCode
        // union all
        // select 8 as SalHoghoghBasiInfoKind,SalBimeh.SalBimehID,N'کسورات سهم کارگر بیمه' as Title,SalBimeh.SalBimehInsCompName,SalBimehMah.SalBimehMahSahmeBimeKargar,
        // SalBimehMah.SalBimehMahPersonID, SalBimehMahStartDate, SalBimehMahEndDate,SalBimehMah.ActivityCenterCode as ActivityCenterCode,WorkLoaction.WorkLoactionCode   from SalBimehMah,SalBimeh,dbo.ActivityCenter, dbo.WorkLoaction
        // where SalBimeh.SalBimehID=SalBimehMahBimehID   and SalBimehMah.SalBimehMahStartDate>='{0}' and SalBimehMah.SalBimehMahEndDate<='{1}' and SalBimehMah.ActivityCenterCode=ActivityCenter.ActivityCenterCode and WorkLoaction.WorkLoactionCode=ActivityCenter.WorkLoactionCode
        // union all
        //  select 8 as SalHoghoghBasiInfoKind,-1,N'کسورات سهم کارگر مالیات' as Title,N'مالیات',SalMaliat.SalMaliatMaliat,
        // SalMaliat.SalMaliatPersonID,SalMaliatStartDate,SalMaliatEndDate,SalMaliat.ActivityCenterCode as ActivityCenterCode,WorkLoaction.WorkLoactionCode  from SalMaliat ,ActivityCenter,WorkLoaction
        // where     SalMaliat.SalMaliatStartDate>='{0}' and SalMaliat.SalMaliatEndDate<='{1}'  and SalMaliat.ActivityCenterCode=ActivityCenter.ActivityCenterCode and WorkLoaction.WorkLoactionCode=ActivityCenter.WorkLoactionCode
        // union  
        //  select 9 as SalHoghoghBasiInfoKind,SalBimeh.SalBimehID,N'کسورات سهم کارفرما بیمه' as Title,SalBimeh.SalBimehInsCompName,SalBimehMah.SalBimehMahSahmeBimeKarfarma+isnull(SalBimehMah.SalBimehMahBimeBikari,0),
        // SalBimehMah.SalBimehMahPersonID,SalBimehMahStartDate,SalBimehMahEndDate, SalBimehMah.ActivityCenterCode as ActivityCenterCode,WorkLoaction.WorkLoactionCode from SalBimehMah,SalBimeh,dbo.ActivityCenter, dbo.WorkLoaction
        // where SalBimeh.SalBimehID=SalBimehMahBimehID    and SalBimehMah.SalBimehMahStartDate>='{0}' and SalBimehMah.SalBimehMahEndDate<='{1}'  and SalBimehMah.ActivityCenterCode=ActivityCenter.ActivityCenterCode and WorkLoaction.WorkLoactionCode=ActivityCenter.WorkLoactionCode
        //union all
        //  select 9 as SalHoghoghBasiInfoKind,-2,N'کسورات سهم کارفرما عیدی' as Title,N'عیدی',SalZakhireEydiMah.SalZakhireEydiMahPrice,
        // SalZakhireEydiMah.PersonID,SalZakhireEydiMahStartDate,SalZakhireEydiMahEndDate,SalZakhireEydiMah.ActivityCenterCode as ActivityCenterCode,WorkLoaction.WorkLoactionCode as WorkLoactionCode  from SalZakhireEydiMah ,ActivityCenter,WorkLoaction
        // where  SalZakhireEydiMah.SalZakhireEydiMahStartDate>='{0}' and SalZakhireEydiMah.SalZakhireEydiMahEndDate<='{1}'  and SalZakhireEydiMah.ActivityCenterCode=ActivityCenter.ActivityCenterCode and WorkLoaction.WorkLoactionCode=ActivityCenter.WorkLoactionCode
        // union all
        //  select 9 as SalHoghoghBasiInfoKind,-3,N'کسورات سهم کارفرما سنوات' as Title,N'سنوات',[SalMonthSanavat].Price,
        // [SalMonthSanavat].SalMonthSanavatPID,[SalMonthSanavat].SalMonthSanavatFromDate,[SalMonthSanavat].SalMonthSanavatToDate,[SalMonthSanavat].activitycentercode as ActivityCenterCode,WorkLoaction.WorkLoactionCode  from [SalMonthSanavat] ,dbo.ActivityCenter, dbo.WorkLoaction
        // where  [SalMonthSanavat].SalMonthSanavatFromDate>='{0}' and [SalMonthSanavat].SalMonthSanavatToDate<='{1}'    and [SalMonthSanavat].ActivityCenterCode=ActivityCenter.ActivityCenterCode and WorkLoaction.WorkLoactionCode=ActivityCenter.WorkLoactionCode
        //", startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd")));

        //        }
        //        public static DataTable GetAllByMaxHkm()
        //        {
        //            return repository.GetAllDataTable(@"select * from StatementPersonalDtl,
        //                        (select max(hkmCode) as hkmCode,pid from StatementPersonal where TypeHkmCode!=2 group by pid) as t1
        //                        where t1.hkmcode=StatementPersonalDtl.HkmCode");
        //        }
        //        public static DataTable RetTitleViewType()
        //        {
        //            return repository.GetAllDataTable(@"select distinct FormulType, MonthValueType,ID,EnName,FaName,ValueType  from viewMonthValue order by FaName");
        //        }

        //        #endregion
    }
}
