#ifndef MYUNITYPLUGIN_H
#define MYUNITYPLUGIN_H


#define MYUNITYPLUGIN_EXPORT

#define netID int
#include "Lib.h"
#include "network.h"

/*
* expose C functions for Unity.
* Use only primitive types b/c mapping is hard with structs / strings.
*
*
*
*
*/
#define __cplusplus
#ifdef __cplusplus
extern "C"
{
#else // !__cplusplus
#endif // __cplusplus

MYUNITYPLUGIN_SYMBOL int initNetwork(int numNetworkInstances);
MYUNITYPLUGIN_SYMBOL netID getNetworkInstance();
MYUNITYPLUGIN_SYMBOL int initClient(uString IP, int port, uString username, netID ID=0);
MYUNITYPLUGIN_SYMBOL int initServer(int port, uString username, int maxClients = 10, netID ID =0);
MYUNITYPLUGIN_SYMBOL int cleanup(netID ID=0);
MYUNITYPLUGIN_SYMBOL int sendMessage(char* message, netID ID = 0);
MYUNITYPLUGIN_SYMBOL int readMessage(char* message, int bufferSize, netID ID = 0);
MYUNITYPLUGIN_SYMBOL int checkConnection(netID ID = 0);
MYUNITYPLUGIN_SYMBOL int doEverything(bool isServer);

//send message
//for each event send message
MYUNITYPLUGIN_SYMBOL int sendColorEvent(float r, float g, float b, netID = 0);
MYUNITYPLUGIN_SYMBOL int sendDirectionEvent(float x, float y, float z, netID ID = 0);
MYUNITYPLUGIN_SYMBOL int sendMessageEvent(char* message, netID ID = 0);
MYUNITYPLUGIN_SYMBOL int sendSpeedEvent(float speed, netID ID = 0);

#ifdef __cplusplus
} // extern "C"
#else // !__cplusplus
#endif // __cplusplus


#endif // MYUNITYPLUGIN_H