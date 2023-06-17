namespace DigitalTwinMiddleware.DTOs.Enums
{
    public enum IOTDeviceType
    {
        SmartPole, 
        SmartTap,
        SmartThermostats, 
        SmartLocks, 
        SmartLights, 
        SmartPlugsandSwitches, 
        SmartSecurityCameras, 
        SmartDoorbells, 
        SmartSpeakersandVoiceAssistants, 
        SmartAppliances, 
        FitnessTrackersandWearableTechnology, 
        SmartHomeHubsandControllers, 
        SmartIrrigationSystems, 
        SmartPetFeeders,
        SmartPowerMeters, 
        SmartParkingSystems,
        SmartWasteManagementSystems
    }

    public enum IOTSensorType
    {
        CameraSensors,
        TemperatureSensors,
        HumiditySensors,
        PressureSensors,
        ProximitySensors,
        MotionSensors,
        LightSensors,
        InfraredSensors,
        GasSensors,
        MagneticSensors,
        AccelerometerSensors,
        GyroscopeSensors,
        GPSSensors,
        SoundSensors,
        VibrationSensors,
        MoistureSensors,
        LedSensor
    }

    public enum IOTType
    {
        Standalone,
        Component
    }
}
