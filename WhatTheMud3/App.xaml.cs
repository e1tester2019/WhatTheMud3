﻿namespace WhatTheMud3;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt+QHFqVkNrXVNbdV5dVGpAd0N3RGlcdlR1fUUmHVdTRHRcQl5hTH9SdkdnX3ZddHM=;Mgo+DSMBPh8sVXJ1S0d+X1RPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSX1Rc0RiWX1adn1QRmc=;ORg4AjUWIQA/Gnt2VFhhQlJBfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5QdEBiWH9cdHJcQWBb;MTQ2NzE4NkAzMjMxMmUzMTJlMzMzNUFOa2luRTBidTBpc01HWFVDUTRiWTFBUm5kamwxMTZBS0JFYXkvQXVCWmc9;MTQ2NzE4N0AzMjMxMmUzMTJlMzMzNVpHb2QvdklvQzhsdWN6Z2FObkY1L1Q3bzQwdXo4YTJXbEtZNWRBRnlvV009;NRAiBiAaIQQuGjN/V0d+XU9Hc1RDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS31TdUdmWH5ecnBSRmRVVg==;MTQ2NzE4OUAzMjMxMmUzMTJlMzMzNU1CNzh1Z2pZUkY4UlJkTkZGL3FDVHZCcmdaMjM3bFJIZ2ZoZllGcXZwMzQ9;MTQ2NzE5MEAzMjMxMmUzMTJlMzMzNUtYbEFQSTh5dXNBbHE1Q2lRcCtYOW94anpmUzRyZmdpUStIc0ZNY0ZkYkk9;Mgo+DSMBMAY9C3t2VFhhQlJBfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5QdEBiWH9cdHNURGZb;MTQ2NzE5MkAzMjMxMmUzMTJlMzMzNW52UFB5NkxBYlAxbk9abFVMRGNRV29xQi9HRHZOdmU4bGxNVlZQZTh5OEU9;MTQ2NzE5M0AzMjMxMmUzMTJlMzMzNWFOWkNlaUtrR0t2SWJPWVZOSjNwaWtCcDNxdkNzWWxDZUM0eWlhWFNlUHM9;MTQ2NzE5NEAzMjMxMmUzMTJlMzMzNU1CNzh1Z2pZUkY4UlJkTkZGL3FDVHZCcmdaMjM3bFJIZ2ZoZllGcXZwMzQ9");
		MainPage = new AppShell();

	}
}