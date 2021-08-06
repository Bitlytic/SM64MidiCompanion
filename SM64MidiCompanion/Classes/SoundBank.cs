using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM64MidiCompanion.Classes
{
    public class Instrument : IEquatable<Instrument>
    {
        [JsonProperty("release_rate")]
        public int releaseRate;
        public string envelope;
        public string sound;

        public bool Equals(Instrument other)
        {
            return envelope == other.envelope && sound == other.sound && releaseRate == other.releaseRate; 
        }
    }

    public class SoundBank
    {
        public string date;
        [JsonProperty("sample_bank")]
        public string sampleBank;
        public Dictionary<string, object> envelopes;
        [JsonProperty("instruments")]
        public Dictionary<string, object> instrumentMap;
        public Dictionary<string, Instrument> filteredInstrumentMap = new Dictionary<string, Instrument>();
        [JsonProperty("instrument_list")]
        public string[] instrumentList;

        public void FilterInstruments()
        {
            foreach (var inst in instrumentMap)
            {
                if (inst.Key.Equals("percussion"))
                {
                    continue;
                }

                Instrument instrument = JsonConvert.DeserializeObject<Instrument>(inst.Value.ToString());
                filteredInstrumentMap.Add(inst.Key, instrument);
            }
        }

        public List<Instrument> GetInstruments()
        {
            List<Instrument> ret = new List<Instrument>();

            foreach(var inst in filteredInstrumentMap)
            {
                if (instrumentList.Contains(inst.Key)) {
                    ret.Add(inst.Value);
                }
            }

            return ret;
        }

        public int GetInstrumentIndex(Instrument inst)
        {
            String name = "";

            foreach(var i in filteredInstrumentMap)
            {
                if(i.Value.Equals(inst))
                {
                    name = i.Key;
                    break;
                }
            }

            return Array.IndexOf(instrumentList, name);
        }

        public Instrument GetInstrumentFromBankIndex(int i)
        {
            if(i >= instrumentList.Length || i < 0)
            {
                return null;
            }

            String name = instrumentList[i];

            foreach(var inst in filteredInstrumentMap)
            {
                if(inst.Key == name)
                {
                    return inst.Value;
                }
            }

            return null;
        }
    }
}
