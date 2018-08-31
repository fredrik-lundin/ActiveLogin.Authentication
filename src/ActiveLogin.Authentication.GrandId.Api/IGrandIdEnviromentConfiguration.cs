﻿using System;

namespace ActiveLogin.Authentication.GrandId.Api
{
    public interface IGrandIdEnviromentConfiguration
    {
        Uri ApiBaseUrl { get; set; }
        string ApiKey { get; set; }
        string SameDeviceServiceKey { get; set; }
        string OtherDeviceServiceKey { get; set; }
        string ChooseDeviceServiceKey { get; set; }
    }
}