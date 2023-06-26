using DigitalTwinMiddleware.DigitalTwin.Components;
using DigitalTwinMiddleware.DTOs.Enums;
using DigitalTwinMiddleware.Entities;
using DigitalTwinMiddleware.Extensions;
using System.ComponentModel.DataAnnotations;

namespace DigitalTwinMiddleware.DigitalTwin
{
    public class IOTDeviceTwin
    {
        public List<Telemetry> Telemetries { get; set; }

        public IOTDeviceTwin(List<Telemetry> telemetries)
        {
            Telemetries = telemetries;
        }

        public List<TelemetryReport> Principal()
        {
            var ultraSonicDistanceOffset = .5;
            var tempOffset = .5;
            var humOffset = .5;
            List<TelemetryReport> allReports = new();
            //twinReports.Reports = new List<TwinReport>();

            foreach (var telemetry in Telemetries)
            {
                TelemetryReport twinReports = new();
                twinReports.Timestamp = telemetry.TimeStamp;
                //DHTSensor
                if (telemetry.DHT11Sensor != null)
                {
                    var twinReport = new TwinReport();
                    twinReport.Reactions = new List<ReactTwinReport>();
                    twinReport.DeviceName = "DHT11Sensor";
                    DHT11SensorTwin dHT11SensorTwin = new(telemetry.DHT11Sensor.Temperature - tempOffset, telemetry.DHT11Sensor.Temperature + tempOffset,
                        telemetry.DHT11Sensor.Humidity - humOffset, telemetry.DHT11Sensor.Humidity + humOffset);

                    twinReport.DeviceStatus = dHT11SensorTwin.StatusCheck(telemetry.DHT11Sensor.Temperature, telemetry.DHT11Sensor.Humidity).ToString();
                     if(telemetry.DHT11Sensor.IOTDevice != null) 
                     {
                        telemetry.DHT11Sensor.IOTDevice.DeviceRelationships = telemetry.IOTDevice.DeviceRelationships.Where(c => c.DeviceOneId == telemetry.DHT11Sensor.IOTDeviceId).ToList();
                        if (telemetry.DHT11Sensor.IOTDevice.DeviceRelationships.Count > 0)
                        {
                            foreach (var _relationship in telemetry.DHT11Sensor.IOTDevice.DeviceRelationships)
                            {
                                var twinReactDevices = new ReactTwinReport();
                                var errors = new List<string>();
                                var conditionTemp = _relationship.DeviceOneCondition.GetValue("Temperature");
                                var conditionHum = _relationship.DeviceOneCondition.GetValue("Humidity");
                                if (DeviceRelationship.CheckRelationship(conditionTemp.Condition, dHT11SensorTwin.Temperature, double.Parse(conditionTemp.Value)))
                                {
                                    twinReactDevices = GetReportData(_relationship, errors, telemetry, twinReactDevices);
                                }

                                if (DeviceRelationship.CheckRelationship(conditionHum.Condition, dHT11SensorTwin.Humidity, double.Parse(conditionHum.Value)))
                                {
                                    twinReactDevices = GetReportData(_relationship, errors, telemetry, twinReactDevices);
                                }


                                twinReactDevices.Errors = errors;
                                twinReport.Reactions.Add(twinReactDevices);
                            }
                        }
                     }
                    twinReports.DHT11SensorData = twinReport;
                }

                //UltrasonicSensor
                if (telemetry.UltrasonicSensor != null)
                {
                    var twinReport = new TwinReport();
                    twinReport.Reactions = new List<ReactTwinReport>();
                    twinReport.DeviceName = "UltrasonicSensor";
                    UltrasonicSensorTwin ultrasonicSensorTwin = new(telemetry.UltrasonicSensor.Distance - ultraSonicDistanceOffset, 
                        telemetry.UltrasonicSensor.Distance + ultraSonicDistanceOffset, 
                        telemetry.UltrasonicSensor.Duration);

                    twinReport.DeviceStatus = ultrasonicSensorTwin.StatusCheck().ToString();
                    if (telemetry.UltrasonicSensor.IOTDevice != null)
                    {
                        telemetry.UltrasonicSensor.IOTDevice.DeviceRelationships = telemetry.IOTDevice.DeviceRelationships.Where(c => c.DeviceOneId == telemetry.UltrasonicSensor.IOTDeviceId).ToList();
                        if (telemetry.UltrasonicSensor.IOTDevice.DeviceRelationships.Count > 0)
                        {
                            foreach (var _relationship in telemetry.UltrasonicSensor.IOTDevice.DeviceRelationships)
                            {
                                var twinReactDevices = new ReactTwinReport();
                                var errors = new List<string>();
                                var conditionMinD = _relationship.DeviceOneCondition.GetValue("MinDistance");
                                var conditionMaxD = _relationship.DeviceOneCondition.GetValue("MaxDIstance");
                                if (DeviceRelationship.CheckRelationship(conditionMinD.Condition, ultrasonicSensorTwin.MinDistance, double.Parse(conditionMinD.Value)))
                                {
                                    twinReactDevices = GetReportData(_relationship, errors, telemetry, twinReactDevices);
                                }

                                if (DeviceRelationship.CheckRelationship(conditionMaxD.Condition, ultrasonicSensorTwin.MaxDistance, double.Parse(conditionMaxD.Value)))
                                {
                                    twinReactDevices = GetReportData(_relationship, errors, telemetry, twinReactDevices);
                                }

                                twinReactDevices.Errors = errors;
                                twinReport.Reactions.Add(twinReactDevices);
                            }
                        }
                    }
                    twinReports.UltrasonicSensorData = twinReport;
                }

                //MotionSensor
                if (telemetry.MotionSensor != null)
                {
                    var twinReport = new TwinReport();
                    twinReport.Reactions = new List<ReactTwinReport>();
                    twinReport.DeviceName = "MotionSensor";
                    MotionSensorTwin motionSensorTwin = new(telemetry.MotionSensor.MotionDetected);

                    twinReport.DeviceStatus = motionSensorTwin.StatusCheck().ToString();
                    if (telemetry.MotionSensor.IOTDevice != null)
                    {
                        telemetry.MotionSensor.IOTDevice.DeviceRelationships = telemetry.IOTDevice.DeviceRelationships.Where(c => c.DeviceOneId == telemetry.MotionSensor.IOTDeviceId).ToList();
                        if (telemetry.MotionSensor.IOTDevice.DeviceRelationships.Count > 0)
                        {
                            foreach (var _relationship in telemetry.MotionSensor.IOTDevice.DeviceRelationships)
                            {
                                var twinReactDevices = new ReactTwinReport();
                                var errors = new List<string>();

                                var condition = _relationship.DeviceOneCondition.GetValue("MotionDetected");
                                if (condition.Condition == Condition.EqualTo && motionSensorTwin.MotionDetected == bool.Parse(condition.Value))
                                {
                                    twinReactDevices = GetReportData(_relationship, errors, telemetry, twinReactDevices);
                                }

                                twinReactDevices.Errors = errors;
                                twinReport.Reactions.Add(twinReactDevices);
                            }
                        }
                    }
                    twinReports.MotionSensorData = twinReport;
                }

                //CameraSensor
                if (telemetry.CameraSensor != null)
                {
                    var twinReport = new TwinReport();
                    twinReport.Reactions = new List<ReactTwinReport>();
                    twinReport.DeviceName = "CameraSensor";
                    var isPoweredOn = telemetry.CameraSensor.DeviceStatus?.PowerStatus == PowerStatus.On;
                    CameraSensorTwin cameraSensorTwin = new(isPoweredOn, telemetry.CameraSensor.Data);

                    twinReport.DeviceStatus = cameraSensorTwin.StatusCheck().ToString();
                    twinReports.CameraSensor = twinReport;
                }

                //GPSModuleSensor
                if (telemetry.GPSModule != null)
                {
                    var twinReport = new TwinReport();
                    twinReport.DeviceName = "GPSModule";
                    GPSModuleTwin gpsModuleTwin = new(telemetry.GPSModule.Longitude,
                        telemetry.GPSModule.Latitude);

                    twinReport.DeviceStatus = gpsModuleTwin.StatusCheck().ToString();
                    twinReports.GPSData = twinReport;
                }

                //LedSensor
                if (telemetry.LedSensor != null)
                {
                    var twinReport = new TwinReport();
                    twinReport.Reactions = new List<ReactTwinReport>();
                    twinReport.DeviceName = "LedSensor";
                    LedSensorTwin ledSensorTwin = new(telemetry.LedSensor.IsOn);
                    if (telemetry.LedSensor.IOTDevice != null)
                    {
                        telemetry.LedSensor.IOTDevice.DeviceRelationships = telemetry.IOTDevice.DeviceRelationships.Where(c => c.DeviceOneId == telemetry.LedSensor.IOTDeviceId).ToList();
                        twinReport.DeviceStatus = ledSensorTwin.StatusCheck().ToString();
                        if (telemetry.LedSensor.IOTDevice.DeviceRelationships.Count > 0)
                        {
                            foreach (var _relationship in telemetry.LedSensor.IOTDevice.DeviceRelationships)
                            {
                                var twinReactDevices = new ReactTwinReport();
                                var errors = new List<string>();
                                var condition = _relationship.DeviceOneCondition.GetValue("IsOn");
                                if (condition.Condition == Condition.EqualTo && ledSensorTwin.IsOn == bool.Parse(condition.Value))
                                {
                                    twinReactDevices = GetReportData(_relationship, errors, telemetry, twinReactDevices);
                                }
                                twinReactDevices.Errors = errors;
                                twinReport.Reactions.Add(twinReactDevices);
                            }
                        }
                    }
                    twinReports.LedSensorData = twinReport;
                }

                //LightSensor
                if (telemetry.LightSensor != null)
                {
                    var twinReport = new TwinReport();
                    twinReport.Reactions = new List<ReactTwinReport>();
                    twinReport.DeviceName = "LightSensor";
                    LightSensorTwin lightSensorTwin = new(telemetry.LightSensor.Value);
                    if (telemetry.LightSensor.IOTDevice != null)
                    {
                        telemetry.LightSensor.IOTDevice.DeviceRelationships = telemetry.IOTDevice.DeviceRelationships.Where(c => c.DeviceOneId == telemetry.LightSensor.IOTDeviceId).ToList();
                        twinReport.DeviceStatus = lightSensorTwin.StatusCheck().ToString();
                        if (telemetry.LightSensor.IOTDevice.DeviceRelationships.Count > 0)
                        {
                            foreach (var _relationship in telemetry.LightSensor.IOTDevice.DeviceRelationships)
                            {
                                var twinReactDevices = new ReactTwinReport();
                                var errors = new List<string>();
                                var condition = _relationship.DeviceOneCondition.GetValue("Value");

                                if (condition.Condition == Condition.EqualTo && lightSensorTwin.Value == bool.Parse(condition.Value))
                                {
                                    twinReactDevices = GetReportData(_relationship, errors, telemetry, twinReactDevices);
                                }

                                twinReactDevices.Errors = errors;
                                twinReport.Reactions.Add(twinReactDevices);
                            }
                        }
                    }
                    twinReports.LightSensorData = twinReport;
                }

                allReports.Add(twinReports);
            }

            return allReports;
        }

        public static ReactTwinReport GetReportData(DeviceRelationship _relationship, List<string> errors, Telemetry telemetry, ReactTwinReport twinReactDevices)
        {

            var ultraSonicDistanceOffset = .5;
            var tempOffset = .5;
            var humOffset = .5;

            var deviceType = _relationship.DeviceTwo.IOTSensorType;
            if (deviceType != null)
            {
                var _deviceIIClass = telemetry.GetClassBySensor(deviceType.Value);
                switch (_deviceIIClass)
                {
                    case "DHT11Sensor":
                        twinReactDevices.DeviceName = "DHT11Sensor";
                        DHT11SensorTwin _dhttemp = new(telemetry.DHT11Sensor.Temperature - tempOffset, telemetry.DHT11Sensor.Temperature + tempOffset,
                                                        telemetry.DHT11Sensor.Humidity - humOffset, telemetry.DHT11Sensor.Humidity + humOffset);

                        //null check
                        var _conditionTwoTemp = _relationship.DeviceTwoReaction.GetValue("Temperature");
                        var _conditionTwoHum = _relationship.DeviceTwoReaction.GetValue("Humidity");
                        var tempResult = DeviceRelationship.CheckRelationship(_conditionTwoTemp.Condition, _dhttemp.Temperature, double.Parse(_conditionTwoTemp.Value));
                        var humResult = DeviceRelationship.CheckRelationship(_conditionTwoHum.Condition, _dhttemp.Humidity, double.Parse(_conditionTwoHum.Value));
                        if (tempResult && humResult)
                        {
                            twinReactDevices.WorkingProperly = true;
                        }
                        else
                        {
                            twinReactDevices.WorkingProperly = false;
                            errors.Add($"The temperature value of {_dhttemp.Temperature} seems off");
                            errors.Add($"The humidity value of {_dhttemp.Humidity} seems off");
                        }
                        break;

                    case "UltrasonicSensor":
                        twinReactDevices.DeviceName = "UltrasonicSensor";
                        UltrasonicSensorTwin _ultratemp = new(telemetry.UltrasonicSensor.Distance - ultraSonicDistanceOffset,
                                                                telemetry.UltrasonicSensor.Distance + ultraSonicDistanceOffset,
                                                                telemetry.UltrasonicSensor.Duration);

                        //null check
                        var _conditionTwoMaxD = _relationship.DeviceTwoReaction.GetValue("MaxDistance");
                        var _conditionTwoMinD = _relationship.DeviceTwoReaction.GetValue("MinDistance");
                        var maxDResult = DeviceRelationship.CheckRelationship(_conditionTwoMaxD.Condition, _ultratemp.MaxDistance, double.Parse(_conditionTwoMaxD.Value));
                        var minDResult = DeviceRelationship.CheckRelationship(_conditionTwoMinD.Condition, _ultratemp.MinDistance, double.Parse(_conditionTwoMinD.Value));
                        if (maxDResult && minDResult)
                        {
                            twinReactDevices.WorkingProperly = true;
                        }
                        else
                        {
                            twinReactDevices.WorkingProperly = false;
                            errors.Add($"The possible values of ultrasonic sensor seems off with distance of {telemetry.UltrasonicSensor.Distance}");
                        }
                        break;

                    case "MotionSensor":
                        twinReactDevices.DeviceName = "MotionSensor";
                        MotionSensorTwin _motionSensor = new(telemetry.MotionSensor.MotionDetected);

                        //null check
                        var _conditionTwoM = _relationship.DeviceTwoReaction.GetValue("MotionDetected");
                        var mResult = DeviceRelationship.CheckRelationship(_conditionTwoM.Condition, _motionSensor.MotionDetected.Value, bool.Parse(_conditionTwoM.Value));
                        if (mResult)
                        {
                            twinReactDevices.WorkingProperly = true;
                        }
                        else
                        {
                            twinReactDevices.WorkingProperly = false;
                            errors.Add($"Motion Sensor values inaccurate");
                        }
                        break;

                    case "LedSensor":
                        twinReactDevices.DeviceName = "LedSensor";
                        LedSensorTwin _ledSensor = new(telemetry.LedSensor.IsOn);

                        //null check
                        var _conditionTwoL = _relationship.DeviceTwoReaction.GetValue("IsOn");
                        var lResult = DeviceRelationship.CheckRelationship(_conditionTwoL.Condition, _ledSensor.IsOn.Value, bool.Parse(_conditionTwoL.Value));
                        if (lResult)
                        {
                            twinReactDevices.WorkingProperly = true;
                        }
                        else
                        {
                            twinReactDevices.WorkingProperly = false;
                            errors.Add($"Led Sensor values inaccurate");
                        }
                        break;
                    case "LightSensor":
                        twinReactDevices.DeviceName = "LightSensor";
                        LightSensorTwin _lightSensor = new(telemetry.LightSensor.Value);

                        //null check
                        var _conditionTwoLight = _relationship.DeviceTwoReaction.GetValue("Value");
                        var lightResult = DeviceRelationship.CheckRelationship(_conditionTwoLight.Condition, _lightSensor.Value.Value, bool.Parse(_conditionTwoLight.Value));
                        if (lightResult)
                        {
                            twinReactDevices.WorkingProperly = true;
                        }
                        else
                        {
                            twinReactDevices.WorkingProperly = false;
                            errors.Add($"Light Sensor values inaccurate");
                        }
                        break;
                }

            }

            return twinReactDevices;
        }
    }
}
