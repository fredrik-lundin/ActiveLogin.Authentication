﻿using System.IO;
using ActiveLogin.Authentication.BankId.AspNetCore.Models;
using Microsoft.AspNetCore.Authentication;

namespace ActiveLogin.Authentication.BankId.AspNetCore.Serialization
{
    public class BankIdStateSerializer : IDataSerializer<BankIdState>
    {
        private const int FormatVersion = 1;

        public byte[] Serialize(BankIdState model)
        {
            using (var memory = new MemoryStream())
            {
                using (var writer = new BinaryWriter(memory))
                {
                    writer.Write(FormatVersion);
                    PropertiesSerializer.Default.Write(writer, model.AuthenticationProperties);
                    writer.Flush();
                    return memory.ToArray();
                }
            }
        }

        public BankIdState Deserialize(byte[] data)
        {
            using (var memory = new MemoryStream(data))
            {
                using (var reader = new BinaryReader(memory))
                {
                    if (reader.ReadInt32() != FormatVersion)
                    {
                        return null;
                    }

                    var authenticationProperties = PropertiesSerializer.Default.Read(reader);
                    if (authenticationProperties == null)
                    {
                        return null;
                    }

                    return new BankIdState
                    {
                        AuthenticationProperties = authenticationProperties
                    };
                }
            }
        }
    }
}