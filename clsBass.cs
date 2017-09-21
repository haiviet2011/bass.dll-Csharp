using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
class Bass
{
    public const int BASSVERSION = 0x204;
    // BASS_ChannelGetLength/GetPosition/SetPosition modes
    public const int BASS_POS_BYTE = 0;          // byte position
    public const int BASS_POS_MUSIC_ORDER = 1;   // order.row position, MAKELONG(order,row)
    public const int BASS_POS_OGG = 3;           // OGG bitstream number
    public const int BASS_POS_INEXACT = 0x8000000; // flag: allow seeking to inexact position
    public const int BASS_POS_DECODE = 0x10000000; // flag: get the decoding (not playing) position
    public const int BASS_POS_DECODETO = 0x20000000; // flag: decode to the position instead of seeking
    public const int BASS_POS_SCAN = 0x40000000; // flag: scan to the position
    // BASS_ChannelGetTags types : what's returned
    public const int BASS_TAG_ID3 = 0;                // ID3v1 tags : TAG_ID3 structure
    public const int BASS_TAG_ID3V2 = 1;              // ID3v2 tags : variable length block
    public const int BASS_TAG_OGG = 2;                // OGG comments : series of null-terminated UTF-8 strings
    public const int BASS_TAG_HTTP = 3;               // HTTP headers : series of null-terminated ANSI strings
    public const int BASS_TAG_ICY = 4;                // ICY headers : series of null-terminated ANSI strings
    public const int BASS_TAG_META = 5;               // ICY metadata : ANSI string
    public const int BASS_TAG_APE = 6;                // APEv2 tags : series of null-terminated UTF-8 strings
    public const int BASS_TAG_MP4 = 7;                // MP4/iTunes metadata : series of null-terminated UTF-8 strings
    public const int BASS_TAG_VENDOR = 9;             // OGG encoder : UTF-8 string
    public const int BASS_TAG_LYRICS3 = 10;           // Lyric3v2 tag : ASCII string
    public const int BASS_TAG_CA_CODEC = 11;          // CoreAudio codec info : TAG_CA_CODEC structure
    public const int BASS_TAG_MF = 13;                // Media Foundation tags : series of null-terminated UTF-8 strings
    public const int BASS_TAG_WAVEFORMAT = 14;        // WAVE format : WAVEFORMATEEX structure
    public const int BASS_TAG_RIFF_INFO = 0x100;      // RIFF "INFO" tags : series of null-terminated ANSI strings
    public const int BASS_TAG_RIFF_BEXT = 0x101;      // RIFF/BWF "bext" tags : TAG_BEXT structure
    public const int BASS_TAG_RIFF_CART = 0x102;      // RIFF/BWF "cart" tags : TAG_CART structure
    public const int BASS_TAG_RIFF_DISP = 0x103;      // RIFF "DISP" text tag : ANSI string
    public const int BASS_TAG_APE_BINARY = 0x1000;    // + index #, binary APEv2 tag : TAG_APE_BINARY structure
    public const int BASS_TAG_MUSIC_NAME = 0x10000;   // MOD music name : ANSI string
    public const int BASS_TAG_MUSIC_ORDERS = 0x10002; // MOD order list : BYTE array of pattern numbers
    public const int BASS_TAG_MUSIC_MESSAGE = 0x10001; // MOD message : ANSI string
    public const int BASS_TAG_MUSIC_INST = 0x10100;   // + instrument #, MOD instrument name : ANSI string
    public const int BASS_TAG_MUSIC_SAMPLE = 0x10300; // + sample #, MOD sample name : ANSI string
    #region Config
    #region Bass_Config

    public const int BASS_CONFIG_BUFFER = 0;
    public const int BASS_CONFIG_UPDATEPERIOD = 1;
    public const int BASS_CONFIG_GVOL_SAMPLE = 4;
    public const int BASS_CONFIG_GVOL_STREAM = 5;
    public const int BASS_CONFIG_GVOL_MUSIC = 6;
    public const int BASS_CONFIG_CURVE_VOL = 7;
    public const int BASS_CONFIG_CURVE_PAN = 8;
    public const int BASS_CONFIG_FLOATDSP = 9;
    public const int BASS_CONFIG_3DALGORITHM = 10;
    public const int BASS_CONFIG_NET_TIMEOUT = 11;
    public const int BASS_CONFIG_NET_BUFFER = 12;
    public const int BASS_CONFIG_PAUSE_NOPLAY = 13;
    public const int BASS_CONFIG_NET_PREBUF = 15;
    public const int BASS_CONFIG_NET_PASSIVE = 18;
    public const int BASS_CONFIG_REC_BUFFER = 19;
    public const int BASS_CONFIG_NET_PLAYLIST = 21;
    public const int BASS_CONFIG_MUSIC_VIRTUAL = 22;
    public const int BASS_CONFIG_VERIFY = 23;
    public const int BASS_CONFIG_UPDATETHREADS = 24;
    public const int BASS_CONFIG_DEV_BUFFER = 27;
    public const int BASS_CONFIG_VISTA_TRUEPOS = 30;
    public const int BASS_CONFIG_DEV_DEFAULT = 36;
    public const int BASS_CONFIG_NET_READTIMEOUT = 37;
    public const int BASS_CONFIG_VISTA_SPEAKERS = 38;
    public const int BASS_CONFIG_MF_DISABLE = 40;
    public const int BASS_CONFIG_HANDLES = 41;
    public const int BASS_CONFIG_UNICODE = 42;
    public const int BASS_CONFIG_SRC = 43;
    public const int BASS_CONFIG_SRC_SAMPLE = 44;
    public const int BASS_CONFIG_ASYNCFILE_BUFFER = 45;
    public const int BASS_CONFIG_OGG_PRESCAN = 47;
    public const int BASS_CONFIG_MF_VIDEO = 48;
    public const int BASS_CONFIG_VERIFY_NET = 52;
    // BASS_SetConfigPtr options
    public const int BASS_CONFIG_NET_AGENT = 16;
    public const int BASS_CONFIG_NET_PROXY = 17;
    #endregion
    [DllImport("bass.dll")]
    public static extern int BASS_SetConfig(int opt, bool value);

    [DllImport("bass.dll")]
    public static extern int BASS_GetConfig(int opt);

    [DllImport("bass.dll")]
    public static extern int BASS_SetConfigPtr(int opt, dynamic value);

    [DllImport("bass.dll")]
    public static extern int BASS_GetConfigPtr(int opt);
    #endregion
    #region Main
    public struct BASS_DEVICEINFO
    {
        public long name; // description
        public long driver; // driver
        public long flags;

        public BASS_DEVICEINFO(object _object_)
        {
            name = 0;
            driver = 0;
            flags = 0;
        }

    }


    public struct BASS_INFO
    {
        public long flags; // device capabilities (DSCAPS_xxx flags)
        public long hwsize; // size of total device hardware memory
        public long hwfree; // size of free device hardware memory
        public long freesam; // number of free sample slots in the hardware
        public long free3d; // number of free 3D sample slots in the hardware
        public long minrate; // min sample rate supported by the hardware
        public long maxrate; // max sample rate supported by the hardware
        public long eax; // device supports EAX? (always BASSFALSE if BASS_DEVICE_3D was not used)
        public long minbuf; // recommended minimum buffer length in ms (requires BASS_DEVICE_LATENCY)
        public long dsver; // DirectSound version
        public long latency; // delay (in ms) before start of playback (requires BASS_DEVICE_LATENCY)
        public long initflags; // BASS_Init "flags" parameter
        public long speakers; // number of speakers available
        public long freq; // current output rate

        public BASS_INFO(object _object_)
        {
            flags = 0;
            hwsize = 0;
            hwfree = 0;
            freesam = 0;
            free3d = 0;
            minrate = 0;
            maxrate = 0;
            eax = 0;
            minbuf = 0;
            dsver = 0;
            latency = 0;
            initflags = 0;
            speakers = 0;
            freq = 0;
        }

    }
    [DllImport("bass.dll")]
    public static extern int BASS_GetVersion();

    [DllImport("bass.dll")]
    public static extern int BASS_ErrorGetCode();

    [DllImport("bass.dll")]
    public static extern bool BASS_GetDeviceInfo(int device, BASS_DEVICEINFO dinfo);

    [DllImport("bass.dll")]
    public static extern bool BASS_Init(int device, int freq, int flags, IntPtr win, int guid);

    [DllImport("bass.dll")]
    public static extern int BASS_SetDevice(int device);

    [DllImport("bass.dll")]
    public static extern int BASS_GetDevice();

    [DllImport("bass.dll")]
    public static extern bool BASS_Free();

    [DllImport("bass.dll")]
    public static extern int BASS_GetDSoundObject(int __object);

    [DllImport("bass.dll")]
    public static extern int BASS_GetInfo(BASS_INFO info);

    [DllImport("bass.dll")]
    public static extern int BASS_Update(int legnth);

    [DllImport("bass.dll")]
    public static extern float BASS_GetCPU();

    [DllImport("bass.dll")]
    public static extern int BASS_Start();

    [DllImport("bass.dll")]
    public static extern int BASS_Stop();

    [DllImport("bass.dll")]
    public static extern int BASS_Pause();

    [DllImport("bass.dll")]
    public static extern int BASS_SetVolume(float volume);

    [DllImport("bass.dll")]
    public static extern float BASS_GetVolume();
    #endregion
    #region Plugin
    [DllImport("bass.dll")]
    public static extern int BASS_PluginLoad(string filename, int flags);

    [DllImport("bass.dll")]
    public static extern int BASS_PluginFree(int handle);

    [DllImport("bass.dll")]
    public static extern int BASS_PluginGetInfo_(int handle);
    #endregion
    #region 3D & EAX
    [DllImport("bass.dll")]
    public static extern int BASS_Set3DFactors(float distf, float rollf, float doppf);

    [DllImport("bass.dll")]
    public static extern int BASS_Get3DFactors(ref float distf, ref float rollf, ref float doppf);

    [DllImport("bass.dll")]
    public static extern int BASS_Set3DPosition(ref dynamic pos, ref dynamic vel, ref dynamic front, ref dynamic top);

    [DllImport("bass.dll")]
    public static extern int BASS_Get3DPosition(ref dynamic pos, ref dynamic vel, ref dynamic front, ref dynamic top);

    [DllImport("bass.dll")]
    public static extern int BASS_Apply3D();

    [DllImport("bass.dll")]
    public static extern int BASS_SetEAXParameters(int env, float vol, float decay, float damp);

    [DllImport("bass.dll")]
    public static extern int BASS_GetEAXParameters(ref int env, ref float vol, ref float decay, ref float damp);
    #endregion
    #region Music
    [DllImport("bass.dll")]
    public static extern int BASS_MusicLoad64(int mem, dynamic file, int offset, int offsethigh, int length, int flags, int freq);

    [DllImport("bass.dll")]
    public static extern int BASS_MusicFree(int handle);
    #endregion
    #region Sample
    [DllImport("bass.dll")]
    public static extern int BASS_SampleLoad64(int mem, dynamic file, int offset, int offsethigh, int length, int max, int flags);

    [DllImport("bass.dll")]
    public static extern int BASS_SampleCreate(int length, int freq, int chans, int max, int flags);

    [DllImport("bass.dll")]
    public static extern int BASS_SampleFree(int handle);

    [DllImport("bass.dll")]
    public static extern int BASS_SampleSetData(int handle, ref dynamic buffer);

    [DllImport("bass.dll")]
    public static extern int BASS_SampleGetData(int handle, ref dynamic buffer);

    [DllImport("bass.dll")]
    public static extern int BASS_SampleGetInfo(int handle, ref dynamic info);

    [DllImport("bass.dll")]
    public static extern int BASS_SampleSetInfo(int handle, ref dynamic info);

    [DllImport("bass.dll")]
    public static extern int BASS_SampleGetChannel(int handle, int onlynew);

    [DllImport("bass.dll")]
    public static extern int BASS_SampleGetChannels(int handle, ref int channels);

    [DllImport("bass.dll")]
    public static extern int BASS_SampleStop(int handle);
    #endregion
    #region Stream
    [DllImport("bass.dll")]
    public static extern uint BASS_StreamCreate(uint freq, uint chans, uint flags, uint proc, uint user);

    [DllImport("bass.dll")]
    public static extern uint BASS_StreamCreateFile(bool mem, string file, ulong offset, ulong length, uint flags);

    [DllImport("bass.dll")]
    public static extern uint BASS_StreamCreateURL(string url, uint offset, uint flags, DOWNLOADPROC proc, IntPtr user);

    [DllImport("bass.dll")]
    public static extern uint BASS_StreamCreateFileUser(uint system, uint flags, uint procs, uint user);

    [DllImport("bass.dll")]
    public static extern uint BASS_StreamFree(uint handle);

    [DllImport("bass.dll")]
    public static extern uint BASS_StreamGetFilePosition(uint handle, uint mode);

    [DllImport("bass.dll")]
    public static extern uint BASS_StreamPutData(uint handle, ref dynamic buffer, uint length);

    [DllImport("bass.dll")]
    public static extern uint BASS_StreamPutFileData(uint handle, ref dynamic buffer, uint length);
    #endregion
    #region Record
    public delegate bool RECORDPROC(uint handle, IntPtr buffer, uint length, IntPtr user);

    [DllImport("bass.dll")]
    public static extern uint BASS_RecordGetDeviceInfo(uint device, ref dynamic info);

    [DllImport("bass.dll")]
    public static extern uint BASS_RecordInit(int device);

    [DllImport("bass.dll")]
    public static extern uint BASS_RecordSetDevice(uint device);

    [DllImport("bass.dll")]
    public static extern uint BASS_RecordGetDevice();

    [DllImport("bass.dll")]
    public static extern uint BASS_RecordFree();

    [DllImport("bass.dll")]
    public static extern uint BASS_RecordGetInfo(ref dynamic info);

    [DllImport("bass.dll")]
    public static extern uint BASS_RecordGetInputName(uint inputn);

    [DllImport("bass.dll")]
    public static extern uint BASS_RecordSetInput(uint inputn, uint flags, float volume);

    [DllImport("bass.dll")]
    public static extern uint BASS_RecordGetInput(uint inputn, ref float volume);

    [DllImport("bass.dll")]
    public static extern uint BASS_RecordStart(uint freq, uint chans, uint flags, RECORDPROC proc, IntPtr user);
    #endregion
    #region Channel
    #region var
    public struct BASS_CHANNELINFO
    {
        public uint freq, chans, flags, ctype, origres, plugin, sample;
        public string filename;
        public BASS_CHANNELINFO(object _object)
        {
            freq = 0;
            chans = 0;
            flags = 0;
            ctype = 0;
            origres = 0;
            plugin = 0;
            sample = 0;
            filename = "";
        }
    }
    #endregion
    #region BASS_Channel Attributes
    public const uint BASS_ATTRIB_FREQ = 1;
    public const uint BASS_ATTRIB_VOL = 2;
    public const uint BASS_ATTRIB_PAN = 3;
    public const uint BASS_ATTRIB_EAXMIX = 4;
    public const uint BASS_ATTRIB_NOBUFFER = 5;
    public const uint BASS_ATTRIB_VBR = 6;
    public const uint BASS_ATTRIB_CPU = 7;
    public const uint BASS_ATTRIB_SRC = 8;
    public const uint BASS_ATTRIB_NET_RESUME = 9;
    public const uint BASS_ATTRIB_SCANINFO = 10;
    public const uint BASS_ATTRIB_MUSIC_AMPLIFY = 0x100;
    public const uint BASS_ATTRIB_MUSIC_PANSEP = 0x101;
    public const uint BASS_ATTRIB_MUSIC_PSCALER = 0x102;
    public const uint BASS_ATTRIB_MUSIC_BPM = 0x103;
    public const uint BASS_ATTRIB_MUSIC_SPEED = 0x104;
    public const uint BASS_ATTRIB_MUSIC_VOL_GLOBAL = 0x105;
    public const uint BASS_ATTRIB_MUSIC_ACTIVE = 0x106;
    public const uint BASS_ATTRIB_MUSIC_VOL_CHAN = 0x200; // + channel #
    public const uint BASS_ATTRIB_MUSIC_VOL_INST = 0x300; // + instrument #
    #endregion
    #region BASS_Channel_GetData
    public const uint BASS_DATA_AVAILABLE = 0;         // query how much data is buffered
    public const uint BASS_DATA_FIXED = 0x20000000;    // flag: return 8.24 fixed-point data
    public const uint BASS_DATA_FLOAT = 0x40000000;    // flag: return floating-point sample data
    public const uint BASS_DATA_FFT256 = 0x80000000;   // 256 sample FFT
    public const uint BASS_DATA_FFT512 = 0x80000001;   // 512 FFT
    public const uint BASS_DATA_FFT1024 = 0x80000002;  // 1024 FFT
    public const uint BASS_DATA_FFT2048 = 0x80000003;  // 2048 FFT
    public const uint BASS_DATA_FFT4096 = 0x80000004;  // 4096 FFT
    public const uint BASS_DATA_FFT8192 = 0x80000005;  // 8192 FFT
    public const uint BASS_DATA_FFT16384 = 0x80000006; // 16384 FFT
    public const uint BASS_DATA_FFT_INDIVIDUAL = 0x10; // FFT flag: FFT for each channel, else all combined
    public const uint BASS_DATA_FFT_NOWINDOW = 0x20;   // FFT flag: no Hanning window
    public const uint BASS_DATA_FFT_REMOVEDC = 0x40;   // FFT flag: pre-remove DC bias
    public const uint BASS_DATA_FFT_COMPLEX = 0x80;    // FFT flag: return complex data
    #endregion

    [DllImport("bass.dll")]
    public static extern double BASS_ChannelBytes2Seconds(uint handle, ulong pos);

    [DllImport("bass.dll")]
    public static extern ulong BASS_ChannelSeconds2Bytes(uint handle, double pos);

    [DllImport("bass.dll")]
    public static extern uint BASS_ChannelGetDevice(uint handle);

    [DllImport("bass.dll")]
    public static extern bool BASS_ChannelSetDevice(uint handle, uint device);

    [DllImport("bass.dll")]
    public static extern uint BASS_ChannelIsActive(uint handle);

    [DllImport("bass.dll")]
    public static extern bool BASS_ChannelGetInfo(uint handle, BASS_CHANNELINFO info);

    [DllImport("bass.dll")]
    public static extern string BASS_ChannelGetTags(uint handle, uint tags);

    [DllImport("bass.dll")]
    public static extern uint BASS_ChannelFlags(uint handle, uint flags, uint mask);

    [DllImport("bass.dll")]
    public static extern bool BASS_ChannelUpdate(uint handle, uint length);

    [DllImport("bass.dll")]
    public static extern bool BASS_ChannelLock(uint handle, bool lock_);

    [DllImport("bass.dll")]
    public static extern bool BASS_ChannelPlay(uint handle, bool restart);

    [DllImport("bass.dll")]
    public static extern bool BASS_ChannelStop(uint handle);

    [DllImport("bass.dll")]
    public static extern bool BASS_ChannelPause(uint handle);

    [DllImport("bass.dll")]
    public static extern bool BASS_ChannelSetAttribute(uint handle, uint attrib, float value);

    [DllImport("bass.dll")]
    public static extern bool BASS_ChannelGetAttribute(uint handle, uint attrib, ref float value);

    [DllImport("bass.dll")]
    public static extern bool BASS_ChannelSlideAttribute(uint handle, uint attrib, float value, uint time);

    [DllImport("bass.dll")]
    public static extern bool BASS_ChannelIsSliding(uint handle, uint attrib);

    [DllImport("bass.dll")]
    public static extern bool BASS_ChannelSetAttributeEx(uint handle, uint attrib, ref dynamic value, uint size);

    [DllImport("bass.dll")]
    public static extern bool BASS_ChannelGetAttributeEx(uint handle, uint attrib, ref dynamic value, uint size);

    [DllImport("bass.dll")]
    public static extern uint BASS_ChannelSet3DAttributes(uint handle, uint mode, float min, float max, uint iangle, uint oangle, float outvol);

    [DllImport("bass.dll")]
    public static extern uint BASS_ChannelGet3DAttributes(uint handle, ref uint mode, ref float min, ref float max, ref uint iangle, ref uint oangle, ref float outvol);

    [DllImport("bass.dll")]
    public static extern uint BASS_ChannelSet3DPosition(uint handle, ref dynamic pos, ref dynamic orient, ref dynamic vel);

    [DllImport("bass.dll")]
    public static extern uint BASS_ChannelGet3DPosition(uint handle, ref dynamic pos, ref dynamic orient, ref dynamic vel);

    [DllImport("bass.dll")]
    public static extern uint BASS_ChannelGetLength(uint handle, uint mode);

    [DllImport("bass.dll")]
    public static extern bool BASS_ChannelSetPosition(uint handle, ulong pos, uint mode);

    [DllImport("bass.dll")]
    public static extern ulong BASS_ChannelGetPosition(uint handle, uint mode);

    [DllImport("bass.dll")]
    public static extern int BASS_ChannelGetLevel(uint handle);

    [DllImport("bass.dll")]
    public static extern uint BASS_ChannelGetLevelEx(uint handle, ref float levels, float length, uint flags);

    /*[ DllImport( "bass.dll")]
    public static extern uint BASS_ChannelGetData(uint handle, ref dynamic buffer, uint length);*/

    [DllImport("bass.dll")]
    public static extern uint BASS_ChannelGetData(uint handle, byte[] buffer, uint length);

    [DllImport("bass.dll")]
    public static extern uint BASS_ChannelGetData(uint handle, short[] buffer, uint length);

    [DllImport("bass.dll")]
    public static extern uint BASS_ChannelGetData(uint handle, int[] buffer, uint length);

    [DllImport("bass.dll")]
    public static extern uint BASS_ChannelGetData(uint handle, IntPtr buffer, uint length);

    [DllImport("bass.dll")]
    public static extern uint BASS_ChannelGetData(uint handle, float[] buffer, uint length);


    [DllImport("bass.dll")]
    public static extern uint BASS_ChannelSetSync64(uint handle, uint type_, uint param, uint paramhigh, uint proc, uint user);

    [DllImport("bass.dll")]
    public static extern uint BASS_ChannelRemoveSync(uint handle, uint sync);

    [DllImport("bass.dll")]
    public static extern uint BASS_ChannelSetDSP(uint handle, uint proc, uint user, uint priority);

    [DllImport("bass.dll")]
    public static extern uint BASS_ChannelRemoveDSP(uint handle, uint dsp);

    [DllImport("bass.dll")]
    public static extern uint BASS_ChannelSetLink(uint handle, uint chan);

    [DllImport("bass.dll")]
    public static extern uint BASS_ChannelRemoveLink(uint handle, uint chan);

    [DllImport("bass.dll")]
    public static extern uint BASS_ChannelSetFX(uint handle, uint type_, uint priority);

    [DllImport("bass.dll")]
    public static extern uint BASS_ChannelRemoveFX(uint handle, uint fx);
    #endregion
    #region FX
    [DllImport("bass.dll")]
    public static extern int BASS_FXSetParameters(int handle, ref dynamic par);

    [DllImport("bass.dll")]
    public static extern int BASS_FXGetParameters(int handle, ref dynamic par);

    [DllImport("bass.dll")]
    public static extern int BASS_FXReset(int handle);
    #endregion
    #region Function
    public delegate void DOWNLOADPROC(long buffer, long length, long user);
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
    #endregion
}
