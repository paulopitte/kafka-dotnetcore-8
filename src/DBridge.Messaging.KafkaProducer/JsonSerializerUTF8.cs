﻿namespace DBridge.Messaging.KafkaProducer
{
    using Confluent.Kafka;

    using Newtonsoft.Json;

    using System.Text;

    public class JsonSerializerUTF8<T> : ISerializer<T>
    {
        private readonly JsonSerializerSettings jsonSettings;
        private readonly Encoding encoder;

        public JsonSerializerUTF8()
        {
            jsonSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            };

            encoder = Encoding.UTF8;
        }

        public byte[] Serialize(T data, SerializationContext context)
        {
            return encoder.GetBytes(JsonConvert.SerializeObject(data, jsonSettings));
        }
    }
}
