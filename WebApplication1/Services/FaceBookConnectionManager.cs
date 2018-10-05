using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Services
{
  public class FaceBookConnectionManager : IFaceBookConnectionManager
  {

    public string _userName;

    public string _token;

    public string _connection;
    public FaceBookConnectionManager(string userName, string token, string connection)
    {
      _userName = userName;
      _token = token;

      _connection = connection;
    }

    public bool AuthorizeUser()
    {
      return ("" + _userName != "") && ("" + _token != "") && ("" + _connection != "");
    }
  }
}