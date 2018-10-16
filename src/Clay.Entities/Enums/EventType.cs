namespace Clay.WebApi
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.11.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum EventType
    {
        [System.Runtime.Serialization.EnumMember(Value = "doorOpened")]
        DoorOpened = 0,

        [System.Runtime.Serialization.EnumMember(Value = "doorClosed")]
        DoorClosed = 1,

        [System.Runtime.Serialization.EnumMember(Value = "remoteLock")]
        RemoteLock = 2,

        [System.Runtime.Serialization.EnumMember(Value = "remoteUnlocked")]
        RemoteUnlocked = 3,

        [System.Runtime.Serialization.EnumMember(Value = "cardLock")]
        CardLock = 4,

        [System.Runtime.Serialization.EnumMember(Value = "cardUnlock")]
        CardUnlock = 5,

        [System.Runtime.Serialization.EnumMember(Value = "manualLock")]
        ManualLock = 6,

        [System.Runtime.Serialization.EnumMember(Value = "manualUnlocked")]
        ManualUnlocked = 7,

        [System.Runtime.Serialization.EnumMember(Value = "autoLock")]
        AutoLock = 8,
    }
}