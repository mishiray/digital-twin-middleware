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

        public string Principal()
        {
            var ultraSonicDistanceOffset = .5;
            var tempOffset = .5;
            var humOffset = .5;

            foreach (var telemetry in Telemetries) {

                //DHTSensor
                if (telemetry.DHT11Sensor != null)
                {
                    DHT11SensorTwin dHT11SensorTwin = new(telemetry.DHT11Sensor.Temperature - tempOffset, telemetry.DHT11Sensor.Temperature + tempOffset,
                        telemetry.DHT11Sensor.Humidity - humOffset, telemetry.DHT11Sensor.Humidity + humOffset);

                    var dHT11Status = dHT11SensorTwin.StatusCheck(telemetry.DHT11Sensor.Temperature, telemetry.DHT11Sensor.Humidity);
                     if(telemetry.DHT11Sensor.IOTDevice != null) 
                    { 
                        if (telemetry.DHT11Sensor.IOTDevice.DeviceRelationships.Count > 0)
                        {
                            foreach (var _relationship in telemetry.DHT11Sensor.IOTDevice.DeviceRelationships)
                            {
                                var conditionTemp = _relationship.DeviceOneCondition.GetValue("Temperature");
                                var conditionHum = _relationship.DeviceOneCondition.GetValue("Humidity");
                                if (DeviceRelationship.CheckRelationship(conditionTemp.Condition, dHT11SensorTwin.Temperature, double.Parse(conditionTemp.Value)))
                                {
                                    var deviceType = _relationship.DeviceTwo.IOTSensorType;
                                    if (deviceType != null)
                                    {
                                        var _deviceIIClass = telemetry.GetClassBySensor(deviceType.Value);
                                        switch (_deviceIIClass)
                                        {
                                            case "DHT11Sensor":
                                                DHT11SensorTwin _dhttemp = new(telemetry.DHT11Sensor.Temperature - tempOffset, telemetry.DHT11Sensor.Temperature + tempOffset,
                                                                                telemetry.DHT11Sensor.Humidity - humOffset, telemetry.DHT11Sensor.Humidity + humOffset);

                                                //null check
                                                var _conditionTwoTemp = _relationship.DeviceTwoReaction.GetValue("Temperature");
                                                var _conditionTwoHum = _relationship.DeviceTwoReaction.GetValue("Humidity");
                                                var tempResult = DeviceRelationship.CheckRelationship(_conditionTwoTemp.Condition, _dhttemp.Temperature, double.Parse(_conditionTwoTemp.Value));
                                                var humResult = DeviceRelationship.CheckRelationship(_conditionTwoHum.Condition, _dhttemp.Temperature, double.Parse(_conditionTwoHum.Value));
                                                break;

                                            case "UltrasonicSensor":
                                                UltrasonicSensorTwin _ultratemp = new(telemetry.UltrasonicSensor.Distance - ultraSonicDistanceOffset,
                                                                                        telemetry.UltrasonicSensor.Distance + ultraSonicDistanceOffset,
                                                                                        telemetry.UltrasonicSensor.Duration);

                                                //null check
                                                var _conditionTwoMaxD = _relationship.DeviceTwoReaction.GetValue("MaxDistance");
                                                var _conditionTwoMinD = _relationship.DeviceTwoReaction.GetValue("MinDistance");
                                                var maxDResult = DeviceRelationship.CheckRelationship(_conditionTwoMaxD.Condition, _ultratemp.MaxDistance, double.Parse(_conditionTwoMaxD.Value));
                                                var minDResult = DeviceRelationship.CheckRelationship(_conditionTwoMinD.Condition, _ultratemp.MinDistance, double.Parse(_conditionTwoMinD.Value));
                                                break;

                                            case "MotionSensor":
                                                MotionSensorTwin _motionSensor = new(telemetry.MotionSensor.MotionDetected);

                                                //null check
                                                var _conditionTwoM = _relationship.DeviceTwoReaction.GetValue("MotionDetected");
                                                var mResult = DeviceRelationship.CheckRelationship(_conditionTwoM.Condition, _motionSensor.MotionDetected.Value, bool.Parse(_conditionTwoM.Value));
                                                break;

                                            case "LedSensor":
                                                LedSensorTwin _ledSensor = new(telemetry.LedSensor.IsOn);

                                                //null check
                                                var _conditionTwoL = _relationship.DeviceTwoReaction.GetValue("IsOn");
                                                var lResult = DeviceRelationship.CheckRelationship(_conditionTwoL.Condition, _ledSensor.IsOn.Value, bool.Parse(_conditionTwoL.Value));
                                                break;
                                        }
                                    }
                                }

                                if (DeviceRelationship.CheckRelationship(conditionHum.Condition, dHT11SensorTwin.Humidity, double.Parse(conditionHum.Value)))
                                {
                                    var deviceType = _relationship.DeviceTwo.IOTSensorType;
                                    if (deviceType != null)
                                    {
                                        var _deviceIIClass = telemetry.GetClassBySensor(deviceType.Value);
                                        switch (_deviceIIClass)
                                        {
                                            case "DHT11Sensor":
                                                DHT11SensorTwin _dhttemp = new(telemetry.DHT11Sensor.Temperature - tempOffset, telemetry.DHT11Sensor.Temperature + tempOffset,
                                                                                telemetry.DHT11Sensor.Humidity - humOffset, telemetry.DHT11Sensor.Humidity + humOffset);

                                                //null check
                                                var _conditionTwoTemp = _relationship.DeviceTwoReaction.GetValue("Temperature");
                                                var _conditionTwoHum = _relationship.DeviceTwoReaction.GetValue("Humidity");
                                                var tempResult = DeviceRelationship.CheckRelationship(_conditionTwoTemp.Condition, _dhttemp.Temperature, double.Parse(_conditionTwoTemp.Value));
                                                var humResult = DeviceRelationship.CheckRelationship(_conditionTwoHum.Condition, _dhttemp.Temperature, double.Parse(_conditionTwoHum.Value));
                                                break;

                                            case "UltrasonicSensor":
                                                UltrasonicSensorTwin _ultratemp = new(telemetry.UltrasonicSensor.Distance - ultraSonicDistanceOffset,
                                                                                        telemetry.UltrasonicSensor.Distance + ultraSonicDistanceOffset,
                                                                                        telemetry.UltrasonicSensor.Duration);

                                                //null check
                                                var _conditionTwoMaxD = _relationship.DeviceTwoReaction.GetValue("MaxDistance");
                                                var _conditionTwoMinD = _relationship.DeviceTwoReaction.GetValue("MinDistance");
                                                var maxDResult = DeviceRelationship.CheckRelationship(_conditionTwoMaxD.Condition, _ultratemp.MaxDistance, double.Parse(_conditionTwoMaxD.Value));
                                                var minDResult = DeviceRelationship.CheckRelationship(_conditionTwoMinD.Condition, _ultratemp.MinDistance, double.Parse(_conditionTwoMinD.Value));
                                                break;

                                            case "MotionSensor":
                                                MotionSensorTwin _motionSensor = new(telemetry.MotionSensor.MotionDetected);

                                                //null check
                                                var _conditionTwoM = _relationship.DeviceTwoReaction.GetValue("MotionDetected");
                                                var mResult = DeviceRelationship.CheckRelationship(_conditionTwoM.Condition, _motionSensor.MotionDetected.Value, bool.Parse(_conditionTwoM.Value));
                                                break;

                                            case "LedSensor":
                                                LedSensorTwin _ledSensor = new(telemetry.LedSensor.IsOn);

                                                //null check
                                                var _conditionTwoL = _relationship.DeviceTwoReaction.GetValue("IsOn");
                                                var lResult = DeviceRelationship.CheckRelationship(_conditionTwoL.Condition, _ledSensor.IsOn.Value, bool.Parse(_conditionTwoL.Value));
                                                break;
                                        }
                                    }
                                }

                            }
                        }
                     }
                }

                //UltrasonicSensor
                if (telemetry.UltrasonicSensor != null)
                {
                    UltrasonicSensorTwin ultrasonicSensorTwin = new(telemetry.UltrasonicSensor.Distance - ultraSonicDistanceOffset, 
                        telemetry.UltrasonicSensor.Distance + ultraSonicDistanceOffset, 
                        telemetry.UltrasonicSensor.Duration);

                    var ultrasonicStatus = ultrasonicSensorTwin.StatusCheck();
                    if (telemetry.UltrasonicSensor.IOTDevice != null)
                    {
                        if (telemetry.UltrasonicSensor.IOTDevice.DeviceRelationships.Count > 0)
                        {
                            foreach (var _relationship in telemetry.UltrasonicSensor.IOTDevice.DeviceRelationships)
                            {
                                var conditionMinD = _relationship.DeviceOneCondition.GetValue("MinDistance");
                                var conditionMaxD = _relationship.DeviceOneCondition.GetValue("MaxDIstance");
                                if (DeviceRelationship.CheckRelationship(conditionMinD.Condition, ultrasonicSensorTwin.MinDistance, double.Parse(conditionMinD.Value)))
                                {
                                    var deviceType = _relationship.DeviceTwo.IOTSensorType;
                                    if (deviceType != null)
                                    {
                                        var _deviceIIClass = telemetry.GetClassBySensor(deviceType.Value);
                                        switch (_deviceIIClass)
                                        {
                                            case "DHT11Sensor":
                                                DHT11SensorTwin _dhttemp = new(telemetry.DHT11Sensor.Temperature - tempOffset, telemetry.DHT11Sensor.Temperature + tempOffset,
                                                                                telemetry.DHT11Sensor.Humidity - humOffset, telemetry.DHT11Sensor.Humidity + humOffset);

                                                //null check
                                                var _conditionTwoTemp = _relationship.DeviceTwoReaction.GetValue("Temperature");
                                                var _conditionTwoHum = _relationship.DeviceTwoReaction.GetValue("Humidity");
                                                var tempResult = DeviceRelationship.CheckRelationship(_conditionTwoTemp.Condition, _dhttemp.Temperature, double.Parse(_conditionTwoTemp.Value));
                                                var humResult = DeviceRelationship.CheckRelationship(_conditionTwoHum.Condition, _dhttemp.Temperature, double.Parse(_conditionTwoHum.Value));
                                                break;

                                            case "UltrasonicSensor":
                                                UltrasonicSensorTwin _ultratemp = new(telemetry.UltrasonicSensor.Distance - ultraSonicDistanceOffset,
                                                                                        telemetry.UltrasonicSensor.Distance + ultraSonicDistanceOffset,
                                                                                        telemetry.UltrasonicSensor.Duration);

                                                //null check
                                                var _conditionTwoMaxD = _relationship.DeviceTwoReaction.GetValue("MaxDistance");
                                                var _conditionTwoMinD = _relationship.DeviceTwoReaction.GetValue("MinDistance");
                                                var maxDResult = DeviceRelationship.CheckRelationship(_conditionTwoMaxD.Condition, _ultratemp.MaxDistance, double.Parse(_conditionTwoMaxD.Value));
                                                var minDResult = DeviceRelationship.CheckRelationship(_conditionTwoMinD.Condition, _ultratemp.MinDistance, double.Parse(_conditionTwoMinD.Value));
                                                break;

                                            case "MotionSensor":
                                                MotionSensorTwin _motionSensor = new(telemetry.MotionSensor.MotionDetected);

                                                //null check
                                                var _conditionTwoM = _relationship.DeviceTwoReaction.GetValue("MotionDetected");
                                                var mResult = DeviceRelationship.CheckRelationship(_conditionTwoM.Condition, _motionSensor.MotionDetected.Value, bool.Parse(_conditionTwoM.Value));
                                                break;

                                            case "LedSensor":
                                                LedSensorTwin _ledSensor = new(telemetry.LedSensor.IsOn);

                                                //null check
                                                var _conditionTwoL = _relationship.DeviceTwoReaction.GetValue("IsOn");
                                                var lResult = DeviceRelationship.CheckRelationship(_conditionTwoL.Condition, _ledSensor.IsOn.Value, bool.Parse(_conditionTwoL.Value));
                                                break;
                                        }
                                    }
                                }

                                if (DeviceRelationship.CheckRelationship(conditionMaxD.Condition, ultrasonicSensorTwin.MaxDistance, double.Parse(conditionMaxD.Value)))
                                {
                                    var deviceType = _relationship.DeviceTwo.IOTSensorType;
                                    if (deviceType != null)
                                    {
                                        var _deviceIIClass = telemetry.GetClassBySensor(deviceType.Value);
                                        switch (_deviceIIClass)
                                        {
                                            case "DHT11Sensor":
                                                DHT11SensorTwin _dhttemp = new(telemetry.DHT11Sensor.Temperature - tempOffset, telemetry.DHT11Sensor.Temperature + tempOffset,
                                                                                telemetry.DHT11Sensor.Humidity - humOffset, telemetry.DHT11Sensor.Humidity + humOffset);

                                                //null check
                                                var _conditionTwoTemp = _relationship.DeviceTwoReaction.GetValue("Temperature");
                                                var _conditionTwoHum = _relationship.DeviceTwoReaction.GetValue("Humidity");
                                                var tempResult = DeviceRelationship.CheckRelationship(_conditionTwoTemp.Condition, _dhttemp.Temperature, double.Parse(_conditionTwoTemp.Value));
                                                var humResult = DeviceRelationship.CheckRelationship(_conditionTwoHum.Condition, _dhttemp.Temperature, double.Parse(_conditionTwoHum.Value));
                                                break;

                                            case "UltrasonicSensor":
                                                UltrasonicSensorTwin _ultratemp = new(telemetry.UltrasonicSensor.Distance - ultraSonicDistanceOffset,
                                                                                        telemetry.UltrasonicSensor.Distance + ultraSonicDistanceOffset,
                                                                                        telemetry.UltrasonicSensor.Duration);

                                                //null check
                                                var _conditionTwoMaxD = _relationship.DeviceTwoReaction.GetValue("MaxDistance");
                                                var _conditionTwoMinD = _relationship.DeviceTwoReaction.GetValue("MinDistance");
                                                var maxDResult = DeviceRelationship.CheckRelationship(_conditionTwoMaxD.Condition, _ultratemp.MaxDistance, double.Parse(_conditionTwoMaxD.Value));
                                                var minDResult = DeviceRelationship.CheckRelationship(_conditionTwoMinD.Condition, _ultratemp.MinDistance, double.Parse(_conditionTwoMinD.Value));
                                                break;

                                            case "MotionSensor":
                                                MotionSensorTwin _motionSensor = new(telemetry.MotionSensor.MotionDetected);

                                                //null check
                                                var _conditionTwoM = _relationship.DeviceTwoReaction.GetValue("MotionDetected");
                                                var mResult = DeviceRelationship.CheckRelationship(_conditionTwoM.Condition, _motionSensor.MotionDetected.Value, bool.Parse(_conditionTwoM.Value));
                                                break;

                                            case "LedSensor":
                                                LedSensorTwin _ledSensor = new(telemetry.LedSensor.IsOn);

                                                //null check
                                                var _conditionTwoL = _relationship.DeviceTwoReaction.GetValue("IsOn");
                                                var lResult = DeviceRelationship.CheckRelationship(_conditionTwoL.Condition, _ledSensor.IsOn.Value, bool.Parse(_conditionTwoL.Value));
                                                break;
                                        }
                                    }
                                }

                            }
                        }
                    }
                }

                //MotionSensor
                if (telemetry.MotionSensor != null)
                {
                    MotionSensorTwin motionSensorTwin = new(telemetry.MotionSensor.MotionDetected);

                    var motionStatus = motionSensorTwin.StatusCheck();
                    if (telemetry.MotionSensor.IOTDevice != null)
                    {
                        if (telemetry.MotionSensor.IOTDevice.DeviceRelationships.Count > 0)
                        {
                            foreach (var _relationship in telemetry.MotionSensor.IOTDevice.DeviceRelationships)
                            {
                                var condition = _relationship.DeviceOneCondition.GetValue("MotionDetected");
                                if (condition.Condition == Condition.EqualTo && motionSensorTwin.MotionDetected == bool.Parse(condition.Value))
                                {
                                    var deviceType = _relationship.DeviceTwo.IOTSensorType;
                                    if (deviceType != null)
                                    {
                                        var _deviceIIClass = telemetry.GetClassBySensor(deviceType.Value);
                                        switch (_deviceIIClass)
                                        {
                                            case "DHT11Sensor":
                                                DHT11SensorTwin _dhttemp = new(telemetry.DHT11Sensor.Temperature - tempOffset, telemetry.DHT11Sensor.Temperature + tempOffset,
                                                                                telemetry.DHT11Sensor.Humidity - humOffset, telemetry.DHT11Sensor.Humidity + humOffset);

                                                //null check
                                                var _conditionTwoTemp = _relationship.DeviceTwoReaction.GetValue("Temperature");
                                                var _conditionTwoHum = _relationship.DeviceTwoReaction.GetValue("Humidity");
                                                var tempResult = DeviceRelationship.CheckRelationship(_conditionTwoTemp.Condition, _dhttemp.Temperature, double.Parse(_conditionTwoTemp.Value));
                                                var humResult = DeviceRelationship.CheckRelationship(_conditionTwoHum.Condition, _dhttemp.Temperature, double.Parse(_conditionTwoHum.Value));
                                                break;

                                            case "UltrasonicSensor":
                                                UltrasonicSensorTwin _ultratemp = new(telemetry.UltrasonicSensor.Distance - ultraSonicDistanceOffset,
                                                                                        telemetry.UltrasonicSensor.Distance + ultraSonicDistanceOffset,
                                                                                        telemetry.UltrasonicSensor.Duration);

                                                //null check
                                                var _conditionTwoMaxD = _relationship.DeviceTwoReaction.GetValue("MaxDistance");
                                                var _conditionTwoMinD = _relationship.DeviceTwoReaction.GetValue("MinDistance");
                                                var maxDResult = DeviceRelationship.CheckRelationship(_conditionTwoMaxD.Condition, _ultratemp.MaxDistance, double.Parse(_conditionTwoMaxD.Value));
                                                var minDResult = DeviceRelationship.CheckRelationship(_conditionTwoMinD.Condition, _ultratemp.MinDistance, double.Parse(_conditionTwoMinD.Value));
                                                break;

                                            case "MotionSensor":
                                                MotionSensorTwin _motionSensor = new(telemetry.MotionSensor.MotionDetected);

                                                //null check
                                                var _conditionTwoM = _relationship.DeviceTwoReaction.GetValue("MotionDetected");
                                                var mResult = DeviceRelationship.CheckRelationship(_conditionTwoM.Condition, _motionSensor.MotionDetected.Value, bool.Parse(_conditionTwoM.Value));
                                                break;

                                            case "LedSensor":
                                                LedSensorTwin _ledSensor = new(telemetry.LedSensor.IsOn);

                                                //null check
                                                var _conditionTwoL = _relationship.DeviceTwoReaction.GetValue("IsOn");
                                                var lResult = DeviceRelationship.CheckRelationship(_conditionTwoL.Condition, _ledSensor.IsOn.Value, bool.Parse(_conditionTwoL.Value));
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                //CameraSensor
                if (telemetry.CameraSensor != null)
                {
                    var isPoweredOn = telemetry.CameraSensor?.DeviceStatus.PowerStatus == PowerStatus.On;
                    CameraSensorTwin cameraSensorTwin = new(isPoweredOn, telemetry.CameraSensor.Data);

                    var cameraStatus = cameraSensorTwin.StatusCheck();
                }

                //GPSModuleSensor
                if (telemetry.GPSModule != null)
                {
                    GPSModuleTwin gpsModuleTwin = new(telemetry.GPSModule.Longitude,
                        telemetry.GPSModule.Latitude);

                    var gpsStatus = gpsModuleTwin.StatusCheck();
                }

                //LedSensor
                if (telemetry.LedSensor != null)
                {
                    LedSensorTwin ledSensorTwin = new(telemetry.LedSensor.IsOn);
                    if (telemetry.LedSensor.IOTDevice != null)
                    {
                        var ledStatus = ledSensorTwin.StatusCheck();
                        if (telemetry.LedSensor.IOTDevice.DeviceRelationships.Count > 0)
                        {
                            foreach (var _relationship in telemetry.LedSensor.IOTDevice.DeviceRelationships)
                            {
                                var condition = _relationship.DeviceOneCondition.GetValue("IsOn");
                                if (condition.Condition == Condition.EqualTo && ledSensorTwin.IsOn == bool.Parse(condition.Value))
                                {
                                    var deviceType = _relationship.DeviceTwo.IOTSensorType;
                                    if (deviceType != null)
                                    {
                                        var _deviceIIClass = telemetry.GetClassBySensor(deviceType.Value);
                                        switch (_deviceIIClass)
                                        {
                                            case "DHT11Sensor":
                                                DHT11SensorTwin _dhttemp = new(telemetry.DHT11Sensor.Temperature - tempOffset, telemetry.DHT11Sensor.Temperature + tempOffset,
                                                                                telemetry.DHT11Sensor.Humidity - humOffset, telemetry.DHT11Sensor.Humidity + humOffset);

                                                //null check
                                                var _conditionTwoTemp = _relationship.DeviceTwoReaction.GetValue("Temperature");
                                                var _conditionTwoHum = _relationship.DeviceTwoReaction.GetValue("Humidity");
                                                var tempResult = DeviceRelationship.CheckRelationship(_conditionTwoTemp.Condition, _dhttemp.Temperature, double.Parse(_conditionTwoTemp.Value));
                                                var humResult = DeviceRelationship.CheckRelationship(_conditionTwoHum.Condition, _dhttemp.Temperature, double.Parse(_conditionTwoHum.Value));
                                                break;

                                            case "UltrasonicSensor":
                                                UltrasonicSensorTwin _ultratemp = new(telemetry.UltrasonicSensor.Distance - ultraSonicDistanceOffset,
                                                                                        telemetry.UltrasonicSensor.Distance + ultraSonicDistanceOffset,
                                                                                        telemetry.UltrasonicSensor.Duration);

                                                //null check
                                                var _conditionTwoMaxD = _relationship.DeviceTwoReaction.GetValue("MaxDistance");
                                                var _conditionTwoMinD = _relationship.DeviceTwoReaction.GetValue("MinDistance");
                                                var maxDResult = DeviceRelationship.CheckRelationship(_conditionTwoMaxD.Condition, _ultratemp.MaxDistance, double.Parse(_conditionTwoMaxD.Value));
                                                var minDResult = DeviceRelationship.CheckRelationship(_conditionTwoMinD.Condition, _ultratemp.MinDistance, double.Parse(_conditionTwoMinD.Value));
                                                break;

                                            case "MotionSensor":
                                                MotionSensorTwin _motionSensor = new(telemetry.MotionSensor.MotionDetected);

                                                //null check
                                                var _conditionTwoM = _relationship.DeviceTwoReaction.GetValue("MotionDetected");
                                                var mResult = DeviceRelationship.CheckRelationship(_conditionTwoM.Condition, _motionSensor.MotionDetected.Value, bool.Parse(_conditionTwoM.Value));
                                                break;

                                            case "LedSensor":
                                                LedSensorTwin _ledSensor = new(telemetry.LedSensor.IsOn);

                                                //null check
                                                var _conditionTwoL = _relationship.DeviceTwoReaction.GetValue("IsOn");
                                                var lResult = DeviceRelationship.CheckRelationship(_conditionTwoL.Condition, _ledSensor.IsOn.Value, bool.Parse(_conditionTwoL.Value));
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }

            return null;
        }
    }
}
