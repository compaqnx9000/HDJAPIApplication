using HDJAPIApplication.vo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;

namespace HDJAPIApplication.Controllers
{
    [ApiController]
    public class ProbeController : ControllerBase
    {
        [HttpGet("missile")]
        public IActionResult Missile()
        {
            MissileVO missileVO = new MissileVO();

            double lng = 116.40;
            double lat = 39.90;
            double yield = 300000;
            double alt = 0;

            // TODO: alt=1000,airblast=3000,=0

            MyCore.MyAnalyse analyse = new MyCore.MyAnalyse();

            missileVO.thermalradiation.Add(analyse.GetThermalRadiationR(yield / 1000, alt * MyCore.Utils.Const.M2FT, 1.9));
            missileVO.thermalradiation.Add(analyse.GetThermalRadiationR(yield / 1000, alt * MyCore.Utils.Const.M2FT, 6.2));
            missileVO.thermalradiation.Add(analyse.GetThermalRadiationR(yield / 1000, alt * MyCore.Utils.Const.M2FT, 11.3));

            missileVO.airblast.Add(analyse.CalcShockWaveRadius(yield / 1000, alt * MyCore.Utils.Const.M2FT, 1));
            missileVO.airblast.Add(analyse.CalcShockWaveRadius(yield / 1000, alt * MyCore.Utils.Const.M2FT, 20));
            missileVO.airblast.Add(analyse.CalcShockWaveRadius(yield / 1000, alt * MyCore.Utils.Const.M2FT, 3000));

            missileVO.nuclearradiation.Add(analyse.CalcNuclearRadiationRadius(yield / 1000, alt * MyCore.Utils.Const.M2FT, 100));
            missileVO.nuclearradiation.Add(analyse.CalcNuclearRadiationRadius(yield / 1000, alt * MyCore.Utils.Const.M2FT, 600));
            missileVO.nuclearradiation.Add(analyse.CalcNuclearRadiationRadius(yield / 1000, alt * MyCore.Utils.Const.M2FT, 5000));

            missileVO.nuclearpulse.Add(analyse.CalcNuclearPulseRadius(yield, alt / 1000, 200.0) * 1000);
            missileVO.nuclearpulse.Add(analyse.CalcNuclearPulseRadius(yield, alt / 1000, 2000.0) * 1000);
            missileVO.nuclearpulse.Add(analyse.CalcNuclearPulseRadius(yield, alt / 1000, 50000.0) * 1000);

            double maximumDownwindDistance = 0;double maximumWidth = 0;
            analyse.CalcRadioactiveFalloutRegion(lng, lat, alt * MyCore.Utils.Const.M2FT, yield / 1000,
                                                 15, 225, MyCore.enums.DamageEnumeration.Light,
                                                ref maximumDownwindDistance, ref maximumWidth);
            missileVO.fallout.Add(maximumDownwindDistance*1000);

            analyse.CalcRadioactiveFalloutRegion(lng, lat, alt * MyCore.Utils.Const.M2FT, yield / 1000,
                                                 15, 225, MyCore.enums.DamageEnumeration.Heavy,
                                                ref maximumDownwindDistance, ref maximumWidth);
            missileVO.fallout.Add(maximumDownwindDistance * 1000);

            analyse.CalcRadioactiveFalloutRegion(lng, lat, alt * MyCore.Utils.Const.M2FT, yield / 1000,
                                                 15, 225, MyCore.enums.DamageEnumeration.Destroy,
                                                ref maximumDownwindDistance, ref maximumWidth);
            missileVO.fallout.Add(maximumDownwindDistance * 1000);

            return new JsonResult(new
            {
                return_status = 0,
                return_msg = "",
                return_data = missileVO
            });
        }
    }
}
