# EM24-Victron
EM24 Victron Emulation mit C#

## WR  SUN2000-17KTL-M5
Der WR ist ein HUAWEI SUN2000-17KTL-M5, verbunden mit Modbus RTU und per WAVESHARE RS485 to RJ45 zu ModbusTCP gewandelt. [Modbus Read WR](src/ModbusSun2000.cs) 

![Screenshot 2025-04-26 124717](https://github.com/user-attachments/assets/c9acb060-d0ac-41ae-a6f0-1bf05c0a3973)

## GRID Siemens PAC2200
Das Grid wird vor der Verbidnug zum Netzbetreiber per Siemens PAC2200 gemessen, der PAC2200 kann per ModbusTCP [Modbus Read GRID](src/ModbusPAC2200.cs)  oder per API Schnittstelle [API Read GRID](src/Pac2200_RESTAPI.cs)  bedient werden. 


## VRM Portal Dashboard

![Screenshot 2025-04-26 123152](https://github.com/user-attachments/assets/0ad7c0cd-69fe-4c2c-a715-bb09d78c0d85)
![Screenshot 2025-04-26 123210](https://github.com/user-attachments/assets/16454533-de1b-47ba-9bd8-2d597bdaeef9)

VRM Portal Erweitert

Grid:
![Screenshot 2025-04-26 123251](https://github.com/user-attachments/assets/07879511-4e57-4b9a-bc94-96406adf7226)

WR:
![Screenshot 2025-04-26 123245](https://github.com/user-attachments/assets/44f546d4-6f75-4b18-b010-676b044147b0)


## Werte in Victron Device

Der Modbus Master wird mit [API Read GRID](src/LoopModbusMaster.cs) dem Multiplus II GX zur verfügung gestellt.

Auf Multiplus II GX einlogen per ssh als root:

Folgende dBus Register sind vorhanden und können eingesehen werden:

```bash
root@nanopi:~# dbus -y
org.freedesktop.DBus
com.victronenergy.hub4
com.victronenergy.grid.cg_SolarViewWR1
com.victronenergy.settings
com.victronenergy.battery.socketcan_can0
com.victronenergy.pvinverter.cg_SplarViewWR1
com.victronenergy.system
com.victronenergy.vebus.ttyS3
org.bluez
com.victronenergy.fronius
com.victronenergy.platform
net.connman
com.victronenergy.modbusclient.tcp
org.freedesktop.Avahi
debug.victronenergy.gui
fi.w1.wpa_supplicant1
com.victronenergy.logger
com.victronenergy.adc
com.victronenergy.modbustcp
```

Die zwei EM24 Geräte welche ich emuliere ist das GRID und der WR:
```bash
com.victronenergy.grid.cg_SolarViewWR1
com.victronenergy.pvinverter.cg_SplarViewWR1
```

Werte im Grid sind:
```bash
root@nanopi:~# dbus -y com.victronenergy.grid.cg_SolarViewWR1 / GetValue
{'Ac/Energy/Forward': 12084.0,
 'Ac/Energy/Reverse': 11623.0,
 'Ac/Frequency': 50.0,
 'Ac/L1/Current': 4.778,
 'Ac/L1/Energy/Forward': 5714.9,
 'Ac/L1/Power': 1124.0,
 'Ac/L1/Voltage': 237.8,
 'Ac/L2/Current': -5.927,
 'Ac/L2/Energy/Forward': 4113.0,
 'Ac/L2/Power': -1394.0,
 'Ac/L2/Voltage': 237.5,
 'Ac/L3/Current': -6.41,
 'Ac/L3/Energy/Forward': 3883.3,
 'Ac/L3/Power': -1510.0,
 'Ac/L3/Voltage': 236.9,
 'Ac/Power': -1780.0,
 'AllowedRoles': ['grid',
                  'pvinverter',
                  'genset',
                  'acload',
                  'evcharger',
                  'heatpump'],
 'Connected': 1,
 'CustomName': 'GRID',
 'DeviceInstance': 40,
 'FirmwareVersion': 3585,
 'HardwareVersion': 2305,
 'Mgmt/Connection': 'Modbus TCP 192.168.30.5',
 'Mgmt/ProcessName': 'dbus-modbus-client.py',
 'Mgmt/ProcessVersion': '1.61',
 'Model': 'EM24DINAV23XE1PFB',
 'NrOfPhases': 3,
 'PhaseConfig': 0.0,
 'PhaseSequence': 0.0,
 'ProductId': 45079,
 'ProductName': 'Carlo Gavazzi EM24 Ethernet Energy Meter',
 'Role': 'grid',
 'Serial': 'SolarViewWR1',
 'SwitchPos': 3.0}
```

Werte im WR sind:
```bash
root@nanopi:~# dbus -y com.victronenergy.pvinverter.cg_SplarViewWR1 / GetValue
{'Ac/Energy/Forward': 19360.8,
 'Ac/Energy/Reverse': 0.0,
 'Ac/Frequency': 50.0,
 'Ac/L1/Current': 7.62,
 'Ac/L1/Energy/Forward': 6453.6,
 'Ac/L1/Power': 1816.3,
 'Ac/L1/Voltage': 238.2,
 'Ac/L2/Current': 7.61,
 'Ac/L2/Energy/Forward': 6453.6,
 'Ac/L2/Power': 1816.9,
 'Ac/L2/Voltage': 238.9,
 'Ac/L3/Current': 7.627,
 'Ac/L3/Energy/Forward': 6453.6,
 'Ac/L3/Power': 1807.8,
 'Ac/L3/Voltage': 236.9,
 'Ac/Power': 5394.0,
 'AllowedRoles': ['grid',
                  'pvinverter',
                  'genset',
                  'acload',
                  'evcharger',
                  'heatpump'],
 'Connected': 1,
 'CustomName': 'PV',
 'DeviceInstance': 42,
 'FirmwareVersion': 3585,
 'HardwareVersion': 2305,
 'Mgmt/Connection': 'Modbus TCP 192.168.30.5',
 'Mgmt/ProcessName': 'dbus-modbus-client.py',
 'Mgmt/ProcessVersion': '1.61',
 'Model': 'EM24DINAV23XE1PFB',
 'NrOfPhases': 3,
 'PhaseConfig': 0.0,
 'PhaseSequence': 0.0,
 'Position': 0,
 'ProductId': 45079,
 'ProductName': 'Carlo Gavazzi EM24 Ethernet Energy Meter',
 'Role': 'pvinverter',
 'Serial': 'SplarViewWR1',
 'SwitchPos': 3.0}
```




