﻿using GFX.Core;
using ParkingSpace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSpace.Services {
  public class SettingService : ServiceBase<App, Setting> {
    public override IRepository<Setting> Repository {
      get; set;
    }

    public override Setting Find(params object[] keys) {
      int id = (int)keys[0];
      return Query(item => item.Id == id).SingleOrDefault();
    }

    public Setting Current {
      get {
        var setting = All().FirstOrDefault();

        if (setting == null) {
          setting = new Setting();
          Add(setting);
          SaveChanges();
        }

        return setting;
      }
    }
  }
}
