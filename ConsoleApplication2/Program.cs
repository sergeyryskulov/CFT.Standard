using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CamlexNET.Interfaces;
using System.Xml.Linq;

namespace ConsoleApplication2
{
  public class MyIQuery : CamlexNET.Interfaces.IQuery
  {
    IQuery camlQuery;

    public IQuery GroupBy(Expression<Func<ListItem, object>> expr)
    {
      throw new NotImplementedException();
    }

    public IQuery GroupBy(string existingGroupBy, Expression<Func<ListItem, object[]>> expr)
    {
      throw new NotImplementedException();
    }

    public IQuery GroupBy(string existingGroupBy, Expression<Func<ListItem, object>> expr)
    {
      throw new NotImplementedException();
    }

    public IQuery GroupBy(Expression<Func<ListItem, object>> expr, bool? collapse)
    {
      throw new NotImplementedException();
    }

    public IQuery GroupBy(Expression<Func<ListItem, object>> expr, int? groupLimit)
    {
      throw new NotImplementedException();
    }

    public IQuery GroupBy(Expression<Func<ListItem, object>> expr, bool? collapse, int? groupLimit)
    {
      throw new NotImplementedException();
    }

    public IQuery GroupBy(Expression<Func<ListItem, object[]>> expr, bool? collapse, int? groupLimit)
    {
      throw new NotImplementedException();
    }

    public IQuery InnerJoin(Expression<Func<ListItem, object>> expr)
    {
      throw new NotImplementedException();
    }

    public IQuery LeftJoin(Expression<Func<ListItem, object>> expr)
    {
      throw new NotImplementedException();
    }

    public IQuery OrderBy(IEnumerable<Expression<Func<ListItem, object>>> expressions)
    {
      throw new NotImplementedException();
    }

    public IQuery OrderBy(Expression<Func<ListItem, object[]>> expr)
    {
      throw new NotImplementedException();
    }

    public IQuery OrderBy(Expression<Func<ListItem, object>> expr)
    {
      throw new NotImplementedException();
    }

    public IQuery OrderBy(string existingOrderBy, Expression<Func<ListItem, object[]>> expr)
    {
      throw new NotImplementedException();
    }

    public IQuery OrderBy(string existingOrderBy, IEnumerable<Expression<Func<ListItem, object>>> expressions)
    {
      throw new NotImplementedException();
    }

    public IQuery OrderBy(string existingOrderBy, Expression<Func<ListItem, object>> expr)
    {
      throw new NotImplementedException();
    }

    public IQuery ProjectedField(Expression<Func<ListItem, object>> expr)
    {
      throw new NotImplementedException();
    }

    public IQuery Scope(ViewScope scope)
    {
      throw new NotImplementedException();
    }

    public IQuery Take(int count)
    {
      throw new NotImplementedException();
    }

    public XElement[] ToCaml(bool includeViewTag)
    {
      throw new NotImplementedException();
    }

    public CamlQuery ToCamlQuery()
    {
      throw new NotImplementedException();
    }

    public string ToString(bool includeViewTag)
    {
      throw new NotImplementedException();
    }

    public IQuery ViewFields(IEnumerable<string> titles)
    {
      throw new NotImplementedException();
    }

    public IQuery ViewFields(Expression<Func<ListItem, object[]>> expr)
    {
      throw new NotImplementedException();
    }

    public IQuery ViewFields(Expression<Func<ListItem, object>> expr)
    {
      throw new NotImplementedException();
    }

    public IQuery ViewFields(string existingViewFields, Expression<Func<ListItem, object[]>> expr)
    {
      throw new NotImplementedException();
    }

    public IQuery ViewFields(string existingViewFields, IEnumerable<string> titles)
    {
      throw new NotImplementedException();
    }

    public IQuery ViewFields(string existingViewFields, Expression<Func<ListItem, object>> expr)
    {
      throw new NotImplementedException();
    }

    public IQuery Where(Expression<Func<ListItem, bool>> expr)
    {
      throw new NotImplementedException();
    }

    public IQuery WhereAll(IEnumerable<string> expressions)
    {
      throw new NotImplementedException();
    }

    public IQuery WhereAll(IEnumerable<Expression<Func<ListItem, bool>>> expressions)
    {
      throw new NotImplementedException();
    }

    public IQuery WhereAll(string existingWhere, IEnumerable<Expression<Func<ListItem, bool>>> expressions)
    {
      throw new NotImplementedException();
    }

    public IQuery WhereAll(string existingWhere, Expression<Func<ListItem, bool>> expression)
    {
      throw new NotImplementedException();
    }

    public IQuery WhereAny(IEnumerable<string> expression)
    {
      throw new NotImplementedException();
    }

    public IQuery WhereAny(IEnumerable<Expression<Func<ListItem, bool>>> expressions)
    {
      throw new NotImplementedException();
    }

    public IQuery WhereAny(string existingWhere, IEnumerable<Expression<Func<ListItem, bool>>> expressions)
    {
      throw new NotImplementedException();
    }

    public IQuery WhereAny(string existingWhere, Expression<Func<ListItem, bool>> expression)
    {
      throw new NotImplementedException();
    }
  }




  class Program
  {
    static void Main(string[] args)
    {
      

      //Expression<Func<ListItem, bool>> expr = (m => (int)m["ww"] == 1);

      //string s = expr.ToString();
      //Console.Write(s);
      using (ClientContext ctx = new ClientContext("http://uuu.yu"))
      {
        ListItem a=ctx.Web.GetList("").AddItem(new ListItemCreationInformation());
        a["ww"] = 1;
        var query= CamlexNET.Camlex.Query().Where((m => (int)m["ww"] == 1 &&(DateTime)  m["Created"] > DateTime.Now));

         var t="" + CamlexNET.Camlex.QueryFromString(query.ToString(true)).ToExpression();

        Console.Write(t);
        
      }
      

     
    }
  }
}
