using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDJAPIApplication.vo
{
    public class MissileVO
    {
        public MissileVO()
        {
            thermalradiation = new List<double>();
            airblast = new List<double>();
            nuclearradiation = new List<double>();
            nuclearpulse = new List<double>();
            fallout = new List<double>();
        }

        /// <summary>
        /// 型号。
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 探测手段。
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        /// 部队。
        /// </summary>
        public string Troop { get; set; }
        /// <summary>
        /// 飞行时长。
        /// </summary>
        public double FlightTime{get;set;}
        /// <summary>
        /// 信息来源。
        /// </summary>
        public string Base { get; set; }
        /// <summary>
        /// 当前经度。
        /// </summary>
        public double FlightLon { get; set; }
        /// <summary>
        /// 当前纬度。
        /// </summary>
        public double FlightLat { get; set; }
        /// <summary>
        /// 当前高程。
        /// </summary>
        public double FlightAlt { get; set; }
        /// <summary>
        /// 落点经度。
        /// </summary>
        public double LaunchLon { get; set; }
        /// <summary>
        /// 落点纬度。
        /// </summary>
        public double LaunchLat { get; set; }
        /// <summary>
        /// 发射时间。
        /// </summary>
        public double LaunchTime { get; set; }
        // <summary>
        /// 探测时间。
        /// </summary>
        public double ProbeTime { get; set; }
        public List<double> thermalradiation { get; set; }
        public List<double> airblast { get; set; }
        public List<double> nuclearradiation { get; set; }
        public List<double> nuclearpulse { get; set; }
        public List<double> fallout { get; set; }


    }
}
