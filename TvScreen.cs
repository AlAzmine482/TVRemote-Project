using System;

namespace TvRemoteExample
{

    public abstract class TvDevice{
        public string ModelName { get;  set; }
        public bool IsOn { get; internal set; }

        public abstract void TurnOn();
        public abstract void TurnOff();
        public abstract void volumeUp();
        public abstract void volumeDown();
        public abstract void ChannelNumber(int channel);
        public abstract void channelUp();
        public abstract void channelDown();
        public abstract void Model();
        public abstract void Screensize();
        public abstract void UPCCODe();
        public abstract void countryofOrgin();
        public abstract void mute();
        public abstract void BrightnessDown();
        public abstract void BrightnessUp();
        public abstract void ContrastDown();
        public abstract void ContrastUp();
        public abstract void SharpnessDown();
        public abstract void SharpnessUp();
    } 
}
