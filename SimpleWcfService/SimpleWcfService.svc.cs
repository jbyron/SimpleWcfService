using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SimpleWcfService {

public class SimpleWcfService : ISimpleWcfService {
    
    public DateTime GetServerDate(string timezoneName) {
        return GetServerDateWithTzInfo(timezoneName).TheTime;
    }

    public TimeWithTimezone GetServerDateWithTzInfo(string timezoneName) {
        TimeWithTimezone rv = new TimeWithTimezone();
        TimeZone tz = null;

        if(string.IsNullOrWhiteSpace(timezoneName)) {
            tz = TimeZone.CurrentTimeZone;
            rv.TheTime = tz.ToLocalTime(DateTime.Now);
            rv.TimezoneDetails = TimeZoneInfo.FindSystemTimeZoneById(tz.StandardName);
        } else {
            try {
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(timezoneName);
                
                rv.TheTime = DateTime.UtcNow.AddMinutes(tzi.GetUtcOffset(DateTime.UtcNow).TotalMinutes);
                rv.TimezoneDetails = tzi;
            } catch (TimeZoneNotFoundException) {
                tz = TimeZone.CurrentTimeZone;
                rv.TheTime = tz.ToLocalTime(DateTime.Now);
                rv.TimezoneDetails = TimeZoneInfo.FindSystemTimeZoneById(tz.StandardName);
            }
        } // if

        return rv;
    }
}
}
