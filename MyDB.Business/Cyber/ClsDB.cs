using MyDB.BusinessLayer.Cyber.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace MyDB.BusinessLayer.Cyber
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

        public static int GetAllByMaxInt(object fieldMax, object fieldName, object value)
        {
            return int.Parse(repository.ExecuteSqlString("select ISNULL(MAX(" + fieldMax + "),0) from " + repository.RetTableName() + " where " + fieldName + "='" + value + "'"));
        }
        public static long GetAllByMax(object fieldMax, object fieldName, object value)
        {
            return long.Parse(repository.ExecuteSqlString("select ISNULL(MAX(" + fieldMax + "),0) from "+repository.RetTableName()+" where " + fieldName + "='"+value+"'"));
        }
        public static int GetAllByMax(object fieldMax)
        {
            return int.Parse(repository.ExecuteSqlString("select ISNULL(MAX(" + fieldMax + "),0) from " + repository.RetTableName() + ""));
        }
        public static List<T> GetAllBy(object fieldName, object value, object fieldName2, object value2, object fieldName3, object value3)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + fieldName + "='" + value + "' " +
                "and " + fieldName2 + " ='" + value2 + "' and " + fieldName3 + " ='" + value3 + "'").ToList();
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

        public static List<T> GetAllByDate(string fieldNameDate, object value)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where CAST(" + fieldNameDate + " as date)='" + value + "'").ToList();
        }

        public static List<T> GetAllByDate(string fieldName, object value, string fieldNameDate, object valueDate)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + fieldName + "='" + value + "' and CAST(" + fieldNameDate + " as date)='" + valueDate + "'").ToList();
        }

        public static List<T> GetAllByDate(string fieldName, object value, string fieldNameDate, object valueDate, string fieldNameDate2, object valueDate2)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + fieldName + "='" + value + "' and CAST(" + fieldNameDate + " as date)>='" + valueDate + "' and " +
                "CAST(" + fieldNameDate2 + " as date)<='" + valueDate2 + "'").ToList();
        }

        public static List<T> GetAllByDate(string fieldName, object value, string fieldNameDate, object valueDate, object valueDate2)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + fieldName + "='" + value + "' and CAST(" + fieldNameDate + " as date)>='" + valueDate + "' and CAST(" + fieldNameDate + " as date)<='" + valueDate2 + "'").ToList();
        }
        public static List<T> GetAllByDate(string fieldName, object value, string fieldName2, object value2, string fieldNameDate, object valueDate, object valueDate2)
        {
            return repository.GetAllQuery("select * from " + repository.RetTableName() + " where " + fieldName + "='" + value + "' and " + fieldName2 + "='" + value2 + "' and CAST(" + fieldNameDate + " as date)>='" + valueDate + "' and CAST(" + fieldNameDate + " as date)<='" + valueDate2 + "'").ToList();
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

      
    }
}
