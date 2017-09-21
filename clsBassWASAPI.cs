using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

class BassWasapi
{
    public const int BASS_ERROR_WASAPI = 5000;
    public const int BASS_ERROR_WASAPI_BUFFER = 5001;
    // BASS_WASAPI_DEVICEINFO flags
    public const int BASS_DEVICE_ENABLED = 1;
    public const int BASS_DEVICE_DEFAULT = 2;
    public const int BASS_DEVICE_INIT = 4;
    public const int BASS_DEVICE_LOOPBACK = 8;
    public const int BASS_DEVICE_INPUT = 16;
    public const int BASS_DEVICE_UNPLUGGED = 32;
    public const int BASS_DEVICE_DISABLED = 64;

    // BASS_WASAPI_Init flags
    public enum BASSWASAPIInit
    {
        BASS_WASAPI_EXCLUSIVE = 1,
        BASS_WASAPI_AUTOFORMAT = 2,
        BASS_WASAPI_BUFFER = 4,
        BASS_WASAPI_EVENT = 16
    }
    /*
    public const int BASS_WASAPI_EXCLUSIVE = 1;
    public const int BASS_WASAPI_AUTOFORMAT = 2;
    public const int BASS_WASAPI_BUFFER = 4;
    public const int BASS_WASAPI_EVENT = 16;*/

    // BASS_WASAPI_INFO "format"
    public const int BASS_WASAPI_FORMAT_FLOAT = 0;
    public const int BASS_WASAPI_FORMAT_8BIT = 1;
    public const int BASS_WASAPI_FORMAT_16BIT = 2;
    public const int BASS_WASAPI_FORMAT_24BIT = 3;
    public const int BASS_WASAPI_FORMAT_32BIT = 4;

    // BASS_WASAPI_Set/GetVolume modes
    public enum BASSWASAPICURVE
    {
        BASS_WASAPI_CURVE_DB = 0,
        BASS_WASAPI_CURVE_LINEAR = 1,
        BASS_WASAPI_CURVE_WINDOWS = 2,
        BASS_WASAPI_VOL_SESSION = 8
    }
    /*
    public const int BASS_WASAPI_CURVE_DB = 0;
    public const int BASS_WASAPI_CURVE_LINEAR = 1;
    public const int BASS_WASAPI_CURVE_WINDOWS = 2;
    public const int BASS_WASAPI_VOL_SESSION = 8;*/

    // Device notifications
    public enum BASSWASAPINOTIFY
    {
        BASS_WASAPI_NOTIFY_ENABLED = 0,
        BASS_WASAPI_NOTIFY_DISABLED = 1,
        BASS_WASAPI_NOTIFY_DEFOUTPUT = 2,
        BASS_WASAPI_NOTIFY_DEFINPUT = 3
    }
    /*
    public const int BASS_WASAPI_NOTIFY_ENABLED = 0;
    public const int BASS_WASAPI_NOTIFY_DISABLED = 1;
    public const int BASS_WASAPI_NOTIFY_DEFOUTPUT = 2;
    public const int BASS_WASAPI_NOTIFY_DEFINPUT = 3;*/

    public struct BASS_WASAPI_DEVICEINFO
    {
        public string name;
        public string id;
        public uint type;
        public uint flags;
        public float minperiod;
        public float defperiod;
        public uint mixfreq;
        public uint mixchans;
        public BASS_WASAPI_DEVICEINFO(object _object_)
        {
            name = "";
            id = "";
            type = 0;
            flags = 0;
            minperiod = 0;
            defperiod = 0;
            mixfreq = 0;
            mixchans = 0;
        }
    }

    public struct BASS_WASAPI_INFO
    {
        public long initflags;
        public long freq;
        public long chans;
        public long format;
        public long buflen;
        public long volmax;
        public long volmin;
        public long volstep;
        public BASS_WASAPI_INFO(object _object_)
        {
            initflags = 0;
            freq = 0;
            chans = 0;
            format = 0;
            buflen = 0;
            volmax = 0;
            volmin = 0;
            volstep = 0;
        }
    }

    [DllImport("basswasapi.dll")]
    public static extern int BASS_WASAPI_GetVersion();

    [DllImport("basswasapi.dll")]
    public static extern bool BASS_WASAPI_SetNotify(
        WASAPINOTIFYPROC proc,
        IntPtr user
    );

    [DllImport("basswasapi.dll")]
    public static extern bool BASS_WASAPI_GetDeviceInfo(
        int device,
        BASS_WASAPI_DEVICEINFO info
    );

    [DllImport("basswasapi.dll")]
    public static extern float BASS_WASAPI_GetDeviceLevel(
        int device,
        int chan
    );

    [DllImport("basswasapi.dll")]
    public static extern bool BASS_WASAPI_SetDevice(int device);

    [DllImport("basswasapi.dll")]
    public static extern int BASS_WASAPI_GetDevice();

    [DllImport("basswasapi.dll")]
    public static extern void BASS_WASAPI_CheckFormat(
        int device,
        int freq,
        int chans,
        int flag
    );
    [DllImport("basswasapi.dll")]
    public static extern bool BASS_WASAPI_Init(
        int device,
        int freq,
        int chans,
        int flags,
        float buffer,
        float period,
        WASAPIPROC proc,
        IntPtr user
    );
    [DllImport("basswasapi.dll")]
    public static extern bool BASS_WASAPI_Free();

    [DllImport("basswasapi.dll")]
    public static extern bool BASS_WASAPI_GetInfo(BASS_WASAPI_INFO info);

    [DllImport("basswasapi.dll")]
    public static extern float BASS_WASAPI_GetCPU();

    [DllImport("basswasapi.dll")]
    public static extern float BASS_WASAPI_Lock(bool stage);

    [DllImport("basswasapi.dll")]
    public static extern bool BASS_WASAPI_Start();

    [DllImport("basswasapi.dll")]
    public static extern bool BASS_WASAPI_Stop(bool reset);

    [DllImport("basswasapi.dll")]
    public static extern bool BASS_WASAPI_IsStarted();

    [DllImport("basswasapi.dll")]
    public static extern long BASS_WASAPI_SetVolume(
        BASSWASAPICURVE mode,
        float value
    );

    [DllImport("basswasapi.dll")]
    public static extern float BASS_WASAPI_GetVolume(BASSWASAPICURVE mode);

    [DllImport("basswasapi.dll")]
    public static extern bool BASS_WASAPI_SetMute(
        int mode,
        bool muted
    );

    [DllImport("basswasapi.dll")]
    public static extern bool BASS_WASAPI_GetMute(int mode);

    [DllImport("basswasapi.dll")]
    public static extern int BASS_WASAPI_PutData(
        byte[] buffer,
        uint length
    );

    [DllImport("basswasapi.dll")]
    public static extern int BASS_WASAPI_PutData(
        IntPtr buffer,
        uint length
    );

    [DllImport("basswasapi.dll")]
    public static extern int BASS_WASAPI_PutData(
        int[] buffer,
        uint length
    );

    [DllImport("basswasapi.dll")]
    public static extern int BASS_WASAPI_PutData(
        float[] buffer,
        uint length
    );

    [DllImport("basswasapi.dll")]
    public static extern int BASS_WASAPI_GetData(
        byte[] buffer,
        uint length
    );

    [DllImport("basswasapi.dll")]
    public static extern int BASS_WASAPI_GetData(
        int[] buffer,
        uint length
    );

    [DllImport("basswasapi.dll")]
    public static extern int BASS_WASAPI_GetData(
        float[] buffer,
        uint length
    );

    [DllImport("basswasapi.dll")]
    public static extern int BASS_WASAPI_GetData(
        IntPtr buffer,
        uint length
    );

    [DllImport("basswasapi.dll")]
    public static extern int BASS_WASAPI_GetLevel();

    [DllImport("basswasapi.dll")]
    public static extern bool BASS_WASAPI_GetLevelEx(float levels, float length, int flags);

    public delegate void WASAPINOTIFYPROC(
        BASSWASAPINOTIFY notify,
        int device,
        IntPtr user
    );

    public delegate int WASAPIPROC(
        IntPtr buffer,
        int length,
        IntPtr user
    );

    public static int LowByte(int value)
    {
        return value & 0xFF;
    }
    public static int HiByte(int value)
    {
        return (value & 0xFF00) / 0x100;
    }
    public static int LowWord(int value)
    {
        return value & 0x0000FFFF;
    }
    public static int HiWord(int value)
    {
        return value / 0x10000;
    }
}
