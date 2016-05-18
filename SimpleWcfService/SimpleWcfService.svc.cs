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
        TimeZoneInfo tzi = null;

        if(string.IsNullOrWhiteSpace(timezoneName)) {
            tz = TimeZone.CurrentTimeZone;
            rv.TheTime = tz.ToLocalTime(DateTime.Now);
            tzi = TimeZoneInfo.FindSystemTimeZoneById(tz.StandardName);
            rv.TimezoneName = tzi.StandardName;
            rv.TimezoneGmtOffset = (int)tzi.BaseUtcOffset.TotalMinutes;
        } else {
            try {
                tzi = TimeZoneInfo.FindSystemTimeZoneById(timezoneName);
                rv.TheTime = DateTime.UtcNow.AddMinutes(tzi.GetUtcOffset(DateTime.UtcNow).TotalMinutes);
                rv.TimezoneName = tzi.StandardName;
                rv.TimezoneGmtOffset = (int)tzi.BaseUtcOffset.TotalMinutes;
            } catch (TimeZoneNotFoundException) {
                tz = TimeZone.CurrentTimeZone;
                rv.TheTime = tz.ToLocalTime(DateTime.Now);
                tzi = TimeZoneInfo.FindSystemTimeZoneById(tz.StandardName);
                rv.TimezoneName = tzi.StandardName;
                rv.TimezoneGmtOffset = (int)tzi.BaseUtcOffset.TotalMinutes;
            }
        } // if

        return rv;
    }
}
}
