﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Services
{
  public class LocalServiceProvider : ILocalWheatherServiceProvider
  {

    public LocalServiceProvider(IFaceBookConnectionManager mn)
    {
      ;
    }

    public string GetWheatherByZip(string code)
    {
      return "wheather is  " + code;
    }
  }

  
}