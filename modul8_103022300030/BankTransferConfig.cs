using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_103022300030
{
     class BankTransferConfig
    {
        //Attribute untuk diserialisasi
        public int lang { get; set; }
        public int transfer { get; set; }
        //Constructor kosong untuk deserialisasi
        public BankTransferConfig() { }
        public BankTransferConfig(string lang, int transfer)
        {
            lang = lang;
            transfer = transfer;
        }

    }

    class UIConfig
    {
        public BankTransferConfig config;
        public const String filePath = @"config.json";

        public int Lang { get; private set; }
        public int Transfer { get; private set; }

        public UIConfig() { }
        private void SetDefault() {
            Console.WriteLine("ENG = Select transfer method:");
            Console.WriteLine("ID = Pilih metode transfer:");
        }
        private void WriteNewConfigFile() { }

        private BankTransferConfig ReadConfigFie()
        {
            String configJsonData = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<BankTransferConfig>(configJsonData);
            return config;
        }

        private void WriteNewConfigFiled()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            String jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }

    

        private void Form1_Load(object sender, EventArgs e)
        {
            //Membuat object konfigurasi
            UIConfig uIConfig = new UIConfig();
            //Membaca data konfigurasi untuk digunakan untuk setting
            Lang = uIConfig.config.lang;
            Transfer = uIConfig.config.transfer;
        }

    }


}



