using System;
using SoundViewer;


namespace OpenFAC.Library
{

    public class OpenCapSensorMicrophoneWindows : OpenCapSensorBase
    {

        private WaveInRecorder _recorder;
        private byte[] _recorderBuffer;
        private WaveFormat _waveFormat;
        private int _audioFrameSize = 11025;
        private byte _audioBitsPerSample = 16;
        private byte _audioChannels = 1;
  

        public new void Dispose()
        {
            Stop();
            base.Dispose();
        }

        public bool IsTrigged()
        {
            return true;
        }


        public override void Start()
        {
           
            _waveFormat = new WaveFormat(_audioFrameSize, _audioBitsPerSample, _audioChannels);
            _recorder = new WaveInRecorder(0, _waveFormat, _audioFrameSize * 2, 3, new BufferDoneEventHandler(DataArrived));
     
        }

        public void Open()
        {
        }


        public override void DoAction(SensorState state)
        {
            base.DoAction(state);
        }

        private void DataArrived(IntPtr data, int size)
        {
            if (_recorderBuffer == null || _recorderBuffer.Length < size)
                _recorderBuffer = new byte[size];
            if (_recorderBuffer != null)
            {
                System.Runtime.InteropServices.Marshal.Copy(data, _recorderBuffer, 0, size);
                float bigValue=0;
                int MaxValue = 80; //Level
                for (int index = 0; index < _recorderBuffer.Length; index += 2)
                {
                    short sample = (short)((_recorderBuffer[index + 1] << 8) |
                                           _recorderBuffer[index + 0]);
                    float sample32 = 100 * sample / 32768f;
                    if (bigValue < sample32)
                    {
                        bigValue = sample32;
                        if (bigValue > MaxValue)
                        {
                            DoAction(0);
                        }
                    }
                }
            }
        }

        public void Close()
        {

        }

        public void SetWaveFormat()
        {

        }

        public void SetTriggerLevel(int Level)
        {
        }

        public void SwapBuffers()
        {

        }

    }

}



